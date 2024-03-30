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
    public partial class AdminDashboard : System.Web.UI.MasterPage
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
            double POP = 0;
            DataSet TotalPayments = lp.getAllPayments();
            DataSet TotalPayNowPayments = lp.getOnlinePayNowPayments();
            DataSet TotalWithdrawals = lp.getAllAgentPoints();
            DataSet getcollege = um.GetSystemUserByUserRole(2);
            DataSet getagent = um.GetSystemUserByUserRole(4);
            DataSet getconsultant = um.GetSystemUserByUserRole(5);
            DataSet getadmin = um.GetSystemUserByUserRole(1);
            DataSet TotalLetters = lp.getAllAcceptanceLetters();
            DataSet getstudent = um.GetSystemUserByUserRole(3);
            DataSet TotalPop = lp.getUploadedProofOfPayments();
            DataSet TotalApplications = lp.getAllApplications();

            if (TotalWithdrawals != null)
            {
                lblAgentCommission.Text = TotalWithdrawals.Tables[0].Rows.Count.ToString();
            }
            if (getagent != null)
            {
                lblTotalAgents.Text = getagent.Tables[0].Rows.Count.ToString();
            }
            if (getconsultant != null)
            {
                lblConsultant.Text = getconsultant.Tables[0].Rows.Count.ToString();
            }
            if (TotalApplications != null)
            {
                lblTotalApplications.Text = TotalApplications.Tables[0].Rows.Count.ToString();
            }
            if (TotalLetters != null)
            {
                lblAcceptanceLetter.Text = TotalLetters.Tables[0].Rows.Count.ToString();
            }
            if (getcollege != null)
            {
                lblTotalColleges.Text = getcollege.Tables[0].Rows.Count.ToString();
            }
            if (TotalPayNowPayments != null)
            {
                double total = 0;
                foreach (DataRow dt in TotalPayNowPayments.Tables[0].Rows)
                {
                    total += double.Parse(dt["Amount"].ToString());
                }

                lblOnlinePayments.Text = $"${total}";
            }
            if (TotalPop != null)
            {
                foreach (DataRow dt in TotalPop.Tables[0].Rows)
                {
                    POP += double.Parse(dt["Fee"].ToString());
                }

                lblPop.Text = $"${POP}";
                //lblPop.Text = TotalPop.Tables[0].Rows.Count.ToString();
            }
            if (TotalPayments != null)
            {
                lblTotalPayments.Text = TotalPayments.Tables[0].Rows.Count.ToString();
            }

            if (getadmin != null)
            {
                lblTotalAdmin.Text = getadmin.Tables[0].Rows.Count.ToString();
            }

            if (getstudent != null)
            {
                lblTotalStudents.Text = getstudent.Tables[0].Rows.Count.ToString();
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
      
        protected void lnkTotalPayments_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/all-payments"));
        }

        protected void lnkTotalAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/view-user"));
        }

        protected void lnkTotalColleges_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/view-colleges"));
        }

        protected void lnkTotalStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/view-students"));
        }

        protected void lnkPop_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/pop-uploads"));
        }

        protected void lnkAgentCommission_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/manage-withdrawal"));
        }
        protected void lnkAcceptanceLetter_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/acceptance-letters"));
        }

        protected void lnkTotalApplications_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/total-applications"));
        }

        protected void lnkTotalAgents_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/view-agent"));
        }

        protected void lnkConsultant_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/view-consultant"));
        }

        protected void lnkOnlinePayments_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../admin/paynow-payments"));
        }
    }
}