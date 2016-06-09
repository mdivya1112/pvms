<%@ Page Title="PASSPORT VISA MANAGEMENT SYSTEM" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="cancelvisa2" Codebehind="cancelvisa2.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
        width: 100%;
    }
    .style7
    {
        }
    .style8
    {
        width: 146px;
        height: 12px;
    }
    .style9
    {
        height: 12px;
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
          yearRange:"1900:2100"
      });
  }

);   
    
    </script> 
    <%-- <script type="text/javascript">
         var picker = new Pikaday(
                    {
                        field: document.getElementById('tdoi'),
                        yearRange: [1900, 2100],
                        dateFormat: 'dd/MM/yy'
                        //                        maxDate:new Date(

                    });
                    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <p>
    CANCEL VISA</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style6">
    <tr>
        <td class="style7">
            <asp:Label ID="UserID" runat="server" Text="UserID"></asp:Label>
        </td>
        <td>
            <asp:Label ID="luserid" runat="server"></asp:Label>
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
            <asp:Label ID="Passport_No" runat="server" Text="Passport No"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tpassno" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="rpassno" runat="server" 
                ControlToValidate="tpassno" ErrorMessage="should not be left blank"></asp:RequiredFieldValidator>
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
            <asp:Label ID="Visa_no" runat="server" Text="Visa No"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tvisano" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="rvisano" runat="server" 
                ControlToValidate="tvisano" ErrorMessage="should not be left blank"></asp:RequiredFieldValidator>
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
            <asp:Label ID="_of_Issue" runat="server" Text="Date of Issue"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tdoi" class="dDate" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style8">
            &nbsp;&nbsp;<asp:Button ID="Submit" runat="server" Text="Submit" 
                onclick="Submit_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td class="style9">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Reset0" runat="server" Text="Reset" 
                onclick="Reset_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7" colspan="2">
            <asp:Label ID="lerror1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style7">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7" colspan="2">
            <asp:Label ID="lerror2" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

