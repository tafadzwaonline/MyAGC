using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static MyAGC.Classes.LookUp;

namespace MyAGC
{
    public partial class forgot_password : System.Web.UI.Page
    {
        readonly LookUp look = new LookUp("con");
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errorMessages = new List<string>();

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    errorMessages.Add("Email is required");
                }
                if (txtEmail.Text.Contains("'"))
                {
                    txtEmail.Text = txtEmail.Text.Replace("'", "");
                }
                if (!txtEmail.Text.Contains("@"))
                {
                    errorMessages.Add("Please enter a valid email address");
                }

                if (errorMessages.Count > 0)
                {
                    lblLoginError.Text = string.Join("<br>", errorMessages);
                    return;
                }
                string userEmail = txtEmail.Text;
               

                if (!um.CheckEmailExists(userEmail))
                {
                    lblLoginError.Text = "Email does not exists";
                    return;
                }
                // Generate the 6-digit code
                int code = RandomGenerator.GenerateRandom6DigitNumber();

                // Send the code to the user's email
                SendEmail(userEmail, code);

                // Redirect the user to a verification page or display a success message
                
            }
            catch (Exception ex)
            {

                lblLoginError.Text = ex.ToString();
            }
        }
        private void SendEmail(string recipientEmail, int code)
        {
            try
            {

                string EmailHost = string.Empty;
                string EmailPort = string.Empty;
                string EmailAddress = string.Empty;
                string EmailPassword = string.Empty;

                DataSet emails = look.getEmailSettings(int.Parse(Session["userid"].ToString()));
                if (emails != null)
                {
                    DataRow row = emails.Tables[0].Rows[0];
                    EmailHost = row["Host"].ToString();
                    EmailPort = row["Port"].ToString();
                    EmailAddress = row["Email"].ToString();
                    EmailPassword = row["Password"].ToString();
                }
                else
                {
                    lblLoginError.Text = "No email settings found";
                    return;
                }

                SmtpClient Client = new SmtpClient()
                {
                    Host = EmailHost,
                    Port = int.Parse(EmailPort),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = EmailAddress,
                        Password = EmailPassword
                    }
                };

                MailAddress FromEmail = new MailAddress(EmailAddress, "MyAGC");
                MailAddress ToEmail = new MailAddress("" + recipientEmail + "", "Client");
                MailMessage Message = new MailMessage()
                {
                    From = FromEmail,
                    Subject = "Password Reset"
                };

                // Prompt the user to change their password
                look.UpdateVerificationCode(code, recipientEmail);

                string body = $@"<html>
                    <body>
                      
                        <p>Good Day,</p>
                        <p>Your password reset code is {code}</p>
                        <p>Regards,</p>
                        <p><b>MyAGC Management</b></p>
                    </body>
                </html>";

                // Create an alternate view with the HTML body
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");

                // Load the image from a file in the folder
                //string imagePath = @"C:\Systems\NovaPublished\files\img\nova.PNG";
                //// string imagePath = "../files/img/nova.PNG";
                //LinkedResource imageResource = new LinkedResource(imagePath);
                //imageResource.ContentId = "imageId";

                // Add the image to the alternate view
                //htmlView.LinkedResources.Add(imageResource);

                // Add the alternate view to the email message
                Message.AlternateViews.Add(htmlView);

                Message.To.Add(ToEmail);
                try
                {
                    Client.Send(Message);
                    //lblSuccess.Text = "Please check your email to reset your password";
                    Response.Redirect("verify-email.aspx");
                    // MessageBox.Show("send successfully", "Done");
                }
                catch (Exception ex)
                {
                    // DangerAlert(ex.ToString());
                    lblLoginError.Text = ex.ToString();
                }
            }
            catch (Exception ex)
            {
                //DangerAlert(ex.ToString());
                lblLoginError.Text = ex.ToString();
            }
        }
    }
}