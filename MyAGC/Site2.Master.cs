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
    public partial class Site2 : System.Web.UI.MasterPage
    {
        LookUp lp = new LookUp("con");
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                DataRow rw = lp.getSystemUserById(int.Parse(Session["userid"].ToString())).Tables[0].Rows[0];
                lblUsername.Text = $"{rw["FirstName"]} {rw["LastName"]}";
                LoadClientImage();
            }
            else
            {
                
                Response.Redirect("../login.aspx");
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
    }
}