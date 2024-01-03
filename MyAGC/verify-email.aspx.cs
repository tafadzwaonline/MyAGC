using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC
{
    public partial class verify_email : System.Web.UI.Page
    {
        readonly LookUp look = new LookUp("con");
        readonly UsersManagement um = new UsersManagement("con");
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (!IsPostBack)
            {
                lblSuccess.Text = "Please check your email to get verification code";
            }
        }

        protected void BtnValidate_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                lblLoginError.Text = "Please enter verification code send to your email";
                return;
            }
            // Send the code to the user's email
            VerifyCode(int.Parse(txtCode.Text));
        }
        private void VerifyCode(int code)
        {
            try
            {
                QueryStringModule querystring = new QueryStringModule();
                if (!look.IsVerificationCodeExists(code))
                {
                    lblLoginError.Text = "Verification code does not exists";
                    return;
                }

                string UserID = look.getUserByCode(code);
                string EcryptedID = HttpUtility.UrlEncode(querystring.Encrypt(UserID));
                Response.Redirect(string.Format("~/change-password.aspx?id={0}", EcryptedID), false);


            }
            catch (Exception ex)
            {

                lblLoginError.Text = ex.ToString();
            }
        }
    }
}