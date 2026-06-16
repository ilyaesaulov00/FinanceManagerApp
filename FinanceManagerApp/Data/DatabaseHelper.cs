using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagerApp.Data
{
    public static class DatabaseHelper
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["FinanceDb"].ConnectionString;

        public static SqlConnection GetConnection() => new SqlConnection(ConnectionString);
    }
}
