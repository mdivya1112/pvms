<%@ Page Title="PASSPORT VISA MANAGEMENT SYSTEM" Language="C#" AutoEventWireup="true" CodeFile="ResetPass.aspx.cs" Inherits="ResetPass" %>

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
            width: 238px;
        }
    </style>
</head>
<body>
<h3 class="w3-container w3-green w3-responsive">Reset Password</h3>

    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2">
                    <asp:Label ID="user_id" runat="server" Text="User ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tuserid" runat="server" BorderStyle="None" 
                        ontextchanged="tbuserid_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tuserid" ErrorMessage="enter the user id"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="new_pass" runat="server" Text="New Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_newpassword" runat="server" BorderStyle="None" 
                        ontextchanged="tb_newpassword_TextChanged" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tb_newpassword" ErrorMessage="enter the new password"></asp:RequiredFieldValidator>
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="tb_newpassword" 
                        ErrorMessage="password should be 8 characters and should contain #" 
                        ValidationExpression="(?=.*[#])([a-zA-Z0-9#]{8})"></asp:RegularExpressionValidator>
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
                    <asp:Label ID="confirm_pass" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_confirmpassword" runat="server" BorderStyle="None" 
                        ontextchanged="tb_confirmpassword_TextChanged" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="tb_confirmpassword" ErrorMessage="Enter the password again"></asp:RequiredFieldValidator>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" 
                        onclick="Button1_Click" Text="Change password" />
                    &nbsp;&nbsp;&nbsp;
                </td>
                <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="reset" runat="server" Text="Reset" BorderStyle="None" 
                        onclick="reset_Click" />
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
