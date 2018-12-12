using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsLogger
{
    class GenerateTicketNumber
    {
        //string referenceNum;
        //public string GetUniqueKey()
        //{
        //    using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from Tickets", conn);
        //        object count = cmd.ExecuteScalar();
        //        referenceNum = (1000 + (Convert.ToInt32(count) + 1)).ToString();
        //    }
        //    return referenceNum;
        //}
        string TicketsNumber;
        public string getTicketNumber()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from Tickets", conn);
                    object count = cmd.ExecuteScalar();
                    string dateStr = DateTime.Now.ToString("ddMMyy");
                    TicketsNumber = dateStr + (Convert.ToInt32(count) + 1).ToString("D4");
                    int count2 = 0;
                    do
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) from Tickets where TicketNumber='" + TicketsNumber + "'", conn);
                        count2 = (int)cmd2.ExecuteScalar();
                        if (count2 > 0)
                        {
                            TicketsNumber = (Convert.ToInt32(TicketsNumber) + 1).ToString();
                        }
                    }
                    while (count2 > 0);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new LogWriter(ex);
            }
            return TicketsNumber;

        }
    }
}
