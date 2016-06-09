<%@ Page Title="PASSPORT VISA MANAGEMENT SYSTEM" Language="C#" AutoEventWireup="true" Inherits="forgotpass" Codebehind="ForgotPass.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/mystylesheet.css" rel="stylesheet" type="text/css" />
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 166px;
        }
        .style3
        {
            width: 166px;
            height: 22px;
        }
        .style4
        {
            height: 22px;
        }
        .style5
        {
            width: 166px;
            height: 33px;
        }
        .style6
        {
            height: 33px;
        }
        .style7
        {
            width: 166px;
            height: 50px;
        }
        .style8
        {
            height: 50px;
        }
        .style9
        {
            width: 166px;
            height: 43px;
        }
        .style10
        {
            height: 43px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <h3 class="w3-container w3-green">Reset Password</h3>

    <div>
    
        <table class="style1">
            <tr>
                <td class="style9">
                    <asp:Label ID="User_Id" runat="server" Text="UserId"></asp:Label>
                </td>
                <td class="style10">
                    <asp:TextBox ID="tb_userid" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tb_userid" ErrorMessage="Enter your user id"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="Hint_Question" runat="server" Text="Hint Question"></asp:Label>
                </td>
                <td class="style6">
                    <asp:DropDownList ID="tb_hintque" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style4">
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="Hint_Answer" runat="server" Text="Hint Answer"></asp:Label>
                </td>
                <td class="style8">
                    <asp:TextBox ID="tb_hintans" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tb_hintans" ErrorMessage="enter the hint answer"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="Submit" runat="server" onclick="Button1_Click" Text="Submit" />
                </td>
                <td>
                    <asp:Button ID="Reset" runat="server" onclick="Reset_Click" Text="Reset" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
