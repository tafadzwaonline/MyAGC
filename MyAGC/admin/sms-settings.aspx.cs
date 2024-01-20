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
    public partial class sms_settings : System.Web.UI.Page
    {
        LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSavedSmsParameters();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSenderName.Text))
            {
                WarningAlert("Please enter sender name");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                WarningAlert("Please enter password");
                return;
            }
            if (string.IsNullOrEmpty(txtSenderNumber.Text))
            {
                WarningAlert("Please enter sender number");
                return;
            }

            Save();
        }

        private void Save()
        {
            try
            {
                lp.SaveSmsSettings(int.Parse(Session["userid"].ToString()), txtSenderName.Text, txtPassword.Text, txtSenderNumber.Text);
                getSavedSmsParameters();
                SuccessAlert("Details successfully saved");

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void getSavedSmsParameters()
        {
            DataSet email = lp.getSavedSmsSettings(int.Parse(Session["userid"].ToString()));
            if (email != null)
            {
                DataRow rw = email.Tables[0].Rows[0];
                txtSenderName.Text = rw["Name"].ToString();
                txtPassword.Text = rw["Password"].ToString();
                txtSenderNumber.Text = rw["SenderID"].ToString();

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
    }
}