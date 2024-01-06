using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyAGC.student
{
    /// <summary>
    /// Summary description for StudentImageHandler
    /// </summary>
    public class StudentImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            try
            {
                SqlDataReader rdr = null;
                SqlConnection conn = null;
                SqlCommand selcmd = null;

            
                long UserID = long.Parse(context.Request.QueryString["UserID"]);
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                selcmd = new SqlCommand("select Image from Users where UserID=" + UserID + "", conn);
                conn.Open();
                rdr = selcmd.ExecuteReader();
                while (rdr.Read())
                {
                    context.Response.ContentType = "image/jpg";

                    context.Response.BinaryWrite((byte[])rdr["Image"]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {

            }
            //finally
            //{
            //    conn.Close();
            //}

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}