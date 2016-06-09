//error class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace pvms1
{
    public class error2
    {
        public void errorinf(Exception ex,string s,string s1,string s2)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));//time stamp
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            //message += string.Format("User ID: {0}", s1);//error message
            //message += Environment.NewLine;
            message += string.Format("Client IP: {0}", s);//error message
            message += Environment.NewLine;
            message += string.Format("Server: {0} {1}", s1,s2);//error message
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);//error message
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);//error source
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = HttpContext.Current.Server.MapPath("~/logfolder/error.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
  
}