using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMaker;
using IDE;
using HTMLMaker;
using System.Windows;

namespace Program
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application app = new Application();
            app.Run(new IDEWindow(new List<AbstractFactory>{new WPFFactory(), new HTMLFactory()}));
        }
    }
}
