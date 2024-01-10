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
    public partial class institution_information : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                getCountry();

                getUniversityTypes();

                getInstitutionDetails();


            }
        }
        private void getInstitutionDetails()
        {

            DataSet GetUsers = um.GetSystemUserByUserEmail(Session["username"].ToString());

            if (GetUsers.Tables.Count > 0 && GetUsers.Tables[0].Rows.Count > 0)
            {
                DataRow row = GetUsers.Tables[0].Rows[0];

                txtSchoolName.Text = row["FirstName"].ToString();
               // txtLastName.Text = row["LastName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtAddress.Text = row["Address"].ToString();
                txtMissionStatement.Text = row["MissionStatement"].ToString();
                txtMobile1.Text = row["Mobile"].ToString();
                txtMobile2.Text = row["Tel"].ToString();
                txtWebsiteUrl.Text = row["WebSiteUrl"].ToString();
                txtFacebooklink.Text = row["Facebooklink"].ToString();
                txtTwitterlink.Text = row["TwitterLink"].ToString();
                drpCountry.SelectedValue = row["CountryID"].ToString();
                drpUniversityType.SelectedValue = row["UniversityType"].ToString();



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

        protected void getUniversityTypes()
        {
            try
            {

                if (lp.getUniversityTypes() != null)
                {
                    ListItem li = new ListItem("Select a University Type", "0");
                    drpUniversityType.DataSource = lp.getUniversityTypes();
                    drpUniversityType.DataValueField = "ID";
                    drpUniversityType.DataTextField = "Name";
                    drpUniversityType.DataBind();
                    drpUniversityType.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no University Types", "0");
                    drpUniversityType.DataSource = null;
                    drpUniversityType.DataBind();
                    drpUniversityType.Items.Insert(0, li);
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
                WarningAlert("Please enter First Name");
                return;
            }
    
            if (txtAddress.Text == "")
            {
                WarningAlert("Please enter Residental Address");
                return;
            }
            if (txtMobile1.Text == "")
            {
                WarningAlert("Please enter Mobile");
                return;
            }
            if (drpCountry.SelectedValue == "0")
            {
                WarningAlert("Please select country");
                return;
            }
            if (drpUniversityType.SelectedValue == "0")
            {
                WarningAlert("Please select university type");
                return;
            }


            UpdateDetails();
        }

        private void UpdateDetails()
        {
            try
            {
                um.UpdateInstituionDetails(txtSchoolName.Text,txtEmail.Text,txtMobile1.Text,txtMobile2.Text,txtAddress.Text,int.Parse(drpUniversityType.SelectedValue),int.Parse(drpCountry.SelectedValue),txtMissionStatement.Text,txtWebsiteUrl.Text,txtFacebooklink.Text,txtTwitterlink.Text);

                getInstitutionDetails();
                SuccessAlert("Institution records successfully updated");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}