using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.institution
{
    public partial class view_application : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCollegeID.Value = Session["userid"].ToString();
                txtApplicationID.Value = "0";
                txtApplicantID.Value = "0";


                if (Request.QueryString["ApplicationID"].ToString() != null)
                {
                    txtApplicationID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ApplicationID"]));
                }
                getApplications();
                
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

                if (txtApplicationStatus.Text.ToLower() == "pending")
                {
                    butt.Visible = true;

                }
                else 
                { 
                    butt.Visible = false; 
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
    }
}