using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.admin
{

    public partial class create_user : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
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
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                WarningAlert("Please enter firstname");
                return;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                WarningAlert("Please enter lastname");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                WarningAlert("Please enter email");
                return;
            }
            if (txtEmail.Text.Contains("'"))
            {
                txtEmail.Text = txtEmail.Text.Replace("'", "");
            }

            if (!txtEmail.Text.Contains("@"))
            {
                WarningAlert("Please enter valid email");
                return;
            }



            SaveDetails();
        }



        private void SaveDetails()
        {
            try
            {
                string Password = "XC4G160UbpgbPhnnnYcKfw==";
                um.InsertAdminDetails(0, txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtMobile.Text, Password);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application successful, now awaiting confirmation');window.location ='../admin/view-user';", true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}