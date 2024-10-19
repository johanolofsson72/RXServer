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
using System.Text.RegularExpressions;

public partial class Modules_Boxes_Forum_Forum : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_Forum_Forum";
    String Url,Url2,Url3;
    


    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            

            HideWindows();

            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.Forum_admin.Visible = true;
                if (RXMali.GetLastUrl(this.Page.MasterPageFile) == "Template1.master")
                {
                    this.img_AdminEdit.OnClientClick = "javascript:showAdminForum(1," + this.PagId + "," + this.ModId + ",'4'); return false;";
                }
                else
                {
                    this.img_AdminEdit.OnClientClick = "javascript:showAdminForum(1," + this.PagId + "," + this.ModId + ",'3'); return false;";
                }
                this.img_AdminDelete.OnClientClick = "javascript:showAdminDeleteModule(1," + this.PagId + "," + this.ModId + "); return false;";
            }

            if (!Page.IsPostBack)
            {
                bindData();
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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);

            if (sm.Visible == "true" || RXServer.Auth.IsInRole("Admin"))
            {

                this.Forum_holder.Visible = true;

                this.lblThreadTitle.Text = Server.HtmlDecode(sm.Text1).Replace("`", "'");

                // Sets Module Width

                Int32 ModelId = 0;
                Int32.TryParse(sm.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize(ModelId.ToString());

                String _style = "";
                String _float = "";

                if (sm.Float == "")
                {
                    _float = "left";
                }
                else
                {
                    _float = sm.Float;
                }

                if (ModelId == 0)
                {
                    _width = 665;
                }

                _style = "position: relative; float: " + _float + "; width: " + _width + "px;";

                this.Forum_admin.Attributes.Add("style", _style);
                this.Forum_holder.Attributes.Add("style", _style);

                BindForumData();

                // CONTENT

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

            }
            else
            {
                this.Forum_holder.Visible = false;
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void BindForumData()
    {
        String function_name = "BindForumData";
        try
        {
            if (Request["c"] != null)
            {
                if (Request["c"].ToString() != "")
                {
                    if (RXServer.Web.RequestValues.Page == "ct")
                    {
                        LoadCreateThread(Request["c"].ToString());
                    }
                    else
                    {
                        if (Request["t"] != null)
                        {
                            if (Request["t"] != null)
                            {
                                BindPostData(Request["c"].ToString(), Request["t"].ToString());
                                if (RXServer.Web.RequestValues.Page == "re")
                                {
                                    LoadCreatePost(Request["c"].ToString(), Request["t"].ToString());
                                }
                            }
                            else
                            {
                                BindThreadData(Request["c"].ToString());
                            }
                        }
                        else
                        {
                            BindThreadData(Request["c"].ToString());
                        }
                    }
                }
                else
                {
                    BindCategoryData();
                }

            }
            else
            {
                BindCategoryData();
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    private void BindCategoryData()
    {
        String function_name = "BindCategoryData";
        try
        {
            String list = "";

            this.ForumList.Visible = true;

            RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("Forum_" + this.ModId);

            if (cl.Count > 0)
            {
                foreach (RXServer.Modules.Base.List.Item item in cl)
                {

                    if (item.Value6 == "true")
                    {
                        list += "<div style='position:relative; float: left; width: 580px; padding: 10px; margin-bottom: 2px; background-color: #FFF; border: 1px solid #CECECE;'>";
                        list += "<table cellspacing='0' cellpadding='0' style='width:100%'>";
                        list += "<tr class='Text12_black_bold'><td rowspan='2' style='width: 40px;'><img src='Images/Modules/Forum/icon_forum.jpg' alt='' /></td><td style='width: 10px;'>&nbsp;</td>";
                        list += "<td ><a href='" + Request.Url + "&c=" + item.Id + "'>" + item.Value25 + "</a></td>";
                        list += "<td style='width: 10px;'>&nbsp;</td><td style='width: 40px;'>" + Forum.GetTotalForumThreads(this.ModId, item.Id) + "</td>";
                        list += "<td style='width: 10px;'>&nbsp;</td><td style='width: 40px;'>" + Forum.GetTotalForumPosts(this.ModId, item.Id, 0) + "</td>";
                        list += "</tr>";
                        list += "<tr><td style='width: 10px;'>&nbsp;</td>";
                        list += "<td class='Text10_505050'>" + RXMali.GetXMLNode("Modules/Forum/last_post") + " " + Forum.GetLastPostInfo(this.ModId, item.Id, 0) +"</td>";
                        list += "<td style='width: 10px;'>&nbsp;</td><td class='Text10_505050 'style='width: 40px;'>" + RXMali.GetXMLNode("Modules/Forum/threads") + "</td>";
                        list += "<td style='width: 10px;'>&nbsp;</td><td class='Text10_505050' style='width: 40px;'>" + RXMali.GetXMLNode("Modules/Forum/posts") + "</td>";
                        list += "</tr>";
                        list += "</table></div>";
                    }
                }
            }

            this.ltrCategories.Text = list;

            String menu = "";            
            menu += "<table cellspacing='0' cellpadding='0' style='width:100%'>";
            menu += "<tr><td style='height: 20px;'>" + RXMali.GetXMLNode("Modules/Forum/home_directory") + "</td></tr>";
            menu += "</table>";

            this.ltrForumMenu.Text = menu;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    private void BindThreadData(String catId)
    {
        String function_name = "BindThreadData";
        try
        {
            String list = "";    

            Int32 cId = 0;
            Int32.TryParse(catId, out cId);

            //this.ForumSearch.Visible = true;
            //this.ForumHeader.Visible = true;
            this.ForumList.Visible = true;
            if (RXServer.Auth.AuthorizedUser.Identity.Authenticated)
            {
                this.ForumCreate.Visible = true;
            }

            Url = Request.Url.ToString();
            Url = Url.Replace("&Page=ct", "");

            this.hplCreateThread.NavigateUrl = Url + "&Page=ct";


            Int32 limit = 10;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index / limit) + 1;
            Int32 pages = 0;

            RXServer.Modules.Base.List t = new RXServer.Modules.Base.List("Forum_" + this.ModId + "_" + catId);

            total = t.Count;

            if (total > 0)
            {
                RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("Forum_" + this.ModId + "_" + catId, LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value8, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Descending, index, limit);

                list += "<div style='position:relative; float: left; width: 580px; padding: 10px; margin-bottom: 2px; '>";
                list += "<table cellspacing='0' cellpadding='0' style='width:100%'>";
                list += "<tr class='Text12_black_bold'><td rowspan='4'>&nbsp;</td>";
                list += "<td style='width: 10px;'>&nbsp;</td><td class='Text10_505050' style='width: 40px;'>" + RXMali.GetXMLNode("Modules/Forum/posts") + "</td>";
                list += "<td style='width: 10px;'>&nbsp;</td><td class='Text10_505050 'style='width: 40px;'>" + RXMali.GetXMLNode("Modules/Forum/visits") + "</td>";
                list += "<td style='width: 10px;'>&nbsp;</td><td class='Text10_505050 'style='width: 100px;'>" + RXMali.GetXMLNode("Modules/Forum/last_post") + "</td>";
                list += "</tr>";
                list += "</table></div>";


                foreach (RXServer.Modules.Base.List.Item item in cl)
                {
                    list += "<div style='position:relative; float: left; width: 580px; padding: 10px; margin-bottom: 2px; background-color: #FFF; border: 1px solid #CECECE;'>";
                    if (RXServer.Auth.IsInRole("Admin"))
                    {
                        list += "<div style='position:relative; width:100%; text-align: left; font-size:10px;'>IP:<a class='red_link' href='http://cqcounter.com/whois/?query=" + item.Value28 + "' target='_blank'>" + Server.HtmlDecode(item.Value28).Replace("`", "'") + "</a> <a href='javascript:showAdminDeleteThread(1," + this.PagId + "," + this.ModId + "," + catId + "," + item.Id + ");'><img src='Images/Modules/Forum/post_delete.gif' alt='Delete Thread' class='img_noborder' /></a></div>";
                    }
                    list += "<table cellspacing='0' cellpadding='0' style='width:100%'>";
                    list += "<tr class='Text12_black_bold'><td rowspan='2' style='width: 40px;' valign='top'><img src='Images/Modules/Forum/icon_forum.jpg' alt='' /></td><td style='width: 10px;'><a name='" + item.Id + "'></a></td>";
                    String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
                    list += "<td valign='top'><a href='" + Request.Url + "&t=" + item.Id + "'>" + item.Value25 + "</a><br /><span class='Text10_505050'>" + RXMali.GetXMLNode("Modules/Forum/created_by") + " <a href='" + path + "Default.aspx?PagId=" + ConfigurationManager.AppSettings["MembersPage"].ToString() + "&amp;v1=" + RXServer.Auth.Users.GetUserId(Server.HtmlDecode(item.Value26)) + "'>" + Server.HtmlDecode(item.Value26).Replace("`", "'") + "</a></span></td>";
                    list += "<td style='width: 10px;'>&nbsp;</td><td style='width: 40px;' valign='top'>" + Forum.GetTotalForumPosts(this.ModId, cId, item.Id) + "</td>";
                    list += "<td style='width: 10px;'>&nbsp;</td><td class='Text10_505050' style='width: 40px;' valign='top'>" + Server.HtmlDecode(item.Value29).Replace("`", "'") + "</td>";
                    list += "<td style='width: 10px;'>&nbsp;</td><td class='Text10_505050' style='width: 100px; font-size:10px;' valign='top'>" + Forum.GetLastPostInfo2(this.ModId, cId, item.Id) + "</td>";
                    list += "</tr>";
                    list += "</table></div>";
                }
            }

            #region Paging

            if (total > 0)
            {
                double t1, t2;
                t1 = total;
                t2 = limit;
                pages = (int)Math.Ceiling(t1 / t2);
                Url = Url.Replace("&Index=" + index, "");
                

                list += "<table cellspacing='0' cellpadding='0' style='width: 100%;'><tr>";
                list += "<td colspan='10' style='text-align: right' class='Text11_666666'><div style='position:relative; padding: 0px; margin: 0px; float: right'><table cellspacing='0' cellpadding='5'><tr>";
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
                            list += "<td style='background-color: #FFF;'>" + (i + 1) + "</td>";
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

            this.ltrCategories.Text = list;


            Int32 c = 0;
            Int32.TryParse(catId, out c);

            RXServer.Modules.Base.List.Item cat = new RXServer.Modules.Base.List.Item(c);

            Url = Request.Url.ToString();
            Url = Url.Replace("&c="+catId, "");
            Url = Url.Replace("&Page=ct", "");


            String menu = "";
            menu += "<table cellspacing='0' cellpadding='0'>";
            menu += "<tr class='Text10_505050'><td style='height: 20px;'><a href='" + Url + "'>Forum</a></td><td style='width: 6px;'>&nbsp;>&nbsp;</td><td>" + cat.Value25 + "</td></tr>";
            menu += "</table>";

            this.ltrForumMenu.Text = menu;

            //this.lblThreadTitle.Text = cat.Value1;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    private void BindPostData(String catId, String threadId)
    {
        String function_name = "BindPostData";
        try
        {
            String list = "";

            //this.ForumHeader.Visible = true;
            this.ForumList.Visible = true;

            if (Session["Thread_" + threadId] == null)
            {
                Int32 tId = 0;
                Int32.TryParse(threadId, out tId);
                Forum.AddVisit(tId);
                Session["Thread_" + threadId] = "true";
            }


            Int32 limit = 25;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index / limit) + 1;
            Int32 pages = 0;

            RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("Forum_" + this.ModId + "_" + catId + "_" + threadId, LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Id, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending, index, limit);
            RXServer.Modules.Base.List tot = new RXServer.Modules.Base.List("Forum_" + this.ModId + "_" + catId + "_" + threadId);

            total = tot.Count;            
            
            if (total > 0)
            {
                Url = Request.Url.ToString();
                Url = Url.Replace("&Page=re", "");

                DateTime stamp;
                list += "<div style='position:relative; float: left; width: 100%; padding: 0px;'><a name='" + threadId + "'></a>";

                foreach (RXServer.Modules.Base.List.Item item in cl)
                {

                    DateTime.TryParse(item.Value28, out stamp);

                    list += "<div style='position:relative; float: left; width: 580px; padding: 10px; margin-bottom: 2px; background-color: #FFF; border: 1px solid #CECECE;'>";
                    if (RXServer.Auth.IsInRole("Admin"))
                    {
                        list += "<div style='position:relative; width:100%; text-align: left;font-size:10px;'>IP:<a class='red_link' href='http://cqcounter.com/whois/?query=" + item.Value29 + "' target='_blank' style='font-size:10px;'>" + item.Value29 + "</a> <a href='javascript:showAdminDeletePost(1," + this.PagId + "," + item.Id + ");'><img src='Images/Modules/Forum/post_delete.gif' alt='Delete Post' class='img_noborder'  /></a></div>";
                    }
                    list += "<table cellspacing='0' cellpadding='0' style='width:100%;'>";
                    list += "<tr>";
                    String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
                    list += "<td style='width:60px;' style='font-size:10px;'><a href='" + path + "Default.aspx?PagId=" + ConfigurationManager.AppSettings["MembersPage"].ToString() + "&amp;v1=" + RXServer.Auth.Users.GetUserId(Server.HtmlDecode(item.Value26)) + "' style='font-size:10px;'>" + Server.HtmlDecode(item.Value26) + "</a></td>";
                    list += "<td style='width:20px;' ><a name='" + item.Id + "'></a></td>";
                    list += "<td style='font-size:10px;'>Postad ";
                    list += " " + stamp.ToString("HH:mm") + ", " + stamp.Day + " " + RXMali.GetShortMonthName(stamp.Month.ToString()) + " " + stamp.Year;
                    list += " (<a href='" + Url + "#" + item.Id + "'>" + RXMali.GetXMLNode("Modules/Forum/permalink") + "</a>)</td>";
                    list += "</tr>";
                    list += "<tr>";
                    list += "<td style='width:60px; font-size:10px; text-align: center;' valign='top'>";

                    RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(Server.HtmlDecode(item.Value26).Replace("`", "'")));

                    Boolean isAdmin = false;

                    Int32 rolid = 0;
                    if (u.UserName != null)
                    {
                        if (u.GetRoles()[0].ToString() == "1")
                        {
                            isAdmin = true;
                        }

                        Int32.TryParse(u.GetRoles()[0].ToString(), out rolid);

                        RXServer.Auth.Roles.Role r = new RXServer.Auth.Roles.Role(rolid);

                        if (u.ImageUrl != "")
                        {
                            string mediafile;
                            mediafile = "Upload/Users/" + r.Description + "/" + u.Id + "/" + u.ImageUrl;
                            list += "<a href='" + path + "Default.aspx?PagId=" + ConfigurationManager.AppSettings["MembersPage"].ToString() + "&amp;v1=" + RXServer.Auth.Users.GetUserId(Server.HtmlDecode(item.Value26)) + "'><img src='" + mediafile + "' style='width: 60px;' title='" + u.FirstName + " " + u.LastName + "' class='img_noborder' /></a>";

                            //list += "<img src='Images/Modules/Comments/user_pic.gif' style='width:60px;' alt='' />";
                        }
                        else
                        {
                            list += "<img src='Images/Modules/Comments/user_pic.gif' style='width:60px;' alt='' />";
                        }
                    }
                    else
                    {
                        list += "<img src='Images/Modules/Comments/user_pic.gif' style='width:60px;' alt='' />";
                    }

                    if (isAdmin)
                    {
                        list += "<br /><b>(admin)</b>";
                    }

                    list += "</td>";
                    list += "<td style='width:20px;'>&nbsp;</td>";
                    list += "<td valign='top'";
                    if (isAdmin)
                    {
                        list += " style='color: #932323;'";
                    }
                    list += "> " + Server.HtmlDecode(item.Value25).Replace("`", "'") + "</td>";
                    list += "</tr>";
                    if (RXServer.Auth.AuthorizedUser.Identity.Authenticated)
                    {
                        list += "<tr>";
                        list += "<td colspan='3' style='text-align: right;' class='Text12_black'><a href='" + Url + "&Page=re'>Reply</a></td>";
                        list += "</tr>";
                    }
                    list += "</table></div>";
                }
                list += "</div>";
            }

            #region Paging

            if (total > 0)
            {
                double t1, t2;
                t1 = total;
                t2 = limit;
                pages = (int)Math.Ceiling(t1 / t2);
                Url = Url.Replace("&Index=" + index, "");
                

                list += "<table cellspacing='0' cellpadding='0' style='width: 100%;'><tr>";
                list += "<td colspan='10' style='text-align: right' class='Text11_666666'><div style='position:relative; padding: 0px; margin: 0px; float: right; padding-top: 10px;'><table cellspacing='0' cellpadding='5'><tr>";
                list += "<td>Page " + page + "  of " + pages + "</td>";

                if (page > 1)
                {
                    list += "<td style='width:5px;'><a href='" + Url + "&Index=" + (index - limit) + "#" + threadId + "' class='paging_on'>«</a></td>";
                }
                else
                {
                    list += "<td style='width:5px;'>&nbsp;</td>";
                }

                if ((page) > 3)
                {
                    list += "<td><a href='" + Url + "&Index=" + 0 + "#" + threadId + "' class='paging_on'>1</a></td><td>...</td>";
                }

                for (int i = 0; i < pages; i++)
                {
                    if (i < page + 2 && i > (page - 4))
                    {
                        Int32 ix = i * limit;
                        if ((i + 1) == page)
                        {
                            list += "<td style='background-color: #FFF;'>" + (i + 1) + "</td>";
                        }
                        else
                        {
                            list += "<td><a href='" + Url + "&Index=" + ix + "#" + threadId + "' class='paging_on'>" + (i + 1) + "</a></td>";
                        }
                    }
                }
                if ((page + 2) < pages)
                {
                    Int32 ix = (pages-1) * limit;
                    list += "<td>...</td><td><a href='" + Url + "&Index=" + ix + "#" + threadId + "' class='paging_on'>" + (pages) + "</a></td>";
                }


                if (page < pages)
                {
                    list += "<td style='width:5px;'><a href='" + Url + "&Index=" + (index + limit) + "#" + threadId + "' class='paging_on'>»</a></td>";
                }
                else
                {
                    list += "<td style='width:5px;'>&nbsp;</td>";
                }

                list += "<tr></table></div></td></tr></table>";
            }

            #endregion

            this.ltrCategories.Text = list;


            Int32 c = 0;
            Int32.TryParse(catId, out c);

            Int32 t = 0;
            Int32.TryParse(threadId, out t);

            RXServer.Modules.Base.List.Item cat = new RXServer.Modules.Base.List.Item(c);
            RXServer.Modules.Base.List.Item thread = new RXServer.Modules.Base.List.Item(t);

            Url = Request.Url.ToString();
            Url = Url.Replace("&t=" + threadId, "");
            Url2 =  Url;
            Url = Url.Replace("&c=" + catId, "");

            String menu = "";
            menu += "<table cellspacing='0' cellpadding='0'>";
            menu += "<tr class='Text10_505050'><td style='height: 20px;'><a href='" + Url + "'>Forum</a></td><td style='width: 6px;'>&nbsp;>&nbsp;</td><td><a href='" + Url2 + "'>" + cat.Value25 + "</a></td><td style='width: 6px;'>&nbsp;>&nbsp;</td><td>" + thread.Value25 + "</td></tr>";
            menu += "</table>";

            this.ltrForumMenu.Text = menu;

            //this.lblThreadTitle.Text = thread.Value1;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    private void LoadCreateThread(String catId)
    {
        String function_name = "LoadCreateThread";
        try
        {
            if (RXServer.Auth.AuthorizedUser.Identity.Authenticated)
            {
                this.ForumCreateThread.Visible = true;

                //RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(RXServer.Auth.Roles.GetRoleId(RXServer.Auth.AuthorizedUser.Identity.Role));

                //string[] folder = new string[] { "~/Upload/Users/" + role.Description + "/" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) };
                //this.RadEditor1.ImageManager.UploadPaths = folder;
                //this.RadEditor1.ImageManager.ViewPaths = folder;
                //this.RadEditor1.ImageManager.DeletePaths = folder;
            }

            Int32 c = 0;
            Int32.TryParse(catId, out c);



            //this.txtAuthor.Text = RXMali.GetXMLNode("Common/name");
            //this.txtAuthorMail.Text = RXMali.GetXMLNode("Common/email");
            this.txtThreadTitle.Text = RXMali.GetXMLNode("Modules/Forum/enter_title");
            this.lblCreateThreadTitle.Text = RXMali.GetXMLNode("Modules/Forum/create_thread_title");


            RXServer.Modules.Base.List.Item cat = new RXServer.Modules.Base.List.Item(c);

            Url = Request.Url.ToString();
            Url = Url.Replace("&c=" + catId, "");
            Url = Url.Replace("&Page=ct", "");

            Url2 = Request.Url.ToString();
            Url2 = Url2.Replace("&Page=ct", "");

            String menu = "";
            menu += "<table cellspacing='0' cellpadding='0'>";
            menu += "<tr class='Text10_505050'><td style='height: 20px;'><a href='" + Url + "'>Forum</a></td><td style='width: 6px;'>&nbsp;>&nbsp;</td><td><a href='" + Url2 + "'>" + cat.Value25 + "</a></td></tr>";
            menu += "</table>";

            this.ltrForumMenu.Text = menu;
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    private void LoadCreatePost(String catId, String threadId)
    {
        String function_name = "LoadCreatePost";
        try
        {
            //this.txtPoster.Text = RXMali.GetXMLNode("Common/name");
            //this.txtPosterMail.Text = RXMali.GetXMLNode("Common/email");

            if (RXServer.Auth.AuthorizedUser.Identity.Authenticated)
            {
                this.ForumCreatePost.Visible = true;

                //RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(RXServer.Auth.Roles.GetRoleId(RXServer.Auth.AuthorizedUser.Identity.Role));

                //string[] folder = new string[] { "~/Upload/Users/" + role.Description + "/" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) };
                //this.RadEditor2.ImageManager.UploadPaths = folder;
                //this.RadEditor2.ImageManager.ViewPaths = folder;
                //this.RadEditor2.ImageManager.DeletePaths = folder;
            }


            Int32 c = 0;
            Int32.TryParse(catId, out c);

            Int32 t = 0;
            Int32.TryParse(threadId, out t);

            RXServer.Modules.Base.List.Item cat = new RXServer.Modules.Base.List.Item(c);
            RXServer.Modules.Base.List.Item thread = new RXServer.Modules.Base.List.Item(t);

            Url = Request.Url.ToString();
            Url = Url.Replace("&Page=re", "");
            Url3 = Url;
            Url = Url.Replace("&t=" + threadId, "");
            Url2 = Url;
            Url = Url.Replace("&c=" + catId, "");

            String menu = "";
            menu += "<table cellspacing='0' cellpadding='0'>";
            menu += "<tr class='Text10_505050'><td style='height: 20px;'><a href='" + Url + "'>Forum</a></td><td>&nbsp;>&nbsp;</td><td><a href='" + Url2 + "'>" + cat.Value25 + "</a></td><td style='width: 6px;'>&nbsp;>&nbsp;</td><td><a href='" + Url3 + "'>" + thread.Value25 + "</a></td></tr>";
            menu += "</table>";

            this.ltrForumMenu.Text = menu;
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

            RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
        }
        catch(Exception ex)
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

            RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
        }
        catch(Exception ex)
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

            RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnCreateThread_Click(object sender, EventArgs e)
    {
        String function_name = "btnCreateThread_Click";
        try
        {
            Boolean valid = true;

            if (this.txtThreadTitle.Text == "")
            {
                valid = false;
            }

            if (this.RadEditor1.Content == "")
            {
                valid = false;
            }

            if (valid)
            {
                if(CreateThread(this.txtThreadTitle.Text, this.RadEditor1.Content))
                {
                    Url = Request.Url.ToString();
                    Url = Url.Replace("&Page=ct", "");

                    RXServer.Web.Redirect.To(Url);
                }
                else
                {

                }
            }
           
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
    protected void btnCreatePost_Click(object sender, EventArgs e)
    {
        String function_name = "btnCreatePost_Click";
        try
        {
            Boolean valid = true;

            if (this.RadEditor2.Content == "")
            {
                valid = false;
            }

            if (valid)
            {
                if (CreatePost(this.RadEditor2.Content))
                {
                    Url = Request.Url.ToString();
                    Url = Url.Replace("&Page=re", "");

                    RXServer.Web.Redirect.To(Url);
                }
                else
                {

                }
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
    protected Boolean CreateThread(string _title, string _post)
    {
        String function_name = "CreateThread";
        try
        {
            String catId = Request["c"].ToString();

            String post = "";
            String author = "";
            String email = "";
            String title = "";

            post = Regex.Replace(Server.HtmlEncode(_post), "'", "´");

            Int32 uId = RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name);
            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(uId);


            author = Regex.Replace(Server.HtmlEncode(u.UserName), "'", "´");
            email = Regex.Replace(Server.HtmlEncode(u.Mail), "'", "´");
            title = Regex.Replace(Server.HtmlEncode(_title), "'", "´");

            if (author == RXMali.GetXMLNode("Common/name") || author == "")
            {
                author = RXMali.GetXMLNode("Common/anonymous");
            }

            if (email == RXMali.GetXMLNode("Common/email") || email == "")
            {
                email = "";
            }

            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item();

            i.Alias = "Forum_" + this.ModId + "_" + catId;
            i.Status = 1;
            i.Language = 1;
            i.SitId = 1;
            i.PagId = this.PagId;
            i.ModId = this.ModId;
            i.Value25 = title;
            i.Value26 = author;
            i.Value27 = email;
            i.Value20 = DateTime.Now.ToString();
            i.Value28 = Request.UserHostAddress;
            i.Value29 = "1";
            i.Value30 = DateTime.Now.ToString();
            i.Save();
            

            RXServer.Modules.Base.List.Item p = new LiquidCore.List.Item();

            p.Alias = "Forum_" + this.ModId + "_" + catId + "_" + i.Id;
            p.Status = 1;
            p.Language = 1;
            p.SitId = 1;
            p.PagId = this.PagId;
            p.ModId = this.ModId;
            p.Value25 = post;
            p.Value26 = author;
            p.Value27 = email;
            p.Value28 = DateTime.Now.ToString();
            p.Value29 = Request.UserHostAddress;
            p.Save();

            return true;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }
    protected Boolean CreatePost(string _post)
    {
        String function_name = "CreatePost";
        try
        {
            Int32 c, t;

            String catId = Request["c"].ToString();
            String threadId = Request["t"].ToString();

            Int32.TryParse(catId,out c);
            Int32.TryParse(threadId, out t);

            String post = "";
            String author = "";
            String email = "";

            Int32 uId = RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name);
            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(uId);

            post = Regex.Replace(Server.HtmlEncode(_post), "'", "´");
            author = Regex.Replace(Server.HtmlEncode(u.UserName), "'", "`");
            email = Regex.Replace(Server.HtmlEncode(u.Mail), "'", "`");

            if (author == RXMali.GetXMLNode("Common/name") || author == "")
            {
                author = RXMali.GetXMLNode("Common/anonymous");
            }

            if (email == RXMali.GetXMLNode("Common/email") || email == "")
            {
                email = "";
            }

            RXServer.Modules.Base.List.Item p = new LiquidCore.List.Item();

            p.Alias = "Forum_" + this.ModId + "_" + catId + "_" + threadId;
            p.Status = 1;
            p.Language = 1;
            p.SitId = 1;
            p.PagId = this.PagId;
            p.ModId = this.ModId;
            p.Value25 = post;
            p.Value26 = author;
            p.Value27 = email;
            p.Value28 = DateTime.Now.ToString();
            p.Value29 = Request.UserHostAddress;
            p.Save();

            Forum.UpdateThreadTime(c, DateTime.Now.ToString());
            Forum.UpdateCategoryTime(t,DateTime.Now.ToString());

            return true;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    private void HideWindows()
    {
        String function_name = "HideWindows";
        try
        {
            //this.ForumSearch.Visible = false;
            //this.ForumHeader.Visible = false;
            this.ForumCreate.Visible = false;
            this.ForumCreateThread.Visible = false;
            this.ForumCreatePost.Visible = false;
            this.ForumList.Visible = false;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
