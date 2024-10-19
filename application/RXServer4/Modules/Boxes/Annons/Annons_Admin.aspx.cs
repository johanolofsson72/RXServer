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

public partial class Modules_Boxes_Annons_Annons_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_Annons_Annons_Admin";
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
                        this.Page_1.Visible = true;
                        BindTextData();
                    }
                    break;

                case "Categories":
                    if (RXServer.Web.RequestValues.DelId != "")
                    {
                        DeleteCategory(RXServer.Web.RequestValues.DelId);
                    }
                    if (!Page.IsPostBack)
                    {
                        this.Page_2.Visible = true;
                        if (Request["Up"] != null)
                        {
                            MoveUpItem(Request["Up"]);
                        }
                        if (Request["Down"] != null)
                        {
                            MoveDownItem(Request["Down"]);
                        }
                        BindListData();
                    }
                    break;


                case "AddCategory":
                    if (!Page.IsPostBack)
                    {
                        this.Page_3.Visible = true;
                        if (RXServer.Web.RequestValues.ViewId != "")
                        {
                            BindCategoryData(RXServer.Web.RequestValues.ViewId);
                        }
                    }
                    break;

                default:
                    if (!Page.IsPostBack)
                    {
                        this.Page_1.Visible = true;
                        BindTextData();
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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            //this.txtTitle.Text = Server.HtmlDecode(sm.Title);
            this.txtHeader.Text = Server.HtmlDecode(sm.Text1).Replace("`", "'");
            //this.RadEditor1.Content = Server.HtmlDecode(sm.);
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    
    public void BindCategoryData(String lId)
    {
        String function_name = "BindLinkData";
        try
        {
            Int32 obd_id = 0;
            Int32.TryParse(lId, out obd_id);

            RXServer.Modules.Base.List.Item e = new LiquidCore.List.Item(obd_id);

            this.txtCatTitle.Text = Server.HtmlDecode(e.Value25).Replace("`","'");

            if (e.Value6 == "true")
            {
                cbShowLink.Checked = true;
            }
            else
            {
                cbShowLink.Checked = false;
            }

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
            String list = "";

            String Url = "";
            Int32 limit = 10;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index / limit) + 1;
            Int32 pages = 0;

            Url = RXMali.GetLastUrl(Request.Url.ToString());

            RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("Forum_" + RXServer.Web.RequestValues.ModId);

            total = cl.Count();

            list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

            if (total > 0)
            {
                list += "<tr style='background-color: #666666' class='Text11_white'>";
                //list += "<td valign='top'>Id</td>";
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
                        list += "<tr style='background-color: white;'  class='Text11_gray'>";
                    }
                    else
                    {
                        list += "<tr style='background-color: #EFEFEF;'  class='Text11_gray'>";
                    }
                    list += "<td valign='top'><a href='Annons_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "' class='underline'>" + Server.HtmlDecode(item.Value25).Replace("`", "'") + "</a></td>";
                    
                    if (item.Value6 == "true")
                    {
                        list += "<td valign='top' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_on.gif' title='Active' class='img_noborder' /></td>";
                    }
                    else
                    {
                        list += "<td valign='top' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_off.gif' title='Unactive' class='img_noborder' /></td>";
                    }

                    list += "<td valign='top' align='center'><a href='" + Request.Url.ToString() + "&Up=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_up.gif' class='img_noborder' alt='Move Up' /></a> / <a href='" + Url + "&Down=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_arrow_down.gif' class='img_noborder' alt='Move Down' /></a></td>";
                    list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this category( " +  Server.HtmlDecode(item.Value25).Replace("`", "'") + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + item.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this category( " + Server.HtmlDecode(item.Value25).Replace("`", "'") + " )?')\">Delete</a></td></tr></table></td>";
                    list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='Annons_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_edit.gif' class='img_noborder' /></a></td><td><a href='Annons_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "&amp;ViewId=" + item.Id.ToString() + "'>&nbsp;Edit</a></td></tr></table></td>";

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

            this.ltrCategoryList.Text = list;

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
            if (RXServer.Web.RequestValues.Page == "Text" || RXServer.Web.RequestValues.Page == "")
            {
                list += "<td><a href='Annons_Admin.aspx?Page=Text&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_on'>Text</a></td>";
            }
            else
            {
                list += "<td><a href='Annons_Admin.aspx?Page=Text&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_off'>Text</a></td>";
            }
            list += "<td style='width:20px;'></td>";

            if (RXServer.Web.RequestValues.Page == "Categories")
            {
                list += "<td><a href='Annons_Admin.aspx?Page=Categories&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_on'>Categories</a></td>";
            }
            else
            {
                list += "<td><a href='Annons_Admin.aspx?Page=Categories&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_off'>Categories</a></td>";
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
            if (RXServer.Web.RequestValues.Page == "AddLink")
            {
                list += "<td><a href='Annons_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='Annons_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_on'>Add Category</a></td>";
            }
            else
            {
                list += "<td><a href='Annons_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='Annons_Admin.aspx?Page=AddCategory&SitId=" + RXServer.Web.RequestValues.SitId + "&PagId=" + RXServer.Web.RequestValues.PagId + "&ModId=" + RXServer.Web.RequestValues.ModId + "' class='submenu_off'>Add Category</a></td>";
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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            //sm.Title = Server.HtmlEncode(this.txtTitle.Text);
            sm.Text1 = Server.HtmlEncode(this.txtHeader.Text).Replace("'", "`");
            //sm.Text = Server.HtmlEncode(this.RadEditor1.Content);

            sm.Save();
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void DeleteCategory(String Id)
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

               // + DELETE MERA
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
                if (RXServer.Web.RequestValues.ViewId != "")   // EDIT Link
                {
                    try
                    {
                        Int32 obd_id = 0;

                        Int32.TryParse(RXServer.Web.RequestValues.ViewId, out obd_id);

                        if (obd_id > 0)
                        {
                            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obd_id);

                            if (this.cbShowLink.Checked == true)
                            {
                                i.Value6 = "true";
                            }
                            else
                            {
                                i.Value6 = "false";
                            }

                            i.Alias = "Forum_" + RXServer.Web.RequestValues.ModId;
                            i.Status = 1;
                            i.Language = 1;
                            i.SitId = 1;
                            i.PagId = RXServer.Web.RequestValues.PagId;
                            i.ModId = RXServer.Web.RequestValues.ModId;
                            i.Value25 = Server.HtmlEncode(this.txtCatTitle.Text).Replace("'","`");
                            i.Value30 = DateTime.Now.ToString();
                            i.Save();
                        }
                    }
                    catch (Exception ex)
                    {
                        this.ErrorBox.Visible = true;
                        this.ltrErrors.Text = ex.ToString();
                    }

                }
                else     // ADD LINK
                {
                    try
                    {
                        RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item();

                        if (this.cbShowLink.Checked == true)
                        {
                            i.Value6 = "true";
                        }
                        else
                        {
                            i.Value6 = "false";
                        }

                        i.Alias = "Forum_" + RXServer.Web.RequestValues.ModId;
                        i.Status = 1;
                        i.Language = 1;
                        i.SitId = 1;
                        i.PagId = RXServer.Web.RequestValues.PagId;
                        i.ModId = RXServer.Web.RequestValues.ModId;
                        i.Value25 = Server.HtmlEncode(this.txtCatTitle.Text).Replace("'", "`");
                        i.Value30 = DateTime.Now.ToString();
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
                Url = Url.Replace("AddCategory", "Categories");

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

            if (this.txtCatTitle.Text == "")
            {
                valid = false;
                ErrorList += "- Please write a name for the link<br />";
                this.imgError2_1.Visible = true;
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
            i.ChangeOrderUp();

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
            i.ChangeOrderDown();

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
  
}
