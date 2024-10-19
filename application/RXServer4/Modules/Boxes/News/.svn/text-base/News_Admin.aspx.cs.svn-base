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
using System.IO;
using Telerik.Web.UI;
using System.Drawing;

public partial class Modules_Boxes_News_News_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_News_News_Admin";
    String ErrorList = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.SubMenu.Visible = true;
            HideErrors();
            BindMenuData();
            BindMenuData2();

            switch (RXServer.Web.RequestValues.Page)
            {
                case "Text":                    
                    if (!Page.IsPostBack)
                    {
                        BindTextData();
                        this.Page_2.Visible = true;

                    }
                break;

                case "AddNews":
                    if (!Page.IsPostBack)
                    {
                        this.Page_3.Visible = true;
                        this.RadCalendar1.SelectedDate = DateTime.Today;
                        this.ltrHelpText.Text = RXMali.GetXMLHelpNode("News/Add");

                        if (RXServer.Web.RequestValues.ViewId != "")
                        {
                            BindNewsData(RXServer.Web.RequestValues.ViewId);
                        }
                    }
                break;

                default:
                    if (!Page.IsPostBack)
                    {
                        this.Page_1.Visible = true;
                        if (RXServer.Web.RequestValues.DelId != "")
                        {
                            DeleteNews(RXServer.Web.RequestValues.DelId);
                        }
                        else
                        {
                            BindListData();
                        }
                    }
                    if (Request["Up"] != null)
                    {
                        MoveUpItem(Request["Up"]);
                    }
                    if (Request["Down"] != null)
                    {
                        MoveDownItem(Request["Down"]);
                    }
                break;
            }
            
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindTextData()
    {
        String function_name = "BindTextData";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("News/Text");
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            this.txtTitle.Text = Server.HtmlDecode(sm.Text1);

            PopulateModels();

            Int32 ModelId = 0;  // Default value
            Int32.TryParse(sm.ModelId, out ModelId);

            this.ddlModels.SelectedValue = ModelId.ToString();

            if (sm.Float == "right")
            {
                this.rbFloatRight.Checked = true;
            }
            else
            {
                this.rbFloatLeft.Checked = true;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindNewsData(String eId)
    {
        String function_name = "BindNewsData";
        try
        {
            Int32 obd_id = 0;
            Int32.TryParse(eId, out obd_id);

            RXServer.Modules.Base.List.Item e = new LiquidCore.List.Item(obd_id);

            this.txtNewsTitle.Text = Server.HtmlDecode(e.Value2).Replace("`", "'");
            this.RadEditor3.Content = Server.HtmlDecode(e.Value4).Replace("`", "'");
            this.RadEditor2.Content = Server.HtmlDecode(e.Value5).Replace("`", "'");
            this.RadEditor1.Content = Server.HtmlDecode(e.Value3).Replace("`", "'");           

            if (e.Value6 == "true")
            {   
                cbShowNews.Checked = true;
            }
            else
            {
                cbShowNews.Checked = false;
            }

            string date = "";

            char[] delimiterChars = { '/','-' };

            string[] words = e.Value25.Split(delimiterChars);

            date = words[2] + "-" + words[1] + "-" + words[0];

            DateTime startDate = DateTime.Parse(date + " 00:00:00");
            this.RadCalendar1.SelectedDate = startDate;
            this.btnSaveEvent.Text = "Edit News";
                       
                        

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindListData()
    {
        String function_name = "BindListData";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("News/List");
            String list = "";
            
            String Url = "";
            Int32 limit = 10;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index / limit) + 1;
            Int32 pages = 0;

            Url = RXMali.GetLastUrl(Request.Url.ToString());

            //RXServer.Modules.CalendarList cl = new RXServer.Modules.CalendarList("Calendar_" + RXServer.Web.RequestValues.ModId.ToString());

            RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("News_" + RXServer.Web.RequestValues.ModId, LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Order, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Descending, index, limit);
            RXServer.Modules.Base.List t = new RXServer.Modules.Base.List("News_" + RXServer.Web.RequestValues.ModId);
           

            total = t.Count();

            list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

            if (total > 0)
            {
                list += "<tr style='background-color: #666666' class='Text11_white'>";
                list += "<td valign='top'>Title</td>";
                list += "<td valign='top'>Date</td>";
                list += "<td valign='top' align='center'>Visible</td>";
                list += "<td valign='top' align='center'>Order</td>";
                list += "<td valign='top'>Delete</td>";
                list += "<td valign='top'>Edit</td>";

                list += "</tr>";

                Int32 counter = 0;

                foreach (RXServer.Modules.Base.List.Item item in cl)
                {
                    if ((counter % 2) == 0)
                    {
                        list += "<tr style='background-color: white;'  class='Text11_gray'>";
                    }
                    else
                    {
                        list += "<tr style='background-color: #EFEFEF;'  class='Text11_gray'>";
                    }
                    list += "<td valign='top'><a href='News_Admin.aspx?Page=AddNews&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "' class='underline'>" + item.Value2 + "</a></td>";
                    list += "<td valign='top'>" + item.Value25.Replace('-','/') + "</td>";
                    if (item.Value6 == "true")
                    {
                        list += "<td valign='top' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_on.gif' title='Active' class='img_noborder' /></td>";
                    }
                    else
                    {
                        list += "<td valign='top' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_off.gif' title='Unactive' class='img_noborder' /></td>";
                    }

                    list += "<td valign='top' align='center'><a href='" + Request.Url.ToString() + "&Up=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_up.gif' alt='Move Up' class='img_noborder' /></a> / <a href='" + Request.Url.ToString() + "&Down=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_down.gif' alt='Move Down' class='img_noborder' /></a></td>";
                    list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this item( " + item.Value2 + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this item( " + item.Value2 + " )?')\">Delete</a></td></tr></table></td>";
                    list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='News_Admin.aspx?Page=AddNews&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_edit.gif' class='img_noborder' /></a></td><td><a href='News_Admin.aspx?Page=AddNews&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "'>&nbsp;Edit</a></td></tr></table></td>";
                    
                    list += "</tr>";
                    counter++;
                }
            }
            else
            {
                list += "<tr><td class='Text11_gray'>No Records was found.</td></tr>";
            }

            list += "</table>";

            #region Paging

            if (total > 0)
            {
                double t1, t2;
                t1 = total;
                t2 = limit;
                pages = (int)Math.Ceiling(t1 / t2);
                Url = Url.Replace("&Index=" + index, "");

                if (RXServer.Web.RequestValues.PagId > 0)
                {
                    Url = Url + "&PagId=" + RXServer.Web.RequestValues.PagId;
                }

                list += "<table cellspacing='0' cellpadding='0' style='width: 100%;'><tr>";
                list += "<td colspan='10' style='text-align: right' class='Text11_gray'><div style='position:relative; padding: 0px; margin: 0px; float: right'><table cellspacing='0' cellpadding='5'><tr>";
                list += "<td>Page " + page + "  of " + pages + "</td>";
                
                if (page > 1)
                {
                    list += "<td style='width:5px;'><a href='" + Url + "&Index=" + (index - limit) + "' class='paging_on'>«</a></td>";
                }
                else
                {
                    list += "<td style='width:5px;'>&nbsp;</td>";
                }

                if ((page) > 3)
                {
                    list += "<td><a href='" + Url + "&Index=" + 0 + "' class='paging_on'>1</a></td><td>...</td>";
                }

                for (int i = 0; i < pages; i++)
                {
                    if (i < page + 2 && i > (page - 4))
                    {
                        Int32 ix = i * limit;
                        if ((i + 1) == page)
                        {
                            list += "<td style='background-color: #CCCCCC;'>" + (i + 1) + "</td>";
                        }
                        else
                        {
                            list += "<td><a href='" + Url + "&Index=" + ix + "' class='paging_on'>" + (i + 1) + "</a></td>";
                        }
                    }
                }
                if ((page + 2) < pages)
                {
                    Int32 ix = (pages-1) * limit;
                    list += "<td>...</td><td><a href='" + Url + "&Index=" + ix + "' class='paging_on'>" + (pages) + "</a></td>";
                }


                if (page < pages)
                {
                    list += "<td style='width:5px;'><a href='" + Url + "&Index=" + (index + limit) + "' class='paging_on'>»</a></td>";
                }
                else
                {
                    list += "<td style='width:5px;'>&nbsp;</td>";
                }

                list += "<tr></table></div></td></tr></table>";
            }

            #endregion

            this.ltrEventsList.Text = list;

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindMenuData()
    {
        String function_name = "BindMenuData";
        try
        {
            String list = "";

            list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
            list += "<tr>";
            list += "<tr><td style='width:10px; height:34px;'></td>";
            if (RXServer.Web.RequestValues.Page == "News" || RXServer.Web.RequestValues.Page == "")
            {
                list += "<td><a href='News_Admin.aspx?Page=News&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_on'>News</a></td>";
            }
            else
            {
                list += "<td><a href='News_Admin.aspx?Page=News&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_off'>News</a></td>";
            }
            list += "<td style='width:20px;'></td>";

            if (RXServer.Web.RequestValues.Page == "Text")
            {
                list += "<td><a href='News_Admin.aspx?Page=Text&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_on'>Content</a></td>";
            }
            else
            {
                list += "<td><a href='News_Admin.aspx?Page=Text&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_off'>Content</a></td>";
            }
            list += "<td style='width:20px;'></td>";

            list += "</tr>";
            list += "</table>";

            this.ltrSubMenuList1.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindMenuData2()
    {
        String function_name = "BindMenuData2";
        try
        {
            String list = "";

            list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
            list += "<tr>";
            list += "<td style='width:10px;'><td><img src='../../../App_Themes/WebAdmin/Images/submenu_divider.gif' class='img_noborder' /></td><td style='width:10px;'>";
            if (RXServer.Web.RequestValues.Page == "AddNews")
            {
                list += "<td><a href='News_Admin.aspx?Page=AddNews&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='News_Admin.aspx?Page=AddNews&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_on'>Add News</a></td>";
            }
            else
            {
                list += "<td><a href='News_Admin.aspx?Page=AddNews&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='News_Admin.aspx?Page=AddNews&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_off'>Add News</a></td>";
            }
            list += "<td style='width:20px; height:34px;'></td>";
            list += "</tr>";
            list += "</table>";

            this.ltrSubMenuList2.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
       
    protected void btnSaveData_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveData_Click";
        try
        {
            Boolean valid = true;
            String Errors = "";

            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            sm.Text1 = Server.HtmlEncode(this.txtTitle.Text).Replace("'", "`");
            sm.Save();

            if (this.rbFloatRight.Checked)
            {
                sm.Float = "right";
            }
            else
            {
                sm.Float = "left";
            }

            if (this.ddlModels.SelectedItem.Value == "0")
            {
                valid = false;
                Errors += " - Please select a size.";
                this.imgError1_2.Visible = true;
            }
            else
            {
                sm.ModelId = this.ddlModels.SelectedItem.Value;
            }

            sm.Save();

            if (valid)
            {
                this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = Errors;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void DeleteNews(String Id)
    {
        String function_name = "DeleteNews";
        try
        {
            Int32 obdId = 0;
            Int32.TryParse(Id, out obdId);
            if (obdId > 0)
            {
                RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obdId);

                Int32 pagId = 0;
                Int32.TryParse(i.Value26.ToString(), out pagId);
                              
                i.Delete();

                RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(pagId);

                mItem.Delete();
            }

            String Url;
            Url = RXMali.GetLastUrl(Request.Url.ToString());
            Url = Url.Replace("&DelId=" + Id, "");

            RXServer.Web.Redirect.To(Url);
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void HideErrors()
    {
        String function_name = "HideErrors";
        try
        {
            this.imgError1_2.Visible = false;
            //this.imgError1_1.Visible = false;
            this.imgError2_2.Visible = false;
            this.imgError3_1.Visible = false;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    protected void btnSaveNews_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveNews_Click";
        try
        {

            if(CheckNews())
            {
                String Errors = "";
                Boolean valid = true;

                RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);

                if (RXServer.Web.RequestValues.ViewId != "")   // EDIT EVENT
                {
                    
                    Int32 obd_id = 0;

                    Int32.TryParse(RXServer.Web.RequestValues.ViewId, out obd_id);

                    if (obd_id > 0)
                    {
                        RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obd_id);

                        i.Alias = "News_" + RXServer.Web.RequestValues.ModId;
                        i.Status = 1;
                        i.Language = 1;
                        i.SitId = 1;
                        i.PagId = RXServer.Web.RequestValues.PagId;
                        i.ModId = RXServer.Web.RequestValues.ModId;
                        i.Value2 = Server.HtmlEncode(this.txtNewsTitle.Text).Replace("'", "`");
                        i.Value3 = Server.HtmlEncode(this.RadEditor1.Content.Replace("'", "`"));
                        i.Value4 = Server.HtmlEncode(this.RadEditor3.Content).Replace("'", "`");
                        i.Value5 = Server.HtmlEncode(this.RadEditor2.Content).Replace("'", "`");

                        i.Value25 = this.RadCalendar1.SelectedDate.Date.ToString("dd/MM/yyyy");
                        //Response.Write(this.RadCalendar1.SelectedDate.Date.ToString("dd/MM/yyyy"));
                        
                        if (cbShowNews.Checked == true)
                        {
                            i.Value6 = "true";
                        }
                        else
                        {
                            i.Value6 = "false";
                        }                        

                        #region EditNewsPage

                        if (valid)
                        {
                            RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(Convert.ToInt32(i.Value26));

                            mItem.Title = Server.HtmlDecode(this.txtNewsTitle.Text);
                            mItem.Alias = RXMali.GetFriendlyUrl(this.txtNewsTitle.Text, this.txtNewsTitle.Text, mItem.Level, mItem.Id);
                            mItem.Save();

                            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(RXServer.Web.RequestValues.SitId, Convert.ToInt32(i.Value26), Convert.ToInt32(i.Value27));

                            tm.Text2 = Server.HtmlEncode(this.txtNewsTitle.Text);
                            tm.Text3 = Server.HtmlEncode(this.RadEditor1.Content);
                            tm.Text4 = Server.HtmlEncode(this.RadEditor3.Content);
                         
                            tm.Save();

                        }

                        #endregion
                       
                        i.Save();                            

                    }
                }
                else     // ADD EVENT(S)
                {
                    try
                    {
                        RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item();

                        i.Alias = "News_" + RXServer.Web.RequestValues.ModId;
                        i.Status = 1;
                        i.Language = 1;
                        i.SitId = 1;
                        i.PagId = RXServer.Web.RequestValues.PagId;
                        i.ModId = RXServer.Web.RequestValues.ModId;
                        i.Value2 = Server.HtmlEncode(this.txtNewsTitle.Text).Replace("'", "`");
                        i.Value3 = Server.HtmlEncode(this.RadEditor1.Content).Replace("'", "`");
                        i.Value4 = Server.HtmlEncode(this.RadEditor3.Content).Replace("'", "`");
                        i.Value5 = Server.HtmlEncode(this.RadEditor2.Content).Replace("'", "`");

                        
                        i.Value25 = this.RadCalendar1.SelectedDate.Date.ToString("dd/MM/yyyy");
                        //Response.Write(this.RadCalendar1.SelectedDate.Date.ToString("dd/MM/yyyy"));

                        if (cbShowNews.Checked == true)
                        {
                            i.Value6 = "true";
                        }
                        else
                        {
                            i.Value6 = "false";
                        }                       

                        Int32 textModId = 0;
                        Int32 textPagId = 0;

                        if (valid)
                        {
                            RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item();
                            mItem.SitId = 1;
                            mItem.Language = 1;
                            mItem.Status = 2;
                            mItem.ParentId = RXServer.Web.RequestValues.PagId;
                            mItem.Template = "Template3.master";
                            mItem.Title = Server.HtmlDecode(this.txtNewsTitle.Text);
                            mItem.ModelId = 1;

                            mItem.Save();
                            CreatePageFolder(mItem.Id);
                            textPagId = mItem.Id;

                            RXServer.Modules.Menu.Item mItem2 = new RXServer.Modules.Menu.Item(mItem.Id);
                            mItem2.Alias = RXMali.GetFriendlyUrl(this.txtNewsTitle.Text, this.txtNewsTitle.Text, mItem.Level, mItem.Id);

                            textModId = RXServer.Modules.TextModule.Create(1, mItem.Id, 71, "ContentPane1", 1, 1, false, false);

                            i.Value26 = mItem.Id.ToString();
                            i.Value27 = textModId.ToString();

                            mItem2.Save();
                        }

                        i.Save();


                        if (valid)
                        {
                            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(RXServer.Web.RequestValues.SitId, textPagId, textModId);

                            tm.Text2 = Server.HtmlEncode(this.txtNewsTitle.Text);
                            tm.Text3 = Server.HtmlEncode(this.RadEditor1.Content);
                            tm.Text4 = Server.HtmlEncode(this.RadEditor3.Content);

                            tm.Text10 = "NewsItem";
                            tm.Visible = "true";
                            tm.Text9 = RXServer.Web.RequestValues.ModId.ToString();
                            tm.Text8 = RXServer.Web.RequestValues.PagId.ToString();
                            tm.Text7 = i.Id.ToString();

                            tm.ModelId = "2";

                            tm.Save();
                        }

                        #region AddNewsPage

                        

                        #endregion
                    }
                    catch (Exception ex)
                    {
                        this.ErrorBox.Visible = true;
                        this.ltrErrors.Text = ex.ToString();
                    }
                }


                if (valid)
                {

                    string Url = "";

                    Url = RXMali.GetLastUrl(Request.Url.ToString());

                    Url = Url.Replace("&ViewId=" + RXServer.Web.RequestValues.ViewId, "");
                    Url = Url.Replace("AddNews", "News");

                    RXServer.Web.Redirect.To(Url);
                }
                else
                {
                    this.ltrErrors.Text = ErrorList;
                    this.ErrorBox.Visible = true;
                }
            }
            else
            {
                this.ltrErrors.Text = ErrorList; 
                this.ErrorBox.Visible = true;
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public Boolean CheckNews()
    {
        String function_name = "CheckNews";
        try
        {
            Boolean valid = true;

            if (this.txtNewsTitle.Text == "")
            {
                valid = false;
                ErrorList += "- Please write a title for the news<br />";
                this.imgError3_1.Visible = true;
            }

            return valid;

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    public void MoveUpItem(string id)
    {
        String function_name = "MoveUpItem";
        try
        {
            Int32 obd_id = 0;
            Int32.TryParse(id, out obd_id);

            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obd_id);
            i.ChangeOrderDown();

            String Url = "";
            Url = RXMali.GetLastUrl(Request.Url.ToString());
            Url = Url.Replace("&Up=" + Request["Up"], "");

            RXServer.Web.Redirect.To(Url);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void MoveDownItem(string id)
    {
        String function_name = "MoveDownItem";
        try
        {
            Int32 obd_id = 0;
            Int32.TryParse(id, out obd_id);

            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obd_id);
            i.ChangeOrderUp();

            String Url = "";
            Url = RXMali.GetLastUrl(Request.Url.ToString());
            Url = Url.Replace("&Down=" + Request["Down"], "");

            RXServer.Web.Redirect.To(Url);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void PopulateModels()
    {
        String function_name = "PopulateModels";
        try
        {
            Int32 modelId = 0;
            Int32.TryParse(RXServer.Web.RequestValues.Var, out modelId);

            this.ddlModels.Items.Add(new ListItem("Select a size", "0"));
            this.ddlModels.Items.Add(new ListItem("Medium", "2"));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void CreatePageFolder(Int32 pagId)
    {
        String function_name = "CreatePageFolder";
        try
        {
            string activeDir = Server.MapPath("~/Upload/Pages/");
            string newPath = System.IO.Path.Combine(activeDir, pagId.ToString());

            System.IO.Directory.CreateDirectory(newPath);
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
}
