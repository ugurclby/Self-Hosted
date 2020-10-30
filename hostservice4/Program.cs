using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.SelfHost;
using System.Windows.Forms;

namespace hostservice4
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
  
            var cors = new EnableCorsAttribute("*", "*", "*");
            var config = new HttpSelfHostConfiguration("http://localhost:12344/api");
            config.EnableCors(cors);
            config.Routes.MapHttpRoute(
            name: "API",
            routeTemplate: "{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new Form1());
            }
        }
    }
    //static class Program
    //{
    //    /// <summary>
    //    /// The main entry point for the application.
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {

    //        //var config = new HttpSelfHostConfiguration("http://localhost:8081");

    //        //config.Routes.MapHttpRoute(
    //        //    "API Default", "api/{controller}/{id}",
    //        //    new { id = RouteParameter.Optional });

    //        //using (HttpSelfHostServer server = new HttpSelfHostServer(config))
    //        //{
    //        //    server.OpenAsync().Wait(); 
    //        //}

    //        string baseAddress = "http://localhost:8081";
    //        HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(baseAddress);

    //        config.MapHttpAttributeRoutes();
    //        config.Routes.MapHttpRoute(
    //            name: "DefaultApi",
    //            routeTemplate: "api/{controller}/{id}",
    //            defaults: new { id = RouteParameter.Optional }
    //        );

    //        //config.EnableCors(new EnableCorsAttribute("", headers: "", methods: "*"));

    //        //config.EnableCors();

    //        HttpSelfHostServer server = new HttpSelfHostServer(config);
    //        server.OpenAsync().Wait();

    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);
    //        Application.Run(new Form1());


    //    }
    //}
}
 