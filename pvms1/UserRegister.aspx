<%@ Page Language="C#" AutoEventWireup="true" Inherits="userreg" Codebehind="UserRegister.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/mystylesheet.css" rel="stylesheet" type="text/css" />
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="pikaday.js" type="text/javascript"></script>
    <link href="css_calendar/pikaday.css" rel="stylesheet" type="text/css" />
    <link href="css_calendar/site.css" rel="stylesheet" type="text/css" />
    <link href="css_calendar/theme.css" rel="stylesheet" type="text/css" />
    <title>PASSPORT VISA MANAGEMENT SYSTEM</title>
     <%-- <script type="text/javascript">
         var picker = new Pikaday(
                    {
                        field: document.getElementById('TextBox7'),
                        yearRange: [1900, 2100],
                        dateFormat: 'dd/MM/yy'
                                             

                    });
                    </script>
--%>
                     <!-- Load jQuery from Google's CDN -->
    <!-- Load jQuery UI CSS  -->
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <!-- Load jQuery JS -->
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <!-- Load jQuery UI Main JS  -->
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <style>
        
    </style> 
 <script type="text/jscript">
     /*  jQuery ready function. Specify a function to execute when the DOM is fully loaded.  */
     $(document).ready(

     /* This is the function that will get executed after the DOM is fully loaded */
  function () {
     
        $(".dDate").datepicker({
          changeMonth: true, //this option for allowing user to select month
          changeYear: true, //this option for allowing user to select from year range
          dateFormat: 'dd/mm/yy',
          maxDate:new Date,
          yearRange: "1900:2100"
      });
  }

);   
    
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style21
        {
            width: 130px;
            height: 72px;
        }
        .style22
        {
            height: 72px;
        }
        .style33
        {
        }
        .style36
        {
            width: 699px;
            height: 72px;
        }
        .style41
        {
            height: 24px;
        }
        .style42
        {
        }
        .style43
        {
            width: 130px;
            height: 72px;
            text-align: left;
        }
        .style56
        {
            width: 130px;
            height: 49px;
        }
        .style57
        {
            height: 49px;
        }
        .style58
        {
            width: 130px;
            height: 89px;
        }
        .style59
        {
            height: 89px;
        }
        .style60
        {
            width: 130px;
            height: 4px;
        }
        .style61
        {
            height: 4px;
        }
        .style62
        {
            width: 130px;
            height: 12px;
        }
        .style63
        {
            height: 12px;
        }
        .style64
        {
            width: 130px;
            height: 6px;
        }
        .style65
        {
            height: 6px;
        }
        .style66
        {
            width: 130px;
            height: 50px;
        }
        .style67
        {
            height: 50px;
        }
        </style>
        

</head>


