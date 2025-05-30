using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data;
using System.Security.Cryptography;
using System.Configuration;
using System.Net;

partial class Directlogin : System.Web.UI.Page
{
    private string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    private static TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
    private static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
    private static string key = "sg75b79-nj48dh02";
    protected void Page_Load(object sender, System.EventArgs e)
    {
        try
        {
            if (Session["IDNO"] == null)
                Response.Redirect("https://dxmall.in/");
            else
            {
                //var LgnID = Encrypt("uid=" + Session["IDNo"] + "&pwd=" + Session["MemPassw"]);
                //DateTime currentDate = DateTime.Now;
                //string TmID = currentDate.Day.ToString("00") + currentDate.Hour.ToString("00") + currentDate.Year.ToString() + (currentDate.Month - 1).ToString();
                //string url = "https://dgtalexpo.com/Default.aspx?lgnT=" + LgnID + "&ID=" + TmID + "";
                ////string url = "http://localhost:59233/Default.aspx?lgnT=" + LgnID + "&ID=" + TmID + "";
                //Response.Redirect(url);
                string formPostText = "";
                string UserName = Encrypt(Session["IDNO"].ToString());
                string Password = Encrypt(Session["MemPassw"].ToString());

                string Token = "ODIzNTEzQzgtNzVDOS00RjE3LUIzOTYtMDlERDQzOUQ0Qjcy";
                //string info12 = "UserName=" + Convert.ToString(Session["IDNO"]) + "&Password=" + Convert.ToString(Session["MemPassw"]) + "&Action=Login" + "&Token=" + Token;
                string info12 = "UserName=" + Session["IDNO"] + "&Password=" + Session["MemPassw"] + "&Action=Login" + "&Token=" + Token;
                string refes = Base64Encode(info12);
                string data = Base64Decode(refes);
                Response.Redirect("https://dxmall.in/Account/DirectLogin?URL=" + refes);
            }


            //string formPostText = "";
            //string UserName = Encrypt(Session["IDNO"].ToString());
            //string Password = Encrypt(Session["MemPassw"].ToString());

            //    formPostText = @"<form method=""POST"" action=""https://shop.capstones.in/Account/DirectLogin"" name=""frm2Post"">" +
            //                   " <input type=\"hidden\" name=\"LoginId\" value=\"" + UserName + "\" />" +
            //                   " <input type=\"hidden\" name=\"Password\" value=\"" + Password + "\" />" +
            //                   " <input type=\"hidden\" name=\"Token\" value=\"9w8gfOY/3amGrCPm1cOAhscvtuPoPqHombKOhTRRhRjDaSj3ppzsZG/gZgl1DnU2\" />" +
            //                   " <script type=\"text/javascript\">document.frm2Post.submit();</script></form>";

            //    Response.Write(formPostText);
        }
        catch (Exception ex)
        {
        }
    }
    public static byte[] MD5Hash(string value)
    {
        return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value));
    }
    public static string Encrypt(string stringToEncrypt)
    {
        DES.Key = Crypto.MD5Hash(key);
        DES.Mode = CipherMode.ECB;
        byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt);
        return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
    }
    public static string Decrypt(string encryptedString)
    {
        try
        {
            DES.Key = Crypto.MD5Hash(key);
            DES.Mode = CipherMode.ECB;
            byte[] Buffer = Convert.FromBase64String(encryptedString);
            return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        catch (Exception ex)
        {
            return DBNull.Value.ToString();
        }
    }
    //public string Encrypt(string plainText)
    //{
    //    string completeUrl = "https://shop.capstones.in/Account/Encrypt?plainText=" + plainText;
    //    System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072; // TLS 1.2

    //    HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(completeUrl);
    //    request1.ContentType = "application/json";
    //    request1.Method = "GET";

    //    using (HttpWebResponse httpWebResponse = (HttpWebResponse)request1.GetResponse())
    //    using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
    //    {
    //        string responseString = reader.ReadToEnd();
    //        return responseString;
    //    }
    //}
    private string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    private string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
    //public string Decrypt(string cipherText)
    //{
    //    byte[] iv = new byte[16]; // 16-byte IV for AES
    //    byte[] buffer = Convert.FromBase64String(cipherText);

    //    using (Aes aes = Aes.Create())
    //    {
    //        aes.Key = Encoding.UTF8.GetBytes("Y$8tM9d#k4KqpV^rLw2zXN&yS7uPqU@3"); // 32-byte key for AES-256
    //        aes.IV = iv;

    //        using (MemoryStream ms = new MemoryStream(buffer))
    //        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
    //        using (StreamReader reader = new StreamReader(cs))
    //        {
    //            return reader.ReadToEnd();
    //        }
    //    }
    //}
}
