using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ToDoApp.App_Code;
using ToDoApp.Models;

namespace ToDoApp
{
    public partial class Profile : Page
    {
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
                user = new User(Convert.ToInt32(Session["UserID"]));
            if (!IsPostBack)
            {
                if (Session["UserID"] == null) Response.Redirect("NeedToSignin.aspx");
                else
                { 
                    lblFirstName.Text = user.firstName;
                    lblLastName.Text = user.lastName;
                    lblGender.Text = user.gender;
                    lblEmail.Text = user.email;
                    lblPassword.Text = user.password;
                    lblProjectsDone.Text =  $"{user.numOfDoneProjects()}/{user.numOfProjects}";
                    lblIsAdmin.Text = user.isAdmin ? "Yes" : "No";
                    ProfileImage.ImageUrl = user.imgURL;
                    lblWelcome.InnerHtml=$"Welcome {user.firstName} !!";
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuProfilePicture.HasFile)
            {
                // Define save path inside the server
                string folderPath = Server.MapPath("~/uploads/");

                // Ensure the folder exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Get file name and combine with folder path
                string fileName = Path.GetFileName(fuProfilePicture.FileName);
                string filePath = Path.Combine(folderPath, fileName);

                // Save file on the server
                fuProfilePicture.SaveAs(filePath);

                // Convert file path to a relative URL (for display)
                user.imgURL = "~/uploads/" + fileName;
                // Update image source
                user.UpdateUser();
                ProfileImage.ImageUrl = user.imgURL;

            }
        }

        protected void EditFirstName(object sender, EventArgs e)
        {
            ToggleEdit(lblFirstName, txtFirstName, btnEditFirstName, btnSaveFirstName);
        }

        protected void SaveFirstName(object sender, EventArgs e)
        {
            user = new User(Convert.ToInt32(Session["UserID"]));
            user.firstName = txtFirstName.Text;
            user.UpdateUser();
            lblFirstName.Text = user.firstName;
            ToggleSave(lblFirstName, txtFirstName, btnEditFirstName, btnSaveFirstName);

        }

        protected void EditLastName(object sender, EventArgs e)
        {
            ToggleEdit(lblLastName, txtLastName, btnEditLastName, btnSaveLastName);
        }

        protected void SaveLastName(object sender, EventArgs e)
        {
            user = new User(Convert.ToInt32(Session["UserID"]));
            user.lastName = txtLastName.Text;
            user.UpdateUser();
            lblLastName.Text = user.lastName;
            ToggleSave(lblLastName, txtLastName, btnEditLastName, btnSaveLastName);
        }

        protected void EditGender(object sender, EventArgs e)
        {
            lblGender.Visible = false;
            ddlGender.Visible = true;
            ddlGender.SelectedValue = lblGender.Text;
            btnEditGender.Visible = false;
            btnSaveGender.Visible = true;
        }

        protected void SaveGender(object sender, EventArgs e)
        {
            user = new User(Convert.ToInt32(Session["UserID"]));
            user.gender = ddlGender.SelectedValue;
            user.UpdateUser();
            lblGender.Text = user.gender;
            lblGender.Visible = true;
            ddlGender.Visible = false;
            btnEditGender.Visible = true;
            btnSaveGender.Visible = false;
        }

        protected void EditPassword(object sender, EventArgs e)
        {
            ToggleEdit(lblPassword, txtPassword, btnEditPassword, btnSavePassword);
        }

        protected void SavePassword(object sender, EventArgs e)
        {
            user = new User(Convert.ToInt32(Session["UserID"]));
            user.password = txtPassword.Text;
            user.UpdateUser();
            lblPassword.Text = user.password;
            ToggleSave(lblPassword, txtPassword, btnEditPassword, btnSavePassword);
        }

        protected void ToggleEdit(Label label, TextBox textbox, Button editBtn, Button saveBtn)
        {
            textbox.Text = label.Text;
            label.Visible = false;
            textbox.Visible = true;
            editBtn.Visible = false;
            saveBtn.Visible = true;
        }

        protected void ToggleSave(Label label, TextBox textbox, Button editBtn, Button saveBtn)
        {
            label.Visible = true;
            textbox.Visible = false;
            editBtn.Visible = true;
            saveBtn.Visible = false;
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Signin.aspx");
        }
    }
}