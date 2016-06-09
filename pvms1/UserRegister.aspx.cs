//code behind page for user register
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
using System.Globalization;

public partial class userreg : System.Web.UI.Page
{
    bususer bobj = new bususer(); //object declaration for businesslogic layer
    entityuser eobj = new entityuser(); //object declaration for entity layer
    pvms1.activity pa = new pvms1.activity();
    protected void Page_Load(object sender, EventArgs e)
    {
        //fields loaded during page load
        try
        {
            if (!IsPostBack)
            {
                List<string> a = new List<string>();
                List<string> b = new List<string>();
                a = bobj.getqualificationbus();//get qualification types
                DropDownList1.DataSource = a;
                DropDownList1.DataBind();
                b = bobj.getapplytypebus();//get applytype
                DropDownList2.DataSource = b;
                DropDownList2.DataBind();
                Session.Timeout = 15;//session duration
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

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
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        RadioButtonList1.ClearSelection();
    }
    //public void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    Calendar1.Visible = true;
    //}
    //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    //{
    //    TextBox7.Text = Calendar1.SelectedDate.ToShortDateString();
    //    Calendar1.Visible = false;
    //}

    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {


    }

    protected void Register_Click(object sender, EventArgs e)
    {
        //register the user details
        try
        {
           
            if (DropDownList2.Text == "visa")
                eobj.new_tag = "VISA";
            else
                eobj.new_tag = "PASS";
            int id1 = bobj.registerbus(eobj);// get value for new user id
            //determine new user id
            if (id1 < 10)
                eobj.user_id = eobj.new_tag + "-" + "000" + Convert.ToString(id1);
            else if (id1 >= 10 && id1 < 100)
                eobj.user_id = eobj.new_tag + "-" + "00" + Convert.ToString(id1);
            else if (id1 >= 100 && id1 < 999)
                eobj.user_id = eobj.new_tag + "-" + "0" + Convert.ToString(id1);
            else if (id1 >= 1000 && id1 < 9999)
                eobj.user_id = eobj.new_tag + "-" + Convert.ToString(id1);
            string s = eobj.user_id;

            DateTime dt = DateTime.ParseExact(TextBox7.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime b = Convert.ToDateTime(TextBox7.Text);
            if (dt< DateTime.Now)
            {
                eobj.age = DateTime.Now.Year - dt.Year;//calculate age
                //determine citizen type
                if (eobj.age >= 0 && eobj.age < 1)
                    eobj.citizen_type = "infant";
                else if (eobj.age >= 1 && eobj.age < 10)
                    eobj.citizen_type = "Children";
                else if (eobj.age >= 10 && eobj.age < 20)
                    eobj.citizen_type = "Teen";
                else if (eobj.age >= 20 && eobj.age < 50)
                    eobj.citizen_type = "Adult";
                else
                    eobj.citizen_type = "Senior Citizen";//determine citizen type
                eobj.username = TextBox1.Text;//username
                eobj.password = TextBox2.Text;//password
                eobj.qualification = DropDownList1.Text;//qualification
                eobj.emailid = TextBox4.Text;//emailid
                eobj.contact = TextBox3.Text;//contact
                eobj.dob = dt;//store password
                eobj.applytype = DropDownList2.Text;//applytype
                eobj.gender = RadioButtonList1.Text;//gender
                eobj.hint_question = TextBox5.Text;//hint question
                eobj.hint_ans = TextBox6.Text;//hint answer
               
                    bobj.registeruserbus(eobj);//insert values into database
                    
                    //final message
                    Label1.Text = "Dear User,";
                    lerror1.Text = " Your User Id is " + eobj.user_id + " and your password is " + eobj.password;//final mesage
                    lerror2.Text = " You are planning for " + eobj.applytype + " and your citizen type is " + eobj.citizen_type;//final message
                    Session["user_msg"] = " user registered ";
                    Session["reg_time"] = DateTime.Now;
                    Session["user_id"] = s;
                    pa.userdet(Convert.ToDateTime(Session["reg_time"]), s, "user registered", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                    Register.Visible = false;
                    Reset.Visible = false;
              
            }
            else

            {
                pa.userdet(Convert.ToDateTime(Session["reg_time"]), s, "registration error", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
    
                lerror1.Text = "DOB is invalid"; //dob error message
            }
        }
        catch (Exception ex)
        {
            //catch block
            pvms1.error2 er2 = new pvms1.error2();
            er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
            Server.ClearError();
            Response.Redirect("error1.aspx",false);//error page
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    public static string GetServerIP()
    {
        //get server address
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