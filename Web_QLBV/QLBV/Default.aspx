<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="QLBV._Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		
		<title> Login </title>
		
		<!--                       CSS                       -->
	  
		<!-- Main Stylesheet -->
		<link rel="stylesheet" href="Styles/Site.css" type="text/css" media="screen" />

</head>
<body id="login">

    <div id="Div1" class="png_bg">
    <div class="clear"></div>
    <br /><br /><br />
        <div id="login-top">
            <center>
                <!-- Logo (221px width) -->
                <img src="Source/logo.jpg" alt="" width="221px" height="221px"/>
            </center>
        </div> <!-- End #logn-top -->
    <br /><br /><br />
    <div id="login-wrapper" class="png_bg">
        <div id="login-content">
            <form id="form1" runat="server">
                <div class="notification information png_bg">
	                <div>
		                <asp:Label ID="lbl_thongBao" runat="server" ForeColor="Red" Font-Size="12px"></asp:Label>
	                </div>
                </div>
    			<div class="clear"></div>
                <div class="clear"></div>		
                <p>
	                <label>Tài khoản</label>
                    <asp:TextBox ID="txt_username"  runat="server" MaxLength="32"></asp:TextBox>
                </p>

                <div class="clear"></div>
			    <p>
				    <label>Mật khẩu</label>
				    <asp:TextBox ID="txt_password"  runat="server" MaxLength="32" TextMode="Password"></asp:TextBox>
			    </p>
			    <div class="clear"></div>
                <p>
                    <asp:Button ID="btn_login" runat="server" Text="Đăng nhập" Width="100px" OnClick="btn_login_Click" />
                </p>
            </form>
            
        </div>
    </div>
    </div>
</body>
</html>
