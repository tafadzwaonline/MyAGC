using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.institution
{
    public partial class ApplicationsReport : System.Web.UI.Page
    {
        ReportDocument myReport;
        LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getApplicationStatus();
            }
            else
            {
                ReportDocument doc = (ReportDocument)Session["ApplicationReport"];
                ApplicationsReportViewer.ReportSource = doc;
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
                WarningAlert("Please select eend date");
                return;
            }

            if (drpApplicationStatus.SelectedValue == "0")
            {
                WarningAlert("Please select application status");
                return;
            }

            ViewReport();
        }

        private void getApplicationStatus()
        {
            try
            {

                if (lp.getApplicationStatus() != null)
                {
                    ListItem li = new ListItem("Select a status", "0");
                    drpApplicationStatus.DataSource = lp.getApplicationStatus();
                    drpApplicationStatus.DataValueField = "ID";
                    drpApplicationStatus.DataTextField = "Name";
                    drpApplicationStatus.DataBind();
                    drpApplicationStatus.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no statuses", "0");
                    drpApplicationStatus.DataSource = null;
                    drpApplicationStatus.DataBind();
                    drpApplicationStatus.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        protected void WarningAlert(string message)
        {
            string script = $"WarningToastr('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastScript", script, true);
        }
        private void ViewReport()
        {
            myReport = new ReportDocument();
            myReport.Load(Server.MapPath(@"../reports/ApplicationReportByStatus.rpt"));
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


            CrystalDecisions.Shared.ParameterField myParameterField2 = new CrystalDecisions.Shared.ParameterField();
            CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue2 = new CrystalDecisions.Shared.ParameterDiscreteValue();
            myParameterField2.ParameterFieldName = "StatusID";
            myDiscreteValue2.Value = drpApplicationStatus.SelectedValue;
            myParameterField2.CurrentValues.Add(myDiscreteValue2);
            myParameterFields.Add(myParameterField2);

            CrystalDecisions.Shared.ParameterField myParameterField3 = new CrystalDecisions.Shared.ParameterField();
            CrystalDecisions.Shared.ParameterDiscreteValue myDiscreteValue3 = new CrystalDecisions.Shared.ParameterDiscreteValue();
            myParameterField3.ParameterFieldName = "UserID";
            myDiscreteValue3.Value = int.Parse(Session["userid"].ToString());
            myParameterField3.CurrentValues.Add(myDiscreteValue3);
            myParameterFields.Add(myParameterField3);


            ApplicationsReportViewer.ReportSource = myReport;
            ApplicationsReportViewer.ParameterFieldInfo = myParameterFields;
            ApplicationsReportViewer.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;

            Session["ApplicationReport"] = myReport;
        }
    }
}