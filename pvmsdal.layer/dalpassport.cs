//date access layer for apply passport and passport renewal
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using pvmsentity.layer;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Globalization;

namespace pvmsdal.layer
{
    public class dalpassport
    {
        SqlConnection con = null;//connection variable
        SqlCommand cmd = null;//command variable
        SqlDataReader dr = null;//datareader
        public void getconnection()
        {
            //connection string
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["passport-visaConnectionString"].ConnectionString);
        }
        public string getstateid(SqlParameter[] a)
        {
            //get state id
            getconnection();
            con.Open();
            string id = "";
            cmd = new SqlCommand("getstateid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(a);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr[0].ToString();
                con.Close();
                return id;
            }
            else
            {
                con.Close();
            }
            return id;
        }
        public List<string> getcityname(SqlParameter[] b)
        {
            //get city for the state
            getconnection();
            con.Open();
            List<string> output = new List<string>();
            cmd = new SqlCommand("getcityname", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(b);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                output.Add(dr[0].ToString());
            }
            con.Close();
            return output;
        }
        public int passportid(SqlParameter[] c)
        {
            //next passport id
            getconnection();
            con.Open();
            cmd = new SqlCommand("newpassportid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(c);
            cmd.ExecuteReader();
            int id1 = (int)c[0].Value;
            con.Close();
            return id1;

        }

        public void appplypassport(SqlParameter[] d)
        {
            //insert passport details
            getconnection();
            con.Open();
            cmd = new SqlCommand("applypassport1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(d);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<string> gettos(SqlParameter[] e)
        {
            //get type of service
            getconnection();
            con.Open();
            List<string> tos2 = new List<string>();
            cmd = new SqlCommand("selecttypeofservice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tos2.Add((string)dr[0].ToString());
            }
            con.Close();
            return tos2;
        }
        public List<string> getbt(SqlParameter[] f)
        {
            //get booklet type
            getconnection();
            con.Open();
            List<string> bt2 = new List<string>();
            cmd=new SqlCommand("selectbooklettype",con);
            cmd.CommandType=CommandType.StoredProcedure;
            dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                bt2.Add((string)dr[0].ToString());
            }
            con.Close();
            return bt2;
        }
        public List<string> getstate(SqlParameter[] g)
        {
            //get state list
            getconnection();
            con.Open();
            List<string> state2 = new List<string>();
            cmd = new SqlCommand("selectstate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                state2.Add((string)dr[0].ToString());
            }
            con.Close();
            return state2;
        }
        public string[] getrenew(SqlParameter h)
        {
            //get passport details
            getconnection();
            con.Open();
            string[] a2 = new string[4];
            cmd = new SqlCommand("getrenewdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(h);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                a2[0] = dr["country"].ToString();
                a2[1] = dr["state"].ToString();
                a2[2] = dr["city"].ToString();
                a2[3] = dr["pin"].ToString();     
            }
            con.Close();
            return a2;
        }
        public bool passportlogin(SqlParameter[] i)
        {
            //check passport login
            getconnection();
            con.Open();
            bool f2;
            cmd = new SqlCommand("passportlogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(i);
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                f2=true;
            }
            else
            {
                f2=false;
            }
            con.Close();
            return f2;
        }
        
        public DateTime getexpirydate(SqlParameter j)
        {
            //get expiry date for passport renewal
            getconnection();
            con.Open();
            DateTime? dt2 =null;
            cmd = new SqlCommand("getexpirydate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(j);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                dt2 = Convert.ToDateTime(dr["expiry_date"]);
            }

            DateTime dt3 = Convert.ToDateTime(dt2);
            con.Close();
            return dt3;            
           
        }
        public void insertrenew(SqlParameter[] k)
        {
            //insert renewed passport details
            getconnection();
            con.Open();
            cmd = new SqlCommand("renewpass", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(k);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public bool checkduplicatepass(SqlParameter l)
        {
            //check for duplicate passport
            getconnection();
            con.Open();
            bool k2 = false;
            cmd = new SqlCommand("checkduplicatepass", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(l);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                k2 = true;
            }
            con.Close();
            return k2;
           
        }
        public DateTime getexpirydate1(SqlParameter m)
        {
            //get expiry date for passport
            getconnection();
            con.Open();
            DateTime? j2 = null;
            cmd = new SqlCommand("getexpiry1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(m);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                j2 = Convert.ToDateTime(dr["expiry_date"]);
            }
            con.Close();
            return Convert.ToDateTime(j2);
            
        }
    }

}

