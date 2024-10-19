using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Net.Mail;

/// <summary>
/// Summary description for RXmali
/// </summary>
public class RXMali
{
    static String class_name = "RXMali";
    public RXMali()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool IsEmail(string Email)
    {
        String function_name = "IsEmail";
        try
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
                return (true);
            else
                return (false);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    public static bool IsUrl(string Url)
    {
        String function_name = "IsUrl";
        try
        {
            string strRegex = "^(https?://)"
            + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
            + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
            + "|" // allows either IP or domain
            + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
            + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // second level domain
            + "[a-z]{2,6})" // first level domain- .com or .museum
            + "(:[0-9]{1,4})?" // port number- :80
            + "((/?)|" // a slash isn't required if there is no file name
            + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(Url))
                return (true);
            else
                return (false);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    public static string GetLastUrl(String url)
    {
        String function_name = "GetLastUrl";
        try
        {
            char[] delimiterChars = { '/' };

            string[] words = url.Split(delimiterChars);

            Int32 i = words.Length - 1;

            return words[i];
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static string GetShortDayName(String day)
    {
        String function_name = "GetShortDayName";
        try
        {
            switch (day)
            {
                case "Monday":
                    return "Mån";
                    break;
                case "Tuesday":
                    return "Tis";
                    break;
                case "Wednesday":
                    return "Ons";
                    break;
                case "Thursday":
                    return "Tor";
                    break;
                case "Friday":
                    return "Fre";
                    break;
                case "Saturday":
                    return "Lör";
                    break;
                case "Sunday":
                    return "Sön";
                    break;
                default:
                    return "";
                    break;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static string GetShortMonthName(String month)
    {
        String function_name = "GetShortMonthName";
        try
        {
            switch (month)
            {
                case "1":
                    return "Jan";
                    break;
                case "2":
                    return "Feb";
                    break;
                case "3":
                    return "Mar";
                    break;
                case "4":
                    return "Apr";
                    break;
                case "5":
                    return "Maj";
                    break;
                case "6":
                    return "Jun";
                    break;
                case "7":
                    return "Jul";
                    break;
                case "8":
                    return "Aug";
                    break;
                case "9":
                    return "Sep";
                    break;
                case "10":
                    return "Okt";
                    break;
                case "11":
                    return "Nov";
                    break;
                case "12":
                    return "Dec";
                    break;

                default:
                    return "";
                    break;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static string GetMonthName(int month)
    {
        String function_name = "GetMonthName";
        try
        {
            string monthname;

            switch (month)
            {
                case 1:
                    monthname = "Januari";
                    break;

                case 2:
                    monthname = "Februari";
                    break;

                case 3:
                    monthname = "Mars";
                    break;

                case 4:
                    monthname = "April";
                    break;

                case 5:
                    monthname = "Maj";
                    break;

                case 6:
                    monthname = "Juni";
                    break;

                case 7:
                    monthname = "Juli";
                    break;

                case 8:
                    monthname = "Augusti";
                    break;

                case 9:
                    monthname = "September";
                    break;

                case 10:
                    monthname = "Oktober";
                    break;

                case 11:
                    monthname = "November";
                    break;

                case 12:
                    monthname = "December";
                    break;

                default:
                    monthname = "Månad";
                    break;
            }

            return monthname;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static string GetDomainUrl(String url)
    {
        String function_name = "GetDomainUrl";
        try
        {
            char[] delimiterChars = { '/' };

            string[] words = url.Split(delimiterChars);

            String newpath = "";

            for (int i = 0; i < words.Length - 1; i++)
            {
                newpath += words[i] + "/";
            }

            return newpath;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static string GetFriendlyUrl(String pagename, String friendlyname, int paglevel, int pagid)
    {
        String function_name = "GetFriendlyUrl";
        try
        {
            string url = "";

            if (RXMali.TrimURL(friendlyname) == "")
            {
                url = RXMali.TrimURL(pagename);
            }
            else
            {
                url = RXMali.TrimURL(friendlyname);
            }


            url = CheckFriendlyUrlOnLevel(url, paglevel, pagid);
           

            return url;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static string CheckFriendlyUrlOnLevel(String url, int paglevel, int pagid)
    {
        String function_name = "CheckFriendlyUrlOnLevel";
        try
        {
            Boolean valid = true;

            String sql = "SELECT pag_id ";
            sql += "FROM pag_pages ";
            sql += "WHERE pag_alias LIKE '" + url + "' ";
            sql += "AND pag_id <> " + pagid + " ";
            sql += "AND pag_deleted = 0 ";

            DataSet dataSet = new DataSet("dataSet");
            dataSet = RXServer.Data.Direct.GetDataSet(sql);

            if (dataSet.Tables.Count > 0)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    DataTable myDataTable = dataSet.Tables[0];
                    foreach (DataRow dRow in myDataTable.Rows)
                    {
                        RXServer.Modules.Menu.Item m = new RXServer.Modules.Menu.Item(Convert.ToInt32(dRow["pag_id"].ToString()));
                        if (m.Level.Equals(paglevel))
                        {
                            valid = false;                            
                        }
                    }
                }
            }

            if (valid)
            {
                return url;
            }
            else
            {
                url = url + "-";
                return CheckFriendlyUrlOnLevel(url, paglevel, pagid);
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }
    
    public static string TrimURL(string url)
    {
        String function_name = "TrimURL";
        try
        {
            // first trim the raw string
            string safe = url.Trim();

            safe = safe.ToLower();

            safe = safe.Replace('å', 'a');
            safe = safe.Replace('ä', 'a');
            safe = safe.Replace('ö', 'o');

            // replace spaces with hyphens
            safe = safe.Replace(" ", "-").ToLower();

            // replace any 'double spaces' with singles
            if (safe.IndexOf("--") > -1)
                while (safe.IndexOf("--") > -1)
                    safe = safe.Replace("--", "-");

            // trim out illegal characters
            safe = Regex.Replace(safe, "[^a-z0-9\\-]", "");

            return safe;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return "";
        }
    }

    public static long DirSize(DirectoryInfo d)
    {
        String function_name = "DirSize";
        try
        {
            long Size = 0;

            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return 0;
        }

    }

    public static String GetFLVCode(string flashFile, string flvpath, string flashId, int width, int height)
    {
        String function_name = "GetFLVCode";
        try
        {
            String code = "";

            code += "<div><script type=\"text/javascript\">";
            code += "var params = { wmode: 'transparent', quality: 'high', allowfullscreen: 'true' };";
            code += "var flashvars = { file: '" + flvpath + "'};";
            code += "var attributes = {};";

            code += "swfobject.embedSWF(\"" + flashFile + "\", \"" + flashId + "\", \"" + width + "\", \"" + height + "\", \"9.0.0\",\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "swf/expressInstall.swf\",flashvars,params,attributes);";
            code += "</script></div>";

            code += "<div id=\"" + flashId + "\"><p><a href=\"http://www.macromedia.com/go/getflashplayer\">Get the Flash Player</a> to see this media.</p></div>";

            return code;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static String GetGalleryCode(string flashFile, string flashId, int width, int height, string xml)
    {
        String function_name = "GetGalleryCode";
        try
        {
            String code = "";

            code += "<div><script type=\"text/javascript\">";
            code += "var params = {wmode: 'transparent',allowfullscreen: 'true'  };"; //wmode: 'transparent', quality: 'high'
            code += "var flashvars = { file: '" + xml + "',width: '" + width + "', height: '" + height + "', backcolor: 'FFFFFF', screencolor: 'FFFFFF', transition: 'bgfade', thumbsinplaylist: 'true', autostart : 'false' };";
            code += "var attributes = {};";

            code += "swfobject.embedSWF(\"" + flashFile + "\", \"" + flashId + "\", \"" + width + "\", \"" + height + "\", \"9.0.0\",\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix()+ "swf/expressInstall.swf\",flashvars,params,attributes);";
            code += "</script></div>";

            code += "<div id=\"" + flashId + "\"><p><a href=\"http://www.macromedia.com/go/getflashplayer\">Get the Flash Player</a> to see this media.</p></div>";

            return code;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static String GetYouTubeCode(string url, int width, int height)
    {
        String function_name = "GetYouTubeCode";
        try
        {
            String code = "";
            url = url.Replace("watch?v=", "v/");
            url += "&hl=en&fs=1";

            code = "<object width=\"" + width + "\" height= \"" + height + "\"><param name=\"movie\" value=\"" + url + "\"></param><param name=\"allowFullScreen\" value=\"true\"></param><param name=\"wmode\" value=\"transparent\"></param><param name=\"allowscriptaccess\" value=\"always\"></param><embed src=\"" + url + "\" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" allowfullscreen=\"true\" wmode=\"transparent\" width=\"" + width + "\" height=\"" + height + "\"></embed></object>";
            return code;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static String GetFlashCode(string flashFile, string flashId, int width, int height)
    {
        String function_name = "GetFlashCode";
        try
        {
            String code = "";

            code += "<div><script type=\"text/javascript\">";
            code += "var params = { wmode: 'transparent', quality: 'high'};";
            code += "var flashvars = {};";
            code += "var attributes = {};";

            code += "swfobject.embedSWF(\"" + flashFile + "\", \"" + flashId + "\", \"" + width + "\", \"" + height + "\", \"9.0.0\",\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() +"swf/expressInstall.swf\",flashvars,params,attributes);";
            code += "</script></div>";

            code += "<div id=\"" + flashId + "\"><p><a href=\"http://www.macromedia.com/go/getflashplayer\">Get the Flash Player</a> to see this player.</p></div>";

            return code;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static String GetXMLNode(string section)
    {
        String function_name = "GetXMLNode";
        try
        {
            String lng = "Swedish";

            string lng_path = System.Web.HttpContext.Current.Server.MapPath("~/Language/");

            XmlDocument doc = new XmlDocument();

            doc.Load(lng_path + lng + ".xml");

            XmlNode node = doc.SelectSingleNode("Translations/" + section + "/text()");
            if (node != null)
            {
                return node.Value.Replace("[newline]", "<br />");
            }
            else
            {
                return ("XMLError in: " + section);
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }
    public static String GetXMLHelpNode(string section)
    {
        String function_name = "GetXMLHelpNode";
        try
        {
            String file = "Help";

            string file_path = System.Web.HttpContext.Current.Server.MapPath("~/Language/");

            XmlDocument doc = new XmlDocument();

            doc.Load(file_path + file + ".xml");

            XmlNode node = doc.SelectSingleNode("Translations/" + section + "/text()");
            if (node != null)
            {
                string n = node.Value;
                n = n.Replace("[newline]", "<br />");
                n = n.Replace("[img]", "<img src='");
                n = n.Replace("[/img]", "' />");
                return n;
            }
            else
            {
                return ("XMLError in: " + section);
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static string Substring(string text, Int32 length)
    {
        String function_name = "Substring";
        try
        {
            if (text.Length > length)
            {
                text = text.Substring(0, length) + "...";
            }

            return text;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }

    public static Image ScaleFixedImage(Image imgPhoto, int Width, int Height)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = System.Convert.ToInt16((Width -
                          (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = System.Convert.ToInt16((Height -
                          (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height,
                          PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.White);
        grPhoto.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }
    public static Image ScaleFixedWidthImage(Image imgPhoto, int Width)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercentW = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        int destWidth = Width;
        int destHeight = (int)(sourceHeight * nPercentW);

        Bitmap bmPhoto = new Bitmap(Width, destHeight,
                          PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.White);
        grPhoto.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }

    public static Boolean CheckIfRDFFeed(string url)
    {
        String function_name = "CheckIfRDFFeed";
        try
        {
            if (RXMali.IsUrl(url))
            {

                XmlReader reader;
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ProhibitDtd = true;

                using (reader = XmlReader.Create(url, settings))
                {
                    XmlDocument doc = new XmlDocument();


                    try
                    {
                        doc.Load(reader);

                        if (doc.DocumentElement.LocalName == "RDF")
                        {
                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return false;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }
    public static string GetGravatarURL(string email, string size, string default_img)
    {
        String function_name = "GetGravatarURL";
        try
        {
            return (string.Format("http://www.gravatar.com/avatar/{0}?s={1}&default=" + default_img + "&r=PG", EncryptMD5(email), size));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return "";
        }


    }
    private static string EncryptMD5(string Value)
    {
        String function_name = "EncryptMD5";
        try
        {

            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] valueArray = System.Text.Encoding.ASCII.GetBytes(Value);

            valueArray = md5.ComputeHash(valueArray);

            string encrypted = "";

            for (int i = 0; i < valueArray.Length; i++)

                encrypted += valueArray[i].ToString("x2").ToLower();

            return encrypted;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return "";
        }

    }

    public static Boolean SendMail(string mailText, string mailSubject, string mailTo, string mailSender, string mailSenderName, string mailServer, string mailPort)
    {
        String function_name = "SendMail";
        try
        {

            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(mailSender, mailSenderName);

            char[] delimiterChars = { ' ', ';', ',' };
            string[] mails = mailTo.ToString().Split(delimiterChars);

            // Hämtar alla mailto adresser

            foreach (string m in mails)
            {
                if (RXMali.IsEmail(m))
                {
                    mailMsg.To.Add(new MailAddress(m));
                }
            }

            mailMsg.Subject = mailSubject;
            mailMsg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");

            System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString
            (System.Text.RegularExpressions.Regex.Replace(mailText, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(mailText, null, "text/html");

            mailMsg.AlternateViews.Add(plainView);
            mailMsg.AlternateViews.Add(htmlView);

            // Smtp configuration
            SmtpClient smtp = new SmtpClient();
            smtp.Host = mailServer;
            smtp.Port = Convert.ToInt32(mailPort);
            smtp.Send(mailMsg);

            return true;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

	public static Int32 GetModelId(Int32 sitId, Int32 pagId, Int32 modId, String masterPageFile)
	{
		RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(sitId, pagId, modId);
		String conPane = sm.ContentPane;

		if (RXMali.GetLastUrl(masterPageFile) == "Template1.master")
		{
			return 4;
		}
		else if (RXMali.GetLastUrl(masterPageFile) == "Template2.master")
		{
			return 3;
		}
		else if (RXMali.GetLastUrl(masterPageFile) == "Template3.master")
		{
			if (conPane == "ContentPane1")
			{
				return 2;
			}
			else
			{
				return 1;
			}
		}
		else if (RXMali.GetLastUrl(masterPageFile) == "Template4.master")
		{
			if (conPane == "ContentPane1")
			{
				return 1;
			}
			else
			{
				return 3;
			}
		}
		else if (RXMali.GetLastUrl(masterPageFile) == "Template5.master")
		{
			return 4;
		}
		else if (RXMali.GetLastUrl(masterPageFile) == "Template6.master")
		{
			if (conPane == "ContentPane1")
			{
				return 3;
			}
			else if (conPane == "ContentPane2")
			{
				return 2;
			}
			else
			{
				return 1;
			}
		}
		else if (RXMali.GetLastUrl(masterPageFile) == "Template7.master")
		{
			if (conPane == "ContentPane1")
			{
				return 3;
			}
			else if (conPane == "ContentPane2")
			{
				return 1;
			}
			else
			{
				return 2;
			}
		}
		else if (RXMali.GetLastUrl(masterPageFile) == "Template8.master")
		{
			if (conPane == "ContentPane1")
			{
				return 3;
			}
			else
			{
				return 1;
			}
		}
		else
		{
			return 4;
		}
	}

    public static Int32 GetModelSize(String model)
    {
        switch (model)
        {
            case "1":
                return 215;

            case "2":
                return 430;

            case "3":
                return 665;

            case "4":
                return 900;

            default:
                return 215;
        }
    }
    public static Int32 GetMediaHeight(String model)
    {
        switch (model)
        {
            case "1":
                return 220;

            case "2":
                return 220;

            case "3":
                return 220;

            case "4":
                return 220;

            default:
                return 0;
        }
    }
    //public static String GetModelName(String model)
    //{
    //    switch (model)
    //    {
    //        case "1":
    //            return "X-Small";

    //        case "2":
    //            return "Small";

    //        case "3":
    //            return "Medium";

    //        case "4":
    //            return "Large";

    //        case "5":
    //            return "X-Large";

    //        case "6":
    //            return "XX-Large";

    //        case "0":
    //            return "Divider";

    //        default:
    //            return "X-Small";

    //    }
    //}

    

}
