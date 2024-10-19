using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Forum
/// </summary>
public class Forum
{

    static String class_name = "Forum";
	public Forum()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static Int32 GetTotalForumThreads(Int32 modId, Int32 catId)
    {
        String function_name = "GetTotalForumThreads";
        try
        {
            String sql = "Forum";

            if(modId > 0)
            {
                sql += "_" + modId.ToString();
            }            
            if(catId > 0)
            {
                sql += "_" + catId.ToString();
            }

            RXServer.Modules.Base.List l = new RXServer.Modules.Base.List(sql);
            return l.Count;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return 0;
        }

    }
    public static Int32 GetTotalForumPosts(Int32 modId, Int32 catId, Int32 threadId)
    {
        String function_name = "GetTotalForumPosts";
        try
        {
            Int32 total = 0;

            String sql = "Forum";

            if (modId > 0)
            {
                sql += "_" + modId.ToString();
            }
            if (catId > 0)
            {
                sql += "_" + catId.ToString();
            }
            else
            {
                sql += "_";
            }
            if (threadId > 0)
            {
                sql += "_" + threadId.ToString();
            }
            else
            {
                sql += "_";
            }


            String count = "SELECT COUNT(obd_id) as total FROM obd_objectdata WHERE obd_alias LIKE '" + sql +"%' AND obd_deleted = 0";

            DataSet dataSet = new DataSet("dataSet");
            dataSet = RXServer.Data.Direct.GetDataSet(count);

            Int32.TryParse(dataSet.Tables[0].Rows[0][0].ToString(), out total);

            return total;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return 0;
        }

    }
    public static String GetLastPostInfo(Int32 modId, Int32 catId, Int32 threadId)
    {
        String function_name = "GetLastPostInfo";
        try
        {
            Int32 total = 0;

            String sql = "Forum";

            if (modId > 0)
            {
                sql += "_" + modId.ToString();
            }
            if (catId > 0)
            {
                sql += "_" + catId.ToString();
            }
            else
            {
                sql += "_";
            }
            if (threadId > 0)
            {
                sql += "_" + threadId.ToString();
            }
            else
            {
                sql += "_";
            }


            String count = "SELECT * FROM obd_objectdata WHERE obd_alias LIKE '" + sql + "%' AND obd_deleted = 0 ORDER BY obd_id DESC";

            DataSet dataSet = new DataSet("dataSet");
            dataSet = RXServer.Data.Direct.GetDataSet(count);

            String info = "";

            if (dataSet.Tables.Count != 0)
            {
                if (dataSet.Tables[0].Rows.Count != 0)
                {
                    Int32 lastpostId = 0;
                    Int32.TryParse(dataSet.Tables[0].Rows[0][0].ToString(), out lastpostId);

                    RXServer.Modules.Base.List.Item i = new RXServer.Modules.Base.List.Item(lastpostId);

                    DateTime stamp;
                    DateTime.TryParse(i.Value28, out stamp);
                    info += "<a href='Default.aspx?PagId=" + ConfigurationManager.AppSettings["MembersPage"].ToString() + "&amp;v1=" + RXServer.Auth.Users.GetUserId(System.Web.HttpContext.Current.Server.HtmlDecode(i.Value26)) + "'> " + System.Web.HttpContext.Current.Server.HtmlDecode(i.Value26) + "</a> " + stamp.ToString("HH:mm") + ", " + stamp.Day + " " + RXMali.GetShortMonthName(stamp.Month.ToString()) + " " + stamp.Year;
                }

            }

            return info;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return "";
        }

    }
    public static String GetLastPostInfo2(Int32 modId, Int32 catId, Int32 threadId)
    {
        String function_name = "GetLastPostInfo2";
        try
        {
            Int32 total = 0;

            String sql = "Forum";

            if (modId > 0)
            {
                sql += "_" + modId.ToString();
            }
            if (catId > 0)
            {
                sql += "_" + catId.ToString();
            }
            else
            {
                sql += "_";
            }
            if (threadId > 0)
            {
                sql += "_" + threadId.ToString();
            }
            else
            {
                sql += "_";
            }


            String count = "SELECT * FROM obd_objectdata WHERE obd_alias LIKE '" + sql + "%' AND obd_deleted = 0 ORDER BY obd_id DESC";

            DataSet dataSet = new DataSet("dataSet");
            dataSet = RXServer.Data.Direct.GetDataSet(count);

            String info = "";

            if (dataSet.Tables.Count != 0)
            {
                if (dataSet.Tables[0].Rows.Count != 0)
                {
                    Int32 lastpostId = 0;
                    Int32.TryParse(dataSet.Tables[0].Rows[0][0].ToString(), out lastpostId);

                    RXServer.Modules.Base.List.Item i = new RXServer.Modules.Base.List.Item(lastpostId);

                    DateTime stamp;
                    DateTime.TryParse(i.Value28, out stamp);
                    info += "<a href='Default.aspx?PagId=" + ConfigurationManager.AppSettings["MembersPage"].ToString() + "&amp;v1=" + RXServer.Auth.Users.GetUserId(System.Web.HttpContext.Current.Server.HtmlDecode(i.Value26)) + "' style='font-size:10px;'> " + System.Web.HttpContext.Current.Server.HtmlDecode(i.Value26) + "</a><br /> " + stamp.ToString("HH:mm") + ", " + stamp.Day + " " + RXMali.GetShortMonthName(stamp.Month.ToString()) + " " + stamp.Year;
                }

            }

            return info;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return "";
        }

    }
    public static void AddVisit(Int32 obd_id)
    {
        String function_name = "AddVisit";
        try
        {
            Int32 visit = 0;

            RXServer.Modules.Base.List.Item i = new RXServer.Modules.Base.List.Item(obd_id);

            Int32.TryParse(i.Value29, out visit);
            visit++;
            i.Value29 = visit.ToString();
            i.Save();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
    public static void UpdateThreadTime(Int32 threadId, string time)
    {
        String function_name = "UpdateThreadTime";
        try
        {
            Int32 visit = 0;

            RXServer.Modules.Base.List.Item i = new RXServer.Modules.Base.List.Item(threadId);
            i.Value30 = time;
            i.Save();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public static void UpdateCategoryTime(Int32 catId, string time)
    {
        String function_name = "UpdateCategoryTime";
        try
        {
            Int32 visit = 0;

            RXServer.Modules.Base.List.Item i = new RXServer.Modules.Base.List.Item(catId);
            i.Value30 = time;
            i.Save();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

}



