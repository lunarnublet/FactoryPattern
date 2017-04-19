using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE;

namespace HTMLMaker
{
    class HTMLButton : AbstractElement
    {
        public HTMLButton(string content, int height = 20, int width = 20, int x = 0, int y = 0) : base(content, height, width, x, y)
        {

        }

        public override string Serialize()
        {
            return "<button type = \"button\" style=\" height:" + Height + "px; width:" + 
                    Width + "px; margin-left: " + X + "px; margin-top: " + Y + "px;\">" + 
                    Content + "</button>";
        }

        public override string ToString()
        {
            return "Button" + (Content == null ? "" : ": " + Content);
        }
    }
}
