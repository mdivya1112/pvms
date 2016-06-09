//code behind page for apply visa second page
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

public partial class applyvisa2 : System.Web.UI.Page
{
    //object declaration for entity and business logic layer
    entityvisa eobj2 = new entityvisa();
    busvisa bobj2 = new busvisa();
    //object for activity class
    pvms1.activity pa = new pvms1.activity();
    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //fields to be loaded during page load
        if ((string)Session["user_id"] != "")//prevents direct url access
        {
            try
            {
                if (!IsPostBack)
                {
                    luserid.Text = (string)Session["user_id"];//session value  for user id
                    List<string> des = new List<string>();
                    List<string> occ = new List<string>();
                    des = bobj2.getdestinationbus();//get destination values
                    dddestination.DataSource = des;
                    dddestination.DataBind();
                    occ = bobj2.getoccupationbus();//get occupation values
                    ddoccupation.DataSource = occ;
                    ddoccupation.DataBind();
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
    
    //protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
    //{
    //    //select applydate from calendar
    //    tbapplydate.Text = Calendar1.SelectedDate.ToShortDateString(); 
    //    Calendar1.Visible = false;

    //}
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    //change visiblity of calendar
    //    Calendar1.Visible = true;

    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        //register visa details
        try
        {
            
           eobj2.user_id = luserid.Text;//user id
            eobj2.passport_id = (string)Session["passno"];//passport number
            eobj2.destination = dddestination.Text;//destination
            eobj2.occupation = ddoccupation.Text;//occupation
            //determine duration of visa validity
            if (ddoccupation.Text == "Student")
            {
                eobj2.visa_permit = "2";
                eobj2.new_visa_tag = "ST";
                if (dddestination.Text == "USA")
                    eobj2.cost = "3000";
                else if (dddestination.Text == "China")
                    eobj2.cost = "1500";
                else if (dddestination.Text == "Japan")
                    eobj2.cost = "3500";
            }
            else if (ddoccupation.Text == "Private Employee")
            {
                eobj2.visa_permit = "3";
                eobj2.new_visa_tag = "PE";
                if (dddestination.Text == "USA")
                    eobj2.cost = "4500";
                else if (dddestination.Text == "China")
                    eobj2.cost = "2000";
                else if (dddestination.Text == "Japan")
                    eobj2.cost = "4000";
            }
            else if (ddoccupation.Text == "Government Employee")
            {
                eobj2.visa_permit = "4";
                eobj2.new_visa_tag = "GE";
                if (dddestination.Text == "USA")
                    eobj2.cost = "5000";
                else if (dddestination.Text == "China")
                    eobj2.cost = "3000";
                else if (dddestination.Text == "Japan")
                    eobj2.cost = "4500";
            }
            else if (ddoccupation.Text == "Self Employed")
            {
                eobj2.visa_permit = "1";
                eobj2.new_visa_tag = "SE";
                if (dddestination.Text == "USA")
                    eobj2.cost = "6000";
                else if (dddestination.Text == "China")
                    eobj2.cost = "4000";
                else if (dddestination.Text == "Japan")
                    eobj2.cost = "9000";
            }
            else if (ddoccupation.Text == "Retired Employee")
            {
                eobj2.visa_permit = "1.5";
                eobj2.new_visa_tag = "RE";
                if (dddestination.Text == "USA")
                    eobj2.cost = "2000";
                else if (dddestination.Text == "China")
                    eobj2.cost = "2000";
                else if (dddestination.Text == "Japan")
                    eobj2.cost = "1000";
            }
            eobj2.new_visa_id = bobj2.getnewvisaidbus(eobj2);//get new visa id
            //determine new visa id
            if (ddoccupation.Text == "Student")
            {
                if (eobj2.new_visa_id < 10)
                    eobj2.visa_id = "STU-" + "000" + eobj2.new_visa_id;
                else if (eobj2.new_visa_id >= 10 && eobj2.new_visa_id < 100)
                    eobj2.visa_id = "STU-" + "00" + eobj2.new_visa_id;
                else if (eobj2.new_visa_id >= 100 && eobj2.new_visa_id < 1000)
                    eobj2.visa_id = "STU-" + "0" + eobj2.new_visa_id;
                else if (eobj2.new_visa_id >= 1000 && eobj2.new_visa_id < 10000)
                    eobj2.visa_id = "STU-" + eobj2.new_visa_id;
                else
                    eobj2.visa_id = "STU-" + "0000";
            }
            else
            {
                if (eobj2.new_visa_id < 10)
                    eobj2.visa_id = eobj2.new_visa_tag + "-000" + eobj2.new_visa_id;
                else if (eobj2.new_visa_id >= 10 && eobj2.new_visa_id < 100)
                    eobj2.visa_id = eobj2.new_visa_tag + "-00" + eobj2.new_visa_id;
                else if (eobj2.new_visa_id >= 100 && eobj2.new_visa_id < 1000)
                    eobj2.visa_id = eobj2.new_visa_tag + "-0" + eobj2.new_visa_id;
                else if (eobj2.new_visa_id >= 1000 && eobj2.new_visa_id < 10000)
                    eobj2.visa_id = eobj2.new_visa_tag + "-" + eobj2.new_visa_id;
                else
                    eobj2.visa_id = eobj2.new_visa_tag + "0000";
            }
            string s=eobj2.visa_id;
            string dr = DateTime.ParseExact(tbapplydate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            eobj2.date_of_apply = Convert.ToDateTime(dr);//date of application of visa
           // DateTime dt = DateTime.ParseExact(tbapplydate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
           
            DateTime dt = Convert.ToDateTime(dr);
            eobj2.date_of_issue = dt.AddDays(10);//calculate date of issue of visa
            //determine date of expiry
            if (ddoccupation.Text == "Retired Employee")
            {
                //int z = 15;
                //int z1 = z * 12;
                //int z2 = z / 10;
                eobj2.date_of_expiry = eobj2.date_of_issue.AddMonths(18);
            }
            else
            {
                
                int q = Convert.ToInt32(eobj2.visa_permit);
                eobj2.date_of_expiry = eobj2.date_of_issue.AddYears(q);
            }
           
                bobj2.insertvisabus(eobj2);//insert visa values into database
                //count = count + 1;
                //final message
                message.Text = "Dear User your Visa request has been accepted successfully with id " + eobj2.visa_id;
                userid.Text = "UserId";
                useridval.Text = (string)Session["user_id"];
                des_tination.Text = "Destination";
                destinationval.Text = eobj2.destination;
                occ_pation.Text = "Employee Occupation";
                occupationval.Text = eobj2.occupation;
                doa.Text = "Date Of Application";
                doaval.Text = Convert.ToString(eobj2.date_of_apply.ToString("dd/MM/yyyy"));
                doi.Text = "Date Of Issue";
                doival.Text = Convert.ToString(eobj2.date_of_issue.ToString("dd/MM/yyyy"));
                doe.Text = "Date Of Expiry";
                doeval.Text = Convert.ToString(eobj2.date_of_expiry.ToString("dd/MM/yyyy"));
                Session["applyvisa_msg"] = " Visa applied ";//activity string 
                Session["visa_time"] = DateTime.Now; //visa apply time
                pa.applyvisa(DateTime.Now, s, (string)Session["user_id"], "visa applied", Request.ServerVariables["REMOTE_ADDR"], (string)Session["pass_no"], GetServerIP(), System.Net.Dns.GetHostName());
           
            issue.Visible = false;
            Reset.Visible = false;
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
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        //block past dates
        if (e.Day.Date < DateTime.Now.Date)
        {
            e.Day.IsSelectable = false;
            //e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
    }
    public static string GetServerIP()
    {
        //get server name
        string strHostName = System.Net.Dns.GetHostName();

        IPHostEntry ipHostInfo = Dns.GetHostEntry(strHostName);

        foreach (IPAddress address in ipHostInfo.AddressList)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork)
                return address.ToString();
        }

        return string.Empty;
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        tbapplydate.Text = "";

    }
    //System.Net.Dns.GetHostName()
   
}