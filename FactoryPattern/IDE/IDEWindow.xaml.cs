using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;

namespace IDE
{
    /// <summary>
    /// Interaction logic for IDEWindow.xaml
    /// </summary>
    public partial class IDEWindow : Window
    {
        private AbstractFactory Factory { get; set; }
        public List<AbstractElement> Elements { get; private set; }

        //public void AddElement(string elementName, int height, int width, int x, int y)
        //{
        //    Elements.Add(Factory.GetInstance(elementName, height, width, x, y));
        //}

        public IDEWindow(AbstractFactory factory)
        {
            Elements = new List<AbstractElement>();
            this.Factory = factory;
            DoStuff("YourOutput.cs");
        }

        private void DoStuff(string path)
        {
            string s = "";
            s += Factory.GetBeginnings();
            foreach (var element in Elements)
            {
                s += element.Serialize();
            }
            s += Factory.GetEndings();

            StreamWriter writer = new StreamWriter(path);
            writer.Write(s);
            writer.Flush();
            writer.Close();

            StreamReader reader = new StreamReader(path);

            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            string Output = "YourOutput.exe";

            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
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

        private void Build(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
