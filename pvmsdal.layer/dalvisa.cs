//date access layer for apply visa and cancel visa
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pvmsentity.layer;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Configuration;

namespace pvmsdal.layer
{
    public class dalvisa
    {
        SqlConnection con = null;//connection variable
        SqlCommand cmd = null;//command varible
        SqlDataReader dr = null;//datareader 
        public void getconnection()
        {
            //connection string
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["passport-visaConnectionString"].ConnectionString);
        }
        entityvisa eobj2 = new entityvisa();// object for entity layer
        public bool passportlogin(SqlParameter[] a)
        {
            // validate login
            getconnection();
            con.Open();
            bool b2 = false;
            cmd = new SqlCommand("passportlogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(a);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                b2 = true;
            }
            con.Close();
            return b2;

        }
        public List<string> getdestination(SqlParameter[] b)
        {
            //get destination list
            getconnection();
            con.Open();
            List<string> des2 = new List<string>();
            cmd = new SqlCommand("getdestination", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddRange(b);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                des2.Add(dr[0].ToString());
            }
            con.Close();
            return des2;
        }
        public List<string> getoccupation(SqlParameter[] c)
        {
            //get occupation list
            getconnection();
            con.Open();
            List<string> occ2 = new List<string>();
            cmd = new SqlCommand("getoccupation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddRange(c);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                occ2.Add(dr[0].ToString());
            }
            con.Close();
            return occ2;
        }
        public int getnewvisaid(SqlParameter[] d)
        {
            //get next visa id
            getconnection();
            con.Open();
            int vid2 = 0;
            cmd = new SqlCommand("newvisaid1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(d);
            cmd.ExecuteReader();
            vid2 = (int)d[1].Value;
            con.Close();
            return vid2;
        }
        public void insertvisa(SqlParameter[] e)
        {
            //insert visa details
            getconnection();
            con.Open();
            cmd = new SqlCommand("applyvisa", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(e);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<string> getquestions()
        {
            //get secret question list
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
        public string[] validatequestions(SqlParameter f)
        {
            //validate secret question
            getconnection();
            con.Open();
            string[] w2 = new string[2];
            cmd = new SqlCommand("validquestion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(f);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                w2[0] = dr["question"].ToString();
                w2[1] = dr["answer"].ToString();
            }
            con.Close();
            return w2;
        }
        public string validuserpass(SqlParameter g)
        {
            //validate user id and passport id
            getconnection();
            con.Open();
            string x2 = "";
            cmd = new SqlCommand("validuserpass", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(g);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                x2 = dr["passport_id"].ToString();
            }
            con.Close();
            return x2;
        }
        public DateTime getexpiry(SqlParameter h)
        {
            //get expiry date for visa
            getconnection();
            con.Open();
            DateTime? dt2=null;
            cmd = new SqlCommand("getvisaexpiry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(h);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dt2 =Convert.ToDateTime( dr["date_of_expiry"].ToString());
            }
            con.Close();
            return Convert.ToDateTime(dt2);
        }
        public string[] getocc1(SqlParameter i)
        {
            //get occupation
            getconnection();
            con.Open();
            string[] s2 = new string[2];
            cmd = new SqlCommand("getocc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(i);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s2[0] = dr["occupation"].ToString();
                s2[1] = dr["cost"].ToString();
            }
            con.Close();
            return s2;
        }
        public void insertcancelvisa(SqlParameter[] j)
        {
            //insert cancelled visa details
            getconnection();
            con.Open();
            cmd =new SqlCommand("cancelvisa", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(j);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public bool checkduplicatevisaid(SqlParameter k)
        {
            //check already existing visa
            getconnection();
            con.Open();
            bool v2=false;
            cmd = new SqlCommand("checkduplicatevisaid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(k);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                v2 = true;
            }
            return v2;
        }
        public bool checkduplicatevisaid2(SqlParameter l)
        {
            //check already existing visa
            getconnection();
            con.Open();
            bool b02 = false;
            cmd = new SqlCommand("checkduplicatevisaid2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(l);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                b02 = true;
            }
            con.Close();
            return b02;
        }
        public bool checkduplicatevisaid1(SqlParameter m)
        {
            //check already existing visa
            getconnection();
            con.Open();
            bool b12 = false;
            cmd = new SqlCommand("checkduplicatevisaid1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(m);
            dr=cmd.ExecuteReader();
            if(dr.Read())
            {
                b12=true;
            }
            con.Close();
            return b12;
        }
        public DateTime getexpiry2(SqlParameter n)
        {
            //get expiry date
            getconnection();
            con.Open();
            DateTime? dt2=null;
            cmd = new SqlCommand("getexpiry2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(n);
            dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                dt2 = Convert.ToDateTime(dr["date_of_expiry"]);
            }
            con.Close();
            return Convert.ToDateTime(dt2);

        }
        public bool checkissuedate(SqlParameter[] o)
        {
            //check visa issue date
            getconnection();
            con.Open();
            bool x3 = false;
            cmd = new SqlCommand("checkissuedate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(o);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                x3 = true;
            }
            con.Close();
            return x3;
        }
        public DateTime getexpirydate1(SqlParameter o)
        {
            //get expiry date for passport
            getconnection();
            con.Open();
            DateTime? j2 = null;
            cmd = new SqlCommand("getexpiry1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(o);
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
