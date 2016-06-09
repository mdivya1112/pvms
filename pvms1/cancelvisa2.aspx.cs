//code behind page for cancel visa second page
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
using System.Windows.Forms;

public partial class cancelvisa2 : System.Web.UI.Page
{
    //object declaration for entity and businesslogic layers
    entityvisa eobj2 = new entityvisa();
    busvisa bobj2 = new busvisa();
    pvms1.activity pa = new pvms1.activity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["user_id"] != "")
        {
            try
            {
                if (!IsPostBack)
                {
                    luserid.Text = (string)Session["user_id"];  //session value for user id
                    Session.Timeout = 15;  //session duration

                }
            }
            catch (Exception ex)
            {
                //exception block
                pvms1.error2 er2 = new pvms1.error2();
                er2.errorinf(ex, Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                Server.ClearError();
                Response.Redirect("error1.aspx", false);  //error page
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }

    }
    

    protected void Submit_Click(object sender, EventArgs e)
    {
        //submit cancel visa details
        try
        {
            
            eobj2.user_id = luserid.Text;  //user id
            eobj2.passport_id = tpassno.Text;//passport id
            eobj2.visa_id = tvisano.Text;
            string s0=eobj2.visa_id;//visa id
            bool v = false;
            v = bobj2.checkduplicatevisaidbus(eobj2); //check if visa is already cancelled
            DateTime dt = DateTime.ParseExact(tdoi.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            eobj2.date_of_issue =dt; //date of issue
            bool x1 = bobj2.checkissuedatebus(s0, dt);
            string x = "";
            x = bobj2.validuserpassbus(eobj2); //check valid passport id and user id values
            eobj2.date_of_expiry = bobj2.getexpirybus(eobj2);  //get date of expiry of visa
            if ((v==false)&&(x1==true)&&(x == eobj2.passport_id)&&(eobj2.date_of_expiry > DateTime.Now))
             {
                 string[] s = new string[2];
                 s = bobj2.getoccbus1(eobj2);
                 eobj2.occupation = s[0]; //occupation
                 eobj2.cost = s[1]; //visa cost
                 eobj2.date_of_cancel = DateTime.Now;  //date of cancel visa
                 //calculate difference between date of expiry and date of cancel of visa 
                 int diff = Math.Abs(((eobj2.date_of_expiry.Year - eobj2.date_of_cancel.Year) * 12) + (eobj2.date_of_expiry.Month - eobj2.date_of_cancel.Month));
                 //calculate fine amount
                  if (eobj2.occupation == "Student")
                    {
                                if (diff < 6)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.15)));
                                else if (diff >= 6)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.25)));
                    }
                    else if (eobj2.occupation == "Retired Employee")
                    {
                                if (diff < 6)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.10)));
                                else if (diff >= 6)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.20)));
                    }
                    else if (eobj2.occupation == "Private Employee")
                   {
                                if (diff < 6)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.15)));
                                else if (diff >= 6 && diff < 12)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.25)));
                                else if (diff >= 12)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.20)));

                  }
                 else if (eobj2.occupation == "Self Employed")
                  {
                                if (diff < 6)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.15)));
                                else if (diff >= 6)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.25)));
                  }
                 else if (eobj2.occupation == "Government Employee")
                  {
                                if (diff < 6)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.12)));
                                else if (diff >= 6 && diff < 12)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.20)));
                                else if (diff >= 12)
                                    eobj2.fine_amount = Convert.ToString((double)((Convert.ToInt32(eobj2.cost)) * (0.25)));
                 }
                            
                 bobj2.insertcancelvisabus(eobj2);  //insert cancelled visa details into database
                 //final message
                 lerror1.Text = "Your request has been submitted successfully.";
                 lerror2.Text = "Please pay Rs." + eobj2.fine_amount + " to complete the cancellation process";
                 Session["cancel_msg"] = " visa cancelled ";
                 Session["cancel_time"] = DateTime.Now;
                 pa.cancelvisa(Convert.ToDateTime(Session["cancel_time"]), s0, (string)Session["user_id"], "visa cancelled", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                 Submit.Visible = false;
                 }
                 else if(v==true)
                 {
                            //error message when Visa is already cancelled
                            MessageBox.Show("Your Visa is already cancelled");
                            pa.cancelvisa(DateTime.Now, s0, (string)Session["user_id"], "visa cancelled", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                            Session.Contents.RemoveAll();
                            Response.Redirect("Login.aspx",false);
                 }
                   
                else if(x1==false)
                {
                        //error message for incorrect issue date
                         MessageBox.Show("incorrect issue date");
                        pa.cancelvisa(DateTime.Now, s0, (string)Session["user_id"], "visa cancel failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                }
                
                else if(eobj2.date_of_expiry < DateTime.Now)
                {
                    //error message when visa already expired
                    MessageBox.Show("Visa already expired");
                    pa.cancelvisa(DateTime.Now, s0, (string)Session["user_id"], "visa cancel failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
                    Session.Contents.RemoveAll();
                    Response.Redirect("Login.aspx",false);

                }
            
            else if (x != eobj2.passport_id)
            {
                //error mesage for incorrect userid and passport id pair
                MessageBox.Show("incorrect user id or passport id");
                pa.cancelvisa(Convert.ToDateTime(Session["cancel_time"]), s0, (string)Session["user_id"], "fail-visa already failed", Request.ServerVariables["REMOTE_ADDR"], GetServerIP(), System.Net.Dns.GetHostName());
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
        tpassno.Text = "";
        tvisano.Text = "";
        tdoi.Text = "";
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