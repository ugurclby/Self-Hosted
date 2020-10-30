using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.SelfHost;
using System.Windows.Forms;

namespace hostservice5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var cors = new EnableCorsAttribute("http://integsmart.com", "*", "GET,POST"); 
            var config = new HttpSelfHostConfiguration("http://localhost:9999");
            config.EnableCors(cors);
            config.Routes.MapHttpRoute(
            name: "API",
            routeTemplate: "{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                var formatter = server.Configuration.Formatters;
                formatter.Remove(formatter.XmlFormatter);
                server.OpenAsync().Wait();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new Form1());
            }
        }
    }
}
