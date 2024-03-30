using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.student
{
    public partial class track_parcel : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
       
        protected void grdParcel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
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
                    Response.Redirect(string.Format("../student/parcel?ID={0}", EcryptedID), false);
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