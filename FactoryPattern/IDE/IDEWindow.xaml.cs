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
        private List<AbstractFactory> Factories { get; set; }
        public List<AbstractElement> Elements { get; private set; }

        public ObservableCollection<string> ComboBoxElements = new ObservableCollection<string>();
        public ObservableCollection<string> ComboBoxTargets = new ObservableCollection<string>();

        private AbstractFactory currentFactory;

        public IDEWindow(List<AbstractFactory> factories)
        {
            InitializeComponent();
            Elements = new List<AbstractElement>();
            Factories = new List<AbstractFactory>();
            this.Factories.AddRange(factories);
            var canvas = new Canvas();

            foreach (AbstractFactory factory in Factories)
            {
                ComboBoxTargets.Add(factory.ToString());                
            }

            ElementComboBox.ItemsSource = ComboBoxElements;
            TargetComboBox.ItemsSource = ComboBoxTargets;

            TargetComboBox.SelectedItem = ComboBoxTargets[0];
            ElementComboBox.SelectedItem = ComboBoxElements[0];
        }

        public void AddFactory(AbstractFactory factory)
        {
            if (factory != null)
            {
                this.Factories.Add(factory);
            }
        }

        private void Build(object sender, RoutedEventArgs e)
        {
            currentFactory.Build(Elements);
        }

        private void AddElement(object sender, RoutedEventArgs e)
        {
            string content = ContentText.Text;
            int x = 0, y = 0, width = 0, height = 0;

            if (!int.TryParse(XText.Text, out x))
            {
                MessageBox.Show("Invalid X");
                return;
            }
            else if (!int.TryParse(YText.Text, out y))
            {
                MessageBox.Show("Invalid Y");
                return;
            }
            else if (!int.TryParse(WText.Text, out width))
            {
                MessageBox.Show("Invalid W");
                return;
            }
            else if (!int.TryParse(HText.Text, out height))
            {
                MessageBox.Show("Invalid H");
                return;
            }


            AbstractElement element = currentFactory.GetInstance(ElementComboBox.SelectedItem.ToString(), content, height, width, x, y);
            if (element != null)
            {
                Elements.Add(element);
                //ElementCanvas.Children.Add(new Label() { Content = element.ToString(), Width = width, Height = height, Margin = new Thickness(x, y, x, y) });
                ElementCanvas.Children.Add(new Label() { Content = element.ToString(), Margin = new Thickness(x, y, x, y) });
            }
            else
            {
                MessageBox.Show("Null element!");
            }
        }

        private void RemoveLast(object sender, RoutedEventArgs e)
        {
            if (Elements.Count > 0)
            {
                Elements.RemoveAt(Elements.Count - 1);
                ElementCanvas.Children.RemoveAt(ElementCanvas.Children.Count - 1);
            }
        }

        private void TargetChange(object sender, SelectionChangedEventArgs e)
        {
            string target = TargetComboBox.SelectedItem.ToString();

            foreach (var factory in Factories)
            {
                if (factory.ToString() == target)
                {
                    currentFactory = factory;
                    ComboBoxElements.Clear();
                    ElementCanvas.Children.Clear();
                    Elements.Clear();
                    foreach (var str in currentFactory.GetElementTypes())
                    {
                        ComboBoxElements.Add(str);
                    }
                    ElementComboBox.SelectedItem = ComboBoxElements[0];
                    break;
                }
            }
        }

        private void UpdateComboBoxes()
        {
            string target = TargetComboBox.SelectedItem.ToString();

            foreach (var factory in Factories)
            {
                if (factory.ToString() == target)
                {
                    currentFactory = factory;
                    ComboBoxElements.Clear();
                    ElementCanvas.Children.Clear();
                    foreach (var str in currentFactory.GetElementTypes())
                    {
                        ComboBoxElements.Add(str);
                    }

                    ElementComboBox.SelectedItem = ComboBoxElements[0];

                    break;
                }
            }
        }

    }
}
