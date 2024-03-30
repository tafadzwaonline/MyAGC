using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webdev.Payments;

namespace MyAGC.student
{
    public partial class make_payment : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPaymentOption();
                getUserDetails();
                SavePayment();
            }
        }

        private void getUserDetails()
        {

            DataSet GetUsers = um.GetSystemUserByUserEmail(Session["username"].ToString());

            if (GetUsers.Tables.Count > 0 && GetUsers.Tables[0].Rows.Count > 0)
            {
                DataRow row = GetUsers.Tables[0].Rows[0];

               


                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtMobile.Text = row["Mobile"].ToString();
                
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

        protected void getPaymentOption()
        {
            try
            {

                if (lp.getPaymentOptions() != null)
                {
                    ListItem li = new ListItem("Select a Payment Option", "0");
                    drpPaymentOption.DataSource = lp.getPaymentOptions();
                    drpPaymentOption.DataValueField = "ID";
                    drpPaymentOption.DataTextField = "Name";
                    drpPaymentOption.DataBind();
                    drpPaymentOption.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem("There are no Payment Options", "0");
                    drpPaymentOption.DataSource = null;
                    drpPaymentOption.DataBind();
                    drpPaymentOption.Items.Insert(0, li);
                }

            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }




        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (drpPaymentOption.SelectedValue == "0")
                {
                    WarningAlert("Please select a payment option");
                    return;
                }
                if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    WarningAlert("Please enter amount to pay");
                    return;
                }

                Save();
            }
            catch (Exception)
            {
                
                WarningAlert("An error occurred. Please try again later.");
                return;
            }
        }
        private void SavePayment()
        {
            try
            {
                //var paynow = new Paynow("15551", "ad6ee0d2-0103-4036-a920-623b5a83f7fa");
                var paynow = new Paynow("15816", "2e98fc93-849c-48d7-9ab1-0a742d679ed2");
                var pollUrl = Session["PollUrl"] as string;
                int userId = int.Parse(Session["userid"].ToString());
                string useremail = Session["username"].ToString();
              
                if (!string.IsNullOrEmpty(pollUrl))
                {
                    // Check the transaction status
                    //var status = paynow.CheckTransactionStatus(pollUrl);
                    var status = paynow.PollTransaction(pollUrl);
                    int paynowreference = 0;
                    if (status.Paid())
                    {

                        foreach (var item in status.GetData())
                        {
                            if (item.Key == "paynowreference")
                            {
                                paynowreference = Convert.ToInt32(item.Value);
                                break;
                            }
                        }

                        //insert payment details with status
                        lp.SaveOnlinePayment(userId, txtFirstName.Text,txtLastName.Text, useremail, status.Amount, pollUrl, paynowreference,int.Parse(drpPaymentOption.SelectedValue),1);
                        string Ecryptedpaynowreference = HttpUtility.UrlEncode(qn.Encrypt(paynowreference.ToString()));
                        Session["PollUrl"] = null;
                        Session["TransactionReference"] = null;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application successful, now awaiting confirmation');window.location ='../student/receipt?Reference="+ Ecryptedpaynowreference + "';", true);
                        //SuccessAlert("Your transaction was successfully paid");

                    }
                    else
                    {

                        WarningAlert("Your transaction was not paid");
                        Session["PollUrl"] = null;
                        Session["TransactionReference"] = null;
                    }

                }
            }
            catch (Exception ex)
            {
                Session["PollUrl"] = null;
                Session["TransactionReference"] = null;
                WarningAlert("An error occured, please try again later");
            }
        }

        private void Save()
        {
            try
            {


                PayNow();

            }
            catch (Exception)
            {


                WarningAlert("An error occurred. Please try again later.");
                return;
            }
        }

    

        private void PayNow()
        {
            var paynow = new Paynow("15816", "2e98fc93-849c-48d7-9ab1-0a742d679ed2");

            //paynow.ReturnUrl = $"https://localhost:44302/student/make-payment";
            //paynow.ReturnUrl = $"http://localhost/MyAGC/student/make-payment";
            paynow.ReturnUrl = $"https://mysystem.ddns.net/MyAGC/student/make-payment";
            //http://localhost/MyAGC/student/make-payment
            paynow.ResultUrl = "http://example.com/gateways/paynow/update";

            var payment = paynow.CreatePayment(drpPaymentOption.SelectedItem.Text);
            payment.AuthEmail = Session["username"].ToString();
            // Add items to the payment
            payment.Add(drpPaymentOption.SelectedItem.Text, Convert.ToDecimal(txtAmount.Text));

            // Send payment to paynow
            var response = paynow.Send(payment);



            // Check if payment was sent without error
            if (response.Success())
            {
                // Get the url to redirect the user to so they can make payment
                //var link = response.RedirectLink();
                //Response.Redirect(string.Format(link));


                //System.Diagnostics.Process.Start(link);
                // Get the poll url of the transaction
                //var pollUrl = response.PollUrl();

                //var status = paynow.PollTransaction(pollUrl);
                var redirectUrl = response.RedirectLink();

                // Store relevant transaction information for later retrieval
                Session["TransactionReference"] = payment.Reference;
                Session["PollUrl"] = response.PollUrl();

                // Redirect the user to Paynow for payment
                Response.Redirect(redirectUrl);
            }
        }

      
    }
}