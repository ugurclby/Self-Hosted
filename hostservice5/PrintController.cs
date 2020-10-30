using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace hostservice5
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PrintController:ApiController
    {
        //[EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
        [HttpGet]
        public string GetPrinters()
        { 
            List<string> printList = new List<string>();
            
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printList.Add(printer);
            }
            var json = JsonConvert.SerializeObject(printList);

            return json;
        }
        
        //[EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
        [HttpPost]
        public void SetPrint(string PRINTER_NAME)
        {
            var doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = PRINTER_NAME;
            doc.PrintPage += new PrintPageEventHandler(ProvideContent); 
            doc.Print(); 
        }

        private void ProvideContent(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(
            "Hello world",
            new Font("Arial", 12),
            Brushes.Black,
            e.MarginBounds.Left,
            e.MarginBounds.Top);
        }
    }
}
