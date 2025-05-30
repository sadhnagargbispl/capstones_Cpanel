using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShoppingRedirect : System.Web.UI.Page
{
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    string constr1 = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["IDNO"] == null)
            {
                Response.Redirect("https://shopping.capstones.in/");
            }
            else
            {
                try
                {
                    //string formPostText = "";
                    //formPostText = "<form method=\"POST\" action=\"https://shopping.capstones.in/members/index.php\" name=\"frm2Post\">";
                    //formPostText += "<input type=\"hidden\" name=\"token\" value=\"bce077f7ce2069e73a6d1c99a4e9f4ff\" />";
                    //formPostText += "<input type=\"hidden\" name=\"mod\" value=\"interLogin\" />";
                    //formPostText += "<input type=\"hidden\" name=\"userid\" value=\"" + Session["IDNO"].ToString() + "\" />";
                    //formPostText += "<input type=\"hidden\" name=\"password\" value=\"" + Session["MemPassw"].ToString() + "\" /> ";
                    //formPostText += "<script type=\"text/javascript\">document.frm2Post.submit();</script>";
                    //formPostText += "</form>";
                    //Response.Write(formPostText);
                    string formPostText = "";
                    string UserName = Encrypt(Session["IDNO"].ToString());
                    string Password = Encrypt(Session["MemPassw"].ToString());

                    formPostText = @"<form method=""POST"" action=""https://shop.capstones.in/Account/DirectLogin"" name=""frm2Post"">" +
                                   " <input type=\"hidden\" name=\"LoginId\" value=\"" + UserName + "\" />" +
                                   " <input type=\"hidden\" name=\"Password\" value=\"" + Password + "\" />" +
                                   " <input type=\"hidden\" name=\"Token\" value=\"9w8gfOY/3amGrCPm1cOAhscvtuPoPqHombKOhTRRhRjDaSj3ppzsZG/gZgl1DnU2\" />" +
                                   " <script type=\"text/javascript\">document.frm2Post.submit();</script></form>";

                    Response.Write(formPostText);
                }
                catch (Exception ex)
                {
                    // Handle exception (if needed, log it or show a message)
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
    public string Encrypt(string plainText)
    {
        string completeUrl = "https://shop.capstones.in/Account/Encrypt?plainText=" + plainText;
        System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072; // TLS 1.2

        HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(completeUrl);
        request1.ContentType = "application/json";
        request1.Method = "GET";

        using (HttpWebResponse httpWebResponse = (HttpWebResponse)request1.GetResponse())
        using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
        {
            string responseString = reader.ReadToEnd();
            return responseString;
        }
    }
    public string Decrypt(string cipherText)
    {
        byte[] iv = new byte[16]; // 16-byte IV for AES
        byte[] buffer = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes("Y$8tM9d#k4KqpV^rLw2zXN&yS7uPqU@3"); // 32-byte key for AES-256
            aes.IV = iv;

            using (MemoryStream ms = new MemoryStream(buffer))
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
            using (StreamReader reader = new StreamReader(cs))
            {
                return reader.ReadToEnd();
            }
        }
    }
    //public string Encrypt(string plainText)
    //{
    //    string completeUrl = "https://store.megamart.ai/Account/Encrypt?plainText=" + plainText;
    //    string customerOTPmessage = string.Empty;
    //    string amount = string.Empty;

    //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2
    //    HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(completeUrl);
    //    request1.ContentType = "application/json";
    //    request1.Method = "GET";

    //    using (HttpWebResponse httpWebResponse = (HttpWebResponse)request1.GetResponse())
    //    {
    //        using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
    //        {
    //            string responseString = reader.ReadToEnd();
    //            return responseString;
    //        }
    //    }
    //}
    //public string Decrypt(string cipherText)
    //{
    //    // AES decryption logic
    //    byte[] iv = new byte[16]; // 16-byte IV for AES
    //    byte[] buffer = Convert.FromBase64String(cipherText);

    //    using (Aes aes = Aes.Create())
    //    {
    //        aes.Key = Encoding.UTF8.GetBytes("Y$8tM9d#k4KqpV^rLw2zXN&yS7uPqU@3"); // 32-byte key for AES-256
    //        aes.IV = iv;

    //        using (MemoryStream ms = new MemoryStream(buffer))
    //        {
    //            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
    //            {
    //                using (StreamReader reader = new StreamReader(cs))
    //                {
    //                    return reader.ReadToEnd();
    //                }
    //            }
    //        }
    //    }
    //}
}
