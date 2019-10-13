using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;

namespace TicketsLogger
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
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
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.ExitThread();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new LogWriter(ex);
            }

        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            string hashPass = txtPassword.Text;
            try
            {
                if (!string.IsNullOrWhiteSpace((txtEmail.Text)))
                {
                    using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
                    {
                        DataTable table = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(@"select * from Staff where email = '" + txtEmail.Text + "' and password = '" + hashPass + "'", conn);
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            Global.Staff = new Staff
                            {
                                Name = table.Rows[0]["name"].ToString(),
                                Surname = table.Rows[0]["surname"].ToString(),
                                Email = table.Rows[0]["email"].ToString(),
                                Gender = table.Rows[0]["gender"].ToString(),
                                Password = table.Rows[0]["password"].ToString(),
                                Role = table.Rows[0]["role"].ToString(),
                                ID = table.Rows[0]["id"].ToString(),
                                Department = table.Rows[0]["department"].ToString()
                            };
                            TicketForm frmMain = new TicketForm();
                            this.Hide();
                            frmMain.Show();
                            new loginLogs(Global.Staff.Name, Global.Staff.ID, Global.Staff.Email, Global.Staff.Department);
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
            }

        }
    }
}
