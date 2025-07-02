using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class myinvestment : System.Web.UI.Page
{
    private string query;
    private DataTable Dt = new DataTable();
    private DAL ObjDal = new DAL();
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Status"] != null && Session["Status"].ToString() == "OK")
            {
                
            }
            else {
                Response.Redirect("logout.aspx");
            }
            if (!IsPostBack)
            {
                Session["ShopFund"] = null;
                FillDetail();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
  private void FillDetail()
    {
        try
        {
            Dt = new DataTable();
           
                query = "Sp_GetInvestMentReport '" + Session["formno"] + "' " ;
                Dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, query).Tables[0];
                Session["ShopFund"] = Dt;
            
            if (Dt.Rows.Count > 0)
            {
                RptDirects.DataSource = Dt;
                RptDirects.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
   }
    protected void RptDirects_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string orderNo = drv["billno"].ToString();
            string billNo = drv["billno"].ToString(); // if you still want to append this

            string encoded = Base64Encode(drv["billno"].ToString());
            string col2 = $"<a href='https://capstones.in/Invoice.aspx?orderno={encoded}' target='_blank' class='order-link'>{orderNo}</a>";

            Literal ltlOrderLink = (Literal)e.Item.FindControl("ltlOrderLink");
            ltlOrderLink.Text = col2;
        }
    }
    private static string Base64Encode(string plainText)
    {
        byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }
    protected void RptDirects_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            //RptDirects.PageIndex = e.NewPageIndex;
            FillDetail();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        try
        {
            // Add your code here
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        try
        {
            // Add your code here
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }

}

