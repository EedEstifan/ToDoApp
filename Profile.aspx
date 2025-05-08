<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ToDoApp.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>User Profile</title>
    <link rel="stylesheet" type="text/css" href="CSS/ProfileStyle.css" />
    <link href="CSS/navbar.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
      <div class="top-navbar">
        <a href="Projects.aspx">Projects</a>
        <a href="Profile.aspx">Profile</a>
        <a href="MyDay.aspx">MyDay</a>
        <a href="Signin.aspx">Signin</a>
        <a href="Register.aspx">Register</a>
    </div>
    <div class="profile-container">
        <header>
            <h1 runat="server" id="lblWelcome">Welcome</h1>
        </header>

        <section class="profile-content">
            <div class="profile-picture">
                <asp:Image ID="profileImage" runat="server"  />
                <br />
                <asp:Label Text="Change Profile Picture" runat="server" />
                <asp:FileUpload ID="imgUpload" runat="server"/>
               
            </div>

            <div class="profile-info">
                <div class="info-item">
                    <label >First Name:</label>
                    <asp:Label ID="lblFirstName" runat="server" Text="John" />
                    <asp:Button ID="btnEditFirstName" runat="server" CssClass="edit-btn" Text="Edit" OnClick="EditFirstName" />
                </div>

                <div class="info-item">
                    <label >Last Name:</label>
                    <asp:Label ID="lblLastName" runat="server" Text="Doe" />
                    <asp:Button ID="btnEditLastName" runat="server" CssClass="edit-btn" Text="Edit" OnClick="EditLastName" />
                </div>

                <div class="info-item">
                    <label >Gender:</label>
                    <asp:Label ID="lblGender" runat="server" Text="Male" />
                    <asp:Button ID="btnEditGender" runat="server" CssClass="edit-btn" Text="Edit" OnClick="EditGender" />
                </div>

                <div class="info-item">
                    <label >Email:</label>
                    <asp:Label ID="lblEmail" runat="server" Text="@gmail.com" />
                    <asp:Button ID="btnEditEmail" runat="server" CssClass="edit-btn" Text="Edit" OnClick="EditEmail" />
                </div>

                <div class="info-item">
                    <label >Password:</label>
                    <asp:Label ID="lblPassword" runat="server" Text="********" />
                    <asp:Button ID="btnEditPassword" runat="server" CssClass="edit-btn" Text="Edit" OnClick="EditPassword" />
                </div>
            </div>
        </section>
    </div>
</form>
</body>
</html>
