﻿using System;
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
using System.Xml;

namespace ddddd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();         
        }

        private void CreateConfig_Click(object sender, RoutedEventArgs e)
        {
            CreateConfig config = new CreateConfig
            {
                Owner = this
            };
            config.Show();           
        }

        private void AutoMode_Click(object sender, RoutedEventArgs e)
        {
            AutoMode auto = new AutoMode
            {
                Owner = this
            };
            auto.Show();
        }
    }
}