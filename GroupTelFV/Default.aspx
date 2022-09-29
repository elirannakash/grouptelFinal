<%@ Page Title="" Language="C#" MasterPageFile="~/general.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupTelFV.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <section class="collabs">
            <div class="container-collabs">
                <div>
                 <h3 class="heading-third">בשיתוף עם</h3>
                <p>   
                    <a href="https://www.fattal.co.il/">
                    <img src="img/logo/fattal.jpg" class="img-collabs" alt="fatal logo" />  
                        </a>
                    <a href="https://www.isrotel.co.il/">
                    <img src="img/logo/isrotel.jpg" class="img-collabs" alt="isrotel logo" /> 
                        </a>
                    <a href="https://www.payngo.co.il/">
                    <img src="img/logo/hashmal.png" class="img-collabs" alt="mahsanei hashmal logo" /> 
                        </a>
                    <a href="https://www.shw.co.il/">
                    <img src="img/logo/shomrat.png" class="img-collabs" alt="shomrat logo" /> 
                        </a>
                    <a href="https://www.ace.co.il/">
                    <img src="img/logo/ace.jpg" class="img-collabs" alt="ace logo" />
                        </a>
                    <a href="https://www.homecenter.co.il/">
                    <img src="img/logo/home-center.jpg" class="img-collabs"  alt="home center logo"/>
                        </a>
                </p>
                </div>
            </div>
        </section>--%>
     <br /><br />
    <%-- HOTELS --%>
     <h5 class="heading-fifth">חופשות>> <a class="btn-nav" href="showallprods.aspx?Cid=1">צפייה בהכול</a></h5>

    <section class="prod-section">
        <div class="prod-item">
            <asp:Repeater ID="DataList1" runat="server">
                <ItemTemplate>
                   <div class="prod-box">
                   <img src="<%#Eval("Ppic") %>" class="prod-img" />
                    <div class="grid-quantity-name">
                   <div class="prod-name"><%#Eval("Pname") %></div>
                        <asp:Literal runat="server" ID="LtlMsg" ></asp:Literal>
                    </div>
                   <div class="grid-price-btn">
                   <a href="#" class="price">₪<%#Eval("Price") %></a>
                   <a href="JoinGroup1.aspx?Pid=<%#Eval("Pid") %>" class="prod-btn"> לרכישה</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           
        </div>
    </section>
   

    <%-- ELECTRONIC --%>
            <h5 class="heading-fifth">אלקטרוניקה>> <a class="btn-nav" href="showallprods.aspx?Cid=2">צפייה בהכול</a></h5>
    <section class="prod-section">
        <div class="prod-item">
            <asp:Repeater ID="DataList2" runat="server">
                <ItemTemplate>
                    <div class="prod-box">
                   <img src="<%#Eval("Ppic") %>" class="prod-img" />
                   <div class="prod-name"><%#Eval("Pname") %></div>
                   <a href="#" class="price">₪<%#Eval("Price") %></a>
                   <a href="JoinGroup1.aspx?Pid=<%#Eval("Pid") %>" class="prod-btn"> לרכישה</a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           
        </div>
    </section>
   

    <%-- FURNITURES --%>

    <h5 class="heading-fifth">ריהוט>> <a class="btn-nav" href="showallprods.aspx?Cid=3">צפייה בהכול</a></h5>
    <section class="prod-section">
        <div class="prod-item">
            <asp:Repeater ID="DataList3" runat="server">
                <ItemTemplate>
                    <div class="prod-box">
                   <img src="<%#Eval("Ppic") %>" class="prod-img" />
                   <div class="prod-name"><%#Eval("Pname") %></div>
                   <a href="#" class="price">₪<%#Eval("Price") %></a>
                   <a href="JoinGroup1.aspx?Pid=<%#Eval("Pid") %>" class="prod-btn"> לרכישה</a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           
        </div>
    </section>
        <script  src="//code.tidio.co/41ys4q70e9ys6wkagae894wz3fqv4viu.js" async></script>

</asp:Content>
