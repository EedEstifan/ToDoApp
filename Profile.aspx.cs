using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoApp.Models;

namespace ToDoApp
{
    public partial class Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null) Response.Redirect("NeedToSignin.aspx");
            else
            {
                User user = new User(Convert.ToInt32(Session["UserID"]));
                lblWelcome.InnerText = $"Welcome {user.firstName}";
                lblFirstName.Text = user.firstName;
                lblLastName.Text = user.lastName;
                lblPassword.Text = user.password;
                lblEmail.Text = user.email;
                profileImage.ImageUrl = user.imgURL;
            }
        }

        // Edit Profile Picture
        protected void EditPicture(object sender, EventArgs e)
        {
           
        }

        // Edit First Name
        protected void EditFirstName(object sender, EventArgs e)
        {
            
        }

        // Edit Last Name
        protected void EditLastName(object sender, EventArgs e)
        {
           
        }

        // Edit Gender
        protected void EditGender(object sender, EventArgs e)
        {
            
        }

        // Edit Password
        protected void EditPassword(object sender, EventArgs e)
        {

        }

        protected void EditEmail(object sender, EventArgs e)
        {

        }
    }
}