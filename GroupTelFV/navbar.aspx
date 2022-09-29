<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="navbar.aspx.cs" Inherits="GroupTelFV.navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/navbar.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="top-row">
		<button type="button" class="nav-btn">
			<span class="material-icons">
				menu
			</span>
		</button>
		<img class="logo" src="images/dcode-logo.png" alt="dcode">
	</div>
	<div class="nav-overlay"></div>
	<nav class="nav">
		<a href="#" class="nav-link">Nav Item #1</a>
		<a href="#" class="nav-link">Nav Item #2</a>
		<a href="#" class="nav-link">Nav Item #3</a>
		<a href="#" class="nav-link">Nav Item #4</a>
		<a href="#" class="nav-link">Nav Item #5</a>
	</nav>
    </form>
    <script src="JS/navbar.js"></script>
</body>
</html>
