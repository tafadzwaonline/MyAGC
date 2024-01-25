using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyAGC.Classes
{
    public class BroadcastMessagesList : ErrorLog
    {
        #region "Variables"

        protected string mMsgFlg;
        protected long mID;
        protected long mCreatedBy;
        protected long mStatusID;
        protected string mDateCreated;
        protected string mSenderEmail;
        protected string mBroadcastMessgeTitle;

        protected string mMessageType;
        protected Database db;
        protected string mConnectionName;

        protected long mObjectUserID;
        #endregion

        #region "Properties"
        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { mMsgFlg = value; }
        }
        public Database Database
        {
            get { return db; }
        }

        public string OwnerType
        {
            get { return this.GetType().Name; }
        }

        public string ConnectionName
        {
            get { return mConnectionName; }
        }

        public long ID
        {
            get { return mID; }
            set { mID = value; }
        }

        public long CreatedBy
        {
            get { return mCreatedBy; }
            set { mCreatedBy = value; }
        }

        public long StatusID
        {
            get { return mStatusID; }
            set { mStatusID = value; }
        }

        public string DateCreated
        {
            get { return mDateCreated; }
            set { mDateCreated = value; }
        }

        public string SenderEmail
        {
            get { return mSenderEmail; }
            set { mSenderEmail = value; }
        }

        public string BroadcastMessgeTitle
        {
            get { return mBroadcastMessgeTitle; }
            set { mBroadcastMessgeTitle = value; }
        }

        public string MessageType
        {
            get { return mMessageType; }
            set { mMessageType = value; }
        }

        #endregion

        #region "Methods"

        #region "Constructors"


        public BroadcastMessagesList(string ConnectionName)
        {
            //mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        #endregion


        public void Clear()
        {
            mID = 0;
            mCreatedBy = mObjectUserID;
            mStatusID = 0;
            mDateCreated = "";
            mBroadcastMessgeTitle = "";
            mMessageType = "";

        }

        #region "Retrieve Overloads"

        public virtual bool Retrieve()
        {

            return this.Retrieve(mID);

        }

        public virtual bool Retrieve(long ID)
        {

            string sql = null;

            if (ID > 0)
            {
                sql = "SELECT * FROM BroadcastMessagesList WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM BroadcastMessagesList WHERE ID = " + mID;
            }

            return Retrieve(sql);

        }
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
        protected virtual bool Retrieve(string sql)
        {


            try
            {
                DataSet dsRetrieve = db.ExecuteDataSet(CommandType.Text, sql);


                if (dsRetrieve != null && dsRetrieve.Tables.Count > 0 && dsRetrieve.Tables[0].Rows.Count > 0)
                {
                    LoadDataRecord(dsRetrieve.Tables[0].Rows[0]);

                    dsRetrieve = null;
                    return true;


                }
                else
                {
                    SetErrorDetails("BroadcastMessagesList not found.");

                    return false;

                }


            }
            catch (Exception e)
            {
                SetErrorDetails(e.Message);
                return false;

            }

        }

        public virtual System.Data.DataSet GetBroadcastMessagesList()
        {

            return GetBroadcastMessagesList(mID);

        }
        public bool UpdateEmailListStatus(int BroadcastID, long PensionNo)
        {
            string str = "update BroadcastListContacts set StatusID=2 where BroadCastListID=" + BroadcastID + " and PensionNo=" + PensionNo + "";
            db.ExecuteNonQuery(CommandType.Text, str);
            return true;

        }

        public bool UpdateEmailListStatusFailed(int BroadcastID, long PensionNo)
        {
            string str = "update BroadcastListContacts set StatusID=3 where BroadCastListID=" + BroadcastID + " and PensionNo=" + PensionNo + "";
            db.ExecuteNonQuery(CommandType.Text, str);
            return true;

        }

        public virtual DataSet GetBroadcastMessagesList(long ID)
        {

            string sql = null;

            if (ID > 0)
            {
                sql = "SELECT * FROM BroadcastMessagesList WHERE ID = " + ID;
            }
            else
            {
                sql = "SELECT * FROM BroadcastMessagesList WHERE ID = " + mID;
            }

            return GetBroadcastMessagesList(sql);

        }

        protected virtual DataSet GetBroadcastMessagesList(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }

        #endregion


        protected internal virtual void LoadDataRecord(DataRow rw)
        {


            mID = ((object)rw["ID"] == DBNull.Value) ? 0 : int.Parse(rw["ID"].ToString());
            mCreatedBy = ((object)rw["CreateBy"] == DBNull.Value) ? 0 : int.Parse(rw["CreateBy"].ToString());
            mStatusID = ((object)rw["StatusID"] == DBNull.Value) ? 0 : int.Parse(rw["StatusID"].ToString());
            mDateCreated = ((object)rw["DateCreated"] == DBNull.Value) ? string.Empty : rw["DateCreated"].ToString();
            mBroadcastMessgeTitle = ((object)rw["BroadcastMessgeTitle"] == DBNull.Value) ? string.Empty : rw["BroadcastMessgeTitle"].ToString();
            mMessageType = ((object)rw["MessageType"] == DBNull.Value) ? string.Empty : rw["MessageType"].ToString();


        }

        public DataSet getUnassignedContacts(int BroadcastListID)
        {
            try
            {
                string str = "select m.ID,m.Name as Pensioner ,Email from Employees m where Email like '%@%' and m.ID not in (select distinct(PensionNo) from BroadcastListContacts where BroadCastListID = " + BroadcastListID + " ) order by m.ID desc";
                return ReturnDs(str);

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet getUnassignedSystemUsers(int BroadcastListID,int RoleID)
        {

            DataSet ds = null;

            string str = "sp_getUnassignedSystemUsers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@BroadcastListID", DbType.Int32, BroadcastListID);
            db.AddInParameter(cmd, "@RoleID", DbType.Int32, RoleID);

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
      

        public DataSet getassignedContacts(int BroadcastListID)
        {
            try
            {
                string str = "select m.ID,m.Name as Pensioner ,Email from Employees m where Email like '%@%' and m.ID in (select distinct(PensionNo) from BroadcastListContacts where BroadCastListID = " + BroadcastListID + " ) order by m.Id desc";
                return ReturnDs(str);

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
       
        public DataSet getassignedSystemUsers(int BroadcastListID, int RoleID)
        {

            DataSet ds = null;

            string str = "sp_getassignedSystemUsers";
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);
            db.AddInParameter(cmd, "@BroadcastListID", DbType.Int32, BroadcastListID);
            db.AddInParameter(cmd, "@RoleID", DbType.Int32, RoleID);

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
        #region "Save"


        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            db.AddInParameter(cmd, "@ID", DbType.Int32, mID);
            db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, mObjectUserID);
            db.AddInParameter(cmd, "@StatusID", DbType.Int32, mStatusID);
            db.AddInParameter(cmd, "@DateCreated", DbType.String, mDateCreated);
            db.AddInParameter(cmd, "@BroadcastMessgeTitle", DbType.String, mBroadcastMessgeTitle);
            db.AddInParameter(cmd, "@MessageType", DbType.String, mMessageType);
            //db.AddInParameter(cmd, "@SenderEmail", DbType.String, mSenderEmail);

        }
     

        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_BroadcastMessagesList");

            GenerateSaveParameters(ref db, ref cmd);

            try
            {
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    mID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

                }

                return true;

            }
            catch (Exception ex)
            {
                SetErrorDetails(ex.Message);
                return false;
            }

        }

        #endregion

        #region "Delete"

        public virtual bool Delete()
        {

            //Return Delete("UPDATE BroadcastMessagesList SET Deleted = 1 WHERE ID = " & mID) 
            return Delete("DELETE FROM BroadcastMessagesList WHERE ID = " + mID);

        }

        protected virtual bool Delete(string DeleteSQL)
        {


            try
            {
                db.ExecuteNonQuery(CommandType.Text, DeleteSQL);
                return true;


            }
            catch (Exception e)
            {
                SetErrorDetails(e.Message);
                return false;

            }

        }

        #endregion

        #endregion

    }
}