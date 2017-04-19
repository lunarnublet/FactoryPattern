using System;using System.Collections.Generic;
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
namespace WpfApp {
public partial class MainWindow : Window {
public MainWindow() {
InitializeComponent();
Root.Children.Add(new Button(){Content = "foobar",Width = 100,Height = 100,Margin = new System.Windows.Thickness(200, 0, 200, 0)});
Root.Children.Add(new Label(){Content = "foobar",Width = 100,Height = 100,Margin = new System.Windows.Thickness(200, 200, 200, 200)});
}}}