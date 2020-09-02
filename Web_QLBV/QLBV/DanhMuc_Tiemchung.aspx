<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_Tiemchung.aspx.cs" Inherits="QLBV.DanhMuc_Tiemchung1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="font-weight:bold;padding-left:170px">DANH MỤC TIÊM CHỦNG</h1>
    <asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>
                Mã tiêm chủng : 
            </td>
            <td>
                <asp:TextBox ID="tb_MaTiemChung" runat="server" Enabled="false" Width="50px"></asp:TextBox>
            </td>
            <td>
                Tên tiêm chủng :
            </td>
            <td>
                <asp:TextBox ID="tb_TenTiemChung" runat="server" Enabled="false" Width="250px"></asp:TextBox>
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
                    <asp:TemplateField HeaderText="Mã Dịch Truyền">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaTiemChung") %>' 
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Dịch Truyền" DataField="TenTiemChung"
                        SortExpression="TenTiemChung"/>
                </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    
</asp:Content>
