using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBootstart01.Models
{
    public class Weather
    {
        [Display(Name ="温度")]
        public string Temperature { get; set; }
        [Display(Name = "城市")]
        public string City { get; set; }
        //public string WeatherInfo { get; set; }
        //public string Wind_strength { get; set; }
        [Display(Name = "湿度")]
        public string Humidity { get; set; }
    }

}