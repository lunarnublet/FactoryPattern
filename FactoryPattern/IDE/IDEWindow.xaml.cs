﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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

        //public void AddElement(string elementName, int height, int width, int x, int y)
        //{
        //    Elements.Add(Factory.GetInstance(elementName, height, width, x, y));
        //}

        public IDEWindow(AbstractFactory factory)
        {
            InitializeComponent();
            Elements = new List<AbstractElement>();
            this.Factory = factory;
        }

        private void Build(object sender, RoutedEventArgs e)
        {
            Factory.Build(Elements);
        }
    }
}
