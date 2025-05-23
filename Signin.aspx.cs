using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoApp.App_Code;
using ToDoApp.Models;

namespace ToDoApp
{
    public partial class Signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            User user = new User(email, password);
            if (user.isValidEmailPassword() == true)
            {
                Session["userId"] = user.getUserIdByEmailPassword();
                Response.Redirect("Profile.aspx");
            }
            else
            {
                lblMessage.Text = "Email or pasword is incrrect";
            }
        }

        private bool ValidateUser(string email, string password)
        {
            bool isValid = false;
            string connectionString = WebConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    isValid = count > 0;
                }
            }

            return isValid;
        }
    }
}