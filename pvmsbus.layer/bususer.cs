//business logic layer for user registration
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pvmsentity.layer;
using pvmsdal.layer;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data;


namespace pvmsbus.layer
{

    public class bususer
    {
        daluser dobj = new daluser();
        public int registerbus(entityuser eobj)
        {
            //get new user id
            SqlParameter[] a = new SqlParameter[2];
            a[0] = new SqlParameter("@new_tag", eobj.new_tag);
            a[1] = new SqlParameter("@new_id", eobj.new_id);
            a[1].Direction = ParameterDirection.Output;
            int id = dobj.registerid(a);
            return id;
        }
        public void registeruserbus(entityuser eobj)
        {
            //insert user details
            SqlParameter[] c = new SqlParameter[13];
            c[0] = new SqlParameter("@user_id", eobj.user_id);
            c[1] = new SqlParameter("@username", eobj.username);
            c[2] = new SqlParameter("@password", eobj.password);
            c[3] = new SqlParameter("@qualification", eobj.qualification);
            c[4] = new SqlParameter("@emailid", eobj.emailid);
            c[5] = new SqlParameter("@contact", eobj.contact);
            c[6] = new SqlParameter("@dob", eobj.dob);
            c[7] = new SqlParameter("@applytype", eobj.applytype);
            c[8] = new SqlParameter("@gender", eobj.gender);
            c[9] = new SqlParameter("@hint_question", eobj.hint_question);
            c[10] = new SqlParameter("@hint_ans", eobj.hint_ans);
            c[11] = new SqlParameter("@age", eobj.age);
            c[12] = new SqlParameter("@citizen_type", eobj.citizen_type);
            dobj.registeruser(c);
        }
        public bool loginuserbus(entityuser eobj)
        {
            //check login
            SqlParameter[] d = new SqlParameter[2];
            d[0] = new SqlParameter("@user_id", eobj.user_id);
            d[1] = new SqlParameter("@password", eobj.password);
            bool y = dobj.loginuser(d);
            return y;

        }
        public bool forgotpassbus(entityuser eobj)
        {
            //check hint question and answer for password reset
            SqlParameter[] e = new SqlParameter[3];
            e[0] = new SqlParameter("@user_id", eobj.user_id);
            e[1] = new SqlParameter("@hint_question", eobj.hint_question);
            e[2] = new SqlParameter("@hint_ans", eobj.hint_ans);
            bool z = dobj.forgotpass(e);
            return z;
        }
        public void resetpassbus(entityuser eobj)
        {
            //update password
            SqlParameter[] f = new SqlParameter[2];
            f[0] = new SqlParameter("@user_id", eobj.user_id);
            f[1] = new SqlParameter("@new_password", eobj.newpass);
            dobj.resetpass(f);
        }
        public List<string> getqualificationbus()
        {
            //get qualification list
            List<string> a1 = new List<string>();
            a1 = dobj.getqualification();
            return a1;
        }
        public List<string> getapplytypebus()
        {
            //get apply type list
            List<string> b1 = new List<string>();
            b1 = dobj.getapplytype();
            return b1;
        }
        public List<string> getquestionsbus()
        {
            //get hint question list
            List<string> que1 = new List<string>();
            //SqlParameter f = new SqlParameter();
            //f.Direction = ParameterDirection.Output;
            que1 = dobj.getquestions();
            return que1;
        }
    }
}
