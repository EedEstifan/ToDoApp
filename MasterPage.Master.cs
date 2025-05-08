using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // No special logic needed on page load
    }

    protected void MainMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        switch (e.Item.Value)
        {
            case "Login":
                Response.Redirect("Signin.aspx");
                break;
            case "Projects":
                Response.Redirect("Projects.aspx");
                break;
        }
    }
}
