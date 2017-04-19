using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IDE
{
    /// <summary>
    /// Interaction logic for IDEWindow.xaml
    /// </summary>
    public partial class IDEWindow : Window
    {
        private AbstractFactory Factory { get; set; }
        public List<AbstractElement> Elements { get; private set; }

        public ObservableCollection<string> ComboBoxElements = new ObservableCollection<string>();
        public ObservableCollection<string> ComboBoxTargets = new ObservableCollection<string>();

        //public void AddElement(string elementName, int height, int width, int x, int y)
        //{
        //    Elements.Add(Factory.GetInstance(elementName, height, width, x, y));
        //}

        public IDEWindow(AbstractFactory factory)
        {
            InitializeComponent();
            Elements = new List<AbstractElement>();
            this.Factory = factory;
            //SaveCompileAndRun("YourOutput.cs");
            var canvas = new Canvas();

            ComboBoxTargets.Add(factory.ToString());

            foreach (var str in factory.GetElements())
            {
                ComboBoxElements.Add(str);
            }

            ElementComboBox.ItemsSource = ComboBoxElements;
            TargetComboBox.ItemsSource = ComboBoxTargets;
        }

        private void Build(object sender, RoutedEventArgs e)
        {
            Factory.Build(Elements);
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            string content = "";
            int x = 0, y = 0, width = 0, height = 0;

            if (int.TryParse(XText.Text, out x))
            {

            }
            if (int.TryParse(XText.Text, out x))
            {

            }
            if (int.TryParse(XText.Text, out x))
            {

            }
            if (int.TryParse(XText.Text, out x))
            {

            }

            Elements.Add(Factory.GetInstance(ElementComboBox.SelectedItem.ToString(), content, height, width, x, y));
        }
    }
}
