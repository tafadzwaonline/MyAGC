using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webdev.Payments;

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

                SaveApplication();
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
            DataSet dataSet = lp.getApplicationFeesByID(int.Parse(txtPeriodID.Value),int.Parse(drpCitizenType.SelectedValue),int.Parse(txtCollegeID.Value));

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
                if (drpPaymentType.SelectedValue == "0")
                {
                    WarningAlert("Please select payment type");
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
        private void SaveApplication()
        {
            try
            {
                //var paynow = new Paynow("15551", "ad6ee0d2-0103-4036-a920-623b5a83f7fa");
                var paynow = new Paynow("15816", "2e98fc93-849c-48d7-9ab1-0a742d679ed2");
                var pollUrl = Session["PollUrl"] as string;
                int userId = int.Parse(Session["userid"].ToString());
                string useremail = Session["username"].ToString();
                int collegeId = int.Parse(txtCollegeID.Value);
                int periodId = int.Parse(txtPeriodID.Value);
                int programId = int.Parse(txtProgramID.Value);
                if (!string.IsNullOrEmpty(pollUrl))
                {
                    // Check the transaction status
                    //var status = paynow.CheckTransactionStatus(pollUrl);
                    var status = paynow.PollTransaction(pollUrl);
                    int paynowreference = 0;
                    if (status.Paid())
                    {
                       

                        foreach (var item in status.GetData())
                        {
                            if (item.Key == "paynowreference")
                            {
                                paynowreference = Convert.ToInt32(item.Value);
                                break;
                            }
                        }

                        //insert payment details
                        lp.SavePayment(userId, collegeId, programId, periodId, useremail,status.Amount, pollUrl, paynowreference);


                        lp.SaveApplication(userId, collegeId, programId, periodId);
                       
                        Session["PollUrl"] = null;
                        Session["TransactionReference"] = null;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application successful, now awaiting confirmation');window.location ='../student/my-applications';", true);
                        //SuccessAlert("Your transaction was successfully paid");
                       
                    }
                    else
                    {

                        WarningAlert("Your transaction was not paid");
                        Session["PollUrl"] = null;
                        Session["TransactionReference"] = null;
                    }

                }
            }
            catch (Exception ex)
            {
                Session["PollUrl"] = null;
                Session["TransactionReference"] = null;
                WarningAlert("An error occured, please try again later");
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

                if (drpPaymentType.SelectedValue == "1")
                {
                    PayNow();
                }
                else
                {
                    UploadPop();
                }


                //
                //var paynow = new Paynow("15551", "ad6ee0d2-0103-4036-a920-623b5a83f7fa");
                //var paynow = new Paynow("15816", "2e98fc93-849c-48d7-9ab1-0a742d679ed2");
                //string EcryptedCollegeID = HttpUtility.UrlEncode(qn.Encrypt(txtCollegeID.Value));
                //string EcryptedPeriodID = HttpUtility.UrlEncode(qn.Encrypt(txtPeriodID.Value));
                //string EcryptedProgramID = HttpUtility.UrlEncode(qn.Encrypt(txtProgramID.Value));
                // Response.Redirect(string.Format("../student/application?ID={0}", EcryptedProgramID), false);
                //Response.Redirect(string.Format("../student/application?CollegeID={0}&PeriodID={1}&ProgramID={2}", EcryptedCollegeID, EcryptedPeriodID, EcryptedProgramID), false);
                //paynow.ReturnUrl = $"https://localhost:44302/student/application?CollegeID={EcryptedCollegeID}&PeriodID={EcryptedPeriodID}&ProgramID={EcryptedProgramID}";
                //paynow.ReturnUrl = $"http://mysystem.ddns.net/MyAGC/student/application?CollegeID={EcryptedCollegeID}&PeriodID={EcryptedPeriodID}&ProgramID={EcryptedProgramID}";

                //paynow.ResultUrl = "http://example.com/gateways/paynow/update";

                //var payment = paynow.CreatePayment("Application Fees");
                //payment.AuthEmail = Session["username"].ToString();
                //// Add items to the payment
                //payment.Add("Application Fees", Convert.ToDecimal(txtApplicationFee.Text));

                //// Send payment to paynow
                //var response = paynow.Send(payment);



                // Check if payment was sent without error
                //if (response.Success())
                //{
                //    // Get the url to redirect the user to so they can make payment
                //    //var link = response.RedirectLink();
                //    //Response.Redirect(string.Format(link));


                //    //System.Diagnostics.Process.Start(link);
                //    // Get the poll url of the transaction
                //    //var pollUrl = response.PollUrl();

                //    //var status = paynow.PollTransaction(pollUrl);
                //    var redirectUrl = response.RedirectLink();

                //    // Store relevant transaction information for later retrieval
                //    Session["TransactionReference"] = payment.Reference;
                //    Session["PollUrl"] = response.PollUrl();

                //    // Redirect the user to Paynow for payment
                //    Response.Redirect(redirectUrl);
                //}


                //lp.SaveApplication(userId, collegeId, programId, periodId);
                //SuccessAlert("Program successfully applied, now awaiting confirmation");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application successful, now awaiting confirmation');window.location ='../student/my-applications';", true);
            }
            catch (Exception)
            {

                
                WarningAlert("An error occurred. Please try again later.");
                return;
            }
        }

        private void UploadPop()
        {
            try
            {
                if (!fileUpload.HasFile)
            {
                WarningAlert("Please select a file to upload");
                return;
            }

            

                string filename = Path.GetFileName(fileUpload.PostedFile.FileName);
                string contentType = fileUpload.PostedFile.ContentType;
                int collegeId = int.Parse(txtCollegeID.Value);
                int periodId = int.Parse(txtPeriodID.Value);
                int programId = int.Parse(txtProgramID.Value);
                using (Stream fs = fileUpload.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                        lp.UploadProofOfPayment(filename, contentType, bytes, DateTime.Today, int.Parse(Session["userid"].ToString()),collegeId,periodId,programId);
                    }
                }

                //Save application


                lp.SaveApplication(int.Parse(Session["userid"].ToString()), collegeId, programId, periodId);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application successful, now awaiting confirmation');window.location ='../student/my-applications';", true);


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void PayNow()
        {
            var paynow = new Paynow("15816", "2e98fc93-849c-48d7-9ab1-0a742d679ed2");
            string EcryptedCollegeID = HttpUtility.UrlEncode(qn.Encrypt(txtCollegeID.Value));
            string EcryptedPeriodID = HttpUtility.UrlEncode(qn.Encrypt(txtPeriodID.Value));
            string EcryptedProgramID = HttpUtility.UrlEncode(qn.Encrypt(txtProgramID.Value));
            // Response.Redirect(string.Format("../student/application?ID={0}", EcryptedProgramID), false);
            //Response.Redirect(string.Format("../student/application?CollegeID={0}&PeriodID={1}&ProgramID={2}", EcryptedCollegeID, EcryptedPeriodID, EcryptedProgramID), false);
            //paynow.ReturnUrl = $"https://localhost:44302/student/application?CollegeID={EcryptedCollegeID}&PeriodID={EcryptedPeriodID}&ProgramID={EcryptedProgramID}";
            paynow.ReturnUrl = $"http://mysystem.ddns.net/MyAGC/student/application?CollegeID={EcryptedCollegeID}&PeriodID={EcryptedPeriodID}&ProgramID={EcryptedProgramID}";

            paynow.ResultUrl = "http://example.com/gateways/paynow/update";

            var payment = paynow.CreatePayment("Application Fees");
            payment.AuthEmail = Session["username"].ToString();
            // Add items to the payment
            payment.Add("Application Fees", Convert.ToDecimal(txtApplicationFee.Text));

            // Send payment to paynow
            var response = paynow.Send(payment);



            // Check if payment was sent without error
            if (response.Success())
            {
                // Get the url to redirect the user to so they can make payment
                //var link = response.RedirectLink();
                //Response.Redirect(string.Format(link));


                //System.Diagnostics.Process.Start(link);
                // Get the poll url of the transaction
                //var pollUrl = response.PollUrl();

                //var status = paynow.PollTransaction(pollUrl);
                var redirectUrl = response.RedirectLink();

                // Store relevant transaction information for later retrieval
                Session["TransactionReference"] = payment.Reference;
                Session["PollUrl"] = response.PollUrl();

                // Redirect the user to Paynow for payment
                Response.Redirect(redirectUrl);
            }
        }

        protected void drpPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpPaymentType.SelectedValue == "1" || drpPaymentType.SelectedValue == "0")
            {
                up.Visible= false;
            }
            else
            {
                up.Visible = true;
            }
        }
    }
}