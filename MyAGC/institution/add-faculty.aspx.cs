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
    public partial class add_faculty : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getFacaulty();
              
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtFacultyName.Text == "")
            {
                WarningAlert("Please faculty name");
                return;
            }

            Save();
        }

        private void Save()
        {
            try
            {
                lp.SaveFaculty(int.Parse(Session["userid"].ToString()), txtFacultyName.Text);

                txtFacultyName.Text = string.Empty;
                getFacaulty();
                SuccessAlert("Faculty successfully added");
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void getFacaulty()
        {
            DataSet x = lp.getFaculty(int.Parse(Session["userid"].ToString()));
            if (x != null)
            {
                grdFaculty.DataSource = x;
                grdFaculty.DataBind();
            }
            else
            {
                grdFaculty.DataSource = null;
                grdFaculty.DataBind();
                //ltEmbed.Text = null;
            }
        }

        protected void grdFaculty_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFaculty.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
        }
        private void BindGrid(int page = 0)
        {
            try
            {
                DataSet faculty = lp.getFaculty(int.Parse(Session["userid"].ToString()));
                if (faculty != null)
                {
                    int maxPageIndex = grdFaculty.PageCount - 1;
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
                    grdFaculty.DataSource = faculty;
                    grdFaculty.PageIndex = page;
                    grdFaculty.DataBind();
                }
                else
                {
                    grdFaculty.DataSource = null;
                    grdFaculty.DataBind();
                }

            }
            catch (Exception ex)
            {
                DangerAlert("An error occured");
            }
        }
        protected void grdFaculty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index = Convert.ToInt32(e.CommandArgument);


                if (e.CommandName == "DeleteItem")
                {

                    lp.RemoveFaculty(index);
                    getFacaulty();

                    SuccessAlert("Record successfully removed");
                }
               

            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
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
    }
}