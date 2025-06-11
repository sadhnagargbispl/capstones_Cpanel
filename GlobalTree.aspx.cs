using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

public partial class GlobalTree : System.Web.UI.Page
{
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Status"] != null && Session["Status"].ToString() == "OK")
        {
            if (!IsPostBack)
            {
                LoadTree(Session["FormNo"].ToString());
                LoadSelf(Session["FormNo"].ToString());
            }
        }
        else
        {
            Response.Redirect("logout.aspx");
        }
    }

    private void LoadTree(string FormNo)
    {
        try
        {
            string strSql = "Exec Sp_GetTree @FormNo";
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, strSql, new SqlParameter("@FormNo", FormNo)).Tables[0];

            // Convert to list
            List<DownlineItem> allData = dt.AsEnumerable()
                .Select(r => new DownlineItem { FormNoDwn = r["FormNoDwn"].ToString() })
                .ToList();

            // First item as root
            DownlineItem root = null;
            if (allData.Count > 0)
            {
                root = allData[0];
                allData.RemoveAt(0); // Remove root from list
            }

            List<List<DownlineItem>> rows = new List<List<DownlineItem>>();

            // Root row with center placement
            List<DownlineItem> rootRow = new List<DownlineItem>();
            for (int i = 0; i < 10; i++)
            {
                if (i == 4)
                    rootRow.Add(root ?? new DownlineItem { FormNoDwn = "" });
                else
                    rootRow.Add(new DownlineItem { FormNoDwn = "" });
            }
            rows.Add(rootRow);

            // Fill the rest in 10s
            for (int i = 0; i < 110; i += 10)
            {
                var row = allData.Skip(i).Take(10).ToList();
                while (row.Count < 10)
                    row.Add(new DownlineItem { FormNoDwn = "" });

                rows.Add(row);
            }

            Session["DirectDownline"] = dt;

            Grdtotal.DataSource = rows;
            Grdtotal.DataBind();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
        }
    }
    protected void Grdtotal_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater innerRepeater = (Repeater)e.Item.FindControl("InnerRepeater");
            var rowData = (List<DownlineItem>)e.Item.DataItem;
            innerRepeater.DataSource = rowData;
            innerRepeater.DataBind();
        }
    }
    private void LoadSelf(string FormNo)
    {
        try
        {
            string strSql = "Exec Sp_GetTreeSelf @FormNo";
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, strSql, new SqlParameter("@FormNo", FormNo)).Tables[0];

            // Convert to list
            List<SelfDownlineItem> allData = dt.AsEnumerable()
                .Select(r => new SelfDownlineItem { FormNoDwn = r["FormNoDwn"].ToString() })
                .ToList();

            // First item as root
            SelfDownlineItem root = null;
            if (allData.Count > 0)
            {
                root = allData[0];
                allData.RemoveAt(0); // Remove root from list
            }

            List<List<SelfDownlineItem>> rows = new List<List<SelfDownlineItem>>();

            // Root row with center placement
            List<SelfDownlineItem> rootRow = new List<SelfDownlineItem>();
            for (int i = 0; i < 10; i++)
            {
                if (i == 4)
                    rootRow.Add(root ?? new SelfDownlineItem { FormNoDwn = "" });
                else
                    rootRow.Add(new SelfDownlineItem { FormNoDwn = "" });
            }
            rows.Add(rootRow);

            // Fill the rest in 10s
            for (int i = 0; i < 110; i += 10)
            {
                var row = allData.Skip(i).Take(10).ToList();
                while (row.Count < 10)
                    row.Add(new SelfDownlineItem { FormNoDwn = "" });

                rows.Add(row);
            }

            Session["DirectDownline"] = dt;

            RptSelf.DataSource = rows;
            RptSelf.DataBind();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
        }
    }
    protected void RptSelf_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater InnerRepeaterSelf = (Repeater)e.Item.FindControl("InnerRepeaterSelf");
            var rowData = (List<SelfDownlineItem>)e.Item.DataItem;
            InnerRepeaterSelf.DataSource = rowData;
            InnerRepeaterSelf.DataBind();
        }
    }

    protected void BtnSubmit_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
}

public class DownlineItem
{
    public string FormNoDwn { get; set; }
}
public class SelfDownlineItem
{
    public string FormNoDwn { get; set; }
}