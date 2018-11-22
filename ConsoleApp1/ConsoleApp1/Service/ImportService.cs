using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp1.Service
{
    public class ImportService
    {
        public List<OpenData> FindOpenData()
        {

            List<OpenData> result = new List<OpenData>();

            string baseDir = Directory.GetCurrentDirectory();
            //@"taipeiFactory.xml"
            var xml = XElement.Load(System.IO.Path.Combine(baseDir, "AppData/taipeiFactory.xml"));
            var nodes = xml.Descendants("FCDBDATA").ToList();
            /*for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                OpenData item = new OpenData();

                item.REGI_ID = getValue(node, "REGI_ID");
                item.FACT_NAME = getValue(node, "FACT_NAME");
                item.FACT_ADDR = getValue(node, "FACT_ADDR");
                item.BNAME = getValue(node, "BNAME");
                item.ADDR_X = getValue(node, "ADDR_X");
                item.ADDR_Y = getValue(node, "ADDR_Y");

                result.Add(item);

            }*/
            /*nodes.ToList()
                .ForEach(node =>
                {
                    OpenData item = new OpenData();

                    item.REGI_ID = getValue(node, "REGI_ID");
                    item.FACT_NAME = getValue(node, "FACT_NAME");
                    item.FACT_ADDR = getValue(node, "FACT_ADDR");
                    item.BNAME = getValue(node, "BNAME");
                    item.ADDR_X = getValue(node, "ADDR_X");
                    item.ADDR_Y = getValue(node, "ADDR_Y");
                    result.Add(item);
                });*/

            result = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    OpenData item = new OpenData();

                    item.REGI_ID = getValue(node, "REGI_ID");
                    item.FACT_NAME = getValue(node, "FACT_NAME");
                    item.FACT_ADDR = getValue(node, "FACT_ADDR");
                    item.BNAME = getValue(node, "BNAME");
                    item.ADDR_X = getValue(node, "ADDR_X");
                    item.ADDR_Y = getValue(node, "ADDR_Y");
                    return item;
                }).ToList();

            return result;
        }

        public void ImportToDb(List<OpenData> openDatas)
        {
            Repository.OpenDataRepository Repository = new Repository.OpenDataRepository();
            openDatas.ForEach(item => {
                Repository.Insert(item);
            });
        }

        private string getValue(XElement node, string header)
        {
            return node.Element(header)?.Value?.Trim();
        }
    }
}
