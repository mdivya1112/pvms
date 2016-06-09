<%@ Page Title="PASSPORT VISA MANAGEMENT SYSTEM"Language="C#" AutoEventWireup="true" Inherits="Logout" Codebehind="Logout.aspx.cs" %>

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
            height: 24px;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function TextArea1_onclick() {

        }

// ]]>
    </script>
    <script type="text/javascript">
 window.history.forward(1);
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table class="style1">
        <tr>
            <td class="style2">
                You have been successfully logged out!!!<br />
                <br />
&nbsp;<asp:HyperLink ID="click_here" runat="server" NavigateUrl="~/Login.aspx">Click Here</asp:HyperLink>
&nbsp;to login again</td>
        </tr>
    </table>
    </form>
</body>
</html>
