<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThongKeBenhNhan.aspx.cs" Inherits="QLBV.ThongKeBenhNhan" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/jquery.datepick.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery.datepick.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#MainContent_txt_DayIn').datepick();
            $('#MainContent_txt_DayOut').datepick();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Bệnh nhân nhập/xuất viện</h1>
    <table>
        <tr>
            <td>
                <b>Khoa</b>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Khoa" runat="server" DataSourceID="Khoa" 
                    DataTextField="TenKhoa" DataValueField="MaKhoa">
                </asp:DropDownList>
                <asp:SqlDataSource ID="Khoa" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_Khoa]"></asp:SqlDataSource>
            </td>
            <td>
                <b>Từ ngày</b>
            </td>
            <td>
                <asp:TextBox ID="txt_DayIn" runat="server" Width="80px" />
            </td>
            <td>
                <b>Đến ngày</b>
            </td>
            <td>
                <asp:TextBox ID="txt_DayOut" runat="server" Width="80px" />
            </td>
        </tr>
    </table>
    <div>
        <asp:Button ID="btn_Load" runat="server" Text="Xem" onclick="btn_Load_Click"/>
    </div>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" GroupTreeStyle-ShowLines="False" 
        HasToggleGroupTreeButton="False" Height="50px" ToolPanelView="None" 
        Width="350px" />
</asp:Content>
