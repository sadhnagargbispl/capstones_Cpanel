using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class Referaltree : System.Web.UI.Page
{
    string strQuery;
    int minDeptLevel;
    SqlConnection Cnn = new SqlConnection();
    SqlCommand Comm = new SqlCommand();
    SqlDataAdapter Adp1;
    DataSet dsGetQry = new DataSet();
    DAL Obj = new DAL();
    string strToolTip;
    string strDrawKit;
    string IsoStart;
    string IsoEnd;

    private string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
    private string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr1"].ConnectionString);

            if (!IsPostBack)
            {
                if (Session["Status"] != null && Session["Status"].ToString() == "OK")
                {
                    string strQuery = "";
                    DataTable tmpTable = new DataTable();
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

                    ValidateTree();
                   
                }
                else
                {
                    Response.Redirect("Logout.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            if (Cnn.State == ConnectionState.Open)
            {
                Cnn.Close();
            }

            string path = HttpContext.Current.Request.Url.AbsoluteUri;
            string text = path + ":  " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss:fff") + Environment.NewLine;
            Obj.WriteToFile(text + ex.Message);
            Response.Write("Try later.");
        }
    }
    private void ValidateTree()
    {
        try
        {
            string strSelectedFormNo;
            int minDeptLevel;

            // If User Not Set MinDept level, then set 1 as the default
            if (string.IsNullOrEmpty(Request["DeptLevel"]))
            {
                minDeptLevel = 1;
            }
            else
            {
                minDeptLevel = 1; // Explicitly setting to 1 in both cases
            }

            if (string.IsNullOrEmpty(Session["FormNo"].ToString()) || string.IsNullOrEmpty(Request["DownLineFormNo"]) || Request["DownLineFormNo"] == "123456")
            {
                strSelectedFormNo = Session["FormNo"].ToString();
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

            string strQuery = getQuery(strSelectedFormNo, minDeptLevel);
            GenerateTree(strQuery);
        }
        catch (Exception ex)
        {
            string path = HttpContext.Current.Request.Url.AbsoluteUri;
            string text = path + ":  " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss:fff") + Environment.NewLine;
            Obj.WriteToFile(text + ex.Message);
            Response.Write("Try later.");
        }
    }

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        if (!Page.IsPostBack)
    //        {
    //            if (Session["Status"] != null && (string)Session["Status"] == "OK")
    //            {
    //                ValidateTree();
    //            }
    //            else
    //            {
    //                Response.Redirect("Logout.aspx");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        if (Cnn.State == ConnectionState.Open)
    //        {
    //            Cnn.Close();
    //        }
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
    //    }
    //}

    //private void ValidateTree()
    //{
    //    try
    //    {
    //        string strSelectedFormNo;
    //        if (Request["DeptLevel"] == "")
    //        {
    //            minDeptLevel = 3;
    //        }
    //        else
    //        {
    //            minDeptLevel = 3;
    //        }

    //        if ((System.Convert.ToString(Session["FormNo"]) == "" || (Request["DownLineFormNo"]) == null || Request["DownLineFormNo"] == "123456"))
    //            strSelectedFormNo = Session["FormNo"].ToString();
    //        else
    //        {
    //            if (!CheckDownLineMemberTree())
    //            {
    //                Response.Write("Please Check DownLine Member ID");
    //                Response.End();
    //            }
    //            strSelectedFormNo = Request["DownLineFormNo"];
    //        }
    //        strQuery = getQuery(strSelectedFormNo, minDeptLevel);
    //        GenerateTree(strQuery);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //    // getKits()
    //}

    private void getKits()
    {
        try
        {
            DataSet dsKit = new DataSet();

            if (dsKit.Tables[0].Rows.Count > 0)
            {
                img11.Visible = true;
                img11.ImageUrl = "~/img/" + dsKit.Tables[0].Rows[0]["JoinColor"];
                td21.InnerText = (string)dsKit.Tables[0].Rows[0]["KitName"];

                if (dsKit.Tables[0].Rows.Count > 1)
                {
                    img12.Visible = true;
                    img12.ImageUrl = "~/img/" + dsKit.Tables[0].Rows[1]["JoinColor"];
                    td22.InnerText = (string)dsKit.Tables[0].Rows[1]["KitName"];

                    if (dsKit.Tables[0].Rows.Count > 2)
                    {
                        img13.Visible = true;
                        img13.ImageUrl = "~/img/" + dsKit.Tables[0].Rows[2]["JoinColor"];
                        td23.InnerText = (string)dsKit.Tables[0].Rows[2]["KitName"];

                        if (dsKit.Tables[0].Rows.Count > 3)
                        {
                            img14.Visible = true;
                            img14.ImageUrl = "~/img/" + dsKit.Tables[0].Rows[3]["JoinColor"];
                            td24.InnerText = (string)dsKit.Tables[0].Rows[3]["KitName"];

                            if (dsKit.Tables[0].Rows.Count > 4)
                            {
                                img15.Visible = true;
                                img15.ImageUrl = "~/img/" + dsKit.Tables[0].Rows[4]["JoinColor"];
                                td25.InnerText = (string)dsKit.Tables[0].Rows[4]["KitName"];

                                if (dsKit.Tables[0].Rows.Count > 5)
                                {
                                    img16.Visible = true;
                                    img16.ImageUrl = "~/img/" + dsKit.Tables[0].Rows[5]["JoinColor"];
                                    td26.InnerText = (string)dsKit.Tables[0].Rows[5]["KitName"];

                                    if (dsKit.Tables[0].Rows.Count > 6)
                                    {
                                        img17.Visible = true;
                                        img17.ImageUrl = "~/img/" + dsKit.Tables[0].Rows[6]["JoinColor"];
                                        td27.InnerText = (string)dsKit.Tables[0].Rows[6]["KitName"];
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private bool CheckDownLineMemberTree()
    {
        try
        {
            bool checkDownLineMemberTree = false;
            DataSet ds1 = new DataSet();
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = new SqlParameter("@FormDwn", Request["DownLineFormNo"]);
            prms[1] = new SqlParameter("@FormNo", Session["FormNo"]);
            ds1 = SqlHelper.ExecuteDataset(constr1, CommandType.Text, "Exec sp_CheckDownLineMemberTree '" + prms[0].Value + "','" + prms[1].Value + "'");
            if (ds1.Tables[0].Rows.Count <= 0)
            {
                checkDownLineMemberTree = false;
            }
            else
            {
                checkDownLineMemberTree = true;
            }
            ds1.Dispose();
            return checkDownLineMemberTree;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    //private void GenerateTree(string strQuery)
    //{
    //    int ParentId;
    //    double FormNo;
    //    string MemberName = "";
    //    string LegNo;
    //    string Doj = "";
    //    string UpgradeDate = "";
    //    string DirctLeftActive = "";
    //    string DirectRightActive = "";
    //    string Category = "";
    //    double LeftBV;
    //    double RightBV;
    //    string UpLiner = "";
    //    string Sponsor = "";
    //    string NodeName = "";
    //    string myRunTimeString = "";
    //    string ExpandYesNo;
    //    string strImageFile;
    //    string strUrlPath = "";
    //    string tooltipstrig;
    //    string Mobile;
    //    string idStatus = "";
    //    string Isblock = "";
    //    try
    //    {
    //        DataSet ds1 = new DataSet();

    //        // Adding transaction isolation level to the query
    //        strQuery = IsoStart + strQuery + IsoEnd;
    //        ds1 = SqlHelper.ExecuteDataset(Cnn, CommandType.Text, strQuery);


    //        myRunTimeString += "<Script Language=Javascript>\n";
    //        myRunTimeString += "mytree = new dTree('mytree');\n";
    //        tooltipstrig = ToolTipTable();

    //        ParentId = -1;
    //        FormNo = !string.IsNullOrEmpty(Request["DownLineFormNo"]) ? Convert.ToDouble(Request["DownLineFormNo"]) : Convert.ToDouble(Session["FormNo"]);

    //        DataSet tmpDS = SqlHelper.ExecuteDataset(Cnn, CommandType.Text, IsoStart + "Exec sp_TreeDetail '" + FormNo + "'" + IsoEnd);
    //        if (tmpDS.Tables[0].Rows.Count > 0)
    //        {
    //            DataRow row = tmpDS.Tables[0].Rows[0];
    //            idStatus = row["idstatus"].ToString();
    //            MemberName = row["IdNo"].ToString();
    //            NodeName = row["Idno"].ToString() + "(" + row["MemFirstName"].ToString() + ")";
    //            strImageFile = "img/" + row["Joincolor1"].ToString();
    //            Doj = row["Doj"].ToString();
    //            LeftBV = Convert.ToDouble(row["Direct"]);
    //            RightBV = Convert.ToDouble(row["Indirect"]);
    //            Category = row["BV"].ToString();
    //            UpgradeDate = row["UpgradeDate"].ToString();
    //            DirctLeftActive = row["DirectActive"].ToString();
    //            DirectRightActive = row["InDirectActive"].ToString();
    //            Sponsor = row["Sponsorid"].ToString() + "(" + row["SponsorName"].ToString() + ")";
    //            Mobile = "0";
    //            Isblock = row["Isblock1"].ToString();
    //        }
    //        myRunTimeString += "mytree = new dTree('mytree','" + strImageFile + "');\n";
    //        myRunTimeString += " mytree.add(" + FormNo + "," + ParentId + "," + "'" + Category + "'" + "," + "'" + Doj + "'," + "'" + UpgradeDate + "','" + MemberName + "','" + NodeName + "'," +
    //            "'" + UpLiner + "'" + ",'" + Sponsor + "'," + LeftBV + "," + RightBV + "," + DirctLeftActive + "," + DirectRightActive + "," + "'" + strUrlPath + "'" + ",'" + MemberName + "'," + "'" + "" + "'" + "," +
    //            "" + "''" + "," + "''" + ",'true','" + idStatus + "','" + Mobile + "','" + Isblock + "');\n";
    //        //myRunTimeString += "mytree = new dTree('mytree','" + strImageFile + "');\n";
    //        //myRunTimeString += " mytree.add({FormNo},{ParentId},'{Category}','{Doj}','{UpgradeDate}','{MemberName}','{NodeName}','{UpLiner}','{Sponsor}',{LeftBV},{RightBV},'{DirctLeftActive}','{DirectRightActive}','{strUrlPath}','{MemberName}',''," +
    //        //                   "'{strImageFile}','{strImageFile}','true','{idStatus}','{Mobile}','{Isblock}');\n";

    //        int LoopValue = 0;

    //        foreach (DataRow dr in ds1.Tables[0].Rows)
    //        {
    //            ParentId = Convert.ToInt32(dr["RefFormno"]);
    //            FormNo = Convert.ToDouble(dr["FormNoDwn"]);
    //            LegNo = dr["Reflegno"].ToString();
    //            UpLiner = "0";
    //            Sponsor = dr["Sponsorid"].ToString() + "(" + dr["SponsorName"].ToString() + ")";
    //            Doj = dr["doj"].ToString();
    //            Category = dr["BV"].ToString();
    //            LeftBV = Convert.ToDouble(dr["Direct"]);
    //            RightBV = Convert.ToDouble(dr["Indirect"]);
    //            idStatus = dr["Idstatus"].ToString();

    //            strUrlPath = dr["Isblock"].ToString() == "Flashed" ? "#" : "Referaltree.aspx?DownLineFormNo=" + FormNo + "";

    //            strImageFile = dr["JoinColor"].ToString();
    //            MemberName = dr["IdNO"].ToString();
    //            NodeName = dr["Idno"].ToString() + "(" + dr["MemFirstName"].ToString() + ")";
    //            UpgradeDate = dr["UpgradeDate"].ToString();
    //            DirctLeftActive = dr["ActiveDirect"].ToString();
    //            DirectRightActive = dr["ActiveInDirect"].ToString();
    //            Mobile = dr["mobl"].ToString();
    //            Isblock = dr["Isblock"].ToString();

    //            LoopValue++;
    //            ExpandYesNo = LoopValue <= 3 ? "true" : "false";

    //            if (FormNo <= 0)
    //            {
    //                strImageFile = "img/empty.jpg";
    //                MemberName = "Direct";
    //                strUrlPath = "";
    //            }
    //            else
    //            {
    //                strImageFile = "img/" + dr["JoinColor"];
    //                if (dr["Isblock"].ToString() == "Flashed")
    //                {
    //                    strUrlPath = "#";
    //                }
    //            }

    //            myRunTimeString += " mytree.add(" + FormNo + "," + ParentId + ",'" + Category + "','" + Doj + "','" + UpgradeDate + "','" + MemberName + "','" + NodeName + "','" + UpLiner + "','" + Sponsor + "',";
    //            myRunTimeString += "" + LeftBV + "," + RightBV + ",'" + DirctLeftActive + "','" + DirectRightActive + "','" + strUrlPath + "','" + MemberName + "','',";
    //            myRunTimeString += "'" + strImageFile + "','" + strImageFile + "'," + ExpandYesNo + ",'" + idStatus + "','" + Mobile + "','" + Isblock + "');\n";
    //        }

    //        myRunTimeString += "\n\n\n\n document.write(mytree);\n";
    //        myRunTimeString += "</script> <br> <br> <br> <br> ";
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", myRunTimeString);
    //    }
    //    catch (Exception)
    //    {
    //        Response.Write("Try later.");
    //    }
    //}

    private void GenerateTree(string strQuery)
    {
        try
        {
            DataSet ds1 = new DataSet();
            ds1 = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strQuery);
            string ParentId;
            double FormNo;
            string MemberName = "";
            string LegNo;
            string Doj = "";
            string UpgradeDate = "";
            string DirctLeftActive = "";
            string DirectRightActive = "";
            string DirectBV = "0";
            string InDirectBV = "0";
            string Category = "";
            double LeftBV = 0;
            double RightBV = 0;
            double investment = 0;
            string UpLiner = "";
            string Sponsor = "";
            string NodeName = "";
            string myRunTimeString = "";
            string ExpandYesNo;
            string strImageFile = "";
            string strUrlPath = "";
            string tooltipstrig;
            string Mobile = "0";
            string idStatus = "";
            string Isblock = "";
            string slab = "";

            myRunTimeString = myRunTimeString + "<Script Language=Javascript>" + Environment.NewLine;
            myRunTimeString = myRunTimeString + "mytree = new dTree('mytree');" + Environment.NewLine;
            tooltipstrig = ToolTipTable();
            ParentId = "-1";
            if (Request["DownLineFormNo"] != null)
                FormNo = Convert.ToInt32(Request["DownLineFormNo"]);
            else
                FormNo = Convert.ToInt32(Session["FormNo"]);


            DataSet tmpDS = new DataSet();
            DataSet tmpDS1 = new DataSet();

            tmpDS = SqlHelper.ExecuteDataset(constr1, CommandType.Text, IsoStart + " Exec sp_TreeDetail '" + FormNo + "' " + IsoEnd);
            //tmpDS1 = SqlHelper.ExecuteDataset(constr1, CommandType.Text, IsoStart + " select top(1)slab from " + Obj.dBName + "..MstLevelIncome where formno= '" + FormNo + "' order by sessid desc " + IsoEnd);
            if (tmpDS.Tables[0].Rows.Count > 0)
            {
                //idStatus = tmpDS.Tables[0].Rows[0]["idstatus"].ToString();
                //MemberName = tmpDS.Tables[0].Rows[0]["IdNo"].ToString();
                //NodeName = tmpDS.Tables[0].Rows[0]["MemFirstName"].ToString() + "(" + tmpDS.Tables[0].Rows[0]["Rank"].ToString() + ")";
                //strImageFile = "img/" + tmpDS.Tables[0].Rows[0]["Joincolor1"].ToString();
                //Doj = tmpDS.Tables[0].Rows[0]["Doj"].ToString();
                //LeftBV = Convert.ToDouble(tmpDS.Tables[0].Rows[0]["Direct"].ToString());
                //RightBV = Convert.ToDouble(tmpDS.Tables[0].Rows[0]["Indirect"].ToString());
                ////investment = Convert.ToDouble(tmpDS.Tables[0].Rows[0]["BV"].ToString());
                //investment = Convert.ToDouble(tmpDS.Tables[0].Rows[0]["PVvalue"].ToString());
                //UpgradeDate = tmpDS.Tables[0].Rows[0]["UpgradeDate"].ToString();
                //DirctLeftActive = tmpDS.Tables[0].Rows[0]["DirectActive"].ToString();
                //DirectRightActive = tmpDS.Tables[0].Rows[0]["InDirectActive"].ToString();
                //Sponsor = tmpDS.Tables[0].Rows[0]["Sponsorid"].ToString();
                //Mobile = "0";
                //Isblock = tmpDS.Tables[0].Rows[0]["Isblock1"].ToString();
                //DirectBV = tmpDS.Tables[0].Rows[0]["DirectBV"].ToString();
                //InDirectBV = tmpDS.Tables[0].Rows[0]["InDirectBV"].ToString();
                DataRow row = tmpDS.Tables[0].Rows[0];
                idStatus = row["idstatus"].ToString();
                MemberName = row["IdNo"].ToString();
                NodeName = row["Idno"].ToString() + "(" + row["MemFirstName"].ToString() + ")";
                strImageFile = "img/" + row["Joincolor1"].ToString();
                Doj = row["Doj"].ToString();
                LeftBV = Convert.ToDouble(row["Direct"]);
                RightBV = Convert.ToDouble(row["Indirect"]);
                Category = row["BV"].ToString();
                UpgradeDate = row["UpgradeDate1"].ToString();
                DirctLeftActive = row["DirectActive"].ToString();
                DirectRightActive = row["InDirectActive"].ToString();
                Sponsor = row["Sponsorid"].ToString() + "(" + row["SponsorName"].ToString() + ")";
                Mobile = "0";
                Isblock = row["Isblock1"].ToString();
                //if (tmpDS1.Tables[0].Rows.Count > 0)
                //{
                //    slab = tmpDS1.Tables[0].Rows[0]["slab"].ToString();
                //}
                //else
                //{
                //    slab = "0";
                //}
            }
            myRunTimeString = myRunTimeString + "mytree = new dTree('mytree','" + strImageFile + "');" + Environment.NewLine;
            myRunTimeString = myRunTimeString + " mytree.add(" + FormNo + "," + ParentId + "," + "'" + Category + "'" + "," + "'" + Doj + "'," + "'" + UpgradeDate + "','" + MemberName + "','" + NodeName + "'," +
                "'" + UpLiner + "'" + ",'" + Sponsor + "'," + LeftBV + "," + RightBV + "," + DirctLeftActive + "," + DirectRightActive + "," + "'" + strUrlPath + "'" + ",'" + MemberName + "'," + "'" + "" + "'" + "," +
                "" + "'" + strImageFile + "'" + "," + "'" + strImageFile + "'" + ",'true','" + idStatus + "','" + Mobile + "','" + Isblock + "');" + Environment.NewLine;

            //myRunTimeString += "mytree = new dTree('mytree','" + strImageFile + "');\n";
            //        //myRunTimeString += " mytree.add({FormNo},{ParentId},'{Category}','{Doj}','{UpgradeDate}','{MemberName}','{NodeName}','{UpLiner}','{Sponsor}',{LeftBV},{RightBV},'{DirctLeftActive}','{DirectRightActive}','{strUrlPath}','{MemberName}',''," +
            //        //                   "'{strImageFile}','{strImageFile}','true','{idStatus}','{Mobile}','{Isblock}');\n";


            int LoopValue = 0;
            string FolderFile = "";

            //foreach (DataRow dr in ds1.Tables[0].Rows)
            //{
            //    ParentId = dr["RefFormno"].ToString();
            //    FormNo = Convert.ToDouble(dr["FormNoDwn"].ToString());
            //   // DataSet tmpDS2 = new DataSet();
            //    //tmpDS2 = SqlHelper.ExecuteDataset(constr1, CommandType.Text, IsoStart + "select top(1)slab from " + Obj.dBName + "..MstLevelIncome where formno= '" + Convert.ToDouble(dr["FormNoDwn"].ToString()) + "' order by sessid desc " + IsoEnd);
            //    //if (tmpDS2.Tables[0].Rows.Count > 0)
            //    //{
            //    //    slab = tmpDS2.Tables[0].Rows[0]["slab"].ToString();
            //    //}
            //    //else
            //    //{
            //    //    slab = "0";
            //    //}
            //    LegNo = dr["Reflegno"].ToString();
            //    UpLiner = "0";
            //    Sponsor = dr["Sponsorid"].ToString();
            //    Doj = dr["doj"].ToString();
            //    //investment = Convert.ToDouble(dr["BV"].ToString());
            //    investment = Convert.ToDouble(dr["PVValue"].ToString());
            //    LeftBV = Convert.ToDouble(dr["Direct"].ToString());
            //    RightBV = Convert.ToDouble(dr["Indirect"].ToString());
            //    idStatus = dr["Idstatus"].ToString();
            //    DirectBV = dr["DirectBV"].ToString();
            //    InDirectBV = dr["InDirectBV"].ToString();
            //    if (dr["Isblock"].ToString() == "Flashed")
            //    {
            //        strUrlPath = "#";
            //    }
            //    else
            //    {
            //        strUrlPath = "Referaltree.aspx?DownLineFormNo=" + FormNo;
            //    }
            //    strImageFile = dr["JoinColor"].ToString();
            //    MemberName = dr["IdNO"].ToString();
            //    NodeName = dr["MemFirstName"].ToString() + "(" + dr["Rank"].ToString() + ")";
            //    UpgradeDate = dr["UpgradeDate"].ToString();
            //    DirctLeftActive = dr["ActiveDirect"].ToString();
            //    DirectRightActive = dr["ActiveInDirect"].ToString();
            //    Mobile = dr["mobl"].ToString();
            //    Isblock = dr["Isblock"].ToString();
            //    LoopValue = LoopValue + 1;
            //    if (LoopValue <= 3)
            //    {
            //        ExpandYesNo = "true";
            //    }
            //    else
            //    {
            //        ExpandYesNo = "false";
            //    }
            //    if (FormNo <= 0)
            //    {
            //        strImageFile = "img/empty.jpg";
            //        MemberName = "Direct";
            //        strUrlPath = "";
            //    }
            //    else
            //    {
            //        strImageFile = " img/" + dr["JoinColor"].ToString();
            //        if (dr["Isblock"].ToString() == "Flashed")
            //        {
            //            strUrlPath = "#";
            //        }
            //        else
            //        {
            //            strUrlPath = "Referaltree.aspx?DownLineFormNo=" + FormNo;
            //        }
            //    }
            //    myRunTimeString = myRunTimeString + " mytree.add(" + FormNo + "," + ParentId + "," + "'" + Category + "'" + "," + "'" + Doj + "'," + "'" + UpgradeDate + "','" + MemberName + "','" + NodeName + "','" + UpLiner + "'" + ",'" + Sponsor + "'," + LeftBV + "," + RightBV + "," + DirctLeftActive + "," + DirectRightActive + "," + "'" + strUrlPath + "'" + ",'" + MemberName + "'," + "'" + "" + "'" + "," + "'" + strImageFile + "'" + "," + "'" + strImageFile + "'" + "," + ExpandYesNo + ",'" + idStatus + "','" + Mobile + "','" + Isblock + "','" + DirectBV + "','" + InDirectBV + "','" + slab + "','" + investment + "');" + Environment.NewLine;
            //}
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                //ParentId = Convert.ToInt32(dr["RefFormno"]);
                //FormNo = Convert.ToDouble(dr["FormNoDwn"]);
                ParentId = dr["RefFormno"].ToString();
                FormNo = Convert.ToDouble(dr["FormNoDwn"].ToString());
                LegNo = dr["Reflegno"].ToString();
                UpLiner = "0";
                Sponsor = dr["Sponsorid"].ToString() + "(" + dr["SponsorName"].ToString() + ")";
                Doj = dr["doj"].ToString();
                Category = dr["BV"].ToString();
                LeftBV = Convert.ToDouble(dr["Direct"]);
                RightBV = Convert.ToDouble(dr["Indirect"]);
                idStatus = dr["Idstatus"].ToString();

                strUrlPath = dr["Isblock"].ToString() == "Flashed" ? "#" : "Referaltree.aspx?DownLineFormNo=" + FormNo + "";

                strImageFile = dr["JoinColor"].ToString();
                MemberName = dr["IdNO"].ToString();
                NodeName = dr["Idno"].ToString() + "(" + dr["MemFirstName"].ToString() + ")";
                UpgradeDate = dr["UpgradeDate"].ToString();
                DirctLeftActive = dr["ActiveDirect"].ToString();
                DirectRightActive = dr["ActiveInDirect"].ToString();
                Mobile = dr["mobl"].ToString();
                Isblock = dr["Isblock"].ToString();

                LoopValue++;
                ExpandYesNo = LoopValue <= 3 ? "true" : "false";

                if (FormNo <= 0)
                {
                    strImageFile = "img/empty.jpg";
                    MemberName = "Direct";
                    strUrlPath = "";
                }
                else
                {
                    strImageFile = "img/" + dr["JoinColor"];
                    if (dr["Isblock"].ToString() == "Flashed")
                    {
                        strUrlPath = "#";
                    }
                }

                myRunTimeString += " mytree.add(" + FormNo + "," + ParentId + ",'" + Category + "','" + Doj + "','" + UpgradeDate + "','" + MemberName + "','" + NodeName + "','" + UpLiner + "','" + Sponsor + "',";
                myRunTimeString += "" + LeftBV + "," + RightBV + ",'" + DirctLeftActive + "','" + DirectRightActive + "','" + strUrlPath + "','" + MemberName + "','',";
                myRunTimeString += "'" + strImageFile + "','" + strImageFile + "'," + ExpandYesNo + ",'" + idStatus + "','" + Mobile + "','" + Isblock + "');\n";
            }
            myRunTimeString = myRunTimeString + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + " document.write(mytree);" + Environment.NewLine;
            myRunTimeString = myRunTimeString + "</script> " + "<br> <br> <br> <br> ";
            RegisterStartupScript("clientScript", myRunTimeString);
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
        }
    }
    private string ToolTipTable()
    {

        // strToolTip = "onMouseOver=""ddrivetip('<table width=100% border=0 cellpadding=5 cellspacing=1 bgcolor=#CCCCCC class=containtd>...</table>')"" onMouseOut=""hideddrivetip()"""
        return strToolTip;
    }
    private string getQuery(string strSelectedFormNo, int minDeptLevel)
    {
        try
        {
            return "exec sp_ShowRefTree " + strSelectedFormNo + " , " + minDeptLevel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        try
        {
            if (Cnn.State == ConnectionState.Open)
            {
                Cnn.Close();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        try
        {
            if (Cnn.State == ConnectionState.Open)
            {
                Cnn.Close();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        }
    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Index.aspx");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
