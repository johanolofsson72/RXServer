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
using System.Numeric;

public partial class Modules__System_AdminView_PagePage : System.Web.UI.UserControl
{
    String class_name = "Modules__System_AdminView_PagePage";
    String ErrorList = "";
    String Links = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            ErrorList = "";
            this.ErrorBox.Visible = false;
            HideErrors();
            if (RXServer.Web.RequestValues.Page == "Pages")
            {

                this.PagePage_1.Visible = false;

                this.PageSubMenu.Visible = true;
                BindPagesSubMenuData();

                switch (RXServer.Web.RequestValues.SubPage)
                {

                    case "Modules":
                        this.PagePage_3.Visible = true;
                        if (RXServer.Web.RequestValues.DelId != "")
                        {
                            DeleteModule(RXServer.Web.RequestValues.DelId);
                        }
                        else
                        {
                            BindModulesData(RXServer.Web.RequestValues.ViewId);
                        }
                        break;

                    case "Edit":
                        this.PagePage_2.Visible = true;
                        ContentPlaceHolder cph = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
                        Literal help = cph.FindControl("ltrHelpText") as Literal;
                        help.Text = RXMali.GetXMLHelpNode("ContentManager/Pages/Add");

                        if (RXServer.Web.RequestValues.ViewId != "")
                        {
                            if (!Page.IsPostBack)
                            {
                                BindPagesEditData(RXServer.Web.RequestValues.ViewId);
                            }
                        }
                        
                        break;

                    default:

                        this.PagePage_1.Visible = true;
                        if (RXServer.Web.RequestValues.DelId != "")
                        {
                            DeletePage(RXServer.Web.RequestValues.DelId);
                        }
                        else
                        {
                            BindPagesData();
                        }
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindPagesData()
    {
        String function_name = "BindPagesData";
        try
        {
            ContentPlaceHolder cph = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
            Literal help = cph.FindControl("ltrHelpText") as Literal;
            help.Text = RXMali.GetXMLHelpNode("ContentManager/Pages/List");
         
            Int32 staId,Level1,Level2,Level3,Level4  = 0;

            Int32.TryParse(RXServer.Web.RequestValues.StaId.ToString(), out staId);
            Int32.TryParse(RXServer.Web.RequestValues.Level1.ToString(), out Level1);
            Int32.TryParse(RXServer.Web.RequestValues.Level2.ToString(), out Level2);
            Int32.TryParse(RXServer.Web.RequestValues.Level3.ToString(), out Level3);
            Int32.TryParse(RXServer.Web.RequestValues.Level4.ToString(), out Level4);

            if (staId == 0)
            {
                staId = 1;
            }

            string Url = "";
            Int32 limit = 10;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index/limit)+1;
            Int32 pages = 0;


            Url = RXMali.GetLastUrl(Request.Url.ToString());
            Url = Url.Replace("&PagId=" + RXServer.Web.RequestValues.PagId, "");
            Url = Url.Replace("&Orderby=" + RXServer.Web.RequestValues.Orderby, "");
            Url = Url.Replace("&Sort=" + RXServer.Web.RequestValues.Sort, "");

            RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, RXServer.Web.RequestValues.PagId, staId, LiquidCore.LiquidCore.Definition.MenuDefinition.SortParamEnum.Order, LiquidCore.LiquidCore.Definition.MenuDefinition.SortOrderEnum.Ascending, index, limit);

            RXServer.Modules.Menu mt = new RXServer.Modules.Menu(1, RXServer.Web.RequestValues.PagId, staId);
            total = mt.Count;
            
            if (RXServer.Web.RequestValues.PagId > 0)
            {
                Links = " <a href='" + Url + "'>Pages</a> » ";
                GetLinks(RXServer.Web.RequestValues.PagId);
            }
            else
            {
                Links = " Pages ";
            }


            this.lblHeaderPage1.Text = Links;

            String list = "";

            list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

            if (m.Count > 0)
            {
                list += "<tr style='background-color: #666666' class='Text11_white'>";
                list += "<td valign='top'></td>";
                list += "<td valign='top'>Id</td>";
                list += "<td valign='top' style='width: 200px;'>Title</td>";

                //list += "<td valign='top'>Friendly Url</td>";
                list += "<td valign='top' align='center'>Visible</td>";
                list += "<td valign='top' align='center'>Subpages</td>";
                list += "<td valign='top' align='center'>Modules</td>";
                //list += "<td valign='top' align='center'>Rights</td>";
                list += "<td valign='top' align='center'>Delete</td>";
                list += "<td valign='top' align='center'>Edit</td>";                

                list += "</tr>";

                Int32 counter = 0;
                foreach (LiquidCore.Menu.Item mItem in m)
                {
                    if ((counter % 2) == 0)
                    {
                        list += "<tr style='background-color: white;'  class='Text11_gray'>";
                    }
                    else
                    {
                        list += "<tr style='background-color: #EFEFEF;'  class='Text11_gray'>";
                    }

                    if (mItem.HasChildren)
                    {
                        String Url2 = Url.Replace("&Index=" + index, "");
                        list += "<td valign='top'><a href='" + Url2 + "&PagId=" + mItem.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_expand.gif' class='img_noborder' /></a></td>";
                    }
                    else
                    {
                        list += "<td valign='top'>&nbsp;</td>";
                    }
                    list += "<td valign='top'>" + mItem.Id.ToString() + "</td>";
                    list += "<td valign='top'>" + mItem.Title + "</td>";
                    //list += "<td valign='top'>getFURL(" + mItem.Id.ToString() + ")</td>";

                    if (mItem.Hidden)
                    {
                        list += "<td valign='top' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_off.gif' class='img_noborder' /></td>";
                    }
                    else
                    {
                        list += "<td valign='top' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_visible_on.gif' class='img_noborder' /></td>";
                    }

                    list += "<td valign='top' align='center'><a href='" + Url + "&PagId=" + mItem.Id.ToString() + "'>" + RXServer.Modules.Menu.GetTotalChildsOnPage(1, mItem.Id) + "</a></td>";
                    list += "<td valign='top' align='center'><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&SubPage=Modules&ViewId=" + mItem.Id + "'>" + RXServer.Modules.Modules.GetTotalModulesOnPage(mItem.Id) + "</a></td>";
                    //list += "<td valign='top' align='center'>Rights(" + mItem.Id.ToString() + ")</td>";
                    if (mItem.Id != 1)
                    {
                        list += "<td valign='top' align='center'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + mItem.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this page( " + mItem.Title + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + mItem.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this page( " + mItem.Title + " )?')\">Delete</a></td></tr></table></td>";
                    }
                    else
                    {
                        list += "<td>&nbsp;</td>";
                    }
                    list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&SubPage=Edit&ViewId=" + mItem.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_edit.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&SubPage=Edit&ViewId=" + mItem.Id.ToString() + "'>&nbsp;Edit</a></td></tr></table></td></td>";
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
                double t1,t2;
                t1 = total;
                t2 = limit;
                pages = (int)Math.Ceiling(t1 / t2);
                Url = Url.Replace("&Index=" + index, "");
                
                if(RXServer.Web.RequestValues.PagId > 0)                    
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

            this.ltrPageList.Text = list;

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindPagesSubMenuData()
    {
        String function_name = "BindPagesSubMenuData";
        try
        {
            String list = "";

            list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
            list += "<tr>";
            list += "<tr><td style='width:10px; height: 34px;'></td>";
            if (RXServer.Web.RequestValues.StaId == "" || RXServer.Web.RequestValues.StaId.ToString() == "1")
            {
                list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Pages&StaId=1' class='submenu_on'>Active</a></td>";
            }
            else
            {
                list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Pages&StaId=1' class='submenu_off'>Active</a></td>";
            }
            list += "<td style='width:10px;'>&nbsp;</td>";
            if (RXServer.Web.RequestValues.StaId == "2")
            {
                list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Pages&StaId=2' class='submenu_on'>Unactive</a></td>";
            }
            else
            {
                list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Pages&StaId=2' class='submenu_off'>Unactive</a></td>";
            }

            list += "<td style='width:10px;'>&nbsp;</td>";
            if (RXServer.Web.RequestValues.StaId == "3")
            {
                list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Pages&StaId=3' class='submenu_on'>Userpages</a></td>";
            }
            else
            {
                list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Pages&StaId=3' class='submenu_off'>Userpages</a></td>";
            }

            list += "</tr>";
            list += "</table>";

            this.ltrPageSubMenuList.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindPagesEditData(String editId)
    {
        String function_name = "BindPagesEditData";
        try
        {
            Int32 pId = 0;
            Int32.TryParse(editId, out pId);

            this.lblHeaderPage2.Text = "Edit Page";
            //this.btnAddPag.Text = "Edit Page";

            if (pId > 0)
            {
                RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(pId);
                this.txtPageName.Text = mItem.Title;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private Boolean EditPage(String PagId)
    {
        String function_name = "EditPage";
        try
        {
            Int32 pId = 0;

            Int32.TryParse(PagId, out pId);

            if (pId > 0)
            {
                RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(pId);
                mItem.Title = this.txtPageName.Text;
                mItem.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }

    }

    protected void btnAddPag_Click(object sender, EventArgs e)
    {
        String function_name = "btnAddPag_Click";
        try
        {
            if (this.txtPageName.Text != "")
            {
                if (EditPage(RXServer.Web.RequestValues.ViewId))
                {
                    String Url = "";
                    Url = RXMali.GetLastUrl(Request.Url.ToString());
                    Url = Url.Replace("&SubPage=Edit&ViewId=" + RXServer.Web.RequestValues.ViewId, "");

                    RXServer.Web.Redirect.To(Url);
                }
                else
                {
                    this.ErrorBox.Visible = true;
                    this.ltrErrors.Text = "- Page wasnt edited!<br />";
                }
            }
            else
            {
                ErrorList += " - You must fill in a pagename<br />";
                this.imgError2_1.Visible = true;
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

    public void DeletePage(String pagId)
    {
        String function_name = "DeletePage";
        try
        {
            Int32 PgId = 0;
            Int32.TryParse(pagId, out PgId);
            if (PgId > 0)
            {
                RXServer.Modules.Menu.DeletePage(1, PgId);

                /*string activeDir = Server.MapPath("~/Upload/Pages/" + PgId + "/");

                if (System.IO.Directory.Exists(activeDir))
                {
                    foreach (string sFile in System.IO.Directory.GetFiles(activeDir))
                    {
                        System.IO.File.Delete(sFile);                        
                    }

                    //System.IO.Directory.Delete(activeDir);
                }*/
            }

            string Url = "";

            Url = RXMali.GetLastUrl(Request.Url.ToString());
            Url = Url.Replace("&DelId=" + PgId, "");

            RXServer.Web.Redirect.To(Url);
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindModulesData(String PagId)
    {
        String function_name = "BindModulesData";
        try
        {
            Int32 pId = 0;

            Int32.TryParse(PagId, out pId);

            String list = "";

            if (pId > 0)
            {
                RXServer.Modules.Modules m = RXServer.Modules.Modules.GetModulesByPagId(1, pId);
                RXServer.Modules.Menu.Item p = new RXServer.Modules.Menu.Item(pId);

                list += "<span class='Text18_bold_gray'>PageId » " + PagId + " » " + p.Title + "</span>";
                list += "<br />";
                list += "<hr class='line' />";
                list += "<br />";
                list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

                if (m.Count > 0)
                {

                    list += "<tr style='background-color: #666666' class='Text11_white'>";
                    list += "<td valign='top'>Id</td>";
                    list += "<td valign='top'>Title</td>";
                    list += "<td valign='top'>ModDef</td>";
                    list += "<td valign='top'>Edit</td>";
                    list += "<td valign='top'>Delete</td>";
                    list += "</tr>";

                    Int32 counter = 0;
                    foreach (LiquidCore.Module mod in m)
                    {
                        if ((counter % 2) == 0)
                        {
                            list += "<tr style='background-color: white;'  class='Text11_gray'>";
                        }
                        else
                        {
                            list += "<tr style='background-color: #EFEFEF;'  class='Text11_gray'>";
                        }
                        list += "<td valign='top'>" + mod.Id.ToString() + "</td>";

                        LiquidCore.ModDef md = new LiquidCore.ModDef(mod.MdeId);
                        list += "<td valign='top'>" + md.Alias + "</td>";
                        list += "<td valign='top'>" + mod.MdeId + "</td>";

                        #region adminModLink

                        String modSrc = "";
                        modSrc = mod.Src;
                        modSrc = modSrc.Replace(".ascx", "_Admin.aspx");

                        string adminFile = Server.MapPath("~/" + modSrc + "/");


                        #endregion

                        if (File.Exists(adminFile))
                        {
                            list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='../../../" + modSrc + "?SitId=1&PagId=" + mod.PagId + "&ModId=" + mod.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_edit.gif' class='img_noborder' /></a></td><td><a href='../../../" + modSrc + "?SitId=1&PagId=" + mod.PagId + "&ModId=" + mod.Id.ToString() + "'>&nbsp;Edit</a></td></tr></table></td>";
                        }
                        else
                        {
                            list += "<td valign='top'>&nbsp;</td>";
                        }


                        if (!mod.AllPages)
                        {
                            list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + mod.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this module from page( " + mod.PagId + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + mod.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this module from page( " + mod.PagId + " )?')\">Delete</a></td></tr></table></td>";
                        }
                        else
                        {
                            list += "<td valign='top'>&nbsp;</td>";
                        }
                        list += "</tr>";
                        counter++;
                    }
                }
                else
                {
                    list += "<tr><td class='Text11_gray'>No Records was found.</td></tr>";
                }

                list += "</table>";
            }

            this.ltrModulesOnPageList.Text = list;

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void DeleteModule(String modId)
    {
        String function_name = "DeleteModule";
        try
        {
            Int32 MId = 0;
            Int32.TryParse(modId, out MId);
            if (MId > 0)
            {
                LiquidCore.Module m = new LiquidCore.Module(MId);
                m.Delete();
            }

            string Url = "";

            Url = RXMali.GetLastUrl(Request.Url.ToString());
            Url = Url.Replace("&DelId=" + MId, "");

            RXServer.Web.Redirect.To(Url);
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
        }
    }
    public void HideErrors()
    {
        String function_name = "HideErrors";
        try
        {
            // Add User
            //this.imgError3_1.Visible = false;
            //this.imgError3_2.Visible = false;
            //this.imgError3_3.Visible = false;
            //this.imgError3_4a.Visible = false;
            //this.imgError3_4b.Visible = false;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    public void GetLinks(Int32 pgId)
    {
        String function_name = "GetLinks";
        try
        {
            string Url = "";

            Url = RXMali.GetLastUrl(Request.Url.ToString());
            Url = Url.Replace("&PagId=" + RXServer.Web.RequestValues.PagId, "");
          
            RXServer.Modules.Menu.Item me = new RXServer.Modules.Menu.Item(pgId);
            if (me.ParentId > 0)
            {
                RXServer.Modules.Menu.Item me2 = new RXServer.Modules.Menu.Item(me.ParentId);
                Links = Links + " <a href='" + Url + "&PagId=" + me2.Id + "'>" + me2.Title + "</a> » ";
                GetLinks(me.ParentId);
            }
            else
            {
                RXServer.Modules.Menu.Item me3 = new RXServer.Modules.Menu.Item(RXServer.Web.RequestValues.PagId);
                Links = Links + me3.Title + " ";
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

}
