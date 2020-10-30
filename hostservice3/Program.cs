using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace hostservice3
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;

            SelfHostService _selfHostService = new SelfHostService();

            _selfHostService.ServiceName = "WebAPI_Hosted";

            ServicesToRun = new ServiceBase[]
            {
                _selfHostService
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
