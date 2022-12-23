using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TreinamentoLuisAPI.Models
{
    public class AppSettings
    {
        public string ConnectionMsSql { get; set; }
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string IntegratedSecurity { get; set; }

        public SqlConnection GetConnection()
        {

            string strConnection = "Server=localhost;Database=LUISFF_TREINAMENTOLUISDB;Trusted_Connection=True;";
            var conSql = new SqlConnection(strConnection);
            conSql.Open();

            return conSql;
            //get
            //{
            //    return new SqlConnection(string.Format(this.ConnectionMsSql,
            //                                           this.DataSource,
            //                                           this.InitialCatalog,
            //                                           this.IntegratedSecurity));
            //}
        }


    }

}
