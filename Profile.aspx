<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ToDoApp.Profile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile Page</title>
    <link href="CSS/ProfileStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="profile-container">
            <h2 ID="lblWelcome" runat="server">Your Profile</h2>
            <div class="profile-picture">
                <asp:Image ID="ProfileImage" runat="server" CssClass="profile-img" />
            </div>
            <asp:FileUpload ID="fuProfilePicture" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="edit-btn" OnClick="btnUpload_Click" />

            <div class="profile-info">
                <!-- First Name -->
                <div class="info-item">
                    <label>First Name:</label>
                    <asp:Label ID="lblFirstName" runat="server" />
                    <asp:TextBox ID="txtFirstName" runat="server" Visible="false" />
                    <asp:Button ID="btnEditFirstName" runat="server" Text="Edit" OnClick="EditFirstName" CssClass="edit-btn" />
                    <asp:Button ID="btnSaveFirstName" runat="server" Text="Save" OnClick="SaveFirstName" CssClass="edit-btn" Visible="false" />
                </div>

                <!-- Last Name -->
                <div class="info-item">
                    <label>Last Name:</label>
                    <asp:Label ID="lblLastName" runat="server" />
                    <asp:TextBox ID="txtLastName" runat="server" Visible="false" />
                    <asp:Button ID="btnEditLastName" runat="server" Text="Edit" OnClick="EditLastName" CssClass="edit-btn" />
                    <asp:Button ID="btnSaveLastName" runat="server" Text="Save" OnClick="SaveLastName" CssClass="edit-btn" Visible="false" />
                </div>

                <!-- Gender -->
                <div class="info-item">
                    <label>Gender:</label>
                    <asp:Label ID="lblGender" runat="server" />
                    <asp:DropDownList ID="ddlGender" runat="server" Visible="false">
                        <asp:ListItem Text="Male" Value="Male" />
                        <asp:ListItem Text="Female" Value="Female" />
                    </asp:DropDownList>
                    <asp:Button ID="btnEditGender" runat="server" Text="Edit" OnClick="EditGender" CssClass="edit-btn" />
                    <asp:Button ID="btnSaveGender" runat="server" Text="Save" OnClick="SaveGender" CssClass="edit-btn" Visible="false" />
                </div>

                <!-- Email -->
                <div class="info-item">
                    <label>Email:</label>
                    <asp:Label ID="lblEmail" runat="server" />

                </div>

                <!-- Password -->
                <div class="info-item">
                    <label>Password:</label>
                    <asp:Label ID="lblPassword" runat="server" Text="********" />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Visible="false" />
                    <asp:Button ID="btnEditPassword" runat="server" Text="Edit" OnClick="EditPassword" CssClass="edit-btn" />
                    <asp:Button ID="btnSavePassword" runat="server" Text="Save" OnClick="SavePassword" CssClass="edit-btn" Visible="false" />
                </div>

                <!-- Projects Done -->
                <div class="info-item">
                    <label>Projects Done:</label>
                    <asp:Label ID="lblProjectsDone" runat="server" />
                </div>

                <!-- Is Admin -->
                <div class="info-item">
                    <label>Admin:</label>
                    <asp:Label ID="lblIsAdmin" runat="server" />
                </div>
            </div>

            <asp:Button ID="btnSignOut" runat="server" Text="Sign Out" CssClass="edit-btn" OnClick="SignOut_Click" />
        </div>
    </form>
</body>
</html>
