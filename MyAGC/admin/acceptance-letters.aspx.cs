using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyAGC.Classes;

namespace MyAGC.admin
{
    public partial class acceptance_letters : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getLetters();

            }
        }
        private void getLetters()
        {
            DataSet x = lp.getAllAcceptanceLetters();
            if (x != null)
            {
                grdDocument.DataSource = x;
                grdDocument.DataBind();
            }
            else
            {
                grdDocument.DataSource = null;
                grdDocument.DataBind();
                //ltEmbed.Text = null;
            }
        }
        protected void download(int AppID)
        {

            byte[] bytes = null;
            string fileName = null;
            string contentType = null;
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DownloadLetter", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AppID", AppID);

                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        if (sdr.HasRows)
                        {
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["FileName"].ToString();
                        }
                        else
                        {
                            bytes = null;
                            contentType = null;
                            fileName = string.Empty;
                        }
                    }
                }

                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", "attachment;filename=\"" + fileName + "");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
        protected void grdDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index;
                if (e.CommandName == "SelectItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    download(index);
                }
                if (e.CommandName == "DeleteItem")
                {
                    index = Convert.ToInt32(e.CommandArgument);
                    lp.DeleteAcceptanceLetter(index);

                    getLetters();
                    SuccessAlert("Letter successfully deleted");
                }
            }
            catch (Exception ex)
            {

                WarningAlert("An error occurred,Try again later");
            }
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

            DataSet getsearchdata = lp.SearchLetter(int.Parse(drpSearchBy.SelectedValue), txtValue.Text);
            if (getsearchdata != null)
            {
                grdDocument.DataSource = getsearchdata;
                grdDocument.DataBind();
            }
            else
            {
                grdDocument.DataSource = null;
                grdDocument.DataBind();
            }
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
        protected void grdDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDocument.PageIndex = e.NewPageIndex;
            this.BindGrid(e.NewPageIndex);
        }

        private void BindGrid(int page = 0)
        {
            try
            {
                DataSet program = lp.getAllAcceptanceLetters();
                if (program != null)
                {
                    int maxPageIndex = grdDocument.PageCount - 1;
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
                    grdDocument.DataSource = program;
                    grdDocument.PageIndex = page;
                    grdDocument.DataBind();
                }
                else
                {
                    grdDocument.DataSource = null;
                    grdDocument.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}