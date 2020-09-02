<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_PhauThuat.aspx.cs" Inherits="QLBV.DanhMuc_Phauthuat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="font-weight:bold;padding-left:170px">DANH MỤC PHẪU THUẬT</h1>
<asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>Mã phẫu thuật: </td>
            <td>
                <asp:TextBox ID="tb_MaPhauThuat" runat="server" Enabled="false" Width="50px"></asp:TextBox>
            </td>
            <td>Tên phẫu thuật:</td>
            <td>
                <asp:TextBox ID="tb_TenPhauThuat" runat="server" Enabled="false" Width="250px"></asp:TextBox>
            </td>
        </tr>     
        <tr>
            <td></td>
            <td></td>
            <td>Loại phẫu thuật</td>
            <td>
                <asp:DropDownList ID="ddl_loaiphauthuat" runat="server" Enabled="false"
                    DataSourceID="SqlDataSource1" DataTextField="TenLoaiPhauThuat" 
                    DataValueField="MaLoaiPhauThuat">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_LoaiPhauThuat]"></asp:SqlDataSource>
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
                    <asp:TemplateField HeaderText="Mã Phẫu Thuật">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaPhauThuat") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Phẫu Thuật" DataField="TenPhauThuat"
                        SortExpression="TenPhauThuat"/>
                    <asp:BoundField HeaderText="Mã Loại Phẫu Thuật"  DataField="MaLoaiPhauThuat"
                        SortExpression="MaLoaiPhauThuat" />
                </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
</asp:Content>
