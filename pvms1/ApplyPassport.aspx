<%@ Page Title="PASSPORT VISA MANAGEMENT SYSTEM" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Inherits="applypass" CodeBehind="ApplyPassport.aspx.cs"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style8
        {
            width: 115px;
        }
    </style>
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
          minDate: 0

      });
  }

);   
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <table class="style6">
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td class="style8">
                            <asp:Label ID="Userid" runat="server" Text="User Id"></asp:Label>
                        </td>
                        <td>
                        &nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="Country" runat="server" Text="Country"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="la_country" runat="server" Text="India"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="State" runat="server" Text="State"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd1_state" runat="server" 
                                onselectedindexchanged="dd1_state_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="City" runat="server" Text="City"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd2_city" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="Pin" runat="server" Text="Pin"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tb_pin" runat="server" Height="22px" 
                                ontextchanged="tb_pin_TextChanged"></asp:TextBox>
                        &nbsp;
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="tb_pin" 
                                ErrorMessage="pin has to be numeric and must be six digits" 
                                SetFocusOnError="True" ValidationExpression="[0-9]{6}"></asp:RegularExpressionValidator>
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="tb_pin" ErrorMessage="Pin can't be left empty"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="type_of_service" runat="server" Text="Type of Service"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd3_tos" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="booklet_type" runat="server" Text="Booklet Type"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd4_bt" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="Issue_date" runat="server" Text="Issue Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tb_issuedate" class="dDate" runat="server" Height="23px" 
                                ontextchanged="tb_issuedate_TextChanged"></asp:TextBox>
                            
                        &nbsp;
                            <asp:Label ID="dateerror" runat="server" BorderStyle="None"></asp:Label>
                            
                        </td>
                    </tr>
                    </table>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;
            <asp:Button ID="Apply" runat="server" Text="Apply" onclick="Apply_Click"  OnClientClick="if (!Page_ClientValidate()){ return false; } this.disabled = true; this.value = 'Saving...';" 
   UseSubmitBehavior="false" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Reset0" runat="server" Text="Reset" onclick="Reset_Click" Height="24px" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lerror1" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lerror2" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <p>
        <h3><b>APPLY PASSPORT</b></h3></p>
</asp:Content>
