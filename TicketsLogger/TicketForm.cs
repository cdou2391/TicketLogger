using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TicketsLogger
{
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 logForm = new Form1();
            logForm.Show();
        }

        private void TicketForm_Load(object sender, EventArgs e)
        {
            staffNames.Text = Global.Staff.Name + " " + Global.Staff.Surname;
            LoadStaffUser();
            LoadCalls();
            this.Text =ProductName.ToString()+ " " + ProductVersion.ToString();
        }

        private void RecBtnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("You are about to exit and log out of the application. Are you sure?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
               
            }
        }

        private void LocateBtnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("You are about to exit and log out of the application. Are you sure?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                
            }
        }

        private void closeBtnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("You are about to exit and log out of the application. Are you sure?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
               
            }
        }
        private void LoadStaffUser()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Staff", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ComboboxItem staffEmail = new ComboboxItem();
                        ComboboxItem staffNumber = new ComboboxItem();
                        staffEmail.Text = reader["email"].ToString();
                        staffNumber.Text = reader["StaffID"].ToString();
                        recComboAssignedTo.Items.Add(staffEmail);
                        recComboUnikNo.Items.Add(staffNumber);
                    }
                    reader.Close();
                }
            }
        }

        private void LoadCalls()
        {
            locComboUnikNo.Items.Clear();
            closeComboUnikNo.Items.Clear();
            using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tickets", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ComboboxItem refNo = new ComboboxItem();
                        refNo.Text = reader["TicketNumber"].ToString();
                        locComboUnikNo.Items.Add(refNo);
                        closeComboUnikNo.Items.Add(refNo);
                    }
                    reader.Close();
                }
            }
        }
        private void recBtnSearch_Click(object sender, EventArgs e)
        {
            string refNum = recComboUnikNo.Text;
            int i;
            try
            {
                if ((refNum.ToString().Length > 2))
                {
                    if (int.TryParse(refNum, out i))
                    {
                        int id = Convert.ToInt32(refNum);
                        using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
                        {
                            conn.Open();
                            try
                            {
                                using (SqlCommand cmd = new SqlCommand("SELECT * from Staff where StaffID = '" + id + "'", conn))
                                {
                                    SqlDataReader reader = cmd.ExecuteReader();
                                    reader.Read();
                                    recTxtName.Text = reader["Name"].ToString();
                                    recTxtSurname.Text = reader["Surname"].ToString();
                                    recTxtEmail.Text = reader["Email"].ToString();
                                    recTxtDept.Text = reader["Department"].ToString();
                                    recTxtUnit.Text = reader["Unit"].ToString();
                                    recTxtBuilding.Text = reader["Building"].ToString();
                                    recTxtFloorNo.Text = reader["Floor"].ToString();

                                    reader.Close();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new LogWriter(ex);
                this.Close();
            }
        }

        private void RecBtnSave_Click(object sender, EventArgs e)
        {
            string callType="";
            string callPriority = recComboPriority.Text;
            string callStatus = "Opened";
            string callAssignedTo = recComboAssignedTo.Text;
            string callDateLogged = DateTime.Now.ToString();
            string callDateResolved = "Still in progress";
            string callAssignedBy = staffNames.Text;
            string callDescription = recTxtCallDescription.Text;

            string techEmail = recComboAssignedTo.Text;
            string clientEmail = recTxtEmail.Text;
            string clientNames = recTxtSurname.Text + " " + recTxtName.Text;
            string callDesc = recTxtCallDescription.Text;
            string refNum = recComboUnikNo.Text;

            string emailMsg = "You have been assigned a new Ticket!";
            GenerateTicketNumber genTicket = new GenerateTicketNumber();
            string TicketNum = genTicket.getTicketNumber();
            try
            {
                if (recRadIncident.Checked == true)
                {
                    callType = "Incident";
                    TicketNum = "I" + genTicket.getTicketNumber();
                }
                else
                {
                    callType = "Request";
                    TicketNum = "R" + genTicket.getTicketNumber();
                }

                if ((recTxtCallDescription.Text == "") || (recComboUnikNo.Text == "") || (recComboAssignedTo.Text == "Choose") || (recComboPriority.Text == "Choose")
                   || (recComboAssignedTo.Text == "") || (recComboPriority.Text == ""))
                {
                    MessageBox.Show("Please fill in all the fields with the correct information");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Tickets(TicketNumber,Type,CreatedBy,Priority,Description,CreatedDate,Status,ClosedDate,AssignedTo) VALUES(@TicketNumber,@Type,@CreatedBy,@Priority,@Description,@CreatedDate,@Status,@ClosedDate,@AssignedTo) ", conn))
                        {
                            cmd.Parameters.AddWithValue("@TicketNumber", TicketNum);
                            cmd.Parameters.AddWithValue("@Type", callType);
                            cmd.Parameters.AddWithValue("@AssignedTo", callAssignedTo);
                            cmd.Parameters.AddWithValue("@CreatedBy", callAssignedBy);
                            cmd.Parameters.AddWithValue("@Priority", callPriority);
                            cmd.Parameters.AddWithValue("@Description", callDescription);
                            cmd.Parameters.AddWithValue("@CreatedDate", callDateLogged);
                            cmd.Parameters.AddWithValue("@Status", callStatus);
                            cmd.Parameters.AddWithValue("@ClosedDate", callDateResolved);

                            cmd.ExecuteNonQuery();

                            SendEmail sendE = new SendEmail();
                            void threadStart()
                            {
                                sendE.sendEmail(Global.Staff.Email,
                                techEmail, clientEmail, clientNames,
                                callDesc, TicketNum, callType,
                                callStatus, callPriority, emailMsg);
                            }
                            Thread thread = new Thread(threadStart);
                            thread.Start();
                        }
                    }
                    //LoadCalls();
                    //string techEmail = recComboAssignedTo.Text;
                    //string clientEmail = recTxtEmail.Text;
                    //string clientNames = recTxtSurname.Text + " " + recTxtName.Text;
                    //string callDesc = recTxtCallDescription.Text;
                }

                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new LogWriter(ex);
                this.Close();
            }
        }

        private void LocBtnContinue_Click(object sender, EventArgs e)
        {
            string refNum = locComboUnikNo.Text;
            try
            {
                if (refNum.ToString().Length > 2)
                {
                    DataTable table = new DataTable();
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
                        {
                            conn.Open();

                            using (conn)
                            {
                                SqlDataAdapter reader = new SqlDataAdapter("SELECT * from Tickets where TicketNumber = '" + refNum + "'", conn);
                                DataSet ds = new DataSet();
                                reader.Fill(ds);
                                dataGridView1.VirtualMode = false;
                                dataGridView1.Columns.Clear();
                                dataGridView1.AutoGenerateColumns = true;
                                dataGridView1.DataSource = ds.Tables[0];
                                dataGridView1.Refresh();

                                try
                                {

                                    for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                                    {
                                        string status = dataGridView1.Rows[rows].Cells[5].Value.ToString();
                                        if (status == "Closed")
                                        {
                                            dataGridView1.Rows[rows].DefaultCellStyle.BackColor = Color.Yellow;
                                        }
                                        else if (status == "Escalated")
                                        {
                                            dataGridView1.Rows[rows].DefaultCellStyle.BackColor = Color.Red;
                                        }
                                        else if (status == "Opened")
                                        {
                                            dataGridView1.Rows[rows].DefaultCellStyle.BackColor = Color.Green;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    new LogWriter(ex);
                                }
                            }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new LogWriter(ex);
                this.Close();
            }
        }

        private void locBtnShowAll_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
            {
                conn.Open();
                using (conn)
                {
                    SqlDataAdapter reader = new SqlDataAdapter("SELECT * from Tickets", conn);
                    DataSet ds = new DataSet();
                    reader.Fill(ds);
                    dataGridView1.VirtualMode = false;
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                try
                {

                    for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                    {
                        string status = dataGridView1.Rows[rows].Cells[6].Value.ToString();
                        if (status == "Closed")
                        {
                            dataGridView1.Rows[rows].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else if (status == "Escalated")
                        {
                            dataGridView1.Rows[rows].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else if (status == "Opened")
                        {
                            dataGridView1.Rows[rows].DefaultCellStyle.BackColor = Color.Green;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void closeBtnSearch_Click(object sender, EventArgs e)
        {
            string refNum = closeComboUnikNo.Text;
            if (refNum.ToString().Length > 2)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT * from Tickets where TicketNumber='" + refNum + "'", conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            closeTxtType.Text = reader["type"].ToString();
                            closeTxtDescription.Text = reader["description"].ToString();
                            closeTxtAssignedTo.Text = reader["AssignedTo"].ToString();
                            closeTxtAssignedBy.Text = reader["CreatedBy"].ToString();

                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    new LogWriter(ex);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid reference number");
            }
        }

        private void closeRadEscalate_Click(object sender, EventArgs e)
        {
            escPnlEsclTo.Visible = true;
        }

        private void closeRadClose_Click(object sender, EventArgs e)
        {
            escPnlEsclTo.Visible = false;
        }

        private void closeBtnSave_Click(object sender, EventArgs e)
        {
            string status;
            if (closeTxtMessage.Text == "")
            {
                MessageBox.Show("Please provide a message");
            }
            else
            {
                if (closeRadClose.Checked == true)
                {
                    status = "Closed";
                }
                else
                {
                    status = "Escalated";
                }
                string callStatus = status;
                string statusDescription = closeTxtMessage.Text;
                string callDateResolved;
                string ticketNum = closeComboUnikNo.Text;
                string escalatedTo = clsEscalatedTo.Text;
                string callType = closeTxtType.Text;
                if (status == "Closed")
                {
                    callDateResolved = DateTime.Now.ToString();
                }
                else
                {
                    callDateResolved = "Still in progress";
                }
                using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("update Tickets set Status= @callStatus ,Description=@statusDescription, ClosedDate= @ClosedDate ,EscalatedTo= @escalatedTo where TicketNumber = '" + ticketNum + "'", conn))
                    {
                        SendEmail sendE = new SendEmail();
                        string emailMsg = "The ticket has been " + callStatus;
                        void threadStart()
                        {
                            sendE.sendEmail(Global.Staff.Email,
                            escalatedTo, "", "",
                            statusDescription, ticketNum, callType,
                            callStatus, "", emailMsg);
                        }
                        Thread thread = new Thread(threadStart);
                        thread.Start();

                        cmd.Parameters.AddWithValue("@callStatus", callStatus);
                        cmd.Parameters.AddWithValue("@ClosedDate", callDateResolved);
                        cmd.Parameters.AddWithValue("@statusDescription", statusDescription);
                        cmd.Parameters.AddWithValue("@escalatedTo", escalatedTo);

                        cmd.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Call sucessfully " + status + "!");
            }
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileFrm frmProfile = new profileFrm();
            frmProfile.Show();
        }
    }
}
