using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE;

namespace HTMLMaker
{
    class HTMLList : AbstractElement
    {
        public HTMLList(string content, int height = 20, int width = 20, int x = 0, int y = 0) : base(content, height, width, x, y)
        {
        }

        public override string Serialize()
        {
            return "<select style=\" height:" + Height + "px; width:" +
                   Width + "px; margin-left: " + X + "px; margin-top: " + Y + "px;\"  >" + "</ button >";
        }
    }
}
