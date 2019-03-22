using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Devart.Data.SQLite;
using ListSearchSQLLite.Models;

namespace ListSearchSQLLite.Business
{
    public class ValuesBusiness
    {
        public List<SystemValveDesc> GetLogDescSystemValve()
        {
            var ImportedFiles = new List<SystemValveDesc>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\repo\cSharpPractice\ListSearchSQLLite\waterdistributionnetwork.geodatabase"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT 'wSystemValve'  as TABLENAME
                                                ,[LOCDESC]      
                                        FROM [wSystemValve] where LOCDESC
                                                union
                                        SELECT 'wCurbStopValve'   as TABLENAME    
                                                ,[LOCDESC]      
                                        FROM [wCurbStopValve] where LOCDESC;";
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        var item = new SystemValveDesc();
                        string value = "";
                        if (r["LOCDESC"] != DBNull.Value)
                        {
                            item.TableName = (string)r["TABLENAME"];
                            item.LocDesc = (string)r["LOCDESC"];
                        }


                        ImportedFiles.Add(item);
                    }

                    connect.Close();
                }
            }

            return ImportedFiles;
        }

        public List<SystemValveDesc> GetLogDescSystemValve(string desc)
        {
            List<SystemValveDesc> ImportedFiles = new List<SystemValveDesc>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\repo\cSharpPractice\ListSearchSQLLite\waterdistributionnetwork.geodatabase"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT 'wSystemValve'  as TABLENAME
                                                ,[LOCDESC]      
                                        FROM [wSystemValve] where LOCDESC like  @pDesc
                                                union
                                        SELECT 'wCurbStopValve'   as TABLENAME    
                                                ,[LOCDESC]      
                                        FROM [wCurbStopValve] where LOCDESC like @pDesc;";
                    fmd.Parameters.Add("@pDesc", DbType.String);
                    fmd.Parameters["@pDesc"].Value = '%' + desc + '%';
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        var item = new SystemValveDesc();
                        string value = "";
                        if (r["LOCDESC"] != DBNull.Value)
                        {
                            item.TableName = (string)r["TABLENAME"];
                            item.LocDesc = (string)r["LOCDESC"];
                        }


                        ImportedFiles.Add(item);
                    }

                    connect.Close();
                }
            }

            return ImportedFiles;
        }
    }
}