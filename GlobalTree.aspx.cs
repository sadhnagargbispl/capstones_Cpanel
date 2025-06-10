using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class GlobalTree : System.Web.UI.Page
{
    SqlConnection Conn;
    SqlCommand Comm;
    DataSet Ds = new DataSet();
    SqlDataAdapter Ad;
    DAL ObjDal = new DAL();
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string IsoStart;
    string IsoEnd;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Status"] != null && Session["Status"].ToString() == "OK")
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadDownline(Session["FormNo"].ToString());
                }
            }
            catch (Exception ex)
            {
                string path = HttpContext.Current.Request.Url.AbsoluteUri;
                string text = path + " (Page_Load):   " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss:fff") + Environment.NewLine;
                ObjDal.WriteToFile(text + ex.Message);
                Response.Write("Try later.");
            }
        }
        else
        {
            Response.Redirect("logout.aspx");
        }
    }

    private void LoadDownline(string FormNo)
    {
        try
        {
            // Fetch data from stored procedure
            string strSql = "Exec Sp_GetTree @FormNo";
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, strSql, new SqlParameter("@FormNo", FormNo)).Tables[0];

            // Group data into rows of 10
            List<List<DownlineItem>> rows = new List<List<DownlineItem>>();
            for (int i = 0; i < dt.Rows.Count; i += 10)
            {
                var row = dt.AsEnumerable()
                            .Skip(i)
                            .Take(10)
                            .Select(r => new DownlineItem { FormNoDwn = r["FormNoDwn"].ToString() })
                            .ToList();
                if (row.Count > 0)
                {
                    // Pad the row with empty cells if fewer than 10
                    while (row.Count < 10)
                    {
                        row.Add(new DownlineItem { FormNoDwn = "" });
                    }
                    rows.Add(row);
                }
            }

            // Pad with empty rows if fewer than 10 rows
            while (rows.Count < 10)
            {
                var emptyRow = new List<DownlineItem>();
                for (int i = 0; i < 10; i++)
                {
                    emptyRow.Add(new DownlineItem { FormNoDwn = "" });
                }
                rows.Add(emptyRow);
            }

            // Store original DataTable in Session (if needed)
            Session["DirectDownline"] = dt;

            // Bind grouped data to the outer Repeater
            Grdtotal.DataSource = rows;
            Grdtotal.DataBind();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", $"alert('Error: {ex.Message}');", true);
        }
    }
    protected void Grdtotal_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Find the inner Repeater
            Repeater innerRepeater = (Repeater)e.Item.FindControl("InnerRepeater");

            // Bind the inner Repeater to the row's data (10 columns)
            var rowData = (List<DownlineItem>)e.Item.DataItem;
            innerRepeater.DataSource = rowData;
            innerRepeater.DataBind();
        }
    }
}
public class DownlineItem
{
    public string FormNoDwn { get; set; }
}