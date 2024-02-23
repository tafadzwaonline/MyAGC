using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.profile
{
    public partial class my_profile : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClientImage();
                Clear();
            }
        }
        protected void LoadClientImage()
        {
            try
            {
                ClientPic.ImageUrl = string.Format("~/ImageHandler.ashx?UserID={0}", int.Parse(Session["userid"].ToString()));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void DangerAlert(string Err)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('" + Err + "')</script>", false);
        }
        protected void SuccessAlert(string message)
        {

            string script = $"SuccessToastr('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastScript", script, true);
        }
        protected void WarningAlert(string message)
        {
            string script = $"WarningToastr('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastScript", script, true);
        }
        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (!fileUpload.HasFile)
            {
                WarningAlert("Please select an image to upload");
                return;
            }
            string fileExtension = System.IO.Path.GetExtension(fileUpload.FileName).ToLower();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            if (!allowedExtensions.Contains(fileExtension))
            {
                // Invalid file type, show error message or handle accordingly
                // Clear the FileUpload control
                WarningAlert("Please upload only image files");

                fileUpload.FileContent.Dispose(); // Dispose to prevent memory leaks

                // Display an error message to the user
                // e.g., ErrorMessageLabel.Text = "Please select an image file (JPG, PNG, GIF).";
                return;
            }

            SaveImage();
        }
        private void SaveImage()
        {
            try
            {
                Byte[] bytes = null;
                if (fileUpload.HasFile)
                {
                    string filename = fileUpload.PostedFile.FileName;
                    string filePath = Path.GetFileName(filename);
                    Stream fs = fileUpload.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);
                }

                if (lp.SaveClientImage(long.Parse(Session["userid"].ToString()), bytes))
                {

                    LoadClientImage();
                    SuccessAlert("Image successfully uploaded");
                }
            }
            catch (Exception generatedExceptionName)
            {
                DangerAlert(generatedExceptionName.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                WarningAlert("Please enter new password");
                return;
            }
            if (txtRepeatPassword.Text == "")
            {
                WarningAlert("Please repeat new password");
                return;
            }

            ChangePassword();
        }

        private void ChangePassword()
        {
            try
            {
                EncryptDecryptClass encryptDecrypt = new EncryptDecryptClass();
                int userId = int.Parse(Session["userid"].ToString());


                // Validate and get required parameters
                int passwordLength = 6;


                string newPassword = txtPassword.Text;
                string confirmPassword = txtRepeatPassword.Text;

                // Password validation checks
                if (newPassword.Length < passwordLength)
                {
                    WarningAlert($"Minimum Password Length is {passwordLength}");
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    WarningAlert("Passwords do not match!");
                    return;
                }

                bool containsSpecialChar = newPassword.Any(ch => !Char.IsLetterOrDigit(ch));
                if (!containsSpecialChar)
                {
                    WarningAlert("Password Must Contain at Least One Special Character!");
                    return;
                }

                // Encrypt and update the password
                string encryptedPassword = encryptDecrypt.EncryptPassword(newPassword);
                um.UpdatePassword(userId, encryptedPassword);

                SuccessAlert("Password successfully changed.");
                Clear();
            }
            catch (FormatException ex)
            {
                throw;
            }

        }

        private void Clear()
        {
            txtPassword.Text = string.Empty;
            txtRepeatPassword.Text = string.Empty;
        }
    }
}