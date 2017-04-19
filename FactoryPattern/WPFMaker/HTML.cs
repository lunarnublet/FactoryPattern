using IDE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMaker
{
    public class HtmlButton : AbstractElement
    {
        public HtmlButton(string content, int height = 20, int width = 20, int x = 0, int y = 0) : base(content, height, width, x, y)
        {
        }

        public override string Serialize()
        {
            return $"<button type=\"button\" style=\"margin:{X}px, {Y}px;width:{Width}px;height:{Height}px;\">{Content}</button>";
        }
    }

    public class HtmlCheckBox : AbstractElement
    {
        public HtmlCheckBox(string content, int height = 20, int width = 20, int x = 0, int y = 0) : base(content, height, width, x, y)
        {
        }

        public override string Serialize()
        {
            return $"<input type=\"checkbox\" style=\"margin:{X}px, {Y}px;width:{Width}px;height:{Height}px;\">{Content}</p>";
        }
    }

    public class HtmlTextBox : AbstractElement
    {
        public HtmlTextBox(string content, int height = 20, int width = 20, int x = 0, int y = 0) : base(content, height, width, x, y)
        {
        }

        public override string Serialize()
        {
            return $"<input type=\"text\" style=\"margin:{X}px, {Y}px;width:{Width}px;height:{Height}px;\">{Content}</p>";
        }
    }

    public class HtmlLabel : AbstractElement
    {
        public HtmlLabel(string content, int height = 20, int width = 20, int x = 0, int y = 0) : base(content, height, width, x, y)
        {
        }

        public override string Serialize()
        {
            return $"<p style=\"margin:{X}px, {Y}px;width:{Width}px;height:{Height}px;\">{Content}</p>";
        }
    }
}
