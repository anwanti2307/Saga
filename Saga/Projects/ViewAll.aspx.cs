using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Saga.Projects
{
    public partial class ViewAll : System.Web.UI.Page
    {
        BusinessLayer.Manager.ProductManager productManager = new BusinessLayer.Manager.ProductManager();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(Request.QueryString["CId"]);
            dt = productManager.GetProductList(2, CategoryID);
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