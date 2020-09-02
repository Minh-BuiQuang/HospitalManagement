<%@ Page Title="Danh Mục Chụp X Quang" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_CanLamSan_XQuang_DanhMuc.aspx.cs" Inherits="QLBV.DanhMuc_CanLamSan_LoaiSieuAm_XQuang_DanhMuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<form id="Form1" runat="server" style="background-color:#ffffff;width:90%;height:500px;padding-left:17px;">
    <h1 style="font-weight:bold"><center>DANH MỤC X-QUANG</center></h1>
    <table>
        <tr>
            <td>
                Mã X-Quang : 
            </td>
            <td>
                <asp:TextBox ID="tb_MaXQuang" runat="server"></asp:TextBox>
            </td>
            <td>
                Tên X-Quang :
            </td>
            <td>
                <asp:TextBox ID="tb_TenXQuang" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Loại X-Quang :         
            </td>
            <td>
                <asp:DropDownList ID="ddl_LoaiXQuang" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:GridView ID="gv_XQuang" runat="server">
    </asp:GridView>
    <asp:Button ID="btn_Them" runat="server" Text="Thêm" />
    <asp:Button ID="btn_Xoa" runat="server" Text="Xóa" /> 
    <asp:Button ID="btn_Sua" runat="server" Text="Sửa" />  
    <asp:Button ID="btn_Save" runat="server" Text="Lưu" /> 
    
</form>
</asp:Content>
