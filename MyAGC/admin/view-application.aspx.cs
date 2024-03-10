using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.admin
{
    public partial class view_application : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtApplicationID.Value = "0";
                txtApplicantID.Value = "0";
                txtPeriodID.Value = "0";
                txtProgramID.Value = "0";
                txtCollegeID.Value = "0";

                if (Request.QueryString["ApplicationID"].ToString() != null)
                {
                    txtApplicationID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ApplicationID"]));
                }
                getApplications();
                getLetters();
                geApplicantPOPUploads();
            }


        }
        private void getAcademicHistory()
        {
            DataSet dataSet = lp.getAcademicHistory(int.Parse(txtApplicantID.Value));

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
        private void getCertificateUploads()
        {
            DataSet x = lp.getCertificateFileUploads(int.Parse(txtApplicantID.Value));
            if (x != null)
            {
                grdDocument.DataSource = x;
                grdDocument.DataBind();
            }
            else
            {
                grdDocument.DataSource = null;
                grdDocument.DataBind();
                //ltEmbed.Text = null;
            }
        }
        private void getApplications()
        {
            DataSet dataSet = lp.getStudentApplicationByID(int.Parse(txtApplicationID.Value));

            if (dataSet != null)
            {
                DataRow dt = dataSet.Tables[0].Rows[0];

                DateTime dat = Convert.ToDateTime(dt["DOB"].ToString());
                string dats = dat.ToString("yyyy-MM-dd");

                txtApplicantName.Text = dt["ApplicantName"].ToString();
                txtApplicantEmail.Text = dt["Email"].ToString();
                txtApplicantAddress.Text = dt["Address"].ToString();
                txtApplicantDOB.Text = dats;
                txtApplicantDocumentType.Text = dt["IdentityDocument"].ToString();
                txtApplicantIdentityNumber.Text = dt["IdentityNumber"].ToString();
                txtCollegeName.Text = dt["College"].ToString();
                txtProgramName.Text = dt["ProgramName"].ToString();
                txtDuration.Text = dt["Duration"].ToString();
                txtRequirements.Text = dt["Requirements"].ToString();
                txtPeriod.Text = dt["Period"].ToString();
                txtApplicationStatus.Text = dt["Status"].ToString();
                txtApplicantMobile.Text = dt["Mobile"].ToString();
                txtApplicantID.Value = dt["ApplicantID"].ToString();
                txtPeriodID.Value = dt["PeriodID"].ToString();
                txtProgramID.Value = dt["ProgramID"].ToString();
                txtCollegeID.Value = dt["CollegeID"].ToString();

                if (txtApplicationStatus.Text.ToLower() == "pending")
                {
                    butt.Visible = true;
                    upp.Visible = false;
                    ub.Visible = false;
                    letter.Visible = false;

                }
                else if (txtApplicationStatus.Text.ToLower() == "accepted")
                {
                    upp.Visible = true;
                    ub.Visible = true;
                    butt.Visible = false;
                    letter.Visible = true;
                }
                else
                {

                    butt.Visible = false;
                    upp.Visible = false;
                    ub.Visible = false;
                    letter.Visible = false;

                }
            }


            getAcademicHistory();
            getCertificateUploads();


        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            lp.ApproveApplication(int.Parse(txtApplicationID.Value));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application successful approved');window.location ='../institution/accepted-applications';", true);

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            lp.RejectApplication(int.Parse(txtApplicationID.Value));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application successful rejected');window.location ='../institution/rejected-applications';", true);

        }
        protected void downloadLetter(int AppID)
        {

            byte[] bytes = null;
            string fileName = null;
            string contentType = null;
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DownloadLetter", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppID", AppID);

                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["FileName"].ToString();
                        }
                        else
                        {
                            bytes = null;
                            contentType = null;
                            fileName = string.Empty;
                        }
                    }
                }

                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", "attachment;filename=\"" + fileName + "");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
        protected void download(int AppID)
        {

            byte[] bytes = null;
            string fileName = null;
            string contentType = null;
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetFileData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppID", AppID);

                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["Name"].ToString();
                        }
                        else
                        {
                            bytes = null;
                            contentType = null;
                            fileName = string.Empty;
                        }
                    }
                }

                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", "attachment;filename=\"" + fileName + "");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
        protected void grdDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index = Convert.ToInt32(e.CommandArgument);

                download(index);

            }
            catch (Exception ex)
            {

                throw;
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
            if (!fileUpload.HasFile)
            {
                WarningAlert("Please select a certificate to upload");
                return;
            }



            UpdateDetails();
        }

        private void UpdateDetails()
        {
            try
            {

                string filename = Path.GetFileName(fileUpload.PostedFile.FileName);
                string contentType = fileUpload.PostedFile.ContentType;
                //int DocTypeID = int.Parse(drpDocumentType.SelectedValue);
                using (Stream fs = fileUpload.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                        lp.UploadAcceptanceLetter(int.Parse(txtApplicationID.Value), filename, contentType, bytes, int.Parse(txtCollegeID.Value), int.Parse(txtApplicantID.Value), int.Parse(txtPeriodID.Value), int.Parse(txtProgramID.Value));
                    }
                }
                //getDocumentUploads();
                getLetters();
                SuccessAlert("Letter successfully uploaded");

                //Clear();
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void getLetters()
        {
            DataSet x = lp.getAcceptanceLettersByApplicationID(int.Parse(txtApplicationID.Value));
            if (x != null)
            {
                grdAcceptanceLetter.DataSource = x;
                grdAcceptanceLetter.DataBind();
            }
            else
            {
                grdAcceptanceLetter.DataSource = null;
                grdAcceptanceLetter.DataBind();
                //ltEmbed.Text = null;
            }
        }
        protected void grdAcceptanceLetter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index = Convert.ToInt32(e.CommandArgument);

                downloadLetter(index);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void grdPop_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index;
                if (e.CommandName == "selectrecord")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    downloadpop(index);
                }
                if (e.CommandName == "deleterecord")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    lp.DeletePOP(index);
                    geApplicantPOPUploads();
                    SuccessAlert("POP successfully deleted");
                }

            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
            }
        }

        protected void grdPop_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDocument.PageIndex = e.NewPageIndex;
            this.BindPopGrid(e.NewPageIndex);
        }
        private void geApplicantPOPUploads()
        {
            DataSet x = lp.getStudentPopByProgram(int.Parse(txtApplicantID.Value), int.Parse(txtCollegeID.Value), int.Parse(txtProgramID.Value));
            if (x != null)
            {
                pop.Visible = true;
                grdPop.DataSource = x;
                grdPop.DataBind();
            }
            else
            {
                pop.Visible = false;
                grdPop.DataSource = null;
                grdPop.DataBind();
                //ltEmbed.Text = null;
            }
        }
        protected void downloadpop(int AppID)
        {

            byte[] bytes = null;
            string fileName = null;
            string contentType = null;
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetPop", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppID", AppID);

                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["Name"].ToString();
                        }
                        else
                        {
                            bytes = null;
                            contentType = null;
                            fileName = string.Empty;
                        }
                    }
                }

                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", "attachment;filename=\"" + fileName + "");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
        private void BindPopGrid(int page = 0)
        {
            try
            {

                DataSet user = lp.getStudentPopByProgram(int.Parse(txtApplicantID.Value), int.Parse(txtCollegeID.Value), int.Parse(txtProgramID.Value));
                if (user != null)
                {
                    int maxPageIndex = grdDocument.PageCount - 1;
                    if (page < 0 || page > maxPageIndex)
                    {
                        if (maxPageIndex >= 0)
                        {
                            // Navigate to the last available page
                            page = maxPageIndex;
                        }
                        else
                        {
                            // No data available, reset to the first page
                            page = 0;
                        }
                    }
                    grdPop.DataSource = user;
                    grdPop.PageIndex = page;
                    grdPop.DataBind();
                }
                else
                {
                    grdPop.DataSource = null;
                    grdPop.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert(ex.ToString());
            }
        }
    }
}