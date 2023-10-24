using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer.Manager;
using BusinessLayer;

namespace Saga.Projects
{
   
    public partial class Login : System.Web.UI.Page
    {
         UserManager userManager = new UserManager();
         EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
         SessionObject sessionObject = new SessionObject();
        //DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(Object sender, EventArgs e)
        {
            try
            {
                lblinvalidErr.Visible=false;
                string Email = txtEmailId.Text.Trim();
                string Password = txtPassWord.Text.Trim();
                Email= encryptDecrypt.EnryptString(Email);
                Password = encryptDecrypt.EnryptString(Password);
                List<SessionObject.User> UserDetails = userManager.ValidateUser(Email, Password,true);
                if (UserDetails != null && UserDetails.Count == 1)
                {
                    Session["UserSession"] = new SessionObject();
                    SessionObject.Sess(Session).SiteUSer =  UserDetails.FirstOrDefault();
                    Response.Redirect("/Projects/Home.aspx", true);
                }
                else
                {
                    lblinvalidErr.Visible=true;
                }
            }
            catch (Exception ex)
            {
                lblinvalidErr.Visible=true;
            }
        }
    }
}