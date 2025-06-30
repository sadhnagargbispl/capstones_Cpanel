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
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using System.Security.Policy;
public partial class Fundwithdrawal : System.Web.UI.Page
{
    private SqlConnection Conn;
    private SqlCommand Comm;
    private SqlDataAdapter Adp;
    private SqlDataReader Dr;
    private DAL ObjDal = new DAL();
    private string Query;
    private int Todate;
    private int BankID = 0;
    private string BranchName = "";
    private string PayName = "";
    private string IFSCode = "";
    private string Acno = "";
    private string PanNo = "";
    private string MobileNo = "";
    private string ISpan = "";
    private clsGeneral clsgen = new clsGeneral();
    private string scrname = "";
    private string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
    private string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            BtnSubmit.Attributes.Add("onclick", DisableTheButton(Page, BtnSubmit));
            BtnOtp.Attributes.Add("onclick", DisableTheButton(Page, BtnOtp));
            ResendOtp.Attributes.Add("onclick", DisableTheButton(Page, ResendOtp));

            if (Session["Status"] as string != "OK")
            {
                Response.Redirect("Logout.aspx");
            }
            GetFundwithdrawalLimit();
            if (!GetKycPerStatus())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please approve kyc detail.');location.replace('Index.aspx');", true);
                return;
            }
            if (GetDateFormatCondition())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Withdrawals are only allowed on Monday.!');location.replace('Index.aspx');", true);
                return;
            }
            if (!GetAmountStatus())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('You Are Not Authorised For Withdrawal.Because Of Your Wallet Balance Is Low.!');location.replace('Index.aspx');", true);
                return;
            }
            if (!IsPostBack)
            {
                Session["OtpCount"] = 0;
                Session["OtpTime"] = null;
                Session["Retry"] = null;
                Session["OTP_"] = null;
                HdnCheckTrnns.Value = GenerateRandomString();
                FillDetail();
                if (FillBankDetail())
                {
                }
                TxtCredit.Text = Amount().ToString();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('" + ex.Message + "');", true);
        }
    }
    private void FillDetail()
    {
        DataTable tmpTable = new DataTable();

        using (SqlConnection Conn = new SqlConnection(constr))
        {
            Conn.Open();

            string query = "SELECT 1 AS Sno, a.BankId, b.BANKNAME, a.aCnO, a.iFsCODE, " +
                           "A.MemFirstName AS pAYEEnAME, A.BranchName, a.pANnO " +
                           "FROM M_MemberMaster AS a, m_BANKmASTER AS b " +
                           "WHERE a.bANKid = b.bANKcODE AND a.fORMnO = @FormNo";

            using (SqlCommand Comm = new SqlCommand(query, Conn))
            {
                Comm.Parameters.AddWithValue("@FormNo", Session["FormNo"]);

                using (SqlDataAdapter Adp = new SqlDataAdapter(Comm))
                {
                    Adp.Fill(tmpTable);
                    GrdBankDetail.DataSource = tmpTable;
                    GrdBankDetail.DataBind();
                }
            }
        }
    }
    private bool GetReqStatus()
    {
        bool result = false;
        try
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string strSql = ObjDal.Isostart + " exec SP_GetReqStatusUpdate '" + Session["FormNo"] + "', 'M' " + ObjDal.IsoEnd;
            ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0]["Cnt"]);
                    if (Convert.ToInt32(dt.Rows[0]["Cnt"]) == 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            return result;
        }
    }
    private string DisableTheButton(Control pge, Control btn)
    {
        try
        {
            var sb = new System.Text.StringBuilder();
            sb.Append("if (typeof(Page_ClientValidate) == 'function') {");
            sb.Append("if (Page_ClientValidate() == false) { return false; }} ");
            sb.Append("if (confirm('Are you sure to proceed?') == false) { return false; } ");
            sb.Append("this.value = 'Please Wait...';");
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
    private bool GetDateFormatCondition()
    {
        try
        {
            bool result = false;
            DataTable dt = new DataTable();
            string strSql = ObjDal.Isostart + " exec Sp_GetDateFormatCondition " + ObjDal.IsoEnd;
            DataSet ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = ds.Tables[0];
            result = dt.Rows[0]["Status"].ToString() == "0";
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private bool GetKycPerStatus()
    {
        try
        {
            bool result = false;
            DataTable dt12 = new DataTable();
            string str12 = ObjDal.Isostart + "EXEC sp_CheckKycStatus '" + Convert.ToInt32(Session["Formno"]) + "' " + ObjDal.IsoEnd;
            DataSet ds12 = SqlHelper.ExecuteDataset(constr1, CommandType.Text, str12);
            dt12 = ds12.Tables[0];
            result = dt12.Rows[0]["Status"].ToString().ToUpper() == "TRUE";
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private void CheckAmount()
    {
        int temp = 0;
        if (Convert.ToDecimal(TxtReqAmt.Text) < Convert.ToDecimal(Session["FMinwithdrawl"]))
        {
            string scrname = "<script language='javascript'>alert('Minimum request amount is " + Session["FMinwithdrawl"] + ".');</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Error", scrname, false);
            BtnSubmit.Enabled = true;
            TxtTds.Text = "0";
            txtwithdrawls.Text = "0";
            TxtFinalSritoken.Text = "0";
            TxtReqAmt.Text = "0";
            TxtFrxInfra.Text = string.Empty;
        }
        else if (Convert.ToDecimal(TxtReqAmt.Text) > Convert.ToDecimal(Session["MaxWithdrawl"]))
        {
            string scrname = "<script language='javascript'>alert('Maximum request amount is " + Session["MaxWithdrawl"] + "');</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Error", scrname, false);
            BtnSubmit.Enabled = true;
            TxtTds.Text = "0";
            txtwithdrawls.Text = "0";
            TxtFinalSritoken.Text = "0";
            TxtReqAmt.Text = "0";
            TxtFrxInfra.Text = string.Empty;
            return;
        }
        else if (Convert.ToDecimal(TxtReqAmt.Text) > Amount())
        {
            string scrname = "<script language='javascript'>alert('Insufficient Balance.');</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Error", scrname, false);
            BtnSubmit.Enabled = true;
            TxtTds.Text = "0";
            txtwithdrawls.Text = "0";
            TxtFinalSritoken.Text = "0";
            TxtReqAmt.Text = "0";
            TxtFrxInfra.Text = string.Empty;
        }
        else if (Convert.ToDecimal(TxtReqAmt.Text) == 0)
        {
            string scrname = "<script language='javascript'>alert('Minimum request amount is " + Session["FMinwithdrawl"] + ".');</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Error", scrname, false);
            BtnSubmit.Enabled = true;
            TxtTds.Text = "0";
            txtwithdrawls.Text = "0";
            TxtFinalSritoken.Text = "0";
            TxtReqAmt.Text = "0";
            TxtFrxInfra.Text = string.Empty;
        }
        else
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string strSql = ObjDal.Isostart + " Select * from  [dbo].[ufnGetWithdrawalCharge]('" + TxtReqAmt.Text + "','" + Session["formno"] + "','M') " + ObjDal.IsoEnd;
            ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                //TxtReqAmt.Text = dt.Rows[0]["Amount"].ToString();
                TxtTds.Text = Math.Round(Convert.ToDouble(dt.Rows[0]["AdminChargeAmount"]), 2).ToString();
                txtwithdrawls.Text = Math.Round(Convert.ToDouble(dt.Rows[0]["NetAMount"]), 2).ToString();
                TxtFinalSritoken.Text = Math.Round(Convert.ToDouble(dt.Rows[0]["FinalWithdrawalAmount"]), 2).ToString();
                //LblCoinRate.Text = Math.Round(Convert.ToDouble(dt.Rows[0]["RPRate"]), 2).ToString();
            }
            //}
            //else
            //{
            //    DataTable dt = new DataTable();
            //    DataSet ds = new DataSet();
            //    string strSql = ObjDal.Isostart + " Select * from  [dbo].[ufnGetWithdrawalCharge]('" + TxtReqAmt.Text + "','" + Session["formno"] + "','" + ddlWalletType.SelectedValue + "') " + ObjDal.IsoEnd;
            //    ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            //    dt = ds.Tables[0];

            //    if (dt.Rows.Count > 0)
            //    {
            //        TxtReqAmt.Text = dt.Rows[0]["Amount"].ToString();
            //        TxtTds.Text = "0";
            //        txtwithdrawls.Text = dt.Rows[0]["Amount"].ToString();
            //    }
            //}
        }
    }
    private bool FillBankDetail()
    {
        try
        {
            DataTable tmpTable = new DataTable();
            string qq = " exec sp_GetBankDetail " + Session["FormNo"];
            DataSet ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, qq);
            tmpTable = ds.Tables[0];
            return true; // Assuming you want to return true if the operation succeeds
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private Decimal Amount()
    {
        try
        {
            Decimal RtrVal = 0;
            string Str = ObjDal.Isostart + "Select balance From dbo.ufnGetBalance('" + Session["FormNo"] + "','M')" + ObjDal.IsoEnd;
            SqlConnection cnn = new SqlConnection(constr1);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(cnn, CommandType.Text, Str))
            {
                if (dr.Read())
                {
                    RtrVal = Convert.ToDecimal(dr["Balance"]);
                }
            }
            return RtrVal;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private bool GetFundwithdrawalLimit()
    {
        try
        {
            bool result = false;
            DataTable dt = new DataTable();
            string strSql = ObjDal.Isostart + " exec Sp_GetFundlimit " + ObjDal.IsoEnd;
            DataSet ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                Session["FMinwithdrawl"] = dt.Rows[0]["MinWithdrawl"];
                Session["MinFWithdraDeduction"] = dt.Rows[0]["WithdrawlDeduction"];
                Session["MaxWithdrawl"] = dt.Rows[0]["MaxWithdrawl"];
                result = true; // Set result to true since data is found
            }
            else
            {
                Session["FMinwithdrawl"] = 0;
                Session["MinFWithdraDeduction"] = 0;
                Session["MaxWithdrawl"] = 0;
            }

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private bool GetAmountStatus()
    {
        try
        {
            bool result = false;
            DataTable dt = new DataTable();
            string strSql = ObjDal.Isostart + "Select balance From dbo.ufnGetBalance('" + Session["FormNo"] + "','M')" + ObjDal.IsoEnd;
            DataSet ds = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql);
            dt = ds.Tables[0];

            if (Convert.ToDouble(dt.Rows[0]["balance"]) < Convert.ToDouble(Session["FMinwithdrawl"]))
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (!GetReqStatus())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('You can withdrawal only one time in a day.!');location.replace('Index.aspx');", true);
                return;
            }
            if (Convert.ToDecimal(txtwithdrawls.Text) == 0)
            {
                string scrName = "<script language='javascript'>alert('Minimum request amount is " + Session["FMinwithdrawl"] + ".');</script>";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrName, false);
                ResetFields();
                return;
            }
            if (!GetKycPerStatus())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please approve kyc detail.');location.replace('Index.aspx');", true);
                return;
            }
            if (!GetAmountStatus())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('You do not have enough balance for withdrawal.');location.replace('Index.aspx');", true);
                return;
            }
            ObjDal = new DAL();
            DataTable dtCheck = new DataTable();
            string strCheck = ObjDal.Isostart + " exec Sp_GetTimeOfWithdrawal '" + Session["formno"] + "'" + ObjDal.IsoEnd;
            dtCheck = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strCheck).Tables[0];
            if (dtCheck.Rows.Count > 0)
            {
                DateTime minTime = DateTime.Parse(dtCheck.Rows[0]["Min"].ToString());
                DateTime currentTime = DateTime.Parse(dtCheck.Rows[0]["CurrentTime"].ToString());

                if (minTime > currentTime)
                {
                    string scrName = "<SCRIPT language='javascript'>alert('You can withdrawal after 10 Min.');</SCRIPT>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Login Error", scrName, false);
                    ResetFields();
                    return;
                }
            }
            string strSql = ObjDal.Isostart + "EXEC Sp_CheckTransctionPassword " + Session["Formno"] + ",'" + TxtPassword.Text.Trim() + "'" + ObjDal.IsoEnd;
            DataTable dtPassword = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strSql).Tables[0];

            if (dtPassword.Rows.Count > 0)
            {
                otp_save_function();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Upgraded", "<SCRIPT language='javascript'>alert('Please Enter Valid Transaction Password.!');</SCRIPT>", false);
            }
            
        }
        catch (Exception ex)
        {
            string scrName = "<SCRIPT language='javascript'>alert('Email Try Later');</SCRIPT>";
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Error", scrName, false);
        }
    }
    private void ResetFields()
    {
        TxtReqAmt.Text = "0";
        TxtTds.Text = "0";
        txtwithdrawls.Text = "0";
        TxtFinalSritoken.Text = "0";
        TxtFrxInfra.Text = "";
    }
    protected void otp_save_function()
    {
        try
        {
            string strSql = "Insert into TrnFundUniqe (Transid, Rectimestamp) values (" + HdnCheckTrnns.Value + ", GETDATE())";
            int updateEffect = ObjDal.SaveData(strSql);

            if (updateEffect > 0)
            {
                string responseData = string.Empty;
                try
                {
                    string scrname = string.Empty;
                    Label1.Text = string.Empty;

                    if (decimal.Parse(TxtReqAmt.Text) < decimal.Parse(Session["FMinwithdrawl"].ToString()))
                    {
                        scrname = "<SCRIPT language='javascript'>alert('Minimum Request Amount is " + Session["FMinwithdrawl"].ToString() + ".');</SCRIPT>";
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "Login Error", scrname, false);
                        return;
                    }

                    decimal result = 0;
                    if (Convert.ToDecimal(TxtReqAmt.Text) > Amount())
                    {
                        scrname = "<SCRIPT language='javascript'>alert('Insufficient Balance.');</SCRIPT>";
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "Login Error", scrname, false);
                        return;
                    }    
                    if (FillBankDetail())
                    {
                        ObjDal = new DAL();
                        DataTable dt = new DataTable();
                        DataSet ds = new DataSet();
                        string strCheck = ObjDal.Isostart + " exec Sp_GetTimeOfWithdrawal '" + Session["formno"].ToString() + "'" + ObjDal.IsoEnd;
                        dt = SqlHelper.ExecuteDataset(constr1, CommandType.Text, strCheck).Tables[0];

                        if (dt.Rows.Count > 0)
                        {
                            DateTime minTime = DateTime.Parse(dt.Rows[0]["Min"].ToString());
                            DateTime currentTime = DateTime.Parse(dt.Rows[0]["CurrentTime"].ToString());

                            if (minTime > currentTime)
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "Key", "alert('You can withdrawal after 10 Min.!');location.replace('FundWithdrawal.aspx');", true);
                                ResetFields();
                                return;
                            }
                        }
                        string reqNo = string.Empty;
                        string MaxVoucherNo_ = "2" + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        long maxVno_ = Convert.ToInt64(MaxVoucherNo_) + Convert.ToInt64(Session["Formno"].ToString());
                        reqNo = maxVno_.ToString();
                        string strCheckReq = "select count(*) as Cnt from TrnFundWithDrawal where formno='" + Session["formno"].ToString() + "' AND reqno = '" + reqNo + "'";
                        DataTable dtCheck_D = SqlHelper.ExecuteDataset(constr, CommandType.Text, strCheckReq).Tables[0];
                        if (Convert.ToInt32(dtCheck_D.Rows[0]["Cnt"]) == 0)
                        {
                            string Str_TrnFun = "";
                            string Str_TrnFun_Query = "";
                            Str_TrnFun += "INSERT INTO TrnFundWithDrawal (ReqNo, Formno, ReqAmount, AdminCharge, TDSCharge, NetAmount, DeductForProductWallet, WithdrawToken, ";
                            Str_TrnFun += "TokenRate, AdminCredit, PanNo, Wsessid, PayeeName, RectimeStamp, IpAdrs, OtherId, WalletType) ";
                            Str_TrnFun += "VALUES ('" + reqNo + "', '" + Convert.ToDecimal(Session["Formno"]) + "', '" + Convert.ToDecimal(TxtReqAmt.Text) + "', '" + Convert.ToDecimal(TxtTds.Text) + "', ";
                            Str_TrnFun += "'0', '" + Convert.ToDecimal(txtwithdrawls.Text) + "', '0', '" + Convert.ToDecimal(txtwithdrawls.Text) + "', ";
                            Str_TrnFun += "'0', 0, '', 1, '" + Session["MemName"] + "', GETDATE(), '','" + TxtFrxInfra.Text.Trim() + "', 'M');";
                            Str_TrnFun += "UPDATE TrnFundUniqe SET ReqID = '" + reqNo + "' WHERE Transid = '" + HdnCheckTrnns.Value + "'";
                            Str_TrnFun_Query = "BEGIN TRY BEGIN TRANSACTION " + Str_TrnFun + " COMMIT TRANSACTION END TRY BEGIN CATCH ROLLBACK TRANSACTION END CATCH";
                            int i = SqlHelper.ExecuteNonQuery(constr, CommandType.Text, Str_TrnFun_Query);
                            if (i > 0)
                            {
                                TxtCredit.Text = Amount().ToString();
                                TxtReqAmt.Text = "0";
                                TxtTds.Text = "0";
                                txtwithdrawls.Text = "0";
                                TxtFinalSritoken.Text = "0";
                                TxtFrxInfra.Text = string.Empty;
                                ScriptManager.RegisterStartupScript(Page, GetType(), "Key", "alert('Withdrawal Successfully.!');location.replace('FundWithdrawal.aspx');", true);
                                return;
                            }
                            else
                            {
                                TxtReqAmt.Text = "0";
                                TxtTds.Text = "0";
                                txtwithdrawls.Text = "0";
                                TxtFinalSritoken.Text = "0";
                                TxtCredit.Text = Amount().ToString();
                                TxtFrxInfra.Text = string.Empty;
                                scrname = "<SCRIPT language='javascript'>alert('Try again later.');</SCRIPT>";
                                ScriptManager.RegisterStartupScript(Page, GetType(), "Login Error", scrname, false);
                                return;
                            }
                        }
                        else
                        {
                            scrname = "<SCRIPT language='javascript'>alert('Something Went Wrong.');</SCRIPT>";
                            ScriptManager.RegisterStartupScript(Page, GetType(), "Upgraded", scrname, false);
                            TxtReqAmt.Text = "0";
                            TxtTds.Text = "0";
                            txtwithdrawls.Text = "0";
                            TxtFinalSritoken.Text = "0";
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string scrname = "<SCRIPT language='javascript'>alert('" + ex.Message + "');</SCRIPT>";
                    ScriptManager.RegisterStartupScript(Page, GetType(), "Login Error", scrname, false);
                    return;
                }
            }
            else
            {
                string scrname = "<SCRIPT language='javascript'>alert('Something Went Wrong.');</SCRIPT>";
                ScriptManager.RegisterStartupScript(Page, GetType(), "Upgraded", scrname, false);
                return;
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that might be thrown
            // Log or process the exception as needed
            Console.WriteLine("Error in otp_save_function: " + ex.Message);
        }
    }
    public string GenerateRandomString()
    {
        string result = "";
        string currentDateTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        Random random = new Random();
        int randomNumber = random.Next(0, 999);
        string formattedDateTime = currentDateTime + randomNumber.ToString("D3");
        result = formattedDateTime;
        return result;
    }
    protected void TxtReqAmt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CheckAmount();
        }
        catch (Exception ex)
        {
            string scrname = "<script language='javascript'>alert('Minimum request amount is " + Session["FMinwithdrawl"] + "');</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Login Error", scrname, false);
            BtnSubmit.Enabled = true;
            TxtTds.Text = "0";
            txtwithdrawls.Text = "0";
            TxtFinalSritoken.Text = "0";
            TxtReqAmt.Text = "0";
        }
    }
}
