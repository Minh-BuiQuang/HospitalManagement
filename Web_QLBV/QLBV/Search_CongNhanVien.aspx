<%@ Page Title="Tìm kiếm công nhân viên" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_CongNhanVien.aspx.cs" Inherits="QLBV.Search_CongNhanhVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="Search_HoSoBenhAn.aspx">Tìm kiếm hồ sơ bệnh án</a></li>
        <li><a href="Search_BenhNhan.aspx">Tìm kiếm bệnh nhân</a></li>
        <li><a href="Search_CongNhanVien.aspx">Tìm kiếm công nhân viên</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h1 style="font-weight:bold;">TÌM KIẾM THÔNG NHÂN VIÊN</h1>
        <table>
            <tr>
                <td>Mã công nhân viên :</td>
                <td>
                    <asp:TextBox ID="tb_MaCongNhanVien" runat="server"></asp:TextBox>
                </td>
                <td>Khoa :</td>
                <td>
                    <asp:DropDownList ID="ddl_Khoa" runat="server" Width="200px" Enabled="false"
                        DataSourceID="SqlDataSource1" DataTextField="TenKhoa" DataValueField="MaKhoa"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_Khoa]"></asp:SqlDataSource>
                    <asp:CheckBox ID="cb_Khoa" runat="server" Text="Tìm theo khoa" Checked="false"
                        AutoPostBack="true" oncheckedchanged="cb_Khoa_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td>Họ và tên :</td>
                <td>
                    <asp:TextBox ID="tb_HoTen" runat="server"></asp:TextBox>
                </td>
                <td>Chức vụ :</td>
                <td>
                    <asp:DropDownList ID="ddl_ChucVu" runat="server" Width="200px" Enabled="false"
                        DataSourceID="SqlDataSource2" DataTextField="TenChucVu" 
                        DataValueField="MaChucVu"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_ChucVu]"></asp:SqlDataSource>
                    <asp:CheckBox ID="cb_ChucVu" runat="server" Text="Tìm theo chức vụ" Checked="false"
                        AutoPostBack="true" oncheckedchanged="cb_ChucVu_CheckedChanged" />
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
                <td>Chức danh :</td>
                <td>
                    <asp:DropDownList ID="ddl_ChucDanh" runat="server" Width="200px" Enabled="false"
                        DataSourceID="SqlDataSource3" DataTextField="ChucDanh" 
                        DataValueField="MaChucDanh"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_ChucDanh]"></asp:SqlDataSource>
                    <asp:CheckBox ID="cb_ChucDanh" runat="server" Text="Tìm theo chức danh" Checked="false"
                        AutoPostBack="true" oncheckedchanged="cb_ChucDanh_CheckedChanged" />
                </td>
            </tr>
        </table>
        <asp:Button ID="btn_TimKiem" runat="server" Text="Tìm kiếm" 
            onclick="btn_TimKiem_Click" />
        <asp:Panel ID="pn_GridView" Width="1160px" runat="server" BackColor="White" Height="500px"
        ScrollBars="Both">
            <asp:GridView ID="gv_DanhSach" runat="server" BackColor="#DEBA84" 
                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                CellSpacing="2">
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
