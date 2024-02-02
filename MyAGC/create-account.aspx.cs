using Antlr.Runtime.Misc;
using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC
{
    public partial class create_account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rdStudent_CheckedChanged(object sender, EventArgs e)
        {
            FirstName.Visible = true;
            LastName.Visible = true;
            Password1.Visible = true;
            Password2.Visible = true;
            Emails.Visible = true;
            Phone.Visible = true;
            Address.Visible = true;
            Dob.Visible = true;
            InstitutionAddress.Visible = false;
            InstitutionName.Visible = false;
            AgentLastName.Visible = false;
            AgentFirstName.Visible = false;
            tr1.Visible = true;
            //tr2.Visible = true;
            //tr3.Visible = true;
            tr4.Visible = true;
            ClearLabels();
        }

        protected void rdInstitution_CheckedChanged(object sender, EventArgs e)
        {
            InstitutionAddress.Visible = true;
            InstitutionName.Visible = true;
            AgentLastName.Visible = false;
            AgentFirstName.Visible = false;
            Password1.Visible = true;
            Password2.Visible = true;
            Emails.Visible = true;
            FirstName.Visible = false;
            LastName.Visible = false;
            Phone.Visible = true;
            Address.Visible = false;
            Dob.Visible = false;
            tr1.Visible = true;
            //tr2.Visible = true;
            //tr3.Visible = true;
            tr4.Visible = true;
            ClearLabels();
        }
        protected void rdAgent_CheckedChanged(object sender, EventArgs e)
        {
            AgentFirstName.Visible = true;
            AgentLastName.Visible = true;
            InstitutionAddress.Visible = false;
            InstitutionName.Visible = false;
            Password1.Visible = true;
            Password2.Visible = true;
            Emails.Visible = true;
            FirstName.Visible = false;
            LastName.Visible = false;
            Phone.Visible = true;
            Address.Visible = false;
            Dob.Visible = false;
            tr1.Visible = true;
            tr4.Visible = true;
            ClearLabels();
        }
        private void ClearLabels()
        {
            lblLoginError.Text=string.Empty;
            lblSuccess.Text=string.Empty;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string FirstName= string.Empty;
            string LastName = string.Empty;
            string Addresses= string.Empty;
            int RoleID = 0;
            if (!rdStudent.Checked && !rdInstitution.Checked && !rdAgent.Checked)
            {
                lblLoginError.Text = "Please select account type to register";
                return;
            }

            if (rdStudent.Checked)
            {
                List<string> errorMessages = new List<string>();

                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    errorMessages.Add("FirstName is required");
                }
                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    errorMessages.Add("LastName is required");
                }
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    errorMessages.Add("Address is required");
                }
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    errorMessages.Add("Phone No is required");
                }
                if (string.IsNullOrWhiteSpace(txtDOB.Text))
                {
                    errorMessages.Add("Date Of Birth is required");
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    errorMessages.Add("Email is required");
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errorMessages.Add("Password is required");
                }
                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    errorMessages.Add("Repeat Password is required");
                }

                if (txtEmail.Text.Contains("'"))
                {
                    txtEmail.Text = txtEmail.Text.Replace("'", "");
                }
                if (txtPhone.Text.Contains("+"))
                {
                    txtPhone.Text = txtPhone.Text.Replace("+", "");
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
                FirstName = txtFirstName.Text;
                LastName = txtLastName.Text;
                Addresses = txtAddress.Text;
                RoleID = 3;
            }
            if (rdInstitution.Checked)
            {
                List<string> errorMessages = new List<string>();

                if (string.IsNullOrWhiteSpace(txtInstitutionName.Text))
                {
                    errorMessages.Add("Institution Name is required");
                }
                if (string.IsNullOrWhiteSpace(txtInstitutionAddress.Text))
                {
                    errorMessages.Add("Institution Address is required");
                }
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    errorMessages.Add("Mobile No is required");
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    errorMessages.Add("Email is required");
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errorMessages.Add("Password is required");
                }
                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    errorMessages.Add("Repeat Password is required");
                }

                if (txtEmail.Text.Contains("'"))
                {
                    txtEmail.Text = txtEmail.Text.Replace("'", "");
                }
                if (txtPhone.Text.Contains("+"))
                {
                    txtPhone.Text = txtPhone.Text.Replace("+", "");
                }

                if (!txtEmail.Text.Contains("@"))
                {
                    errorMessages.Add("Please enter a valid email address");
                }
                if (txtEmail.Text.Contains("gmail"))
                {
                    errorMessages.Add("Please enter institution valid email address");
                }
                if (errorMessages.Count > 0)
                {
                    lblLoginError.Text = string.Join("<br>", errorMessages);
                    return;
                }
                FirstName = txtInstitutionName.Text;
                Addresses = txtInstitutionAddress.Text;
                RoleID = 2;
            }


            if (rdAgent.Checked)
            {
                List<string> errorMessages = new List<string>();

                if (string.IsNullOrWhiteSpace(txtAgentFirstName.Text))
                {
                    errorMessages.Add("Agent FirstName is required");
                }
                if (string.IsNullOrWhiteSpace(txtAgentLastName.Text))
                {
                    errorMessages.Add("Agent LastName is required");
                }
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    errorMessages.Add("Mobile No is required");
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    errorMessages.Add("Email is required");
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errorMessages.Add("Password is required");
                }
                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    errorMessages.Add("Repeat Password is required");
                }
              
                if (txtEmail.Text.Contains("'"))
                {
                    txtEmail.Text = txtEmail.Text.Replace("'", "");
                }
                if (txtPhone.Text.Contains("+"))
                {
                    txtPhone.Text = txtPhone.Text.Replace("+", "");
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
                FirstName = txtAgentFirstName.Text;
                LastName = txtAgentLastName.Text;
                Addresses = txtInstitutionAddress.Text;
                RoleID = 4;
            }

            if (!CheckBox2.Checked)
            {
                lblLoginError.Text = "Please agree to the terms and conditions to proceed";
                return;
            }
            RegisterUser(FirstName,LastName, Addresses, RoleID);
        }
        //static string RemoveCharacters(string input, params char[] charactersToRemove)
        //{
        //    foreach (char character in charactersToRemove)
        //    {
        //        input = input.Replace(character.ToString(), string.Empty);
        //    }

        //    return input;
        //}
        protected void RegisterUser(string FirstName,string LastName,string Addresses,int RoleID)
        {
            try
            {
                UsersManagement um = new UsersManagement("con");
                EncryptDecryptClass encryptDecrypt = new EncryptDecryptClass();
                string newPassword = txtPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;

                //validate duplicates
                if (um.CheckEmailExists(txtEmail.Text))
                {
                    lblLoginError.Text= "Email already exists";
                    return;
                }

                // Password validation checks
                if (newPassword.Length < 6)
                {
                    lblLoginError.Text = $"Minimum Password Length is {6}";
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
                if (RoleID != 3)
                {
                    txtDOB.Text = DateTime.Now.ToString();
                }

                // Encrypt the password
                string encryptedPassword = encryptDecrypt.EncryptPassword(newPassword);
                um.SaveAccount(FirstName,LastName,txtEmail.Text,txtPhone.Text, encryptedPassword, Addresses,Convert.ToDateTime(txtDOB.Text), RoleID);

                lblSuccess.Text = "Account successfully registered";
                Clear();

    }
            catch (Exception ex)
            {
                lblLoginError.Text = ex.ToString();
            }
        }


        private void Clear()
        {
            txtFirstName.Text=string.Empty;
            txtLastName.Text=string.Empty;
            txtAgentLastName.Text = string.Empty;
            txtAgentFirstName.Text = string.Empty;
            txtPassword.Text=string.Empty;
            txtConfirmPassword.Text=string.Empty;
            txtEmail.Text=string.Empty;
            txtPhone.Text=string.Empty;
            txtAddress.Text=string.Empty;
            txtDOB.Text=string.Empty;
            txtInstitutionAddress.Text=string.Empty;
            txtInstitutionName.Text=string.Empty;
            rdStudent.Checked = false;
            rdInstitution.Checked = false;
            CheckBox2.Checked = false;
            lblLoginError.Text=string.Empty;
        }

        
    }
}