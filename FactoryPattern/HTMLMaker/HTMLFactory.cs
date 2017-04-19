using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE;
using System.IO;
using System.Diagnostics;

namespace HTMLMaker
{
    public class HTMLFactory : AbstractFactory
    {
        public override void Build(List<AbstractElement> elements)
        {
            string s = "";
            s += GetBeginnings();
            foreach (var element in elements)
            {
                s += element.Serialize() + "\r\n";
            }
            s += GetEndings();

            StreamWriter writer = new StreamWriter("D:\\YourOutput.html");
            writer.Write(s);
            writer.Flush();
            writer.Close();

            Process.Start("D:\\YourOutput.html");
        }

        public override string GetBeginnings()
        {
            string s = @"<!DOCTYPE html>
                        <html>
                            <body>
                        ";
            return s;
        }

        public override List<string> GetElementTypes()
        {
            return new List<string>() { "button", "label", "circle", "list" };
        }

        public override string GetEndings()
        {
            string s = @"
                            </body>
                         </html>
                        ";
            return s;
        }

        public override AbstractElement GetInstance(string type, string content, int height, int width, int x, int y)
        {
            switch (type)
            {
                case "button":
                    return new HTMLButton(content, height, width, x, y);
                case "label":
                    return new HTMLLabel(content, height, width, x, y);
                case "circle":
                    return new HTMLCircle(content, height, width, x, y);
                case "list":
                    return new HTMLList(content, height, width, x, y);
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            return "HTML";
        }
    }
}
