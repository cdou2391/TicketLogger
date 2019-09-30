using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
            }
            else
            {
                labelEmail.BackColor = Color.SteelBlue;
                labelEmail.ForeColor = Color.White;
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
            }
            else
            {
                labelLogs.BackColor = Color.SteelBlue;
                labelLogs.ForeColor = Color.White;
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
    }
}
