using CrystalDecisions.CrystalReports.Engine;
using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.admin
{
    public partial class TotalPaymentsReport : System.Web.UI.Page
    {
        ReportDocument myReport;
        LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //getRoles();
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["TotalPaymentsReport"];
                TotalPaymentsReportViewer.ReportSource = doc;
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStartDate.Text))
            {
                WarningAlert("Please select start date");
                return;
            }
            if (string.IsNullOrEmpty(txtEndDate.Text))
            {
                WarningAlert("Please select end date");
                return;
            }

            //if (drpUserRoles.SelectedValue == "0")
            //{
            //    WarningAlert("Please select a user role");
            //    return;
            //}

            ViewReport();
        }

        //private void getRoles()
        //{
        //    try
        //    {

        //        if (lp.getRoles() != null)
        //        {
        //            ListItem li = new ListItem("Select a role", "0");
        //            drpUserRoles.DataSource = lp.getRoles();
        //            drpUserRoles.DataValueField = "RoleID";
        //            drpUserRoles.DataTextField = "RoleName";
        //            drpUserRoles.DataBind();
        //            drpUserRoles.Items.Insert(0, li);
        //        }
        //        else
        //        {
        //            ListItem li = new ListItem("There are no roles", "0");
        //            drpUserRoles.DataSource = null;
        //            drpUserRoles.DataBind();
        //            drpUserRoles.Items.Insert(0, li);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        WarningAlert(ex.Message);
        //    }
        //}
        protected void WarningAlert(string message)
        {
            string script = $"WarningToastr('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastScript", script, true);
        }
        private void ViewReport()
        {
            myReport = new ReportDocument();
            myReport.Load(Server.MapPath(@"../reports/TotalPaymentsReport.rpt"));
            string servername = ConfigurationManager.AppSettings["servername"].ToString();
            string ReportPass = ConfigurationManager.AppSettings["ReportPass"].ToString();
            string DBName = ConfigurationManager.AppSettings["DBName"].ToString();
            string DbUser = ConfigurationManager.AppSettings["DbUser"].ToString();


            myReport.SetDatabaseLogon(DbUser, ReportPass, servername, DBName);
            CrystalDecisions.Shared.ParameterFields myParameterFields = new CrystalDecisions.Shared.ParameterFields();
            CrystalDecisions.Shared.ParameterField myParameterField = new CrystalDecisions.Shared.ParameterField();
            CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            myParameterField.ParameterFieldName = "EndDate";
            myDiscreteValue.Value = txtEndDate.Text;
            myParameterField.CurrentValues.Add(myDiscreteValue);
            myParameterFields.Add(myParameterField);

            CrystalDecisions.Shared.ParameterField myParameterField1 = new CrystalDecisions.Shared.ParameterField();
            CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue1 = new CrystalDecisions.Shared.ParameterDiscreteValue();
            myParameterField1.ParameterFieldName = "StartDate";
            myDiscreteValue1.Value = txtStartDate.Text;
            myParameterField1.CurrentValues.Add(myDiscreteValue1);
            myParameterFields.Add(myParameterField1);

            TotalPaymentsReportViewer.ReportSource = myReport;
            TotalPaymentsReportViewer.ParameterFieldInfo = myParameterFields;
            TotalPaymentsReportViewer.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;

            Session["TotalPaymentsReport"] = myReport;
        }
    }
}