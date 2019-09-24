using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsLogger
{
    class DatabaseConnection
    {
        public static string connectionStr = @"Data Source=IT2-CEDRIC;Initial Catalog = TicketLogger; Integrated Security = True";
        public static SqlConnection connection = new SqlConnection(connectionStr);
        public string checkDatabase()
        {
            string answer = null;
            using (var conn = new SqlConnection(DatabaseConnection.connectionStr))
            {
                try
                {
                    conn.Open();
                    answer = "True";
                }
                catch (SqlException sql)
                {
                    answer = "False" + sql.Message;
                }
            }
            return answer;
        }
    }
}
