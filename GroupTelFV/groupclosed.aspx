<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="groupclosed.aspx.cs" Inherits="GroupTelFV.groupclosed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>קבוצת רכישה סגורה</title>
     <link href="CSS/JoinGroup.css" rel="stylesheet" />
    <link href="CSS/Query-size.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width",initail-scale="1.0" />
</head>
<body dir="rtl">
    <div class="top-row" dir="rtl">
		<button type="button" class="nav-btn">
			<span class="material-icons" style="font-size:4.4rem; padding-right:2rem;">
				תפריט
			</span>
		</button>
		
	</div> 
    
<header class="nav-overlay ">
       
        <nav class="nav"> 
            
            
                <a class="nav-link" href="Default.aspx" >בית</a>
                <a class="nav-link" href="Login.aspx" >הרשמה/התחברות</a>
                <%--<li><a class="main-nav-link" href="index.aspx" >קטגוריות מוצרים</a></li>--%>
               <a class="nav-link" href="contact.aspx" >צרו קשר</a>
                <a class="nav-link1" href="profile.aspx" >איזור אישי</a>

           
          
    
     </nav>
       
       </header>
          
         <form id="form2" runat="server" dir="rtl">  

                 <a class="search" dir="rtl">
                    <asp:TextBox runat="server" id="searchBox" placeholder="מה ברצונכם למצוא?" CssClass="search1"   />
                    <asp:Button runat="server" ID="searchBtn" Text="מצא" OnClick="searchBtn_Click" CssClass="btn-search" />
                 </a>
             

         </form>
          
      
        <div dir="rtl">
  <center>
            <div class="literal-join">
                <asp:Literal runat="server" ID="LtlMsg"></asp:Literal>
            </div>
        </center>       
        <asp:Repeater ID="RptProd" runat="server">
        <ItemTemplate>
          
 <div class="wrapper">
<br /><br /><br />
  <div class="cols">
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" >
                        	<div class="headline">
							 <p ><%#Eval("Pname") %></p>
              
						</div>
                 
                </center>
                        <img src="<%#Eval("Ppic") %>"; class="img-join" />
					         <center>
            <div class="pic" style="margin-right:25rem;">
            <p>עמדו על התמונה לעוד פרטים</p>
            </div>
					</div>
					<div class="back">
						<div class="inner">
						  <p><%#Eval("Pdisc") %></p>
                          
                    </div>
                   
						</div>
					</div>
				</div>
			</div>
			<div class="col" ontouchstart="this.classList.toggle('hover');">
                </div></div></div>
              
        </ItemTemplate>
    </asp:Repeater>

        </div>
</body>
      <script src="JS/navbar.js"></script>
    <script src="https://apis.google.com/js/platform.js?onload=renderButton" async="async" defer="defer"></script>
        <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
</html>
