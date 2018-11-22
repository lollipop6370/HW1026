using System;
using ConsoleApp1.Model;
using ConsoleApp1.Service;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ImportService importService = new Service.ImportService();

            var nodes = importService.FindOpenData();

            importService.ImportToDb(nodes);

            showOpenData(nodes);
            Console.ReadKey();
        }

        public static void showOpenData(List<OpenData> nodes)
        {
            Console.WriteLine(string.Format("登記在台北市的工廠，總共有{0}家", nodes.Count));
            nodes.GroupBy(node => node.REGI_ID).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var allDatas = group.ToList();
                    var message = $"\n擁有此註冊序號:{key}的工廠數量為：{allDatas.Count()}";
                    Console.WriteLine(message);
                });


        }
    }
}