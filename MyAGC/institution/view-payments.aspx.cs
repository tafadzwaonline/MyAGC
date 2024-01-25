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
    public partial class view_payments : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                txtPaymentID.Value = "0";
                if (Request.QueryString["PaymentID"].ToString() != null)
                {
                    txtPaymentID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["PaymentID"]));
                }
                getPayment();

            }
        }



        private void getPayment()
        {
            DataSet dataSet = lp.getPaymentsByPaymentID(int.Parse(txtPaymentID.Value));

            if (dataSet != null)
            {
                DataRow dt = dataSet.Tables[0].Rows[0];

                DateTime date = Convert.ToDateTime(dt["DateCreated"].ToString());

                string dates = date.ToString("yyyy-MM-dd");


                txtApplicantName.Text = dt["ApplicantName"].ToString();
                txtApplicantEmail.Text = dt["UserEmail"].ToString();
                txtApplicantAddress.Text = dt["ApplicantAddress"].ToString();
                txtApplicantMobile.Text = dt["ApplicantMobile"].ToString();
                txtPaymentDate.Text = dates;
                txtReferenceNumber.Text = dt["ReferenceNumber"].ToString();
                txtPollUrl.Text = dt["PollUrl"].ToString();
                txtAmountPaid.Text = dt["Amount"].ToString();
                txtCollegeApplied.Text = dt["College"].ToString();
                txtProgramApplied.Text = dt["ProgramName"].ToString();
            }

        }
    }
}