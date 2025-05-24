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
public partial class Voucher : System.Web.UI.Page
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
            query = objDal.Isostart + "Exec sp_GetFormWiseCoupon '" + Session["Formno"] + "'" + objDal.IsoEnd;
            dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, query).Tables[0];

            if (dt.Rows.Count > 0)
            {
                RptCOupon.DataSource = dt;
                RptCOupon.DataBind();
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
}
