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
using System.Xml;

public partial class Modules_Boxes_ContactBox_ContactBox_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_ContactBox_ContactBox_Admin";
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
                case "Content":                    
                    if (!Page.IsPostBack)
                    {
                        PopulateModels();
                        BindTextData();
                        this.Page_2.Visible = true;
                    }
                break;

                case "Category":
                    this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ContactBox/AddCategory");
                    if (!Page.IsPostBack)
                    {
                        this.Page_1.Visible = true;
                        if (RXServer.Web.RequestValues.DelId != "")
                        {
                            DeleteItem(RXServer.Web.RequestValues.DelId);
                        }
                        else
                        {
                            BindCategoryList();
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

                case "AddCategory":
                if (!Page.IsPostBack)
                {
                    this.Page_3.Visible = true;
                    this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ContactBox/AddCategory");

                    if (RXServer.Web.RequestValues.ViewId != "")
                    {
                        BindCategoryData(RXServer.Web.RequestValues.ViewId);
                    }
                }
                break;

                case "Subcategory":
                    if (!Page.IsPostBack)
                    {
                        this.Page_1b.Visible = true;
                        if (RXServer.Web.RequestValues.DelId != "")
                        {
                            DeleteItem(RXServer.Web.RequestValues.DelId);
                        }
                        else
                        {
                            BindSubCategoryList();
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

                case "AddSubCategory":
                if (!Page.IsPostBack)
                {
                    this.Page_3b.Visible = true;
                    this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ContactBox/AddSubCategory");
                    PopulateListCategories2();
                    if (RXServer.Web.RequestValues.ViewId != "")
                    {
                        BindSubCategoryData(RXServer.Web.RequestValues.ViewId);
                    }
                }
                break;

                case "Clients":
                if (!Page.IsPostBack)
                {
                    this.Page_1c.Visible = true;
                    if (RXServer.Web.RequestValues.DelId != "")
                    {
                        DeleteItem(RXServer.Web.RequestValues.DelId);
                    }
                    else
                    {
                        BindClientList();
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

                case "AddClient":
                if (!Page.IsPostBack)
                {
                    this.Page_3c.Visible = true;
                    this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ContactBox/AddClient");

                    if (RXServer.Web.RequestValues.ViewId != "")
                    {
                        BindClientData(RXServer.Web.RequestValues.ViewId);
                    }
                }
                break;

                default:
                    if (!Page.IsPostBack)
                    {
                        PopulateModels();
                        BindTextData();
                        this.Page_2.Visible = true;
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
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ContactBox/Text");
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            this.txtTitle.Text = Server.HtmlDecode(sm.Text2);
            this.RadEditor1.Content = Server.HtmlDecode(sm.Text4);
            this.RadEditor2.Content = Server.HtmlDecode(sm.Text6);
            this.RadEditor3.Content = Server.HtmlDecode(sm.Text7);
            this.txtMailSubject.Text = Server.HtmlDecode(sm.Text8);
            this.txtFromAdress.Text = Server.HtmlDecode(sm.Text9);

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
    public void BindCategoryData(String eId)
    {
        String function_name = "BindCategoryData";
        try
        {
            Int32 obd_id = 0;
            Int32.TryParse(eId, out obd_id);

            RXServer.Modules.Base.List.Item e = new LiquidCore.List.Item(obd_id);

            this.txtCategoryName.Text = Server.HtmlDecode(e.Value25);

            if (e.Value6 == "false")
            {
                this.cbShowItem.Checked = false;
            }
            else
            {
                this.cbShowItem.Checked = true;
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindSubCategoryData(String eId)
    {
        String function_name = "BindSubCategoryData";
        try
        {
            Int32 obd_id = 0;
            Int32.TryParse(eId, out obd_id);

            RXServer.Modules.Base.List.Item e = new LiquidCore.List.Item(obd_id);

            this.txtSubCategoryName.Text = Server.HtmlDecode(e.Value25);
            this.txtSubCategoryMail.Text = Server.HtmlDecode(e.Value26);

            this.ddlCategory.SelectedValue = e.Value27;

            if (e.Value6 == "false")
            {
                this.cbShowSubCategory.Checked = false;
            }
            else
            {
                this.cbShowSubCategory.Checked = true;
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindClientData(String eId)
    {
        String function_name = "BindClientData";
        try
        {
            Int32 obd_id = 0;
            Int32.TryParse(eId, out obd_id);

            RXServer.Modules.Base.List.Item e = new LiquidCore.List.Item(obd_id);

            this.txtClientName.Text = Server.HtmlDecode(e.Value25);

            if (e.Value6 == "false")
            {
                this.cbShowClient.Checked = false;
            }
            else
            {
                this.cbShowClient.Checked = true;
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindCategoryList()
    {
        String function_name = "BindCategoryList";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ContactBox/CategoryList");
            String list = "";
            
            String Url = "";
            Int32 limit = 10;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index / limit) + 1;
            Int32 pages = 0;

            Url = RXMali.GetLastUrl(Request.Url.ToString());

            //RXServer.Modules.CalendarList cl = new RXServer.Modules.CalendarList("Calendar_" + RXServer.Web.RequestValues.ModId.ToString());

            RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("Category_" + RXServer.Web.RequestValues.ModId, LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Order, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Descending, index, limit);
            RXServer.Modules.Base.List t = new RXServer.Modules.Base.List("Category_" + RXServer.Web.RequestValues.ModId);
           

            total = t.Count();

            list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

            if (total > 0)
            {
                list += "<tr style='background-color: #666666' class='Text11_white'>";
                list += "<td valign='top'>Category Name</td>";
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
                        list += "<tr style='background-color: white; vertical-align: middle;'  class='Text11_gray'>";
                    }
                    else
                    {
                        list += "<tr style='background-color: #EFEFEF; vertical-align: middle;'  class='Text11_gray'>";
                    }
                    list += "<td valign='middle'><a href='ContactBox_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "&Var=" + RXServer.Web.RequestValues.Var + "' class='underline'>" + item.Value25 + "</a></td>";
                    if (item.Value6 == "true")
                    {
                        list += "<td valign='middle' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_on.gif' title='Active' class='img_noborder' /></td>";
                    }
                    else
                    {
                        list += "<td valign='middle' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_off.gif' title='Unactive' class='img_noborder' /></td>";
                    }

                    list += "<td valign='middle' align='center'><a href='" + Request.Url.ToString() + "&Up=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_up.gif' alt='Move Up' class='img_noborder' /></a> / <a href='" + Request.Url.ToString() + "&Down=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_down.gif' alt='Move Down' class='img_noborder' /></a></td>";
                    list += "<td valign='middle'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this item ( " + item.Value25 + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this item( " + item.Value25 + " )?')\">Delete</a></td></tr></table></td>";
                    list += "<td valign='middle'><table cellpadding='0' cellspacing='0'><tr><td><a href='ContactBox_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "&Var=" + RXServer.Web.RequestValues.Var + "'><img src='../../../App_Themes/WebAdmin/Images/icon_edit.gif' class='img_noborder' /></a></td><td><a href='ContactBox_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "&Var=" + RXServer.Web.RequestValues.Var + "'>&nbsp;Edit</a></td></tr></table></td>";
                    
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
    public void BindSubCategoryList()
    {
        String function_name = "BindSubCategoryList";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ContactBox/CategoryList");
            String list = "";

            String Url = "";
            Int32 limit = 10;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index / limit) + 1;
            Int32 pages = 0;

            Url = RXMali.GetLastUrl(Request.Url.ToString());

            if (!Page.IsPostBack)
            {
                PopulateListCategories();            
            }


            //RXServer.Modules.CalendarList cl = new RXServer.Modules.CalendarList("Calendar_" + RXServer.Web.RequestValues.ModId.ToString());

            RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("Subcategory_" + this.ddlListCategory.SelectedValue + "_" + RXServer.Web.RequestValues.ModId, LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Order, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Descending, index, limit);
            RXServer.Modules.Base.List t = new RXServer.Modules.Base.List("Subcategory_" + this.ddlListCategory.SelectedValue + "_" + RXServer.Web.RequestValues.ModId);


            total = t.Count();

            list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

            if (total > 0)
            {
                list += "<tr style='background-color: #666666' class='Text11_white'>";
                list += "<td valign='top'>Subcategory Name</td>";
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
                        list += "<tr style='background-color: white; vertical-align: middle;'  class='Text11_gray'>";
                    }
                    else
                    {
                        list += "<tr style='background-color: #EFEFEF; vertical-align: middle;'  class='Text11_gray'>";
                    }
                    list += "<td valign='middle'><a href='ContactBox_Admin.aspx?Page=AddSubCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "&Var=" + RXServer.Web.RequestValues.Var + "' class='underline'>" + item.Value25 + "</a></td>";
                    if (item.Value6 == "true")
                    {
                        list += "<td valign='middle' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_on.gif' title='Active' class='img_noborder' /></td>";
                    }
                    else
                    {
                        list += "<td valign='middle' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_off.gif' title='Unactive' class='img_noborder' /></td>";
                    }

                    list += "<td valign='middle' align='center'><a href='" + Request.Url.ToString() + "&Up=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_up.gif' alt='Move Up' class='img_noborder' /></a> / <a href='" + Request.Url.ToString() + "&Down=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_down.gif' alt='Move Down' class='img_noborder' /></a></td>";
                    list += "<td valign='middle'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this item ( " + item.Value25 + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this item( " + item.Value25 + " )?')\">Delete</a></td></tr></table></td>";
                    list += "<td valign='middle'><table cellpadding='0' cellspacing='0'><tr><td><a href='ContactBox_Admin.aspx?Page=AddSubCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "&Var=" + RXServer.Web.RequestValues.Var + "'><img src='../../../App_Themes/WebAdmin/Images/icon_edit.gif' class='img_noborder' /></a></td><td><a href='ContactBox_Admin.aspx?Page=AddSubCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "&Var=" + RXServer.Web.RequestValues.Var + "'>&nbsp;Edit</a></td></tr></table></td>";

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
                    Int32 ix = (pages - 1) * limit;
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

            this.ltrSubList.Text = list;

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindClientList()
    {
        String function_name = "BindClientList";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ContactBox/ClientList");
            String list = "";

            String Url = "";
            Int32 limit = 10;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index / limit) + 1;
            Int32 pages = 0;

            Url = RXMali.GetLastUrl(Request.Url.ToString());

            //RXServer.Modules.CalendarList cl = new RXServer.Modules.CalendarList("Calendar_" + RXServer.Web.RequestValues.ModId.ToString());

            RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("Client_" + RXServer.Web.RequestValues.ModId, LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Order, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Descending, index, limit);
            RXServer.Modules.Base.List t = new RXServer.Modules.Base.List("Client_" + RXServer.Web.RequestValues.ModId);


            total = t.Count();

            list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

            if (total > 0)
            {
                list += "<tr style='background-color: #666666' class='Text11_white'>";
                list += "<td valign='top'>Name</td>";
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
                        list += "<tr style='background-color: white; vertical-align: middle;'  class='Text11_gray'>";
                    }
                    else
                    {
                        list += "<tr style='background-color: #EFEFEF; vertical-align: middle;'  class='Text11_gray'>";
                    }
                    list += "<td valign='middle'><a href='ContactBox_Admin.aspx?Page=AddClient&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "&Var=" + RXServer.Web.RequestValues.Var + "' class='underline'>" + item.Value25 + "</a></td>";
                    if (item.Value6 == "true")
                    {
                        list += "<td valign='middle' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_on.gif' title='Active' class='img_noborder' /></td>";
                    }
                    else
                    {
                        list += "<td valign='middle' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_off.gif' title='Unactive' class='img_noborder' /></td>";
                    }

                    list += "<td valign='middle' align='center'><a href='" + Request.Url.ToString() + "&Up=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_up.gif' alt='Move Up' class='img_noborder' /></a> / <a href='" + Request.Url.ToString() + "&Down=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_down.gif' alt='Move Down' class='img_noborder' /></a></td>";
                    list += "<td valign='middle'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this item ( " + item.Value25 + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this item( " + item.Value25 + " )?')\">Delete</a></td></tr></table></td>";
                    list += "<td valign='middle'><table cellpadding='0' cellspacing='0'><tr><td><a href='ContactBox_Admin.aspx?Page=AddClient&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "&Var=" + RXServer.Web.RequestValues.Var + "'><img src='../../../App_Themes/WebAdmin/Images/icon_edit.gif' class='img_noborder' /></a></td><td><a href='ContactBox_Admin.aspx?Page=AddClient&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "&Var=" + RXServer.Web.RequestValues.Var + "'>&nbsp;Edit</a></td></tr></table></td>";

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
                    Int32 ix = (pages - 1) * limit;
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

            this.ltrClientList.Text = list;

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
            if (RXServer.Web.RequestValues.Page == "Content" || RXServer.Web.RequestValues.Page == "")
            {
                list += "<td><a href='ContactBox_Admin.aspx?Page=Content&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_on'>Content</a></td>";
            }
            else
            {
                list += "<td><a href='ContactBox_Admin.aspx?Page=Content&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_off'>Content</a></td>";
            }
            list += "<td style='width:20px;'></td>";
            if (RXServer.Web.RequestValues.Page == "Category")
            {
                list += "<td><a href='ContactBox_Admin.aspx?Page=Category&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_on'>Categories</a></td>";
            }
            else
            {
                list += "<td><a href='ContactBox_Admin.aspx?Page=Category&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_off'>Categories</a></td>";
            }
            list += "<td style='width:20px;'></td>";
            if (RXServer.Web.RequestValues.Page == "Subcategory")
            {
                list += "<td><a href='ContactBox_Admin.aspx?Page=Subcategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_on'>Subcategories</a></td>";
            }
            else
            {
                list += "<td><a href='ContactBox_Admin.aspx?Page=Subcategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_off'>Subcategories</a></td>";
            }
            list += "<td style='width:20px;'></td>";
            if (RXServer.Web.RequestValues.Page == "Clients")
            {
                list += "<td><a href='ContactBox_Admin.aspx?Page=Clients&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_on'>Clients</a></td>";
            }
            else
            {
                list += "<td><a href='ContactBox_Admin.aspx?Page=Clients&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_off'>Clients</a></td>";
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
            if (RXServer.Web.RequestValues.Page == "Category" || RXServer.Web.RequestValues.Page == "AddCategory")
            {

                list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
                list += "<tr>";
                list += "<td style='width:10px;'><td><img src='../../../App_Themes/WebAdmin/Images/submenu_divider.gif' class='img_noborder' /></td><td style='width:10px;'>";
                if (RXServer.Web.RequestValues.Page == "AddCategory")
                {
                    list += "<td><a href='ContactBox_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='ContactBox_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_on'>Add Category</a></td>";
                }
                else
                {
                    list += "<td><a href='ContactBox_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='ContactBox_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_off'>Add Category</a></td>";
                }
                list += "<td style='width:20px; height:34px;'></td>";
                list += "</tr>";
                list += "</table>";
            }

            if (RXServer.Web.RequestValues.Page == "Subcategory" || RXServer.Web.RequestValues.Page == "AddSubCategory")
            {

                list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
                list += "<tr>";
                list += "<td style='width:10px;'><td><img src='../../../App_Themes/WebAdmin/Images/submenu_divider.gif' class='img_noborder' /></td><td style='width:10px;'>";
                if (RXServer.Web.RequestValues.Page == "AddSubCategory")
                {
                    list += "<td><a href='ContactBox_Admin.aspx?Page=AddSubCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='ContactBox_Admin.aspx?Page=AddSubCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_on'>Add Subcategory</a></td>";
                }
                else
                {
                    list += "<td><a href='ContactBox_Admin.aspx?Page=AddSubCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='ContactBox_Admin.aspx?Page=AddSubCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_off'>Add Subcategory</a></td>";
                }
                list += "<td style='width:20px; height:34px;'></td>";
                list += "</tr>";
                list += "</table>";
            }

            if (RXServer.Web.RequestValues.Page == "Clients" || RXServer.Web.RequestValues.Page == "AddClient")
            {

                list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
                list += "<tr>";
                list += "<td style='width:10px;'><td><img src='../../../App_Themes/WebAdmin/Images/submenu_divider.gif' class='img_noborder' /></td><td style='width:10px;'>";
                if (RXServer.Web.RequestValues.Page == "AddClient")
                {
                    list += "<td><a href='ContactBox_Admin.aspx?Page=AddClient&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='ContactBox_Admin.aspx?Page=AddClient&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_on'>Add Client</a></td>";
                }
                else
                {
                    list += "<td><a href='ContactBox_Admin.aspx?Page=AddClient&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='ContactBox_Admin.aspx?Page=AddClient&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&Var=" + RXServer.Web.RequestValues.Var + "' class='submenu_off'>Add Client</a></td>";
                }
                list += "<td style='width:20px; height:34px;'></td>";
                list += "</tr>";
                list += "</table>";
            }

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

            sm.Text2 = Server.HtmlEncode(this.txtTitle.Text);
            sm.Text4 = Server.HtmlEncode(this.RadEditor1.Content);
            sm.Text6 = Server.HtmlEncode(this.RadEditor2.Content);
            sm.Text7 = Server.HtmlEncode(this.RadEditor3.Content);
            sm.Text8 = Server.HtmlEncode(this.txtMailSubject.Text);
            sm.Text9 = Server.HtmlEncode(this.txtFromAdress.Text);

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
                this.imgError2_1.Visible = true;
            }
            else
            {
                sm.ModelId = this.ddlModels.SelectedItem.Value;
            }

            if (!RXMali.IsEmail(this.txtFromAdress.Text))
            {
                valid = false;
                Errors += " - " + RXMali.GetXMLNode("Error/email") + "<br />";
                this.imgError2_2.Visible = true;
            }

            if (valid)
            {
                sm.Save();
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

    public void DeleteItem(String Id)
    {
        String function_name = "DeleteCategory";
        try
        {
            Int32 obdId = 0;
            Int32.TryParse(Id, out obdId);
            if (obdId > 0)
            {
                RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obdId);
                i.Delete();
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
            this.imgError2_1.Visible = false;
            this.imgError3_1.Visible = false;
            this.imgError3a_1.Visible = false;
            this.imgError3a_2.Visible = false;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveCategory_Click";
        try
        {
            if (CheckCategory())
            {                
                Boolean valid = true;
                if (this.txtCategoryName.Text == "")
                {
                    valid = false;
                    ErrorList += " - Please write a name";
                    this.imgError3_1.Visible = true;
                }


                if (valid)
                {
                    if (RXServer.Web.RequestValues.ViewId != "")   // EDIT Item
                    {
                        Int32 obd_id = 0;

                        Int32.TryParse(RXServer.Web.RequestValues.ViewId, out obd_id);

                        if (obd_id > 0)
                        {
                            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
                            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obd_id);

                            i.Alias = "Category_" + RXServer.Web.RequestValues.ModId;
                            i.Status = 1;
                            i.Language = 1;
                            i.SitId = 1;
                            i.PagId = RXServer.Web.RequestValues.PagId;
                            i.ModId = RXServer.Web.RequestValues.ModId;
                            i.Value25 = Server.HtmlEncode(this.txtCategoryName.Text);

                            if (this.cbShowItem.Checked == true)
                            {
                                i.Value6 = "true";
                            }
                            else
                            {
                                i.Value6 = "false";
                            }

                            i.Save();                            
                        }
                    }
                    else     // ADD Item
                    {
                        try
                        {
                            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
                            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item();


                            i.Alias = "Category_" + RXServer.Web.RequestValues.ModId;
                            i.Status = 1;
                            i.Language = 1;
                            i.SitId = 1;
                            i.PagId = RXServer.Web.RequestValues.PagId;
                            i.ModId = RXServer.Web.RequestValues.ModId;
                            i.Value25 = Server.HtmlEncode(this.txtCategoryName.Text);

                            if (this.cbShowItem.Checked == true)
                            {
                                i.Value6 = "true";
                            }
                            else
                            {
                                i.Value6 = "false";
                            }                       

                            i.Save();
                        }
                        catch (Exception ex)
                        {
                            this.ErrorBox.Visible = true;
                            this.ltrErrors.Text = ex.ToString();
                        }
                    }
                               

                    string Url = "";

                    Url = RXMali.GetLastUrl(Request.Url.ToString());

                    Url = Url.Replace("&ViewId=" + RXServer.Web.RequestValues.ViewId, "");
                    Url = Url.Replace("AddCategory", "Category");

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
    protected void btnSaveSubCategory_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveSubCategory_Click";
        try
        {
            if (CheckCategory())
            {
                Boolean valid = true;
                if (this.txtSubCategoryName.Text == "")
                {
                    valid = false;
                    ErrorList += " - Please write a name" + "<br />";
                    this.imgError3a_1.Visible = true;
                }
                if (this.txtSubCategoryMail.Text == "")
                {
                    valid = false;
                    ErrorList += " - Please write an email" + "<br />";
                    this.imgError3a_2.Visible = true;
                }

                if (!RXMali.IsEmail(this.txtSubCategoryMail.Text) && this.txtSubCategoryMail.Text != "")
                {
                    valid = false;
                    ErrorList += " - " + RXMali.GetXMLNode("Error/email") + "<br />";
                    this.imgError3a_2.Visible = true;
                }

                if (valid)
                {
                    if (RXServer.Web.RequestValues.ViewId != "")   // EDIT Item
                    {
                        Int32 obd_id = 0;

                        Int32.TryParse(RXServer.Web.RequestValues.ViewId, out obd_id);

                        if (obd_id > 0)
                        {
                            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
                            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obd_id);

                            i.Alias = "Subcategory_" + this.ddlCategory.SelectedValue + "_" + RXServer.Web.RequestValues.ModId;
                            i.Status = 1;
                            i.Language = 1;
                            i.SitId = 1;
                            i.PagId = RXServer.Web.RequestValues.PagId;
                            i.ModId = RXServer.Web.RequestValues.ModId;
                            i.Value25 = Server.HtmlEncode(this.txtSubCategoryName.Text);
                            i.Value26 = Server.HtmlEncode(this.txtSubCategoryMail.Text);
                            i.Value27 = Server.HtmlEncode(this.ddlCategory.SelectedValue);

                            if (this.cbShowSubCategory.Checked == true)
                            {
                                i.Value6 = "true";
                            }
                            else
                            {
                                i.Value6 = "false";
                            }

                            i.Save();
                        }
                    }
                    else     // ADD Item
                    {
                        try
                        {
                            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
                            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item();

                            i.Alias = "Subcategory_" + this.ddlCategory.SelectedValue + "_" + RXServer.Web.RequestValues.ModId;
                            i.Status = 1;
                            i.Language = 1;
                            i.SitId = 1;
                            i.PagId = RXServer.Web.RequestValues.PagId;
                            i.ModId = RXServer.Web.RequestValues.ModId;
                            i.Value25 = Server.HtmlEncode(this.txtSubCategoryName.Text);
                            i.Value26 = Server.HtmlEncode(this.txtSubCategoryMail.Text);
                            i.Value27 = Server.HtmlEncode(this.ddlCategory.SelectedValue);

                            if (this.cbShowSubCategory.Checked == true)
                            {
                                i.Value6 = "true";
                            }
                            else
                            {
                                i.Value6 = "false";
                            }

                            i.Save();
                        }
                        catch (Exception ex)
                        {
                            this.ErrorBox.Visible = true;
                            this.ltrErrors.Text = ex.ToString();
                        }
                    }

                

                    string Url = "";

                    Url = RXMali.GetLastUrl(Request.Url.ToString());

                    Url = Url.Replace("&ViewId=" + RXServer.Web.RequestValues.ViewId, "");
                    Url = Url.Replace("AddSubCategory", "Subcategory");

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
    protected void btnSaveClient_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveClient_Click";
        try
        {
                Boolean valid = true;
                if (this.txtClientName.Text == "")
                {
                    valid = false;
                    ErrorList += " - Please write a name";
                    this.imgError3c_1.Visible = true;
                }

                if (valid)
                {

                    if (RXServer.Web.RequestValues.ViewId != "")   // EDIT Item
                    {
                        Int32 obd_id = 0;

                        Int32.TryParse(RXServer.Web.RequestValues.ViewId, out obd_id);

                        if (obd_id > 0)
                        {
                            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
                            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obd_id);

                            i.Alias = "Client_" + RXServer.Web.RequestValues.ModId;
                            i.Status = 1;
                            i.Language = 1;
                            i.SitId = 1;
                            i.PagId = RXServer.Web.RequestValues.PagId;
                            i.ModId = RXServer.Web.RequestValues.ModId;
                            i.Value25 = Server.HtmlEncode(this.txtClientName.Text);

                            if (this.cbShowClient.Checked == true)
                            {
                                i.Value6 = "true";
                            }
                            else
                            {
                                i.Value6 = "false";
                            }

                            i.Save();
                        }
                    }
                    else     // ADD Item
                    {
                        try
                        {
                            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
                            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item();

                            i.Alias = "Client_" + RXServer.Web.RequestValues.ModId;
                            i.Status = 1;
                            i.Language = 1;
                            i.SitId = 1;
                            i.PagId = RXServer.Web.RequestValues.PagId;
                            i.ModId = RXServer.Web.RequestValues.ModId;
                            i.Value25 = Server.HtmlEncode(this.txtClientName.Text);

                            if (this.cbShowClient.Checked == true)
                            {
                                i.Value6 = "true";
                            }
                            else
                            {
                                i.Value6 = "false";
                            }

                            i.Save();
                        }
                        catch (Exception ex)
                        {
                            this.ErrorBox.Visible = true;
                            this.ltrErrors.Text = ex.ToString();
                        }
                    }                           

                    string Url = "";

                    Url = RXMali.GetLastUrl(Request.Url.ToString());

                    Url = Url.Replace("&ViewId=" + RXServer.Web.RequestValues.ViewId, "");
                    Url = Url.Replace("AddClient", "Clients");

                    RXServer.Web.Redirect.To(Url);
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

    public Boolean CheckCategory()
    {
        String function_name = "CheckCategory";
        try
        {
            Boolean valid = true;
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
            if (modelId > 1)
            {
                this.ddlModels.Items.Add(new ListItem("Medium", "2"));
            }
            if (modelId > 2)
            {
                this.ddlModels.Items.Add(new ListItem("Large", "3"));
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    private void PopulateListCategories()
    {
        String function_name = "PopulateListCategories";
        try
        {
            RXServer.Modules.Base.List cat = new RXServer.Modules.Base.List("Category_" + RXServer.Web.RequestValues.ModId);

            this.ddlListCategory.Items.Add(new ListItem("Select a category", "0"));

            foreach (RXServer.Modules.Base.List.Item item in cat)
            {
                this.ddlListCategory.Items.Add(new ListItem(Server.HtmlDecode(item.Value25), item.Id.ToString()));
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    private void PopulateListCategories2()
    {
        String function_name = "PopulateListCategories2";
        try
        {
            RXServer.Modules.Base.List cat = new RXServer.Modules.Base.List("Category_" + RXServer.Web.RequestValues.ModId);

            foreach (RXServer.Modules.Base.List.Item item in cat)
            {
                this.ddlCategory.Items.Add(new ListItem(Server.HtmlDecode(item.Value25), item.Id.ToString()));
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void ddlListCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlListCategory_SelectedIndexChanged";
        try
        {
            BindSubCategoryList();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
}


