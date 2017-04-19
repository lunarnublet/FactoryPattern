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

        public AbstractElement(string content, int height = 20, int width = 20, int x = 0, int y = 0)
        {
            this.Content = content;
            this.Height = height;
            this.Width = width;
            this.X = x;
            this.Y = y;
        }
        public abstract string Serialize();
    }
}
