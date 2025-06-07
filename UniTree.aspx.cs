using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UniTree : System.Web.UI.Page
{
    string strQuery;
    int minDeptLevel;
    SqlConnection conn = new SqlConnection();
    SqlCommand Comm = new SqlCommand();
    SqlDataAdapter Adp1;
    DataSet dsGetQry = new DataSet();
    string strDrawKit;
    string sql;
    DataTable Dt;
    DAL ObjDal = new DAL();
    string IsoStart;
    string IsoEnd;
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Status"] != null && Session["Status"].ToString() == "OK")
            {
                conn = new SqlConnection(Application["Connect"].ToString());
                conn.Open();

                if (!Page.IsPostBack)
                {
                    ValidateTree();
                }
            }
            else
            {
                Response.Redirect("logout.aspx");
            }
        }
        catch (Exception ex)
        {
            // Optionally log ex
        }

    }
    private void ValidateTree()
    {
        try
        {
            Session["Ttype"] = Request["type"];
            string strSelectedFormNo = "";
            minDeptLevel = 3;

            if (Convert.ToString(Session["FormNO"]) == "" || Request["DownLineFormNo"] == "")
            {
                if (Session["Ttype"] != null)
                {
                    DataTable dt = new DataTable();
                    DataSet Ds = new DataSet();
                    string strSql = ObjDal.Isostart + "Exec Sp_GetSelectPoolTableDetailPol " + Session["Ttype"] + " " + ObjDal.IsoEnd;
                    Ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
                    dt = Ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        sql = IsoStart + " Select Top 1 FormNo From " + ObjDal.dBName + ".." + dt.Rows[0]["TableName"] + " Where Formno = '" + Session["FormNo"] + "' " + IsoEnd;
                        Dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, sql).Tables[0];
                        if (Dt.Rows.Count > 0)
                        {
                            strSelectedFormNo = Dt.Rows[0]["FormNo"].ToString();
                        }
                    }
                }
            }
            else
            {
                if (!CheckDownLineMemberTree())
                {
                    Response.Write("Please Check DownLine Member ID");
                    Response.End();
                }

                strSelectedFormNo = Request["DownLineFormNo"];
            }

            if (!string.IsNullOrEmpty(strSelectedFormNo))
            {
                strQuery = getQuery(strSelectedFormNo, minDeptLevel);
                GenerateTree(strQuery);
            }
        }
        catch (Exception ex)
        {
            // Optionally log the exception
        }
    }
    private bool CheckDownLineMemberTree()
    {
        try
        {
            string Tblname2 = "";
            string TblName = "";
            if (Session["Ttype"] != null)
            {
                DataTable dt = new DataTable();
                DataSet Ds = new DataSet();
                string strSql = ObjDal.Isostart + "Exec Sp_GetSelectPoolTableDetailPol " + Session["Ttype"] + " " + ObjDal.IsoEnd;
                Ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
                dt = Ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    TblName = dt.Rows[0]["PoolTableName"].ToString();
                    Tblname2 = dt.Rows[0]["TableName"].ToString();
                }
            }
            //if (Session["Ttype"] != null && Session["Ttype"].ToString() == "A")
            //{
            //    TblName = "M_PoolTreeRelation";
            //    Tblname2 = "MstPool";
            //}
            //else if (Session["Ttype"] != null && Session["Ttype"].ToString() == "B")
            //{
            //    TblName = "M_Pool1TreeRelation";
            //    Tblname2 = "MstPool1";
            //}
            //else if (Session["Ttype"] != null && Session["Ttype"].ToString() == "C")
            //{
            //    TblName = "M_Pool2TreeRelation";
            //    Tblname2 = "MstPool2";
            //}
            //else if (Session["Ttype"] != null && Session["Ttype"].ToString() == "D")
            //{
            //    TblName = "M_Pool3TreeRelation";
            //    Tblname2 = "MstPool3";
            //}
            string formNo = Convert.ToString(Session["FORMNO"]);
            string downLineFormNo = Request["DownLineFormNo"];

            string strQuery = IsoStart + " Select FormnoDwn FROM " + ObjDal.dBName + ".." + TblName + " WHERE FormNoDwn = " + downLineFormNo +
                " AND FormNo = (Select Top 1 FormNo From " + ObjDal.dBName + ".." + Tblname2 + " Where MFormNo = '" + formNo + "')" + IsoEnd;
            DataSet ds1 = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strQuery);
           bool result = ds1.Tables[0].Rows.Count > 0;
            ds1.Dispose();
            return result;
        }
        catch (Exception ex)
        {
            // Optionally log the exception
            return false;
        }
    }
    private string getQuery(string strSelectedFormNo, int minDeptLevel)
    {
        try
        {
            string query = "";

            if (Session["Ttype"] != null)
            {
                query = "exec sp_Pool_Tree " + Session["Ttype"] + "," + strSelectedFormNo + "," + minDeptLevel;
            }
            return query;
        }
        catch (Exception ex)
        {
            // Optionally log the error
            return string.Empty;
        }
    }
    private string ToolTipTable()
    {
        string strToolTip = string.Empty;
        return strToolTip;
    }

    private void GenerateTree(string strQuery)
    {
        try
        {
            DataSet ds1 = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strQuery);
            double ParentId;
            double FormNo;
            string MemberName;
            string LegNo;
            string Doj = "";
            string Category = "";
            double LeftBV, RightBV;
            double LeftJoining, RightJoining;
            string UpLiner, Sponsor, MemId;
            int level, CurrentLevel;
            string NodeName;
            string myRunTimeString = "";
            string ExpandYesNo;
            string strImageFile;
            string strUrlPath = "";
            string upgradeDt, IMECode, LevelDate;
            string tooltipstrig;
            myRunTimeString += "<Script Language=Javascript>\n";
            tooltipstrig = ToolTipTable(); // You must implement this
            ParentId = -1;
            if (!string.IsNullOrEmpty(Request["DownLineFormNo"]))
                FormNo = Convert.ToDouble(Request["DownLineFormNo"]);
            else
                FormNo = Convert.ToDouble(Session["FormNo"].ToString());
            strImageFile = "img/base.jpg";
            int i = 0;
            int LoopValue;
            string FolderFile = "img/Deactivate.jpg";

            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                strImageFile = "img/" + dr["JoinColor"].ToString();

                if (i == 0)
                {
                    myRunTimeString += "mytree = new dTree('mytree','" + strImageFile + "');\n";
                    i++;
                }

                ParentId = Convert.ToDouble(dr["UPLNFORMNO"]);
                FormNo = Convert.ToDouble(dr["FormNoDwn"]);
                LegNo = dr["legno"].ToString();
                UpLiner = dr["UpLiner"].ToString();
                Sponsor = dr["Sponsor"].ToString();
                Doj = dr["doj"].ToString();
                Category = dr["Category"].ToString();
                LeftBV = Convert.ToDouble(dr["LeftBV"]);
                RightBV = Convert.ToDouble(dr["bv"]);
                LeftJoining = Convert.ToDouble(dr["leftbusiness"]);
                RightJoining = Convert.ToDouble(dr["rightbusiness"]);
                level = Convert.ToInt32(dr["level"]);
                IMECode = dr["IMECode"].ToString();
                strUrlPath = "UniTree.aspx?DownLineFormNo=" + FormNo;
                upgradeDt = dr["UpDt"].ToString();
                LevelDate = dr["LevelDate"].ToString();
                CurrentLevel = Convert.ToInt32(dr["CurrentLevel"]);
                MemId = dr["FormNo"].ToString();
                //string sql = "Exec Sp_GetAchieveDetail '" + Session["formno"] + "','" + Session["Ttype"] + "'";
                //DataTable Dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, sql).Tables[0];
                //if (Dt.Rows.Count > 0 && Session["idno"].ToString() == dr["Formno"].ToString())
                //    MemberName = dr["Formno"] + " <b> - Achieved</b><br />(" + dr["memName"] + ")";
                //else
                    MemberName = dr["Formno"] + "<br />(" + dr["memName"] + ")";
                NodeName = dr["memName"].ToString();
                LoopValue = Convert.ToInt32(dr["mlevel"]);
                ExpandYesNo = (LoopValue < 4 && LoopValue > 0) || ParentId == -1 ? "true" : "false";
                if (upgradeDt == "01 Jan 00")
                    upgradeDt = "";
                if (FormNo <= 0)
                {
                    strUrlPath = "";
                    MemberName = LegNo == "1" ? "A" : LegNo == "2" ? "B" : "C";
                }
                else
                {
                    switch (dr["Kitid"].ToString())
                    {
                        case "1": strImageFile = "img/Red.jpg"; break;
                        case "2": strImageFile = "img/Blue.jpg"; break;
                        case "3": strImageFile = "img/Green.jpg"; break;
                        case "4": strImageFile = "img/Yellow.jpg"; break;
                        case "5": strImageFile = "img/Orange.jpg"; break;
                        case "6": strImageFile = "img/purpel.jpg"; break;
                        default: strImageFile = dr["ActiveStatus"].ToString() == "N" ? "img/deact.jpg" : "img/empty.jpg"; break;
                    }

                    strUrlPath = "UniTree.aspx?type=" + Request["type"] + "&DownLineFormNo=" + FormNo + " ";
                }

                strImageFile = "img/" + dr["JoinColor"];
                myRunTimeString += " mytree.add(" + FormNo + "," + ParentId + ",'" + Category + "','" + Doj + "','" +
                                    MemberName + "','" + NodeName + "','" + UpLiner + "','" + Sponsor + "'," +
                                    LeftBV + "," + RightBV + ",'" + strUrlPath + "','" + MemberName + "','','" +
                                    strImageFile + "','" + strImageFile + "'," + ExpandYesNo + ",'" +
                                    LeftJoining + "','" + RightJoining + "','" + level + "','" +
                                    MemId + "','" + LevelDate + "','" + CurrentLevel + "');\n";
            }

            myRunTimeString += "\n\n\n\n document.write(mytree);\n";
            myRunTimeString += "</script><br /><br /><br /><br />";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", myRunTimeString);
        }
        catch (Exception)
        {
            // Optional: log error
        }
    }
}