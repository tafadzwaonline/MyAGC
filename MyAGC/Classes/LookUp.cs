
using Microsoft.Practices.EnterpriseLibrary.Data;
using MyAGC.student;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyAGC.Classes
{
    public class LookUp
    {
        #region "Variables"

        protected DataSet mUserDetails;
        protected long mID;
        protected string mMsgFlg;
        protected string mCount;
        protected Database db;
        protected string mConnectionName;

        protected long mObjectUserID;
        #endregion

        #region "Properties"
        public DataSet UserDetails
        {
            get { return mUserDetails; }
            set { mUserDetails = value; }
        }
        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { mMsgFlg = value; }
        }

        public Database Database
        {
            get { return db; }
        }

        public string ConnectionName
        {
            get { return mConnectionName; }
        }

        #endregion

        #region "Methods"




        #region "Constructors"


        public LookUp(string ConnectionName)
        {
            //mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        #endregion

        protected DataSet ReturnDs(string str)
        {
            try
            {
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }



        #region "Save"

        public void SaveAcademicRecords(int UserID, string SchoolName, int SchoolLevel, string StartDateMonth, string StartDateYear, string EndDateMonth, string EndDateYear,
            int SubjectsPassedNo,int ExaminationBody,string Activities)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("AcademicHistory_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@SchoolName", SqlDbType.NVarChar).Value = SchoolName;
                sql_cmnd.Parameters.AddWithValue("@SchoolLevel", SqlDbType.Int).Value = SchoolLevel;
                sql_cmnd.Parameters.AddWithValue("@StartDateMonth", SqlDbType.NVarChar).Value = StartDateMonth;
                sql_cmnd.Parameters.AddWithValue("@StartDateYear", SqlDbType.NVarChar).Value = StartDateYear;
                sql_cmnd.Parameters.AddWithValue("@EndDateMonth", SqlDbType.NVarChar).Value = EndDateMonth;
                sql_cmnd.Parameters.AddWithValue("@EndDateYear", SqlDbType.DateTime).Value = EndDateYear;
                sql_cmnd.Parameters.AddWithValue("@SubjectsPassedNo", SqlDbType.Int).Value = SubjectsPassedNo;
                sql_cmnd.Parameters.AddWithValue("@ExaminationBody", SqlDbType.Int).Value = ExaminationBody;
                sql_cmnd.Parameters.AddWithValue("@Activities", SqlDbType.NVarChar).Value = Activities;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        //public DataSet getSearchColleges(int Criteria,string Value)
        //{
             
        //    DataSet ds = null;

        //    string str = "sp_SearchCollege";
        //    System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
        //    db.AddInParameter(cmd, "@Criteria", DbType.Int32, Criteria);
        //    db.AddInParameter(cmd, "@Value", DbType.String, Value);
        //    ds = db.ExecuteDataSet(cmd);



        //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        return ds;

        //    }
        //    else
        //    {
        //        return null;
        //    }


        //}


        public DataSet getSearchUsers(int Criteria,int RoleID, string Value)
        {

            DataSet ds = null;

            string str = "sp_SearchUsers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Criteria", DbType.Int32, Criteria);
            db.AddInParameter(cmd, "@RoleID", DbType.Int32, RoleID);
            db.AddInParameter(cmd, "@Value", DbType.String, Value);
            ds = db.ExecuteDataSet(cmd);



            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }


        }


        public DataSet getSearchPayments(int Criteria, int RoleID, string Value)
        {

            DataSet ds = null;

            string str = "sp_SearchUsers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Criteria", DbType.Int32, Criteria);
            db.AddInParameter(cmd, "@RoleID", DbType.Int32, RoleID);
            db.AddInParameter(cmd, "@Value", DbType.String, Value);
            ds = db.ExecuteDataSet(cmd);



            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }


        }

        public DataSet getStudentApplications(int ApplicantID, int CollegeID, int PeriodID)
        {

            DataSet ds = null;

            string str = "sp_getApplications";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ApplicantID", DbType.Int32, ApplicantID);
            db.AddInParameter(cmd, "@CollegeID", DbType.String, CollegeID);
            db.AddInParameter(cmd, "@PeriodID", DbType.String, PeriodID);
            ds = db.ExecuteDataSet(cmd);



            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }


        }
        public bool IsProgramApplied(int ApplicantID, int CollegeID, int PeriodID, int ProgramID)
        {
            try
            {
                string str = "sp_ValidateApplications";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
                
                db.AddInParameter(cmd, "@ApplicantID", DbType.Int32, ApplicantID);
                db.AddInParameter(cmd, "@CollegeID", DbType.Int32, CollegeID);
                db.AddInParameter(cmd, "@PeriodID", DbType.Int32, PeriodID);
                db.AddInParameter(cmd, "@ProgramID", DbType.Int32, ProgramID);

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public void SaveAcademicCalendar(int UserID,string StartDateMonth, string StartDateYear, string EndDateMonth, string EndDateYear, int Intake, DateTime ApplicationDeadline)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("AcademicCalendar_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;

                sql_cmnd.Parameters.AddWithValue("@StartDateMonth", SqlDbType.NVarChar).Value = StartDateMonth;
                sql_cmnd.Parameters.AddWithValue("@StartDateYear", SqlDbType.NVarChar).Value = StartDateYear;
                sql_cmnd.Parameters.AddWithValue("@EndDateMonth", SqlDbType.NVarChar).Value = EndDateMonth;
                sql_cmnd.Parameters.AddWithValue("@EndDateYear", SqlDbType.NVarChar).Value = EndDateYear;
                sql_cmnd.Parameters.AddWithValue("@Intake", SqlDbType.Int).Value = Intake;
                sql_cmnd.Parameters.AddWithValue("@ApplicationDeadline", SqlDbType.Date).Value = ApplicationDeadline;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SaveEmailList(DateTime DateSent, string EmailAddress, string Subject, string Target, int StatusID, string Message)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SaveBroadCastMessage_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@DateSent", SqlDbType.Date).Value = DateSent;
                sql_cmnd.Parameters.AddWithValue("@EmailAddress", SqlDbType.NVarChar).Value = EmailAddress;
                sql_cmnd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = Subject;
                sql_cmnd.Parameters.AddWithValue("@Target", SqlDbType.NVarChar).Value = Target;
                sql_cmnd.Parameters.AddWithValue("@StatusID", SqlDbType.Int).Value = StatusID;
                sql_cmnd.Parameters.AddWithValue("@Message", SqlDbType.Int).Value = Message;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SaveSmsList(int ID, int StatusID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SaveBroadCastSms_Upd", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.Parameters.AddWithValue("@StatusID", SqlDbType.Int).Value = StatusID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public void SaveApplicationFees(int UserID, int AcademicCalendarID, double Amount, int CitizenID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("ApplicationFees_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@AcademicCalendarID", SqlDbType.Int).Value = AcademicCalendarID;
                sql_cmnd.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Amount;
                sql_cmnd.Parameters.AddWithValue("@CitizenID", SqlDbType.Int).Value = CitizenID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SavePrograms(int UserID, int Duration, int FacultyID, string ProgramName, string Requirements,double Tuition)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Program_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@Duration", SqlDbType.Int).Value = Duration;
                sql_cmnd.Parameters.AddWithValue("@FacultyID", SqlDbType.Int).Value = FacultyID;
                sql_cmnd.Parameters.AddWithValue("@ProgramName", SqlDbType.NVarChar).Value = ProgramName;
                sql_cmnd.Parameters.AddWithValue("@Requirements", SqlDbType.NVarChar).Value = Requirements;
                sql_cmnd.Parameters.AddWithValue("@Tuition", SqlDbType.Float).Value = Tuition;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public void SaveFaculty(int UserID, string FacultyName)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Faculty_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@FacultyName", SqlDbType.NVarChar).Value = FacultyName;
;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SaveApplication(int ApplicantID, int CollegeID, int ProgramID, int PeriodID,int AgentID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Applications_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ApplicantID", SqlDbType.Int).Value = ApplicantID;
                sql_cmnd.Parameters.AddWithValue("@CollegeID", SqlDbType.Int).Value = CollegeID;
                sql_cmnd.Parameters.AddWithValue("@ProgramID", SqlDbType.Int).Value = ProgramID;
                sql_cmnd.Parameters.AddWithValue("@PeriodID", SqlDbType.Int).Value = PeriodID;
                sql_cmnd.Parameters.AddWithValue("@ApplicationStatusID", SqlDbType.Int).Value = 4;
                sql_cmnd.Parameters.AddWithValue("@AgentID", SqlDbType.Int).Value = AgentID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public void SaveAgentPoints(int ApplicantID, int AgentID, int Points,int CollegeID,int PeriodID,int ProgramID,bool StatusID,int PaymentStatusID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("AgentPoints_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ApplicantID", SqlDbType.Int).Value = ApplicantID;
                sql_cmnd.Parameters.AddWithValue("@AgentID", SqlDbType.Int).Value = AgentID;
                sql_cmnd.Parameters.AddWithValue("@Points", SqlDbType.Int).Value = Points;
                sql_cmnd.Parameters.AddWithValue("@PeriodID", SqlDbType.Int).Value = PeriodID;
                sql_cmnd.Parameters.AddWithValue("@ProgramID", SqlDbType.Int).Value = ProgramID;
                sql_cmnd.Parameters.AddWithValue("@CollegeID", SqlDbType.Int).Value = CollegeID;
                sql_cmnd.Parameters.AddWithValue("@StatusID", SqlDbType.Bit).Value = StatusID;
                sql_cmnd.Parameters.AddWithValue("@PaymentStatusID", SqlDbType.Int).Value = PaymentStatusID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SavePayment(int ApplicantID, int CollegeID, int ProgramID, int PeriodID,string UserEmail,decimal Amount,string PollUrl,int Paynowrefence)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Payment_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ApplicantID", SqlDbType.Int).Value = ApplicantID;
                sql_cmnd.Parameters.AddWithValue("@CollegeID", SqlDbType.Int).Value = CollegeID;
                sql_cmnd.Parameters.AddWithValue("@ProgramID", SqlDbType.Int).Value = ProgramID;
                sql_cmnd.Parameters.AddWithValue("@PeriodID", SqlDbType.Int).Value = PeriodID;
                sql_cmnd.Parameters.AddWithValue("@UserEmail", SqlDbType.NVarChar).Value = UserEmail;
                sql_cmnd.Parameters.AddWithValue("@Amount", SqlDbType.Float).Value = Amount;
                sql_cmnd.Parameters.AddWithValue("@Platform", SqlDbType.NVarChar).Value = "Pay Now";
                sql_cmnd.Parameters.AddWithValue("@Currency", SqlDbType.NVarChar).Value = "USD";
                sql_cmnd.Parameters.AddWithValue("@PollUrl", SqlDbType.NVarChar).Value = PollUrl;
                sql_cmnd.Parameters.AddWithValue("@PayNowReference", SqlDbType.Int).Value = Paynowrefence;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public void SaveEmailSettings(int UserID,string Email,string Password,string Host, int Port)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SaveEmail_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Password;
                sql_cmnd.Parameters.AddWithValue("@Host", SqlDbType.NVarChar).Value = Host;
                sql_cmnd.Parameters.AddWithValue("@Port", SqlDbType.Int).Value = Port;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void SaveSmsSettings(int UserID, string SenderName, string Password, string SenderNumber)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("SaveSms_Ins", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                sql_cmnd.Parameters.AddWithValue("@SenderName", SqlDbType.NVarChar).Value = SenderName;
                sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Password;
                sql_cmnd.Parameters.AddWithValue("@SenderNumber", SqlDbType.NVarChar).Value = SenderNumber;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        public bool SaveClientImage(long UserID, Byte[] bytes)
        {
            try
            {

                string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection sqlCon = null;
                using (sqlCon = new SqlConnection(constr))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("sp_SaveInage", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = UserID;
                    sql_cmnd.Parameters.AddWithValue("@Image", SqlDbType.VarBinary).Value = bytes;
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public void DeleteUploadedDocument(int ID)
        {

            string str = "sp_DeleteUploadedDocument";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, ID);

            DataSet ds = db.ExecuteDataSet(cmd);

        }
        public void RemoveAcademicHistory(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("AcademicHistory_Del", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RemoveAcademicCalendar(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("AcademicCalendar_Del", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RemoveFaculty(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Faculty_Del", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RemoveProgram(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Program_Del", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
               
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void ApproveApplication(int ApplicationID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ApproveApplication", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void ApproveAgentCommision(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ApproveAgentCommission", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RejectAgentCommision(int ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("[sp_RejectAgentCommission", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void RejectApplication(int ApplicationID)
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sqlCon = null;
            using (sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_RejectApplication", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public DataSet getSavedEmailSettings(int UserID)
        {
            string str = "sp_getEmailSettings";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }

        public DataSet getApplicationStatus()
        {
            string str = "sp_getApplicationStatus";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }


        public DataSet getSavedSmsSettings(int UserID)
        {
            string str = "sp_getSmsSettings";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }

        public DataSet getCertificateFileUploads(int UserID)
        {

            string str = "sp_getCertificateFileUploads";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getAcceptanceLetters(int UserID)
        {

            string str = "sp_getAcceptanceLetters";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getAcceptanceLettersByCollegeID(int CollegeID)
        {

            string str = "sp_getAcceptanceLettersByCollege";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, CollegeID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getAcceptanceLettersByApplicationID(int ApplicationID)
        {

            string str = "sp_getAcceptanceLettersByApplicationID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ApplicationID", DbType.Int32, ApplicationID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getAllAcceptanceLetters()
        {

            string str = "sp_getAllAcceptanceLetters";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@UserID", DbType.Int32, CollegeID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getUploadedProofOfPaymentsByApplicantID(int ApplicantID)
        {

            string str = "sp_getProofOfPaymentsByApplicantID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ApplicantID", DbType.Int32, ApplicantID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getUploadedProofOfPaymentsByCollegeID(int CollegeID)
        {

            string str = "sp_getProofOfPaymentsByCollegeID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@CollegeID", DbType.Int32, CollegeID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getUploadedProofOfPayments()
        {

            string str = "sp_getAllProofOfPayments";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getFaculty(int UserID)
        {

            string str = "sp_getFaculty";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getDocumentFileUploads(int UserID)
        {

            string str = "sp_getDocumentFileUploads";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getEmailSettings(int UserID)
        {

            string str = "sp_getEmailSettings";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public DataSet getAllEmailSettings()
        {

            string str = "sp_getAllEmailSettings";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }

        }
        public void UploadDocument(string Name, string ContentType, byte[] Data, DateTime DateCreated, int UploadedBy, int DocTypeID)
        {

            string str = "sp_UploadCertificateDocument";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Name", DbType.String, Name);
            db.AddInParameter(cmd, "@ContentType", DbType.String, ContentType);
            db.AddInParameter(cmd, "@Data", DbType.Binary, Data);
            db.AddInParameter(cmd, "@DateCreated", DbType.DateTime, DateCreated);
            db.AddInParameter(cmd, "@UploadedBy", DbType.Int32, UploadedBy);
            db.AddInParameter(cmd, "@CertificateID", DbType.Int32, DocTypeID);

            DataSet ds = db.ExecuteDataSet(cmd);

        }
        public void UploadAcceptanceLetter(int ApplicationID,string Name, string ContentType, byte[] Data, int CollegeID,int ApplicantID,int PeriodID,int ProgramID)
        {

            string str = "sp_UploadAcceptanceLetter";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ApplicantionID", DbType.Int32, ApplicationID);
            db.AddInParameter(cmd, "@ApplicantID", DbType.Int32, ApplicantID);
            db.AddInParameter(cmd, "@CollegeID", DbType.Int32, CollegeID);
            db.AddInParameter(cmd, "@ProgramID", DbType.Int32, ProgramID);
            db.AddInParameter(cmd, "@PeriodID", DbType.Int32, PeriodID);
            db.AddInParameter(cmd, "@Name", DbType.String, Name);
            db.AddInParameter(cmd, "@ContentType", DbType.String, ContentType);
            db.AddInParameter(cmd, "@Data", DbType.Binary, Data);

            DataSet ds = db.ExecuteDataSet(cmd);

        }
        public void UploadProofOfPayment(string Name, string ContentType, byte[] Data, DateTime DateCreated, int UploadedBy, int CollegeID,int PeriodID,int ProgramID)
        {

            string str = "sp_UploadProofOfPayment";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Name", DbType.String, Name);
            db.AddInParameter(cmd, "@ContentType", DbType.String, ContentType);
            db.AddInParameter(cmd, "@Data", DbType.Binary, Data);
            db.AddInParameter(cmd, "@DateCreated", DbType.DateTime, DateCreated);
            db.AddInParameter(cmd, "@UploadedBy", DbType.Int32, UploadedBy);
            db.AddInParameter(cmd, "@CollegeID", DbType.Int32, CollegeID);
            db.AddInParameter(cmd, "@PeriodID", DbType.Int32, PeriodID);
            db.AddInParameter(cmd, "@ProgramID", DbType.Int32, ProgramID);

            DataSet ds = db.ExecuteDataSet(cmd);

        }
        public void UpdateVerificationCode(int Code, string Email)
        {

            string str = "sp_UpdateVerificationCode";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Code", DbType.Int32, Code);
            db.AddInParameter(cmd, "@Email", DbType.String, Email);

            DataSet ds = db.ExecuteDataSet(cmd);
        }
        public void UpdateStatus(int Status, int UserID)
        {

            string str = "sp_UpdateUserStatus";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Status", DbType.Int32, Status);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);

            DataSet ds = db.ExecuteDataSet(cmd);
        }
        public bool IsVerificationCodeExists(int Code)
        {
            try
            {
                string str = "sp_IsVerificationCodeExists";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
                db.AddInParameter(cmd, "@Code", DbType.Int32, Code);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public string getUserByCode(int Code)
        {

            try
            {
                string str = "sp_getUserByCode";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
                db.AddInParameter(cmd, "@code", DbType.Int32, Code);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "0";
            }
        }

        public DataSet getSystemUserById(int userid)
        {
            string str = "sp_getSystemUserById";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getSystemUserByEmail(string Email)
        {
            string str = "sp_getSystemUserEmail";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Email", DbType.String, Email);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAcademicHistory(int userid)
        {
            string str = "sp_getAcademicHistory";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAcademicCalendar(int userid)
        {
            string str = "sp_getAcademicCalendar";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getStudentApplicationByUserID(int userid)
        {
            string str = "sp_getApplicationByUserID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getPaymentsByApplicantID(int userid)
        {
            string str = "sp_getPaymentsByApplicantID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ApplicantID", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAgentStudents(int AgentID)
        {
            string str = "sp_getAgentStudents";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@AgentID", DbType.Int32, AgentID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAgentStudentsApplications(int AgentID)
        {
            string str = "sp_getAgentStudentsApplications";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@AgentID", DbType.Int32, AgentID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAgentPoints(int AgentID)
        {
            string str = "sp_getAgentPoints";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@AgentID", DbType.Int32, AgentID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAgentPointsByID(int AgentID)
        {
            string str = "sp_getAgentPointsByID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@AgentID", DbType.Int32, AgentID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAllAgentWithdrawals(int AgentID)
        {
            string str = "sp_getAllAgentWithdrawals";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@AgentID", DbType.Int32, AgentID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAllAgentPoints()
        {
            string str = "sp_getAllAgentPoints";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@AgentID", DbType.Int32, AgentID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getPaymentsByCollegeID(int CollegeID)
        {
            string str = "sp_getPaymentsByCollegeID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@CollegeID", DbType.Int32, CollegeID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAllPayments()
        {
            string str = "sp_getAllPayments";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            //db.AddInParameter(cmd, "@CollegeID", DbType.Int32, CollegeID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getPaymentsByPaymentID(int PaymentID)
        {
            string str = "sp_getPaymentsByPaymentID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@PaymentID", DbType.Int32, PaymentID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getStudentApplicationByID(int userid)
        {
            string str = "sp_getApplicationByID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getApplicationsAwaitingApproval(int userid)
        {
            string str = "sp_getApplicationAwaitingApproval";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Userid", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getApprovedApplications(int userid)
        {
            string str = "sp_getApprovedApplications";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Userid", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getAgentApplications(int AgentID)
        {
            string str = "sp_getApplicationsByAgent";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@AgentID", DbType.Int32, AgentID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getTotalApplications(int userid)
        {
            string str = "sp_getTotalApplications";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Userid", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getRejectedApplications(int userid)
        {
            string str = "sp_getRejectedApplications";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Userid", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }

        public DataSet getAcademicCalendarByID(int userid)
        {
            string str = "sp_getAcademicCalendarByID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getPrograms(int userid)
        {
            string str = "sp_getPrograms";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getProgramsByID(int userid)
        {
            string str = "sp_getProgramsByID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@ID", DbType.Int32, userid);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getApplicationFees(int userid, int AcademicCalendarID)
        {
            string str = "sp_getApplicationFees";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@UserID", DbType.Int32, userid);
            db.AddInParameter(cmd, "@ID", DbType.Int32, AcademicCalendarID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getApplicationFeesByID(int AcademicCalendarID, int CitizenID,int CollegeID)
        {
            string str = "sp_getApplicationFeesByID";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@CitizenID", DbType.Int32, CitizenID);
            db.AddInParameter(cmd, "@PeriodID", DbType.Int32, AcademicCalendarID);
            db.AddInParameter(cmd, "@CollegeID", DbType.Int32, CollegeID);

            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getCountry()
        {

            string str = "sp_getCountry";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getMonths()
        {

            string str = "sp_getMonths";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getYears()
        {

            string str = "sp_getYears";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getIntakes()
        {

            string str = "sp_getIntakes";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getCitizens()
        {

            string str = "sp_getCitizens";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getSchoolLevel()
        {

            string str = "sp_getSchoolLevel";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getExamBody()
        {

            string str = "sp_getExamBody";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }

        public DataSet getCertificates()
        {

            string str = "sp_getCertificates";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
       

        public DataSet getDocumentTypes()
        {

            string str = "sp_getDocumentType";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getGender()
        {

            string str = "sp_getGender";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getRelationTypes()
        {

            string str = "sp_getRelationTypes";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getDisabilityTypes()
        {

            string str = "sp_getDisabilityTypes";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getRaces()
        {

            string str = "sp_getRace";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getTitle()
        {

            string str = "sp_getTitle";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getReligion()
        {

            string str = "sp_getReligion";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getIdentityDocumentTypes()
        {

            string str = "sp_getIdentityDocumentTypes";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getUniversityTypes()
        {

            string str = "sp_getUniversityTypes";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }
        public DataSet getRoles()
        {

            string str = "sp_getRoles";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;

            }
            else
            {
                return null;
            }
        }

        public static class RandomGenerator
        {
            private static readonly Random random = new Random();

            public static int GenerateRandom6DigitNumber()
            {
                return random.Next(100000, 999999);
            }
        }


        #endregion

        protected void SetErrorDetails(string str)
        {
            mMsgFlg = str;
        }
        #endregion


    }
}