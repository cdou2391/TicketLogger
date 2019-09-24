using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsLogger
{
    class LogWriter
    {
        private string m_exePath = string.Empty;
        public LogWriter(Exception ex)
        {
            //LogWrite(logMessage);
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + @"TicketsLogger\Logs\TicketsLogs.txt";
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"TicketsLogger\Logs"));

            string currentLog = String.Empty;
            try
            {
                if (File.Exists(path))
                {
                    currentLog = File.ReadAllText(path);
                    File.Delete(path);
                }
                else
                {
                    File.Create(path);
                }
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(message + currentLog);
                    writer.Close();
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
    }
}
