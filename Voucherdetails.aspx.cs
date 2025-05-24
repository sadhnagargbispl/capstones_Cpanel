using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;

public partial class Voucherdetails : System.Web.UI.Page
{
    string scrName;
    DAL objDal = new DAL();
    DataTable Dt = new DataTable();
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Status"] != null && Session["Status"].ToString() == "OK")
        {

            if (!Page.IsPostBack)
            {
                FillCounpon();
            }
        }
        else
        {
            Response.Redirect("logout.aspx");
        }
    }
    protected void FillCounpon()
    {
        try
        {
            string query = "";
            DataTable dt;
            dt = new DataTable();
            //query = objDal.Isostart + "Exec sp_GetFormWiseCouponByCoupon '" + Session["Formno"] + "'" + objDal.IsoEnd;
            query = "Exec sp_GetFormWiseCouponByCoupon '" + Session["FormNo"] + "','" + Request.QueryString["VNo"] + "',";
            query += "'" + Request.QueryString["kID"] + "','" + Session["DOA"] + "','" + Request.QueryString["ID"] + "'";

            dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, query).Tables[0];

            if (dt.Rows.Count > 0)
            {
                RepVouDetail.DataSource = dt;
                RepVouDetail.DataBind();
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            string path = HttpContext.Current.Request.Url.AbsoluteUri;
            string text = path + ":  " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss:fff ") + Environment.NewLine;
            objDal.WriteToFile(text + ex.Message);
            Response.Write("Try later.");
        }
    }

    protected void RepVouDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "USED")
        {
            string str = "Exec Sp_InsertMemberCouponShopPointUpdate 'Insert','" + Session["FormNo"] + "','" + Request.QueryString["kID"] + "',";
            str += "'" + Request.QueryString["VNo"] + "','" + Session["DOA"] + "','" + Request.QueryString["ID"] + "'";

            int x = Convert.ToInt32(SqlHelper.ExecuteNonQuery(
                constr,
                CommandType.Text,
                str));

            if (x > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Thank You! Your amount will be credited in your redemption wallet.');location.replace('Voucher.aspx');", true);
            }
        }

        if (e.CommandName == "CANCEL")
        {
            string str = "Exec Sp_InsertMemberCouponShopPointUpdate 'Cancel','" + Session["FormNo"] + "','" + Request.QueryString["kID"] + "',";
            str += "'" + Request.QueryString["VNo"] + "','" + Session["DOA"] + "','" + Request.QueryString["ID"] + "'";

            int x = Convert.ToInt32(SqlHelper.ExecuteNonQuery(
                constr,
                CommandType.Text,
                str));

            if (x > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Thank You! Your amount will be credited in your main wallet.');location.replace('Voucher.aspx');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('You cannot cancel the same coupon.!');", true);
                // Uncomment if needed:
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('You are not authorized for the cancellation.!');", true);
            }
        }
    }
}
