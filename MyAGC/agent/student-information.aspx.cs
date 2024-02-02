using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webdev.Payments;

namespace MyAGC.agent
{
    public partial class student_information : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtID.Value = "0";
                txtCollegeID.Value = "0";
                txtPeriodID.Value = "0";

                txtProgramID.Value = "0";
                if (Request.QueryString["CollegeID"].ToString() != null)
                {
                    txtCollegeID.Value = Request.QueryString["CollegeID"].ToString();
                }
                if (Request.QueryString["PeriodID"].ToString() != null)
                {
                    txtPeriodID.Value = Request.QueryString["PeriodID"].ToString();
                }
                if (Request.QueryString["ProgramID"].ToString() != null)
                {
                    txtProgramID.Value = Request.QueryString["ProgramID"].ToString();
                }
                getCountry();
                //getRelationTypes();
                getGender();
                getDisabilityTypes();
                getRaces();
                getReligion();
                getIdentityDocumentTypes();
                getTitle();
                //getUserDetails();


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
        protected void getCountry()
        {
            try
            {

                if (lp.getCountry() != null)
                {
                    ListItem li = new ListItem("Select a country", "0");
                    drpCountry.DataSource = lp.getCountry();
                    drpCountry.DataValueField = "ID";
                    drpCountry.DataTextField = "CountryName";
                    drpCountry.DataBind();
                    drpCountry.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no countries", "0");
                    drpCountry.DataSource = null;
                    drpCountry.DataBind();
                    drpCountry.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        protected void getGender()
        {
            try
            {

                if (lp.getGender() != null)
                {
                    ListItem li = new ListItem("Select a gender", "0");
                    DrpGender.DataSource = lp.getGender();
                    DrpGender.DataValueField = "ID";
                    DrpGender.DataTextField = "Name";
                    DrpGender.DataBind();
                    DrpGender.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no genders", "0");
                    DrpGender.DataSource = null;
                    DrpGender.DataBind();
                    DrpGender.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        //protected void getRelationTypes()
        //{
        //    try
        //    {

        //        if (lp.getRelationTypes() != null)
        //        {
        //            ListItem li = new ListItem("Select a relation", "0");
        //            drpRelationType.DataSource = lp.getRelationTypes();
        //            drpRelationType.DataValueField = "ID";
        //            drpRelationType.DataTextField = "Description";
        //            drpRelationType.DataBind();
        //            drpRelationType.Items.Insert(0, li);
        //        }
        //        else
        //        {
        //            ListItem li = new ListItem("There are no relations", "0");
        //            drpRelationType.DataSource = null;
        //            drpRelationType.DataBind();
        //            drpRelationType.Items.Insert(0, li);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //DangerAlert(ex.Message);
        //    }
        //}

        protected void getDisabilityTypes()
        {
            try
            {

                if (lp.getDisabilityTypes() != null)
                {
                    ListItem li = new ListItem("Select a disability type", "0");
                    drpDisabilitype.DataSource = lp.getDisabilityTypes();
                    drpDisabilitype.DataValueField = "ID";
                    drpDisabilitype.DataTextField = "Name";
                    drpDisabilitype.DataBind();
                    drpDisabilitype.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no disability types", "0");
                    drpDisabilitype.DataSource = null;
                    drpDisabilitype.DataBind();
                    drpDisabilitype.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }

        protected void getReligion()
        {
            try
            {

                if (lp.getReligion() != null)
                {
                    ListItem li = new ListItem("Select a religion", "0");
                    drpReligion.DataSource = lp.getReligion();
                    drpReligion.DataValueField = "ID";
                    drpReligion.DataTextField = "Name";
                    drpReligion.DataBind();
                    drpReligion.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no religions", "0");
                    drpReligion.DataSource = null;
                    drpReligion.DataBind();
                    drpReligion.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        protected void getTitle()
        {
            try
            {

                if (lp.getTitle() != null)
                {
                    ListItem li = new ListItem("Select a title", "0");
                    drpTitle.DataSource = lp.getTitle();
                    drpTitle.DataValueField = "ID";
                    drpTitle.DataTextField = "Name";
                    drpTitle.DataBind();
                    drpTitle.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no titles", "0");
                    drpTitle.DataSource = null;
                    drpTitle.DataBind();
                    drpTitle.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        protected void getIdentityDocumentTypes()
        {
            try
            {

                if (lp.getIdentityDocumentTypes() != null)
                {
                    ListItem li = new ListItem("Select a Identity Type", "0");
                    drpIdentityDocument.DataSource = lp.getIdentityDocumentTypes();
                    drpIdentityDocument.DataValueField = "ID";
                    drpIdentityDocument.DataTextField = "IdentityDocument";
                    drpIdentityDocument.DataBind();
                    drpIdentityDocument.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Identity Types", "0");
                    drpIdentityDocument.DataSource = null;
                    drpIdentityDocument.DataBind();
                    drpIdentityDocument.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        protected void getRaces()
        {
            try
            {

                if (lp.getRaces() != null)
                {
                    ListItem li = new ListItem("Select a race", "0");
                    drpRace.DataSource = lp.getRaces();
                    drpRace.DataValueField = "ID";
                    drpRace.DataTextField = "RoleName";
                    drpRace.DataBind();
                    drpRace.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no races", "0");
                    drpRace.DataSource = null;
                    drpRace.DataBind();
                    drpRace.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                WarningAlert("Please enter First Name");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                WarningAlert("Please enter email");
                return;
            }
            if (txtEmail.Text.Contains("'"))
            {
                txtEmail.Text = txtEmail.Text.Replace("'", "");
            }
           
            if (!txtEmail.Text.Contains("@"))
            {
                WarningAlert("Please enter valid email");
                return;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                WarningAlert("Please enter Last Name");
                return;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                WarningAlert("Please enter Residental Address");
                return;
            }
            if (string.IsNullOrEmpty(txtMobile.Text))
            {
                WarningAlert("Please enter Mobile");
                return;
            }
            if (string.IsNullOrEmpty(txtDob.Text))
            {
                WarningAlert("Please enter Date Of Birth");
                return;
            }


            if (drpIdentityDocument.SelectedValue == "0")
            {
                WarningAlert("Please select identity document type");
                return;
            }

            if (string.IsNullOrEmpty(txtIdentityNumber.Text))
            {
                WarningAlert("Please enter identity number");
                return;
            }

            if (drpCountry.SelectedValue == "0")
            {
                WarningAlert("Please select country");
                return;
            }
            if (DrpGender.SelectedValue == "0")
            {
                WarningAlert("Please select gender");
                return;
            }

            if (drpRace.SelectedValue == "0")
            {
                WarningAlert("Please select race");
                return;
            }
            if (drpReligion.SelectedValue == "0")
            {
                WarningAlert("Please select religion");
                return;
            }

            if (drpTitle.SelectedValue == "0")
            {
                WarningAlert("Please select title");
                return;
            }
            if (drpDisabilitype.SelectedValue == "0")
            {
                WarningAlert("Please select disability type");
                return;
            }
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
            if (um.CheckEmailExists(txtEmail.Text))
            {
                WarningAlert("Email already exists");
                return;
            }

            UpdateDetails();
            UploadFiles();
            Response.Redirect(string.Format("../agent/application?CollegeID=" + txtCollegeID.Value + "&ProgramID=" + txtProgramID.Value + "&PeriodID=" + txtPeriodID.Value + "&StudentID=" + txtID.Value + ""));

        }
        private void UploadFiles()
        {
            try
            {
              
                DataSet ds = lp.getSystemUserByEmail(txtEmail.Text);
                if(ds != null)
                {
                    DataRow dt = ds.Tables[0].Rows[0];
                    txtID.Value = dt["UserID"].ToString();
                }

                string filename = Path.GetFileName(fileUpload.PostedFile.FileName);
                string contentType = fileUpload.PostedFile.ContentType;
                int DocTypeID = int.Parse(drpDocumentType.SelectedValue);
                using (Stream fs = fileUpload.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                        lp.UploadDocument(filename, contentType, bytes, DateTime.Today, int.Parse(txtID.Value), DocTypeID);

                    }
                }
               
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void UpdateDetails()
        {
            try
            {
                //EncryptDecryptClass encryptDecrypt = new EncryptDecryptClass();
                string encryptedPassword = "";
                um.SaveAccount(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtMobile.Text, encryptedPassword, txtAddress.Text, Convert.ToDateTime(txtDob.Text), 3);

                um.UpdateUserDetails(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtMobile.Text, txtAddress.Text, Convert.ToDateTime(txtDob.Text),
                    int.Parse(DrpGender.SelectedValue), int.Parse(drpCountry.SelectedValue), int.Parse(drpRace.SelectedValue), int.Parse(drpReligion.SelectedValue),
                    int.Parse(drpTitle.SelectedValue), int.Parse(drpDisabilitype.SelectedValue),0, int.Parse(drpIdentityDocument.SelectedValue),
                    "", "", "", txtIdentityNumber.Text);


               
                //getUserDetails();
                SuccessAlert("User records successfully updated");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}