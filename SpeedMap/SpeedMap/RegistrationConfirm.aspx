<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrationConfirm.aspx.cs" Inherits="SpeedMap.RegistrationConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <section>
        <h1>Thank you for registering!</h1>
        <div class="form-group">
            <label>You may now login with, </label>
            <asp:Label ID="lblNewUser" runat="server"></asp:Label>
            </div>
    </section>
</asp:Content>
