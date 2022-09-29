<%@ Page Title="" Language="C#" MasterPageFile="~/general.Master" AutoEventWireup="true" CodeBehind="categories.aspx.cs" Inherits="GroupTelFV.categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="prod-section">
        <div class="prod-item-all-prods">
            <asp:Repeater ID="RptAllProds" runat="server">
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
  
        <script src="//code.tidio.co/41ys4q70e9ys6wkagae894wz3fqv4viu.js" async></script>
</asp:Content>
