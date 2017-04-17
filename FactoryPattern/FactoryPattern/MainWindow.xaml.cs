using System;
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


using System.CodeDom.Compiler;
using System.Diagnostics;

namespace FactoryPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();


            //StreamWriter writer = new StreamWriter("..\\..\\test.txt");
            //writer.Write("hello world");
            //writer.Flush();
            //Window window2 = new Window();

            //window2.Show();
//            StreamWriter writer = new StreamWriter("..\\..\\WPFTest.cs");
//            writer.Write(@"using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.IO;
//using FactoryPattern;

//namespace TheirWPFApplication
//{
//    public partial class TheirWindow : Window
//    {
//        private Canvas canvas = new Canvas();

//        public TheirWindow()
//        {
//            this.Background = Brushes.White;
//            this.Topmost = true;

//            this.Width = 400;
//            this.Height = 300;
//            canvas.Width = this.Width;
//            canvas.Height = this.Height;
//            canvas.Background = Brushes.Black;
//            this.Content = canvas;
//            this.Show();
//        }
//    }
//}
//                        ");
//            writer.Flush();

            StreamReader reader = new StreamReader("..\\..\\WPFTest.cs");

            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            string Output = "Test.exe";

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


            TestWindow window = new TestWindow();
        }
    }
}
