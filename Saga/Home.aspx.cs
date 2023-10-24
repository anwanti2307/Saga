using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Saga
{
    public partial class Home : System.Web.UI.Page
    {
        BusinessLayer.SQLHelper sQLHelper = new BusinessLayer.SQLHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //find the nested datalist and cast it as one
            DataList datalist = e.Item.FindControl("dlImages") as DataList;

            //find the correct group id of the item
            string ID = DataBinder.Eval(e.Item.DataItem, "Id").ToString();


            //bind data to the nested datalist with the Group_Id in the where clause of the query
            datalist.DataSource = dt;
            datalist.DataBind();
        }
    }
}