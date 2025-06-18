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
    protected string RootFormNo = "";
    protected string ShowTopRow = "N";
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
        using (SqlConnection con = new SqlConnection(constr1))
        {
            using (SqlCommand cmd = new SqlCommand("Sp_GetTreeT", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FormNo", SqlDbType.VarChar).Value = formNo;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rptTreeGrid.DataSource = ds.Tables[0];
                    rptTreeGrid.DataBind();
                }
                // Root row check
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    string root = ds.Tables[1].Rows[0]["RootFormNo"].ToString();
                    if (!string.IsNullOrWhiteSpace(root))
                    {
                        RootFormNo = root;
                        ShowTopRow = "Y";
                    }
                }
            }
        }
    }
    private void BindTreeDataSelf(string formNo)
    {
        using (SqlConnection con = new SqlConnection(constr1))
        {
            using (SqlCommand cmd = new SqlCommand("Sp_GetTreeTSelf", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FormNo", SqlDbType.VarChar).Value = formNo;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    RptSlefTree.DataSource = ds.Tables[0];
                    RptSlefTree.DataBind();
                }
                // Root row check
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    string root = ds.Tables[1].Rows[0]["RootFormNo"].ToString();
                    if (!string.IsNullOrWhiteSpace(root))
                    {
                        RootFormNo = root;
                        ShowTopRow = "Y";
                    }
                }
            }
        }
    }
}
