using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
                                    Surname = table.Rows[0]["surname"].ToString(),
                                    ID= table.Rows[0]["staffID"].ToString(),
                                    Department= table.Rows[0]["Department"].ToString(),
                                    Unit= table.Rows[0]["Unit"].ToString()
                                };
                                TicketForm ticketFrm = new TicketForm();
                                ticketFrm.Show();
                                new loginLogs(Global.Staff.Surname + " " + Global.Staff.Name,
                                    Global.Staff.ID, Global.Staff.Email, Global.Staff.Unit);
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
                                    Surname = table.Rows[0]["surname"].ToString(),
                                    ID = table.Rows[0]["staffID"].ToString(),
                                    Department = table.Rows[0]["Department"].ToString(),
                                    Unit = table.Rows[0]["Unit"].ToString()
                                };
                                TicketForm ticketFrm = new TicketForm();
                                ticketFrm.Show();
                                new loginLogs(Global.Staff.Surname + " " + Global.Staff.Name,
                                    Global.Staff.ID, Global.Staff.Email, Global.Staff.Department);
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

class RoundedButton : Button
{
    GraphicsPath GetRoundPath(RectangleF Rect, int radius)
    {
        float r2 = radius / 2f;
        GraphicsPath GraphPath = new GraphicsPath();

        GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
        GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
        GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
        GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
        GraphPath.AddArc(Rect.X + Rect.Width - radius,
                         Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
        GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
        GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
        GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);

        GraphPath.CloseFigure();
        return GraphPath;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
        GraphicsPath GraphPath = GetRoundPath(Rect, 50);

        this.Region = new Region(GraphPath);
        using (Pen pen = new Pen(Color.CadetBlue, 1.75f))
        {
            pen.Alignment = PenAlignment.Inset;
            e.Graphics.DrawPath(pen, GraphPath);
        }
    }
}
