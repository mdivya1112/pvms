
// code behind page for apply passport
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


public partial class applypass  : System.Web.UI.Page
{
    //object declaration for entity and business logic layers
    entitypassport eobj1 = new entitypassport();
    buspassport bobj1 = new buspassport();
    //object declaration for activity class
    pvms1.activity pa = new pvms1.activity();
    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["user_id"] != "")//prevents direct url access
        {
            try
            {
                if (!IsPostBack)
                {
                    string a0 = (string)Session["user_id"];
                    bool k = false;
                    k = bobj1.checkduplicatepassbus(a0);
                    DateTime j = bobj1.getexpirydate1bus(a0);
                    if ((k == false) || ((k == true) && (DateTime.Now > j)))
                    {
                        Label1.Text = (string)Session["user_id"];
                        List<string> tos = new List<string>();
                        List<string> bt = new List<string>();
                        List<string> state = new List<string>();
                        tos = bobj1.gettosbus();//get type of service list
                        dd3_tos.DataSource = tos;
                        dd3_tos.DataBind();
                        bt = bobj1.getbtbus();//get booklet type list
                        dd4_bt.DataSource = bt;
                        dd4_bt.DataBind();
                        state = bobj1.getstatebus();//get state list
                        dd1_state.DataSource = state;
                        dd1_state.DataBind();
                        dd1_state.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                        dd1_state.Items[0].Attributes.Add("disabled", "disabled");
                        Session.Timeout = 15;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    }
                    else
                    {
                        Response.Redirect("Login.aspx", false);
                        MessageBox.Show("You are not eligible to apply passport");
                        Session.Contents.RemoveAll();
                    }
                }
            }
            catch (Exception ex)
            {
                //exception block
                pvms1.error2 er2 = new pvms1.error2();
                er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                Server.ClearError();
                Response.Redirect("error1.aspx", false);
            }
        }
        else
        {
            Response.Redirect("Login.aspx",false);
        }


     }


    protected void Apply_Click(object sender, EventArgs e)
    {
        //register passport details
        try
        {
           
            eobj1.new_pass_id = bobj1.passportidbus(eobj1);//get next passport id
            //new passport id
            if (dd4_bt.Text == "30 Pages")
            {
                if (eobj1.new_pass_id < 10)
                    eobj1.passsport_id = "FPS-" + "30" + "000" + eobj1.new_pass_id;
                else if (eobj1.new_pass_id >= 10 && eobj1.new_pass_id < 100)
                    eobj1.passsport_id = "FPS-" + "30" + "00" + eobj1.new_pass_id;
                else if (eobj1.new_pass_id >= 100 && eobj1.new_pass_id < 1000)
                    eobj1.passsport_id = "FPS-" + "30" + "0" + eobj1.new_pass_id;
                else if (eobj1.new_pass_id >= 1000 && eobj1.new_pass_id < 10000)
                    eobj1.passsport_id = "FPS-" + "30" + eobj1.new_pass_id;
            }
            else
            {
                if (eobj1.new_pass_id < 10)
                    eobj1.passsport_id = "FPS-" + "60" + "000" + eobj1.new_pass_id;
                else if (eobj1.new_pass_id >= 10 && eobj1.new_pass_id < 100)
                    eobj1.passsport_id = "FPS-" + "60" + "00" + eobj1.new_pass_id;
                else if (eobj1.new_pass_id >= 100 && eobj1.new_pass_id < 1000)
                    eobj1.passsport_id = "FPS-" + "60" + "0" + eobj1.new_pass_id;
                else if (eobj1.new_pass_id >= 1000 && eobj1.new_pass_id < 10000)
                    eobj1.passsport_id = "FPS-" + "60" + eobj1.new_pass_id;
            }
            string s = eobj1.passsport_id;
            eobj1.user_id = Label1.Text;//user id
            eobj1.country = la_country.Text;//country value
            eobj1.state = dd1_state.Text;//state value
            eobj1.city = dd2_city.Text;//city value
            eobj1.pin = tb_pin.Text;//pin value
            DateTime dt;
            bool b = DateTime.TryParseExact(tb_issuedate.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out dt);
            if (b)
            {
                eobj1.issue_date = dt;//issue date
                eobj1.type_of_service = dd3_tos.Text;//type of service
                eobj1.booklet_type = dd4_bt.Text;//booklet type
                eobj1.expiry_date = Convert.ToDateTime(eobj1.issue_date.AddYears(10));//expiry date
                //calculate fee amount
                if (eobj1.type_of_service == "Normal")
                    eobj1.amount = Convert.ToString(2500);
                else
                    eobj1.amount = Convert.ToString(5000);
               
                    bobj1.applypassportbus(eobj1);//insert into database
                    //final message
                    lerror1.Text = "Need the passport number while giving payment? Please note down your Id " + eobj1.passsport_id;
                    lerror2.Text = "Passport application cost is Rs." + eobj1.amount;
                    Session["applypass_msg"] = " passport applied ";
                    Session["applypass_time"] = DateTime.Now;
                    pa.applypass(Convert.ToDateTime(Session["applypass_time"]), s, (string)Session["user_id"], "passport applied", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                    Apply.Visible = false;
                    Reset0.Visible = false;

            }
                //error message for incorrect issue date format
            else
            {
                pa.applypass(DateTime.Now, "null", (string)Session["user_id"], "passport registration failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                dateerror.Text = "Date should be in dd/MM/yy format";
            }
        }
        catch (Exception ex)
        {
            //exception block
            pvms1.error2 er2 = new pvms1.error2();
            er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
            Server.ClearError();
            Response.Redirect("error1.aspx");
        }
    }

    protected void dd1_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get city for selected states
        try
        {
            eobj1.state_name = dd1_state.Text;//state name
            eobj1.state_id = bobj1.getstateidbus(eobj1.state_name);//get state id
            //string stateid = eobj1.state_id;
            //List<string> cityname1 = new List<string>();
            //cityname1 = bobj1.getcitynamebus(this.eobj1.state_id);

            dd2_city.DataSource = bobj1.getcitynamebus(eobj1.state_id);//city list
            //cityname1;
            dd2_city.DataBind();
        }
        catch (Exception ex)
        {
            //exception block
            pvms1.error2 er2 = new pvms1.error2();
            er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
            Server.ClearError();
            Response.Redirect("error1.aspx",false);
        }
        
    }

    protected void tb_pin_TextChanged(object sender, EventArgs e)
    {

    }

    protected void tb_issuedate_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Reset_Click(object sender, EventArgs e)
    {
        //reset values
         Label1.Text = "";
        tb_pin.Text = "";
        tb_issuedate.Text="";
        dd1_state.SelectedIndex = 0;
        dd2_city.SelectedIndex = 0;
        dd3_tos.SelectedIndex = 0;
        dd4_bt.SelectedIndex = 0;
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