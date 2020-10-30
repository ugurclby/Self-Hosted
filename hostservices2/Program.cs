using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hostservices2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<StartUp>("http://localhost:12345"))
            {
                Console.WriteLine("Servis Başladı..!");
                Console.WriteLine("Çıkmak İçin Tuşa Basın..!");
                Console.ReadLine();
            }
        }
    }
}
