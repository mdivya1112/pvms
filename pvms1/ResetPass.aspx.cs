//code behind page for reset password
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using pvmsentity.layer;
using pvmsbus.layer;

public partial class ResetPass : System.Web.UI.Page
{
    //object declaration for entity and business logic layer
    bususer bobj = new bususer();
    entityuser eobj = new entityuser();
    pvms1.activity pa = new pvms1.activity();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session.Timeout = 15; //session duration
            }
        }
        catch (Exception ex)
        {
            //exception block
            pvms1.error2 er2 = new pvms1.error2();
            er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
            Server.ClearError();
            Response.Redirect("error1.aspx",false);//error page
        }
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        //reset fields
        tuserid.Text = "";
        tb_newpassword.Text = "";
        tb_confirmpassword.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //change password details
        try
        {
            eobj.user_id = tuserid.Text; //  user_id
            if (tb_newpassword.Text == tb_confirmpassword.Text)
            {
                eobj.newpass = tb_newpassword.Text; //new password
                eobj.conpass = tb_confirmpassword.Text; //new password
                bobj.resetpassbus(eobj);// insert into database
                pa.resetpass(DateTime.Now, tuserid.Text, "password changed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                Response.Redirect("Login.aspx",false);//login page
                Response.Write("Password changed");
            }
            else
            {
                //reset values
                pa.resetpass(DateTime.Now, tuserid.Text, "reset failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                tuserid.Text = "";
                tb_newpassword.Text = "";
                tb_confirmpassword.Text = "";
                Response.Write("Try Again");
            }
        }
        catch (Exception ex)
        {
            //exception block
            pvms1.error2 er2 = new pvms1.error2();
            er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
            Server.ClearError();
            Response.Redirect("error1.aspx",false);//error page
        }



    }
    protected void tbuserid_TextChanged(object sender, EventArgs e)
    {

    }
    protected void tb_newpassword_TextChanged(object sender, EventArgs e)
    {

    }
    protected void tb_confirmpassword_TextChanged(object sender, EventArgs e)
    {

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
}//System.Net.Dns.GetHostName()