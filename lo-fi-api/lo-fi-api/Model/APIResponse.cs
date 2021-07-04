using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lo_fi_api.Model
{
    public class APIResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string RedirectURL { get; set; }
        public object ResultOBJ { get; set; }
        public CreditCard CreditCard { get; set; }
        public List<CreditCard> CreditCards { get; set; }
    }
}
