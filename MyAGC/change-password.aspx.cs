using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC
{
    public partial class change_password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryStringModule querystring = new QueryStringModule();
                txtid.Value = "0";
                if (Request.QueryString["id"].ToString() != null)
                {
                    txtid.Value = querystring.Decrypt(HttpUtility.UrlDecode(Request.QueryString["id"]));

                }
            }


        }

        protected void BtnChangePassword_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text == "")
            {
                lblLoginError.Text = "Please enter your new password";
                return;
            }
            if (txtPassword2.Text == "")
            {
                lblLoginError.Text = "Please Confirm your new password";
                return;
            }
            ChangePassword();
        }


        private void ChangePassword()
        {
            try
            {
                EncryptDecryptClass encryptDecrypt = new EncryptDecryptClass();
                int userId = int.Parse(txtid.Value);
                UsersManagement user = new UsersManagement("con");
                LookUp look = new LookUp("con");

                // Validate and get required parameters
                int passwordLength = 6;


                string newPassword = txtPassword.Text;
                string confirmPassword = txtPassword2.Text;

                // Password validation checks
                if (newPassword.Length < passwordLength)
                {
                    lblLoginError.Text = $"Minimum Password Length is {passwordLength}";
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    lblLoginError.Text = "Passwords do not match!";
                    return;
                }

                bool containsSpecialChar = newPassword.Any(ch => !Char.IsLetterOrDigit(ch));
                if (!containsSpecialChar)
                {
                    lblLoginError.Text = "Password Must Contain at Least One Special Character!";
                    return;
                }

                // Fetch current password
                string currentPassword = string.Empty;
                DataRow userRow = look.getSystemUserById(userId)?.Tables[0]?.Rows[0];
                if (userRow != null)
                {
                    currentPassword = encryptDecrypt.DecryptPassword(userRow["Password"].ToString());
                }

                // Check if the new password is same as the old password
                if (newPassword == currentPassword)
                {
                    lblLoginError.Text = "New password cannot be the same as the old password.";
                    return;
                }

                // Encrypt and update the password
                string encryptedPassword = encryptDecrypt.EncryptPassword(newPassword);
                user.UpdatePassword(userId, encryptedPassword);

                lblSuccess.Text = "Password successfully changed.";
                lblLoginError.Text = "";
            }
            catch (FormatException ex)
            {
                lblLoginError.Text = "Invalid user ID format. Please provide a valid ID.";
            }
            catch (Exception ex)
            {

                lblLoginError.Text = "An error occurred. Please try again later.";

            }
        }
    }
}