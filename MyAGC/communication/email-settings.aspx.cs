using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.communication
{
    public partial class email_settings : System.Web.UI.Page
    {
        
        LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSavedEmailParameters();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                WarningAlert("Please enter email address");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                WarningAlert("Please enter password");
                return;
            }
            if (string.IsNullOrEmpty(txtHost.Text))
            {
                WarningAlert("Please enter host");
                return;
            }
            if (string.IsNullOrEmpty(txtPort.Text))
            {
                WarningAlert("Please enter port");
                return;
            }
            Save();
        }

        private void Save()
        {
            try
            {
                lp.SaveEmailSettings(int.Parse(Session["userid"].ToString()),txtEmailAddress.Text, txtPassword.Text, txtHost.Text, int.Parse(txtPort.Text));
                getSavedEmailParameters();
                SuccessAlert("Details successfully saved");
               


            }
            catch (Exception)
            {

                throw;
            }
        }
        private void getSavedEmailParameters()
        {
            DataSet email = lp.getSavedEmailSettings(int.Parse(Session["userid"].ToString()));
            if (email != null)
            {
                DataRow rw = email.Tables[0].Rows[0];
                txtEmailAddress.Text = rw["Email"].ToString();
                txtPassword.Text = rw["Password"].ToString();
                txtHost.Text = rw["Host"].ToString();
                txtPort.Text = rw["Port"].ToString();
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