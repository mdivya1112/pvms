<%@ Page Title="PASSPORT VISA MANAGEMENT SYSTEM" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="_Default" Codebehind="cancelvisa1.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
        width: 100%;
    }
    .style9
    {
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
    <p>
    CANCEL VISA</p>
</asp:Content>


<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <table class="style6">
    <tr>
        <td class="style9">
            <asp:Label ID="UserId" runat="server" Text="UserId"></asp:Label>
        </td>
        <td>
            <asp:Label ID="luserid" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            <asp:Label ID="security_question" runat="server" Text="Security Question"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="dd_que" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            <asp:Label ID="Security_answer" runat="server" Text="Security Answer"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="tbsecans" runat="server" BorderStyle="None" 
                ontextchanged="tbsecans_TextChanged"></asp:TextBox>
        &nbsp;
            <asp:RequiredFieldValidator ID="rfans" runat="server" 
                ControlToValidate="tbsecans" ErrorMessage="should not be left blank"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            <asp:Button ID="Submit" runat="server" Text="Submit" onclick="Submit_Click" 
                CausesValidation="False" />
        </td>
    </tr>
    <tr>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style9" colspan="2">
            <asp:Label ID="lerror" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<p>
</p>
</asp:Content>



