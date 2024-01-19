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
    public partial class application : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCollegeID.Value = "0";
                txtPeriodID.Value = "0";
                txtProgramID.Value = "0";
                if (Request.QueryString["CollegeID"].ToString() != null)
                {
                    txtCollegeID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["CollegeID"]));
                }
                if (Request.QueryString["PeriodID"].ToString() != null)
                {
                    txtPeriodID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["PeriodID"]));
                }
                if (Request.QueryString["ProgramID"].ToString() != null)
                {
                    txtProgramID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ProgramID"]));
                }

                getCitizenTypes();

                getSavedPrograms();
                ApplicationDate();
                getSavedAcademicPeriod();
            }
        }
        private void getSavedPrograms()
        {
            DataSet dataSet = lp.getProgramsByID(int.Parse(txtProgramID.Value));

            if (dataSet != null)
            {
                DataRow dr = dataSet.Tables[0].Rows[0];
                txtProgram.Text = dr["ProgramName"].ToString();
                txtRequirements.Text = dr["Requirements"].ToString();
                txtDuration.Text = dr["Duration"].ToString();
                txtFaculty.Text = dr["FacultyName"].ToString();
                txtTuition.Text = dr["Tuition"].ToString();
            }
           
        }
        private void getSavedAcademicPeriod()
        {
           
            DataSet dataSet = lp.getAcademicCalendarByID(int.Parse(txtPeriodID.Value));

            if (dataSet != null)
            {
                DataRow dr = dataSet.Tables[0].Rows[0];
                txtPeriod.Text = dr["Period"].ToString();
                txtApplicationDeadline.Text = dr["ApplicationDeadline"].ToString();
                txtIntake.Text = dr["Name"].ToString();
                
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
        private void ApplicationDate()
        {
            DateTime dt = DateTime.Now;
            txtApplicationDate.Text = dt.ToString("yyyy-MM-dd");
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
            DataSet dataSet = lp.getApplicationFeesByID(int.Parse(drpCitizenType.SelectedValue));

            if (dataSet != null)
            {
                DataRow dt = dataSet.Tables[0].Rows[0];
                txtApplicationFee.Text = dt["Amount"].ToString();
            }
            
        }
        
        protected void drpCitizenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSavedApplicationFees();
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if user information is complete
                DataSet userDataSet = um.GetSystemUserByUserEmail(Session["username"].ToString());
                if (userDataSet != null)
                {
                    DataRow userRow = userDataSet.Tables[0].Rows[0];
                    if (string.IsNullOrEmpty(userRow["GenderID"].ToString()) ||
                        string.IsNullOrEmpty(userRow["CountryID"].ToString()) ||
                        string.IsNullOrEmpty(userRow["IdentityNumber"].ToString()) ||
                        string.IsNullOrEmpty(userRow["NextKinFullName"].ToString()))
                    {
                        WarningAlert("Please complete your personal information before proceeding");
                        return;
                    }
                }

                // Check if certificate is uploaded
                DataSet certificateDataSet = lp.getCertificateFileUploads(int.Parse(Session["userid"].ToString()));
                if (certificateDataSet == null)
                {
                    WarningAlert("Please upload your certificate before proceeding");
                    return;
                }

                // Check if academic records are entered
                DataSet academicDataSet = lp.getAcademicHistory(int.Parse(Session["userid"].ToString()));
                if (academicDataSet == null)
                {
                    WarningAlert("Please enter your academic records before proceeding");
                    return;
                }

                // Check application deadline
                DateTime applicationDate = Convert.ToDateTime(txtApplicationDate.Text);
                DateTime applicationDeadline = Convert.ToDateTime(txtApplicationDeadline.Text);
                if (applicationDate > applicationDeadline)
                {
                    WarningAlert("Application deadline for the program has passed");
                    return;
                }

                // Check citizen type selection
                if (drpCitizenType.SelectedValue == "0")
                {
                    WarningAlert("Please select citizen type");
                    return;
                }

                // Check application fee entry
                if (string.IsNullOrEmpty(txtApplicationFee.Text))
                {
                    WarningAlert("Please enter application fee");
                    return;
                }

                // If all checks pass, proceed to save
                Save();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur
                //LogException(ex);
                WarningAlert("An error occurred. Please try again later.");
                return;
            }
        }


        private void Save()
        {
            try
            {
                //validate apply for only 3 programs per period
                //validate cannot apply same program twice
                int userId = int.Parse(Session["userid"].ToString());
                int collegeId = int.Parse(txtCollegeID.Value);
                int periodId = int.Parse(txtPeriodID.Value);
                int programId = int.Parse(txtProgramID.Value);

                // Retrieve student applications dataset
                DataSet applicationsDataSet = lp.getStudentApplications(userId, collegeId, periodId);

                // Check if dataset is not null and has rows
                if (applicationsDataSet?.Tables.Count > 0 && applicationsDataSet.Tables[0].Rows.Count > 0)
                {
                    int applicationCount = applicationsDataSet.Tables[0].Rows.Count;

                    // Check if the application count exceeds the limit
                    if (applicationCount > 3)
                    {
                        WarningAlert("Applicant is only allowed 3 applications per period");
                        return;
                    }
                }

                
                if (lp.IsProgramApplied(userId, collegeId, periodId, programId))
                {
                    WarningAlert("Program already applied");
                    return;
                }


                lp.SaveApplication(userId, collegeId, programId, periodId);
                //SuccessAlert("Program successfully applied, now awaiting confirmation");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application successful, now awaiting confirmation');window.location ='../student/my-applications';", true);
            }
            catch (Exception)
            {

                
                WarningAlert("An error occurred. Please try again later.");
                return;
            }
        }
    }
}