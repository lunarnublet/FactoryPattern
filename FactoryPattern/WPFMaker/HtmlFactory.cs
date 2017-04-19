using IDE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMaker
{
    public class HtmlFactory : AbstractFactory
    {
        public override void Build(List<AbstractElement> elements)
        {
            throw new NotImplementedException();
        }

        public override string GetBeginnings()
        {
            throw new NotImplementedException();
        }

        public override string GetEndings()
        {
            throw new NotImplementedException();
        }

        public override AbstractElement GetInstance(string type, string content, int height, int width, int x, int y)
        {
            switch(type)
            {
                case "button":
                    return new HtmlButton(content, height, width, x, y);
                case "label":
                    return new HtmlLabel(content, height, width, x, y);
                case "checkbox":
                    return new HtmlCheckBox(content, height, width, x, y);
                case "textbox":
                    return new HtmlTextBox(content, height, width, x, y);
                default:
                    return null;
            }
        }

        public override List<string> GetElements()
        {
            return new List<string>()
            {
                "button",
                "label",
                "checkbox",
                "textbox"
            };
        }

        public override string ToString()
        {
            return "HTML";
        }
    }
}
