using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UniversalTree : System.Web.UI.Page
{
    DAL ObjDal = new DAL();
    string IsoStart;
    string IsoEnd;
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Status"] != null && Session["Status"].ToString() == "OK")
        {
            if (!Page.IsPostBack)
            {
                Fill_PoolType();
                string scrname = "";
                // string DownFormNo = get_FormNo(DownLineFormNo.Value);
                string DownFormNo = "";
                TreeFrame.Attributes["src"] = "UniTree.aspx?type=" + ddllist.SelectedValue + "&DownLineFormNo=" + DownFormNo + " ";
                // Response.Redirect("UniTree.aspx?type=" + ddllist.SelectedValue + "&DownLineFormNo=" + DownFormNo + " ");
            }
        }
        else
        {
            Response.Redirect("logout.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string scrname = "";
        // string DownFormNo = get_FormNo(DownLineFormNo.Value);
        string DownFormNo = "";

        if (DownFormNo != "")
        {
            TreeFrame.Attributes["src"] = "UniTree.aspx?type=" + ddllist.SelectedValue + "&DownLineFormNo=" + DownFormNo + " ";
            // Response.Redirect("UniTree.aspx?type=" + ddllist.SelectedValue + "&DownLineFormNo=" + DownFormNo + " ");
        }
        else if (DownFormNo == "")
        {
            TreeFrame.Attributes["src"] = "UniTree.aspx?type=" + ddllist.SelectedValue + "&DownLineFormNo=" + DownFormNo + " ";
            // Response.Redirect("UniTree.aspx?type=" + ddllist.SelectedValue + "&DownLineFormNo=" + DownFormNo + " ");
        }
        else
        {
            // Optional else block
        }
    }

    private void Fill_PoolType()
    {
        try
        {
            DataTable dt = new DataTable();
            string str = IsoStart + " Exec Sp_GetSelectPoolTable " + IsoEnd;

            dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, str).Tables[0];

            if (dt.Rows.Count > 0)
            {
                ddllist.DataSource = dt;
                ddllist.DataTextField = "PoolName";
                ddllist.DataValueField = "Rid";
                ddllist.DataBind();
            }
        }
        catch (Exception ex)
        {
            // Handle exception if needed
        }
    }

    protected void cmdBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    private string get_FormNo(string IDNo)
    {
        string FormNo = "";
        try
        {
            string str = "";
            DataTable dt = new DataTable();

            str = IsoStart + "Select FormNo From " + ObjDal.dBName + "..M_MemberMaster Where IDNo='" + IDNo + "'" + IsoEnd;
            dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, str).Tables[0];

            if (dt.Rows.Count > 0)
            {
                FormNo = dt.Rows[0]["FormNo"].ToString();
            }
        }
        catch (Exception ex)
        {
            // Handle exception if needed
        }

        return FormNo;
    }
}