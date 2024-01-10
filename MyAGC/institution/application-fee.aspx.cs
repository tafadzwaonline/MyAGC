using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.institution
{
    public partial class application_fee : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtID.Value = "0";
                if (Request.QueryString["ID"].ToString() != null)
                {
                    txtID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ID"]));
                }
             
                getCitizenTypes();
                getSavedApplicationFees();
                //getYears();
                //getMonths();
                //getIntake();
                //getAcademicCalendar();


            }
        }

        protected void getCitizenTypes()
        {
            try
            {

                if (lp.getCitizens() != null)
                {
                    ListItem li = new ListItem("Select a Citizen Type", "0");
                    drpCitizenType.DataSource = lp.getCitizens();
                    drpCitizenType.DataValueField = "ID";
                    drpCitizenType.DataTextField = "Name";
                    drpCitizenType.DataBind();
                    drpCitizenType.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Citizen Types", "0");
                    drpCitizenType.DataSource = null;
                    drpCitizenType.DataBind();
                    drpCitizenType.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        private void getSavedApplicationFees()
        {
            DataSet dataSet = lp.getApplicationFees(int.Parse(Session["userid"].ToString()), int.Parse(txtID.Value));

            if (dataSet != null)
            {
                grdApplicationFees.DataSource = dataSet;
                grdApplicationFees.DataBind();
            }
            else
            {
                grdApplicationFees.DataSource = null;
                grdApplicationFees.DataBind();
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
            if (drpCitizenType.SelectedValue == "0")
            {
                WarningAlert("Please select Citizen Type");
                return;
            }
            if (txtAmount.Text == "")
            {
                WarningAlert("Please enter application amount");
                return;
            }
            Save();
        }
        private void Clear()
        {

            drpCitizenType.SelectedValue = "0";
            txtAmount.Text = string.Empty;
        }
        private void Save()
        {
            lp.SaveApplicationFees(int.Parse(Session["userid"].ToString()),int.Parse(txtID.Value),double.Parse(txtAmount.Text),int.Parse(drpCitizenType.SelectedValue));

            getSavedApplicationFees();
            SuccessAlert("Application fee successfully saved");

            Clear();
        }

        protected void grdApplicationFees_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdApplicationFees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}