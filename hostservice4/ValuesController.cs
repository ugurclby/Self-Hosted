using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace hostservice3
{
    public class ValuesController:ApiController
    {
        [HttpGet]
        [Route("api/GetString")]
        public String GetString(Int32 id)
        {
            return "This is string returned through the Windows service.";
        }
    }
}
