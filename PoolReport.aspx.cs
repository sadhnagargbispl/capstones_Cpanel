using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class PoolReport : System.Web.UI.Page
{
    DataSet Ds;
    SqlConnection conn = new SqlConnection();
    SqlCommand Comm = new SqlCommand();
    SqlDataAdapter Adp;
    DAL ObjDal = new DAL();
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
    private SqlConnection cnn;
    DataTable Dt = new DataTable();
    string IsoStart;
    string IsoEnd;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Status"] != null)
            {
                if (!Page.IsPostBack)
                {
                    Session["DirDel"] = null;
                    Session["DirDelCount"] = null;
                    FillLevel();
                    string strQuery = "";
                    DataTable tmpTable = new DataTable();
                }
            }
            else
            {
                Response.Redirect("logout.aspx");
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
    protected void FillLevel()
    {
        try
        {
            Ds = SqlHelper.ExecuteDataset(constr1, "Sp_GetSelectPoolTable");
            rbtnsearch.DataSource = Ds.Tables[0];
            rbtnsearch.DataTextField = "PoolName";
            rbtnsearch.DataValueField = "Rid";
            rbtnsearch.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private void FillData()
    {
        try
        {
            DataTable dt = new DataTable();
            DataSet Ds = new DataSet();
            string strSql = ObjDal.Isostart + "Exec Sp_GetSelectPoolTableDetail " + rbtnsearch.SelectedValue + " " + ObjDal.IsoEnd;
            Ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = Ds.Tables[0];
            RptDirects.DataSource = dt;
            RptDirects.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        try
        {
            this.FillData();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = int.Parse(((LinkButton)sender).CommandArgument);
            FillData();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Session["DirDel"] = null;
            Session["DirDelCount"] = null;
            FillData();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }

    protected void RptDirects_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            RptDirects.PageIndex = e.NewPageIndex;
            FillData();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }

    }
}
