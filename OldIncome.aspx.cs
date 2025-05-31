using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OldIncome : System.Web.UI.Page
{
    DAL ObjDal = new DAL();
    string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Status"] != null && Session["Status"].ToString() == "OK")
            {
                //UserStatus.InnerText = "Welcome " + Session["MemName"] + "(" + Session["Formno"] + ")" + Session["Company"] + "";
            }
            else
            {
                Response.Redirect("logout.aspx");
            }
            if (!Page.IsPostBack)
            {
                Fill_Grid();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
    private void Fill_Grid()
    {
        try
        {
            DataTable Dt = new DataTable();
            string str = "";
            str = ObjDal.Isostart + "  Exec sp_GetOldIncome '" + Session["idno"] + "' " + ObjDal.IsoEnd;
            Dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, str).Tables[0];
            if (Dt.Rows.Count > 0)
            {
                DibDateCondition.Visible = true;
                RptDirects.DataSource = Dt;
                RptDirects.DataBind();
              }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void RptDirects_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            RptDirects.PageIndex = e.NewPageIndex;
            Fill_Grid();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('" + ex.Message + "');", true);
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            Session["OldPayout"] = null;
            Fill_Grid();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
