using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using IDE;

namespace WPFMaker
{
    class WPFButton : AbstractElement
    {
        public WPFButton(string content, int height = 20, int width = 20, int x = 0, int y = 0) : base(content, height, width, x, y)
        {
        }

        public override string Serialize()
        {
            string s = "";

            s += "new Button(){";
            s += $"Content = \"{Content}\",";
            s += $"Width = {Width},";
            s += $"Height = {Height},";
            s += $"Margin = new System.Windows.Thickness({X}, {Y}, {X}, {Y})";
            s += "}";

            //s += "Button " + Content + " = new Button();\r\n";
            //s += Content + ".Height = " + Height + ";\r\n";
            //s += Content + ".Width = " + Width + ";\r\n";
            //s += Content + ".Margin = new System.Windows.Thickness(" + X + "," + Y + ",0,0);\r\n";
            //s += Content + ".Content = " + Content + ";\r\n";

            return s;
        }

        public override string ToString()
        {
            return "Button" + (Content == null ? "" : ": " + Content);
        }
    }
}
