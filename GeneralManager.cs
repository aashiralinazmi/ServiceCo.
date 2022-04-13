using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ServiceCo.Manager
{
    public class GeneralManager
    {
        protected static ServiceCoEntities ServDB = new ServiceCoEntities();
        //public static string ConString = @"Data Source=AASHIR-ONLINE\SQLEXPRESS;Initial Catalog=ServiceCo;Integrated Security=True";
        //public static SqlConnection Con = new SqlConnection(ConString);
    }
}