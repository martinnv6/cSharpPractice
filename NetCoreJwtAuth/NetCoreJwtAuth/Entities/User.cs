using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreJwtAuth.Entities
{
    public class User
    {
        public string Id { get; set; }

     
        public string Key { get; set; }

     
        public decimal NameAdmin { get; set; }

       
        public string System { get; set; }

       
        public string Controller { get; set; }
    }
}
