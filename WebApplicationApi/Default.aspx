<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationApi.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="¨Filter by"></asp:Label>

            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem selected="True" Value="1">Select</asp:ListItem>
                <asp:ListItem Value="1">H</asp:ListItem>
                <asp:ListItem Value="2">Pp</asp:ListItem>
            </asp:DropDownList>


        </div>
    </form>
</body>
</html>
