using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE;

namespace HTMLMaker
{
    class HTMLLabel : AbstractElement
    {
        public HTMLLabel(string content, int height = 20, int width = 20, int x = 0, int y = 0) : base(content, height, width, x, y)
        {
        }

        public override string Serialize()
        {
            return "< label style=' height:" + Height + "px; width:" + 
                    Width + "px; margin-left: " + X + "px; margin-top: " + 
                    Y + "px;\"  >" + Content + "</ label >";
        }

        public override string ToString()
        {
            return "Label" + (Content == null ? "" : ": " + Content);
        }
    }
}
