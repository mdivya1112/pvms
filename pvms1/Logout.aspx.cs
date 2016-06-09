//code behind page for logout
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using pvmsentity.layer;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                entitylog elog = new entitylog();//object for entity layer
                elog.login = Convert.ToDateTime(Session["login_time"]);//login time
                elog.logout = DateTime.Now;//logout time
                elog.userreg = Convert.ToDateTime(Session["reg_time"]);//user register time
                elog.applypassport = Convert.ToDateTime(Session["applypass_time"]);//apply passport time
                elog.applyvisa = Convert.ToDateTime(Session["visa_time"]);//apply visa time
                elog.passrenew = Convert.ToDateTime(Session["renew_time"]);//passport renewed time
                elog.cancelvisa = Convert.ToDateTime(Session["cancel_time"]);//visa cancelled time
                elog.userid = (string)Session["user_id"];//user id
                elog.sb.Append((string)Session["login_msg"]);
                elog.sb.Append((string)Session["user_msg"]);
                elog.sb.Append((string)Session["applypass_msg"]);
                elog.sb.Append((string)Session["applyvisa_msg"]);   //activity messages
                elog.sb.Append((string)Session["renew_msg"]);
                elog.sb.Append((string)Session["cancel_msg"]);
                elog.sb.Append(" logged out ");//logout time
                elog.ip = Request.ServerVariables["REMOTE_ADDR"];//client ip
                elog.activity = elog.sb.ToString();//activity message
                elog.server= GetServerIP() +" "+ System.Net.Dns.GetHostName();//server ip
                pvms1.activity pa = new pvms1.activity();//object for activity class
                pa.inf(elog);
                Session.Timeout = 15;//session duration
                Session.Abandon();
                Session.Contents.RemoveAll();//drop session variables
            }
        }
        catch (Exception ex)
        {
            //exception class
            pvms1.error2 er2 = new pvms1.error2();
            er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
            Server.ClearError();
            Response.Redirect("error1.aspx", false);//error page
        }
       
    }
    public static string GetServerIP()
    {
        //get server address
        string strHostName = System.Net.Dns.GetHostName();

        IPHostEntry ipHostInfo = Dns.GetHostEntry(strHostName);

        foreach (IPAddress address in ipHostInfo.AddressList)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork)
                return address.ToString();
        }

        return string.Empty;
    }
   

   
}