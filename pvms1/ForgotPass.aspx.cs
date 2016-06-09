//code behind page for forgot password page
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

public partial class forgotpass : System.Web.UI.Page
{
    //object declaration for entity and business logic layer
    bususer bobj = new bususer();
    entityuser eobj = new entityuser();
    pvms1.activity pa = new pvms1.activity();
    protected void Page_Load(object sender, EventArgs e)
    {
        //fields loaded during page load
        try
        {
            if (!IsPostBack)
            {
                List<string> que = new List<string>();
                que = bobj.getquestionsbus();//get hint questions
                tb_hintque.DataSource = que;
                tb_hintque.DataBind();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        //submit password details
        try
        {

            eobj.user_id = tb_userid.Text; //user id
            eobj.hint_ans = tb_hintans.Text; //hint answer
            eobj.hint_question = tb_hintque.Text; //hint question
            bool s = bobj.forgotpassbus(eobj);// check correct hint question and answer
            if (s == true)
            {
                //correct values
                Response.Redirect("ResetPass.aspx",false); //redirect to reset password page
            }
            else
            {
                //incorrect values
                tb_userid.Text = "";
                tb_hintans.Text = "";
                tb_hintque.SelectedIndex = 0;
                pa.resetpass(DateTime.Now, tb_userid.Text, "invalid secret answer", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                Response.Write("Entered values do not match");
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

    protected void Reset_Click(object sender, EventArgs e)
    {
        //reset fields
        tb_userid.Text = "";
        tb_hintans.Text = "";
        tb_hintque.SelectedIndex = 0;
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
    //System.Net.Dns.GetHostName()
}