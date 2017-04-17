using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDE;

namespace FactoryPattern
{
    class MyFactory : AbstractFactory
    {
        public override string GetBeginnings()
        {
            throw new NotImplementedException();
        }

        public override string GetEndings()
        {
            throw new NotImplementedException();
        }

        public override AbstractElement GetInstance(string type, int height, int width, int x, int y)
        {
            switch (type)
            {
                case "button":
                    return new MyButton(height, width, x, y);
                case "label":
                    return new MyLabel(height, width, x, y);
                default:
                    return null;
            }
        }
    }
}
