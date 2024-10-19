using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Drawing.Printing;

public partial class Modules_Search_Search_Search : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Search_Search_Search";

    String Frase = String.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.Search_admin.Visible = true;
                this.img_AdminEdit.OnClientClick = "javascript:showAdminSearch(1," + this.PagId + "," + this.ModId + "); return false;";
                this.img_AdminDelete.OnClientClick = "javascript:showAdminDeleteModule(1," + this.PagId + "," + this.ModId + "); return false;";
            }

            if (!Page.IsPostBack)
            {
                bindData();
            }

            BindResultData(0);
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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);

            if (sm.Visible == "true" || RXServer.Auth.IsInRole("Admin"))
            {
                this.Search_holder.Visible = true;
                this.lblSuperHeader.Text = Server.HtmlDecode(sm.Text1);

                if (sm.Visible == "true")
                {
                    this.imbAdminVisible.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_vis_true.gif";
                    this.imbAdminVisible.ToolTip = "Hide Content";
                }
                else
                {
                    this.imbAdminVisible.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_vis_false.gif";
                    this.imbAdminVisible.ToolTip = "Publish Content";
                }

                this.lblResultTitle.Text = RXMali.GetXMLNode("Modules/Search/search_results_for");
                this.lblSearchHits.Text = RXMali.GetXMLNode("Modules/Search/search_hits") + ":";
                this.lnkSearchFirst.Text = RXMali.GetXMLNode("Modules/Search/first");
                this.lnkSearchNext.Text = RXMali.GetXMLNode("Modules/Search/next");
                this.lnkSearchPrev.Text = RXMali.GetXMLNode("Modules/Search/previous");

            }
            else
            {
                this.Search_holder.Visible = false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void img_AdminMoveDown_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminMoveDown_Click";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            sm.ChangeOrderDown();
            sm.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void img_AdminMoveUp_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminMoveUp_Click";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            sm.ChangeOrderUp();
            sm.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void img_AdminVisible_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminVisible_Click";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            if (sm.Visible == "true")
            {
                sm.Visible = "false";
            }
            else
            {
                sm.Visible = "true";
            }
            sm.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void BindResultData(Int32 mode)
    {
        String function_name = "BindResultData";
        try
        {
            Int32 ItemCount = 0;
            Int32 PageCount = 0;
            Double TempCount = 0;
            Int32 ShowItemFrom = 0;
            Int32 ShowItemTo = 0;
            Int32 SearchLevel = 0;
            Int32 ShowCounter = 0;
            lblRes.Text = "0";
            lnkSearchFirst.Visible = false;
            lnkSearchPrev.Visible = false;
            lnkSearchNext.Visible = false;
            //lnkSearchMid.Visible = false;
            //lnkSearchMid2.Visible = false;
            //lnkSearchMid3.Visible = false;

            if (Session["RXServer_txtSearch"] != null)
            {
                Frase = Session["RXServer_txtSearch"].ToString();
                lblFrase.Text = Frase;
            }

            if (Frase.Length > 0)
            {
                // Leta efter artiklar...
                String sql = "SELECT obd_id, obd_objectdata.pag_id, obd_varchar1, obd_varchar2, obd_varchar3, obd_varchar4, obd_updatedby, obd_createdby FROM obd_objectdata ";
                sql += "INNER JOIN pag_pages ";
                sql += "ON obd_objectdata.pag_id=pag_pages.pag_id ";
                sql += "INNER JOIN mod_modules ";
                sql += "ON obd_objectdata.mod_id=mod_modules.mod_id ";
                sql += "WHERE pag_deleted=0 ";
                sql += "AND pag_hidden=0 ";
                sql += "AND mod_deleted=0 ";
                sql += "AND mod_hidden=0 ";
                sql += "AND obd_deleted = 0 ";
                sql += "AND ( obd_varchar1 LIKE '%" + Frase + "%' ";
                sql += "OR obd_varchar2 LIKE '%" + Frase + "%' ";
                sql += "OR obd_varchar3 LIKE '%" + Frase + "%' ";
                sql += "OR obd_varchar4 LIKE '%" + Frase + "%' ";
                sql += ")";
                using (DataTable dt1 = RXServer.Data.Direct.GetDataTable(sql))
                {
                    if (dt1.Rows.Count > 0)
                    {
                        ShowCounter = 0;
                        lblRes.Text = dt1.Rows.Count.ToString();

                        Int32.TryParse(dt1.Rows.Count.ToString(), out ItemCount);
                        TempCount = Convert.ToDouble(ItemCount) / 10.0;
                        PageCount = ItemCount / 10;
                        if (PageCount < TempCount) PageCount += 1;
                        Session["SearchCount"] = PageCount;
                        if (Session["SearchLevel"] != null)
                            SearchLevel = Convert.ToInt32(Session["SearchLevel"]);
                        if (Session["SearchCount"] != null)
                            PageCount = Convert.ToInt32(Session["SearchCount"]);
                        ShowItemFrom = SearchLevel == 1 ? 1 : (10 * SearchLevel - 9);
                        ShowItemTo = SearchLevel == PageCount ? (ShowItemFrom + 9) > ItemCount ? ItemCount : (ShowItemFrom + 9) : (ShowItemFrom + 9);

                        if (ItemCount == 0)
                        {
                            Session["SearchLevel"] = 1;
                            Session["SearchCount"] = 0;
                            return;
                        }
                        else
                        {
                            // Visa Första och Föregående
                            if (!SearchLevel.Equals(1))
                            {
                                lnkSearchFirst.Visible = true;
                                lnkSearchPrev.Visible = true;
                                //lnkSearchMid.Visible = true;
                                //lnkSearchMid2.Visible = true;
                            }

                            // Visa Nästa
                            if (!SearchLevel.Equals(PageCount))
                            {
                                lnkSearchNext.Visible = true;
                                //lnkSearchMid3.Visible = true;
                            }

                            //Response.Write("mode" + mode.ToString() + "<br>");
                            if (mode.Equals(0) || mode.Equals(1))
                            {
                                SearchHolder.Controls.Clear();

                                // Skapa numeriska, prev och next...
                                // För att det inte ska bli så trångt
                                // ska det ändast visas 5 siffror även
                                // om det finns fler sidor.
                                // alltså max 5 stycken.
                                //Response.Write("PageCount" + PageCount.ToString() + "<br>");
                                //Response.Write("SearchLevel" + SearchLevel.ToString() + "<br>");
                                Int32 iMin = 1;
                                Int32 iMax = PageCount + 1;
                                if (PageCount > 5)
                                {
                                    if (SearchLevel > 2 && PageCount.Equals(SearchLevel + 3))
                                    {
                                        iMin = SearchLevel - 1;
                                        iMax = SearchLevel + 4;
                                    }
                                    else if (SearchLevel > 2 && PageCount.Equals(SearchLevel + 2))
                                    {
                                        iMin = SearchLevel - 2;
                                        iMax = SearchLevel + 3;
                                    }
                                    else if (SearchLevel > 2 && PageCount.Equals(SearchLevel + 1))
                                    {
                                        iMin = SearchLevel - 3;
                                        iMax = SearchLevel + 2;
                                    }
                                    else if (SearchLevel > 2 && PageCount.Equals(SearchLevel))
                                    {
                                        iMin = SearchLevel - 4;
                                        iMax = SearchLevel + 1;
                                    }
                                    else if (SearchLevel > 2)
                                    {
                                        iMin = SearchLevel - 2;
                                        iMax = SearchLevel + 3;
                                    }
                                    else
                                    {
                                        iMin = 1;
                                        iMax = 6;
                                    }
                                }
                                for (Int32 i = iMin; i < iMax; i++)
                                {
                                    if (i > 1 && i != iMin)
                                        SearchHolder.Controls.Add(new LiteralControl("<img src=\"Images/Modules/Search/seperator.gif\" style=\"width:1px; border: none;\" alt=\"\" />"));
                                    if (i.Equals(1) || i.Equals(iMin))
                                    {
                                        LinkButton c = new LinkButton();
                                        c.ID = "lnkSearchNumeric" + i.ToString();
                                        c.Text = i.ToString();
                                        c.CommandArgument = i.ToString();
                                        c.Click += new EventHandler(lnkSearchNumeric_Click);
                                        if (i.Equals(SearchLevel))
                                            c.CssClass = "page_link_active";
                                        else
                                            c.CssClass = "page_link";
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(c);
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                    }
                                    else if (i.Equals(SearchLevel))
                                    {
                                        LinkButton c = new LinkButton();
                                        c.ID = "lnkSearchNumeric" + i.ToString();
                                        c.Text = i.ToString();
                                        c.CommandArgument = i.ToString();
                                        c.Click += new EventHandler(lnkSearchNumeric_Click);
                                        c.CssClass = "page_link_active";
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(c);
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                    }
                                    else if (i.Equals(PageCount))
                                    {
                                        LinkButton c = new LinkButton();
                                        c.ID = "lnkSearchNumeric" + i.ToString();
                                        c.Text = i.ToString();
                                        c.CommandArgument = i.ToString();
                                        c.Click += new EventHandler(lnkSearchNumeric_Click);
                                        c.CssClass = "page_link";
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(c);
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                    }
                                    else
                                    {
                                        LinkButton c = new LinkButton();
                                        c.ID = "lnkSearchNumeric" + i.ToString();
                                        c.Text = i.ToString();
                                        c.CommandArgument = i.ToString();
                                        c.Click += new EventHandler(lnkSearchNumeric_Click);
                                        c.CssClass = "page_link";
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(c);
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                        SearchHolder.Controls.Add(new LiteralControl("&nbsp;"));
                                    }
                                }

                            }
                            else
                            {
                                foreach (Control c in SearchHolder.Controls)
                                {
                                    if (c.GetType() == typeof(LinkButton))
                                    {
                                        System.Diagnostics.Debug.WriteLine(c.ID);
                                        LinkButton a = (LinkButton)c;
                                        a.CssClass = "page_link";
                                    }
                                }
                            }
                        }

                        ShowCounter = 0;
                        foreach (DataRow dr in dt1.Rows)
                        {
                            ShowCounter += 1;
                            if (ShowCounter >= ShowItemFrom && ShowCounter <= ShowItemTo)
                            {
                                DateTime dt = DateTime.Now;
                                DateTime.TryParse(dr["obd_varchar1"].ToString(), out dt);
                                dr["obd_varchar1"] = dt.ToShortDateString();
                                dr["obd_varchar2"] = Server.HtmlDecode(dr["obd_varchar2"].ToString()).Replace(Frase.ToLower(), "<b>" + Frase.ToLower() + "</b>");
                                dr["obd_varchar3"] = Server.HtmlDecode(dr["obd_varchar3"].ToString()).Replace(Frase.ToLower(), "<b>" + Frase.ToLower() + "</b>");
                                dr["obd_varchar4"] = Server.HtmlDecode(dr["obd_varchar4"].ToString()).Replace(Frase.ToLower(), "<b>" + Frase.ToLower() + "</b>");
                                dr["obd_updatedby"] = "Default.aspx?PagId=" + dr["pag_id"].ToString();
                                dr["obd_createdby"] = RXServer.Web.SelectedPages.GetDynamicSiteMapPath(Convert.ToInt32(dr["pag_id"].ToString()), " / ");
                            }
                            else
                            {
                                dr.Delete();
                            }
                        }
                        dt1.AcceptChanges();
                    }

                    dlResult.DataSource = dt1;
                    dlResult.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void lnkSearchFirst_Click(object sender, EventArgs e)
    {
        String function_name = "lnkSearchFirst_Click";
        try
        {
            Session["SearchLevel"] = 1;
            BindResultData(0);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void lnkSearchPrev_Click(object sender, EventArgs e)
    {
        String function_name = "lnkSearchPrev_Click";
        try
        {
            Int32 SearchLevel = 0;
            if (Session["SearchLevel"] != null)
                SearchLevel = Convert.ToInt32(Session["SearchLevel"]);
            if (SearchLevel > 1)
                Session["SearchLevel"] = SearchLevel - 1;
            BindResultData(0);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void lnkSearchNext_Click(object sender, EventArgs e)
    {
        String function_name = "lnkSearchNext_Click";
        try
        {
            Int32 PageCount = 0;
            Int32 SearchLevel = 0;
            if (Session["SearchLevel"] != null)
                SearchLevel = Convert.ToInt32(Session["SearchLevel"]);
            if (Session["SearchCount"] != null)
                PageCount = Convert.ToInt32(Session["SearchCount"]);
            if (PageCount != SearchLevel)
                Session["SearchLevel"] = SearchLevel + 1;
            BindResultData(0);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void lnkSearchNumeric_Click(object sender, EventArgs e)
    {
        String function_name = "lnkSearchNumeric_Click";
        try
        {
            LinkButton c = (LinkButton)sender;
            Int32 i = 0;
            Int32.TryParse(c.CommandArgument, out i);
            if (!i.Equals(0))
            {
                Int32 SearchLevel = 0;
                if (Session["SearchLevel"] != null)
                    SearchLevel = Convert.ToInt32(Session["SearchLevel"]);
                if (i < SearchLevel)
                {
                    Int32 cur = SearchLevel - i;
                    Session["SearchLevel"] = SearchLevel - cur;
                }
                if (i > SearchLevel)
                {
                    Int32 cur = i - SearchLevel;
                    Session["SearchLevel"] = SearchLevel + cur;
                }
            }
            BindResultData(1);
            Control x = this.Page.FindControl(SearchHolder.ClientID.Substring(0, SearchHolder.ClientID.IndexOf("_")) + "$lnkSearchNumeric" + i.ToString());
            ////ctl17_lnkSearchNumeric1
            //Response.Write(x.ID);
            if (x != null)
            {
                LinkButton a = (LinkButton)x;
                a.CssClass = "standard_link_black";
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
   
}
