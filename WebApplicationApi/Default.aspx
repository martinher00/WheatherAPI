<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationApi.Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="Select timespan: "></asp:Label>
            <asp:DropDownList ID="DropDownListTimeSpan" runat="server">
                <asp:ListItem Value="daily">Daily</asp:ListItem>
                <asp:ListItem Value="weekly">Weekly</asp:ListItem>
                <asp:ListItem Value="monthly">Monthly</asp:ListItem>
            </asp:DropDownList>

            <br />

            <asp:Label ID="Label2" runat="server" Text="Select year, month and day: "></asp:Label>

            <asp:DropDownList ID="DropDownListYear" runat="server" OnSelectedIndexChanged="DropDownListYear_SelectedIndexChanged">
                <asp:ListItem Value="2023">2023</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList ID="DropDownListMonth" runat="server" OnSelectedIndexChanged="DropDownListMonth_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="01">January</asp:ListItem>
                <asp:ListItem Value="02">February</asp:ListItem>
                <asp:ListItem Value="03">March</asp:ListItem>
                <asp:ListItem Value="04">April</asp:ListItem>
                <asp:ListItem Value="05">May</asp:ListItem>
                <asp:ListItem Value="06">Juni</asp:ListItem>
                <asp:ListItem Value="07">July</asp:ListItem>
                <asp:ListItem Value="08">August</asp:ListItem>
                <asp:ListItem Value="09">September</asp:ListItem>
                <asp:ListItem Value="10">October</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList ID="DropDownListDays" runat="server">
                
            </asp:DropDownList>

            <br />

            <asp:Button ID="ExecuteQuery" runat="server" Text="View" />

            <asp:Chart ID="WeatherChart" runat="server">
                <Series>
                    <asp:Series Name="Series1"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

        </div>
    </form>
</body>
</html>
