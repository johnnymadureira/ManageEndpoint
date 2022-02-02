using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EndPointManager.Enums.Enumerators;

namespace EndPointManager.Model
{
    public class Meter : MeterBase
    {
        private int _modelId { get; set; }

        public Meter(int modelid, int number, string firmware, int switchstate) : base(number,  firmware, switchstate)
        {
            _modelId = modelid;
        }
        public override string ToString()
        {
            MeterModel metermodeldescription = (MeterModel)Enum.Parse(typeof(MeterModel), _modelId.ToString(), true);
            return ", Meter Model Id: " + metermodeldescription + base.ToString();
        }
        public bool IsValid()
        {
            if (_modelId == 0)
                return false;
           
            if (_modelId < 16 || _modelId > 19)
                return false;

            if (_switchstate == -1)
                return false;

            if (_switchstate < 0 || _switchstate > 3)
                return false;


            return true;
        }
        public void MessageInvalid()
        {
            if (_modelId == 0)
                throw new InvalidCastException("Meter model is just numeric: NSX1P2W = 16, NSX1P3W = 17, NSX2P3W = 18, NSX3P4W = 19");

            if (_modelId < 16 || _modelId > 19)
                throw new Exception("inválid meter model id.");

            if (_switchstate == -1)
                throw new InvalidCastException("switch state is just numeric: 0 = Disconnected, 1 = Connected, 2 = Armed");

            if (_switchstate < 0 || _switchstate > 3)
                throw new ApplicationException("inválid meter switch state.");
        }
    }
}
