<%@ Page Title="Danh Mục Siêu Âm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_CanLamSan_SieuAm_ChiTieu.aspx.cs" Inherits="QLBV.DanhMuc_CanLamSan_LoaiSieuAm_SieuAm_DanhMuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="font-weight:bold;padding-left:170px">DANH MỤC SIÊU ÂM</h1>
    <asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>
                Mã siêu âm : 
            </td>
            <td>
                <asp:TextBox ID="tb_MaSieuAm" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td>
                Tên siêu âm :
            </td>
            <td>
                <asp:TextBox ID="tb_TenSieuAm" runat="server" Width="250px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Loại siêu âm :         
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddl_LoaiSieuAm" runat="server" Enabled="False" 
                    DataSourceID="SqlDataSource1" DataTextField="TenLoaiSieuAm" 
                    DataValueField="MaLoaiSieuAm">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_LoaiSieuAm]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>

    <asp:Button ID="btn_add" runat="server" Text="Thêm" onclick="btn_add_Click" />
    <asp:Button ID="btn_del" runat="server" Text="Xóa" onclick="btn_del_Click" 
        OnClientClick="return confirm('Bạn có chắc không?')" Visible="false"/> 
    <asp:Button ID="btn_edit" runat="server" Text="Sửa" onclick="btn_edit_Click"
        OnClientClick="return confirm('Bạn có chắc không?')" Visible="false" />  
    <asp:Button ID="btn_save" runat="server" Text="Lưu" onclick="btn_save_Click" Visible="false" />
    <asp:Button ID="btn_Cancel" runat="server" Text="Hủy" Visible="false" 
                    onclick="btn_Cancel_Click" />

    <asp:Panel ID="pn_pan" runat="server" Width="500px" BorderStyle="Double">
        <asp:GridView ID="gv_PatientList" runat="server" Width="100%"
            EmptyDataText="List empty" AutoGenerateColumns="False" 
            style="margin-top: 0px">
                <Columns>
                    <asp:TemplateField HeaderText="Mã Siêu Âm">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaSieuAm") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Siêu Âm" DataField="TenSieuAm"
                        SortExpression="TenSieuAm"/>
                    <asp:BoundField HeaderText="Mã Loại Siêu Âm" DataField="MaLoaiSieuAm" 
                        SortExpression="MaLoaiSieuAm" />
                </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    
</asp:Content>
