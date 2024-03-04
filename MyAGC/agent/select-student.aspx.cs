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
                grdStudent.DataSource = dataSet;
                grdStudent.DataBind();
            }
            else
            {
                grdStudent.DataSource = null;
                grdStudent.DataBind();
            }
        }



        protected void grdStudent_RowCommand(object sender, GridViewCommandEventArgs e)
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                WarningAlert("Please enter search value");
                return;
            }



            Search();
        }
        private void Search()
        {


            DataSet getsearchdata = lp.SearchAgentStudent(int.Parse(Session["userid"].ToString()), txtSearch.Text);
            if (getsearchdata != null)
            {
                grdStudent.DataSource = getsearchdata;
                grdStudent.DataBind();
            }
            else
            {
                grdStudent.DataSource = null;
                grdStudent.DataBind();
            }
        }
        protected void grdStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStudent.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
        }

        private void BindGrid(int page = 0)
        {
            try
            {

                DataSet user = lp.getAgentStudents(int.Parse(Session["userid"].ToString()));
                if (user != null)
                {
                    int maxPageIndex = grdStudent.PageCount - 1;
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
                    grdStudent.DataSource = user;
                    grdStudent.PageIndex = page;
                    grdStudent.DataBind();
                }
                else
                {
                    grdStudent.DataSource = null;
                    grdStudent.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert(ex.ToString());
            }
        }
    }
}