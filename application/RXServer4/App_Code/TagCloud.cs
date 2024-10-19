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
using System.Text;

/// <summary>
/// Summary description for TagCloud
/// </summary>
public class TagCloud
{
    static String class_name = "TagCloud";
	public TagCloud()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private static String GetCloudData(DataTable tagData, string cloudTemplate)
    {
        String function_name = "GetCloudData";
        try
        {
            // Check the input data
            if (!tagData.Columns.Contains("tag"))
                throw new Exception("Expected column 'tag' is missing");

            if (!tagData.Columns.Contains("count"))
                throw new Exception("Expected column 'count' is missing");


            // Lets get cracking
            StringBuilder outputBuffer = new StringBuilder();
            double max = 0;
            double min = 0;

            // Use Compute to get the min and max counts
            double.TryParse(tagData.Compute("min(count)", null).ToString(), out min);
            double.TryParse(tagData.Compute("max(count)", null).ToString(), out max);

            // Loop through the data, generate the tag cloud
            foreach (DataRow row in tagData.Rows)
            {
                // work out the weight
                double weightPercent = (double.Parse(row["count"].ToString()) / max) * 100;
                int weight = 0;

                if (weightPercent >= 99)
                {
                    //heaviest
                    weight = 1;
                }
                else if (weightPercent >= 70)
                {
                    weight = 2;
                }
                else if (weightPercent >= 40)
                {
                    weight = 3;
                }
                else if (weightPercent >= 20)
                {
                    weight = 4;
                }
                else if (weightPercent >= 3)
                {
                    //weakest
                    weight = 5;
                }
                else
                {
                    // use this to filter out all low hitters
                    weight = 0;
                }

               
                // don't return data for unweighted itemsHttpContext.Current.Server.HtmlDecode(data)
                if (weight > 0)
                    outputBuffer.Append(cloudTemplate.Replace("$weight$", weight.ToString()).Replace("$tag$", row["tag"].ToString()).Replace("$urlencodetag$", HttpContext.Current.Server.UrlDecode(row["tag"].ToString())));
            }

            return outputBuffer.ToString();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return "";
        }
    }
    protected static DataTable GetTagData()
    {
        String function_name = "GetTagData";
        try
        {
            // Create a table to store our test data in
            DataTable tagData = new DataTable("tags");

            // The two required columns are "tag" and "count"
            tagData.Columns.Add(new DataColumn("tag"));
            tagData.Columns.Add(new DataColumn("count", typeof(Int32)));

            DataRow newRow;

            String sql = "SELECT COUNT(t1.obd_varchar2) AS 'total', t1.obd_varchar2 AS 'tag', t1.obd_varchar1 AS 'id'";
            sql += "FROM obd_objectdata AS t1, obd_objectdata AS t2 ";
            sql += "WHERE t1.obd_alias LIKE 'Tags%' ";
            sql += "AND t1.obd_varchar1 = t2.obd_id ";
            sql += "AND t1.obd_deleted = 0 ";
            sql += "AND t2.obd_deleted = 0 ";
            sql += "AND t2.obd_varchar20 LIKE 'approved' ";
            sql += "AND t2.obd_varchar10 LIKE 'true' ";
            sql += "GROUP BY t1.obd_varchar2 ";
            sql += "ORDER BY total DESC ";

            DataSet dataSet = new DataSet("dataSet");
            dataSet = RXServer.Data.Direct.GetDataSet(sql);

            if (dataSet.Tables.Count > 0)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    DataTable myDataTable = dataSet.Tables[0];
                    foreach (DataRow dRow in myDataTable.Rows)
                    {
                        newRow = tagData.Rows.Add();
                        newRow["tag"] = dRow["tag"].ToString();
                        newRow["count"] = Convert.ToInt32(dRow["total"].ToString());
                    }
                }
            }

            return tagData;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return null;
        }
    }

    protected static void AddTagg(string tagname)
    {

    }
    protected static void CheckTagg(string tagname, Int32 id)
    {

    }
    public static String GetCloud(String Id, String browseUrl)
    {
        String function_name = "GetCloud";
        try
        {
            return GetCloudData(GetTagData(), "<a class='weight$weight$' href='" + browseUrl + "?tag=$urlencodetag$'>$tag$</a> ");
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }
    public static String GetFlashCloud(String swfFile,Int32 width, Int32 height)
    {
        String function_name = "GetFlashCloud";
        try
        {




            String html = "";

            html += "<div id=\"flashcontent\">This will be shown to users with no Flash or Javascript.</div>";

            html += "<script type=\"text/javascript\">";
            html += " var so = new SWFObject(\"" + swfFile + "\", \"tagcloud\", \"" + width + "\", \"" + height + "\", \"7\", \"#ffffff\");";
            html += "    so.addParam(\"wmode\", \"transparent\");";
            html += "    so.addVariable(\"tcolor\", \"0x333333\");";
            html += "    so.addVariable(\"tspeed\", \"100\");";
            html += "    so.addVariable(\"distr\", \"true\");";
            html += "    so.write(\"flashcontent\");";
            html += "</script>";

            return html;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }
    protected static void SaveTagData()
    {
        String function_name = "SaveTagData";
        try
        {
            //String sql = "SELECT COUNT(CONVERT(varchar(250), obd_varchar2)) AS 'total', CONVERT(varchar(250), obd_varchar2) AS 'tag' FROM obd_objectdata WHERE obd_alias LIKE 'Tags%' AND obd_deleted = 0 GROUP BY CONVERT(varchar(250), obd_varchar2)";

            //DataSet dataSet = new DataSet("dataSet");
            //dataSet = RXServer.Data.Direct.GetDataSet(sql);

            //if (dataSet.Tables.Count > 0)
            //{
            //    DataTable table;
            //    table = dataSet.Tables[0];

            //    if (dataSet.Tables[0].Rows.Count > 0)
            //    {
            //        DataTable myDataTable = dataSet.Tables[0];
            //        foreach (DataRow dRow in myDataTable.Rows)
            //        {

            //            dRow["tag"].ToString();
            //            Convert.ToInt32(dRow["total"].ToString());
            //        }
            //    }
            //}
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
