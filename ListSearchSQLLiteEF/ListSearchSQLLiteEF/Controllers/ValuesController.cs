using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ListSearchSQLLiteEF.Business;
using ListSearchSQLLiteEF.Models;

namespace ListSearchSQLLiteEF.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<LocDescDTO> Get()
        {
            var result = new LOCDESCBuisness();            
            return result.GetLocDesc();
        }

        // GET api/values/5
        public List<LocDescDTO> Get(string desc)
        {
            var result = new LOCDESCBuisness();
            return result.GetLocDesc(desc);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
