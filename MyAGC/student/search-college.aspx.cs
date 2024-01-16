using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.student
{
    public partial class search_college : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getFaculty();
                getSavedColleges();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (drpSearchBy.SelectedValue == "1")
            {
                WarningAlert("Please select a value to search by");
                return;
            }

            if (txtValue.Text == "")
            {
                WarningAlert("Please enter search value");
                return;
            }



            Search();
        }
        private void getSavedColleges()
        {
            
            DataSet getsearchdata = um.GetSystemUserByUserRole(2);
            if (getsearchdata != null)
            {
                grdCollege.DataSource = getsearchdata;
                grdCollege.DataBind();
            }
            else
            {
                grdCollege.DataSource = null;
                grdCollege.DataBind();
            }
        }

        private void Search()
        {
            
            DataSet getsearchdata = lp.getSearchColleges(int.Parse(drpSearchBy.SelectedValue),txtValue.Text);
            if (getsearchdata != null)
            {
                grdCollege.DataSource = getsearchdata;
                grdCollege.DataBind();
            }
            else
            {
                grdCollege.DataSource = null;
                grdCollege.DataBind();
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

        protected void grdCollege_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void grdCollege_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            QueryStringModule qn = new QueryStringModule();
            string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString().Trim()));
            Response.Redirect(string.Format("../student/academic-calander.aspx?collegeID={0}", EcryptedID), false);
        }
    }
}