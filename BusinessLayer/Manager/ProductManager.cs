using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BusinessLayer.Manager
{
    public class ProductManager
    {
        
            //Get connection string from web.config file  
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
           
       
        public DataTable GetProductList(int Types, int ProductTypeId=0)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("GetProductList",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1800;
                cmd.Parameters.AddWithValue("@Type", Types);
                cmd.Parameters.AddWithValue("@ProductTypeId", ProductTypeId);
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter();
                sqlData.SelectCommand = cmd;
                sqlData.Fill(ds, "table");
                if (ds!= null && ds.Tables.Count>0)
                dt=ds.Tables[0];
                return dt;
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
        }

        public DataTable GetProductImages(int ID)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("GetProductImages", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1800;
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter();
                sqlData.SelectCommand = cmd;
                sqlData.Fill(ds, "table");
                if (ds!= null && ds.Tables.Count>0)
                    dt=ds.Tables[0];
                return dt;
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
        }

        public int SaveCartProduct(int ProductID,int UserID,string Size)
        {
            SqlConnection con = new SqlConnection(strcon);
            int Count = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SaveCartProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1800;
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@Size", Size);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Count = dr.GetInt32(0);
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
            return Count;
        }

        public DataTable GetCartProduct(int UserId)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("GetCartProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1800;
                cmd.Parameters.AddWithValue("@UserID", UserId);
            
                con.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter();
                sqlData.SelectCommand = cmd;
                sqlData.Fill(ds, "table");
                if (ds!= null && ds.Tables.Count>0)
                    dt=ds.Tables[0];
                return dt;
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
        }

        public int UpdateCartValue(int CartId, int UserID, int UpdateType,bool IsChecked=false)
        {
            SqlConnection con = new SqlConnection(strcon);
            int Updated = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateCartValue", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1800;
                cmd.Parameters.AddWithValue("@CartId", CartId);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@UpdateType", UpdateType);
                cmd.Parameters.AddWithValue("@IsChecked", IsChecked);
               
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Updated = dr.GetInt32(0);
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
            return Updated;
        }
      
    }
}