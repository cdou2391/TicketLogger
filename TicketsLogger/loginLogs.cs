using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsLogger
{
    class loginLogs
    {

            private string m_exePath = string.Empty;
            public loginLogs(string Names, string ID, string Em, string Dep)
            {
                string message = string.Format("Login Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                message += Environment.NewLine;
                message += "-----------------------------------------------------------";
                message += Environment.NewLine;
                message += string.Format("Technician Names: {0}", Names);
                message += Environment.NewLine;
                message += string.Format("Technician ID: {0}", ID);
                message += Environment.NewLine;
                message += string.Format("Technician Email: {0}", Em);
                message += Environment.NewLine;
                message += string.Format("Technician Department: {0}", Dep);
                message += Environment.NewLine;
                message += "-----------------------------------------------------------";

            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + @"TicketsLogger\Logs\loginLogs.txt";
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Car Management\Logs"));

                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(message);
                    writer.Close();
                }

            }
        
    }
}
