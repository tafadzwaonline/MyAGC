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
    public partial class add_program : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getFaculty();
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
            DataSet dataSet = lp.getPrograms(int.Parse(Session["userid"].ToString()));

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


        protected void getFaculty()
        {
            try
            {

                if (lp.getFaculty(int.Parse(Session["userid"].ToString())) != null)
                {
                    ListItem li = new ListItem("Select a faculty", "0");
                    drpFaculty.DataSource = lp.getFaculty(int.Parse(Session["userid"].ToString()));
                    drpFaculty.DataValueField = "ID";
                    drpFaculty.DataTextField = "Name";
                    drpFaculty.DataBind();
                    drpFaculty.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no faculties", "0");
                    drpFaculty.DataSource = null;
                    drpFaculty.DataBind();
                    drpFaculty.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
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
                DataSet program = lp.getPrograms(int.Parse(Session["userid"].ToString()));
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

        protected void grdPrograms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index = Convert.ToInt32(e.CommandArgument);


                if (e.CommandName == "DeleteItem")
                {

                    lp.RemoveProgram(index);
                    getSavedPrograms();

                    SuccessAlert("Record successfully removed");
                }


            }
            catch (Exception ex)
            {

                DangerAlert(ex.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (drpFaculty.SelectedValue == "0")
            {
                WarningAlert("Please select a faculty");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProgramName.Text))
            {
                WarningAlert("Please enter a program name");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDuration.Text))
            {
                WarningAlert("Please enter duration");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequirements.Text))
            {
                WarningAlert("Please enter program requirements");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTuition.Text))
            {
                WarningAlert("Please enter tuition");
                return;
            }

            SaveProgram();

        }

        private void SaveProgram()
        {
            lp.SavePrograms(int.Parse(Session["userid"].ToString()),int.Parse(txtDuration.Text),int.Parse(drpFaculty.SelectedValue),txtProgramName.Text,txtRequirements.Text,double.Parse(txtTuition.Text));
            getSavedPrograms();
            SuccessAlert("Program Successfully added");
            Clear();
        }

        private void Clear()
        {
            drpFaculty.SelectedValue = "0";
            txtRequirements.Text = string.Empty;
            txtDuration.Text = string.Empty;
            txtProgramName.Text = string.Empty;
            txtTuition.Text = string.Empty;
        }
    }
}