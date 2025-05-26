using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductRequestDetail : System.Web.UI.Page
{
    string strquery;
    DataTable dt;
    clsGeneral objGen = new clsGeneral();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Status"] != null && Session["Status"].ToString() == "OK")
        {
            if (!Page.IsPostBack)
            {
                PaymentDetails();
            }
        }
        else
        {
            Response.Redirect("Logout.aspx");
        }
    }
    private void PaymentDetails()
    {
        try
        {
            DataTable dt = new DataTable();
            string col = "";
            string col2 = "";
            string col9 = "";
            DAL obj = new DAL();
            string Condition = "";
            strquery = "Sp_MyPurchaseDetail '" + Convert.ToInt32(Session["Formno"]).ToString() + "'";
            dt = obj.GetData(strquery);
            if (dt.Rows.Count > 0)
            {

                //if (!dt.Columns.Contains("DebugCol"))
                //{
                //    dt.Columns.Add("DebugCol", typeof(string));
                //}

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Status"].ToString() == "Dispatched")
                    {
                        string url = string.Empty;
                        string tempProtocol = HttpContext.Current.Request.Url.AbsoluteUri;
                        url = (tempProtocol.StartsWith("http://") ? "http://" : "https://") + HttpContext.Current.Request.Url.Host.ToUpper()
                            .Replace("HTTP://", "HTTP://").Replace("HTTPS://", "HTTP://").Replace("WWW.", "").Replace("BASICMLM.", "")
                            .Replace("CPANEL.", "franchise.").Replace("LOGIN.", "franchise.");
                        url = url.ToLower().Replace("https://", "http://");
                        //col2 = $"<a href=\"https://franchise.capstones.in/Invoice/DownloadPdf?Pm={Base64Encode(dr["Orderno"].ToString())}&id={Session["IDNo"]}\" target=\"_blank\" style=\"color:blue\">{dr["OrderNo"]}</a>";
                        col2 = "<a href=\"" + HttpUtility.HtmlEncode("https://franchise.capstones.in/Invoice/DownloadPdf?Pm=" +
                  Base64Encode(dr["Orderno"].ToString()) +
                  "&id=" + Session["IDNo"]) +
                  "\" target=\"_blank\" style=\"color:blue\">" +
                  dr["OrderNo"] + "</a>";
                    }
                    else {
                        col2 = "<a href=\"ViewProductDetail.aspx?&ReqNo=" + dr["Orderno"] + "\" " +
                        "onclick=\"return hs.htmlExpand(this, { objectType: 'iframe', width: 530, height: 430, marginTop: 0 })\" " +
                        "style=\"color:blue\">" + dr["OrderNo"] + "</a>";
                    }

                    dr["Orderno"] = col2;
                    col9 = $"<a href='{dr["Website"]}' style=\"color :Blue\" target=\"_blank\">Track Docket</a>";
                    dr["Website"] = col9;
                }
            }
            RptDirects.DataSource = dt;
            RptDirects.DataBind();
            RptDirects.Visible = true;
            Session["ReceivedPin"] = dt;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + "SideB");
        }
    }
    public static string Base64Encode(string plainText)
    {
        byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EncodedData)
    {
        byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

}
