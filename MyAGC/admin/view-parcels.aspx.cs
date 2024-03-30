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
    public partial class view_parcels : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getParcels();
            }
        }
        private void getParcels()
        {
            DataSet dataSet = lp.getParcels();

            if (dataSet != null)
            {
                grdParcel.DataSource = dataSet;
                grdParcel.DataBind();
            }
            else
            {
                grdParcel.DataSource = null;
                grdParcel.DataBind();
            }
        }
        protected void grdParcel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdParcel.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
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

            DataSet getsearchdata = lp.getSearchParcel(int.Parse(drpSearchBy.SelectedValue), txtValue.Text);
            if (getsearchdata != null)
            {
                grdParcel.DataSource = getsearchdata;
                grdParcel.DataBind();
            }
            else
            {
                grdParcel.DataSource = null;
                grdParcel.DataBind();
            }
        }
        private void BindGrid(int page = 0)
        {
            try
            {
                DataSet program = lp.getParcels();
                if (program != null)
                {
                    int maxPageIndex = grdParcel.PageCount - 1;
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
                    grdParcel.DataSource = program;
                    grdParcel.PageIndex = page;
                    grdParcel.DataBind();
                }
                else
                {
                    grdParcel.DataSource = null;
                    grdParcel.DataBind();
                }

            }
            catch (Exception ex)
            {
                WarningAlert("An error occured");
            }
        }
        protected void WarningAlert(string message)
        {
            string script = $"WarningToastr('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastScript", script, true);
        }
        protected void grdParcel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                
                int index;

                if (e.CommandName == "SelectItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    Response.Redirect(string.Format("../admin/parcel?ID={0}", EcryptedID), false);
                }

            }
            catch (Exception ex)
            {

                WarningAlert(ex.ToString());
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/my-courier"));
        }
    }
}