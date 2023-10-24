using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLayer.Manager;
using System.Web.Security;

namespace Saga
{
    public partial class SiteMaster : MasterPage
    {
        ProductManager productManager = new ProductManager();
        protected SessionObject.User sessionUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserID = 0;
            if (SessionObject.Sess(Session)!= null)
            {
                sessionUser = SessionObject.Sess(Session).SiteUSer;
                UserID = sessionUser.UserID;
            }
           
            if (!IsPostBack)
            {
               
                int CartCount = productManager.SaveCartProduct(0, UserID, "");
                if (CartCount>0)
                {
                    notification.Visible = true;
                    lblCount.Text  = CartCount.ToString();
                }
                else
                {
                    notification.Visible = false;
                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
           if(SessionObject.Sess(HttpContext.Current.Session) != null)
            {
                SessionObject.Sess(HttpContext.Current.Session).SiteUSer = null;
            }
           HttpContext.Current.Session.Clear();
           HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("/Projects/Login",true);
        }
    }
}