using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyAGC
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
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