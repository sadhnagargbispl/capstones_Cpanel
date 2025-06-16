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
    string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Status"] != null && (string)Session["Status"] == "OK")
            {
                Fun_Sp_GetGlobalPoolTreeMember();
                BindTreeDataTeam(Session["formno"].ToString());
                BindTreeDataSelf(Session["formno"].ToString());
            }
            else
            {
                Response.Redirect("default.aspx", false);
                return;
            }
        }
    }
    private void Fun_Sp_GetGlobalPoolTreeMember()
    {
        try
        {
            string sql = string.Empty;
            DataTable dt_API_MAster = new DataTable();
            sql = " Exec Sp_GetGlobalPoolTreeMember '" + Session["formno"].ToString() + "' ";
            dt_API_MAster = SqlHelper.ExecuteDataset(constr1, CommandType.Text, sql).Tables[0];
            if (dt_API_MAster.Rows.Count > 0)
            {
                LblTotalEntryInPool.Text = dt_API_MAster.Rows[0]["TotalPoolTreeCount"].ToString();
                LblTodayEntryInPool.Text = dt_API_MAster.Rows[0]["TodayPoolTreeCount"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private void BindTreeDataTeam(string formNo)
    {
        List<List<string>> tableData = new List<List<string>>();
        string rootID = "";
        int totalRows = 0;

        using (SqlConnection con = new SqlConnection(constr1))
        {
            using (SqlCommand cmd = new SqlCommand("Sp_GetTreeT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FormNo", formNo);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Result 1: 110 Downline IDs
                List<string> flatList = new List<string>();
                while (reader.Read())
                {
                    flatList.Add(reader["FormNoDwn"].ToString());
                }

                // Result 2: Root ID
                if (reader.NextResult() && reader.Read())
                {
                    rootID = reader["RootFormNo"].ToString();
                    litRootID.Text = rootID;
                }

                // Result 3: Total rows (usually 11)
                if (reader.NextResult() && reader.Read())
                {
                    totalRows = Convert.ToInt32(reader["TotalRows"]);
                }

                // Build 10x11 grid
                for (int i = 0; i < totalRows; i++)
                {
                    List<string> row = new List<string>();
                    for (int j = 0; j < 10; j++)
                    {
                        int index = i * 10 + j;
                        if (index < flatList.Count)
                            row.Add(flatList[index]);
                        else
                            row.Add("-");
                    }
                    tableData.Add(row);
                }
            }
        }

        rptRows.DataSource = tableData;
        rptRows.DataBind();
    }
    protected void rptRows_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var rowData = (List<string>)e.Item.DataItem;
            Repeater rptCols = (Repeater)e.Item.FindControl("rptCols");
            if (rptCols != null)
            {
                rptCols.DataSource = rowData;
                rptCols.DataBind();
            }
        }
    }
    private void BindTreeDataSelf(string formNo)
    {
        List<List<string>> tableData = new List<List<string>>();
        string rootID = "";
        int totalRows = 0;
        using (SqlConnection con = new SqlConnection(constr1))
        {
            using (SqlCommand cmd = new SqlCommand("Sp_GetTreeSelfT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FormNo", formNo);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                // Result 1: 110 Downline IDs
                List<string> flatList = new List<string>();
                while (reader.Read())
                {
                    flatList.Add(reader["FormNoDwn"].ToString());
                }
                // Result 2: Root ID
                if (reader.NextResult() && reader.Read())
                {
                    rootID = reader["RootFormNo"].ToString();
                    litRootID1.Text = rootID;
                }

                // Result 3: Total rows (usually 11)
                if (reader.NextResult() && reader.Read())
                {
                    totalRows = Convert.ToInt32(reader["TotalRows"]);
                }

                // Build 10x11 grid
                for (int i = 0; i < totalRows; i++)
                {
                    List<string> row = new List<string>();
                    for (int j = 0; j < 10; j++)
                    {
                        int index = i * 10 + j;
                        if (index < flatList.Count)
                            row.Add(flatList[index]);
                        else
                            row.Add("-");
                    }
                    tableData.Add(row);
                }
            }
        }

        RptMemberselfTree.DataSource = tableData;
        RptMemberselfTree.DataBind();
    }
    protected void RptMemberselfTree_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var rowData = (List<string>)e.Item.DataItem;
            Repeater rptColsMemberselfTree = (Repeater)e.Item.FindControl("rptColsMemberselfTree");
            if (rptColsMemberselfTree != null)
            {
                rptColsMemberselfTree.DataSource = rowData;
                rptColsMemberselfTree.DataBind();
            }
        }
    }
}
