using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    class SendEmail
    {
        public string sendEmail(string sender, string receiver1, string receiver2, string clientName, string callMessage, string referenceNum,string callType, string callStatus)
        {
            string staff = sender;
            string tech = receiver1;
            string client = receiver2;
            string clientNames = clientName;
            string callDesc = callMessage;
            string callT = callType;
            string callStat = callStatus;
            string refNum = referenceNum;
            string message = "";

            using (SqlConnection conn = new SqlConnection(DatabaseConnection.connectionStr))
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * from Staff where email = '" + client + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        string email = Global.Staff.Email;
                        reader.Close();
                        using (SqlCommand cmd2 = new SqlCommand("SELECT * from Staff where email = '" + email + "'", conn))
                        {
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            reader2.Read();
                            string inputPassword="";
                            string clientOrgName = reader2["name"].ToString();
                            //string orgEmail = "rugced23@gmail.com"; reader2["email"].ToString();
                            //var toAddress2 = new MailAddress(orgEmail, "From " + clientOrgName);
                            //var toAddress3 = new MailAddress(client, "From " + clientOrgName);
                            var fromAddress = new MailAddress("crugamba@bk.rw", Global.Staff.Name + " " + Global.Staff.Surname);
                            if (inputBox.InputBox("Password", "Enter password:", ref inputPassword) == DialogResult.OK)
                            {
                                //MessageBox.Show(value);
                                //string fromPassword = inputPassword;
                            }
                            
                            var toAddress = new MailAddress(tech, "");
                            string subject = "New Ticket";
                            string body;
                            body = ("You have been assigned a Ticket \r\nTicket Number: " + referenceNum 
                                + "\r\nCall Type: " + callT +"\r\nCall Description: " + callDesc 
                                + "\r\nCall Status: " + callStat);
                            var smtp = new SmtpClient
                            {
                                Host = "smtp.office365.com",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                Credentials = new NetworkCredential(fromAddress.Address, inputPassword),
                                Timeout = 20000
                            };
                            using (var message1 = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = subject,
                                Body = body,
                            })
                            {
                                ServicePointManager.ServerCertificateValidationCallback =
                                                delegate (object s, X509Certificate certificate,
                                                         X509Chain chain, SslPolicyErrors sslPolicyErrors)
                                                { return true; };
                                try
                                {
                                    smtp.Send(message1);
                                    MessageBox.Show("Email to " + toAddress + " was succesfully sent!");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Email to " + toAddress + " was no sent! \nError: " + ex.Message);
                                    new LogWriter(ex);
                                }
                            
                            //try
                            //{
                            //    smtp.Send(message2);
                            //    MessageBox.Show("Email to " + toAddress2 + " was succesfully sent!");
                            //}
                            //catch (Exception ex)
                            //{ MessageBox.Show("Email to rec2" + toAddress2 + " was no sent! \nError: " + ex.Message); }
                            //try
                            //{
                            //    smtp.Send(message3);
                            //    MessageBox.Show("Email to " + toAddress3 + " was succesfully sent!");
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show("Email to rec3" + toAddress3 + " was no sent! \nError: " + ex.Message);
                            //}
                            message = ("All emails succesfully sent");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    new LogWriter(ex);
                }
            }
            return message;

        }
    }
}
