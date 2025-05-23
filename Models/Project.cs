using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ToDoApp.App_Code;
namespace ToDoApp.Models
{
    public class Project : ToDoItem
    {
        
        public List<Task> tasks { get; set; }
        public int numOfTasks { get; private set; }

        public Project(int id, string name , ToDoItemStatus status ,string description, DateTime deadline, ToDoItemPriority priority)
            : base(id,name, status, description, deadline, priority)
        {
            tasks = new List<Task>();
            numOfTasks = 0;
        }

        public Project(int id):base(id)
        {
            tasks = new List<Task>();
            numOfTasks = 0;
            string qry = "SELECT * FROM ProjectTbl WHERE id = @ID";
            DataSet ds = MyDB.select(qry, new string[] { "@ID" }, new object[] { id });
            DataRow row = ds.Tables[0].Rows[0];
            base.name = row["name"].ToString();
            base.status= (ToDoItemStatus)Enum.Parse(typeof(ToDoItemStatus), row["status"].ToString());
            base.description = row["description"].ToString();
            base.deadline = DateTime.TryParse(row["deadline"].ToString(), out DateTime resultDeadline) ? resultDeadline : default(DateTime);
            base.priority= (ToDoItemPriority)Enum.Parse(typeof(ToDoItemPriority), row["priority"].ToString());
            loadProjectTasks();
        }

        public void addTask(int id)
        {
            tasks.Add(new Task(id));
            numOfTasks++;
        }

        public void addTask(Task task)
        {
            tasks.Add(task);
            numOfTasks++;
        }

        public bool removeTask(int id)
        {
            int index = tasks.FindIndex(task => task.id == id);
            if (index != -1)  // Check if the index is valid
            {
                tasks.RemoveAt(index);
                numOfTasks--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task getTask(int id)
        {
            return tasks.Find(task => task.id == id);//!!!need to check what returns
        }

        public int numOfDoneTasks()
        {
            int count = 0;
            for (int i = 0; i < numOfTasks; i++)
            {
                if (tasks[i].status == ToDoItemStatus.Done) count++;
            }
            return count;
        }

        public void loadProjectTasks()
        {
            string qry = "SELECT * FROM TaskTbl WHERE projectId = @projectId;";
            DataSet ds = MyDB.select(qry, new string[] { "@projectId" }, new object[] { id });
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string name = row["name"].ToString();
                ToDoItemStatus status = (ToDoItemStatus)Enum.Parse(typeof(ToDoItemStatus), row["status"].ToString());
                string description = row["description"].ToString();
                DateTime dueDate = DateTime.TryParse(row["dueDate"].ToString(), out DateTime resultDuedate) ? resultDuedate : default(DateTime);
                DateTime deadline = DateTime.TryParse(row["deadline"].ToString(), out DateTime resultDeadline) ? resultDeadline : default(DateTime);
                ToDoItemPriority priority = (ToDoItemPriority)Enum.Parse(typeof(ToDoItemPriority), row["priority"].ToString());
                addTask(new Task(id, name, status, description, dueDate, deadline, priority));
            }
        }

        public void SortTasksByPriority()
        {
            tasks.Sort((a, b) => b.priority.CompareTo(a.priority));
        }
    }
}