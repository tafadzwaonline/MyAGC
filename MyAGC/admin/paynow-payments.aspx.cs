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
    public partial class paynow_payments : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getPayments();

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

            DataSet getsearchdata = lp.getSearchOnlinePayment(int.Parse(drpSearchBy.SelectedValue), txtValue.Text);
            if (getsearchdata != null)
            {
                grdPayments.DataSource = getsearchdata;
                grdPayments.DataBind();
            }
            else
            {
                grdPayments.DataSource = null;
                grdPayments.DataBind();
            }
        }

        private void getPayments()
        {
            DataSet dataSet = lp.getOnlinePayNowPayments();

            if (dataSet != null)
            {
                grdPayments.DataSource = dataSet;
                grdPayments.DataBind();
            }
            else
            {
                grdPayments.DataSource = null;
                grdPayments.DataBind();
            }
        }



        protected void grdPayments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                QueryStringModule qn = new QueryStringModule();
                int index;

                if (e.CommandName == "SelectItem")
                {

                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedReference = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    string EcryptedEmail = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));


                    Response.Redirect(string.Format("../admin/receipt?Reference={0}", EcryptedReference), false);
                }
                if (e.CommandName == "ViewItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedReference = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));


                    Response.Redirect(string.Format("../admin/payment?Reference={0}", EcryptedReference), false);
                }

            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
            }
        }

        protected void grdPayments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPayments.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
        }

        private void BindGrid(int page = 0)
        {
            try
            {

                DataSet user = lp.getOnlinePayNowPayments();
                if (user != null)
                {
                    int maxPageIndex = grdPayments.PageCount - 1;
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
                    grdPayments.DataSource = user;
                    grdPayments.PageIndex = page;
                    grdPayments.DataBind();
                }
                else
                {
                    grdPayments.DataSource = null;
                    grdPayments.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert(ex.ToString());
            }
        }
    }
}