<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_ThuThuat.aspx.cs" Inherits="QLBV.DanhMuc_Thuthuat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="font-weight:bold;padding-left:170px">DANH MỤC THỦ THUẬT</h1>
<asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>
                Mã thủ thuật: 
            </td>
            <td>
                <asp:TextBox ID="tb_MaThuThuat" runat="server" Enabled="false" Width="50px"></asp:TextBox>
            </td>
            <td>
                Tên thủ thuật:
            </td>
            <td>
                <asp:TextBox ID="tb_TenThuThuat" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>
                Loại thủ thuật:
            </td>
            <td>
                <asp:DropDownList ID="ddl_tenloaithuthuat" runat="server" Enabled="false"
                    DataSourceID="SqlDataSource1" DataTextField="TenLoaiThuThuat" 
                    DataValueField="MaLoaiThuThuat"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_LoaiThuThuat]"></asp:SqlDataSource>
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
                    <asp:TemplateField HeaderText="Mã Thủ Thuật">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaThuThuat") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Thủ Thuật" DataField="TenThuThuat"
                        SortExpression="TenThuThuat"/>
                    <asp:BoundField HeaderText="Mã Loại Thủ Thuật"  DataField="MaLoaiThuThuat"
                        SortExpression="MaLoaiThuThuat" />
                </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    
</asp:Content>
