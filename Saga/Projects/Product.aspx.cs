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
    public partial class WebForm1 : System.Web.UI.Page
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
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            dt = productManager.GetProductImages(ID);
            if (dt!= null && dt.Rows.Count>0)
            {
                rptrProductImages.DataSource = dt;
                rptrProductImages.DataBind();
                ltrlContent.Text= dt.Rows[0]["ProductName"].ToString();
                lblSubDescription.Text= dt.Rows[0]["SubDescription"].ToString();

                List<int> Prices = new List<int> { Convert.ToInt32(dt.Rows[0]["SizeSPrice"]),
                    Convert.ToInt32(dt.Rows[0]["SizeMPrice"]),
                    Convert.ToInt32(dt.Rows[0]["SizeLPrice"])};
                int minPrice = Prices.Min();
                lblPrice.Text= "Rs."+minPrice.ToString();
                lblProdctdetails.Text= dt.Rows[0]["Description"].ToString();
                lblFabric.Text=dt.Rows[0]["FabricDescription"].ToString();
            }
            if (!IsPostBack)
            {
                ViewState["Size"]= null;
            }

            
        }

        protected void btnAddCart_Click(Object sender,EventArgs e)
        {
            try
            {
                if (ViewState["Size"]== null)
                {
                    LblSizeError.Visible=true;
                }
                else
                {
                    int ProductID = Convert.ToInt32(Request.QueryString["id"]);
                    int UserId = 1;//Convert.ToInt32(Session["UserID"]);

                    string Size = ViewState["Size"].ToString().Trim();
                    int CartCount = productManager.SaveCartProduct(ProductID, UserId, Size);
                    Control redbadge = (Control)Master.FindControl("notification");
                    Label lblMasterStatus = (Label)Master.FindControl("lblCount");
                    if (CartCount>0)
                    {
                        lblerrMsg.Text="Item Added Successfully to Cart";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Success", "showmodalpopup();", true);
                        redbadge.Visible = true;
                        lblMasterStatus.Text  = CartCount.ToString();
                    }
                    else
                    {
                        redbadge.Visible = false;
                    }
                    //lblMasterStatus.Text  = CartCount.ToString(); 
                }
            }
            catch (Exception ex) {
                throw;
            }
        }

        protected void btnSizeS_Click(Object sender, EventArgs e)
        {
            try
            {
                ViewState["Size"] ="S";
                LblSizeError.Visible=false;
                int ID = Convert.ToInt32(Request.QueryString["id"]);
                dt = productManager.GetProductImages(ID);
                lblPrice.Text= "Rs."+Convert.ToInt32(dt.Rows[0]["SizeSPrice"]);
                lblS.Style["border"]= "2px solid black;";
                lblM.Style["border"]= "2px solid black;";
                lblL.Style["border"]= "2px solid black;";
                lblS.Style["border"]= "2px solid red;";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnSizeMedium_Click(Object sender, EventArgs e)
        {
            try
            {
                ViewState["Size"] ="M";
                LblSizeError.Visible=false;
                int ID = Convert.ToInt32(Request.QueryString["id"]);
                dt = productManager.GetProductImages(ID);
                lblPrice.Text= "Rs."+Convert.ToInt32(dt.Rows[0]["SizeMPrice"]);
                lblS.Style["border"]= "2px solid black;";
                lblM.Style["border"]= "2px solid black;";
                lblL.Style["border"]= "2px solid black;";
                lblM.Style["border"]= "2px solid red;";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnSizeLarge_Click(Object sender, EventArgs e)
        {
            try
            {
                ViewState["Size"] ="L";
                LblSizeError.Visible=false;
                int ID = Convert.ToInt32(Request.QueryString["id"]);
                dt = productManager.GetProductImages(ID);
                lblPrice.Text= "Rs."+Convert.ToInt32(dt.Rows[0]["SizeLPrice"]);
                lblS.Style["border"]= "2px solid black;";
                lblM.Style["border"]= "2px solid black;";
                lblL.Style["border"]= "2px solid black;";
                lblL.Style["border"]= "2px solid red;";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}