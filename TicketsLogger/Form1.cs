using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsLogger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string connected;
                DatabaseConnection check = new DatabaseConnection();
                connected = check.checkDatabase();
                if (connected == "True")
                {
                    using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
                    {
                        SqlCommand cmd = new SqlCommand("Select Email FROM Staff", conn);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                        while (reader.Read())
                        {
                            MyCollection.Add(reader.GetString(0));
                        }
                        txtEmail.AutoCompleteCustomSource = MyCollection;
                        conn.Close();
                    }
                }
                else
                {
                    throw new Exception("Connection to the database was not established.\r\n" +
                                   "Please make sure that your database is on and that you are connected to the internet!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new LogWriter(ex);
                this.Close();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace((txtEmail.Text)))
                {
                    using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
                    {
                        DataTable table = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(@"select * from Staff where email = '" + txtEmail.Text + "' and password = '" + textBox2.Text + "'", conn);
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            if (table.Rows[0]["role"].ToString().Equals("admin", StringComparison.CurrentCultureIgnoreCase))
                            {
                                Global.Staff = new Staff
                                {
                                    Name = table.Rows[0]["name"].ToString(),
                                    Email = table.Rows[0]["email"].ToString(),
                                    Gender = table.Rows[0]["gender"].ToString(),
                                    Password = table.Rows[0]["password"].ToString(),
                                    Role = table.Rows[0]["role"].ToString(),
                                    Surname = table.Rows[0]["surname"].ToString()
                                };
                                TicketForm ticketFrm= new TicketForm();
                                ticketFrm.Show();

                                this.Hide();
                            }
                            else if (table.Rows[0]["role"].ToString().Equals("user", StringComparison.CurrentCultureIgnoreCase))
                            {
                                Global.Staff = new Staff
                                {
                                    Name = table.Rows[0]["name"].ToString(),
                                    Email = table.Rows[0]["email"].ToString(),
                                    Gender = table.Rows[0]["gender"].ToString(),
                                    Password = table.Rows[0]["password"].ToString(),
                                    Role = table.Rows[0]["role"].ToString(),
                                    Surname = table.Rows[0]["surname"].ToString()
                                };
                                TicketForm ticketFrm = new TicketForm();
                                ticketFrm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("You are not an admin");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please provide the correct username and passowrd");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please provide a username and password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new LogWriter(ex);
                this.Close();
            }
        }
    }
}
