using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
                MessageBox.Show("You are not going anywhere!");
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
                MessageBox.Show("You are not going anywhere!");
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

            string techEmail = recComboAssignedTo.Text;
            string clientEmail = recTxtEmail.Text;
            string clientNames = recTxtSurname.Text + " " + recTxtName.Text;
            string callDesc = recTxtCallDescription.Text;
            string refNum = recComboUnikNo.Text;

            GenerateTicketNumber genRef = new GenerateTicketNumber();
            string TicketNum = genRef.getTicketNumber();

            SendEmail sendE = new SendEmail();
            string message = sendE.sendEmail(Global.Staff.Email, techEmail, clientEmail, clientNames, callDesc, TicketNum,callType,callStatus);
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
    }
}
