using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndPointManager.Controller
{
    public static class View
    {
        public static void Inicialize()
        {
            Console.WriteLine("Endpoint Manager \n");
            ShowMenu();
        }
        private static void ShowMenu()
        {
            Console.WriteLine("1 - Insert a new endpoint");
            Console.WriteLine("2 - Edit an existing endpoint");
            Console.WriteLine("3 - Delete an existing endpoint");
            Console.WriteLine("4 - List all endpoints");
            Console.WriteLine("5 - Find a endpoint by Endpoint Serial Number");
            Console.WriteLine("6 - Exit \n");

        }

        public static void HandleMenu()
        {
            EndpointController _endpointcontroller = new EndpointController();
            
            int ExitMenu = -1;
            while (ExitMenu != 0)
            {
                ShowMenu();

                string optionselected = Console.ReadLine();
                switch (optionselected)
                {
                    case "1": InputController.Create(_endpointcontroller); break;
                    case "2": InputController.Edit(_endpointcontroller); break;
                    case "3": InputController.Delete(_endpointcontroller); break;
                    case "4": InputController.ListAll(_endpointcontroller); break;
                    case "5": InputController.Find(_endpointcontroller); break;
                    case "6": ExitMenu = InputController.Exit() == true ? 0 : -1; break;
                    default:  Console.WriteLine("7");
                        break;
                }
            }
        }
    }
}
