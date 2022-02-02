using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndPointManager.Model
{
    public class Endpoint
    {
        public string SerialNumber { get; set; }
        public Meter _meter { get; set; }

        public Endpoint(string serialnumber, Meter meter)
        {
            SerialNumber = serialnumber;
            _meter = meter;
        }

        public override string ToString()
        {
            return "Endpoint SerialNumber: " + SerialNumber + _meter.ToString();
        }

    }
}
