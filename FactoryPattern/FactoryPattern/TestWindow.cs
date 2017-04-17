using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace FactoryPattern
{
    public partial class TestWindow : Window
    {
        private Canvas canvas = new Canvas();

        public TestWindow()
        {
            this.Background = Brushes.Black;
            this.Topmost = true;

            this.Width = 400;
            this.Height = 300;
            canvas.Width = this.Width;
            canvas.Height = this.Height;
            canvas.Background = Brushes.Black;
            this.Content = canvas;
            this.Show();
        }
    }
}
