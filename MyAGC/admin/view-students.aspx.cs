using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.admin
{
    public partial class view_students : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getSavedUsers();
            }
        }


        private void getSavedUsers()
        {

            DataSet getsearchdata = um.GetSystemUserByUserRole(3);
            if (getsearchdata != null)
            {
                grdAdmin.DataSource = getsearchdata;
                grdAdmin.DataBind();
            }
            else
            {
                grdAdmin.DataSource = null;
                grdAdmin.DataBind();
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
        protected void grdAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAdmin.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
        }
        private void BindGrid(int page = 0)
        {
            try
            {

                DataSet user = um.GetSystemUserByUserRole(3);
                if (user != null)
                {
                    int maxPageIndex = grdAdmin.PageCount - 1;
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
                    grdAdmin.DataSource = user;
                    grdAdmin.PageIndex = page;
                    grdAdmin.DataBind();
                }
                else
                {
                    grdAdmin.DataSource = null;
                    grdAdmin.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert(ex.ToString());
            }
        }

        protected void grdAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                QueryStringModule qn = new QueryStringModule();
                int index = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "SuspendItem")
                {
                    lp.UpdateStatus(0, index);
                    getSavedUsers();

                    SuccessAlert("User successfully suspended");
                }
                if (e.CommandName == "ApproveItem")
                {
                    lp.UpdateStatus(1, index);

                    getSavedUsers();
                    SuccessAlert("User successfully activated");
                }
            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
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

            DataSet getsearchdata = lp.getSearchUsers(int.Parse(drpSearchBy.SelectedValue), 3, txtValue.Text);
            if (getsearchdata != null)
            {
                grdAdmin.DataSource = getsearchdata;
                grdAdmin.DataBind();
            }
            else
            {
                grdAdmin.DataSource = null;
                grdAdmin.DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/create-user"));
        }
    }
}