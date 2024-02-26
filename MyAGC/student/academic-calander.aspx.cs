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
    public partial class academic_calander : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryStringModule qn = new QueryStringModule();
                txtid.Value = "0";
                if (Request.QueryString["collegeID"].ToString() != null)
                {
                    txtid.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["collegeID"]));
                }
                getAcademicCalendar();

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



        private void getAcademicCalendar()
        {
            DataSet dataSet = lp.getAcademicCalendar(int.Parse(txtid.Value));

            if (dataSet != null)
            {
                grdAcademicHistory.DataSource = dataSet;
                grdAcademicHistory.DataBind();
            }
            else
            {
                grdAcademicHistory.DataSource = null;
                grdAcademicHistory.DataBind();
            }
        }

       

        protected void grdAcademicHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                QueryStringModule qn = new QueryStringModule();
                int index;

                if (e.CommandName == "SelectItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedPeriodID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    string EcryptedCollegeID = HttpUtility.UrlEncode(qn.Encrypt(txtid.Value));
                    Response.Redirect(string.Format("../student/programs?CollegeID={0}&PeriodID={1}", EcryptedCollegeID, EcryptedPeriodID), false);
                }

            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
            }
        }

        protected void grdAcademicHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAcademicHistory.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
        }

        private void BindGrid(int page = 0)
        {
            try
            {

                DataSet user = lp.getAcademicCalendar(int.Parse(txtid.Value));
                if (user != null)
                {
                    int maxPageIndex = grdAcademicHistory.PageCount - 1;
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
                    grdAcademicHistory.DataSource = user;
                    grdAcademicHistory.PageIndex = page;
                    grdAcademicHistory.DataBind();
                }
                else
                {
                    grdAcademicHistory.DataSource = null;
                    grdAcademicHistory.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert(ex.ToString());
            }
        }
    }
}