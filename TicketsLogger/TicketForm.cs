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
                MessageBox.Show("You are not going anywhere!");
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
                        staffNumber.Text = reader["StaffNumber"].ToString();
                        recComboAssignedTo.Items.Add(staffEmail);
                        recComboUnikNo.Items.Add(staffNumber);
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
                                using (SqlCommand cmd = new SqlCommand("SELECT * from staff where StaffNumber = '" + id + "'", conn))
                                {
                                    SqlDataReader reader = cmd.ExecuteReader();
                                    reader.Read();
                                    recTxtName.Text = reader["Name"].ToString();
                                    recTxtSurname.Text = reader["Surname"].ToString();
                                    recTxtEmail.Text = reader["Email"].ToString();
                                    //recTxtContactNo.Text = reader["contactNumber"].ToString();
                                    //recTxtAddress.Text = reader["address"].ToString();
                                    //recTxtBuilding.Text = reader["building"].ToString();
                                    //recTxtFloorNo.Text = reader["floorNo"].ToString();

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
    }
}
