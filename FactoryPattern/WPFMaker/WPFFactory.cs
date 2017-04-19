using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE;
using System.IO;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.Build.Evaluation;

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


            using (StreamWriter writer = new StreamWriter("WpfApp/MainWindow.cs"))
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
                    Arguments = "test.csproj",
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
        }

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

            StreamReader reader = new StreamReader("D:\\YourOutput.cs");

            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            string Output = "YourOutput.exe";



            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters()
            {
                ReferencedAssemblies = { "System.dll", "System.Core.dll",
                                            "PresentationFramework.dll", "PresentationCore.dll",
                                            "Microsoft.CSharp.dll", "System.Xaml.dll", "WindowsBase.dll"
                                            }

            };
            //Make sure we generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;


            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, reader.ReadToEnd());

            if (results.Errors.Count > 0)
            {

            }
            else
            {
                Process.Start(Output);
                //Successful Compile
                //textBox2.ForeColor = Color.Blue;
                //textBox2.Text = "Success!";
                ////If we clicked run then launch our EXE
                //if (ButtonObject.Text == "Run") Process.Start(Output);
            }

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

        public override List<string> GetElements()
        {
            return new List<string>()
            {
                "button",
                "label"
            };
        }

        public override string ToString()
        {
            return "WPF";
        }
    }
}
