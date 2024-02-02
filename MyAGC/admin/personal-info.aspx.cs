using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.admin
{
    public partial class personal_info : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSavedDetails();
            }
        }

        private void getSavedDetails()
        {
            DataSet GetUsers = um.GetSystemUserByUserEmail(Session["username"].ToString());

            if (GetUsers.Tables.Count > 0 && GetUsers.Tables[0].Rows.Count > 0)
            {
                DataRow row = GetUsers.Tables[0].Rows[0];
                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtAddress.Text = row["Address"].ToString();
                txtMobile.Text = row["Mobile"].ToString();
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
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                WarningAlert("Please enter address");
                return;
            }
            if (string.IsNullOrEmpty(txtMobile.Text))
            {
                WarningAlert("Please enter mobile");
                return;
            }


            SaveDetails();
        }



        private void SaveDetails()
        {
            try
            {
                string Password = "XC4G160UbpgbPhnnnYcKfw==";
                um.InsertAdminDetails(1,int.Parse(Session["userid"].ToString()), txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtMobile.Text, Password);
                getSavedDetails();
                SuccessAlert("Details successfully updated");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}