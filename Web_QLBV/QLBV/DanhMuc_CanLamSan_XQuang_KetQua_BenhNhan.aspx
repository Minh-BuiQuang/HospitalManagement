<%@ Page Title="Bệnh nhân chụp X-Quang" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_CanLamSan_XQuang_KetQua_BenhNhan.aspx.cs" Inherits="QLBV.DanhMuc_CanLamSan_XQuang_KetQua_BenhNhan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="DanhMuc_CanLamSan_XQuang_KetQua_BenhNhan.aspx">Bệnh nhân</a></li>
        <li><a href="DanhMuc_CanLamSan_XQuang_KetQua_DSPhieu.aspx">Danh sách phiếu chụp X-Quang</a></li>
        <li><a href="DanhMuc_CanLamSan_XQuang_KetQua_Phieu.aspx">Phiếu X-Quang</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <br />
        Mã bệnh nhân:
        <asp:TextBox ID="txt_MaBN" runat="server"></asp:TextBox>&nbsp;
        Họ tên:
        <asp:TextBox ID="txt_HoTen" runat="server"></asp:TextBox>&nbsp;
        <asp:Button ID="btn_Search" runat="server" Text="Tìm kiếm" />&nbsp;
        <asp:Button ID="btn_Refresh" runat="server" Text="Xem tất cả" />
        
        <asp:Panel ID="pn_pan" runat="server" ScrollBars="Both" Width="1100px" BorderStyle="Double">
            <asp:GridView ID="gv_DanhSach" runat="server" 
                onrowdatabound="gv_DanhSach_RowDataBound" BackColor="#DEBA84" 
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
