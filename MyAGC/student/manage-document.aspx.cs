using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.student
{
    public partial class manage_document : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                getcertificate();
                getCertificateUploads();


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
     


        protected void getcertificate()
        {
            try
            {

                if (lp.getCertificates() != null)
                {
                    ListItem li = new ListItem("Select a certificate", "0");
                    drpDocumentType.DataSource = lp.getCertificates();
                    drpDocumentType.DataValueField = "ID";
                    drpDocumentType.DataTextField = "Name";
                    drpDocumentType.DataBind();
                    drpDocumentType.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no certificates", "0");
                    drpDocumentType.DataSource = null;
                    drpDocumentType.DataBind();
                    drpDocumentType.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!fileUpload.HasFile)
            {
                WarningAlert("Please select a certificate to upload");
                return;
            }

            if (drpDocumentType.SelectedValue == "0")
            {
                WarningAlert("Please select a valid certificate");
                return;
            }


            UpdateDetails();
        }


        private void getCertificateUploads()
        {
            DataSet x = lp.getCertificateFileUploads(int.Parse(Session["userid"].ToString()));
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


        private void Clear()
        {
            drpDocumentType.SelectedValue = "0";
         
        }

        private void UpdateDetails()
        {
            try
            {

                string filename = Path.GetFileName(fileUpload.PostedFile.FileName);
                string contentType = fileUpload.PostedFile.ContentType;
                int DocTypeID = int.Parse(drpDocumentType.SelectedValue);
                using (Stream fs = fileUpload.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                        lp.UploadDocument(filename, contentType, bytes, DateTime.Today, int.Parse(Session["userid"].ToString()), DocTypeID);

                    }
                }
                getCertificateUploads();
                SuccessAlert("Document successfully uploaded");

                Clear();
            }
            catch (Exception)
            {

                throw;
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


                if (e.CommandName == "DeleteItem")
                {

                    lp.DeleteUploadedDocument(index);
                    getCertificateUploads();

                    SuccessAlert("Record successfully removed");
                }
                else
                {
                    
                    download(index);
                }

            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
            }
        }
    }
}