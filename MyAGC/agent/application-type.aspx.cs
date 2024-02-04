using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyAGC.agent
{
    public partial class application_type : System.Web.UI.Page
    {
        readonly UsersManagement um = new UsersManagement("con");
        readonly LookUp lp = new LookUp("con");
        QueryStringModule qn = new QueryStringModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtID.Value = "0";
                txtCollegeID.Value = "0";
                txtPeriodID.Value = "0";

                txtProgramID.Value = "0";
                if (Request.QueryString["CollegeID"].ToString() != null)
                {
                    txtCollegeID.Value = Request.QueryString["CollegeID"].ToString();
                }
                if (Request.QueryString["PeriodID"].ToString() != null)
                {
                    txtPeriodID.Value = Request.QueryString["PeriodID"].ToString();
                }
                if (Request.QueryString["ProgramID"].ToString() != null)
                {
                    txtProgramID.Value = Request.QueryString["ProgramID"].ToString();
                }
                


            }
        }

        protected void rdStudent_CheckedChanged(object sender, EventArgs e)
        {
            //Response.Redirect(string.Format("../agent/student-information?CollegeID={0}&PeriodID={1}&ProgramID={2}", EcryptedCollegeID, EcryptedPeriodID, EcryptedProgramID), false);
            Response.Redirect(string.Format("../agent/student-information?CollegeID=" + txtCollegeID.Value + "&PeriodID=" + txtPeriodID.Value + "&ProgramID=" + txtProgramID.Value + ""));
        }

        protected void rdExisting_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../agent/select-student?CollegeID=" + txtCollegeID.Value + "&PeriodID=" + txtPeriodID.Value + "&ProgramID=" + txtProgramID.Value + ""));
        }
    }
}