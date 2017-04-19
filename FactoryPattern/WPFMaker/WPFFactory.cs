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

        private void BuildFoo(List<AbstractElement> elements)
        {
            string s = "";
            s += "using System;";
            s += "using System.Collections.Generic;\r\n";
            s += "using System.Linq;\r\n";
            s += "using System.Text;\r\n";
            s += "using System.Threading.Tasks;\r\n";
            s += "using System.Windows;\r\n";
            s += "using System.Windows.Controls;\r\n";
            s += "using System.Windows.Data;\r\n";
            s += "using System.Windows.Documents;\r\n";
            s += "using System.Windows.Input;\r\n";
            s += "using System.Windows.Media;\r\n";
            s += "using System.Windows.Media.Imaging;\r\n";
            s += "using System.Windows.Navigation;\r\n";
            s += "using System.Windows.Shapes;\r\n";
            s += "namespace WpfApp {\r\n";
            s += "public partial class MainWindow : Window {\r\n";
            s += "public MainWindow() {\r\n";
            s += "InitializeComponent();\r\n";

            foreach (var element in elements)
            {
                s += $"Root.Children.Add({element.Serialize()});\r\n";
            }
            s += "}";
            s += "}";
            s += "}";

            string fileToWrite = "../../WpfApp/MainWindow.xaml.cs";

            if (!File.Exists(fileToWrite))
            {
                File.Create(fileToWrite);
            }

            System.Threading.Thread.Sleep(1000);
            using (StreamWriter writer = new StreamWriter(fileToWrite))
            {
                writer.Write(s);
                writer.Flush();
                writer.Close();
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\msbuild.exe",
                    Arguments = "../../WpfApp/WpfApp.csproj",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                Console.WriteLine(line);
            }

            try
            {
                var runBuild = Process.Start("..\\..\\WpfApp\\bin\\Debug\\WpfApp.exe");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.WriteLine("Failed to run WpfApp.exe");
            }
        }

        public override void Build(List<AbstractElement> elements)
        {
            BuildFoo(elements);
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

        public override string ToString()
        {
            return "WPF";
        }
    }
}
