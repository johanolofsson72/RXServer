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

public partial class Modules_Menus_SubMenu2_SubMenu2 : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Menus_SubMenu2_SubMenu2";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.SubMenu2_admin.Visible = true;
                this.img_AdminEdit.OnClientClick = "javascript:showAdminSubMenu2(1," + RXServer.Web.RequestValues.PagId + "," + this.ModId + "); return false;";
            }

            bindData();
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
            bindMenu();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void bindMenu()
    {
        String function_name = "bindMenu";
        try
        {
            Int32 pagId = 1;

            if (RXServer.Web.SelectedPages.Level2 > 0)
            {
                pagId = RXServer.Web.SelectedPages.Level2;
            }
            RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, pagId, 1);

            String menu = "";


            if (m.Count > 0)
            {
                menu = "<div id=\"submenu2\">";
                menu += "<table cellspacing='0' cellpadding='0'>";
                foreach (LiquidCore.Menu.Item mi in m)
                {
					if (!mi.Hidden || RXServer.Auth.IsInRole("Admin"))
                    {
                        int targetPagId = -1;
                        RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(1, 1, 17);
                        if (tm.Text1.Equals("true"))
                        {
                            RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, mi.Id, 1);
                            if (m2.Count > 0)
                            {
                                foreach (LiquidCore.Menu.Item mi2 in m2)
                                {
                                    if (!mi2.Hidden)
                                    {
                                        targetPagId = mi2.Id;
                                        break;
                                    }
                                }

                                if (targetPagId == -1)
                                {
                                    targetPagId = mi.Id;
                                }
                            }
                            else
                            {
                                targetPagId = mi.Id;
                            }
                        }
                        else
                        {
                            targetPagId = mi.Id;
                        }

                        menu += "<tr>";
                        if (mi.Id.Equals(RXServer.Web.CurrentValues.PagId) || RXServer.Web.SelectedPages.IsSelected(mi.Id) || mi.Id.Equals(RXServer.Web.SelectedPages.Level3))
                        {
							menu += "<td class='menu3_left_on'></td>";
							if (false)
							{
								menu += "<td class='menu3_middle_on'><a href='Default.aspx?PagId=" + targetPagId + "' class='menu3_on'>" + Server.HtmlDecode(mi.Title).ToUpper() + "</a></td>";
							}
							else
							{
								menu += "<td class='menu3_middle_on'><a href='" + RXServer.Lib.Common.Dynamic.GetFriendlyUrl(targetPagId) + "' class='menu3_on'>" + mi.Title.ToUpper() + "</a></td>";
							}

							menu += "<td class='menu3_right_on'></td>";
                        }
                        else
                        {
							menu += "<td class='menu3_left_off'></td>";
							if (false)
							{
								menu += "<td class='menu3_middle_off'><a href='Default.aspx?PagId=" + targetPagId + "' class='menu3_off'>" + Server.HtmlDecode(mi.Title).ToUpper() + "</a></td>";
							}
							else
							{
								menu += "<td class='menu3_middle_off'><a href='" + RXServer.Lib.Common.Dynamic.GetFriendlyUrl(targetPagId) + "' class='menu3_off'>" + mi.Title.ToUpper() + "</a></td>";
							}

							menu += "<td class='menu3_right_off'></td>";
                        }
                        menu += "</tr>";
                        menu += "<tr><td colspan='3' class='menu3_divider'>&nbsp;</td></tr>";

                        if (RXServer.Web.SelectedPages.Level3 == mi.Id)
                        {
                            RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, mi.Id, 1);
                            if (m2.Count > 0)
                            {
                                menu += "<tr><td colspan='3'>";
                                menu += "<div id=\"submenu3\">";
                                menu += "<table cellspacing='0' cellpadding='0'>";
                                foreach (LiquidCore.Menu.Item mi2 in m2)
                                {
                                     if (!mi2.Hidden || RXServer.Auth.AuthorizedUser.Identity.Authenticated)
                                     {
                                         menu += "<tr>";
                                         if (mi2.Id.Equals(RXServer.Web.CurrentValues.PagId) || RXServer.Web.SelectedPages.IsSelected(mi2.Id) || mi2.Id.Equals(RXServer.Web.SelectedPages.Level4))
                                         {
											 menu += "<td class='menu4_left_on'></td>";
											 if (false)
											 {
												 menu += "<td class='menu4_middle_on'><a href='Default.aspx?PagId=" + mi2.Id + "' class='menu4_on'>" + Server.HtmlDecode(mi2.Title).ToUpper() + "</a></td>";
											 }
											 else
											 {
												 menu += "<td class='menu4_middle_on'><a href='" + RXServer.Lib.Common.Dynamic.GetFriendlyUrl(mi2.Id) + "' class='menu4_on'>" + mi2.Title.ToUpper() + "</a></td>";
											 }

											 menu += "<td class='menu4_right_on'></td>";
                                         }
                                         else
                                         {
											 menu += "<td class='menu4_left_off'></td>";
											 if (false)
											 {
												 menu += "<td class='menu4_middle_off'><a href='Default.aspx?PagId=" + mi2.Id + "' class='menu4_off'>" + Server.HtmlDecode(mi2.Title).ToUpper() + "</a></td>";
											 }
											 else
											 {
												 menu += "<td class='menu4_middle_off'><a href='" + RXServer.Lib.Common.Dynamic.GetFriendlyUrl(mi2.Id) + "' class='menu4_off'>" + mi2.Title.ToUpper() + "</a></td>";
											 }

											 menu += "<td class='menu4_right_off'></td>";
                                         }
                                         menu += "</tr>";
                                         menu += "<tr><td colspan='3' class='menu4_divider'>&nbsp;</td></tr>";
                                     }
                                }
                                menu += "</table></div></td></tr>";
                            }
                        }
                    }

                }
                menu += "</table></div>";
            }

            this.ltrSubMenu2.Text = menu;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
 
}
