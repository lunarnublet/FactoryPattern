using FactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class MyLabel : AbstractElement
    {
        public MyLabel(int height, int width, int x, int y) : base(height, width, x, y)
        {
        }
    }
}
