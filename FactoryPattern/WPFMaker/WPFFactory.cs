using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE;
using System.IO;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace WPFMaker
{
    class WPFFactory : AbstractFactory
    {

        public override void Build(List<AbstractElement> elements)
        {
            string s = "";
            s += GetBeginnings();
            foreach (var element in elements)
            {
                s += element.Serialize();
            }
            s += GetEndings();

            StreamWriter writer = new StreamWriter("D:\\YourOutput.cs");
            writer.Write(s);
            writer.Flush();
            writer.Close();
        }

        public override string GetBeginnings()
        {
            string s = @"
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
            using System.Windows;
            using System.Windows.Controls;
            using System.Windows.Data;
            using System.Windows.Documents;
            using System.Windows.Input;
            using System.Windows.Media;
            using System.Windows.Media.Imaging;
            using System.Windows.Navigation;
            using System.Windows.Shapes;
            using System.IO;
            using FactoryPattern;

            namespace WPFMaker
    {
        public partial class TheirWindow : Window
        {
            private Canvas canvas = new Canvas();

            public TheirWindow()
            {
                this.Background = Brushes.White;
                this.Topmost = true;

                this.Width = 400;
                this.Height = 300;
                canvas.Width = this.Width;
                canvas.Height = this.Height;
                canvas.Background = Brushes.Black;
                this.Content = canvas;
                ";

            return s;
        }

        public override List<string> GetElementTypes()
        {
            return new List<string>() { "button", "label" };
        }

        public override string GetEndings()
        {
            string s = @"this.Show();
                    }
                }
            }
            ";
            return s;
        }

        public override AbstractElement GetInstance(string type, string content, int height, int width, int x, int y)
        {
            switch (type)
            {
                case "button":
                    return new WPFButton(content, height, width, x, y);
                case "label":
                    return new WPFLabel(content, height, width, x, y);
                default:
                    return null;
            }
        }
    }
}
