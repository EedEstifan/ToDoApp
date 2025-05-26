<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Journals.aspx.cs" Inherits="ToDoApp.Journals" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Journal</title>
    <link href="CSS/JournalStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="journal-container">
            <h1>My Journal</h1>
            <asp:Button ID="btnProfile" runat="server" Text="Go To Profile" CssClass="btn-primary" OnClick="btnProfile_Click" />
            <div class="field-group">
                <label for="txtDate">Select Date:</label>
                <asp:TextBox ID="txtDate" runat="server" CssClass="input" placeholder="yyyy-MM-dd"></asp:TextBox>
                <asp:Button ID="btnLoad" runat="server" Text="Load Journal" CssClass="btn-primary" OnClick="btnLoad_Click" />
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="message-label" EnableViewState="false" />

            <asp:Panel ID="pnlJournal" runat="server" CssClass="journal-panel" Visible="false">
                <div class="field-group">
                    <label for="txtMood">Mood:</label>
                     <asp:DropDownList ID="ddlMood" runat="server" CssClass="input">
                        <asp:ListItem Text="Happy" Value="Happy" />
                        <asp:ListItem Text="Sad" Value="Sad" />
                        <asp:ListItem Text="Excited" Value="Excited" />
                        <asp:ListItem Text="Anxious" Value="Anxious" />
                        <asp:ListItem Text="Neutral" Value="Neutral" />
                    </asp:DropDownList>
                </div>
                <div class="field-group">
                    <label for="txtContent">Content:</label>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="textarea" TextMode="MultiLine" />
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Save Journal" CssClass="btn-primary" OnClick="btnSave_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
