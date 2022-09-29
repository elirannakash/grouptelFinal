<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="joinGroup1.aspx.cs" Inherits="GroupTelFV.joinGroup1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>הצטרפות לקבוצת רכישה</title>
    <script src="https://www.paypal.com/sdk/js?client-id=AczxVS1kfPS9YfJzIqZXUgZesm-Mod2AcT_iWVRiGG6g41KssZUmv9vjCvk7qHlHUTHW7YN3rG4b7Yf8&enable-funding=venmo&currency=ILS" data-sdk-integration-source="button-factory"></script>
    <script src="JS/GooglePay.js"></script>
    <link href="CSS/JoinGroup.css" rel="stylesheet" />
    <link href="CSS/Query-size.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width",initail-scale="1.0" />
    <script> 

        //var mailG = sessionStorage.getItem('GoogleMail');
        //document.getElementById("mailG").innerHTML = mailG;

        var j = '<%=EndDateToDisplay%>';
        var myfunc = setInterval(function () {

            var now = new Date().getTime();
            var countDownDate = new Date(j).getTime();
            var timeleft = countDownDate - now;
            var days = Math.floor(timeleft / (1000 * 60 * 60 * 24));
            var hours = Math.floor((timeleft % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            var minutes = Math.floor((timeleft % (1000 * 60 * 60)) / (1000 * 60));
            var seconds = Math.floor((timeleft % (1000 * 60)) / 1000);

            let dateStr = `${days}: ${hours}: ${minutes}: ${seconds}`;
            document.getElementById("dateForDisplay").innerHTML = dateStr;


            if (timeleft < 0) {
                clearInterval(myfunc);
                document.getElementById("days").innerHTML = ""
                document.getElementById("hours").innerHTML = ""
                document.getElementById("mins").innerHTML = ""
                document.getElementById("secs").innerHTML = ""
                document.getElementById("end").innerHTML = "TIME UP!!";


            }

        }, 1000)

    </script>
</head>
<body dir="rtl" class="body-join">
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
                    <asp:Button runat="server" ID="searchBtn" Text="מצא" OnClick="searchBtn_Click1" CssClass="btn-search" />
                 </a>
             

         </form>
            <div class="literal-join">
                <asp:Literal runat="server" ID="LtlMsg"></asp:Literal>
            </div>
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
                            <h1></h1>
                            <p class="price"> מחיר: <%#Eval("Price") %> ש"ח</p>
                             <div class="prod-timer">
                         
                        
                            <p class="countDown-text"> זמן עד לסגירת הקבוצה </p>
                            <p id="dateForDisplay" class="countDown"></p>
                            
                    </div>
                             <div class="prod-btn-join">
                        <center>
                            <div id="smart-button-container">
                                <div style="text-align: center;">
                                    <div id="paypal-button-container"></div>
                                </div>
                            </div>
                        </center>
                    </div>
                   
						</div>
					</div>
				</div>
			</div>
      
			<div class="col" ontouchstart="this.classList.toggle('hover');">
                </div></div></div>
          <br /><br /><br />
            <h1></h1>
        </ItemTemplate>
    </asp:Repeater>  
    
    
            
           




       
        
        
        
        
      
       


  

        <script src="https://www.paypal.com/sdk/js?client-id=AczxVS1kfPS9YfJzIqZXUgZesm-Mod2AcT_iWVRiGG6g41KssZUmv9vjCvk7qHlHUTHW7YN3rG4b7Yf8&enable-funding=venmo&currency=ILS" data-sdk-integration-source="button-factory"></script>
    <script>
        var pids = '<%=pidToDisplay%>';
        var price = '<%=paypalPrice%>';
        function initPayPalButton() {
            paypal.Buttons({
                style: {
                    shape: 'pill',
                    color: 'gold',
                    layout: 'vertical',
                    label: 'buynow',

                },

                createOrder: function (data, actions) {
                    // This function sets up the details of the transaction, including the amount and line item details.
                    return actions.order.create({
                        purchase_units: [{
                            "description": "",
                            "amount": {
                                "currency_code": "ILS"
                                , "value": price
                            }
                        }]
                    });
                },
                onApprove: function (data, actions) {
                    // This function captures the funds from the transaction.
                    return actions.order.capture().then(function (details) {
                        var payers = details.payer.email_address;

                        var url = "/orderUpdate.ashx?Pid=" + pids + "&email=" + payers;

                        function wello() {

                            fetch(url, {
                                method: 'GET',
                                headers: {
                                    'Content-Type': 'application/json'
                                }
                            }).then((res) => { return res.text(); }).
                                then((data) => {
                                    if (data == "OK") {
                                        alert("הצטרפת לקבוצת הרכישה בהצלחה");
                                        window.location.reload();
                                        window.location.replace("http://localhost:64135/default.aspx");
                                        

                                    }
                                }).
                                catch(error => error);
                        };
                        wello();

                    });
                },
                onError: function (err) {
                    console.log(err);
                }
            }).render('#paypal-button-container');
        }
        initPayPalButton();
    </script>
    <script src="JS/navbar.js"></script>
    <script src="https://apis.google.com/js/platform.js?onload=renderButton" async="async" defer="defer"></script>
    <script src="JS/GooglePay.js"></script>
        <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>

</body>
</html>
