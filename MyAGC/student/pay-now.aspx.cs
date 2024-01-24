using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webdev.Payments;
using static System.Net.Mime.MediaTypeNames;

namespace MyAGC.student
{
    public partial class pay_now : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var paynow = new Paynow("15551", "ad6ee0d2-0103-4036-a920-623b5a83f7fa");
                var pollUrl = Session["PollUrl"] as string;

                if (!string.IsNullOrEmpty(pollUrl))
                {
                    // Check the transaction status
                    //var status = paynow.CheckTransactionStatus(pollUrl);
                    var status = paynow.PollTransaction(pollUrl);
                    if (status.Paid())
                    {
                        // Yay! Transaction was paid for
                        SuccessAlert("Your transaction was successfully paid");
                        Session["PollUrl"] = null;
                        Session["TransactionReference"] = null;
                    }
                    else
                    {
                       
                        WarningAlert("Your transaction was not paid");
                        Session["PollUrl"] = null;
                        Session["TransactionReference"] = null;
                    }
                
                 }
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var paynow = new Paynow("15551", "ad6ee0d2-0103-4036-a920-623b5a83f7fa");

            paynow.ReturnUrl = "http://localhost/MyAGC/student/pay-now";

            paynow.ResultUrl = "http://example.com/gateways/paynow/update";

        //https://www.paynow.co.zw/User/Login?email=tk@gmail.com&returnUrl=L1BheW1lbnQvQ29uZmlybVBheW1lbnQvMTc0MzAwMDgvdGtAZ21haWwuY29tLw2
        //https://www.paynow.co.zw/Payment/ConfirmPayment/17430008/tk@gmail.com/
        //https://www.paynow.co.zw/Payment/ConfirmPayment/17430137/kahwaitafadzwa@gmail.com
        //https://www.paynow.co.zw/Transaction/CustomerView/17430137
            // The return url can be set at later stages. You might want to do this if you want to pass data to the return url (like the reference of the transaction)
            //https://localhost:44302/student/pay-now
            // Create a new payment 
            var payment = paynow.CreatePayment("Application Fees");
            payment.AuthEmail = "kahwaitafadzwa@gmail.com";
            // Add items to the payment
            payment.Add("Bananas", 1000);
            
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