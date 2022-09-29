<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change.aspx.cs" Inherits="GroupTelFV.change" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>עדכון פרטים</title>
<link href="CSS/change.css" rel="stylesheet" />
    <link href="CSS/Query-size.css?v1" rel="stylesheet" />
    <meta name="viewport" content="width=device-width",initail-scale="1.0" />
</head>
<body>
    <form id="form1" class="form-change" runat="server" dir="rtl">

            <nav class="nav">
                <ul class="main-nav-change">
                    <li><a class="main-nav-change" href="Default.aspx">בית</a></li>
                    <li><a><asp:Button ID="logout" CssClass="logout" runat="server" OnClick="logout_Click" Text="התנתקות" /></a></li>
                    <li> <asp:TextBox runat="server" ID="searchBox" placeholder="מה ברצונכם למצוא?" CssClass="search1-change" /></li>
                    <li><asp:Button runat="server" ID="searchBtn" Text="מצא" OnClick="searchBtn_Click" CssClass="btn-search-change" /></li>
                </ul>   
            </nav>
        

         <div class="container">
             <div class="header">
              <h2>מידע אישי</h2>
             </div>

            <div class="info">
            <div class="info-header">
                <p>שם</p>
                <p>סיסמה</p>
                <p>אימייל</p>
                <p>טלפון</p>
            </div>
        </div>
             
        <div class="info-value">
            <asp:TextBox ID="UserName" runat="server" ReadOnly="true" CssClass="profile-info" />
            <asp:TextBox ID="UserPass" runat="server" ReadOnly="true" CssClass="profile-info" />
            <asp:TextBox ID="UserEmail" runat="server" ReadOnly="true" CssClass="profile-info" />
            <asp:TextBox ID="UserPhone" runat="server" ReadOnly="true" CssClass="profile-info" />
        </div>

             <div>
                  <span class="literal-change-phone">
             <asp:Literal ID="LtlPass" runat="server"/>
             </span>
                    <div class="info-grid-change2"><br />
                    <asp:TextBox ID="NewPhone" runat="server" placeholder="שינוי טלפון" CssClass="change-info " />
                        <asp:RegularExpressionValidator ID="PhoneVal" runat="server" ErrorMessage="*נא להזין מספר תקין כולל איזור חיוג" ValidationExpression="^([0-9]{10})*$" ControlToValidate="NewPhone" ForeColor="Red" /><br />
                   <asp:Button runat="server" CssClass="logout" ID="changeInfo" Text="עדכון פרטים" OnClick="changeInfo_Click" />
                  <asp:TextBox ID="NewPass" runat="server" placeholder="שינוי סיסמה" CssClass="change-info "/>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*נא להזין סיסמה עם לפחות 5 תווים" ValidationExpression="^([a-zA-Z0-9_.-]{5,})*$" ControlToValidate="NewPass" ForeColor="Red" /><br />
                        <asp:Button ID="changePass" runat="server" Text="עדכון פרטים" OnClick="changePass_Click" CssClass="logout" />
             </div>
            </div>
</div>
          
        
    </form>
    <script src="JS/nav.js"></script>

</body>
</html>
