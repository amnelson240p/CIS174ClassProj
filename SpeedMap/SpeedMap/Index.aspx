<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SpeedMap.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="login">
            <asp:TextBox ID="txtBxEmail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
            <asp:TextBox ID="txtBxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" />
            <asp:CheckBox ID="chkBxRemember" runat="server" checked="true"/>Remember Me?
        </div>
    <section>
	<h1>Not Registered?</h1>
  <figure> <img src="images/speed-trap.jpg" width="525" height="200" alt="Speed Trap Pic"/> </figure>
  
  <a href="#Registration" id="registration">Register Here!</a>
</section>
</asp:Content>
