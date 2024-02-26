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

            if (drpSearchBy.SelectedValue == "1")
            {
                WarningAlert("Please select a criteria to search");
                return;
            }
            if (string.IsNullOrEmpty(txtValue.Text))
            {
                WarningAlert("Please enter search value");
                return;
            }

            DataSet getsearchdata = lp.getSearchUsers(int.Parse(drpSearchBy.SelectedValue), 2, txtValue.Text);
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



        protected void grdCollege_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            if (e.CommandName == "SelectItem")
            {
                index = Convert.ToInt32(e.CommandArgument);
                QueryStringModule qn = new QueryStringModule();
                string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString().Trim()));
                Response.Redirect(string.Format("../agent/academic-calander.aspx?collegeID={0}", EcryptedID), false);
            }
        }

        protected void grdCollege_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCollege.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
        }

        private void BindGrid(int page = 0)
        {
            try
            {

                DataSet user = um.GetSystemUserByUserRole(2);
                if (user != null)
                {
                    int maxPageIndex = grdCollege.PageCount - 1;
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
                    grdCollege.DataSource = user;
                    grdCollege.PageIndex = page;
                    grdCollege.DataBind();
                }
                else
                {
                    grdCollege.DataSource = null;
                    grdCollege.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert(ex.ToString());
            }
        }
    }
}