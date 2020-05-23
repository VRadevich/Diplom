using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для StepSetup.xaml
    /// </summary>
    public partial class StepSetup : Window
    {
        public StepSetup()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (StepTB.Text != "")
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Введите корректные  или полные данные");
            }
        }

        private static readonly Regex _regex = new Regex("[^1-9]+");
        private static bool TBsValidation(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void StepTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TBsValidation(e.Text);
        }
    }
}

