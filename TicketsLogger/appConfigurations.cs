using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsLogger
{
    public partial class appConfigurations : Form
    {
        public appConfigurations()
        {
            InitializeComponent();
        }
        bool logClicked = false;
        bool emailClicked = false;
        private void labelEmail_Click(object sender, EventArgs e)
        {
            panelEmail.Visible = true;
            panelEmail.Dock = DockStyle.Fill;
            panelLogs.Visible = false;

            logClicked = false;
            emailClicked = true;

            if (emailClicked == true)
            {
                labelEmail.BackColor = Color.White;
                labelEmail.ForeColor = Color.SteelBlue;
                labelLogs.BackColor = Color.SteelBlue;
                labelLogs.ForeColor = Color.White;
                panel2.BackColor = Color.White;
                panel3.BackColor = Color.SteelBlue;
            }
            else
            {
                labelEmail.BackColor = Color.SteelBlue;
                labelEmail.ForeColor = Color.White;
                panel2.BackColor = Color.SteelBlue;
                panel3.BackColor = Color.White;
            }
        }

        private void labelLogs_Click(object sender, EventArgs e)
        {
            panelLogs.Visible = true;
            panelEmail.Visible = false;
            logClicked = true;
            emailClicked = false;
            if (logClicked == true)
            {
                labelLogs.BackColor = Color.White;
                labelLogs.ForeColor = Color.SteelBlue;
                labelEmail.BackColor = Color.SteelBlue;
                labelEmail.ForeColor = Color.White;
                panel3.BackColor = Color.White;
                panel2.BackColor = Color.SteelBlue;
            }
            else
            {
                labelLogs.BackColor = Color.SteelBlue;
                labelLogs.ForeColor = Color.White;
                panel3.BackColor = Color.SteelBlue;
                panel2.BackColor = Color.White;
            }
        }

        private void activityLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + @"TicketsLogger\Logs\ActivityLogs.txt";
                using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    txtLogs.Text = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                new LogWriter(ex);
            }
        }

        private void loginLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + @"TicketsLogger\Logs\loginLogs.txt";
                using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    txtLogs.Text = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                new LogWriter(ex);
            }
        }

        private void errorLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + @"TicketsLogger\Logs\TicketsLogs.txt";
                using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    txtLogs.Text = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                new LogWriter(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendEmail sendE = new SendEmail();
            string emailMsg = "The ticket has been ";
            void threadStart()
            {
                sendE.sendEmail(Global.Staff.Email,
                "rugced@yahoo.fr", "", "",
                "status 1", "1111", "Incident",
                "Open", "", emailMsg);
            }
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        private void appConfigurations_Load(object sender, EventArgs e)
        {
            txtEmail.Text = Properties.Settings.Default.emailAddress;
            txtPassword.Text = Properties.Settings.Default.password;
            txtCompany.Text = Properties.Settings.Default.company;
            cmdSmtp.Text = Properties.Settings.Default.smtp;
            if (cmdSmtp.Text=="smtp.office365.com")
            {
                cmdSmtp.Text = "Office 365";
            }
            else
            {
                cmdSmtp.Text = "Gmail";
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string smtpServer;
                if(cmdSmtp.Text=="Office 365")
                {
                    smtpServer = "smtp.office365.com";
                }
                else
                {
                    smtpServer = "smtp.gmail.com";
                }
                Properties.Settings.Default.smtp = smtpServer;
                Properties.Settings.Default.emailAddress = txtEmail.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.company = txtCompany.Text;
                MessageBox.Show("Configurations Updated");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new LogWriter(ex);
                this.Close();
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            panelLogs.Visible = true;
            panelEmail.Visible = false;
            logClicked = true;
            emailClicked = false;
            if (logClicked == true)
            {
                labelLogs.BackColor = Color.White;
                labelLogs.ForeColor = Color.SteelBlue;
                labelEmail.BackColor = Color.SteelBlue;
                labelEmail.ForeColor = Color.White;
                panel3.BackColor = Color.White;
                panel2.BackColor = Color.SteelBlue;
            }
            else
            {
                labelLogs.BackColor = Color.SteelBlue;
                labelLogs.ForeColor = Color.White;
                panel3.BackColor = Color.SteelBlue;
                panel2.BackColor = Color.White;
            }
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            panelEmail.Visible = true;
            panelEmail.Dock = DockStyle.Fill;
            panelLogs.Visible = false;

            logClicked = false;
            emailClicked = true;

            if (emailClicked == true)
            {
                labelEmail.BackColor = Color.White;
                labelEmail.ForeColor = Color.SteelBlue;
                labelLogs.BackColor = Color.SteelBlue;
                labelLogs.ForeColor = Color.White;
                panel2.BackColor = Color.White;
                panel3.BackColor = Color.SteelBlue;
            }
            else
            {
                labelEmail.BackColor = Color.SteelBlue;
                labelEmail.ForeColor = Color.White;
                panel2.BackColor = Color.SteelBlue;
                panel3.BackColor = Color.White;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
