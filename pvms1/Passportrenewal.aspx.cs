// code behind page for passport renewal 
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
using System.Globalization;
using System.Windows.Forms;

public partial class passrenew : System.Web.UI.Page
{
   
    buspassport bobj1 = new buspassport(); //object declaration for businesslogic layer
    entitypassport eobj1 = new entitypassport(); //object declaration for entity layer
    pvms1.activity pa = new pvms1.activity();
    protected void Page_Load(object sender, EventArgs e)
    {
        //fields loaded during page load
        if ((string)Session["user_id"] != "")
        {
            try
            {
                if (!IsPostBack)
                {
                    List<string> bt = new List<string>();
                    List<string> tos = new List<string>();
                    bt = bobj1.getbtbus();//get booklettype
                    dd_bt.DataSource = bt;
                    dd_bt.DataBind();
                    tos = bobj1.gettosbus();//get type of service
                    rl_tos.DataSource = tos;
                    rl_tos.DataBind();
                    Session.Timeout = 15;//session duration

                }
            }
            catch (Exception ex)
            {
                //exception block
                pvms1.error2 er2 = new pvms1.error2();
                er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                Server.ClearError();
                Response.Redirect("error1.aspx");// error page
            }
        }
        else
        {
            Response.Redirect("Login.aspx");


        }
    }

    protected void tb_passno_TextChanged(object sender, EventArgs e)
    {
        //get country,state,city,pin values for the passport number
        try
        {
           
            eobj1.passsport_id = tb_passno.Text;//passport_id
            bool f = bobj1.passportloginbus(eobj1.passsport_id,(string)Session["user_id"]);
             DateTime d;
             d = bobj1.getexpirydatebus(tb_passno.Text);
             int d1 = Math.Abs(DateTime.Now.Subtract(d).Days);//check whether passport is eligible for renewal
             if ((f==true)&&(d1 >= 1 && d1 <= 366))
              {
                  string[] a = new string[4];
                   a = bobj1.getrenewbus(eobj1.passsport_id);//get country,state,city,pin values
                   lcountry.Text = a[0];//country
                   lstate.Text = a[1];//state
                   lcity.Text = a[2];//city
                   lpin.Text = a[3];//pincode
              }
              else if(f==false)
              {
                  pa.passportrenew(DateTime.Now, "null", (string)Session["user_id"], "passport renew failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                  MessageBox.Show("Incorrect passport id");
              }
              else 
              {
                  pa.passportrenew(DateTime.Now, "null", (string)Session["user_id"], "passport renew failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                   MessageBox.Show("You are not eligible for passport renewal");
                   Session.Contents.RemoveAll();
                   Session.Abandon();
                   Response.Redirect("Login.aspx",false);
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        //renew passport details
        try
        {
           
                DateTime dt;
                bool b = DateTime.TryParseExact(tbissuedate.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out dt);
                if (b)
                {
                    eobj1.passsport_id = tb_passno.Text;//passport_id
                    string s = eobj1.passsport_id;
                    eobj1.new_issue_date = dt;//store new_issue_date
                    eobj1.new_service_type = rl_tos.Text;// store new_service_type
                    eobj1.new_booklet_type = dd_bt.Text;//store new_booklet_type
                    eobj1.new_expiry_date = Convert.ToDateTime(eobj1.new_issue_date.AddYears(10));//new_expiry_date
                    if (rl_tos.Text == "Normal")
                        eobj1.renew_amount = Convert.ToString(1200);//store new renew amount
                    else
                        eobj1.renew_amount = Convert.ToString(1500);//store new renew amount

                    bobj1.insertrenewbus(eobj1);//insert values into database

                    //final message
                    lerror1.Text = "PASSPORT RENEWAL IS SUCCESSFULLY DONE.";
                    lerror2.Text = "Passport renewal fees is Rs." + eobj1.renew_amount;
                    lerror3.Text = "Passport issue date is " + eobj1.new_issue_date.ToString("dd/MM/yyyy") + " and expiry date is " + eobj1.new_expiry_date.ToString("dd/MM/yyyy");
                    Session["renew_msg"] = " passport renewed ";
                    Session["renew_time"] = DateTime.Now;
                    pa.passportrenew(Convert.ToDateTime(Session["renew_time"]), s, (string)Session["user_id"], "passport renewed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                    renew.Visible = false;
                    Reset.Visible = false;

                }
                else
                {
                    pa.passportrenew(DateTime.Now, tb_passno.Text, (string)Session["user_id"], "passport renew failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                    lissuedate.Text = "issue date should be in dd/MM/yyyy format"; //issue date error message
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


    protected void Button2_Click(object sender, EventArgs e)
    {
        //reset fields
        tb_passno.Text = "";
        tbissuedate.Text = "";
        dd_bt.ClearSelection();
        rl_tos.ClearSelection();
        lcountry.Text ="";
        lstate.Text = "";
        lcity.Text = "";
        lpin.Text = "";
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