//code behind page for apply visa first page
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
using System.Windows.Forms;

public partial class applyvisa1 : System.Web.UI.Page
{
    //object declaration for entity and business logic layers
    entityvisa eobj2 = new entityvisa();
    busvisa bobj2 = new busvisa();
    pvms1.activity pa = new pvms1.activity();//object for activity class
    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["user_id"] != "")//prevent direct url access
        {
            try
            {
                if (!IsPostBack)
                {
                    string y = (string)Session["user_id"];
                    bool b0 = false;
                    b0 = bobj2.checkduplicatevisaid2bus(y);
                    bool b1 = false;
                    b1 = bobj2.checkduplicatevisaid1bus(y);
                    DateTime b2 = bobj2.getexpiry2bus(y);
                    DateTime b3 = bobj2.getexpirydate1bus(y);
                    if (DateTime.Now < b3)
                    {
                        if ((b0 == false) || ((b0 == true) && (DateTime.Now > b2) && (b1 == true)) || ((b0 == true) && (DateTime.Now > b2) && (b1 == false)) || ((b0 = true) && (DateTime.Now < b2) && (b1 = true)))
                        {
                        }
                        else
                        {
                            pa.applyvisa(DateTime.Now, "null", (string)Session["user_id"], "already applied for visa ", Request.ServerVariables["REMOTE_ADDR"], "null", GetServerIP(), System.Net.Dns.GetHostName());
                            MessageBox.Show("You have already applied for visa");
                            Session.Contents.RemoveAll();
                            Response.Redirect("Login.aspx", false);
                        }
                    }
                    else
                    {
                        pa.applyvisa(DateTime.Now, "null", (string)Session["user_id"], "passport expired ", Request.ServerVariables["REMOTE_ADDR"], "null", GetServerIP(), System.Net.Dns.GetHostName());
                        MessageBox.Show("Your passort already expired");
                        Session.Contents.RemoveAll();
                        Response.Redirect("Login.aspx", false);

                    }

                    Session.Timeout = 15;//session duration
                }
            }
            catch (Exception ex)
            {
                //exception block
                pvms1.error2 er2 = new pvms1.error2();
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
   
    
    protected void Search_Click(object sender, EventArgs e)
    {
        //search passport number
        try
        {
            
            eobj2.passport_id = tbpassportno.Text;//passport id value
            bool b = bobj2.passportloginbus(eobj2.passport_id, (string)Session["user_id"]);
            if (b == true)
            {
                //correct passport_id
                Session["passno"] = tbpassportno.Text;//passport id
                pa.applyvisa(DateTime.Now, "null", (string)Session["user_id"], "visa login successfull ", Request.ServerVariables["REMOTE_ADDR"], (string)Session["pass_no"], GetServerIP(), System.Net.Dns.GetHostName());
                Response.Redirect("ApplyVisa2.aspx",false);
            }
            else
            {
                //incorrect passport id
                pa.applyvisa(DateTime.Now, "null", (string)Session["user_id"], "visa login failed", Request.ServerVariables["REMOTE_ADDR"], "null", GetServerIP(), System.Net.Dns.GetHostName());
                lpassport.Text = "Incorrect passport No.";
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
    //System.Net.Dns.GetHostName()

    
}