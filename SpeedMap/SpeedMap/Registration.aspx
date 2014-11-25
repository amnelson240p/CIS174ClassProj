<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SpeedMap.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formPlaceHolder" runat="server">
    <section>
        <div class="form-group">
            <div class="entry-group">
                <label for="txtUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" placeholder="new username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Username required" Display="Dynamic" ControlToValidate="txtUsername">*</asp:RequiredFieldValidator>
            </div>
            <div class="entry-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password required" ControlToValidate="txtPassword" Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
            <div class="entry-group">
                <label for="txtVerifyPassword">Re-type Password</label>
                <asp:TextBox ID="txtVerifyPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassRetry" runat="server" ErrorMessage="Required to verify password" ControlToValidate="txtVerifyPassword" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Passwords do not match" Display="Dynamic" ControlToValidate="txtVerifyPassword" ControlToCompare="txtPassword" Operator="Equal">*</asp:CompareValidator>
            </div>
            <div class="clear"></div>
        </div>
        <div style="visibility:hidden">
            <asp:Button ID="btnRegistration" CssClass="btnRegistration" runat="server" Text="Submit" OnClick="btnRegistration_Click" />
        </div>
        <button type="button" id="btnTest" class="btnRegistration" onclick="validate()">Register</button>
        <label id="lblError" class="error"></label>
        <asp:Label ID="lblDatabaseError" runat="server" Text="" CssClass="error"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" />
    </section>
    <script src="Scripts/reportcom.js"></script>
    <script>
        function validate() {
            console.log("validating");
            // stuff to validate username
            var name = document.getElementById("<%= txtUsername.ClientID %>").value;
            console.log("name: " + name);

            ValidateUsername(name);
            // finally redirect
            //document.getElementById("<%= btnRegistration.ClientID %>").click();
        }
    </script>
</asp:Content>
