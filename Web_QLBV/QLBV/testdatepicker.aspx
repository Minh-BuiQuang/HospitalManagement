<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testdatepicker.aspx.cs" Inherits="QLBV.testdatepicker" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="Styles/jquery.datepick.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="Scripts/jquery.datepick.js"></script>
<script type="text/javascript">
    $(function () {
        $('#dob').datepick();
        $('#dob1').datepick();
    });

    function showDate(date) {
        alert('The date chosen is ' + date);
    }

    $(function () {
        $('#Text1').hide();
        $('#MainContent_Button1').click(function () {
            $('#Text1').show();
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>    
            <input id="dob" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="false">
        <ContentTemplate>    
            <input id="dob1" />
        </ContentTemplate>
    </asp:UpdatePanel>--%>

    <asp:Accordion
    ID="MyAccordion"
    runat="Server"
    SelectedIndex="0"
    HeaderCssClass="accordionHeader"
    HeaderSelectedCssClass="accordionHeaderSelected"
    ContentCssClass="accordionContent"
    AutoSize="None"
    FadeTransitions="true"
    TransitionDuration="250"
    FramesPerSecond="40"
    RequireOpenedPane="false"
    SuppressHeaderPostbacks="true">
    <Panes>
        <asp:AccordionPane
            HeaderCssClass="accordionHeader"
            HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContent">
            <Header>sdfsdfsdf</Header>
            <Content>sdfhdfhfghfghfghgfhbvjnujnfgjnf</Content>
        </asp:AccordionPane>
    </Panes>            
    <HeaderTemplate>...</HeaderTemplate>
    <ContentTemplate></ContentTemplate>
</asp:Accordion>



    <asp:Panel ID="Panel" runat="server">
        <input id="Text1" />    
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Button" />
</asp:Content>
