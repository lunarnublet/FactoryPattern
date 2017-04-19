using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE
{
    public abstract class AbstractFactory
    {
        public override abstract string ToString();

        public abstract AbstractElement GetInstance(string type, string content, int height, int width, int x, int y);
        public abstract string GetBeginnings();
        public abstract string GetEndings();
        public abstract void Build(List<AbstractElement> elements);
        public abstract List<string> GetElementTypes();
    }
}
