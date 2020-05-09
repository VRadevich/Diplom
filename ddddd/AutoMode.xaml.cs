using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Threading;

namespace ddddd
{
    /// <summary>
    /// Логика взаимодействия для AutoMode.xaml
    /// </summary>
    public partial class AutoMode : Window
    {
        public AutoMode()
        {
            InitializeComponent();
            DeclareValves();
            ImplementValves();
            //ValvesToolTip();
            Count_Setup();
            InitializeTimer();
        }

        List<Valve> valves = new List<Valve>();
        readonly Ellipse[] v = new Ellipse[126];
        readonly int[] count = new int[126];
        readonly DispatcherTimer timer = new DispatcherTimer();

        public void Count_Setup()
        {
            for (int i = 0; i <= 125; i++)
            {
                count[i] = 0;       
            }      
        }
        void InitializeTimer()
        {
             timer.Interval = TimeSpan.FromSeconds(1);
             timer.Tick += Timer_Tick;
        }

        void Timer_Tick(object sender, EventArgs e)
        {           
            if (int.Parse(SecondsTB.Text) > 0)
              {
                  SecondsTB.Text = $"{int.Parse(SecondsTB.Text) - 1}";
              } 
            else
            {
                if (int.Parse(MinutesTB.Text) > 0)
                {
                      SecondsTB.Text = $"{59}";
                      MinutesTB.Text = $"{int.Parse(MinutesTB.Text) - 1}";
                }
                else
                {
                    if (int.Parse(HoursTB.Text) > 0)
                    {
                          SecondsTB.Text = $"{59}";
                          MinutesTB.Text = $"{59}";
                         HoursTB.Text = $"{int.Parse(HoursTB.Text) - 1}";
                    }
                    else
                    {
                        timer.Stop();
                        for (int i = 0; i <= 125; i++)
                        {
                            ValveClosing(i);
                        }
                            Enable();
                        return;
                    }
                }
            }
            /*for (int i = 0; i <= 125; i++)
            {
                count[i]++;
                if (valves[i].IsOpened == false)
                {
                    if (count[i] == valves[i].Time_close)
                    {
                        ValveOpening(i);
                        count[i] = 0;
                    }
                }
                else
                {
                    if (count[i] == valves[i].Time_open)
                    {
                        ValveClosing(i);
                        count[i] = 0;
                    }
                }
            }*/
        }
      
        public void DeclareValves()
        {
            for (int i = 1; i <= 8; i++)
            {
                for(int j = 1; j <= 16; j++)
                {
                    valves.Add(new Valve() { Index = i, Ltrch = j });
                }
            }
        }

        /*public void ValvesToolTip()
        {
            for (int i = 0; i <= 125; i++)
            {
                v[i].ToolTip = $"Время открытия:{valves[i].Time_open}\n" +
                    $"Время закрытия:{valves[i].Time_close}\n" +
                    $"LTR модуль:{valves[i].Index}_{valves[i].Ltrch}";
            }
        }*/

        private void ImplementValves()
        {
            v[0] = v_0;
            v[1] = v_1;
            v[2] = v_2;
            v[3] = v_3;
            v[4] = v_4;
            v[5] = v_5;
            v[6] = v_6;
            v[7] = v_7;
            v[8] = v_8;
            v[9] = v_9;
            v[10] = v_10;
            v[11] = v_11;
            v[12] = v_12;
            v[13] = v_13;
            v[14] = v_14;
            v[15] = v_15;
            v[16] = v_16;
            v[17] = v_17;
            v[18] = v_18;
            v[19] = v_19;
            v[20] = v_20;
            v[21] = v_21;
            v[22] = v_22;
            v[23] = v_23;
            v[24] = v_24;
            v[25] = v_25;
            v[26] = v_26;
            v[27] = v_27;
            v[28] = v_28;
            v[29] = v_29;
            v[30] = v_30;
            v[31] = v_31;
            v[32] = v_32;
            v[33] = v_33;
            v[34] = v_34;
            v[35] = v_35;
            v[36] = v_36;
            v[37] = v_37;
            v[38] = v_38;
            v[39] = v_39;
            v[40] = v_40;
            v[41] = v_41;
            v[42] = v_42;
            v[43] = v_43;
            v[44] = v_44;
            v[45] = v_45;
            v[46] = v_46;
            v[47] = v_47;
            v[48] = v_48;
            v[49] = v_49;
            v[50] = v_50;
            v[51] = v_51;
            v[52] = v_52;
            v[53] = v_53;
            v[54] = v_54;
            v[55] = v_55;
            v[56] = v_56;
            v[57] = v_57;
            v[58] = v_58;
            v[59] = v_59;
            v[60] = v_60;
            v[61] = v_61;
            v[62] = v_62;
            v[63] = v_63;
            v[64] = v_64;
            v[65] = v_65;
            v[66] = v_66;
            v[67] = v_67;
            v[68] = v_68;
            v[69] = v_69;
            v[70] = v_70;
            v[71] = v_71;
            v[72] = v_72;
            v[73] = v_73;
            v[74] = v_74;
            v[75] = v_75;
            v[76] = v_76;
            v[77] = v_77;
            v[78] = v_78;
            v[79] = v_79;
            v[80] = v_80;
            v[81] = v_81;
            v[82] = v_82;
            v[83] = v_83;
            v[84] = v_84;
            v[85] = v_85;
            v[86] = v_86;
            v[87] = v_87;
            v[88] = v_88;
            v[89] = v_89;
            v[90] = v_90;
            v[91] = v_91;
            v[92] = v_92;
            v[93] = v_93;
            v[94] = v_94;
            v[95] = v_95;
            v[96] = v_96;
            v[97] = v_97;
            v[98] = v_98;
            v[99] = v_99;
            v[100] = v_100;
            v[101] = v_101;
            v[102] = v_102;
            v[103] = v_103;
            v[104] = v_104;
            v[105] = v_105;
            v[106] = v_106;
            v[107] = v_107;
            v[108] = v_108;
            v[109] = v_109;
            v[110] = v_110;
            v[111] = v_111;
            v[112] = v_112;
            v[113] = v_113;
            v[114] = v_114;
            v[115] = v_115;
            v[116] = v_116;
            v[117] = v_117;
            v[118] = v_118;
            v[119] = v_119;
            v[120] = v_120;
            v[121] = v_121;
            v[122] = v_122;
            v[123] = v_123;
            v[124] = v_124;
            v[125] = v_125;

        }

