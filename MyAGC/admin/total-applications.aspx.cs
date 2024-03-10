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
    public partial class total_applications : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getApplications();

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

            DataSet getsearchdata = lp.SearchApplication(int.Parse(drpSearchBy.SelectedValue), txtValue.Text);
            if (getsearchdata != null)
            {
                grdApplications.DataSource = getsearchdata;
                grdApplications.DataBind();
            }
            else
            {
                grdApplications.DataSource = null;
                grdApplications.DataBind();
            }
        }


        private void getApplications()
        {
            DataSet dataSet = lp.getAllApplications();

            if (dataSet != null)
            {
                grdApplications.DataSource = dataSet;
                grdApplications.DataBind();
            }
            else
            {
                grdApplications.DataSource = null;
                grdApplications.DataBind();
            }
        }



        protected void grdApplications_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                QueryStringModule qn = new QueryStringModule();
                int index;

                if (e.CommandName == "SelectItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    //string EcryptedCollegeID = HttpUtility.UrlEncode(qn.Encrypt(txtid.Value));
                    Response.Redirect(string.Format("../admin/view-application?ApplicationID={0}", EcryptedID), false);
                }
                if (e.CommandName == "DeleteItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    lp.DeleteApplication(index);

                    getApplications();
                    SuccessAlert("Application successfully deleted");
                }

            }
            catch (Exception ex)
            {

                WarningAlert("An error occured, Try again later");
            }
        }

        protected void grdApplications_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdApplications.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
        }

        private void BindGrid(int page = 0)
        {
            try
            {

                DataSet user = lp.getAllApplications();
                if (user != null)
                {
                    int maxPageIndex = grdApplications.PageCount - 1;
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
                    grdApplications.DataSource = user;
                    grdApplications.PageIndex = page;
                    grdApplications.DataBind();
                }
                else
                {
                    grdApplications.DataSource = null;
                    grdApplications.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert(ex.ToString());
            }
        }
    }
}