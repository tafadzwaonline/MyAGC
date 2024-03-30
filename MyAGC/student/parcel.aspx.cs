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
    public partial class parcel : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"].ToString() != null)
                {
                    txtid.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["ID"]));
                }

                getSettings();
                getParcels();
            }
        }
        private void getParcels()
        {
            DataSet dataSet = lp.getParcelByID(int.Parse(txtid.Value));

            if (dataSet != null)
            {
                DataRow dt = dataSet.Tables[0].Rows[0];
                txtParcelDetails.Text = dt["PackageDetails"].ToString();
                drpOrigin.SelectedValue = dt["OriginID"].ToString();
                drpDestination.SelectedValue = dt["DestinationID"].ToString();
                txtweight.Text = dt["Weight"].ToString();
                txtAmount.Text = dt["Amount"].ToString();
                txtSenderFullName.Text = dt["SenderFullNames"].ToString();
                txtSenderMobile.Text = dt["SenderMobile"].ToString();
                txtReceiverFullName.Text = dt["ReceiverFullNames"].ToString();
                txtReceiverAddress.Text = dt["ReceiverAddress"].ToString();
                txtRecieverMobile.Text = dt["ReceiverMobile"].ToString();
                txtReceiverIdentityNumber.Text = dt["ReceiverNationalID"].ToString();
                txtSenderOfficer.Text = dt["SendingOfficer"].ToString();
                txtReceivingOfficer.Text = dt["ReceivingOfficer"].ToString();
                txtSendingCode.Text = dt["SendingCodeNumber"].ToString();
                txtReceivingCode.Text = dt["ReceivingCodeNumber"].ToString();
                txtTrackingID.Text = dt["TrackingID"].ToString();
                drpStatus.SelectedValue = dt["ParcelStatusID"].ToString();


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
            catch (Exception)
            {
                WarningAlert("An error occuurred");
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

        protected void txtweight_TextChanged(object sender, EventArgs e)
        {
            txtAmount.Text = lp.getFees(double.Parse(txtweight.Text));
        }

       

      
    }
}