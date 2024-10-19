using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for encodeemails
/// </summary>
public class EE
{
	public EE()
	{
	}

    public static string EncodeEmails(string html)
    {
        try
        {
            foreach (Match match in _Regex.Matches(html))
            {
                html = html.Replace(match.Value, Encode(match.Value));
            }
            return html;
        }
        catch
        {
            string s = "s";
            return html;
        }
    }

    private static Regex _Regex = new Regex("(mailto:|)(\\w+[a-zA-Z0-9.-_]*)@(\\w+).(\\w+)");
    private static Random _Random = new Random();

    private static string Encode(string value)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < value.Length; i++)
        {
            if (_Random.Next(2) == 1)
                sb.AppendFormat("&#{0};", Convert.ToInt32(value[i]));
            else
                sb.Append(value[i]);
        }

        return sb.ToString();
    }
}
