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

public partial class MyDirects : System.Web.UI.Page
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
                    DdlLevel.SelectedValue = "0";
                    LevelDetail(1);
                    FillData();
                    string strQuery = "";
                    DataTable tmpTable = new DataTable();
                    //strQuery = IsoStart + "Exec Sp_GetRegistration '" + txtRefralId.Text.Replace("WP", "") + "'" + IsoEnd;
                    //string prefix = Session["Idno"].ToString().Substring(0, 1); // "D" or "A"
                    //string referralIdWithoutPrefix = Session["Idno"].ToString().Substring(1); // Remove first character

                    //strQuery = IsoStart + "Exec Sp_GetRegistrationClient '" + referralIdWithoutPrefix + "'" + IsoEnd;

                    //tmpTable = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strQuery).Tables[0];

                    //if (tmpTable.Rows.Count > 0)
                    //{
                    //    if (Convert.ToInt32(tmpTable.Rows[0]["Cnt"]) > 0)
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('You Are Not Access This Page.Please Contact To Admin.!');location.replace('index.aspx');", true);
                    //        return;
                    //    }
                    //}
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
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = new SqlParameter("@FormNo", Session["FormNo"]);
            prms[1] = new SqlParameter("@type", "N");

            Ds = SqlHelper.ExecuteDataset(constr1, "sp_GetLevel", prms);
            DdlLevel.DataSource = Ds.Tables[0];
            DdlLevel.DataTextField = "LevelName";
            DdlLevel.DataValueField = "MLevel";
            DdlLevel.DataBind();
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
            this.LevelDetail(1);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
    public void LevelDetail(int pageIndex)
    {
        try
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            if (Session["DirDel"] == null)
            {
                string legno = "";
                string level = "";
                string rank = "";
                if (rbtnsearch.SelectedValue == "L")
                {
                    legno = "0";
                    level = DdlLevel.SelectedValue;
                    rank = "0";
                }
                else
                {
                    legno = rbtnsearch.SelectedValue;
                    level = "1";
                    rank = "0";
                }

                SqlParameter[] prms = new SqlParameter[7];
                prms[0] = new SqlParameter("@MLevel", level);
                prms[1] = new SqlParameter("@Legno", legno);
                prms[2] = new SqlParameter("@ActiveStatus", DDlSearchby.SelectedValue);
                prms[3] = new SqlParameter("@FormNo", Session["FormNo"]);
                //prms[4] = new SqlParameter("@Rank", rank);
                prms[4] = new SqlParameter("@PageIndex", pageIndex);
                prms[5] = new SqlParameter("@PageSize", 150000000);
                prms[6] = new SqlParameter("@RecordCount", SqlDbType.Int);
                prms[6].Direction = ParameterDirection.Output;

                Ds = SqlHelper.ExecuteDataset(constr1, "sp_GetLevelDetail", prms);
                dt = Ds.Tables[0];
                Session["DirDel"] = dt;

                dt1 = Ds.Tables[1];
                Session["DirDelCount"] = dt1;
            }
            else
            {
                dt = (DataTable)Session["DirDel"];
                dt1 = (DataTable)Session["DirDelCount"];
            }

            if (dt1.Rows.Count > 0)
            {
                RptDirects.DataSource = dt;
                RptDirects.DataBind();
                int recordCount = dt.Rows.Count;
                lbltotal.Text = recordCount.ToString();
            }
            else
            {
                RptDirects.DataSource = dt;
                RptDirects.DataBind();
                int recordCount = 0;
                lbltotal.Text = recordCount.ToString();
            }
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
            string strSql = ObjDal.Isostart + " Select * from V#ReferalDownlineinfo where Formno=" + Session["FormNo"] + " " + ObjDal.IsoEnd ;
            Ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, strSql);
            dt = Ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                tdDirectleft.InnerText = dt.Rows[0]["RegisterLeft"].ToString();
                tdDirectright.InnerText = dt.Rows[0]["RegisterRight"].ToString();
                TotalDirect.InnerText = (Convert.ToInt32(dt.Rows[0]["RegisterLeft"]) + Convert.ToInt32(dt.Rows[0]["RegisterRight"])).ToString();
                tddirectActive.InnerText = dt.Rows[0]["ConfirmLeft"].ToString();
                tdindirectActive.InnerText = dt.Rows[0]["ConfirmRight"].ToString();
                TotalActive.InnerText = (Convert.ToInt32(dt.Rows[0]["ConfirmLeft"]) + Convert.ToInt32(dt.Rows[0]["ConfirmRight"])).ToString();
                Directunit.InnerText = dt.Rows[0]["LeftBv"].ToString();
                indirectunit.InnerText = dt.Rows[0]["RightBv"].ToString();
                totalunit.InnerText = (Convert.ToDouble(dt.Rows[0]["LeftBv"]) + Convert.ToDouble(dt.Rows[0]["RightBv"])).ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        try
        {
            int pageIndex = int.Parse(((LinkButton)sender).CommandArgument);
            LevelDetail(pageIndex);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }

    protected void DdlLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Handle DdlLevel_SelectedIndexChanged event
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Session["DirDel"] = null;
            Session["DirDelCount"] = null;
            LevelDetail(1);
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
            LevelDetail(1);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }

    }
    protected void rbtnsearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbtnsearch.SelectedValue == "L")
            {
                lbllevel.Visible = true;
            }
            else
            {
                lbllevel.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
}
