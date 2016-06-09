//business logic layer for apply visa and cancel visa
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pvmsdal.layer;
using pvmsentity.layer;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace pvmsbus.layer
{
    public class busvisa
    {
        //object declaration for entity and data access layer
        entityvisa eobj2 = new entityvisa();
        dalvisa dobj2 = new dalvisa();
        public bool passportloginbus(string e,string e1)
        {
            // validate login
            SqlParameter[] a = new SqlParameter[2];
            bool b1 = false;
            a[0] = new SqlParameter("@passport_id", e);
            a[1] = new SqlParameter("@user_id", e1);
            b1 = dobj2.passportlogin(a);
            return b1;
        }
        public List<string> getdestinationbus()
        {
            //get destination list
            List<string> des1 = new List<string>();
            SqlParameter[] b = new SqlParameter[1];
            b[0] = new SqlParameter();
            b[0].Direction = ParameterDirection.Output;
            des1 = dobj2.getdestination(b);
            return des1;
        }
        public List<string> getoccupationbus()
        {
            //get occupation list
            List<string> occ1 = new List<string>();
            SqlParameter[] c = new SqlParameter[1];
            c[0] = new SqlParameter();
            c[0].Direction = ParameterDirection.Output;
            occ1 = dobj2.getoccupation(c);
            return occ1;
        }
        public int getnewvisaidbus(entityvisa eobj2)
        {
            //get next visa id
            int vid1 = 0;
            SqlParameter[] d = new SqlParameter[2];
            d[0] = new SqlParameter("@new_visa_tag", eobj2.new_visa_tag);
            d[1] = new SqlParameter("@new_visa_id", eobj2.new_visa_id);
            d[1].Direction = ParameterDirection.Output;
            vid1 = dobj2.getnewvisaid(d);
            return vid1;
        }
        public void insertvisabus(entityvisa eobj2)
        {
            //insert visa details
            SqlParameter[] e = new SqlParameter[10];
            e[0] = new SqlParameter("@visa_id", eobj2.visa_id);
            e[1] = new SqlParameter("@passport_id", eobj2.passport_id);
            e[2] = new SqlParameter("@user_id", eobj2.user_id);
            e[3] = new SqlParameter("@destination", eobj2.destination);
            e[4] = new SqlParameter("@occupation", eobj2.occupation);
            e[5] = new SqlParameter("@cost", eobj2.cost);
            e[6] = new SqlParameter("@visa_permit", eobj2.visa_permit);
            e[7] = new SqlParameter("@date_of_apply", eobj2.date_of_apply);
            e[8] = new SqlParameter("@date_of_issue", eobj2.date_of_issue);
            e[9] = new SqlParameter("@date_of_expiry", eobj2.date_of_expiry);
            dobj2.insertvisa(e);
        }
        public List<string> getquestionsbus()
        {
            //get secret question list
            List<string> que1 = new List<string>();
            //SqlParameter f = new SqlParameter();
            //f.Direction = ParameterDirection.Output;
            que1 = dobj2.getquestions();
            return que1;
        }
        public string[] validatequestionbus(entityvisa eobj2)
        {
            //validate secret question
            string[] w1 = new string[2];
            SqlParameter f = new SqlParameter();
            f = new SqlParameter("@user_id", eobj2.user_id);
            w1 = dobj2.validatequestions(f);
            return w1;
        }
        public string validuserpassbus(entityvisa eobj2)
        {
            //validate user id and passport id
            string x1 = "";
            SqlParameter g = new SqlParameter();
            g = new SqlParameter("@user_id", eobj2.user_id);
            x1 = dobj2.validuserpass(g);
            return x1;
        }
        public DateTime getexpirybus(entityvisa eobj2)
        {
            //get expiry date for visa
            DateTime dt;
            SqlParameter h = new SqlParameter();
            h = new SqlParameter("@visa_id", eobj2.visa_id);
            dt = dobj2.getexpiry(h);
            return dt;
        }
        public string[] getoccbus1(entityvisa eobj2)
        {
            //get occupation
            string[] s1 = new string[2];
            SqlParameter i = new SqlParameter();
            i = new SqlParameter("@visa_id", eobj2.visa_id);
            s1 = dobj2.getocc1(i);
            return s1;
        }
        public void insertcancelvisabus(entityvisa eobj2)
        {
            //insert cancelled visa details
            SqlParameter[] j = new SqlParameter[6];
            j[0] = new SqlParameter("@visa_id", eobj2.visa_id);
            j[1] = new SqlParameter("@user_id", eobj2.user_id);
            j[2] = new SqlParameter("@passport_id", eobj2.passport_id);
            j[3] = new SqlParameter("@date_of_issue", eobj2.date_of_issue);
            j[4] = new SqlParameter("@date_of_cancel", eobj2.date_of_cancel);
            j[5] = new SqlParameter("@fine_amount", eobj2.fine_amount);
            dobj2.insertcancelvisa(j);

        }
        public bool checkduplicatevisaidbus(entityvisa eobj2)
        {
            //check already existing visa
            bool v1 = false;
            SqlParameter k = new SqlParameter();
            k = new SqlParameter("@visa_id", eobj2.visa_id);
            v1 = dobj2.checkduplicatevisaid(k);
            return v1;
        }
        public bool checkduplicatevisaid2bus(string y)
        {
            //check already existing visa
            bool b01 = false;
            SqlParameter l = new SqlParameter();
            l = new SqlParameter("@user_id", y);
            b01 = dobj2.checkduplicatevisaid2(l);
            return b01;
        }
        public bool checkduplicatevisaid1bus(string y)
        {
            //check already existing visa
            bool b11 = false;
            SqlParameter m = new SqlParameter();
            m = new SqlParameter("@user_id", y);
            b11 = dobj2.checkduplicatevisaid1(m);
            return b11;
        }
        public DateTime getexpiry2bus(string y)
        {
            //get expiry date
            DateTime? dt1 = null;
            SqlParameter n = new SqlParameter();
            n = new SqlParameter("@user_id", y);
            dt1 = dobj2.getexpiry2(n);
            return Convert.ToDateTime(dt1);
        }
        public bool checkissuedatebus(string s0, DateTime dt)
        {
            bool x2 = false;
            SqlParameter[] o = new SqlParameter[2];
            o[0] = new SqlParameter("@visa_id", s0);
            o[1] = new SqlParameter("@date_of_issue", dt);
            x2 = dobj2.checkissuedate(o);
            return x2;
        }
        public DateTime getexpirydate1bus(string j)
        {
            //get expiry date for passport
            DateTime? j1 = null;
            SqlParameter o = new SqlParameter();
            o = new SqlParameter("@user_id", j);
            j1 = dobj2.getexpirydate1(o);
            return Convert.ToDateTime(j1);
        }

    }
}
