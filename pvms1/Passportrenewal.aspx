<%@ Page Title="PASSPORT VISA MANAGEMENT SYSTEM" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="passrenew" Codebehind="Passportrenewal.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
        width: 100%;
    }
    .style7
    {
        width: 111px;
    }
    .style10
    {
        width: 111px;
        height: 23px;
    }
    .style11
    {
        height: 23px;
    }
    .style12
    {
        width: 111px;
        height: 65px;
    }
    .style13
    {
        height: 65px;
    }
    .style18
    {
        height: 6px;
    }
    .style19
    {
        height: 6px;
    }
    .style20
    {
        width: 111px;
        height: 3px;
    }
    .style21
    {
        height: 3px;
    }
    .style22
    {
        width: 111px;
        height: 9px;
    }
    .style23
    {
        height: 9px;
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
          minDate:0
         
      });
  }

);   
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
    <p>
    PASSPORT RENEWAL</p>
</asp:Content>


<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table class="style6">
    <tr>
        <td class="style7">
&nbsp;<asp:Label ID="Label6" runat="server" Text="PassportNo"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tb_passno" runat="server" AutoPostBack="True" Height="21px" 
                ontextchanged="tb_passno_TextChanged"></asp:TextBox>
        &nbsp;&nbsp;
            <asp:Label ID="lpassportno" runat="server"></asp:Label>
        &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="tb_passno" 
                ErrorMessage="passport number cannot be left blank"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7">
            <asp:Label ID="Label7" runat="server" Text="Country"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lcountry" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style7">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7">
            <asp:Label ID="Label8" runat="server" Text="State"></asp:Label>
&nbsp;
        </td>
        <td>
            <asp:Label ID="lstate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7">
            <asp:Label ID="Label9" runat="server" Text="City"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lcity" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7">
            <asp:Label ID="Label10" runat="server" Text="Pin"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lpin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style20">
        </td>
        <td class="style21">
        </td>
    </tr>
    <tr>
        <td class="style22">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label11" runat="server" Text="Type of service"></asp:Label>
            &nbsp;</td>
        <td class="style23">
&nbsp;
            <asp:RadioButtonList ID="rl_tos" runat="server">
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="rl_tos" ErrorMessage="select type of service"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label12" runat="server" Text="Type of booklet"></asp:Label>
        </td>
        <td>
            <br />
            <asp:DropDownList ID="dd_bt" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
&nbsp;Issue Date
        </td>
        <td class="style11">
            <asp:TextBox ID="tbissuedate" runat="server" class="dDate" Height="16px"></asp:TextBox>
        &nbsp;
            <asp:Label ID="lissuedate" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="tbissuedate" ErrorMessage="issue date cannot be left blank"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style10">
            &nbsp;</td>
        <td class="style11">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style18">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="renew" runat="server" Text="Renew" onclick="Button1_Click" />
        </td>
        <td class="style19">
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Reset" runat="server" Text="Reset" onclick="Button2_Click" />
        </td>
    </tr>
    <tr>
        <td class="style18">
            &nbsp;</td>
        <td class="style19">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style18" colspan="2">
            <asp:Label ID="lerror1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style18">
            &nbsp;</td>
        <td class="style19">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style18" colspan="2">
            <asp:Label ID="lerror2" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style18">
            &nbsp;</td>
        <td class="style19">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style18" colspan="2">
            <asp:Label ID="lerror3" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style12">
            &nbsp;</td>
        <td class="style13">
        </td>
    </tr>
</table>
</asp:Content>



