using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        LookUp lp = new LookUp("con");
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                DataRow rw = lp.getSystemUserById(int.Parse(Session["userid"].ToString())).Tables[0].Rows[0];
                lblUsername.Text = $"{rw["FirstName"]} {rw["LastName"]}";
                LoadClientImage();
                getStatistics();
            }
            else
            {

                Response.Redirect("../login.aspx");
            }
        }
        private void getStatistics()
        {

            DataSet TotalApplication = lp.getStudentApplicationByUserID(int.Parse(Session["userid"].ToString()));
            DataSet TotalPayments = lp.getPaymentsByApplicantID(int.Parse(Session["userid"].ToString()));
            DataSet TotalLetters = lp.getAcceptanceLetters(int.Parse(Session["userid"].ToString()));
            DataSet TotalPop = lp.getUploadedProofOfPaymentsByApplicantID(int.Parse(Session["userid"].ToString()));
            DataSet getsearchdata = um.GetSystemUserByUserRole(2);
            

            if (TotalApplication != null)
            {
                lblTotalApplications.Text = TotalApplication.Tables[0].Rows.Count.ToString();
            }
            if (TotalLetters != null)
            {
                lblAcceptanceLetter.Text = TotalLetters.Tables[0].Rows.Count.ToString();
            }
            if (TotalPop != null)
            {
                lblPop.Text = TotalPop.Tables[0].Rows.Count.ToString();
            }

            if (TotalPayments != null)
            {
                lblTotalPayments.Text = TotalPayments.Tables[0].Rows.Count.ToString();
            }

            if (getsearchdata != null)
            {
                lblSearchCollege.Text = getsearchdata.Tables[0].Rows.Count.ToString();
            }
        }
        protected void LoadClientImage()
        {
            try
            {


                ClientPic.ImageUrl = string.Format("~/ImageHandler.ashx?UserID={0}", int.Parse(Session["userid"].ToString()));
            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }
        protected void lnkTotalApplications_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../student/my-applications"));
        }

   

        protected void lnkSearchCollege_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../student/search-college"));
        }

        protected void lnkSupportQuery_Click(object sender, EventArgs e)
        {
           Response.Redirect(string.Format("../student/pop-uploads"));
        }

        protected void lnkTotalPayments_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../student/my-payments"));
        }

        protected void lnkAcceptanceLetter_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../student/acceptance-letters"));
        }
    }
}