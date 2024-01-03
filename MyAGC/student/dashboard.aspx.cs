using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.student
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WarningAlert("wadii");
            }
            
        }

        protected void SuccessAlert(string Msg)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>success('" + Msg + "', '../student/dashboard')</script>", false);
        }
        protected void WarningAlert(string Err)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>warning('" + Err + "')</script>", false);
        }
    }
}