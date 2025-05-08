using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoApp.App_Code;
using ToDoApp.Models;

namespace ToDoApp
{
    public partial class ProjectManager : System.Web.UI.Page
    {
        Project project;
        private void bindRepeater()
        {
            project = new Project(Convert.ToInt32(Session["projectId"].ToString()));
            if(Convert.ToBoolean(Session["isSort"])==true)project.SortTasksByPriority();
            Repeater1.DataSource = project.tasks;
            Repeater1.DataBind();
        }

        
        private void RefreshDetails(int taskId)
        {
            Task selectedTask = project.getTask(taskId);
            txtTaskName.Text = selectedTask.name;
            txtTaskDisc.Text = selectedTask.description;
            txtTaskDeadline.Text = selectedTask.deadline.ToString("yyyy-MM-dd");
            txtTaskDuedate.Text = selectedTask.deadline.ToString("yyyy-MM-dd");
            ddlTaskPriority.SelectedValue = selectedTask.priority.ToString();
            ddlTaskStatus.SelectedValue = selectedTask.status.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                if (Session["projectId"] != null)
                {
                    project = new Project(Convert.ToInt32(Session["projectId"].ToString()));
                    if (!IsPostBack)
                    {
                        Session["isSort"] = false;
                        Session["taskId"] = null;
                        Repeater1.DataSource = project.tasks;
                        Repeater1.DataBind();
                    }
                    
                }
                else Response.Redirect("projects.aspx");
            }
            else
            {
                Response.Redirect("NeedToSignin.aspx");
            }

        }
        protected void btnNewTask_Click(object sender, EventArgs e)
        {
            string name = txtNewTaskName.Text.Trim();
            if (name != "")
            {
                string qry = "INSERT INTO [TaskTbl](name, status, description, dueDate, deadline, priority, projectId) ";
                qry += "VALUES (@Name, @Status, @Description, @DueDate, @Deadline, @Priority, @ProjectId)";
                string[] Parameters = { "@Name", "@Status", "@Description", "@DueDate", "@Deadline", "@Priority", "@ProjectId"};
                object[] Values = { name, ToDoItemStatus.Backlog, "", DBNull.Value, DBNull.Value, ToDoItemPriority.None, project.id };
                MyDB.updateTable(qry, Parameters, Values);
                bindRepeater();
            }
        }
        protected void btnEditTask_Click(object sender, EventArgs e)
        {
            if (Session["taskId"] == null) return;
            string qry = "UPDATE [TaskTbl] SET name = @Name, status = @Status, dueDate = @DueDate, description = @Description, deadline = @Deadline, priority = @Priority ";
            qry += "WHERE id = @TaskId";

            string[] Parameters = { "@Name", "@Status", "@Description", "@DueDate", "@Deadline", "@Priority", "@TaskId" };
            object[] Values = { txtTaskName.Text, (int)Enum.Parse(typeof(ToDoItemStatus), ddlTaskStatus.SelectedValue)
                    , txtTaskDisc.Text, DateTime.Parse(txtTaskDuedate.Text), DateTime.Parse(txtTaskDeadline.Text),(int)Enum.Parse(typeof(ToDoItemPriority), ddlTaskPriority.SelectedValue),Convert.ToInt32(Session["taskId"])};
            MyDB.updateTable(qry, Parameters, Values);
            bindRepeater();
            RefreshDetails(Convert.ToInt32(Session["taskId"]));
        }

        protected void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (Session["taskId"] == null) return;
            string[] parameters = { "@TaskId" };
            object[] values = { Convert.ToInt32(Session["taskId"]) };
            string qry = "DELETE FROM TaskTbl WHERE id = @TaskId";
            MyDB.updateTable(qry, parameters, values);
            Session["taskId"] = null;
            bindRepeater();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Click")
            {
                int taskId = int.Parse(e.CommandArgument.ToString());
                Session["taskId"] = taskId;
                RefreshDetails(taskId);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["projectId"] = null;
            Session["taskId"] = null;
            Response.Redirect("Projects.aspx");
        }
        protected void btnSort_Click(object sender, EventArgs e)
        {
            bool isSort = Convert.ToBoolean(Session["isSort"]);
            if (isSort)
            {
                btnSort.Text = "Sort By Priority";
                Session["isSort"] = false;
            }
            else
            {
                btnSort.Text = "Remove Sorting";
                Session["isSort"] = true;
            }

            bindRepeater();

        }
        
    }

}