        void Disable()
        {
            LoadConfiguration.IsEnabled = false;
            HoursTB.IsEnabled = false;
            MinutesTB.IsEnabled = false;
            SecondsTB.IsEnabled = false;
            CloseAll.IsEnabled = false;
        }

        void Enable()
        {
            LoadConfiguration.IsEnabled = true;
            HoursTB.IsEnabled = true;
            MinutesTB.IsEnabled = true;
            SecondsTB.IsEnabled = true;
            CloseAll.IsEnabled = true;
        }

        private void LoadConfiguration_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Valve>));
            OpenFileDialog fs = new OpenFileDialog
            {
                InitialDirectory = "c:\\Users\\морозов",
                Filter = "XML Files (*.xml)|*.xml",
                DefaultExt = "xml",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            Nullable<bool> result = fs.ShowDialog();
            if (result == true)
            {
                FileStream FS = new FileStream(fs.FileName, FileMode.OpenOrCreate);
                valves = (List<Valve>)formatter.Deserialize(FS);
            }
            //ValvesToolTip();
        }

        private void Valve_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            int Vnum = 0;
            for (int i = 0; i <= 125; i++)
            {
                if ((e.GetPosition(canv).X >= Canvas.GetLeft(v[i])) && (e.GetPosition(canv).X <= Canvas.GetLeft(v[i]) + 20))
                {
                    if ((e.GetPosition(canv).Y >= Canvas.GetTop(v[i])) && (e.GetPosition(canv).Y <= Canvas.GetTop(v[i]) + 20))
                    {
                        Vnum = i;
                        break;
                    }
                }
            }
            TimeSet timeSet = new TimeSet
            {
                Owner = this,
                Title = $"Клапан #{ Vnum + 1 }"
            };
            Nullable<bool> result = timeSet.ShowDialog();
            if (result == true)
            {
                //valves[Vnum].Time_open[1] = Int32.Parse(timeSet.opentimeTextBox.Text);
                //valves[Vnum].Time_close[1] = Int32.Parse(timeSet.closetimeTextBox.Text);

            }
            timeSet.Close();
            //l1.Content = valves[Vnum].Time_open;
            //v[Vnum].ToolTip = $"Время открытия:{valves[Vnum].Time_open}\n" +
            //    $"Время закрытия:{valves[Vnum].Time_close}\n" +
            //    $"LTR модуль:{valves[Vnum].Index}_{valves[Vnum].Ltrch}";
        }

        void ValveOpening(int i)
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(58, 180, 58)
            };
            v[i].Fill = mySolidColorBrush;
            valves[i].IsOpened = true;
        }

        void ValveClosing(int i)
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(164, 63, 63)
            };
            v[i].Fill = mySolidColorBrush;
            valves[i].IsOpened = false;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            Disable();
        }

        private void CloseAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 125; i++)
            {
                ValveClosing(i);
            }
            
        }

        private void OpenAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <= 125; i++)
            {
                ValveOpening(i);
            }
        }

        private void winAutoMode_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}