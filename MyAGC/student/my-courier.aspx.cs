using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.student
{
    public partial class my_courier : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getSettings();
            }
        }


        protected void getSettings()
        {
            try
            {

                if (lp.getCountry() != null)
                {
                    ListItem li = new ListItem("Select a origin", "0");
                    drpOrigin.DataSource = lp.getCountry();
                    drpOrigin.DataValueField = "ID";
                    drpOrigin.DataTextField = "CountryName";
                    drpOrigin.DataBind();
                    drpOrigin.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no origins", "0");
                    drpOrigin.DataSource = null;
                    drpOrigin.DataBind();
                    drpOrigin.Items.Insert(0, li);
                }


                if (lp.getCountry() != null)
                {
                    ListItem li = new ListItem("Select a destination", "0");
                    drpDestination.DataSource = lp.getCountry();
                    drpDestination.DataValueField = "ID";
                    drpDestination.DataTextField = "CountryName";
                    drpDestination.DataBind();
                    drpDestination.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no destinations", "0");
                    drpDestination.DataSource = null;
                    drpDestination.DataBind();
                    drpDestination.Items.Insert(0, li);
                }

                if (lp.getParcelStatus() != null)
                {
                    ListItem li = new ListItem("Select status", "0");
                    drpStatus.DataSource = lp.getParcelStatus();
                    drpStatus.DataValueField = "ID";
                    drpStatus.DataTextField = "Name";
                    drpStatus.DataBind();
                    drpStatus.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no parcel statuses", "0");
                    drpStatus.DataSource = null;
                    drpStatus.DataBind();
                    drpStatus.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
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
    }
}