<body>



    <form id="form1" runat="server" class="w3-responsive" >
    <h3 class="w3-container w3-green" 
       >User Registration&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="Logout" class="w3-display-topright" runat="server" 
            NavigateUrl="~/Logout.aspx">Logout</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h3>

    <div>
  
      
    <table class="style1">
        <tr>
            <td class="style42" align="left" valign="top">
                <asp:Label ID="User_name" runat="server"  Text="User name"></asp:Label>
                    </td>
            <td align="left" valign="top">
                <asp:TextBox ID="TextBox1" runat="server" Width="148px" BorderStyle="None" 
                    Height="16px"  ontextchanged="TextBox1_TextChanged"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="Username cannot be left blank." 
                    BorderStyle="None"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox1" 
                    ErrorMessage="Username should contain only alphabets" 
                    ValidationExpression="[a-zA-Z&quot; &quot;]*" BorderStyle="None"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style64">
                </td>
            <td class="style65">
                <br />
            </td>
        </tr>
        <tr>
            <td class="style21">
                <br />
                <asp:Label ID="Password" runat="server" Text="Password"></asp:Label>
                <br />
                <br />
                <br />
                <br />
            </td>
            <td class="style22">
                <asp:TextBox ID="TextBox2"  runat="server" 
                    Width="153px" BorderStyle="None" 
                    Height="16px" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="Password cannot be left blank."></asp:RequiredFieldValidator>
     
                
                <br />
     
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox2" 
                    ErrorMessage="Password should contain only 8 characters and should contain #" 
                    ValidationExpression="(?=.*[#])([a-zA-Z0-9#]{8})"></asp:RegularExpressionValidator>
                 </td>
        </tr>
        <tr>
            <td class="style42">
                </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style43">
                <asp:Label ID="Qualification" runat="server" Text="Qualification"></asp:Label>
                
            </td>
            <td class="style22">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                
                </td>
        </tr>
        <tr>
            <td class="style66">
                <br />
            </td>
            <td class="style67">
                <br />
            </td>
        </tr>
        <tr>
            <td class="style21">
                <asp:Label ID="Email_id" runat="server" Text="Email Id"></asp:Label>
                <br />
                <br />
            </td>
            <td class="style22">
                <br />
                <asp:TextBox ID="TextBox4" runat="server"  Width="153px" BorderStyle="None" 
                    Height="19px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox4" ErrorMessage="E-mail ID cannot be left blank."></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="TextBox4" ErrorMessage="E-mail ID should contain @ and ." 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style42">
                </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style42">
                <asp:Label ID="Contact" runat="server" Text="Contact"></asp:Label>
                <br />
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox ID="TextBox3"  runat="server" Width="153px" BorderStyle="None" 
                    Height="19px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="Contact cannot be left blank"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="Contact should contain only numbers and should be 10 digits" 
                    ValidationExpression="[\d]{10}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style62">
                </td>
            <td class="style63">
                <br />
            </td>
        </tr>
        <tr>
            <td class="style21">
                <asp:Label ID="Date_of_Birth" runat="server" Text="Date Of Birth"></asp:Label>
                &nbsp;<br />
                <br />
            </td>
            <td class="style36" width="350px">
                <asp:TextBox ID="TextBox7" runat="server" class="dDate" ontextchanged="TextBox7_TextChanged" 
                    BorderStyle="None" Height="19px" Width="153px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="TextBox7" ErrorMessage="DOB cannot be left blank"></asp:RequiredFieldValidator>
            &nbsp;<br />
            </td>
        </tr>
        <tr>
            <td class="style56">
                </td>
            <td class="style57">
                </td>
        </tr>
        <tr>
            <td class="style21" style="border-spacing: inherit">
                <asp:Label ID="Apply_type" runat="server" Text="Apply Type"></asp:Label>
                <br />
                <br />
                <br />
              
            </td>
            <td style="border-spacing: inherit" valign="top" class="style22">
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
                &nbsp;
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style56">
                </td>
            <td class="style57">
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style21">
                <asp:Label ID="Gender" runat="server" Text="Gender"></asp:Label>
                <br />
                <br />
            </td>
            <td class="style22">
                <asp:RadioButtonList class="w3-radio" ID="RadioButtonList1" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="RadioButtonList1" ErrorMessage="select the gender"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style56">
                </td>
            <td class="style57">
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style21">
                <br />
                <asp:Label ID="Hint_Question" runat="server" Text="HintQuestion"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
            </td>
            <td class="style22">
                <asp:TextBox ID="TextBox5" runat="server" Width="153px" BorderStyle="None" 
                    Height="19px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="TextBox5" ErrorMessage="Hint Question cannot be left blank."></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style56">
                </td>
            <td class="style57">
                
            </td>
        </tr>
        <tr>
            <td class="style21">
               
                <asp:Label ID="Hint_answer" runat="server" Text="HintAnswer"></asp:Label>
                
               
            </td>
            <td class="style22">
                <br />
                <asp:TextBox ID="TextBox6" runat="server" Width="153px" BorderStyle="None" 
                    Height="19px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="TextBox6" ErrorMessage="Hint answer cannot be left blank."></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style60">
                <br />
            </td>
            <td class="style61">
                </td>
        </tr>
        <tr>
            <td class="style58">
                <asp:Button ID="Register" runat="server" Height="33px" Text="Register" 
                    onclick="Register_Click" BorderStyle="None" class="w3-btn w3-blue" 
                    Width="92px" />
              
            </td>
            <td class="style59">
                <asp:Button ID="Reset" runat="server" Height="32px" onclick="Reset_Click" 
                    Text="Reset" CausesValidation="False" BorderStyle="None" 
                    class="w3-btn w3-blue" Width="92px" />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42" colspan="2">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style41" colspan="2">
                <asp:Label ID="lerror1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style33" colspan="2">
                <asp:Label ID="lerror2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style42">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
      
     </div>      
    </form>
</body>
</html>
