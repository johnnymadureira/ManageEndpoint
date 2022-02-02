using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EndPointManager.Enums.Enumerators;

namespace EndPointManager.Model
{
    public class MeterBase
    {
        private int _number { get; set; }
        private string _firmwareVersion { get; set; }
        protected int _switchstate{ get; set; }
        public MeterBase(int number, string firmware, int switchstate)
        {
            _number = number;
            _firmwareVersion = firmware;
            _switchstate = switchstate;
        }

        public void SetSwitchState(int switchstate)
        {
            _switchstate = switchstate;
        }
        public override string ToString()
        {
            SwitchState switchstatedescription = (SwitchState)Enum.Parse(typeof(SwitchState), _switchstate.ToString(), true);
            return ", Meter number: " + _number + ", Fimware version: " + _firmwareVersion + ", Switch State: " + switchstatedescription;
        }
    }
}
