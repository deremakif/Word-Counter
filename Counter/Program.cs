using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<String> listStrLineElements;
                StreamReader sr = new StreamReader(@"C:\Users\mehmet akif\Desktop\Park Net\mobydick.txt");

                XmlDocument doc = new XmlDocument(); 
                XmlNode rootNode = doc.CreateElement("Words");
                doc.AppendChild(rootNode);

                string line;
                line = sr.ReadLine();
                string totalstring = sr.ReadLine();

                while ((line != null))
                {
                    totalstring = totalstring + " " + sr.ReadLine();
                    line = sr.ReadLine();

                }

                string totalstring1 = totalstring.ToLower();
                listStrLineElements = totalstring1.Split(new[] { ' ', ',', ';', '.', ':', '?', '!', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var groups = listStrLineElements.GroupBy(w => w).OrderByDescending(group => group.Count());
                

                foreach (var item in groups)
                {
                    XmlNode dkelime = doc.CreateElement("word");
                    XmlAttribute kelime = doc.CreateAttribute("text");
                    XmlAttribute sayi = doc.CreateAttribute("count");


                    kelime.InnerText = item.Key;
                    sayi.InnerText = item.Count().ToString();
                    dkelime.Attributes.Append(kelime);
                    dkelime.Attributes.Append(sayi);
                    rootNode.AppendChild(dkelime);
                }

                doc.Save(@"C:\Users\mehmet akif\Desktop\Park Net\mobydick.xml");
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
