using ClosedXML.Excel;
using System;
using System.CodeDom;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Activities.Expressions;
using System.Activities;
using System.ServiceModel.Activities;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
public partial class Newjoining1 : System.Web.UI.Page
{

    private double _dblAvailLeg = 0;
    private cls_DataAccess dbConnect;
    private DAL ObjDAL = new DAL();
    private SqlCommand cmd = new SqlCommand();
    private SqlDataReader dRead;
    public string DsnName, UserName, Passw;
    private string strQuery, strCaptcha;
    private DataTable tmpTable = new DataTable();
    private int minSpnsrNoLen, minScrtchLen;
    private double Upln, dblSpons, dblState, dblBank, dblIdNo;
    private string dblDistrict, dblTehsil, IfSC;
    private string dblPlan;
    private DateTime CurrDt;
    private string scrname;
    private string LastInsertID = "";
    private string Email = "";
    private string InVoiceNo;
    private int SupplierId;
    private string BillNo;
    private string TaxType;
    private string BillDate;
    private int SBillNo;
    private string SoldBy = "WR";
    private string FType;
    private string Password = "";
    private string membername = "";
    private string clsGeneral = "";
    private clsGeneral dbGeneral = new clsGeneral();
    private string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    private string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
    private SqlConnection cnn;
    DataTable Dt = new DataTable();
    string IsoStart;
    string IsoEnd;
    protected void Page_Load(object sender, System.EventArgs e)
    {
        this.CmdSave.Attributes.Add("onclick", DisableTheButton(this.Page, this.CmdSave));
        try
        {
            if (Application["WebStatus"] == null)
            {
                if (Application["WebStatus"] == "N")
                {
                    Session.Abandon();
                    Response.Redirect("default.aspx", false);
                }
            }
            cnn = new SqlConnection(constr1);
            dbConnect = new cls_DataAccess((string)Application["Connect"]);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            txtUplinerId.Text = (txtUplinerId.Text).Replace("'", "").Replace("=", "").Replace(";", "");
            string sr = "";
            string[] sbstr;
            string Key = "";
            string K = "";
            if (!Page.IsPostBack)
            {
                Session["OtpCount"] = 0;
                Session["OtpTime"] = null;
                Session["OTPP_"] = null;
                Session["Retry"] = null;

                HdnCheckTrnns.Value = GenerateRandomStringJoining(6);
                //getData();

                Session["OtpCount"] = 0;
                ClrCtrl();

                RbtnLegNo.Items.Add("Group A");
                RbtnLegNo.Items.Add("Group B");
                RbtnLegNo.Items[0].Selected = true;

                if (!string.IsNullOrEmpty(Request.QueryString["s"]))
                {
                    K = Request["s"];
                    K = K.Replace(" ", "+");
                    sr = Crypto.Decrypt(K);

                    sbstr = sr.Split('/');
                    string UplinerFormno = sbstr[1];

                    DataTable dt = new DataTable();
                    string s = ObjDAL.Isostart + " select * from " + ObjDAL.dBName + "..M_MemberMaster where Formno='" + UplinerFormno + "'" + ObjDAL.IsoEnd;
                    dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, s).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        txtUplinerId.Text = dt.Rows[0]["Idno"].ToString();
                    }

                    string LegNo = sbstr[3];

                    txtUplinerId.ReadOnly = true;
                    txtRefralId.Text = Session["Idno"].ToString();

                    if (LegNo == "1")
                    {
                        RbtnLegNo.SelectedIndex = 0;
                    }
                    else
                    {
                        RbtnLegNo.SelectedIndex = 1;
                    }

                    RbtnLegNo.Enabled = false;
                    Session["iLeg"] = LegNo;
                }
            refLink:

                if (Request.QueryString["ref"] != null)
                {

                    string req = Request.QueryString["ref"].Replace(" ", "+");
                    string str = Crypto.Decrypt(req);
                    string[] rfAr = str.Split('/');
                    if (rfAr.Length >= 1)
                    {
                        if (rfAr[0] != "" & rfAr[1] == "0")
                        {
                            RbCategory.SelectedValue = rfAr[2];
                            foreach (ListItem item in RbCategory.Items)
                            {
                                if (item.Value != rfAr[2])
                                {
                                    item.Enabled = false;
                                    item.Attributes["style"] = "display:none;";
                                }
                            }
                            txtRefralId.Text = GetIDno(rfAr[0].ToString());

                            //goto refLink;
                        }
                        else if (rfAr[0] != "" & rfAr[1] == "1")
                        {
                            txtRefralId.Text = GetIDno(rfAr[0].ToString());
                            RbtnLegNo.SelectedIndex = 0;
                            RbtnLegNo.Enabled = false;
                            goto refLink;
                        }
                        else if (rfAr[0] != "" & rfAr[1] == "2")
                        {
                            txtRefralId.Text = GetIDno(rfAr[0].ToString());
                            RbtnLegNo.SelectedIndex = 1;
                            RbtnLegNo.Enabled = false;
                            goto refLink;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(txtRefralId.Text))
                    {
                        // FillReferral(cnn);
                        FillReferral(cnn);
                        txtRefralId.ReadOnly = true;
                        txtRefralId.ForeColor = System.Drawing.Color.Black;

                        DataTable tmpTable = new DataTable();
                        string strQuery = "";
                    }
                    if (txtRefralId.Text.Trim() != "")
                    {
                        FillReferral(cnn);
                    }
                    txtRefralId.ReadOnly = true;
                }

                FillPaymode(cnn);

                dbGeneral.Fill_Date_box(ddlDOBdt, ddlDOBmnth, ddlDOBYr, 1940, DateTime.Now.AddYears(-18).Year);
                dbGeneral.Fill_Date_box(DDlMDay, DDLMMonth, DDLMYear, 1940, DateTime.Now.Year);
                FillBankMaster(cnn);
                // FillStateMaster()
                FillCountryMasterName();
                FillCountryMasterCode();
                Fill_State();
                FindSession();
                GetConfigDtl(cnn);
                // sendSMS()
                vsblCtrl(false, true);
            }

            try
            {
                Session["Dsessid"] = 0;
            }
            catch { }

            if (Session["IsGetExtreme"].ToString() == "N")
            {
                rwSpnsr.Visible = true;
            }
            else
            {
                rwSpnsr.Visible = false;
            }

        }
        catch (Exception ex)
        {

        }
    }
    private string ClearInject(string strObj)
    {
        strObj = strObj.Replace(";", "").Replace("'", "").Replace("=", "");
        return strObj.Trim();
    }
    private string GetIDno(string Mid)
    {
        string Result = "";
        try
        {
            DataTable dt = new DataTable();

            //string strSql = IsoStart + "Select IDNO from " + ObjDAL.dBName + " ..M_MemberMAster Where MID = '" + Mid + "' " + IsoEnd;
            string strSql = ObjDAL.Isostart + "Select IDNO from " + ObjDAL.dBName + "..M_MemberMAster Where MID = '" + Mid + "' " + ObjDAL.IsoEnd;
            dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql).Tables[0];

            if ((dt.Rows.Count > 0))
                Result = dt.Rows[0]["IDNO"].ToString();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return Result;
    }
    private string DisableTheButton(System.Web.UI.Control pge, System.Web.UI.Control btn)
    {
        try
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("if (typeof(Page_ClientValidate) == 'function') {");
            sb.Append("if (Page_ClientValidate() == false) { return false; }} ");
            sb.Append("if (confirm('Are you sure to proceed?') == false) { return false; } ");
            sb.Append("this.value = 'Please wait...';");
            sb.Append("this.disabled = true;");
            sb.Append(pge.Page.GetPostBackEventReference(btn));
            sb.Append(";");
            return sb.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private void FillCountryMasterName()
    {
        try
        {
            DataTable dt = new DataTable();
            string strQuery = ObjDAL.Isostart + "Exec Sp_GetCountry" + ObjDAL.IsoEnd;
            dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strQuery).Tables[0];
            ddlCountryNAme.DataSource = dt;
            ddlCountryNAme.DataValueField = "CId";
            ddlCountryNAme.DataTextField = "CountryName";
            ddlCountryNAme.DataBind();
            // ddlCountryName.SelectedIndex = 90;
        }
        catch (Exception ex)
        {
            // Handle exception
        }
    }
    public string GenerateRandomStringJoining(int iLength)
    {
        Random rdm = new Random();
        char[] allowChrs = "123456789".ToCharArray();
        string sResult = "";

        for (int i = 0; i < iLength; i++)
        {
            sResult += allowChrs[rdm.Next(0, allowChrs.Length)];
        }

        return sResult;
    }
    private void Fill_State()
    {
        try
        {
            DataTable dtMaster = new DataTable();
            string strQuery = ObjDAL.Isostart + "Exec Sp_GetState" + ObjDAL.IsoEnd;
            dtMaster = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strQuery).Tables[0];
            ddlStatename.DataSource = dtMaster;
            ddlStatename.DataValueField = "STATECODE";
            ddlStatename.DataTextField = "StateName";
            ddlStatename.DataBind();
            ddlStatename.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            // Handle exception (log it or display a message)
        }
    }
    private void FillPaymode(SqlConnection cnn)
    {
        try
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string strSql = ObjDAL.Isostart + "SELECT top 1 * FROM " + ObjDAL.dBName + "..M_PayModeMaster WHERE ActiveStatus='Y' " + ObjDAL.IsoEnd;

            if (Session["DtPayMode"] == null)
            {
                ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
                dt = ds.Tables[0];
                Session["DtPayMode"] = dt;
            }
            else
            {
                dt = (DataTable)Session["DtPayMode"];
            }

            if (dt.Rows.Count > 0)
            {
                DdlPaymode.DataSource = dt;
                DdlPaymode.DataValueField = "PID";
                DdlPaymode.DataTextField = "Paymode";
                DdlPaymode.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
        }
    }
    private void GetConfigDtl(SqlConnection cnn)
    {
        try
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string strSql = ObjDAL.Isostart + "select *  from " + ObjDAL.dBName + "..M_ConfigMaster " + ObjDAL.IsoEnd;
            ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = ds.Tables[0];
            Session["DtConfigDetail"] = dt;
            if (dt.Rows.Count > 0)
            {
                Session["IsGetExtreme"] = dt.Rows[0]["IsGetExtreme"];
                Session["IsTopUp"] = dt.Rows[0]["IsTopUp"];
                Session["IsSendSMS"] = dt.Rows[0]["IsSendSMS"];
                Session["IdNoPrefix"] = dt.Rows[0]["IdNoPrefix"];
                Session["IsFreeJoin"] = dt.Rows[0]["IsFreeJoin"];
                Session["IsStartJoin"] = dt.Rows[0]["IsStartJoin"];
                Session["JoinStartFrm"] = dt.Rows[0]["JoinStartFrm"];
                Session["IsSubPlan"] = dt.Rows[0]["IsSubPlan"];
            }
            else
            {
                Session["IsGetExtreme"] = "N";
                Session["IsTopUp"] = "N";
                Session["IsSendSMS"] = "N";
                Session["IdNoPrefix"] = "";
                Session["IsFreeJoin"] = "N";
                Session["IsStartJoin"] = "N";
                Session["JoinStartFrm"] = "01-Sep-2011";
                Session["IsSubPlan"] = "N";
            }
        }
        catch
        {
            Session["CompName"] = "";
            Session["CompAdd"] = "";
            Session["CompWeb"] = "";
        }
    }
    protected void vsblCtrl(bool isVsbl, bool isOnlyDv)
    {
        try
        {
            if (!isOnlyDv)
            {
                txtUplinerId.Enabled = !isVsbl;
                txtRefralId.Enabled = !isVsbl;
            }
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
        }
    }
    public string GenerateRandomString(int iLength)
    {
        Random rdm = new Random();
        char[] allowChrs = "123456789".ToCharArray();
        string sResult = "";

        for (int i = 0; i < iLength; i++)
        {
            sResult += allowChrs[rdm.Next(0, allowChrs.Length)];
        }

        return sResult;
    }
    private void ClrCtrl()
    {
        // txtAddLn2.Text = "";
        txtAddLn1.Text = "";
        txtEMailId.Text = "";
        txtFNm.Text = "";
        txtFrstNm.Text = "";
        txtMobileNo.Text = "";
        txtNominee.Text = "";
        txtPanNo.Text = "";
        txtPhNo.Text = "";
        txtPinCode.Text = "";
        txtRelation.Text = "";
        txtUplinerId.Text = "";
        lblUplnrNm.Text = "";
        ddlDistrict.Text = "";
        ddlTehsil.Text = "";
        TxtBranchName.Text = "";
        TxtAccountNo.Text = "";
        txtIfsCode.Text = "";
        // txtPIN.Text = "";
        // txtScratch.Text = "";
        txtRefralId.Text = "";
        lblRefralNm.Text = "";
        // dv_Main.Visible = false;
        txtUplinerId.Enabled = true;
        txtRefralId.Enabled = true;
        // txtPIN.Enabled = true;
        // txtScratch.Enabled = true;
        // cmdNext.Visible = true;

        RbtnLegNo.Enabled = true;
    }
    private void FillBankMaster(SqlConnection Cnn)
    {
        try
        {
            DataTable dt = new DataTable();

            //if (Session["DtBankMaster"] == null)
            //{
            DataSet Ds = new DataSet();
            string strSql = ObjDAL.Isostart + "SELECT top 1 BankCode as Bid, BANKNAME as Bank FROM " + ObjDAL.dBName + "..M_BankMaster WHERE ACTIVESTATUS='Y' and Rowstatus='Y' ORDER BY BankName" + ObjDAL.IsoEnd;
            Ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = Ds.Tables[0];
            Session["DtBankMaster"] = dt;
            //}
            //else
            //{
            //    dt = (DataTable)Session["DtBankMaster"];
            //}

            if (dt.Rows.Count > 0)
            {
                CmbBank.DataSource = dt;
                CmbBank.DataValueField = "Bid";
                CmbBank.DataTextField = "Bank";
                CmbBank.DataBind();
                CmbBank.SelectedIndex = 0;
            }

            TxtBank.Text = CmbBank.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
        }
    }
    public string Validt_SpnsrDtl(string chkby, SqlConnection Cnn)
    {
        try
        {
            string Validt_SpnsrDtl = "";

            if (Session["IsGetExtreme"].ToString() == "N")
            {
                if (string.IsNullOrEmpty(txtUplinerId.Text))
                {
                    string scrname = "<SCRIPT language='javascript'>alert('Check Placement Id');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    txtUplinerId.Focus();
                    return "";
                }
            }

            txtRefralId.Text = txtRefralId.Text.Replace("'", "").Replace("=", "").Replace(";", "").Trim();
            txtUplinerId.Text = txtUplinerId.Text.Replace("'", "").Replace("=", "").Replace(";", "").Trim();

            if (!string.IsNullOrEmpty(txtRefralId.Text))
            {
                try
                {
                    DataTable dt = new DataTable();
                    DataSet Ds = new DataSet();
                    string strSql = ObjDAL.Isostart + "Select FormNo, MemFirstName + ' ' + MemLastName as MemName, ActiveStatus from " + ObjDAL.dBName + "..M_MemberMaster where Idno = '" + txtRefralId.Text + "'" + ObjDAL.IsoEnd;
                    Ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
                    dt = Ds.Tables[0];

                    if (dt.Rows.Count == 0)
                    {
                        string scrname = "<SCRIPT language='javascript'>alert('Sponsor ID Not Exist.');</SCRIPT>";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                        Validt_SpnsrDtl = "";
                        vsblCtrl(false, true);
                        return "";
                    }
                    else
                    {
                        Session["Kitid"] = 1;
                        Session["Bv"] = 0;
                        Session["JoinStatus"] = "N";
                        Session["RP"] = 0;
                        Validt_SpnsrDtl = "OK";
                    }
                    Session["Refral"] = dt.Rows[0]["FormNo"];
                    lblRefralNm.Text = dt.Rows[0]["MemName"].ToString();
                }
                catch (Exception ex)
                {
                    Response.Write("Please check sponsor ID.");
                }
            }
            else
            {
                string scrname = "<SCRIPT language='javascript'>alert('Check Sponsor ID.');</SCRIPT>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                txtRefralId.Focus();
                return "";
            }

            // Additional code for Upliner logic here...

            return Validt_SpnsrDtl;
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    private void FindSession()
    {
        try
        {
            Session["SessID"] = 1;
            return;
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
        }

        try
        {
            DataTable dt = new DataTable();
            DataSet Ds = new DataSet();
            string strSql = ObjDAL.Isostart + "Select Max(SessId) as SessId from " + ObjDAL.dBName + "..M_SessnMaster  " + ObjDAL.IsoEnd;
            Dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql).Tables[0]; ;
            dt = Dt;
            if (dt.Rows.Count > 0)
            {
                Session["SessID"] = dt.Rows[0]["SessID"];
            }
            else
            {
                errMsg.Text = "Session Not Exist. Please Enter New Session.";
                return;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private bool checkAvailLeg()
    {
        try
        {
            int iLegNo = 0;
            int iformNo = 0;

            if (RbtnLegNo.SelectedIndex == 0)
            {
                iLegNo = 1;
            }
            else if (RbtnLegNo.SelectedIndex == 1)
            {
                iLegNo = 2;
            }
            else
            {
                string scrname = "<SCRIPT language='javascript'>alert('Choose Position.');</SCRIPT>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                return false;
            }

            DataTable dt = new DataTable();
            DataSet Ds = new DataSet();
            string strSql = ObjDAL.Isostart + "Select * from " + ObjDAL.dBName + "..M_MemberMaster where IdNo='" + txtUplinerId.Text + "'" + ObjDAL.IsoEnd;
            Ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = Ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                iformNo = Convert.ToInt32(dt.Rows[0]["FormNo"]);
            }
            else
            {
                errMsg.Text = "Check Placeunder Id.";
                string scrname = "<SCRIPT language='javascript'>alert('" + errMsg.Text + "');</SCRIPT>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                return false;
            }

            DataTable dt12 = new DataTable();
            DataSet Ds12 = new DataSet();
            string strSql12 = ObjDAL.Isostart + "SELECT COUNT(*) AS CNT FROM " + ObjDAL.dBName + "..M_MemberMaster WHERE UpLnFormNo=" + iformNo + " And LegNo=" + iLegNo + ObjDAL.IsoEnd;
            Ds12 = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql12);
            dt12 = Ds12.Tables[0];

            if (dt12.Rows.Count > 0 && Convert.ToInt32(dt12.Rows[0]["CNT"]) > 0)
            {
                errMsg.Text = (iLegNo == 1 ? "LEFT" : "RIGHT") + " Position already used, please select correct Position!";
                string scrname = "<SCRIPT language='javascript'>alert('" + errMsg.Text + "');</SCRIPT>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                return false;
            }
            else
            {
                _dblAvailLeg = iformNo;
                return true;
            }
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
            return false;
        }
    }
    protected void txtUplinerId_TextChanged(object sender, EventArgs e)
    {
        FillSponsor(ref cnn);
    }
    private void FillSponsor(ref SqlConnection Cnn)
    {
        try
        {
            errMsg.Text = "";
            lblErrEpin.Text = "";
            int i = 0;
            txtUplinerId.Text = txtUplinerId.Text.Trim().Replace(";", "").Replace("'", "").Replace("=", "");

            DataTable dt = new DataTable();
            DataSet Ds = new DataSet();
            string strSql = ObjDAL.Isostart + " Select FormNo,MemFirstName + ' ' + MemLastName as MemName from " + ObjDAL.dBName +
                            "..M_MemberMaster where IDNo='" + txtUplinerId.Text + "'" + ObjDAL.IsoEnd;
            Ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = Ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                lblUplnrNm.Text = dt.Rows[0]["MemName"].ToString();
                Session["Uplnr"] = dt.Rows[0]["FormNo"].ToString();
                i += 1;
            }
            else
            {
                errMsg.Text = "Invalid PlaceUnder ID!!";
                lblErrEpin.Text = "Invalid PlaceUnder ID!!";
                string scrname = "<SCRIPT language='javascript'>alert('" + errMsg.Text + "');</SCRIPT>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
            }

            if (i == 1)
            {
                checkAvailLeg();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
        }
    }
    private void FillReferral(SqlConnection Cnn)
    {
        try
        {
            lblErrEpin.Text = "";
            errMsg.Text = "";
            txtRefralId.Text = txtRefralId.Text.Trim().Replace(";", "").Replace("'", "").Replace("=", "");

            DataTable dt = new DataTable();
            DataSet Ds = new DataSet();
            string strSql = ObjDAL.Isostart + "Select FormNo,MemFirstName + ' ' + MemLastName as MemName,ActiveStatus from " +
                            ObjDAL.dBName + "..M_MemberMaster where IDNo='" + txtRefralId.Text + "' and IsBlock='N' " + ObjDAL.IsoEnd;
            Ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = Ds.Tables[0];

            if (dt.Rows.Count == 0)
            {
                string scrname = "<SCRIPT language='javascript'>alert('No such record/This ID is Flashed./This Id Not Active!!');</SCRIPT>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                txtRefralId.Text = "";
                return;
            }
            //else if (dt.Rows[0]["ActiveStatus"].ToString() == "N")
            //{
            //    string scrname = "<SCRIPT language='javascript'>alert('This ID is not eligible for sponsor.');</SCRIPT>";
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
            //    return;
            //}
            else
            {
                lblRefralNm.Text = dt.Rows[0]["MemName"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
        }
    }
    protected void CmdCancel_Click(object sender, EventArgs e)
    {
        ClrCtrl();
    }
    protected void txtRefralId_TextChanged(object sender, EventArgs e)
    {
        try
        {
            FillReferral(cnn);
        }
        catch (Exception ex)
        {
            // Handle the exception if necessary
        }
    }
    protected void txtMobileNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtMobileNo.Text))
            {
                string moblno = txtMobileNo.Text;
                string check = moblno.Substring(0, 1);

                if (check == "0")
                {
                    txtMobileNo.Text = "";
                    CmdSave.Enabled = true;
                    chkterms.Checked = false;
                    string scrname = "<SCRIPT language='javascript'>alert('Invalid Mobile No.!');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtMobileNo.Text))
            {
                DataTable Dt1 = new DataTable();
                DataSet Dsmob = new DataSet();
                string strSql = ObjDAL.Isostart + "select Count(mobl) as mobileno from " + ObjDAL.dBName + "..M_Membermaster where Mobl='" + txtMobileNo.Text.Trim() + "' " + ObjDAL.IsoEnd;
                Dsmob = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
                Dt1 = Dsmob.Tables[0];

                if (Convert.ToInt32(Dt1.Rows[0]["mobileno"]) >= 1)
                {
                    txtMobileNo.Text = "";
                    CmdSave.Enabled = true;
                    chkterms.Checked = false;
                    LblMobile.Visible = true;
                    LblMobile.Text = "Already Registered by this Mobile Number.!";
                    //string scrname = "<SCRIPT language='javascript'>alert('Already Registered by this Mobile Number.');</SCRIPT>";
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else
                {
                    LblMobile.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception
        }
    }
    protected void txtEMailId_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable DtEmail = new DataTable();
            DataSet DsEmail = new DataSet();
            string strSql = ObjDAL.IsoEnd + "select Count(Email) as Email from " + ObjDAL.dBName + "..M_Membermaster where Email='" + txtEMailId.Text.Trim() + "' " + ObjDAL.IsoEnd;
            DsEmail = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            DtEmail = DsEmail.Tables[0];

            if (Convert.ToInt32(DtEmail.Rows[0]["Email"]) >= 1)
            {
                txtEMailId.Text = "";
                CmdSave.Enabled = true;
                chkterms.Checked = false;
                LblEmainID.Visible = true;
                LblEmainID.Text = "Already Registered by this Email ID.!";
                return;
            }
            else
            {
                LblEmainID.Visible = false;
            }
        }
        catch (Exception ex)
        {
            // Handle the exception
        }
    }
    protected void ddlCountryNAme_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCountryMasterCode();
    }
    private void FillCountryMasterCode()
    {
        try
        {
            DataTable dt = new DataTable();
            string strQuery = ObjDAL.Isostart + "SELECT StdCode FROM " + ObjDAL.dBName + "..M_CountryMaster WHERE ACTIVESTATUS='Y' AND Cid = '" + ddlCountryNAme.SelectedValue + "' " + ObjDAL.IsoEnd;
            dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strQuery).Tables[0];

            if (dt.Rows.Count > 0)
            {
                ddlMobileNAme.Text = dt.Rows[0]["StdCode"].ToString();
            }
        }
        catch (Exception ex)
        {
            // Handle the exception
        }
    }
    protected void CmdSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!chkterms.Checked)
            {
                string scrname = "<SCRIPT language='javascript'>alert('Please select Terms and Conditions.!');</SCRIPT>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                return;
            }
            else
            {
                if (txtRefralId.Text == "")
                {
                    string scrname = "<SCRIPT language='javascript'>alert('Please Enter Sponsor Id.!');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else if (txtFrstNm.Text == "")
                {
                    string scrname = "<SCRIPT language='javascript'>alert('Please Enter Full Name.!');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else if (ddlCountryNAme.SelectedValue == "0")
                {
                    string scrname = "<SCRIPT language='javascript'>alert('Please Select Country.!');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else if (txtMobileNo.Text == "")
                {
                    string scrname = "<SCRIPT language='javascript'>alert('Please Enter Mobile No.!');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else if (txtEMailId.Text == "")
                {
                    string scrname = "<SCRIPT language='javascript'>alert('Please Enter Email Id.!');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else if (ddlStatename.SelectedValue == "0")
                {
                    CmdSave.Enabled = true;
                    chkterms.Checked = false;
                    string scrname = "<SCRIPT language='javascript'>alert('Please select Statename ');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else if (ddlDistrict.Text == "")
                {
                    CmdSave.Enabled = true;
                    chkterms.Checked = false;
                    string scrname = "<SCRIPT language='javascript'>alert('Please Enter District! ');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else if (ddlTehsil.Text == "")
                {
                    CmdSave.Enabled = true;
                    chkterms.Checked = false;
                    string scrname = "<SCRIPT language='javascript'>alert('Please Enter City! ');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else if (txtdob.Text == "")
                {
                    CmdSave.Enabled = true;
                    chkterms.Checked = false;
                    string scrname = "<SCRIPT language='javascript'>alert('Please select DOB ');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                    return;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtEMailId.Text)) // Check if txtEMailId is not empty
                    {
                        DataTable dtEmail = new DataTable(); // Initialize DataTable
                        DataSet dsEmail = new DataSet(); // Initialize DataSet
                        string strSql = ObjDAL.Isostart + " select Count(Email) as Email from " + ObjDAL.dBName + "..M_Membermaster where Email='" + txtEMailId.Text.Trim() + "' " + ObjDAL.IsoEnd;
                        dsEmail = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql); // Execute the SQL query
                        dtEmail = dsEmail.Tables[0]; // Get the first DataTable from DataSet
                        if (Convert.ToInt32(dtEmail.Rows[0]["Email"]) >= 1) // Check if the email already exists
                        {
                            CmdSave.Enabled = true; // Enable the save command
                            chkterms.Checked = false; // Uncheck the terms checkbox
                            string scrname = "<script language='javascript'>alert('Already Registered by this Email ID.');</script>"; // Prepare alert script
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false); // Register script block
                            return; // Exit the method
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(txtMobileNo.Text)) // Check if txtMobileNo is not empty
                    {
                        string moblno = txtMobileNo.Text; // Get mobile number
                        string check = moblno.Substring(0, 1); // Get the first character

                        if (check == "0") // Check if the first character is "0"
                        {
                            txtMobileNo.Text = ""; // Clear the mobile number
                            CmdSave.Enabled = true; // Enable the save command
                            chkterms.Checked = false; // Uncheck the terms checkbox
                            string scrname = "<script language='javascript'>alert('Invalid Mobile No.!');</script>"; // Prepare alert script
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false); // Register script block
                            return; // Exit the method
                        }
                        string mobileNumber = txtMobileNo.Text;

                        if (Regex.IsMatch(mobileNumber, @"^\d{10,}$"))
                        {
                            //   MessageBox.Show("Valid mobile number.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            txtMobileNo.Text = "";
                            CmdSave.Enabled = true;
                            chkterms.Checked = false;
                            string scrname = "<SCRIPT language='javascript'>alert('Invalid Mobile No.!');</SCRIPT>";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false);
                            return;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(txtMobileNo.Text)) // Check if txtMobileNo is not empty
                    {
                        DataTable dt1 = new DataTable(); // Initialize DataTable
                        DataSet dsmob = new DataSet(); // Initialize DataSet
                        string strSql = ObjDAL.Isostart + "select Count(mobl) as mobileno from " + ObjDAL.dBName + "..M_Membermaster where Mobl='" + txtMobileNo.Text.Trim() + "' " + ObjDAL.IsoEnd;
                        dsmob = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql); // Execute the SQL query
                        dt1 = dsmob.Tables[0]; // Get the first table from the dataset

                        if (Convert.ToInt32(dt1.Rows[0]["mobileno"]) >= 1) // Check if the mobile number is already registered
                        {
                            CmdSave.Enabled = true; // Enable the save command
                            chkterms.Checked = false; // Uncheck the terms checkbox
                            string scrname = "<script language='javascript'>alert('Already Registered by this Mobile Number.');</script>"; // Prepare alert script
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrname, false); // Register script block
                            return; // Exit the method
                        }
                    }
                    SaveIntoDB();

                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
        }
    }
    public void SaveIntoDB()
    {
        try
        {
            int UpdateData = 0;
            if (UpdateData == 0)
            {
                char IsPanCard;
                string strQry = "";
                string strDOB, strDOM, strDOJ, s;
                int iLeg;
                char cGender, cMarried;
                cGender = 'M';
                cMarried = 'N';
                string hostIp = Context.Request.UserHostAddress;
                string HostIp = Context.Request.UserHostAddress.ToString();
                int DistrictCode, CityCode, VillageCode;
                CmdSave.Enabled = false;
                try
                {
                    if (Validt_SpnsrDtl("", cnn) == "OK")
                    {
                        iLeg = Convert.ToInt32(Session["iLeg"]);
                        if ((RbtnLegNo.SelectedIndex == 0))
                            iLeg = 1;
                        else if ((RbtnLegNo.SelectedIndex == 1))
                            iLeg = 2;
                        else
                        {
                            chkterms.Checked = false;
                            CmdSave.Enabled = true;
                            scrname = "<SCRIPT language='javascript'>alert('Choose Position.');" + "</SCRIPT>";
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Choose Position.');", true);
                            RbtnLegNo.Enabled = true;
                            return;
                        }
                        string s1 = "";
                        string q = "";
                        int i = 0;
                        DataTable Dt;
                        int BankCode = 0;
                        dblBank = Convert.ToInt32(CmbBank.SelectedValue);
                        int AreaCode = 0;
                        AreaCode = 0;
                        string RegestType = "";
                        RegestType = RbCategory.SelectedValue;
                        int PostalAreaCode = 0;
                        strDOB = txtdob.Text;
                        strDOM = DDlMDay.Text + "-" + DDLMMonth.Text + "-" + DDLMYear.Text;
                        strDOJ = dbConnect.Get_ServerDate().ToString("dd-MMM-yyyy"); 
                        string dblDistrict = ClearInject(ddlDistrict.Text.ToUpper());
                        string dblTehsil = ClearInject(ddlTehsil.Text.ToUpper());
                        if (string.IsNullOrEmpty(dblDistrict))
                        {
                            dblDistrict = "";
                        }
                        DistrictCode = 0;
                        CityCode = 0;
                        VillageCode = 0;
                        IfSC = ClearInject(txtIfsCode.Text.ToUpper());
                        dblPlan = "0";
                        InVoiceNo = "0";
                        if (Session["SessID"] == null || (int)Session["SessID"] == 0)
                        {
                            FindSession();
                        }
                        string Name = "";
                        string fathername = "";
                        Name = ClearInject(txtFrstNm.Text.ToUpper());
                        fathername = ClearInject(txtFNm.Text.ToUpper());
                        TxtPasswd.Text = GenerateRandomString(6);
                        var Strquery1 = "Insert into Trnjoining (Transid) values(" + HdnCheckTrnns.Value + ")";
                        int UpdateData1 = 0;
                        UpdateData1 = Convert.ToInt32(SqlHelper.ExecuteNonQuery(constr, CommandType.Text, Strquery1));
                        if (UpdateData1 > 0)
                        {
                            strQry = "INSERT INTO m_memberMaster(SessId, IdNo, CardNo, FormNo, KitId, UpLnFormNo, RefId, LegNo, RefLegNo, RefFormNo, " +
         "MemFirstName, MemLastName, MemRelation, MemFName, MemDOB, MemGender, MemOccupation, NomineeName, Address1, Address2, Post, " +
         "Tehsil, City, District, StateCode, CountryId, PinCode, PhN1, Fax, Mobl, MarrgDate, Passw, Doj, Relation, PanNo, " +
         "BankID, MICRCode, BranchName, EMail, BV, UpGrdSessId, E_MainPassw, EPassw, ActiveStatus, billNo, RP, HostIp, " +
         "PID, Paymode, ChDDNo, ChDDBankID, ChDDBank, ChddDate, ChDDBranch, IsPanCard, AadharNo, AadharNo2, AAdharNo3, Fld5, walletaddress, usercode,regtype) " +
         "VALUES (" + Convert.ToInt32(Session["SessID"]) + ", '0', 0, 0, " + Convert.ToInt32(Session["Kitid"]) + ", " +
         Convert.ToInt32(Session["Uplnr"]) + ", 0, '" + iLeg + "', 0, " + Convert.ToInt32(Session["Refral"]) + ", '" + ClearInject(txtFrstNm.Text.ToUpper()) + "', " +
         "'', '" + CmbType.SelectedValue + "', '" + ClearInject(txtFNm.Text.ToUpper()) + "', '" + strDOB + "', '" + RBTtype.SelectedValue + "', '', " +
         "'" + ClearInject(txtNominee.Text.ToUpper()) + "', '" + ClearInject(txtAddLn1.Text.ToUpper()) + "', '', '', '" + dblTehsil + "', " +
         "'" + dblTehsil + "', '" + dblDistrict + "', " + ddlStatename.SelectedValue + ", " + ddlCountryNAme.SelectedValue + ", '" + txtPinCode.Text + "', " +
         "'" + txtPhNo.Text + "', 'CHOOSE ACCOUNT TYPE', '" + txtMobileNo.Text + "', '" + strDOM + "', '" + ClearInject(TxtPasswd.Text) + "', " +
         "GETDATE(), '" + ClearInject(txtRelation.Text.ToUpper()) + "', '" + ClearInject(txtPanNo.Text.ToUpper()) + "', " + dblBank + ", " +
         "'" + (ClearInject(TxtMICR.Text.ToUpper())) + "', '" + (TxtBranchName.Text.ToUpper()) + "', '" + ClearInject(txtEMailId.Text) + "', " +
         Convert.ToInt32(Session["Bv"]) + ", 0, '" + ClearInject(TxtPasswd.Text) + "', '" + ClearInject(TxtPasswd.Text) + "', '" + Session["JoinStatus"] + "', " +
         "'" + InVoiceNo + "', '" + Session["RP"] + "', '" + HostIp + "', " + Convert.ToInt32(DdlPaymode.SelectedValue) + ", " +
         "'" + (DdlPaymode.SelectedItem.Text.ToUpper()) + "', '" + ClearInject(TxtDDNo.Text) + "', '0', '" + ClearInject(TxtIssueBank.Text.ToUpper()) + "', " +
         "'" + (TxtDDDate.Text) + "', '" + ClearInject(TxtIssueBranch.Text) + "', 'N', '" + ClearInject(TxtAAdhar1.Text) + "', " +
         "'" + ClearInject(TxtAadhar2.Text) + "', '" + ClearInject(TxtAadhar3.Text) + "', '" + Session["TransIDJoin"] + "', '" + TxtWalletaddress.Text + "', '" + ddlMobileNAme.Text + "','" + RbCategory.SelectedValue + "')";

                            int isOk = 0;
                            int retryqry = 0;
                        Savedata:
                            ;
                            isOk = Convert.ToInt32(SqlHelper.ExecuteNonQuery(constr, CommandType.Text, strQry));
                            LastInsertID = "0";
                            if ((isOk > 0))
                            {
                                string membername = "";
                                string SPONSORID1 = "";
                                string SPONSORnAME = "";
                                string Doj = "";
                                string kitamount = "";
                                string Email = "";
                                string Password = "";
                                DataTable Dtsms = new DataTable();
                                string strSql = string.Empty;
                                strSql = ObjDAL.Isostart + " EXEC Sp_GetProfile " + ObjDAL.IsoEnd;
                                Dtsms = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql).Tables[0];
                                if (Dtsms.Rows.Count > 0)
                                {
                                    membername = Dtsms.Rows[0]["MemfirstName"].ToString() + " " + Dtsms.Rows[0]["MemLastName"].ToString();
                                    Email = Dtsms.Rows[0]["Email"].ToString();
                                    LastInsertID = Dtsms.Rows[0]["IDNO"].ToString();
                                    Password = Dtsms.Rows[0]["Passw"].ToString();
                                    Session["Kit"] = Dtsms.Rows[0]["IsBill"];

                                    //FUND_LOGIN_CHECK(Dtsms.Rows[0]["IDNO"].ToString(), Dtsms.Rows[0]["Passw"].ToString(), Dtsms.Rows[0]["formno"].ToString());
                                }
                                else
                                {
                                    LastInsertID = "10001";
                                }


                                CmdSave.Enabled = true;
                                //SendToMemberMail(LastInsertID, Email, membername, Password);
                                Session["LASTID"] = LastInsertID;
                                Session["Join"] = "YES";
                                Response.Redirect("Welcome.Aspx?IDNo=" + LastInsertID, false);
                            }
                            else
                            {
                                if (retryqry <= 2)
                                {
                                    retryqry += 1;
                                    goto Savedata;
                                }
                                CmdSave.Enabled = true;
                                chkterms.Checked = false;
                                scrname = "<SCRIPT language='javascript'>alert('Try Again Later.');" + "</SCRIPT>";
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Try Again Later.');", true);
                            }
                        }

                    }
                }
                catch (Exception e)
                {
                    CmdSave.Enabled = true;
                    chkterms.Checked = false;
                    string scrname = "<SCRIPT language='javascript'>alert('" + e.Message + "');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('" + e.Message + "');", true);

                    string path = HttpContext.Current.Request.Url.AbsoluteUri;
                    string text = path + ": " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss:fff") + Environment.NewLine;
                    ObjDAL.WriteToFile(text + e.Message);
                    Response.Write("Try later.");
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('This id already register.!');location.replace('Registration.aspx');", true);
                return;
            }
        }
        catch (Exception ex)
        {
            dbConnect.closeConnection();
        }
    }
    public bool SendToMemberMail(string IdNo, string Email, string MemberName, string Password)
    {
        try
        {
            string StrMsg = "";
            System.Net.Mail.MailAddress SendFrom = new System.Net.Mail.MailAddress(Session["CompMail"].ToString());
            System.Net.Mail.MailAddress SendTo = new System.Net.Mail.MailAddress(Email);
            System.Net.Mail.MailMessage MyMessage = new System.Net.Mail.MailMessage(SendFrom, SendTo);
            StrMsg = "<table style=\"margin:0; padding:10px; font-size:12px; font-family:Verdana, Arial, Helvetica, sans-serif; line-height:23px; text-align:justify;width:100%\">" +
                     "<tr>" +
                     "<td>" +
                     "<span style=\"color: #0099CC; font-weight: bold;\"><h2>Dear " + MemberName + ",</h2></span><br />" +
                     " It is with great pleasure that we extend our warmest welcome to you as a new member of the <br />" +
                     " " + Session["CompName"] + " family! Congratulations on embarking upon an exciting journey into the world of " + Session["CompName"] + ". <br />" +
                     "<br />" +
                     "<span style=\"color: #0099FF; font-weight: bold;\">Warm regards,</span><br />" +
                     " Team " + Session["CompName"] + " <br />" +
                     "<br />" +
                     "<span style=\"color: #0099FF; font-weight: bold;\">Registration Information</span><br />" +
                     "<strong>Login ID: " + IdNo + "</strong><br />" +
                     "<strong>Password: " + Password + "</strong><br />" +
                     "You may login to the Member Center at: <a href=\"" + Session["CompWeb"] + "\" target=\"_blank\" style=\"color:#0000FF; text-decoration:underline;\">" + Session["CompWeb"] + "</a><br />" +
                     "<br />" +
                     "<br />" +
                     "</td>" +
                     "</tr>" +
                     "</table>";

            MyMessage.Subject = "Warm Welcome to " + Session["CompName"] + ".!";
            MyMessage.Body = StrMsg;
            MyMessage.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(Session["CompMail"].ToString(), Session["MailPass"].ToString());
            smtp.Send(MyMessage);
            return true;
        }
        catch (Exception ex)
        {
            Response.Write("Try later.");
            return false;
        }
    }
    protected void btngenerate_Click(object sender, EventArgs e)
    {

    }
    protected void Txtusername_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable DtEmail = new DataTable();
            DataSet DsEmail = new DataSet();
            string strSql = ObjDAL.Isostart + "select Count(idno) as idno from " + ObjDAL.dBName + "..M_Membermaster where idno = '" + Txtusername.Text.Trim() + "' " + ObjDAL.IsoEnd;
            DsEmail = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            DtEmail = DsEmail.Tables[0];

            if (Convert.ToInt32(DtEmail.Rows[0]["idno"]) >= 1)
            {
                Txtusername.Text = "";
                CmdSave.Enabled = true;
                chkterms.Checked = false;
                LblUseName.Visible = true;
                LblUseName.Text = "Already Registered by this User ID.!";
                return;
            }
            else
            {
                LblUseName.Visible = false;
            }
        }
        catch (Exception ex)
        {
            // Handle the exception
        }
    }
    protected void TxtWalletaddress_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable DtEmail = new DataTable();
            DataSet DsEmail = new DataSet();
            string strSql = ObjDAL.Isostart + "select Count(walletaddress) as walletaddress from " + ObjDAL.dBName + "..M_Membermaster where walletaddress = '" + TxtWalletaddress.Text.Trim() + "' " + ObjDAL.IsoEnd;
            DsEmail = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            DtEmail = DsEmail.Tables[0];

            if (Convert.ToInt32(DtEmail.Rows[0]["walletaddress"]) >= 1)
            {
                txtEMailId.Text = "";
                CmdSave.Enabled = true;
                chkterms.Checked = false;
                LblWalletaddress.Visible = true;
                LblWalletaddress.Text = "Already Registered by this Wallet Address.!";
                return;
            }
            else
            {
                LblWalletaddress.Visible = false;
            }
        }
        catch (Exception ex)
        {
            // Handle the exception
        }
    }
    protected void ddlStatename_TextChanged(object sender, EventArgs e)
    {
        DataTable dtMaster = new DataTable();
        string strQuery = ObjDAL.Isostart + "Select StateCode,StateName from " + ObjDAL.dBName + "..M_StateDivMaster Where ActiveStatus = 'Y' And RowStatus =  'Y' and Statename='" + ddlStatename.SelectedItem.Text + "' " + ObjDAL.IsoEnd;
        dtMaster = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strQuery).Tables[0];
        ddlStatename.DataSource = dtMaster;
        ddlStatename.DataValueField = "STATECODE";
        ddlStatename.DataTextField = "StateName";
        ddlStatename.DataBind();
        ddlStatename.SelectedIndex = 0;
    }
}
