using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLibrary
{
    public class Manager
    {
        private AbstractFactory Factory { get; set; }
        public List<string> Elements {get; private set; }

        public Manager(AbstractFactory factory)
        {
            this.Factory = factory;
        }

        public void AddElement(string elementName, int height, int width, int x, int y)
        {
            Elements.Add(Factory.GetInstance(elementName, height, width, x, y));
        }

        public void AddBeginnings()
        {
            Factory.AddBeginnings();
        }

        public void AddEndings()
        {
            Factory.AddEndings();
        }
    }
}
