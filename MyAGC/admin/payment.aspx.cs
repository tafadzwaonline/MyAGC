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
    public partial class payment : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                txtRerefenceID.Value = "0";
                if (Request.QueryString["Reference"].ToString() != null)
                {
                    txtRerefenceID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Reference"]));
                }
                getPaymentStatus();
                getPaymentDetails();

            }
        }

        private void getPaymentDetails()
        {

            DataSet getPayments = lp.getOnlinePayNowPaymentsByRef(int.Parse(txtRerefenceID.Value));

            if (getPayments.Tables.Count > 0 && getPayments.Tables[0].Rows.Count > 0)
            {
                DataRow row = getPayments.Tables[0].Rows[0];
               
                txtLastName.Text = row["LastName"].ToString();
                txtFirstName.Text = row["FirstName"].ToString();
                txtEmail.Text = row["UserEmail"].ToString();
                DateTime dt = Convert.ToDateTime(row["DateCreated"]);
                string dts = dt.ToString("yyyy-MM-dd");
                txtPaymentDate.Text = dts;
                txtCurrency.Text = row["Currency"].ToString();
                txtPollUrl.Text = row["PollUrl"].ToString(); 
                txtAmountPaid.Text = row["Amount"].ToString();
                txtPaymentOption.Text = row["PaymentOption"].ToString();
                txtPlatform.Text = row["Platform"].ToString();
                drpStatus.SelectedValue = row["PaymentStatusID"].ToString();
                txtReferenceNumber.Text = txtRerefenceID.Value;

            }
        }

        protected void getPaymentStatus()
        {
            try
            {

                if (lp.getPaymentStatus() != null)
                {
                    ListItem li = new ListItem("Select a Payment Status", "0");
                    drpStatus.DataSource = lp.getPaymentStatus();
                    drpStatus.DataValueField = "ID";
                    drpStatus.DataTextField = "Name";
                    drpStatus.DataBind();
                    drpStatus.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Payment Statuses", "0");
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (drpStatus.SelectedValue == "0")
            {
                WarningAlert("Please select payment status");
                return;
            }


            lp.UpdatePaymentStatus(int.Parse(txtRerefenceID.Value),int.Parse(drpStatus.SelectedValue));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Payment successfully updated');window.location ='../admin/paynow-payments';", true);
        }
    }
}