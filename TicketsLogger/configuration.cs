using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TicketsLogger
{
    public partial class configuration : Form
    {
        public configuration()
        {
            InitializeComponent();
            configurations = new configurations();
        }

        private void configuration_Load(object sender, EventArgs e)
        {
            LoadConfig();
            MessageBox.Show(configurations.Email);
        }
        // Global Variables
        static string APPDATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // AppData folder
        static string CFGFOLDER_PATH = Path.Combine(APPDATA_PATH, "Ticket Logger");     // Path for program config folder
        static string CFGFILE_PATH = Path.Combine(CFGFOLDER_PATH, "config.txt");   // Path for config.txt file
        string[] CFG_STR_DELIM = new string[] { " = " }; // Config file string delimiter
        configurations configurations;    // Holds settings for 
        public void LoadConfig()
        {
            // Does the config folder not exist?
            if (!Directory.Exists(CFGFOLDER_PATH))
                Directory.CreateDirectory(CFGFOLDER_PATH); // Create the Config File Exmaple folder

            // Does config.txt not exist?
            if (!File.Exists(CFGFILE_PATH))
                CreateConfig();

            ReadConfig();
        }
        private void CreateConfig()
        {
            StreamWriter cfgWriter = File.CreateText(CFGFILE_PATH);

            string[] cfgDefaults = new string[] { "List Index" + CFG_STR_DELIM[0] + "0",
                                                  "True/False" + CFG_STR_DELIM[0] + "true",
                                                  "Email" + CFG_STR_DELIM[0] + "Default Text",
                                                  "Password" + CFG_STR_DELIM[0] + "Default Text"};

            foreach (string setting in cfgDefaults)
            {
                cfgWriter.WriteLine(setting);
            }

            cfgWriter.Close();
        }

        private void ReadConfig()
        {
            StreamReader cfgReader = File.OpenText(CFGFILE_PATH);

            int settingNameIndex = 0;               // The index of the setting name
            int settingValueIndex = 1;              // The index of the setting value
            string settingLine;                     // String that holds the text read from config file
            string[] cfgSettingArr = new string[2]; // String array that holds the split settingLine string
            List<string[]> cfgList = new List<string[]>(); // List that holds all the cfgSettingArr objects

            // Read the config file until the end of the file
            for (int index = 0; !cfgReader.EndOfStream; index++)
            {
                settingLine = cfgReader.ReadLine();

                // Does the line contain text?
                if (!String.IsNullOrWhiteSpace(settingLine))
                {
                    // Split the read text into cfgSettingArr
                    cfgSettingArr = settingLine.Split(CFG_STR_DELIM, StringSplitOptions.None);

                    // Add to the cfgList
                    cfgList.Add(cfgSettingArr);
                }
            }

            // Read all the settings in the cfgList
            foreach (string[] setting in cfgList)
            {
                string settingName = setting[settingNameIndex];

                // Read the setting name and update corresponding configuration value
                switch (settingName)
                {
                    case "List Index":
                        {
                            configurations.ListIndex = int.Parse(setting[settingValueIndex]);
                            break;
                        }
                    case "True/False":
                        {
                            configurations.TrueFalse = bool.Parse(setting[settingValueIndex]);
                            break;
                        }
                    case "Email":
                        {
                            configurations.Email = setting[settingValueIndex];
                            break;
                        }
                    case "Password":
                        {
                            configurations.Password = setting[settingValueIndex];
                            break;
                        }
                    // Default statement for invalid setting name
                    default:
                        {
                            // Warn user of invalid data and ask for 
                            // confirmation before recreating config file
                            var errorMessage = MessageBox.Show(this,
                                                            "Error reading config file." + Environment.NewLine +
                                                            "Would you like to recreate it?" + Environment.NewLine +
                                                            "Click \"Yes\" to recreate the file, or \"No\" to cancel loading.",
                                                            "File Read Error",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Error,
                                                            MessageBoxDefaultButton.Button1);

                            // Did the user click yes?
                            if (errorMessage == DialogResult.Yes)
                                CreateConfig();

                            else
                                return;
                            break;
                        }
                }
            }

            listBox1.SelectedIndex = configurations.ListIndex;

            // Is the TrueFalse value true?
            if (configurations.TrueFalse == true)
                radGmail.Checked = true;

            else
                radOutlook.Checked = true;

            txtSystemEmail.Text = configurations.Email;
            txtPassword.Text = configurations.Password;

            cfgReader.Close();
        }
        private void SaveConfig()
        {
            configurations.ListIndex = listBox1.SelectedIndex;
            configurations.TrueFalse = radOutlook.Checked;
            configurations.Email = txtSystemEmail.Text;
            configurations.Password = txtPassword.Text;

            UpdateConfig();
        }
        private void UpdateConfig()
        {
            StreamWriter cfgUpdater = new StreamWriter(CFGFILE_PATH);

            List<string> cfgValues = new List<string>();

            cfgValues.Add("List Index" + CFG_STR_DELIM[0] + configurations.ListIndex.ToString());
            cfgValues.Add("True/False" + CFG_STR_DELIM[0] + configurations.TrueFalse.ToString());
            cfgValues.Add("Email" + CFG_STR_DELIM[0] + configurations.Email);
            cfgValues.Add("Password" + CFG_STR_DELIM[0] + configurations.Password);


            foreach (string setting in cfgValues)
                cfgUpdater.WriteLine(setting);

            cfgUpdater.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            LoadConfig();
            SendEmail sendE = new SendEmail();
            void threadStart()
            {
                sendE.sendEmail("rugambacedric@gmail.com",
                "rugced23@gmail.com","rugambacedric@gmail.com", "clientNames",
                "callDesc", "TicketNum", "callType",
                "callStatus", "callPriority", "emailMsg");
            }
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
    }
}
