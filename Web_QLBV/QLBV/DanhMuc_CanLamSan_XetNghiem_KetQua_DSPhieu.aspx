<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_CanLamSan_XetNghiem_KetQua_DSPhieu.aspx.cs" Inherits="QLBV.DanhMuc_CanLamSan_XetNghiem_KetQua_DSPhieu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="DanhMuc_CanLamSan_XetNghiem_KetQua_BenhNhan.aspx">Bệnh nhân</a></li>
        <li><a href="DanhMuc_CanLamSan_XetNghiem_KetQua_DSPhieu.aspx">Danh sách phiếu chụp X-Quang</a></li>
        <li><a href="DanhMuc_CanLamSan_XetNghiem_KetQua_Phieu.aspx">Phiếu X-Quang</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table border="1">
        <tr>
            <td>Họ tên</td>
            <td><asp:TextBox ID="txt_HoTen" runat="server" Enabled="false"></asp:TextBox></td>
            <td>Ngày sinh</td>
            <td><asp:TextBox ID="txt_NgaySinh" runat="server" Enabled="false" Width="55px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Ngày vào viện</td>
            <td><asp:TextBox ID="txt_NgayVaoVien" runat="server" Enabled="false"></asp:TextBox></td>
            
            <td>Phái</td>
            <td>
                <asp:RadioButtonList ID="rdl_GioiTinh" runat="server" RepeatColumns="2" Enabled="false">
                    <asp:ListItem Selected="True" Value="1">Nam</asp:ListItem>
                    <asp:ListItem Value="0">Nữ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>

    <asp:Button ID="btn_add" runat="server" Text="Thêm" onclick="btn_add_Click" />
    
    <asp:Panel ID="pn_pan" runat="server" ScrollBars="Vertical"  Width="900px" BorderStyle="Double">
        <asp:GridView ID="gv_PatientList" runat="server" Width="100%"
            EmptyDataText="List empty" onrowdatabound="gv_PatientList_RowDataBound" 
            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" CellSpacing="2">
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
