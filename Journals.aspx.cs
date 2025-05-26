using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoApp.App_Code;
using ToDoApp.Models;

namespace ToDoApp
{
    public partial class Journals : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null) Response.Redirect("NeedToSignin.aspx");
            pnlJournal.Visible = false;
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(txtDate.Text, out DateTime selectedDate))//convert string to date
            {
                lblMessage.Text = "Invalid date format.";
                return;
            }

            string qry = "SELECT * FROM JournalTbl WHERE userId=@userId AND journalDate=@date";
            string[] parameters = { "@userId", "@date" };
            object[] values = { Session["userId"], selectedDate };

            DataSet ds = MyDB.select(qry, parameters, values);

            pnlJournal.Visible = true;

            if (ds.Tables[0].Rows.Count > 0)
            {
                // Edit mode
                if (selectedDate != DateTime.Today)
                {
                    ddlMood.Enabled = false;
                    txtContent.ReadOnly = true;
                    btnSave.Text = "Done";
                }
                else
                {
                    ddlMood.Enabled = true;
                    txtContent.ReadOnly = false;
                    btnSave.Text = "Save";
                }
               
                ddlMood.SelectedValue= ((MoodLevel)((int)ds.Tables[0].Rows[0]["mood"])).ToString();
                txtContent.Text = ds.Tables[0].Rows[0]["content"].ToString();
                btnSave.CommandArgument = ds.Tables[0].Rows[0]["id"].ToString();//indicates that already exists a journal for today
                lblMessage.Text = "Journal loaded. You can edit it.";
            }
            else
            {

                ddlMood.Enabled = true;
                txtContent.ReadOnly = false;
                btnSave.Text = "Save";
                txtContent.Text = "";
                btnSave.CommandArgument = "0";//indicates new journal for today
                lblMessage.Text = "No journal found. You can create a new one.";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(txtDate.Text, out DateTime selectedDate))
            {
                lblMessage.Text = "Invalid date format.";
                return;
            }

            MoodLevel mood;
            Enum.TryParse(ddlMood.SelectedValue, out mood);
            string content = txtContent.Text.Trim();
            int userId = Convert.ToInt32(Session["userId"]);

            if (btnSave.CommandArgument == "0")
            {
                // Insert new
                string qry = "INSERT INTO JournalTbl (mood, content, journalDate, userId) VALUES (@mood, @content, @date, @userId)";
                string[] parameters = { "@mood", "@content", "@date", "@userId" };
                object[] values = { mood, content, selectedDate, userId };
                MyDB.updateTable(qry, parameters, values);
                lblMessage.Text = "Journal saved successfully.";
            }
            else
            {
                // Update existing
                int id = int.Parse(btnSave.CommandArgument);
                string qry = "UPDATE JournalTbl SET mood=@mood, content=@content WHERE id=@id";
                string[] parameters = { "@mood", "@content", "@id" };
                object[] values = { mood, content, id };
                MyDB.updateTable(qry, parameters, values);
                lblMessage.Text = "Journal updated successfully.";
            }
        }
        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
        
    }
}
