using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.agent
{
    public partial class personal_information : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.Parse(Session["roleid"].ToString()) == 4)
                {
                    lblUsername.Text = "Agent Information";
                }
                else
                {
                    lblUsername.Text = "Consultant Company Information";
                }

                getCountry();
                getAgentDetails();


            }
        }
        private void getAgentDetails()
        {

            DataSet GetUsers = um.GetSystemUserByUserEmail(Session["username"].ToString());

            if (GetUsers.Tables.Count > 0 && GetUsers.Tables[0].Rows.Count > 0)
            {
                DataRow row = GetUsers.Tables[0].Rows[0];

                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtAddress.Text = row["Address"].ToString();
                //txtMissionStatement.Text = row["MissionStatement"].ToString();
                txtMobile1.Text = row["Mobile"].ToString();
                drpCountry.SelectedValue = row["CountryID"].ToString();
                //drpUniversityType.SelectedValue = row["UniversityType"].ToString();



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



        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                WarningAlert("Please enter First Name");
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
            if (string.IsNullOrEmpty(txtMobile1.Text))
            {
                WarningAlert("Please enter Mobile");
                return;
            }
            if (drpCountry.SelectedValue == "0")
            {
                WarningAlert("Please select country");
                return;
            }



            UpdateDetails();
        }

        private void UpdateDetails()
        {
            try
            {
                um.InsertAgentDetails(1, int.Parse(Session["userid"].ToString()), txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtMobile1.Text, int.Parse(drpCountry.SelectedValue));

                getAgentDetails();
                SuccessAlert("Agent records successfully updated");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}