<%@ Page Title="Danh Mục Chụp X Quang" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_CanLamSan_XQuang_ChiTieu.aspx.cs" Inherits="QLBV.DanhMuc_CanLamSan_LoaiSieuAm_XQuang_DanhMuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="font-weight:bold;padding-left:170px">DANH MỤC X-QUANG</h1>
    <asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>
                Mã X-Quang : 
            </td>
            <td>
                <asp:TextBox ID="tb_MaXQuang" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td>
                Tên X-Quang :
            </td>
            <td>
                <asp:TextBox ID="tb_TenXQuang" runat="server" Width="250px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Loại X-Quang :         
            </td>
            <td>
                <asp:DropDownList ID="ddl_LoaiXQuang" runat="server" Width="100%" Enabled="false"
                    DataSourceID="SqlDataSource1" DataTextField="TenLoaiXQuang" 
                    DataValueField="MaLoaiXQuang">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_LoaiXQuang]"></asp:SqlDataSource>
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
                    <asp:TemplateField HeaderText="Mã X-Quang">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaXQuang") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên X-Quang" DataField="TenXQuang"
                        SortExpression="TenXQuang"/>
                    <asp:BoundField HeaderText="Mã Loại X-Quang" DataField="MaLoaiXQuang"
                        SortExpression="MaLoaiXQuang" />
                </Columns>
        </asp:GridView>
    </asp:Panel>
    <br /> 
    
</asp:Content>
