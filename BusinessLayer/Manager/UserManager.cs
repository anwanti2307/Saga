using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BusinessLayer.Manager
{
    public class UserManager
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        public List<SessionObject.User> ValidateUser(string EmailID, string Password, bool IsUser = false,bool IsAdmin = false)
        {
            SqlConnection con = new SqlConnection(strcon);
            //int Count = 0;
            //bool IsValid = false;
            DataTable dt = new DataTable();
            List<SessionObject.User> User = new List<SessionObject.User>();

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("ValidateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1800;
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@IsUser", IsUser);
                cmd.Parameters.AddWithValue("@IsAdmin", IsAdmin);
                con.Open();
                //var result = cmd.ExecuteScalar();
                //IsValid = result != null ? (int)result > 0 : false;
                SqlDataAdapter sqlData = new SqlDataAdapter();
                sqlData.SelectCommand = cmd;
                sqlData.Fill(ds, "table");
                if (ds!= null && ds.Tables.Count>0)
                    dt=ds.Tables[0];
                User = (from DataRow dr in dt.Rows
                               select new SessionObject.User()
                               {
                                   UserID =(Convert.ToInt32(dr["UserID"])),
                                   EmailId  = dr["EmailID"].ToString(),
                                   Password = dr["Passwords"].ToString(),
                                   FirstName = dr["Firstname"].ToString(),
                                   LastName = dr["Lastname"].ToString(),
                                   MobileNo = dr["MobileNo"].ToString()
                               }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return User;
        }

    }
}