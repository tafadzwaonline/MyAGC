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
                txtApplicantID.Value = "1";


                if (Request.QueryString["ApplicationID"].ToString() != null)
                {
                    txtApplicationID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ApplicationID"]));
                }
                getApplications();
                getAcademicHistory();
                getCertificateUploads();
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
                //txtApplicantID.Value = 1;
            }
           
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {

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