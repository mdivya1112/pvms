<%@ Page Title="PASSPORT VISA MANAGEMENT SYSTEM" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="applyvisa2" Codebehind="ApplyVisa2.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style10
        {
        }
        .style11
        {
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <p>
    APPLY VISA</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   
        <table class="style6">
            <tr>
                <td class="style11">
                    <asp:Label ID="User_id" runat="server" Text="User Id"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="luserid" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="destination" runat="server" Text="Destination"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dddestination" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="Occupation" runat="server" Text="Occupation"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddoccupation" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="Label3" runat="server" Text="Date of Application"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbapplydate" runat="server" Height="27px" class="dDate"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
        <asp:Button ID="issue" class="button1" runat="server" onclick="Button1_Click" 
            Text="Issue" />
                </td>
                <td>
        <asp:Button ID="Reset" class="button1" runat="server" onclick="Button1_Click1" 
                        Text="Reset" />
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11" colspan="2">
                    <asp:Label ID="message" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="userid" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="useridval" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style10" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="des_tination" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="destinationval" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="occ_pation" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="occupationval" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="doa" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="doaval" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="doi" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="doival" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="doe" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="doeval" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="co_st" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="costval" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;</p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
<p>
</p>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

