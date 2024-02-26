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
    public partial class academic_calendar : System.Web.UI.Page
    {
        //private readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


               
                getYears();
                getMonths();
                getIntake();
                getAcademicCalendar();


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
        protected void getMonths()
        {
            try
            {
                if (lp.getMonths() != null)
                {
                    ListItem li = new ListItem("Select a month", "0");
                    drpStartDateMonth.DataSource = lp.getMonths();
                    drpStartDateMonth.DataValueField = "ID";
                    drpStartDateMonth.DataTextField = "Name";
                    drpStartDateMonth.DataBind();
                    drpStartDateMonth.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no months", "0");
                    drpStartDateMonth.DataSource = null;
                    drpStartDateMonth.DataBind();
                    drpStartDateMonth.Items.Insert(0, li);
                }

                if (lp.getMonths() != null)
                {
                    ListItem li = new ListItem("Select a month", "0");
                    drpEndDateMonth.DataSource = lp.getMonths();
                    drpEndDateMonth.DataValueField = "ID";
                    drpEndDateMonth.DataTextField = "Name";
                    drpEndDateMonth.DataBind();
                    drpEndDateMonth.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no months", "0");
                    drpEndDateMonth.DataSource = null;
                    drpEndDateMonth.DataBind();
                    drpEndDateMonth.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        protected void getIntake()
        {
            try
            {

               

                if (lp.getIntakes() != null)
                {
                    ListItem li = new ListItem("Select a Intake", "0");
                    drpIntake.DataSource = lp.getIntakes();
                    drpIntake.DataValueField = "ID";
                    drpIntake.DataTextField = "Name";
                    drpIntake.DataBind();
                    drpIntake.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Intakes", "0");
                    drpIntake.DataSource = null;
                    drpIntake.DataBind();
                    drpIntake.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        protected void getYears()
        {
            try
            {

                if (lp.getYears() != null)
                {
                    ListItem li = new ListItem("Select a year", "0");
                    drpStartDateYear.DataSource = lp.getYears();
                    drpStartDateYear.DataValueField = "ID";
                    drpStartDateYear.DataTextField = "Name";
                    drpStartDateYear.DataBind();
                    drpStartDateYear.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no year", "0");
                    drpStartDateYear.DataSource = null;
                    drpStartDateYear.DataBind();
                    drpStartDateYear.Items.Insert(0, li);
                }

                if (lp.getYears() != null)
                {
                    ListItem li = new ListItem("Select a year", "0");
                    drpEndDateYear.DataSource = lp.getYears();
                    drpEndDateYear.DataValueField = "ID";
                    drpEndDateYear.DataTextField = "Name";
                    drpEndDateYear.DataBind();
                    drpEndDateYear.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no year", "0");
                    drpEndDateYear.DataSource = null;
                    drpEndDateYear.DataBind();
                    drpEndDateYear.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
          

            if (drpStartDateMonth.SelectedValue == "0")
            {
                WarningAlert("Please select start month");
                return;
            }
            if (drpStartDateYear.SelectedValue == "0")
            {
                WarningAlert("Please select start year");
                return;
            }
            if (drpEndDateMonth.SelectedValue == "0")
            {
                WarningAlert("Please select end month");
                return;
            }
            if (drpEndDateYear.SelectedValue == "0")
            {
                WarningAlert("Please select end year");
                return;
            }
            if (drpIntake.SelectedValue == "0")
            {
                WarningAlert("Please select Intake");
                return;
            }
            if (txtApplicationDeadline.Text == "")
            {
                WarningAlert("Please select Intake");
                return;
            }
            if (int.Parse(drpStartDateYear.SelectedValue) > int.Parse(drpEndDateYear.SelectedValue))
            {
                WarningAlert("Start year cannot be greater than end year");
                return;
            }

           
            UpdateDetails();
        }


        private void getAcademicCalendar()
        {
            DataSet dataSet = lp.getAcademicCalendar(int.Parse(Session["userid"].ToString()));

            if (dataSet != null)
            {
                grdAcademicHistory.DataSource = dataSet;
                grdAcademicHistory.DataBind();
            }
            else
            {
                grdAcademicHistory.DataSource = null;
                grdAcademicHistory.DataBind();
            }
        }


        private void Clear()
        {
         
            drpStartDateMonth.SelectedValue = "0";
            drpEndDateMonth.SelectedValue = "0";
            drpStartDateMonth.SelectedValue = "0";
            drpIntake.SelectedValue = "0";
            drpStartDateYear.SelectedValue = "0";
            drpEndDateYear.SelectedValue = "0";
            txtApplicationDeadline.Text = string.Empty;
        }

        private void UpdateDetails()
        {
            try
            {

                lp.SaveAcademicCalendar(int.Parse(Session["userid"].ToString()), drpStartDateMonth.SelectedItem.Text, drpStartDateYear.SelectedItem.Text
                    , drpEndDateMonth.SelectedItem.Text, drpEndDateYear.SelectedItem.Text,int.Parse(drpIntake.SelectedValue),Convert.ToDateTime(txtApplicationDeadline.Text));

                getAcademicCalendar();
                SuccessAlert("Instituion records successfully saved");

                Clear();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void grdAcademicHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                QueryStringModule qn = new QueryStringModule();
                int index = Convert.ToInt32(e.CommandArgument);


                if (e.CommandName == "DeleteItem")
                {

                    lp.RemoveAcademicCalendar(index);
                    getAcademicCalendar();

                    SuccessAlert("Record successfully removed");
                }
                if (e.CommandName == "SelectItem")
                {

                    string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    Response.Redirect(string.Format("../institution/application-fee?ID={0}", EcryptedID), false);
                }

            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
            }
        }

        protected void grdAcademicHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}