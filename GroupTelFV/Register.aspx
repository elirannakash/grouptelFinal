<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GroupTelFV.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>הרשמה</title>
    <link href="CSS/login2.css" rel="stylesheet" />
    <link href="CSS/Query-size.css" rel="stylesheet" />
    <link href="CSS/navbar.css" rel="stylesheet" />
   <meta name="viewport" content="width=device-width",initail-scale="1.0" />

</head>
<body class="body-reg" >
    
        <div class="top-row" dir="rtl"    >
		<button type="button" class="nav-btn">
			<span class="material-icons" style="font-size:2.4rem; padding-right:2rem; position: center;">
				תפריט
			</span>
		</button>
		
	</div>
         <header class="nav-overlay" >
       
        <nav class="nav" style="display:flex; flex-direction:column;" dir="rtl"> 
            
            
                <a class="nav-link" href="Default.aspx" >בית</a>
                <a class="nav-link" href="Login.aspx" >הרשמה/התחברות</a>
                <%--<li><a class="main-nav-link" href="index.aspx" >קטגוריות מוצרים</a></li>--%>
               <a class="nav-link" href="contact.aspx" >צרו קשר</a>
                <a class="nav-link1" href="profile.aspx" >איזור אישי</a>

           
          
    
     </nav>
       
       </header>
       
            <div>
                <p class="logo">GroupTel</p> 
            </div>
        
          <form id="form1" runat="server" dir="rtl">  

              

        
 

<div class="grid-log-reg" >
    <div class="grid-1">

    
                <!--- For Name---->
                  
                            <label class="identity" style="color:white;"  ></label>
                       
                            <asp:TextBox ID="UserName" placeholder=" הזן שם " runat="server" CssClass="form-control-reg" />
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" ErrorMessage="*הזן שם משתמש" ForeColor="red" />
                 




    <%-- FOR EMAIL --%>
               
                            <label class="identity" style="color:white; "> </label>
                      
                            <asp:TextBox ID="identity" placeholder=" הזן אימייל" runat="server" CssClass="form-control-reg" />
                      
                        <asp:RequiredFieldValidator ID="identityVal" runat="server" ControlToValidate="identity" ErrorMessage="*הזן אימייל" ForeColor="red" />
                   

    <%-- FOR PHONE --%>
     
                            <label class="mail"  style="color:white;"></label>
                        
                            <asp:TextBox ID="Phone" placeholder=" הזן מספר טלפון" runat="server" CssClass="form-control-reg" />
                      
                        <asp:RegularExpressionValidator ID="PhoneVal" runat="server" ErrorMessage="*נא להזין מספר תקין כולל איזור חיוג" ValidationExpression="^([0-9]{10})$" ControlToValidate="Phone" ForeColor="Red" />
                   
    <div class="grid-layout1">


                <!-----For Password----->
               
                            <label class="pass" style="color:white;"></label>
                       
                            <asp:TextBox ID="UserPass" placeholder=" (לפחות 5 תווים)הזן סיסמה" runat="server" TextMode="Password" CssClass="form-control-reg" />
                       
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*נא להזין סיסמה עם לפחות 5 תווים" ValidationExpression="^([\w]{5,})$" ControlToValidate="UserPass" ForeColor="Red" />

                 


            <%-- PASSWORD CONFIRMATION --%>
      
                            <label class="pass" style="color:white;"></label>
                       
                            <asp:TextBox ID="UserPass2" placeholder="אימות סיסמה" runat="server" TextMode="Password" CssClass="form-control-reg" />
                        
                        <asp:CompareValidator ID="CmpPass" runat="server" ControlToCompare="UserPass" ControlToValidate="UserPass2"  ErrorMessage="*סיסמא ואימות סיסמא אינם תואמים" ForeColor="Red" />
                 



              
                        <asp:Literal ID="userInfo" runat="server"></asp:Literal>
                        <asp:Literal ID="LtlLogin" runat="server"></asp:Literal>
             
    </div>
    
       

                
                    <asp:Button ID="RegButton" runat="server"  OnClick="RegButton_Click" CssClass="btn-log" type="button" Text="הרשמה"  /><br /><br />

               
        
        <div class="grid-layout3">
                  <p  style="margin-right:1rem; font-size:1.4rem;">כבר רשומים?      <a href="Login.aspx" style="" class="home-button1" ">     התחברות</a>   </p>           
                     <br /> <a href="Default.aspx" class="btn-log1" style= "margin-right:.9rem; "><ion-icon name="home-outline"></ion-icon>  לדף בית</a>
        </div>

                 
            </div>
    <div class="grid-2">
        <img src="img/login.jpg" class="img-log"/>
    </div>



    </div>
            
    </form>
        <script src="https://apis.google.com/js/platform.js" async="async" defer="defer"></script>
    <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script nomodule="nomodule" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
    <script src="JS/navbar.js"></script>
    <script>
        const btn = document.getElementById("RegButton");
        btn.addEventListener("click", function () {
            window.location.reload();
        });
    </script>
</body>
</html>