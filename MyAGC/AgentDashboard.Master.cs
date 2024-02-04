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
    public partial class AgentDashboard : System.Web.UI.MasterPage
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

            //DataSet TotalApplication = lp.getAgentApplications(int.Parse(Session["userid"].ToString()));
            DataSet TotalPoints = lp.getAgentPointsByID(int.Parse(Session["userid"].ToString()));
            DataSet TotalWithdrawals = lp.getAllAgentWithdrawals(int.Parse(Session["userid"].ToString()));
            DataSet TotalStudents = lp.getAgentStudents(int.Parse(Session["userid"].ToString()));
            DataSet getsearchdata = um.GetSystemUserByUserRole(2);


            //if (TotalApplication != null)
            //{
            //    lblTotalApplications.Text = TotalApplication.Tables[0].Rows.Count.ToString();
            //}
           
            if (TotalPoints != null)
            {
                double total = 0;
                foreach (DataRow dt in TotalPoints.Tables[0].Rows)
                {
                    total += double.Parse(dt["Points"].ToString());
                }
                lblTotalPoints.Text = total.ToString();

            }
           
            if (TotalWithdrawals != null)
            {
                lblWithdrawals.Text = TotalWithdrawals.Tables[0].Rows.Count.ToString();

            }
            if (TotalStudents != null)
            {
                lblTotalPayments.Text = TotalStudents.Tables[0].Rows.Count.ToString();
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
            Response.Redirect(string.Format("../agent/my-applications"));
        }



        protected void lnkSearchCollege_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../agent/search-college"));
        }

        protected void lnkSupportQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../agent/pop-uploads"));
        }

        protected void lnkTotalPayments_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../agent/view-students"));
        }

        protected void lnkTotalPoints_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../agent/my-points"));
        }

        protected void lnkWithdrawals_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../agent/my-withdrawals"));
        }
    }
}