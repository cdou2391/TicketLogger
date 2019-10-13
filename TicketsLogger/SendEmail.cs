using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace TicketsLogger
{
    class SendEmail
    {
        public string sendEmail(string sender, string receiver1, string receiver2, string clientName, 
                                string callMessage, string referenceNum,string callType, string callStatus, 
                                string callPriority,string introMsg)
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
            string callPrior = callPriority;
            string msgIntro = introMsg;
            

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
                            string clientOrgName = reader2["name"].ToString();
                            string orgEmail = "rugced23@gmail.com"; reader2["email"].ToString();
                            var toAddress2 = new MailAddress(orgEmail, "From " + clientOrgName);
                            var toAddress3 = new MailAddress(client, "From " + clientOrgName);
                            string fromPassword = Properties.Settings.Default.password;

                            var toAddress = new MailAddress("rugced23@gmail.com", "rugced23@gmail.com");
                            string subject = "New Ticket";
                            string body;
                            body = (msgIntro+"\r\nTicket Number: " + referenceNum 
                                  + "\r\nCall Type: " + callT +"\r\nCall Description: " + callDesc 
                                  + "\r\nCall Status: " + callStat + "\r\nCall Priority: "+ callPrior);
                            string smtpServer = Properties.Settings.Default.smtp;
                            try
                            {
                                smtpServer = Properties.Settings.Default.smtp;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("Please specify the mail server and save!");
                            }
                            finally
                            {
                                string fromAddress = Properties.Settings.Default.emailAddress;
                                var smtp = new SmtpClient
                                {
                                    Host = smtpServer,
                                    Port = 587,
                                    EnableSsl = true,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    Credentials = new NetworkCredential(fromAddress, fromPassword),
                                    Timeout = 20000
                                };
                                using (var message1 = new MailMessage(fromAddress, "rugced23@gmail.com")
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
                                        MessageBox.Show("Email to " + toAddress + " was succesfully sent!" + smtp.Credentials);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Email to " + toAddress + " was no sent! \nError: " + ex.Message + fromAddress + fromPassword);
                                        new LogWriter(ex);
                                    }
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
