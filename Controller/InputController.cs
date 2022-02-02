using EndPointManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndPointManager.Controller
{
    public static class InputController
    {
        public static void Create(EndpointController _endpointController)
        {
            Console.WriteLine("Serial Number: ");
            string EndpointSerialNumber = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Meter Model Id: NSX1P2W = 16, NSX1P3W = 17, NSX2P3W = 18, NSX3P4W = 19");
            int MeterModelId = 0;
            int.TryParse(Console.ReadLine(), out MeterModelId);


            int MeterNumber = 0;
            Console.WriteLine();
            Console.WriteLine("Meter Number: ");
            int.TryParse(Console.ReadLine(), out MeterNumber);


            Console.WriteLine();
            Console.WriteLine("Meter Firmware Version: ");
            string MeterFirmwareVersion = Console.ReadLine();

            int EndpointSwitchState = -1;
            Console.WriteLine();
            Console.WriteLine("Meter Switch State: 0 = Disconnected, 1 = Connected, 2 = Armed");
            int.TryParse(Console.ReadLine(), out EndpointSwitchState);

            Meter _meter = new Meter(MeterModelId, MeterNumber, MeterFirmwareVersion, EndpointSwitchState);
            Endpoint _endpoint = new Endpoint(EndpointSerialNumber, _meter);
            if (_meter.IsValid())
            {
                if(_endpointController.Create(_endpoint))
                { 
                     Console.WriteLine();
                     Console.WriteLine("registered sucessfully \n");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Serial Number already exists \n");
                }
            }
            else
            {
                _meter.MessageInvalid();
            }
            
        }
        public static void Edit(EndpointController _endpointController)
        {
            Console.WriteLine();
            Console.WriteLine("Endpoint Serial Number: ");

            string EndpointSerialNumber = Console.ReadLine();

            int EndpointSwitchState = -1;
            Console.WriteLine();
            Console.WriteLine("Meter Switch State: ");
            int.TryParse(Console.ReadLine(), out EndpointSwitchState);
            if (EndpointSwitchState < 0 || EndpointSwitchState > 3)
                throw new ApplicationException("inválid meter switch state.");

            if(_endpointController.Edit(EndpointSerialNumber, EndpointSwitchState))
                Console.WriteLine("Endpoint edited sucessfully.");
        }
        public static void Delete(EndpointController _endpointController)
        {
            Console.WriteLine();
            Console.WriteLine("Endpoint Serial Number: ");

            string EndpointSerialNumber = Console.ReadLine();

            Endpoint endpoint = _endpointController.Find(EndpointSerialNumber);

            Console.WriteLine();
            Console.WriteLine(@$"confirms the removal of the Endpoint Serial Number: {endpoint.SerialNumber} y for yes / n for not: ");
            string ConfirmRemove = Console.ReadLine();
            if (_endpointController.Delete(endpoint, ConfirmRemove))
                Console.WriteLine("endpoint removed");
        }
        public static void ListAll(EndpointController _endpointController)
        {
            foreach (var item in _endpointController.ListAll())
            {
                Console.WriteLine(item.ToString());
            }
        }
        public static void Find(EndpointController _endpointController)
        {
            Console.WriteLine();
            Console.WriteLine("Endpoint Serial Number: ");

            string EndpointSerialNumber = Console.ReadLine();

            Endpoint endpoint = _endpointController.Find(EndpointSerialNumber);
            Console.WriteLine(endpoint.ToString());
        }
        public static bool Exit()
        {
            Console.WriteLine();
            Console.WriteLine("Confirms to close: y for yes / n for not: ");

            string ConfirmExit = Console.ReadLine();

            if (ConfirmExit.Equals("y"))
            {
                return true;
            }
            return false;
        }
    }
}
