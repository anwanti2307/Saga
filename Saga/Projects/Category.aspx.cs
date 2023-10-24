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
    public partial class Category : System.Web.UI.Page
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
            int CategoryID = Convert.ToInt32(Request.QueryString["CId"]);
            dt = productManager.GetProductList(0, CategoryID);
            if (dt != null && dt.Rows.Count>0)
            {
                rptrctgrImages.DataSource = dt;
                rptrctgrImages.DataBind();
            }
            else
            {
                rptrctgrImages.DataSource = null;

            }
        }
    }
}