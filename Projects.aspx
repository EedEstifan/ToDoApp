<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="ToDoApp.Projects" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Projects</title>
    <link rel="stylesheet" href="CSS/ProjectsStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="projectsControl">
            <asp:Button ID="btnNewProject" CssClass="btn" Text="Create New Project" runat="server" OnClick="btnNewProject_Click" />
            <asp:TextBox ID="txtNewProjectName" runat="server"></asp:TextBox>
            <asp:Button ID="btnProfile" CssClass="btn" Text="Go To Profile" runat="server" OnClick="btnProfile_Click" />

        </div>

        <div class="projectsExplorer">
            
            <div id="projectsContainer">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <div class="project-grid">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="project-item">
                            <asp:LinkButton ID="linkButtonFolder" runat="server" CssClass="project-item" CommandName="Click" CommandArgument='<%# Eval("id") %>'>
                                <asp:Image ID="imgFolder" runat="server" CssClass="project-icon" ImageUrl="Pics/projectPic.png" />
                                <asp:Label ID="lblFolderName" runat="server" CssClass="project-label" Text='<%# Eval("name") %>'></asp:Label>
                            </asp:LinkButton>                           
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div id="projectDetails" runat="server">
                <h2 id="projectHeader" runat="server" >No Project Selected</h2>

                <div class="detail-group">
                    <label for="txtProjectName">Project Name</label>
                    <asp:TextBox ID="txtProjectName" runat="server" CssClass="detail-box" placeholder="Name"></asp:TextBox>
                </div>

                <div class="detail-group">
                    <label for="txtProjectDisc">Description</label>
                    <asp:TextBox ID="txtProjectDisc" runat="server" CssClass="detail-box" TextMode="MultiLine" Rows="3" placeholder="Description"></asp:TextBox>
                </div>

                <div class="detail-group">
                    <label for="txtProjectProgress">Progress</label>
                    <asp:TextBox ID="txtProjectProgress" ReadOnly="true" runat="server" CssClass="detail-box" placeholder="Progress"></asp:TextBox>
                </div>

                <div class="detail-group">
                    <label for="txtProjectDeadline">Deadline</label>
                    <asp:TextBox ID="txtProjectDeadline" runat="server" CssClass="detail-box" TextMode="Date"></asp:TextBox>
                </div>

                <div class="detail-group">
                    <label for="txtProjectStatus">Status</label>
                    <asp:DropDownList ID="ddlProjectStatus" runat="server" CssClass="detail-box">
                        <asp:ListItem Text="To DO" Value="ToDo" />
                        <asp:ListItem Text="In Progress" Value="InProgress" />
                        <asp:ListItem Text="Done" Value="Done" />
                        <asp:ListItem Text="Backlog" Value="Backlog" />
                    </asp:DropDownList>
                </div>

                <div class="detail-group">
                    <label for="txtProjectPriority">Priority</label>
                    <asp:DropDownList ID="ddlProjectPriority" runat="server" CssClass="detail-box">
                        <asp:ListItem Text="Low" Value="Low" />
                        <asp:ListItem Text="None" Value="None" />
                        <asp:ListItem Text="Medium" Value="Medium" />
                        <asp:ListItem Text="High" Value="High" />
                    </asp:DropDownList>
                </div>

                <div class="detail-buttons">
                    <asp:Button ID="btnOpenProject" CssClass="btnDetails" Text="Open Project" runat="server" OnClick="btnOpenProject_Click" />
                    <asp:Button ID="btnDeleteProject" CssClass="btnDetails" Text="Delete Project" runat="server" OnClick="btnDeleteProject_Click" />
                    <asp:Button ID="btnEditProject" CssClass="btnDetails" Text="Edit Project" runat="server" OnClick="btnEditProject_Click" />
                </div>
            </div>

            
        </div>
    </form>
</body>
</html>
