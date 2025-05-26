<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ToDoApp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Register</title>
    <link rel="stylesheet" type="text/css" href="CSS/RegisterStyle.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Register</h2>

            <label for="txtFirstName">First Name:</label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>

            <label for="txtLastName">Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>

            <label>Gender:</label>
            <div class="gender-group">
                <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" Text="Male" Checked="true"  />
                <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" Text="Female" />
            </div>

            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:FileUpload ID="imgUpload" runat="server"/>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn"/>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            <p>Already have an account? <a href="SignIn.aspx">Sign In here</a></p>
        </div>
    </form>
    <script src="Scripts/RegisterScript.js"></script>
</body>
</html>
