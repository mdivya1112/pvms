//business logic layer for apply passport and passport renewal
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pvmsdal.layer;
using pvmsentity.layer;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace pvmsbus.layer
{

    public class buspassport
    {
       
      dalpassport dobj1 = new dalpassport();

        public string getstateidbus(string eobj1)
        {
            //get state id
             SqlParameter[] a = new SqlParameter[1];
             a[0] = new SqlParameter("@state_name", eobj1);
             //a[1] = new SqlParameter("state_id", eobj1.state_id);
             //a[1].Direction = ParameterDirection.Output;
              string id = dobj1.getstateid(a);
              return id;
            
           
        }
        public List<string> getcitynamebus(string eobj1)
        {
            //get city for the state
            SqlParameter[] b = new SqlParameter[1];
            List<string> output1 = new List<string>();
            b[0] = new SqlParameter("@state_id", eobj1);
            //b[1] = new SqlParameter("city_name", output1);
            //b[1].Direction = ParameterDirection.Output;
            output1 = dobj1.getcityname(b);
            return output1;

        }
        public int passportidbus(entitypassport eobj1)
        {
            //next passport id
            SqlParameter[] c = new SqlParameter[1];
            c[0] = new SqlParameter("@new_pass_id", eobj1.new_pass_id);
            c[0].Direction = ParameterDirection.Output;
            int output4 = dobj1.passportid(c);
            return output4;
        }
        public void applypassportbus(entitypassport eobj1)
        {
            //insert passport details
            SqlParameter[] d = new SqlParameter[11];
            d[0] = new SqlParameter("@passport_id", eobj1.passsport_id);
            d[1] = new SqlParameter("@user_id", eobj1.user_id);
            d[2] = new SqlParameter("@country", eobj1.country);
            d[3] = new SqlParameter("@state", eobj1.state);
            d[4] = new SqlParameter("@city", eobj1.city);
            d[5] = new SqlParameter("@pin", eobj1.pin);
            d[6] = new SqlParameter("@issue_date", eobj1.issue_date);
            d[7] = new SqlParameter("@type_of_service", eobj1.type_of_service);
            d[8] = new SqlParameter("@booklet_type", eobj1.booklet_type);
            d[9] = new SqlParameter("@expiry_date", eobj1.expiry_date);
            d[10] = new SqlParameter("@amount", eobj1.amount);
            dobj1.appplypassport(d);

        }
        public List<string> gettosbus()
        {
            //get type of service
            List<string> tos1 = new List<string>();
            SqlParameter[] e = new SqlParameter[1];
            e[0] = new SqlParameter();
            e[0].Direction = ParameterDirection.Output;
            tos1=dobj1.gettos(e);
            return tos1;
        }
        public List<string> getbtbus()
        {
            //get booklet type
            List<string> bt1 = new List<string>();
            SqlParameter[] f = new SqlParameter[1];
            f[0] = new SqlParameter();
            f[0].Direction = ParameterDirection.Output;
            bt1 = dobj1.getbt(f);
            return bt1;
        }
        public List<string> getstatebus()
        {
            //get state list
            List<string> state1 = new List<string>();
            SqlParameter[] g = new SqlParameter[1];
            g[0] = new SqlParameter();
            g[0].Direction = ParameterDirection.Output;
            state1 = dobj1.getstate(g);
            return state1;
        }
        public string[] getrenewbus(string e)
        {
            //get passport details
            string[] a1 = new string[4]; 
           SqlParameter h = new SqlParameter("@passport_id", e);
            //h[1] = new SqlParameter("@country", eobj1.country);
            //h[1].Direction = ParameterDirection.Output;
            //h[2] = new SqlParameter("@state", eobj1.state);
            //h[2].Direction = ParameterDirection.Output;
            //h[3] = new SqlParameter("@city", eobj1.city);
            //h[3].Direction = ParameterDirection.Output;
            //h[4] = new SqlParameter("@pin", eobj1.pin);
            //h[4].Direction = ParameterDirection.Output;
            a1 = dobj1.getrenew(h);
            return a1;
        }
        public bool passportloginbus(string g,string g5)
        {
            //check passport login
            bool f1;
            SqlParameter[] i = new SqlParameter[2];
            i[0] = new SqlParameter("@passport_id", g);
            i[1] = new SqlParameter("@user_id", g5);
            f1 = dobj1.passportlogin(i);
            return f1;
        }
        public DateTime getexpirydatebus(string h)
        {
            //get expiry date for passport renewal
            DateTime dt1;
            SqlParameter j = new SqlParameter("@passport_id", h);
            dt1 = dobj1.getexpirydate(j);
            return dt1;
        }
        public void insertrenewbus(entitypassport eobj1)
        {
            //insert renewed passport details
            SqlParameter[] k = new SqlParameter[6];
            k[0] = new SqlParameter("@passport_id", eobj1.passsport_id);
            k[1] = new SqlParameter("@new_service_type", eobj1.new_service_type);
            k[2] = new SqlParameter("@new_booklet_type", eobj1.new_booklet_type);
            k[3] = new SqlParameter("@new_issue_date", eobj1.new_issue_date);
            k[4] = new SqlParameter("@new_expiry_date", eobj1.new_expiry_date);
            k[5] = new SqlParameter("@renew_amount", eobj1.renew_amount);
            dobj1.insertrenew(k);
        }
        public bool checkduplicatepassbus(string k)
        {
            //check for duplicate passport
            bool k1 = false;
            SqlParameter l = new SqlParameter();
            l = new SqlParameter("@user_id", k);
            k1 = dobj1.checkduplicatepass(l);
            return k1;
        }
        public DateTime getexpirydate1bus(string j)
        {
            //get expiry date for passport
            DateTime? j1 = null;
            SqlParameter m = new SqlParameter();
            m = new SqlParameter("@user_id", j);
            j1 = dobj1.getexpirydate1(m);
            return Convert.ToDateTime(j1);
        }
    }

}
