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
    public partial class InstistutionDashboard : System.Web.UI.MasterPage
    {
        LookUp lp = new LookUp("con");

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
           
            DataSet TotalApplication = lp.getTotalApplications(int.Parse(Session["userid"].ToString()));
            DataSet TotalPayments = lp.getPaymentsByCollegeID(int.Parse(Session["userid"].ToString()));
            DataSet RejectedApplication = lp.getRejectedApplications(int.Parse(Session["userid"].ToString()));
            DataSet AcceptedApplication = lp.getApprovedApplications(int.Parse(Session["userid"].ToString()));
            DataSet PendingApplication = lp.getApplicationsAwaitingApproval(int.Parse(Session["userid"].ToString()));
            DataSet TotalPrograms = lp.getPrograms(int.Parse(Session["userid"].ToString()));

            if (TotalApplication != null)
            {
                lblTotalApplications.Text = TotalApplication.Tables[0].Rows.Count.ToString();
            }
            if (TotalPayments != null)
            {
                lblTotalPayments.Text = TotalPayments.Tables[0].Rows.Count.ToString();
            }
            if (RejectedApplication != null)
            {
                lblRejectedApplications.Text = RejectedApplication.Tables[0].Rows.Count.ToString();
            }
            if (AcceptedApplication != null)
            {
                lblAcceptedApplications.Text = AcceptedApplication.Tables[0].Rows.Count.ToString();
            }
            if (PendingApplication != null)
            {
                lblPendingApplications.Text = PendingApplication.Tables[0].Rows.Count.ToString();
            }
            if (TotalPrograms != null)
            {
                lblTotalPrograms.Text = TotalPrograms.Tables[0].Rows.Count.ToString();
            }
        }

        protected void LoadClientImage()
        {
            try
            {


                //ClientPic.ImageUrl = string.Format("~/ImageHandler.ashx?UserID={0}", int.Parse(Session["userid"].ToString()));
            }
            catch (Exception ex)
            {
                //DangerAlert(ex.Message);
            }
        }

        protected void lnkTotalApplications_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../institution/total-applications"));
        }

        protected void lnkAcceptedApplications_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../institution/accepted-applications"));
        }

        protected void lnlPendingApplications_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../institution/approve-applications"));
        }

        protected void lnkRejectedApplications_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../institution/rejected-applications"));
        }

        protected void lnkTotalPrograms_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../institution/add-program"));
        }

        protected void lnkTotalPayments_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../institution/student-payments"));
        }
    }
}