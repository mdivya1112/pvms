//code behind page for cancel visa first page
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

public partial class _Default : System.Web.UI.Page
{
    //object declaration for entity and businesslogic layers
    entityvisa eobj2 = new entityvisa();
    busvisa bobj2 = new busvisa();
    pvms1.activity pa = new pvms1.activity();
    protected void Page_Load(object sender, EventArgs e)
    {
        //fields to be loaded on page load
        if ((string)Session["user_id"] != "")
        {
            try
            {
                if (!IsPostBack)
                {
                    luserid.Text = (string)Session["user_id"];//session value for user id
                    List<string> que = new List<string>();
                    que = bobj2.getquestionsbus();//get secret questions
                    dd_que.DataSource = que;
                    dd_que.DataBind();
                    Session.Timeout = 15;//session duration


                }
            }
            catch (Exception ex)
            {
                //exception block
                string g = Request.ServerVariables["REMOTE_ADDR"];
                pvms1.error2 er2 = new pvms1.error2();
                er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                Server.ClearError();
                Response.Redirect("error1.aspx");//error page
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        //cancel visa details
        try
        {
            eobj2.user_id = luserid.Text;//user id
            eobj2.security_question = dd_que.Text;//security question
            eobj2.security_answer = tbsecans.Text;//security answer
            string[] w = new string[2];
            w = bobj2.validatequestionbus(eobj2);//check question answer values
            if (w[0] == eobj2.security_question && w[1] == eobj2.security_answer)
            {
                //correct values
                pa.cancelvisa(DateTime.Now, "null", luserid.Text, "cancel visa login successfull", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                Response.Redirect("cancelvisa2.aspx",false);//redirect to next cancel visa page
            }
            else
            {
                //incorrect values'
                lerror.Text = "Values do not match";
                pa.cancelvisa(DateTime.Now, "null", luserid.Text, "cancel visa login failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
               // lerror.Text = "Values do not match";
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

    protected void tbsecans_TextChanged(object sender, EventArgs e)
    {

    }
    //System.Net.Dns.GetHostName()
}