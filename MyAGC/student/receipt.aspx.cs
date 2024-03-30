using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MyAGC.student
{
    public partial class receipt : System.Web.UI.Page
    {
        QueryStringModule qn = new QueryStringModule();
        readonly LookUp lp = new LookUp("con");
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtReferenceID.Value = "0";
                if (Request.QueryString["Reference"].ToString() != null)
                {
                    //txtReferenceID.Value = Request.QueryString["Reference"];
                    txtReferenceID.Value = qn.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Reference"]));
                }
                lblPayNowRef.Text = txtReferenceID.Value;
                getUserDetails();
                getPaymentDetails();


            }
        }
        private void getUserDetails()
        {

            DataSet GetUsers = um.GetSystemUserByUserEmail(Session["username"].ToString());

            if (GetUsers.Tables.Count > 0 && GetUsers.Tables[0].Rows.Count > 0)
            {
                DataRow row = GetUsers.Tables[0].Rows[0];
                lblmemberName.Text = $"{row["FirstName"]} {row["LastName"]}";
                lblLastName.Text = row["LastName"].ToString();
                lblClientName.Text = row["FirstName"].ToString();
                lblEmail.Text = row["Email"].ToString();
                

            }
        }
        private void getPaymentDetails()
        {

            DataSet getPayments = lp.getOnlinePayNowPaymentsByRef(int.Parse(txtReferenceID.Value));

            if (getPayments.Tables.Count > 0 && getPayments.Tables[0].Rows.Count > 0)
            {
                DataRow row = getPayments.Tables[0].Rows[0];
                DateTime dt = Convert.ToDateTime(row["DateCreated"]);
                string dts = dt.ToString("yyyy-MM-dd");

                lblDate.Text = dts;
                lblPaymentOption.Text = $"{row["PaymentOption"]}";
                lblTotal.Text = row["Amount"].ToString();
            }
        }


    }
}