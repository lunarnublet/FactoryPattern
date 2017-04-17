using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using IDE;

namespace FactoryPattern
{
    class MyButton : AbstractElement
    {
        public MyButton(int height, int width, int x, int y) : base(height, width, x, y)
        {
        }
    }
}
