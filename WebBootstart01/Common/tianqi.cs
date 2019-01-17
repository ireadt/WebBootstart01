using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Xfrog.Net;
using System.Diagnostics;
using System.Web;
using WebBootstart01.Models;

//----------------------------------
// 全国天气预报调用示例代码 － 聚合数据
// 在线接口文档：http://www.juhe.cn/docs/39
// 代码中JsonObject类下载地址:http://download.csdn.net/download/gcm3206021155665/7458439
//----------------------------------

namespace WebBootstart01.Common
{
    public static class tianqi
    {
        static string appkey = "290169713ae8ec5a978a8c8285417f4a";
        public static Weather GetWeatherByCityName(string city)
        {
            
            //配置您申请的appkey
            //1.根据城市名/id查询天气
            string url = "http://v.juhe.cn/weather/index";

            var parameters1 = new Dictionary<string, string>();

            parameters1.Add("cityname", "柳州"); //城市名或城市ID，如：&quot;苏州&quot;，需要utf8 urlencode
            parameters1.Add("dtype", "json"); //返回数据格式：json或xml,默认json
            parameters1.Add("format", "1"); //未来6天预报(future)两种返回格式，1或2，默认1
            parameters1.Add("key",appkey);//你申请的key

            string result1 = sendPost(url, parameters1, "get");

            JsonObject newObj1 = new JsonObject(result1);
            String errorCode1 = newObj1["error_code"].Value;

            if (errorCode1 == "0")
            {
                return ConverToWerther(newObj1);
            }
            else
            {
                //Debug.WriteLine("失败");
                return null;
            }
        }
        public static Weather ConverToWerther(JsonObject jsonObj)
        {
            Weather wt = new Weather();
            wt.City = jsonObj["result"].Object["today"].Object["city"].Value;
            wt.Humidity = jsonObj["result"].Object["sk"].Object["Humidity"].Value;
            wt.Temperature = jsonObj["result"].Object["today"].Object["temperature"].Value;
            return wt;
        }
        /// <summary>
        /// Http (GET/POST)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <returns>响应内容</returns>
        static string sendPost(string url, IDictionary<string, string> parameters, string method)
        {
            if (method.ToLower() == "post")
            {
                HttpWebRequest req = null;
                HttpWebResponse rsp = null;
                System.IO.Stream reqStream = null;
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = method;
                    req.KeepAlive = false;
                    req.ProtocolVersion = HttpVersion.Version10;
                    req.Timeout = 5000;
                    req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                    byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters, "utf8"));
                    reqStream = req.GetRequestStream();
                    reqStream.Write(postData, 0, postData.Length);
                    rsp = (HttpWebResponse)req.GetResponse();
                    Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    return GetResponseAsString(rsp, encoding);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (reqStream != null) reqStream.Close();
                    if (rsp != null) rsp.Close();
                }
            }
            else
            {
                //创建请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?" + BuildQuery(parameters, "utf8"));

                //GET请求
                request.Method = "GET";
                request.ReadWriteTimeout = 5000;
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

                //返回内容
                string retString = myStreamReader.ReadToEnd();
                return retString;
            }
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        static string BuildQuery(IDictionary<string, string> parameters, string encode)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name))//&& !string.IsNullOrEmpty(value)
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }
                    postData.Append(name);
                    postData.Append("=");
                    if (encode == "gb2312")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding("gb2312")));
                    }
                    else if (encode == "utf8")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    }
                    else
                    {
                        postData.Append(value);
                    }
                    hasParam = true;
                }
            }
            return postData.ToString();
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            System.IO.Stream stream = null;
            StreamReader reader = null;
            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }
    }
}
