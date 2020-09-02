<%@ Page Title="Tìm kiếm bệnh nhân" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_BenhNhan.aspx.cs" Inherits="QLBV.Search_BenhNhan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="Styles/jquery.datepick.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="Scripts/jquery.datepick.js"></script>
<script type="text/javascript">
    $(function () {
        $('#MainContent_tb_TuNgay').datepick();
        $('#MainContent_tb_DenNgay').datepick();
    });

    function showDate(date) {
        alert('The date chosen is ' + date);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
        <ul>
            <li><a href="Search_HoSoBenhAn.aspx">Tìm kiếm hồ sơ bệnh án</a></li>
            <li><a href="Search_BenhNhan.aspx">Tìm kiếm bệnh nhân</a></li>
            <li><a href="Search_CongNhanVien.aspx">Tìm kiếm công nhân viên</a></li>
        </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="font-weight:bold;">TÌM KIẾM BỆNH NHÂN</h1><br />
    <asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red" Visible="false" >Nhập đầy đủ Từ Ngày và Đến Ngày</asp:label>
        <table>
            <tr>
                <td>Mã số bệnh nhân :</td>
                <td>
                    <asp:TextBox ID="tb_MSBenhNhan" runat="server"></asp:TextBox>    
                </td>
                <td>Ngày vào viện</td>
            </tr>
            <tr>
                <td>Họ và tên :</td>
                <td>
                    <asp:TextBox ID="tb_HoTen" runat="server"></asp:TextBox><br />
                </td>
                
                <td rowspan="2">
                    <table style="border-style:groove">
                        <tr>
                            <td>Từ ngày :</td>
                            <td><asp:TextBox ID="tb_TuNgay" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Đến Ngày :</td>
                            <td><asp:TextBox ID="tb_DenNgay" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>Vào khoa :</td>
                <td>
                    <asp:DropDownList ID="ddl_Khoa" runat="server" Enabled="False"
                        DataSourceID="SqlDataSource1" DataTextField="TenKhoa" 
                        DataValueField="MaKhoa">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_Khoa]"></asp:SqlDataSource>
                    <asp:CheckBox ID="cb_enable" runat="server" Text="Tìm theo khoa" Checked="false"
                        oncheckedchanged="cb_enable_CheckedChanged" AutoPostBack="true" />
                </td>
            </tr>
            <tr>
                <td>Giới tính :</td>
                <td>
                    <asp:RadioButtonList ID="rdl_GioiTinh" runat="server" RepeatColumns="2">
                        <asp:ListItem Selected="True" Value="1">Nam</asp:ListItem>
                        <asp:ListItem Value="0">Nữ</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
           
        </table>
        <asp:Button ID="btn_TimKiem" runat="server" Text="Tìm kiếm" 
        onclick="btn_TimKiem_Click" />
        <asp:Panel ID="pn_GridView" Width="1160px" runat="server" BackColor="White" Height="500px"
        ScrollBars="Both">
            <asp:GridView ID="gv_DanhSach" runat="server" BackColor="#DEBA84" 
                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                CellSpacing="2" >
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
        </asp:Panel>
</asp:Content>
