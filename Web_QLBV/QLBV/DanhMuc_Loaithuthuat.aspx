<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_LoaiThuThuat.aspx.cs" Inherits="QLBV.DanhMuc_Loaithuthuat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="font-weight:bold;padding-left:170px">DANH MỤC LOẠI THỦ THUẬT</h1>
<asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>
                Mã loại thủ thuật: 
            </td>
            <td>
                <asp:TextBox ID="tb_MaLoaiThuThuat" runat="server" Enabled="false" Width="50px"></asp:TextBox>
            </td>
            <td>
                Tên loại thủ thuật:
            </td>
            <td>
                <asp:TextBox ID="tb_TenLoaiThuThuat" runat="server" Enabled="false" Width="250px"></asp:TextBox>
            </td>
        </tr>     
    </table>
    
    <asp:Button ID="btn_add" runat="server" Text="Thêm" onclick="btn_add_Click" />
    <asp:Button ID="btn_del" runat="server" Text="Xóa" onclick="btn_del_Click" 
        OnClientClick="return confirm('Bạn có chắc không?')" Visible="false"/> 
    <asp:Button ID="btn_edit" runat="server" Text="Sửa" onclick="btn_edit_Click"
        OnClientClick="return confirm('Bạn có chắc không?')" Visible="false" />  
    <asp:Button ID="btn_save" runat="server" Text="Lưu" onclick="btn_save_Click" Visible="false" />
    <asp:Button ID="btn_cancel" runat="server" Text="Hủy" Visible="false" 
                    onclick="btn_Cancel_Click" />

    <asp:Panel ID="pn_pan" runat="server" ScrollBars="Vertical"  Width="500px" BorderStyle="Double">
        <asp:GridView ID="gv_PatientList" runat="server" Width="100%"
            EmptyDataText="List empty" AutoGenerateColumns="False" 
            style="margin-top: 0px">
                <Columns>
                    <asp:TemplateField HeaderText="Mã Loại Thủ Thuật">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaLoaiThuThuat") %>' 
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Loại Thủ Thuật" DataField="TenLoaiThuThuat"
                        SortExpression="TenLoaiThuThuat"/>
                </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    
</asp:Content>
