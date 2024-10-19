using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using Telerik;
using Telerik.Web.UI;

public partial class Modules_User_UserList_UserList : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_User_UserList_UserList";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            bindData();

            this.lblSort.Text = "Sortera: ";
            if (!Page.IsPostBack)
            {
                this.ddlSort.Items.Add(new ListItem("Namn stigande", "asc"));
                this.ddlSort.Items.Add(new ListItem("Namn fallande", "desc"));

                if (Session["cb_orderby"] != null)
                {
                    this.ddlSort.SelectedValue = Session["cb_orderby"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    private void bindData()
    {
        String function_name = "bindData";
        try
        {
            bindUsers();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void bindUsers()
    {
        String function_name = "bindUsers";
        try
        {
            string menu = "";

            Int32 limit = 10;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index / limit) + 1;
            Int32 pages = 0;

            String sql = "SELECT * FROM usr_users AS u, uro_usersroles AS r ";
            sql += "WHERE u.usr_deleted = 0 ";
            sql += "AND r.uro_deleted = 0 ";
            sql += "AND u.usr_id = r.usr_id ";
            sql += "AND u.sta_id = 1 ";
            //sql += "AND r.rol_id = 2 ";

            if (Session["cb_orderby"] != null)
            {
                //Response.Write(Session["HM_orderby"].ToString());
                if (Session["cb_orderby"].ToString() == "desc")
                {
                    sql += "ORDER BY usr_loginname desc ";
                }
                else
                {
                    sql += "ORDER BY usr_loginname asc ";
                }
            }
            else
            {
                sql += "ORDER BY usr_loginname ";
            }
            string sqlex = "";
            sqlex += "LIMIT " + index + " , " + limit;
            
            DataSet dataSet2 = new DataSet("dataSet");
            dataSet2 = RXServer.Data.Direct.GetDataSet(sql);

            if (dataSet2.Tables.Count > 0)
            {
                total = dataSet2.Tables[0].Rows.Count;
            }

            sql = sql + sqlex;

            DataSet dataSet = new DataSet("dataSet");
            dataSet = RXServer.Data.Direct.GetDataSet(sql);

            //if (dataSet.Tables.Count > 0)
            //{
            //    total = dataSet.Tables[0].Rows.Count;
            //}

            if (dataSet.Tables.Count > 0)
            {
                DataTable table;
                table = dataSet.Tables[0];

                if (dataSet.Tables[0].Rows.Count > 0)
                {

                    menu = "<div id=\"submenu2\">";
                    menu += "<table cellspacing='0' cellpadding='0'>";

                    DataTable myDataTable = dataSet.Tables[0];
                    foreach (DataRow dRow in myDataTable.Rows)
                    {
                        menu += "<tr>";
                        if (RXServer.Web.RequestValues.v1 == dRow["usr_id"].ToString())
                        {
                            menu += "<td class='menu3_left_on'></td>";
                            String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
                            menu += "<td class='menu3_middle_on'><a href='" + path + "Default.aspx?PagId=" + RXServer.Web.RequestValues.PagId + "&amp;v1=" + dRow["usr_id"].ToString() + "' class='menu3_on'>" + dRow["usr_loginname"].ToString() + "";
                            if (dRow["rol_id"].ToString() == "1")
                            {
                                menu += " (admin)";
                            }
                            menu += "</a></td>";
                            menu += "<td class='menu3_right_on'></td>";
                        }
                        else
                        {
                            menu += "<td class='menu3_left_off'></td>";
                            String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
                            menu += "<td class='menu3_middle_off'><a href='" + path + "Default.aspx?PagId=" + RXServer.Web.RequestValues.PagId + "&amp;v1=" + dRow["usr_id"].ToString() + "' class='menu3_off'>" + dRow["usr_loginname"].ToString() + "";
                            if(dRow["rol_id"].ToString() == "1")
                            {
                                menu += " (admin)";
                            }

                            menu += "</a></td>";
                            menu += "<td class='menu3_right_off'></td>";
                        }
                        menu += "</tr>";
                        menu += "<tr><td colspan='3' class='menu3_divider'>&nbsp;</td></tr>";         
                    }

                    menu += "</table></div>";
                }

                #region Paging

                if (total > limit)
                {
                    String Url = Request.Url.ToString();
                    double t1, t2;
                    t1 = total;
                    t2 = limit;
                    pages = (int)Math.Ceiling(t1 / t2);

                    //html = "";
                    Url = Url.Replace("&amp;Index=" + index, "");
                    Url = Url.Replace("?Index=" + index, "");
                    Url = Url.Replace("&Index=" + index, "");

                    String index_url = "";

                    if (Url.Contains('?'))
                    {
                        index_url = "&amp;Index=";
                    }
                    else
                    {
                        index_url = "?Index=";
                    }

                    menu += "<div style=\"position:relative; float: left; width: 140px; height: 27px; \">";
                    menu += "<table cellspacing='0' cellpadding='0' style='width: 100%;'><tr>";
                    menu += "<td colspan='10' style='text-align: right'><div style='position:relative; padding: 0px; margin: 0px; float: right'><table cellspacing='2' cellpadding='3'><tr>";
                    menu += "<td>~ Sida " + page + "  av " + pages + ":</td>";

                    if (page > 1)
                    {
                        menu += "<td style='width:5px;' class='hm_paging_td_off'><a href='" + Url + index_url + (index - limit) + "' class='hm_paging_on'>«</a></td>";
                    }
                    else
                    {
                        menu += "<td style='width:5px;'>&nbsp;</td>";
                    }

                    if ((page) > 3)
                    {
                        menu += "<td><a href='" + Url + index_url + 0 + "' class='paging_on'>1</a></td><td>...</td>";
                    }

                    for (int i = 0; i < pages; i++)
                    {
                        if (i < page + 2 && i > (page - 4))
                        {
                            Int32 ix = i * limit;
                            if ((i + 1) == page)
                            {
                                menu += "<td class='hm_paging_td_on'>" + (i + 1) + "</td>";
                            }
                            else
                            {
                                menu += "<td class='hm_paging_td_off'><a href='" + Url + index_url + ix + "' class='hm_paging_on'>" + (i + 1) + "</a></td>";
                            }
                        }
                    }
                    if ((page + 2) < pages)
                    {
                        Int32 ix = pages * limit;
                        menu += "<td class='hm_paging_td_off'>...</td><td class='hm_paging_td_off'><a href='" + Url + index_url + ix + "' class='hm_paging_on'>" + (pages) + "</a></td>";
                    }


                    if (page < pages)
                    {
                        menu += "<td style='width:5px;' class='hm_paging_td_off'><a href='" + Url + index_url + (index + limit) + "' class='hm_paging_on'>»</a></td>";
                    }
                    else
                    {
                        menu += "<td style='width:5px;'>&nbsp;</td>";
                    }

                    menu += "</tr></table></div></td></tr></table></div>";
                }

                #endregion

            }
        

            this.ltrUserList.Text = menu;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    //protected void img_AdminMoveDown_Click(object sender, ImageClickEventArgs e)
    //{
    //    String function_name = "img_AdminMoveDown_Click";
    //    try
    //    {
    //        RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
    //        sm.ChangeOrderDown();
    //        sm.Save();

    //        RXServer.Web.Redirect.To("Default.aspx?PagId=" + this.PagId);
    //    }
    //    catch (Exception ex)
    //    {
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }

    //}
    //protected void img_AdminMoveUp_Click(object sender, ImageClickEventArgs e)
    //{
    //    String function_name = "img_AdminMoveUp_Click";
    //    try
    //    {
    //        RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
    //        sm.ChangeOrderUp();
    //        sm.Save();

    //        RXServer.Web.Redirect.To("Default.aspx?PagId=" + this.PagId);
    //    }
    //    catch (Exception ex)
    //    {
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}
    //protected void img_AdminVisible_Click(object sender, ImageClickEventArgs e)
    //{
    //    String function_name = "img_AdminVisible_Click";
    //    try
    //    {
    //        RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
    //        if (sm.Visible == "true")
    //        {
    //            sm.Visible = "false";
    //        }
    //        else
    //        {
    //            sm.Visible = "true";
    //        }
    //        sm.Save();

    //        RXServer.Web.Redirect.To("Default.aspx?PagId=" + this.PagId);
    //    }
    //    catch (Exception ex)
    //    {
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}

    protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlSort_SelectedIndexChanged";
        try
        {
            Session["cb_orderby"] = this.ddlSort.SelectedValue.ToString();
            RXServer.Web.Redirect.To(Request.Url.ToString());
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
 
}
