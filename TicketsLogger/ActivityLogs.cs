using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsLogger
{
    class ActivityLogs
    {
        private string m_exePath = string.Empty;
        public ActivityLogs(string Names, string Action, string appTime)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Staff Names: {0}", Names);
            message += Environment.NewLine;
            message += string.Format("Activity: {0}", Action);
            message += Environment.NewLine;
            message += string.Format("Appointment Time: {0}", appTime);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + @"TicketsLogger\Logs\ActivityLogs.txt";
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Patient\Logs"));

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }

        }
    }
}
