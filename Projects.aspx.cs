using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ToDoApp.App_Code;
using ToDoApp.Models;

namespace ToDoApp
{
    public partial class Projects : System.Web.UI.Page
    {
        User user;

        private void RefreshDetails(int projectId)
        {
            Project selectedProject = user.getProject(projectId);
            txtProjectName.Text = selectedProject.name;
            txtProjectDisc.Text = selectedProject.description;
            txtProjectProgress.Text = $"{selectedProject.numOfDoneTasks()}/{selectedProject.numOfTasks}";
            txtProjectDeadline.Text = selectedProject.deadline.ToString("yyyy-MM-dd"); ;
            ddlProjectPriority.SelectedValue = selectedProject.priority.ToString();
            ddlProjectStatus.SelectedValue = selectedProject.status.ToString();
            projectHeader.InnerText = selectedProject.name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) Session["projectId"] = null;
            if (Session["userId"] == null)
            {
                Response.Redirect("NeedToSignin.aspx");
            }
            else
            {
                user = new User(Convert.ToInt32(Session["userId"]));
                Repeater1.DataSource = user.projects;
                Repeater1.DataBind();
            }

        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Click")
            {
                int projectId = int.Parse(e.CommandArgument.ToString());
                Session["projectId"] = projectId;
                RefreshDetails(projectId);
            }
        }

        protected void btnNewProject_Click(object sender, EventArgs e)
        {
            
            string name = txtNewProjectName.Text.Trim();
            if (name != "")
            {
                string qry = "INSERT INTO[ProjectTbl](name, status, description, deadline, priority, userId,numOfTasks) ";
                qry += "VALUES (@Name, @Status, @Description, @Deadline, @Priority, @UserId, @NumOfTasks )";
                string[] Parameters = { "@Name", "@Status", "@Description", "@Deadline", "@Priority", "@UserId", "@NumOfTasks" };
                object[] Values = { name, ToDoItemStatus.Backlog, "", DateTime.Now, ToDoItemPriority.None, user.id, 0 };
                MyDB.updateTable(qry, Parameters, Values);
                Page_Load(sender, e);
            }
        }

        protected void btnOpenProject_Click(object sender, EventArgs e)
        {
            if (Session["ProjectId"] != null)
                Response.Redirect("ProjectManager.aspx");
        }
        protected void btnDeleteProject_Click(object sender, EventArgs e)
        {
            //delete the tasks of the projects from DB first
            string[] parameters = { "@ProjectId" };
            object[] values = { Convert.ToInt32(Session["projectId"]) };
            string qry = "DELETE FROM TaskTbl WHERE projectId = @ProjectId";
            MyDB.updateTable(qry, parameters, values);
            qry = "DELETE FROM ProjectTbl WHERE id = @ProjectId";
            MyDB.updateTable(qry, parameters, values);
            Session["projectId"] = null;
            Page_Load(sender, e);
        }
        protected void btnEditProject_Click(object sender, EventArgs e)
        {
            string qry = "UPDATE [ProjectTbl] SET name = @Name, status = @Status, description = @Description, deadline = @Deadline, priority = @Priority ";
            qry += "WHERE id = @ProjectId";

            string[] Parameters = { "@Name", "@Status", "@Description", "@Deadline", "@Priority", "@ProjectId" };
            object[] Values = { txtProjectName.Text, (int)Enum.Parse(typeof(ToDoItemStatus), ddlProjectStatus.SelectedValue)
                    , txtProjectDisc.Text, DateTime.Parse(txtProjectDeadline.Text), (int)Enum.Parse(typeof(ToDoItemPriority), ddlProjectPriority.SelectedValue), Convert.ToInt32(Session["projectId"] )};

            MyDB.updateTable(qry, Parameters, Values);
            Page_Load(sender, e);
            RefreshDetails(Convert.ToInt32(Session["projectId"]));
        }
        
    }
}