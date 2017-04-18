using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMaker
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IDE.IDEWindow IDE = new IDE.IDEWindow(new WPFFactory());
        }
    }
}
