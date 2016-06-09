//code behind page for login
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using pvmsbus.layer;
using pvmsentity.layer;

public partial class Login : System.Web.UI.Page
{
    bususer bobj = new bususer();//object declaration for businesslogic layer
    entityuser eobj = new entityuser();//object declaration for entity layer
    entitylog elog = new entitylog();//object declaration for entity layer
    pvms1.activity pa = new pvms1.activity();//object declaration for activity class
    protected void Page_Init(object Sender, EventArgs e)
    {
        //disable browser back button
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["user_id"] = "";
            if (!IsPostBack)
            {
                Session.Timeout = 60;//session duration
            }
        }
        catch (Exception ex)
        {
            pvms1.error2 er2 = new pvms1.error2();
            er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
            Server.ClearError();
            Response.Redirect("error1.aspx", false);//error page
        }
     
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
  
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    //protected void Register_Click(object sender, EventArgs e)
    //{
    //    //redirect to userregister page
    //    try
    //    {
    //        Response.Redirect("Userregister.aspx",false);
    //    }
    //    catch (Exception ex)
    //    {
    //        pvms1.error2 er2 = new pvms1.error2();
    //        er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
    //        Server.ClearError();
    //        Response.Redirect("error1.aspx", false);//error page
    //    }
    //}

    protected void _login_Click(object sender, EventArgs e)
    {
        //login user
        try
        {
            eobj.user_id = tbuserid.Text;//user id
            eobj.password = tbpassword.Text;//password
            bool x = bobj.loginuserbus(eobj);//check login
            if (x == true)
            {
                // correct login
                Session["user_id"] = tbuserid.Text;//session value for user id
                DateTime? t = null;
                t = DateTime.Now;
                Session["login_time"] = t;
                Session["login_msg"] = "logged in";
                pvms1.activity pa = new pvms1.activity();
                pa.logindet(Convert.ToDateTime(t), (string)Session["user_id"], "logged in", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                Response.Redirect("Home.aspx",false);//home page
            }
            else
            {
                //incorrect login
                pa.logindet(DateTime.Now, "null", "login failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                tbuserid.Text = "";
                tbpassword.Text = "";
                Response.Write("Your Userid or Password is incorrect.Try Again");
            }
        }
        catch (Exception ex)
        {
            pvms1.error2 er2 = new pvms1.error2();
            er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
            Server.ClearError();
            Response.Redirect("error1.aspx",false);//error page
        }

    }
    public void disablebrowserbackbutton()
    {
        //disable browser back button
        try
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }
        catch (Exception ex)
        {
            //exception block
            pvms1.error2 er2 = new pvms1.error2();
            er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
            Server.ClearError();
            Response.Redirect("error1.aspx");//error page
        }
    }
    public static string GetServerIP()
    {

        string strHostName = System.Net.Dns.GetHostName();
        //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName()); <-- Obsolete

        IPHostEntry ipHostInfo = Dns.GetHostEntry(strHostName);

        foreach (IPAddress address in ipHostInfo.AddressList)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork)
                return address.ToString();
        }

        return string.Empty;
    }

}
//System.Net.Dns.GetHostName()