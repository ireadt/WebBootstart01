using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public class Program
    {
        public string Name { get; set; }
        public int age { get; set; }
        static void Main(string[] args)
        {
            List<Program> AnList = new List<Program>();
            Program sl = new Program();
            sl.Name = "11:";
            sl.age = 19;

            AnList.Add(sl);


            foreach(var lit in AnList)
            {
                Console.WriteLine("名字:{0} || 年龄:{1}", lit.Name, lit.age);
            }
            Console.ReadKey();

            
        }
    }
}
