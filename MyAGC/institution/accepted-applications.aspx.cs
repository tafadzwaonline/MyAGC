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
    public partial class accepted_applications : System.Web.UI.Page
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



        private void getApplications()
        {
            DataSet dataSet = lp.getApprovedApplications(int.Parse(Session["userid"].ToString()));

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
                int index = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "SelectItem")
                {
                    string EcryptedPeriodID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    string EcryptedCollegeID = HttpUtility.UrlEncode(qn.Encrypt(txtid.Value));
                    Response.Redirect(string.Format("../institution/view-application?ApplicationID={0}", EcryptedPeriodID), false);
                }

            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
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

                DataSet user = lp.getApprovedApplications(int.Parse(Session["userid"].ToString()));
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