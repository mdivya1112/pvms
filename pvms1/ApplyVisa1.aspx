<%@ Page Title="PASSPORT VISA MANAGEMENT SYSTEM" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="applyvisa1" Codebehind="ApplyVisa1.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
    <p>
    APPLY VISA1</p>

</asp:Content>


<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <p>
    <br />
</p>
<p>
    &nbsp;</p>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="passport_no" runat="server" Enabled="False" Text="Passport No"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="tbpassportno" runat="server" Height="20px" ></asp:TextBox>
&nbsp;&nbsp;
    <asp:Label ID="lpassport" runat="server"></asp:Label>
</p>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;
</p>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Search" runat="server" Text="Search" onclick="Search_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Reset" runat="server" Text="Reset" />
</p>
<p>
</p>
<p>
</p>
</asp:Content>



