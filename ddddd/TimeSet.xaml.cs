using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ddddd
{
    /// <summary>
    /// Логика взаимодействия для TimeSet.xaml
    /// </summary>
    public partial class TimeSet : Window
    {
        public TimeSet()
        {
            InitializeComponent();

        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
