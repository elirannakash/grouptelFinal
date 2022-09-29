<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="GroupTelFV.contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>צור קשר</title>
    <link href="CSS/navbar.css" rel="stylesheet" />
    <link href="CSS/contact.css" rel="stylesheet" />
</head>
<body dir="rtl">
      <div class="top-row-contact" >
		<button type="button" class="nav-btn-contact">
			<span class="material-icons" style="font-size:4.4rem; padding-right:2rem; position: center;">
				תפריט
			</span>
		</button>
		
	</div>
      <header class="nav-overlay-contact ">
       
        <nav class="nav-contact"  > 
            
            
                <a class="nav-link"  href="Default.aspx" >בית</a>
                <a class="nav-link" href="Login.aspx" >הרשמה/התחברות</a>
                <%--<li><a class="main-nav-link" href="index.aspx" >קטגוריות מוצרים</a></li>--%>
               <a class="nav-link" href="contact.aspx" >צרו קשר</a>
                <a class="nav-link1" href="profile.aspx" >איזור אישי</a>

           
          
    
     </nav>
       
       </header>
    <form id="form1" runat="server">
        <center>
        <section class="contact-main">
            <center>
            <a href="mailto:grouptelgroup@gmail.com" class="a">ניתן לשלוח מייל כאן</a>
                </center>
            <center>
            <div class="phone">
            <p> כמו כן ניתן ליצור קשר במספרי הטלפון: <br />08-8555208<br />052-2255447</p>      
            </div>
                </center>
        </section>
            </center>
    </form>
</body>
<script src="JS/nav.js"></script>
<script src="JS/navbar.js"></script>
</html>
