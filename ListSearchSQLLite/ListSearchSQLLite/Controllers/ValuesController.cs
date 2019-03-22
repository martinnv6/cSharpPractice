using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ListSearchSQLLite.Business;
using ListSearchSQLLite.Models;

namespace ListSearchSQLLite.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<SystemValveDesc> Get()
        {
            ValuesBusiness vb = new ValuesBusiness();
            return vb.GetLogDescSystemValve();            
        }

        // GET api/values/5
        public List<SystemValveDesc> Get(string desc)
        {
            ValuesBusiness vb = new ValuesBusiness();
            return vb.GetLogDescSystemValve(desc);
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
