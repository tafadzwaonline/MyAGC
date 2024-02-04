using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.admin
{
    public partial class manage_withdrawal : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getPoints();

            }
        }


        private void getPoints()
        {
            DataSet dataSet = lp.getAllAgentPoints();

            if (dataSet != null)
            {
                grdPoints.DataSource = dataSet;
                grdPoints.DataBind();
            }
            else
            {
                grdPoints.DataSource = null;
                grdPoints.DataBind();
            }
        }

        protected void grdPoints_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPoints.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
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

        private void BindGrid(int page = 0)
        {
            try
            {

                DataSet user = lp.getAllAgentPoints();
                if (user != null)
                {
                    int maxPageIndex = grdPoints.PageCount - 1;
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
                    grdPoints.DataSource = user;
                    grdPoints.PageIndex = page;
                    grdPoints.DataBind();
                }
                else
                {
                    grdPoints.DataSource = null;
                    grdPoints.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert(ex.ToString());
            }
        }

        protected void grdPoints_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                QueryStringModule qn = new QueryStringModule();
                int index = 0;

                if (e.CommandName == "SelectItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    lp.ApproveAgentCommision(index);
                    getPoints();
                    SuccessAlert("Commission successfully aprroved");

                }
                if (e.CommandName == "DeleteItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    lp.RejectAgentCommision(index);
                    getPoints();
                    SuccessAlert("Commission successfully rejected");
                }

            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
            }
        }
        private void Sort(string sortExpression, string v)
        {
            DataView dv = null;
            DataSet asset = lp.getAllAgentPoints();
            dv = new DataView(asset.Tables[0]);
            dv.Sort = sortExpression + " " + v;
            grdPoints.DataSource = dv;
            grdPoints.DataBind();
        }
        protected void grdPoints_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                string SortExpression = e.SortExpression.ToString();
                Session["SortExpression"] = SortExpression;


                if (Session["SortDirection"] != null && Session["SortDirection"].ToString() == SortDirection.Descending.ToString())
                {
                    Session["SortDirection"] = SortDirection.Ascending;
                    Sort(SortExpression, "ASC");
                }
                else
                {
                    Session["SortDirection"] = SortDirection.Descending;
                    Sort(SortExpression, "DESC");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}