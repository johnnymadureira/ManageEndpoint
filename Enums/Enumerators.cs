using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndPointManager.Enums
{
    public class Enumerators
    {
        public enum MeterModel
        {
            [Description("NSX1P2W")]
            NSX1P2W = 16,
            [Description("NSX1P3W")]
            NSX1P3W = 17,
            [Description("NSX2P3W")]
            NSX2P3W = 18,
            [Description("NSX3P4W")]
            NSX3P4W = 19
        }
        public enum SwitchState
        {
            [Description("Disconnected")]
            Disconnected = 0,
            [Description("Connected")]
            Connected = 1,
            [Description("Armed")]
            Armed = 2
        }
    }
}
