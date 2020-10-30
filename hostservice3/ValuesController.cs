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
        public String GetString(Int32 id)
        {
            return "Win Service";
        }
    }
}
