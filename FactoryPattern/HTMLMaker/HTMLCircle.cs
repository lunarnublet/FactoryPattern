using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE;

namespace HTMLMaker
{
    class HTMLCircle : AbstractElement
    {
        public HTMLCircle(string content, int height = 20, int width = 20, int x = 0, int y = 0) : base(content, height, width, x, y)
        {
        }

        public override string Serialize()
        {
            return "<svg height = \"" + Height + "\" width = \"" + Width + "\" style=\"left:" + X +"; top:" + Y + "; position:absolute;\">" +
                        "<circle cx = \"" + Width / 2 + "\" cy = \"" + Height / 2 + "\" r = \"" + ((Height < Width) ? (Height / 2) : (Width / 2)) + "\" stroke = \"black\" stroke - width = \"3\" fill = \"red\"/>" +
                    "</svg>";
        }

        public override string ToString()
        {
            return "Circle" + (Content == null ? "" : ": " + Content);
        }
    }
}
