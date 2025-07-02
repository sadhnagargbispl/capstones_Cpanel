using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Invoice : System.Web.UI.Page
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
                if (!Page.IsPostBack)
                {
                    if (Request["orderno"] != null)
                    {
                        string OrderNo = Base64Decode(Request["orderno"]);
                        Fill_Invoice(OrderNo);
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }

    }
    private void Fill_Invoice(string OrderNo)
    {
        try
        {
            string str = "EXEC Sp_ShowInvoice '" + Session["FormNo"] + "','" + OrderNo + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, str);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                LblDate.Text = dt.Rows[0]["orderdate"].ToString();
                LblOderNo.Text = dt.Rows[0]["OrderNo"].ToString();
                LblID.Text = dt.Rows[0]["idno"].ToString();
                LblName.Text = dt.Rows[0]["Name"].ToString();
                LblMobileNo.Text = dt.Rows[0]["mobl"].ToString();
                LblAddress.Text = dt.Rows[0]["Addresss"].ToString();
                LblTOtalAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
            }
        }
        catch (Exception ex)
        {
            // Optionally log the error
        }
    }
    private string Base64Decode(string base64EncodedData)
    {
        byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}