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
    public partial class programs : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                txtCollegeID.Value = "0";
                txtPeriodID.Value = "0";
                if (Request.QueryString["collegeID"].ToString() != null)
                {
                    txtCollegeID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["collegeID"]));
                }
                if (Request.QueryString["PeriodID"].ToString() != null)
                {
                    txtPeriodID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["PeriodID"]));
                }
                getSavedPrograms();
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
        private void getSavedPrograms()
        {
            DataSet dataSet = lp.getPrograms(int.Parse(txtCollegeID.Value));

            if (dataSet != null)
            {
                grdPrograms.DataSource = dataSet;
                grdPrograms.DataBind();
            }
            else
            {
                grdPrograms.DataSource = null;
                grdPrograms.DataBind();
            }
        }


        
        protected void grdPrograms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPrograms.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
        }

        private void BindGrid(int page = 0)
        {
            try
            {
                DataSet program = lp.getPrograms(int.Parse(txtCollegeID.Value));
                if (program != null)
                {
                    int maxPageIndex = grdPrograms.PageCount - 1;
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
                    grdPrograms.DataSource = program;
                    grdPrograms.PageIndex = page;
                    grdPrograms.DataBind();
                }
                else
                {
                    grdPrograms.DataSource = null;
                    grdPrograms.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert("An error occured");
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProgramName.Text))
            {
                WarningAlert("Please enter search value");
                return;
            }



            Search();
        }
        private void Search()
        {

          
            DataSet getsearchdata = lp.getSearchProgram(int.Parse(txtCollegeID.Value), txtProgramName.Text);
            if (getsearchdata != null)
            {
                grdPrograms.DataSource = getsearchdata;
                grdPrograms.DataBind();
            }
            else
            {
                grdPrograms.DataSource = null;
                grdPrograms.DataBind();
            }
        }
        protected void grdPrograms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index;
                if (e.CommandName == "SelectItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    string EcryptedCollegeID = HttpUtility.UrlEncode(qn.Encrypt(txtCollegeID.Value));
                    string EcryptedPeriodID = HttpUtility.UrlEncode(qn.Encrypt(txtPeriodID.Value));
                    string EcryptedProgramID = HttpUtility.UrlEncode(qn.Encrypt(index.ToString()));
                    // Response.Redirect(string.Format("../student/application?ID={0}", EcryptedProgramID), false);
                    Response.Redirect(string.Format("../student/application?CollegeID={0}&PeriodID={1}&ProgramID={2}", EcryptedCollegeID, EcryptedPeriodID, EcryptedProgramID), false);
                }


            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
            }
        }

       

    

     
    }
}