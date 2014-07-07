<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Melodic_Analyzer_ASP.WebForm1" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Chart ID="MAView" runat="server" BackHatchStyle="NarrowVertical" BorderlineColor="Black" BorderlineDashStyle="Solid" Width="600px" Palette="SeaGreen">
            <series>
                <asp:Series ChartArea="Melody" ChartType="Spline" Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="Melody">
                    <AxisY Title="Pitch">
                    </AxisY>
                    <AxisX Title="Time">
                    </AxisX>
                </asp:ChartArea>
            </chartareas>
            <BorderSkin BorderDashStyle="Solid"/>
        </asp:Chart>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="example melody" />
    
    </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="193px" ReadOnly="True" TextMode="MultiLine" Width="752px"></asp:TextBox>
    </form>
</body>
</html>
