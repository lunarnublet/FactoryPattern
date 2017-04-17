using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IDE
{
    public abstract class AbstractElement
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Content { get; set; }

        public AbstractElement(int height, int width, int x, int y)
        {
            this.Height = height;
            this.Width = width;
            this.X = x;
            this.Y = y;
        }
    }
}
