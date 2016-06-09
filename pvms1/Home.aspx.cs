using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["user_id"] != "")//prevent direct url access
        {
            try
            {
                if (!IsPostBack)
                {
                    Session.Timeout = 15;//session duration
                }
            }
            catch (Exception ex)
            {
                //exception handling
                pvms1.error2 er2 = new pvms1.error2();//object fot error class
                er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                Server.ClearError();
                Response.Redirect("error1.aspx", false);//error page
            }
        }
        else
        {
            Response.Redirect("Login.aspx",false);
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