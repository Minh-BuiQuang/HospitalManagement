﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_LoaiPhauThuat.aspx.cs" Inherits="QLBV.DanhMuc_Loaiphauthuat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="font-weight:bold;padding-left:170px">DANH MỤC LOẠI PHẪU THUẬT</h1>
<asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>
                Mã loại phẫu thuật: 
            </td>
            <td>
                <asp:TextBox ID="tb_MaLoaiPhauThuat" runat="server" Enabled="false" Width="50px"></asp:TextBox>
            </td>
            <td>
                Tên loại phẫu thuật:
            </td>
            <td>
                <asp:TextBox ID="tb_TenLoaiPhauThuat" runat="server" Enabled="false" Width="250px"></asp:TextBox>
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
                    <asp:TemplateField HeaderText="Mã Loại Phẫu Thuật">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaLoaiPhauThuat") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Loại Phẫu Thuật" DataField="TenLoaiPhauThuat"
                        SortExpression="TenLoaiPhauThuat"/>
                </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
</asp:Content>