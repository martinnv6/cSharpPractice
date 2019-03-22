using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ListSearchSQLLiteEF.Models;

namespace ListSearchSQLLiteEF.Business
{
    public class LOCDESCBuisness
    {
        public List<LocDescDTO> GetLocDesc()
        {           
            List<LocDescDTO> result = new List<LocDescDTO>();
            using (var db = new mainEntities())
            {
                var listTemp1 = db.wCurbStopValve.Select(x => x).ToList();
                foreach (var wCurbStopValve in listTemp1)
                {
                    LocDescDTO logDesc = new LocDescDTO
                    {
                       TableName = "wCurbStopValve",
                        LocDesc = wCurbStopValve.LOCDESC
                    };
                    result.Add(logDesc);
                }
                var listTemp2 = db.wSystemValve.Select(x => x).ToList();
                foreach (var wSystemValve in listTemp2)
                {
                    var logDesc = new LocDescDTO
                    {
                        TableName = "wSystemValve",
                        LocDesc = wSystemValve.LOCDESC
                    };
                    result.Add(logDesc);
                }
            }

            return result;
        }

        internal List<LocDescDTO> GetLocDesc(string desc)
        {            
            List<LocDescDTO> result = new List<LocDescDTO>();
            desc = desc.ToLower();
            using (var db = new mainEntities())
            {
                var listTemp1 = db.wCurbStopValve.Where(x => x.LOCDESC.ToLower().Contains(desc)).ToList();
                foreach (var wCurbStopValve in listTemp1)
                {
                    LocDescDTO logDesc = new LocDescDTO
                    {
                        TableName = "wCurbStopValve",
                        LocDesc = wCurbStopValve.LOCDESC
                    };
                    result.Add(logDesc);
                }
                var listTemp2 = db.wSystemValve.Where(x => x.LOCDESC.ToLower().Contains(desc)).ToList();
                foreach (var wSystemValve in listTemp2)
                {
                    var logDesc = new LocDescDTO
                    {
                        TableName = "wSystemValve",
                        LocDesc = wSystemValve.LOCDESC
                    };
                    result.Add(logDesc);
                }
            }

            return result;
        }
    }
}