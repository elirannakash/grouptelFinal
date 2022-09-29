<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allorders.aspx.cs" Inherits="GroupTelFV.allorders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>היסטוריית הזמנות</title>
    <link href="CSS/allorders.css" rel="stylesheet" />
    <link href="CSS/navbar.css" rel="stylesheet" />
    <link href="CSS/searchbar.css" rel="stylesheet" />
</head>
<body>
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
    <br /><br /><br /><br />
   
    <div>
    <asp:Literal ID="LtlOrd" runat="server" />
                <asp:Repeater ID="RptOrder" runat="server">
                    <ItemTemplate>
                        <div class="order-item">
                            <div class="grid-1">
                            <p class="order-id"> מספר הזמנה: <%#Eval("Oid") %></p>
                        <p class="order-name"><%#Eval("Pname") %></p>
                        
                        <p class="order-date"> תאריך הזמנה: <%#Eval("Odate", "{0: dd/MM/yyyy}")%>  </p>
                                </div>
                            <div class="grid-2">
                            <img src="<%#Eval("Ppic") %>" class="order-img"/>
                                <a href="cancel.aspx?Oid=<%#Eval("Oid") %>" class="cancel-btn"> לביטול הזמנה</a>
                                </div>
                          
                           
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
</body>
<script src="JS/navbar.js"></script>
</html>
