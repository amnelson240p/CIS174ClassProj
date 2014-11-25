<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SpeedMap.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">

    <section>
        <h1>Not Registered?</h1>
        <figure>
            <img src="images/TrapMonitorpbg.gif" alt="Trap Monitor Logo" style="height: 412px; width: 664px" />
        </figure>

        <asp:Button ID="btnRegistration" runat="server" Text="Register Here!" OnClick="btnRegistration_Click" CssClass="btnRegistration" />
        
    </section>
    <script>
       
    </script>
</asp:Content>
