using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SessionState"] != null && Request.QueryString["SessionState"].ToString() == "1")
                {

                    Session["Email"] = "";
                }

                if (Session["Email"] == null || string.IsNullOrEmpty(Session["Email"].ToString()))
                {
                    Session.Remove("userid");
                    Session.Remove("username");
                    Session.Remove("roleid");
                    Session.Clear();
                }

                
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorMessages.Add("Email is required");
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorMessages.Add("Password is required");
            }

            if (txtEmail.Text.Contains("'"))
            {
                txtEmail.Text = txtEmail.Text.Replace("'", "");
            }

            if (!txtEmail.Text.Contains("@"))
            {
                errorMessages.Add("Please enter a valid email address");
            }



            if (errorMessages.Count > 0)
            {
                lblLoginError.Text = string.Join("<br>", errorMessages);
                return;
            }

            LoginDetails();
        }

        private void LoginDetails()
        {
            try
            {
                
                QueryStringModule querystring = new QueryStringModule();
                UsersManagement su = new UsersManagement("con");

                if (su.ValidateUserLoginCreds(txtEmail.Text, txtPassword.Text))
                {
                    if (su.UserDetails != null)
                    {
                        //check if user is blocked or not
                        bool Status = Convert.ToBoolean(su.UserDetails.Tables[0].Rows[0]["Active"].ToString());

                        if (!Status)
                        {
                            lblLoginError.Text = $"User account is blocked. Please contact your administrator";
                            return;
                        }

                        Session["userid"] = su.UserDetails.Tables[0].Rows[0]["UserID"].ToString();
                        Session["username"] = su.UserDetails.Tables[0].Rows[0]["Email"].ToString();
                        Session["roleid"] = su.UserDetails.Tables[0].Rows[0]["RoleID"].ToString();

                        if (int.Parse(Session["roleid"].ToString()) == 1)
                        {
                            Response.Redirect(string.Format("Admin/dashboard"));
                        }
                        else if (int.Parse(Session["roleid"].ToString()) == 2)
                        {
                            Response.Redirect(string.Format("institution/dashboard"));
                        }
                        else
                        {
                            Response.Redirect(string.Format("student/dashboard"));
                        }

                    }
                    else
                    {
                        Session["userid"] = "0";
                        Session["roleid"] = "0";
                        Session["username"] = "";
                    }
                }
                else
                {
                    lblLoginError.Text = su.MsgFlg;
                }
            }
            catch (Exception ex)
            {
                lblLoginError.Text = ex.ToString();

            }
        }
    }
}