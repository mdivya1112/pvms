using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using pvmsentity.layer;

namespace pvms1
{
    
    
    public class activity
    {
        entitylog elog = new entitylog();
        public void inf(entitylog elog)
        {
            //string mesg = string.Format("Log in :{0}", elog.login.ToString("dd/MM/yyyy hh:mm:ss tt"));
            string message = "-----------------------------------------------------------";
            message += Environment.NewLine;
            if (elog.login != DateTime.MinValue)
            {
                message += string.Format("Log in Time: {0}", elog.login.ToString("dd/MM/yyyy hh:mm:ss tt"));//time stamp
            }
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("UserID: {0}", elog.userid);
            message += Environment.NewLine;
            if (elog.userreg != DateTime.MinValue)
            {
                message += string.Format("userreg time: {0}", elog.userreg.ToString("dd/MM/yyyy hh:mm:ss tt"));
                message += Environment.NewLine;
            }
            else
            {
                message += string.Format("userreg time:none");
                message += Environment.NewLine;
            }

            if (elog.applypassport != DateTime.MinValue)
            {
                message += string.Format("passport apply time: {0}", elog.applypassport.ToString("dd/MM/yyyy hh:mm:ss tt"));
                message += Environment.NewLine;
            }
            else
            {
                message += string.Format("passport apply time:none");
                message += Environment.NewLine;
            }

            if (elog.applyvisa!= DateTime.MinValue)
            {
                message += string.Format("visa apply time: {0}", elog.applyvisa.ToString("dd/MM/yyyy hh:mm:ss tt"));
                message += Environment.NewLine;
            }
            else
            {
                message += string.Format("visa apply time:none");
                message += Environment.NewLine;
            }

            if (elog.passrenew!= DateTime.MinValue)
            {
                message += string.Format("passport renew time: {0}", elog.passrenew.ToString("dd/MM/yyyy hh:mm:ss tt"));
                message += Environment.NewLine;
            }
            else
            {
                message += string.Format("passport renew time:none");
                message += Environment.NewLine;
            }

            if (elog.cancelvisa!= DateTime.MinValue)
            {
                message += string.Format("cancel visa time: {0}", elog.cancelvisa.ToString("dd/MM/yyyy hh:mm:ss tt"));
                
            }
            else
            {
                message += string.Format("cancel visa time: none");
               
            }

            message += Environment.NewLine;
            message += string.Format("Activity: {0}", elog.activity);
            message += Environment.NewLine;
            message += string.Format("Client IP: {0}", elog.ip);
            message += Environment.NewLine;
            message += string.Format("Server: {0}", elog.server);
            message += Environment.NewLine;
            message += string.Format("Logout Time: {0}", elog.logout.ToString("dd/MM/yyyy hh:mm:ss tt"));//error source
            message += Environment.NewLine;
            //message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            //message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = HttpContext.Current.Server.MapPath("~/logfolder/activitylog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                //File.SetAttributes("~/logfolder/activitylog.txt", FileAttributes.ReadOnly);
                writer.Close();
            }
        }
        public void applypass(DateTime t, string s,string s1,string s2,string s3,string s4,string s5)
        {
            string message = "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Passport Applied time: {0}", t.ToString("dd/MM/yyyy hh:mm:ss tt"));//time stamp
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("UserID: {0}", s1);//error message
            message += Environment.NewLine;
            message += string.Format("PassportID: {0}", s);//error message
            message += Environment.NewLine;
            message += string.Format("Client IP: {0}", s3);//error message
            message += Environment.NewLine;
            message += string.Format("Server: {0} {1}", s3,s5);//error message
            message += Environment.NewLine;
            message += string.Format("Activity : {0}",s2);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = HttpContext.Current.Server.MapPath("~/logfolder/applypassport.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                //File.SetAttributes("~/logfolder/applypassport.txt", FileAttributes.ReadOnly);
                writer.Close();
            }
        }
        public void applyvisa(DateTime t, string s, string s1, string s2,string s3,string s4,string s5,string s6)
        {
            string message = "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Visa applied time: {0}", t.ToString("dd/MM/yyyy hh:mm:ss tt"));//time stamp
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("UserID: {0}", s1);//error message
            message += Environment.NewLine;
            message += string.Format("VisaID: {0}", s);//error message
            message += Environment.NewLine;
            message += string.Format("PassportID: {0}", s4);//error message
            message += Environment.NewLine;
            message += string.Format("Client IP: {0}", s3);//error message
            message += Environment.NewLine;
            message += string.Format("Server: {0} {1}", s5,s6);//error message
            message += Environment.NewLine;
            message += string.Format("Activity : {0}",s2);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = HttpContext.Current.Server.MapPath("~/logfolder/applyvisa.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                //File.SetAttributes("~/logfolder/applyvisa.txt", FileAttributes.ReadOnly);
                writer.Close();
            }
        }
        public void passportrenew(DateTime t, string s,string s1,string s2,string s3,string s4,string s5)
        {
            string message = "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Passport renewed time: {0}", t.ToString("dd/MM/yyyy hh:mm:ss tt"));//time stamp
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("UserID: {0}", s1);//error message
            message += Environment.NewLine;
            message += string.Format("PassportID: {0}", s);//error message
            message += Environment.NewLine;
            message += string.Format("Client IP: {0}", s3);//error message
            message += Environment.NewLine;
            message += string.Format("Server: {0} {1}", s4,s5);//error message
            message += Environment.NewLine;
            message += string.Format("Activity : {0}",s2);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = HttpContext.Current.Server.MapPath("~/logfolder/passrenew.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                //File.SetAttributes("~/logfolder/passrenew.txt", FileAttributes.ReadOnly);
                writer.Close();
            }
        }
        public void cancelvisa(DateTime t, string s, string s1, string s2,string s3,string s4,string s5)
        {
            string message = "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Visa Cancelled time: {0}", t.ToString("dd/MM/yyyy hh:mm:ss tt"));//time stamp
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("UserID: {0}", s1);//error message
            message += Environment.NewLine;
            message += string.Format("VisaID: {0}", s);//error message
            message += Environment.NewLine;
            message += string.Format("Client ID: {0}", s3);//error message
            message += Environment.NewLine;
            message += string.Format("Server: {0} {1}", s4,s5);//error message
            message += Environment.NewLine;
            message += string.Format("Activity : {0}",s2);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = HttpContext.Current.Server.MapPath("~/logfolder/cancelvisa.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                //File.SetAttributes("~/logfolder/login.txt", FileAttributes.ReadOnly);
                writer.Close();
            }
        }
        public void userdet(DateTime t, string s,string s1,string s2,string s3,string s4)
        {
            string message = "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Reg. time: {0}", t.ToString("dd/MM/yyyy hh:mm:ss tt"));//time stamp
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("UserID: {0}", s);//error message
            message += Environment.NewLine;
            message += string.Format("Client IP: {0}", s2);//error message
            message += Environment.NewLine;
            message += string.Format("Server IP: {0} {1}", s3,s4);//error message
            message += Environment.NewLine;
            message += string.Format("Activity :{0}",s1);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = HttpContext.Current.Server.MapPath("~/logfolder/user.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                //File.SetAttributes("~/logfolder/user.txt", FileAttributes.ReadOnly);
                writer.Close();
            }
        }
         public void logindet(DateTime t,string s,string s1,string s2, string s3,string s4)
        {
            string message = "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Log in Time: {0}", t.ToString("dd/MM/yyyy hh:mm:ss tt"));//time stamp
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("UserID: {0}",s);//error message
            message += Environment.NewLine;
            message += string.Format("Client IP: {0}", s2);//error message
            message += Environment.NewLine;
            message += string.Format("Server: {0} {1}", s3,s4);//error message
            message += Environment.NewLine;
            message += string.Format("Activity :{0}",s1);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = HttpContext.Current.Server.MapPath("~/logfolder/login.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                //File.SetAttributes("~/logfolder/login.txt", FileAttributes.ReadOnly);
                writer.Close();
            }
        }
         public void resetpass(DateTime t, string s, string s1, string s2, string s3, string s4)
         {
             string message = "-----------------------------------------------------------";
             message += Environment.NewLine;
             message += string.Format("Password changed time: {0}", t.ToString("dd/MM/yyyy hh:mm:ss tt"));//time stamp
             message += Environment.NewLine;
             message += "-----------------------------------------------------------";
             message += Environment.NewLine;
             message += string.Format("UserID: {0}", s);//error message
             message += Environment.NewLine;
             message += string.Format("Client IP: {0}", s2);//error message
             message += Environment.NewLine;
             message += string.Format("Server: {0} {1}", s3, s4);//error message
             message += Environment.NewLine;
             message += string.Format("Activity :{0}", s1);
             message += Environment.NewLine;
             message += "-----------------------------------------------------------";
             message += Environment.NewLine;
             string path = HttpContext.Current.Server.MapPath("~/logfolder/login.txt");
             using (StreamWriter writer = new StreamWriter(path, true))
             {
                 writer.WriteLine(message);
                 //File.SetAttributes("~/logfolder/login.txt", FileAttributes.ReadOnly);
                 writer.Close();
             }
         }
    }
  
 }