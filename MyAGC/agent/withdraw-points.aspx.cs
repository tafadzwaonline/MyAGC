using MyAGC.Classes;
using MyAGC.Data;
using MyAGC.student;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.agent
{
    public partial class withdraw_points : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


             

                getAgentDetails();


            }
        }
        private void getAgentDetails()
        {
            double total = 0;
            DataSet GetUsers = um.GetSystemUserByUserEmail(Session["username"].ToString());
            DataSet TotalPoints = lp.getAgentPointsByID(int.Parse(Session["userid"].ToString()));
            if (GetUsers.Tables.Count > 0 && GetUsers.Tables[0].Rows.Count > 0)
            {
                DataRow row = GetUsers.Tables[0].Rows[0];

                txtAgentName.Text = $"{row["FirstName"]} {row["LastName"]}";
                txtAgentID.Text = Session["userid"].ToString();
            }

            
            if (TotalPoints != null)
            {
                foreach (DataRow dt in TotalPoints.Tables[0].Rows)
                {
                    total += double.Parse(dt["Points"].ToString());
                }
                txtCurrentBalance.Text = total.ToString();
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
            if (string.IsNullOrEmpty(txtPoints.Text))
            {
                WarningAlert("Please enter points to withdraw");
                return;
            }

            if (double.Parse(txtPoints.Text) > double.Parse(txtCurrentBalance.Text))
            {
                WarningAlert($"Your current balance is {txtCurrentBalance.Text}");
                return;
            }

            if (double.Parse(txtPoints.Text) < 100)
            {
                WarningAlert("Minimum Withdrawal is 100");
                return;
            }


            Save();

        }

        private void Save()
        {
            lp.SaveAgentPoints(0, int.Parse(Session["userid"].ToString()), -int.Parse(txtPoints.Text), 0, 0, 0,true, 1);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Withdrawal successful, now awaiting authorization');window.location ='../agent/my-withdrawals';", true);
        }
    }
}