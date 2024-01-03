
using Microsoft.Practices.EnterpriseLibrary.Data;
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

       
        public DataSet getEmailSettings()
        {
            string str = "sp_getEmailSettings";
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
        public void UpdateVerificationCode(int Code, string Email)
        {

            string str = "sp_UpdateVerificationCode";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@Code", DbType.Int32, Code);
            db.AddInParameter(cmd, "@Email", DbType.String, Email);

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