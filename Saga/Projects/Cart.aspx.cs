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
    public partial class Cart : System.Web.UI.Page
    {
        ProductManager productManager = new ProductManager();
        DataTable dt = new DataTable();
        int TotalCheckedCount=0;
        protected SessionObject.User sessionUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserID = 0;
            if (SessionObject.Sess(Session)!= null)
            {
                sessionUser = SessionObject.Sess(Session).SiteUSer;
                UserID = sessionUser.UserID;

                if (!IsPostBack)
                {
                    //    int UserID = sessionUser.UserID;

                    //TotalCheckedCount = productManager.SaveCartProduct(0, UserID, "");
                    //if (TotalCheckedCount>0)
                    //{
                    //    lblPriceDetl.Text=$"Price Details({TotalCheckedCount} items)";
                    //    chkTotalCart.Checked=true;
                    //    lblTotalchk.Text=$"{TotalCheckedCount}/{TotalCheckedCount} Items Selected";
                    //}

                    dt = productManager.GetCartProduct(UserID);
                    if (dt!= null && dt.Rows.Count>0)
                    {
                        EmptyCart.Visible = false;
                        rptrCartPRdct.DataSource = dt;
                        rptrCartPRdct.DataBind();
                        lblTotalMRP.Text ="Rs."+ dt.AsEnumerable().Where(row => Convert.ToBoolean(row["IsChecked"]) == true).Sum(x => x.Field<int>("SizePrice")).ToString();
                        lblTotalAmount.Text="Rs."+ dt.AsEnumerable().Where(row => Convert.ToBoolean(row["IsChecked"]) == true).Sum(x => x.Field<int>("SizePrice")+50).ToString();
                        TotalCheckedCount = dt.AsEnumerable().Where(row => Convert.ToBoolean(row["IsChecked"]) == true).Count();
                        lblPriceDetl.Text=$"Price Details({TotalCheckedCount} items)";
                        if (TotalCheckedCount>0)
                            chkTotalCart.Checked=true;
                        lblTotalchk.Text=$"{TotalCheckedCount}/{dt.Rows.Count} Items Selected";
                        foreach (RepeaterItem item in rptrCartPRdct.Items)
                        {
                            DropDownList ddlProductQty = (DropDownList)item.FindControl("ddlQty");
                            ddlProductQty.Items.Clear();
                            TextBox Qty = (TextBox)item.FindControl("lblQtys");
                            //string z = Qty.Text;
                            for (int x = 1; x<=Convert.ToInt32(Qty.Text); x++)
                            {
                                ddlProductQty.Items.Add(x.ToString());
                            }
                            TextBox QtyCount = (TextBox)item.FindControl("txtQtyCount");


                            ddlProductQty.SelectedValue = QtyCount.Text;
                            CheckBox chkCart = (CheckBox)item.FindControl("chkCart");
                            int CartID = Convert.ToInt32(chkCart.Attributes["value"]);
                            bool IsCartChecked = Convert.ToBoolean(dt.AsEnumerable().Where(row => Convert.ToInt32(row["CartId"]) == CartID).Select(row => row.Field<bool?>("IsChecked")).FirstOrDefault());
                            chkCart.Checked=IsCartChecked;
                        }

                    }
                    else
                    {
                        EmptyCart.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("/Projects/Login.aspx", true);
              
            }
        }


        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int UserId = sessionUser.UserID;
                TextBox CartId = (TextBox)e.Item.FindControl("txtCartId");
                int Deleted = productManager.UpdateCartValue(Convert.ToInt32(CartId.Text), UserId,1);
                if (Deleted==1)
                {
                    int CartCount = productManager.SaveCartProduct(0, UserId, "");
                    Label lblMasterStatus = (Label)Master.FindControl("lblCount");
                    Control redbadge = (Control)Master.FindControl("notification");
                    lblerrMsg.Text="Deleted Successfully.";

                    if (CartCount>0)
                    {
                        redbadge.Visible = true;
                        lblMasterStatus.Text  = CartCount.ToString();
                    }
                    else
                    {
                        redbadge.Visible = false;
                    }

                    dt = productManager.GetCartProduct(UserId);
                    if (dt!= null && dt.Rows.Count>0)
                    {
                        EmptyCart.Visible = false;
                        rptrCartPRdct.DataSource = dt;
                        rptrCartPRdct.DataBind();
                        lblTotalMRP.Text ="Rs."+ dt.AsEnumerable().Where(row => Convert.ToBoolean(row["IsChecked"]) == true).Sum(x => x.Field<int>("SizePrice")).ToString();
                        lblTotalAmount.Text="Rs."+ dt.AsEnumerable().Where(row => Convert.ToBoolean(row["IsChecked"]) == true).Sum(x => x.Field<int>("SizePrice")+50).ToString();
                        TotalCheckedCount = dt.AsEnumerable().Where(row => Convert.ToBoolean(row["IsChecked"]) == true).Count();
                        lblPriceDetl.Text=$"Price Details({TotalCheckedCount} items)";
                        if (TotalCheckedCount>0)
                            chkTotalCart.Checked=true;
                        lblTotalchk.Text=$"{TotalCheckedCount}/{dt.Rows.Count} Items Selected";
                        foreach (RepeaterItem item in rptrCartPRdct.Items)
                        {
                            CheckBox chkCart = (CheckBox)item.FindControl("chkCart");
                            int CartID = Convert.ToInt32(chkCart.Attributes["value"]);
                            bool IsCartChecked = Convert.ToBoolean(dt.AsEnumerable().Where(row => Convert.ToInt32(row["CartId"]) == CartID).Select(row => row.Field<bool?>("IsChecked")).FirstOrDefault());
                            chkCart.Checked=IsCartChecked;
                        }
                    }
                    else
                    {

                        rptrCartPRdct.DataSource = null;
                        rptrCartPRdct.DataBind();
                        EmptyCart.Visible = true;
                    }

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"$('#myModal').modal('show');");
                    //sb.Append(@"$('#lblerrMsg').innerHTML = 'ABCDE';");
                    sb.Append(@"</script>");

                    ClientScript.RegisterStartupScript(this.GetType(), "JSScript", sb.ToString());

                }
                else
                {
                    lblerrMsg.Text="Cuurently cannot proceed with the Command.";
                }
            }
            
        }

        protected void chkCart_CheckedChanged(object sender, EventArgs e)
        {
            int UserId = sessionUser.UserID;
            var chk = (CheckBox)sender;
            var CartID = chk.Attributes["value"];
                int Ischecked = productManager.UpdateCartValue(Convert.ToInt32(CartID), UserId,2, chk.Checked);


            dt = productManager.GetCartProduct(UserId);
            if (dt!= null && dt.Rows.Count>0)
            {
                EmptyCart.Visible = false;
                lblTotalMRP.Text ="Rs."+ dt.AsEnumerable().Where(row => Convert.ToBoolean(row["IsChecked"]) == true).Sum(x => x.Field<int>("SizePrice")).ToString();
                lblTotalAmount.Text="Rs."+ dt.AsEnumerable().Where(row => Convert.ToBoolean(row["IsChecked"]) == true).Sum(x => x.Field<int>("SizePrice")+50).ToString();
                TotalCheckedCount = dt.AsEnumerable().Where(row => Convert.ToBoolean(row["IsChecked"]) == true).Count();
                lblPriceDetl.Text=$"Price Details({TotalCheckedCount} items)";
                if (TotalCheckedCount>0)
                    chkTotalCart.Checked=true;
                lblTotalchk.Text=$"{TotalCheckedCount}/{dt.Rows.Count} Items Selected";
            }
        }
    }
}