<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Load_Image.aspx.cs" Inherits="QLBV.Load_Image" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pn_image" runat="server" CssClass="modalPopup" Height="500px">
        <asp:FileUpload ID="fu_link" runat="server" EnableTheming="true" />
            <asp:Button ID="btn_submit" runat="server" Text="Hiện hình" 
                onclick="btn_submit_Click" /><br />
            <asp:Button ID="btn_add" runat="server" Text="Đính kèm" />
            <asp:Button ID="btn_delete" runat="server" Text="Hủy file" />
            <asp:Button ID="btn_save" runat="server" Text="In phiếu" />
            <asp:Button ID="btn_back" runat="server" Text="Quay về" 
            onclick="btn_back_Click" />
    <asp:ImageButton ID="img_upload" runat="server" Width="300px" Height="400px" />
    </asp:Panel>
</asp:Content>
