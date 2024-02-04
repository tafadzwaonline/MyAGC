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
    public partial class select_student : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtID.Value = "0";
                txtCollegeID.Value = "0";
                txtPeriodID.Value = "0";

                txtProgramID.Value = "0";
                if (Request.QueryString["CollegeID"].ToString() != null)
                {
                    txtCollegeID.Value = Request.QueryString["CollegeID"].ToString();
                }
                if (Request.QueryString["PeriodID"].ToString() != null)
                {
                    txtPeriodID.Value = Request.QueryString["PeriodID"].ToString();
                }
                if (Request.QueryString["ProgramID"].ToString() != null)
                {
                    txtProgramID.Value = Request.QueryString["ProgramID"].ToString();
                }

                getStudents();

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



        private void getStudents()
        {
            DataSet dataSet = lp.getAgentStudents(int.Parse(Session["userid"].ToString()));

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
               

                if (e.CommandName == "SelectItem")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedUserID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    Response.Redirect(string.Format("../agent/application?CollegeID=" + txtCollegeID.Value + "&PeriodID=" + txtPeriodID.Value + "&ProgramID=" + txtProgramID.Value + "&StudentID=" + EcryptedUserID + ""));
                    //Response.Redirect(string.Format("../student/programs?CollegeID={0}&PeriodID={1}", EcryptedCollegeID, EcryptedPeriodID), false);
                    //Response.Redirect(string.Format("../student/view-payment?PaymentID={0}", EcryptedPeriodID), false);
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

                DataSet user = lp.getAgentStudents(int.Parse(Session["userid"].ToString()));
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