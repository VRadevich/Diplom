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
    /// Логика взаимодействия для TimeSet.xaml
    /// </summary>
    public partial class TimeSet : Window
    {
        public TimeSet()
        {
            InitializeComponent();
            TBsCreation();
        }
        public List<TextBox> TBsOpen = new List<TextBox>();// TBs means TextBoxes
        public List<TextBox> TBsClose = new List<TextBox>();
        public List<TextBox> TBsAmount = new List<TextBox>();

        public List<Label> lOpen = new List<Label>();
        public List<Label> lClose = new List<Label>();
        public List<Label> lAmount = new List<Label>();

        public TimeSet(int qwe)
        {
            for (int i = 0; i>123; i++)
            {

            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= TBsCount; i++)
            {
                if (i == TBsCount)
                {
                    if ((TBsClose[i].Text == "") || (TBsOpen[i].Text == ""))
                    {
                        MessageBox.Show("Введите корректные  или полные данные");
                        return;
                    }
                }
                else
                {
                    if ((TBsClose[i].Text == "") || (TBsOpen[i].Text == "") || (TBsAmount[i].Text == ""))
                    {
                        MessageBox.Show("Введите корректные  или полные данные");
                        return;
                    }
                }
            }
            this.DialogResult = true;
            this.Hide();
        }

        public int PositioningY1 = 10;
        public int PositioningY2 = 35;
        public int PositioningY3 = 60;
        public int PositioningY4 = 90;
        public int TBsCount = 0;

        void TBsCreation()
        {
            TBsOpen.Add(new TextBox { MaxLength = 5, Width = 45 });
            timeSetCanvas.Children.Add(TBsOpen[TBsCount]);
            Canvas.SetTop(TBsOpen[TBsCount], PositioningY1);
            Canvas.SetLeft(TBsOpen[TBsCount], 150);
            TBsOpen[TBsCount].PreviewTextInput += PreviewText;
            TBsOpen[TBsCount].TextChanged += TextBox_TextChanged;

            lOpen.Add(new Label { Content = "Длительность открытия, сек", Width = 130 });
            timeSetCanvas.Children.Add(lOpen[TBsCount]);
            Canvas.SetTop(lOpen[TBsCount], PositioningY1);
            Canvas.SetLeft(lOpen[TBsCount], 10);
            //
            //
            //
            TBsClose.Add(new TextBox { MaxLength = 5, Width = 45 });
            timeSetCanvas.Children.Add(TBsClose[TBsCount]);
            Canvas.SetTop(TBsClose[TBsCount], PositioningY2);
            Canvas.SetLeft(TBsClose[TBsCount], 150);
            TBsClose[TBsCount].PreviewTextInput += PreviewText;
            TBsClose[TBsCount].TextChanged += TextBox_TextChanged;

            lClose.Add(new Label { Content = "Длительность закрытия, сек", Width = 130 });
            timeSetCanvas.Children.Add(lClose[TBsCount]);
            Canvas.SetTop(lClose[TBsCount], PositioningY2);
            Canvas.SetLeft(lClose[TBsCount], 10);
            //
            //
            //
            TBsAmount.Add(new TextBox { MaxLength = 3, Width = 45, Text = "0" });
            timeSetCanvas.Children.Add(TBsAmount[TBsCount]);
            Canvas.SetTop(TBsAmount[TBsCount], PositioningY3);
            Canvas.SetLeft(TBsAmount[TBsCount], 150);
            TBsAmount[TBsCount].PreviewTextInput += PreviewText;
            TBsAmount[TBsCount].TextChanged += TextBox_TextChanged;

            lAmount.Add(new Label { Content = "Количество повторений", Width = 130 });
            timeSetCanvas.Children.Add(lAmount[TBsCount]);
            Canvas.SetTop(lAmount[TBsCount], PositioningY3);
            Canvas.SetLeft(lAmount[TBsCount], 10);

            PositioningY1 += 80;
            PositioningY2 += 80;
            PositioningY3 += 80;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush red = new SolidColorBrush
            {
                Color = Color.FromRgb(164, 63, 63)
            };

            if (TBsAmount[TBsCount].Text != "")
            {
                if (TBsOpen[TBsCount].Text != "")
                {
                    if (TBsClose[TBsCount].Text != "")
                    {
                        TBsCount++;
                        timeSetCanvas.Height += 80;
                        TBsCreation();
                        PositioningY4 += 80;
                        Canvas.SetTop(Add, PositioningY4);
                    }
                    else
                    {
                        TBsClose[TBsCount].BorderBrush = red;
                    }
                }
                else
                {
                    TBsOpen[TBsCount].BorderBrush = red;
                    if (TBsClose[TBsCount].Text == "")
                    {
                        TBsClose[TBsCount].BorderBrush = red;
                    }
                }
            }
            else
            {
                TBsAmount[TBsCount].BorderBrush = red;
                if (TBsOpen[TBsCount].Text == "")
                {
                    TBsOpen[TBsCount].BorderBrush = red;
                    if (TBsClose[TBsCount].Text == "")
                    {
                        TBsClose[TBsCount].BorderBrush = red;
                    }
                }
            }

        }

        private static readonly Regex _regex = new Regex("[^0-9]+");
        private static bool TBsValidation(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void PreviewText(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TBsValidation(e.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox TB = e.Source as TextBox;
            SolidColorBrush red = new SolidColorBrush
            {
                Color = Color.FromRgb(164, 63, 63)
            };
            if (TB.Text != "")
            {
                TB.BorderBrush = null;
            }
            else
            {
                TB.BorderBrush = red;
            }
        }
    }
}
