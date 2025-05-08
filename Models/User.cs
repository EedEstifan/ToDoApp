using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ToDoApp.App_Code;

namespace ToDoApp.Models
{
    public class User
    {
        public int id { get; set; }
        public int numOfProjects { get; private set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Project> projects { get; set; }
        public string imgURL { get; set; }
        public bool isAdmin { get; set; }

        public User(string firstName, string lastName, string gender, string email, string password, string imgURL, bool isAdmin, int id=0)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.email = email;
            this.password = password;
            this.numOfProjects = 0;
            projects = new List<Project>();
            this.imgURL = imgURL;
            this.isAdmin = isAdmin;
        }
        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        //Constructor that gets user id and loads all his data from DB
        public User(int id)
        {
            string qry= "SELECT * FROM UserTbl WHERE id = @ID";
            DataSet ds= MyDB.select(qry, new string[] { "@ID" }, new object[] { id });
            this.id = id;
            this.firstName = ds.Tables[0].Rows[0]["firstName"].ToString();
            this.lastName = ds.Tables[0].Rows[0]["lastName"].ToString();
            this.gender = ds.Tables[0].Rows[0]["gender"].ToString();
            this.email = ds.Tables[0].Rows[0]["email"].ToString();
            this.password = ds.Tables[0].Rows[0]["password"].ToString();
            this.numOfProjects = Convert.ToInt32(ds.Tables[0].Rows[0]["numOfProjects"]);  
            this.projects = new List<Project>();  
            this.imgURL = ds.Tables[0].Rows[0]["imgURL"].ToString();
            this.isAdmin = Convert.ToBoolean(ds.Tables[0].Rows[0]["isAdmin"]);
            loadProjects();
        }

        public override string ToString()
        {
            return $"User: {firstName} {lastName}, Gender: {gender}, Email: {email}";
        }

        public void addProject(int id)
        {
            projects.Add(new Project(id));
            numOfProjects++;
        }

        public void addProject(Project project)
        {
            projects.Add(project);
            numOfProjects++;
        }

        public bool removeProject(int id)
        {
            int index = projects.FindIndex(project => project.id == id);
            if (index != -1)  // Check if the index is valid
            {
                projects.RemoveAt(index);
                numOfProjects--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Project getProject(int id)
        {
            return projects.Find(project => project.id == id);//!!!need to check what returns
        }

        public bool insertUser()
        {
            if (isExists() == true) return false;
            string qry = "INSERT INTO[UserTbl](email, password, gender, firstName, lastName, numOfProjects, isAdmin, imgURL) ";
            qry += "VALUES (@Email, @Password, @Gender, @FirstName, @LastName, @NumOfProjects, @IsAdmin, @ImgURL)";
            string[] Parameters = { "@Email", "@Password", "@Gender", "@FirstName", "@LastName", "@NumOfProjects", "@IsAdmin", "@ImgURL "};
            object[] Values = { email, password, gender, firstName,lastName,numOfProjects,isAdmin,imgURL};
            MyDB.updateTable(qry, Parameters, Values);
            return true;
        }

        public bool isExists()
        {
            string qry = "SELECT * FROM UserTbl WHERE email = @Email;";
            DataSet ds = MyDB.select(qry, new string[] {"@Email" }, new object[] { email });
            if(ds.Tables[0].Rows.Count > 0) return true; 
            else return false;
        }

        public int getUserIdByEmailPassword()
        {
            string qry = "SELECT * FROM UserTbl WHERE email = @Email AND password = @Password;";
            DataSet ds = MyDB.select(qry, new string[] { "@Email", "@Password" }, new object[] { email, password });
            if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Rows.Count > 1) return -1;
            else return int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
        }

        public bool isValidEmailPassword()
        {
            if(getUserIdByEmailPassword() == -1) return false;
            else return true;
        }

        public void loadProjects()
        {
            string qry = "SELECT * FROM ProjectTbl WHERE userId = @userId;";
            DataSet ds = MyDB.select(qry, new string[] { "@userId" }, new object[] { id });
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string name = row["name"].ToString();
                ToDoItemStatus status = (ToDoItemStatus)Enum.Parse(typeof(ToDoItemStatus), row["status"].ToString());
                string description = row["description"].ToString();
                DateTime deadline = DateTime.TryParse(row["deadline"].ToString(), out DateTime resultDeadline) ? resultDeadline : default(DateTime);
                ToDoItemPriority priority = (ToDoItemPriority)Enum.Parse(typeof(ToDoItemPriority), row["priority"].ToString());
                Project project = new Project(id, name, status, description, deadline, priority);
                project.loadProjectTasks();
                addProject(project);
            }
        }

        

    }
}