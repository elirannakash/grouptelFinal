<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cancel.aspx.cs" Inherits="GroupTelFV.cancel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ביטול הזמנה</title>
    <link href="CSS/navbar.css" rel="stylesheet" />
    <link href="CSS/searchbar.css" rel="stylesheet" />
    <link href="CSS/allorders.css" rel="stylesheet" />
</head>
<body>
        <div class="top-row" dir="rtl">
		<button type="button" class="nav-btn">
			<span class="material-icons" style="font-size:4.4rem; padding-right:2rem;">
				תפריט
			</span>
		</button>
		
	</div> 
   <div class="margin">
<header class="nav-overlay ">
       
        <nav class="nav"> 
            
            
                <a class="nav-link" href="Default.aspx" >בית</a>
                <a class="nav-link" href="Login.aspx" >הרשמה/התחברות</a>
               <a class="nav-link" href="contact.aspx" >צרו קשר</a>
                <a class="nav-link1" href="profile.aspx" >איזור אישי</a>

           
          
    
     </nav>
       
       </header>
       </div>
    <div class="margin" >
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
                               
                                </div>                          
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <form runat="server" id="form1">
                    
                    <div class="cancel-order">
                        <asp:Literal runat="server" ID="LtlErr" />
                        <asp:TextBox ID="cancel1" runat="server" CssClass="cancel-text" placeholder="כדי לבטל, יש להזין סיסמה" TextMode="Password" />
                    <asp:Button ID="BtnCancel" runat="server" Text="ביטול הזמנה" CssClass="cancel-btn" OnClick="BtnCancel_Click"   />
                    </div>
                </form>
        </div>
    <br /><br />
      <footer>
        <div class="footer-grid">
            
            <div class="about-us">
                <h3 class="heading-third">עלינו</h3>
                        <p>
                            זירת השופינג של גרופטל מרכזת חוויות ומוצרים בהנחות ממש משתלמות. מידי יום מתעדכנות באתר הצעות חדשות כך שלרגע לא משעמם פה.
בין היתר תוכלו למצוא כאן הנחות ל: ימי כיף בבתי מלון, ארוחות מפנקות במסעדות, הצגות והופעות, פעילויות לכל המשפחה, אטרקציות לילדים, סדנאות ועוד יםםםם אפשרויות שמכניסות עוד קצת צבע והרבה כיף לחיים.
בנוסף, תמצאו באתר באליגם מוצרים לבית, מוצרי חשמל ואלקטרוניקה, מחשוב, פריטי אופנה וספורט, מוצרי טיפוח ופארם, צעצועים ועוד מאות מוצרים שהופכים את היום יום לנוחים ומפנקים יותר בלי לקרוע את הכיס.
אנחנו חברת אולטימייט ווקיישן מתחייבים בזאת שהלקוח תמיד בראש סדר העדיפיות צברנו ותק בשוק של עשרות שנים ואנחנו כאן כדי להוכיח זאת </p>
            </div>
            <div class="footer-collabs">
                        <h3 class="heading-third">בשיתוף פעולה</h3>
                        <p>
                      <a href="https://www.fattal.co.il/" target="_blank">                    
                    <img src="img/logo/fattal.jpg" class="footer-img-collabs" alt="fatal logo" />
                      </a>

                      <a href="https://www.isrotel.co.il/" target="_blank">
                    <img src="img/logo/isrotel.jpg" class="footer-img-collabs" alt="isrotel logo" /> 
                      </a>

                     <a href="https://www.payngo.co.il/" target="_blank">
                    <img src="img/logo/hashmal.png" class="footer-img-collabs" alt="mahsanei hashmal logo" /> 
                     </a>

                     <a href="https://www.shw.co.il/" target="blank">
                    <img src="img/logo/shomrat.png" class="footer-img-collabs" alt="shomrat logo" /> 
                     </a>

                    <a href="https://ace.co.il" target="_blank">
                    <img src="img/logo/ace.jpg" class="footer-img-collabs" alt="ace logo" />
                    </a>

                    <a href="https://homecenter.co.il" target="_blank">
                    <img src="img/logo/home-center.jpg" class="footer-img-collabs"  alt="home center logo"/>
                    </a>
                
                        </p>

            </div>
            <div class="footer-contact">
                <h3 class="heading-third">צור קשר</h3>
                        <p>
                            <a href="mailto:UltimateVacation@gmail.com">
                                <ion-icon name="mail-open-outline" class="icon"></ion-icon> grouptelgroup@gmail.com 
                            </a>
                        </p>
                        <p>
                            <ion-icon name="phone-portrait-outline" class="icon"></ion-icon>052-2255447    
                        </p>
                        <p>
                            <ion-icon name="call-outline" class="icon"></ion-icon>  08-8555208    
                        </p>
            </div>
           
        </div>
         <div class="footer-rights" dir="ltr">
                 <p>
                     <a href="#" style="text-decoration: none;">
                            ©2021   <strong class="text-warning">UltimateVacation</strong> כל הזכויות שמורות ל 
                                
                                   
                                </a>
                        </p>
            </div>
    </footer>
          <script>
              const btn = document.getElementById("BtnCancel");
              sessionStorage.setItem('pquantity2', <%#Eval("pquantity2")%>) =
              btn.addEventListener("click", function () {
                  if (sessionStorage["pquantity2"] != 1) {
                      alert("הזמנה בוטלה בהצלחה");
                  }
                  else
                      alert("לא ניתן לבטל הזמנה, הקבוצה סגורה");
                  
              });

          </script>
    <script src="JS/navbar.js"></script>
</body>
</html>
