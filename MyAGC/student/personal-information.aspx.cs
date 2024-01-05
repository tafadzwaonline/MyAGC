using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.student
{
    public partial class personal_information : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                
                getCountry();
                getRelationTypes();
                getGender();
                getDisabilityTypes();
                getRaces();
                getReligion();
                getIdentityDocumentTypes();
                getTitle();
                getUserDetails();


            }
        }
        private void getUserDetails()
        {

            DataSet GetUsers = um.GetSystemUserByUserEmail(Session["username"].ToString());

            if (GetUsers.Tables.Count > 0 && GetUsers.Tables[0].Rows.Count > 0)
            {
                DataRow row = GetUsers.Tables[0].Rows[0];

                DateTime dt = Convert.ToDateTime(row["DOB"].ToString());
                string dts = dt.ToString("yyyy-dd-MM");


                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtAddress.Text = row["Address"].ToString();
                txtMobile.Text = row["Mobile"].ToString();
                txtDob.Text = dts;
                DrpGender.SelectedValue = row["GenderID"].ToString();
                drpCountry.SelectedValue = row["CountryID"].ToString();
                drpRace.SelectedValue = row["RaceID"].ToString();
                drpReligion.SelectedValue = row["ReligionID"].ToString();
                drpTitle.SelectedValue = row["TitleID"].ToString();
                drpDisabilitype.SelectedValue = row["DisabilityID"].ToString();
                drpRelationType.SelectedValue = row["NextKinRelationID"].ToString();
                drpIdentityDocument.SelectedValue = row["IdentityDocumentTypeID"].ToString();

                txtIdentityNumber.Text = row["IdentityNumber"].ToString();
                txtKinNames.Text = row["NextKinFullName"].ToString();
                txtKinMobile.Text = row["NextKinMobile"].ToString();
                txtKinAddress.Text = row["NextKinAddress"].ToString();
                

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
        protected void getRelationTypes()
        {
            try
            {

                if (lp.getRelationTypes() != null)
                {
                    ListItem li = new ListItem("Select a relation", "0");
                    drpRelationType.DataSource = lp.getRelationTypes();
                    drpRelationType.DataValueField = "ID";
                    drpRelationType.DataTextField = "Description";
                    drpRelationType.DataBind();
                    drpRelationType.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no relations", "0");
                    drpRelationType.DataSource = null;
                    drpRelationType.DataBind();
                    drpRelationType.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }

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
            if (txtFirstName.Text == "")
            {
                WarningAlert("Please enter First Name");
                return;
            }
            if (txtLastName.Text == "")
            {
                WarningAlert("Please enter Last Name");
                return;
            }
            if (txtAddress.Text == "")
            {
                WarningAlert("Please enter Residental Address");
                return;
            }
            if (txtMobile.Text == "")
            {
                WarningAlert("Please enter Mobile");
                return;
            }
            if (txtDob.Text == "")
            {
                WarningAlert("Please enter Date Of Birth");
                return;
            }


            if (drpIdentityDocument.SelectedValue == "0")
            {
                WarningAlert("Please select identity document type");
                return;
            }

            if (txtIdentityNumber.Text == "")
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

            if (txtKinNames.Text == "")
            {
                WarningAlert("Please enter Next Of Kin Names");
                return;
            }
            if (txtKinMobile.Text == "")
            {
                WarningAlert("Please enter Next Of Kin Mobile");
                return;
            }
            if (txtKinAddress.Text == "")
            {
                WarningAlert("Please enter Next Of Kin Address");
                return;
            }

            if (drpRelationType.SelectedValue == "0")
            {
                WarningAlert("Please select Next Of Kin Relationship");
                return;
            }

            UpdateDetails();
        }

        private void UpdateDetails()
        {
            try
            {
                um.UpdateUserDetails(txtFirstName.Text,txtLastName.Text,txtEmail.Text,txtMobile.Text,txtAddress.Text,Convert.ToDateTime(txtDob.Text),
                    int.Parse(DrpGender.SelectedValue), int.Parse(drpCountry.SelectedValue), int.Parse(drpRace.SelectedValue), int.Parse(drpReligion.SelectedValue),
                    int.Parse(drpTitle.SelectedValue), int.Parse(drpDisabilitype.SelectedValue), int.Parse(drpRelationType.SelectedValue), int.Parse(drpIdentityDocument.SelectedValue),
                    txtKinNames.Text,txtKinMobile.Text,txtKinAddress.Text,txtIdentityNumber.Text);

                getUserDetails();
                SuccessAlert("User records successfully updated");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}