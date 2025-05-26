<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectManager.aspx.cs" Inherits="ToDoApp.ProjectManager" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Project Manager</title>
        <link href="CSS/ProjectManagerStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div id="ProjectControls">
        <asp:Button ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" />
        <asp:Button ID="btnNewTask" Text="Add New Task" runat="server" OnClick="btnNewTask_Click" /><link href="CSS/CalendarViewStyle.css" rel="stylesheet" />
        <asp:TextBox ID="txtNewTaskName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSort" Text="Sort" runat="server" OnClick="btnSort_Click" />
        <asp:Button ID="btnTaskMode" Text="Due Today" runat="server" OnClick="btnTaskMode_Click" />
    </div>

        <div class="projectExplorer">
            
                <div id="TasksContainer">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                            <div class="Task-grid">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="task-item">
                                <asp:Button ID="btnDoneTask" CssClass="done-button" runat="server" Text="✔ " CommandName="Click" CommandArgument='<%# Eval("id") %>'/>         
                                <asp:Label ID="lblTaskName" runat="server" CssClass="task-label" Text='<%# Eval("name") %>'></asp:Label>
                            </div>
                           
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
            </div>

            <div id="taskDetails" runat="server">
                <div class="detail-group">
                    <label for="txtTasktName">Task Name</label>
                    <asp:TextBox ID="txtTaskName" runat="server" CssClass="detail-box" placeholder="Name"></asp:TextBox>
                </div>

                <div class="detail-group">
                    <label for="txtTasktDisc">Description</label>
                    <asp:TextBox ID="txtTaskDisc" runat="server" CssClass="detail-box" TextMode="MultiLine" Rows="3" placeholder="Description"></asp:TextBox>
                </div>

                <div class="detail-group">
                    <label for="txtTaskDeadline">Deadline</label>
                    <asp:TextBox ID="txtTaskDeadline" runat="server" CssClass="detail-box" TextMode="Date"></asp:TextBox>
                </div>

                <div class="detail-group">
                    <label for="txtTaskDuedate">DueDate</label>
                    <asp:TextBox ID="txtTaskDuedate" runat="server" CssClass="detail-box" TextMode="Date"></asp:TextBox>
                </div>

                <div class="detail-group">
                    <label for="txtTaskStatus">Status</label>
                    <asp:DropDownList ID="ddlTaskStatus" runat="server" CssClass="detail-box">
                        <asp:ListItem Text="To DO" Value="ToDo" />
                        <asp:ListItem Text="In Progress" Value="InProgress" />
                        <asp:ListItem Text="Done" Value="Done" />
                        <asp:ListItem Text="Backlog" Value="Backlog" />
                    </asp:DropDownList>
                </div>

                <div class="detail-group">
                    <label for="txtTaskPriority">Priority</label>
                    <asp:DropDownList ID="ddlTaskPriority" runat="server" CssClass="detail-box">
                        <asp:ListItem Text="Low" Value="Low" />
                        <asp:ListItem Text="None" Value="None" />
                        <asp:ListItem Text="Medium" Value="Medium" />
                        <asp:ListItem Text="High" Value="High" />
                    </asp:DropDownList>
                </div>

                <div class="detail-buttons">
                    <asp:Button ID="btnDeleteTask" CssClass="btnDetails" Text="Delete Task" runat="server" OnClick="btnDeleteTask_Click" />
                    <asp:Button ID="btnEditTask" CssClass="btnDetails" Text="Edit Task" runat="server" OnClick="btnEditTask_Click" />
                </div>
            </div>

            
        </div>
    </form>
</body>
</html>

