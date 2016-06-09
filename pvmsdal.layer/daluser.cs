//date access layer for user registration
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pvmsentity.layer;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data;

namespace pvmsdal.layer
{
    public class daluser
    {
        SqlConnection con = null;//connection variable
        SqlCommand cmd = null;//command variable
        SqlDataReader dr = null;//datareader
        public void getconnection()
        {
            
            //connection string
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["passport-visaConnectionString"].ConnectionString);
            
            
        }
        public int registerid(SqlParameter[] a)
        {
            //get new user id
                getconnection();
                con.Open();
                cmd = new SqlCommand("newuserid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(a);
                cmd.ExecuteReader();
                int i = (int)a[1].Value;
                con.Close();
                return i;
           
            
           
        }
        public void registeruser(SqlParameter[] c)
        {
            //insert user details
            getconnection();
            con.Open();
            cmd = new SqlCommand("insertuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(c);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public bool loginuser(SqlParameter[] d)
        {
            //check login
            getconnection();
            con.Open();
            cmd = new SqlCommand("userlogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(d);
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }

        }
        public bool forgotpass(SqlParameter[] e)
        {
            //check hint question and answer for password reset
            getconnection();
            con.Open();
            cmd = new SqlCommand("forgotpassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(e);
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        public void resetpass(SqlParameter[] f)
        {
            //update password
            getconnection();
            con.Open();
            cmd = new SqlCommand("newpassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(f);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<string> getqualification()
        {
            //get qualification list
            getconnection();
            con.Open();
            List<string> a2 = new List<string>();
            cmd = new SqlCommand("selectqualification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                a2.Add((string)dr[0].ToString());
            }
            con.Close();
            return a2;
        }
        public List<string> getapplytype()
        {
            //get apply type list
            getconnection();
            con.Open();
            List<string> b2 = new List<string>();
            cmd = new SqlCommand("selectapplytype", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                b2.Add((string)dr[0].ToString());
            }
            con.Close();
            return b2;
        }
        public List<string> getquestions()
        {
            //get hint question list
            getconnection();
            con.Open();
            List<string> que2 = new List<string>();
            cmd = new SqlCommand("getquestions", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(f);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                que2.Add(dr[0].ToString());
            }
            con.Close();
            return que2;
        }
    }
}
