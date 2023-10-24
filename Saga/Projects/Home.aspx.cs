using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer.Manager;
using BusinessLayer;



namespace Saga
{
    public partial class Home : System.Web.UI.Page
    {
        ProductManager productManager = new ProductManager();
        DataTable dt = new DataTable();
        protected SessionObject.User sessionUser;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (SessionObject.Sess(Session)!= null)
            {
                sessionUser = SessionObject.Sess(Session).SiteUSer;
            }
            else
            {
                Response.Redirect("/Projects/Login.aspx", true);

            }
            int Types = 1;
            dt = productManager.GetProductList(Types);
            rptrImages.DataSource = dt;
            rptrImages.DataBind();
           
            dt = productManager.GetProductList( Types=2);
            rptrCategory.DataSource = dt;
            rptrCategory.DataBind();    

        }
     

    }
}