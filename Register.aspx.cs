using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoApp.Models;

namespace ToDoApp
{
    public partial class Register : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = ""; // Clear error message
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            User user;
            int id = 0;
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string gender = rbMale.Checked ? "Male" : (rbFemale.Checked ? "Female" : "Not Specified");
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string urlImage="";
            if (imgUpload.HasFile)
            {
                // Define save path inside the server
                string folderPath = Server.MapPath("~/uploads/");

                // Ensure the folder exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Get file name and combine with folder path
                string fileName = Path.GetFileName(imgUpload.FileName);
                string filePath = Path.Combine(folderPath, fileName);

                // Save file on the server
                imgUpload.SaveAs(filePath);

                // Convert file path to a relative URL (for display)
                urlImage = "~/uploads/" + fileName;
                // Update image source
            }

            //validations
            user = new User(firstName, lastName, gender, email, password, urlImage, false, id);
            user.insertUser();
        }
  
        private bool checkFieldsFilled()
        {
            // Check if all fields are filled
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                lblMessage.Text = "Please enter your first name.";
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                lblMessage.Text = "Please enter your last name.";
                return false;
            }

            if (!rbMale.Checked && !rbFemale.Checked)
            {
                lblMessage.Text = "Please select your gender.";
                return false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                lblMessage.Text = "Please enter your email.";
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                lblMessage.Text = "Please enter a password.";
                return false;
            }

            // If all fields are filled, return true
            return true;
        }
    }
}