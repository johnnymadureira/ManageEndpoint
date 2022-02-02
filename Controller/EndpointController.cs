using EndPointManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndPointManager.Controller
{
    public class EndpointController
    {
        public List<Endpoint> endpoints { get; set; }

        public EndpointController()
        {
            endpoints = new List<Endpoint>();

        }
        public bool Create(Endpoint _endpoint)
        {

            bool endpointexists = FindOrNull(_endpoint.SerialNumber) == null ? false : true;

            if(!endpointexists)
                endpoints.Add(_endpoint);

            return !endpointexists;

        }
        public bool Edit(string EndpointSerialNumber, int EndpointSwitchState)
        {

            Endpoint endpoint = Find(EndpointSerialNumber);

            endpoint._meter.SetSwitchState(EndpointSwitchState);

            if(endpoint == null)
            {
                return false;
            }
            return true;
        }
        public bool Delete(Endpoint endpoint, string ConfirmRemove)
        {
 
            if(ConfirmRemove.Equals("y"))
            {
                endpoints.Remove(endpoint);
                
                return true;
            }
            return false;

        }

        public List<Endpoint> ListAll()
        {
            return endpoints;
        }
        public Endpoint Find(string serialNumber)
        {
            Endpoint endpoint = endpoints.FirstOrDefault(t => t.SerialNumber == serialNumber);

            if (endpoint == null)
                throw new ApplicationException("Endpoint not found.");

            return endpoint;
        }
        public Endpoint FindOrNull(string serialNumber)
        {
            Endpoint endpoint = endpoints.FirstOrDefault(t => t.SerialNumber == serialNumber);

            return endpoint;
        }
    }
}
