using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ddddd
{
    [Serializable]
    [XmlRoot("Distributor")]
    public partial class Valve
    {

        public int Index { get; set; }

        public int Ltrch { get; set; }

        public List<Time> Times;

        public bool IsOpened { get; set; }

        public Valve()
        { }
    }

    public partial class Time
    {
        public int Time_Opens;
        public int Time_Closes;
        public int Amount;

    }

}
