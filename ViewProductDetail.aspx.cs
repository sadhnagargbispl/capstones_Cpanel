using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProductDetail : System.Web.UI.Page
{
    string strquery;
    DataTable dt;
    clsGeneral objGen = new clsGeneral();
    DataTable dtData = new DataTable();
    DAL objDal = new DAL();
    
    ModuleFunction objModuleFun;
    string ReqNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        string scrname;
     
        if (!string.IsNullOrEmpty(Request["ReqNo"]))
        {
            ReqNo = Request["ReqNo"];
        }

        if (!Page.IsPostBack)
        {
            if (Session["Status"] != null && Session["Status"].ToString() == "OK")
            {
                if (!string.IsNullOrEmpty(Request["ReqNo"]))
                {
                    LblNo.Text = " Order No :" + ReqNo;
                    BindData();
                }
            }
            else
            {
                scrname = "<SCRIPT language='javascript'> window.top.location.reload();</SCRIPT>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Close", scrname, false);
            }
        }
    }
    public void BindData(string SrchCond = "")
    {
        try
        {
            string sql;  
                sql = "select *, (Rate * Qty) as TotalAmount from TrnorderDetail " +
                      "where Convert(varchar, Orderno) = '" + Request["ReqNo"] + "' " +
                      "and Formno = '" + Session["Formno"] + "' and Qty <> 0 and NetAmount > 0";
          
            dtData = new DataTable();
            dtData = objDal.GetData(sql);

            
                if (dtData.Rows.Count > 0)
                {
                    GvData.DataSource = dtData;
                    GvData.DataBind();
                    Session["GData"] = dtData;
                    gvdatagenesis.Visible = false;
                }
                else
                {
                    sql = "select *, (Rate * Qty) as TotalAmount from trnbillDetails where Convert(varchar, BillNo) = '" + Request["ReqNo"] + "' " +
                          "and Formno = '" + Session["Formno"] + "' and Qty <> 0 and NetAmount > 0";
                    dtData = objDal.GetData(sql);
                    GvData.DataSource = dtData;
                    GvData.DataBind();
                    Session["GData"] = dtData;
                    gvdatagenesis.Visible = false;
                }
        }
        catch (Exception ex)
        {
            // Handle exception (consider logging it)
        }
    }

    protected void gvdatagenesis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvData.PageIndex = e.NewPageIndex;
        GvData.DataSource = Session["GData"];
        GvData.DataBind();
    }
}
