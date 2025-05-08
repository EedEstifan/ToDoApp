<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="ToDoApp.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <title>Sign In</title>
    <link rel="stylesheet" type="text/css" href="CSS/SignInStyle.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Sign In</h2>

            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" CssClass="btn"/>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            <p>Don't have an account? <a href="Register.aspx">Register here</a></p>
        </div>

    </form>
</body>
</html>
