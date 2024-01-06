using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.student
{
    public partial class academic_history : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                getExamBody();
                getSchoolLevels();
                getYears();
                getMonths();
                getAcademicHistory();


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


        protected void getSchoolLevels()
        {
            try
            {

                if (lp.getSchoolLevel() != null)
                {
                    ListItem li = new ListItem("Select a school level", "0");
                    drpSchoolLevel.DataSource = lp.getSchoolLevel();
                    drpSchoolLevel.DataValueField = "ID";
                    drpSchoolLevel.DataTextField = "Name";
                    drpSchoolLevel.DataBind();
                    drpSchoolLevel.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no school levels", "0");
                    drpSchoolLevel.DataSource = null;
                    drpSchoolLevel.DataBind();
                    drpSchoolLevel.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }

        protected void getExamBody()
        {
            try
            {

                if (lp.getExamBody() != null)
                {
                    ListItem li = new ListItem("Select a examination body", "0");
                    drpExaminationBody.DataSource = lp.getExamBody();
                    drpExaminationBody.DataValueField = "ID";
                    drpExaminationBody.DataTextField = "Name";
                    drpExaminationBody.DataBind();
                    drpExaminationBody.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no examination bodies", "0");
                    drpExaminationBody.DataSource = null;
                    drpExaminationBody.DataBind();
                    drpExaminationBody.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }

     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSchoolName.Text == "")
            {
                WarningAlert("Please enter School Name");
                return;
            }
            if (drpSchoolLevel.SelectedValue == "0")
            {
                WarningAlert("Please select a school level");
                return;
            }

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
            if (txtSubjectsPassed.Text == "")
            {
                WarningAlert("Please enter subjects passed");
                return;
            }
            if (drpExaminationBody.SelectedValue == "0")
            {
                WarningAlert("Please select examination body");
                return;
            }


            UpdateDetails();
        }


        private void getAcademicHistory()
        {
            DataSet dataSet = lp.getAcademicHistory(int.Parse(Session["userid"].ToString()));

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
            txtSchoolName.Text = string.Empty;
            txtActivities.Text = string.Empty;
            txtSubjectsPassed.Text = string.Empty;
            drpSchoolLevel.SelectedValue = "0";
            drpStartDateMonth.SelectedValue = "0";
            drpEndDateMonth.SelectedValue = "0";
            drpStartDateMonth.SelectedValue = "0";
            drpExaminationBody.SelectedValue = "0";
            drpStartDateYear.SelectedValue = "0";
            drpEndDateYear.SelectedValue = "0";
        }

        private void UpdateDetails()
        {
            try
            {

                lp.SaveAcademicRecords(int.Parse(Session["userid"].ToString()),txtSchoolName.Text,int.Parse(drpSchoolLevel.SelectedValue),drpStartDateMonth.SelectedItem.Text,drpStartDateYear.SelectedItem.Text
                    ,drpEndDateMonth.SelectedItem.Text,drpEndDateYear.SelectedItem.Text,int.Parse(txtSubjectsPassed.Text), int.Parse(drpExaminationBody.SelectedValue),txtActivities.Text);

                getAcademicHistory();
                SuccessAlert("User records successfully saved");

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
               
                int index = Convert.ToInt32(e.CommandArgument);
              

                if (e.CommandName == "DeleteItem")
                {

                    lp.RemoveAcademicHistory(index);
                    getAcademicHistory();

                    SuccessAlert("Record successfully removed");
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