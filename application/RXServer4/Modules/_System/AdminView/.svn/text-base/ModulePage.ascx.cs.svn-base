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

public partial class Modules__System_AdminView_ModulePage : System.Web.UI.UserControl
{
    String class_name = "Modules__System_AdminView_ModulePage";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.ErrorBox.Visible = false;
            HideErrors();

            if (RXServer.Web.RequestValues.Page == "ModDef")
            {

                this.ModulePage_1.Visible = false;

                this.ModuleSubMenu.Visible = true;
                BindModulesSubMenuData();

                switch (RXServer.Web.RequestValues.SubPage)
                {
                    case "Modules" :
                        this.ModulePage_2.Visible = true;
                        if (RXServer.Web.RequestValues.DelId != "")
                        {
                            DeleteModule(RXServer.Web.RequestValues.DelId);
                        }
                        else
                        {   
                            BindModulesData(RXServer.Web.RequestValues.ViewId);
                        }
                    break;

                    default:
                        this.ModulePage_1.Visible = true;
                        BindModulesDefData();                        
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

    public void BindModulesDefData()
    {
        String function_name = "BindModulesDefData";
        try
        {
            ContentPlaceHolder cph = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
            Literal help = cph.FindControl("ltrHelpText") as Literal;
            help.Text = RXMali.GetXMLHelpNode("ContentManager/Modules/Text");

            Int32 staId = 0;
            Int32.TryParse(RXServer.Web.RequestValues.StaId.ToString(), out staId);

            if (staId == 0)
            {
                staId = 1;
            }

            RXServer.Modules.ModuleDefinitions m = new RXServer.Modules.ModuleDefinitions(staId, 1);
                   
            String list = "";

            list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";
            
            if (m.Count > 0)
            {
                list += "<tr style='background-color: #666666' class='Text11_white'>";
                list += "<td valign='top'>Id</td>";
                list += "<td valign='top'>Title</td>";
                list += "<td valign='top' align='center'>Total</td>";
                list += "<td valign='top'>Created</td>";
                list += "<td valign='top'>Created By</td>";
                //list += "<td valign='top'>Rights</td>";
                list += "</tr>";

                Int32 counter = 0;
                foreach (LiquidCore.ModDef mDef in m)
                {
                    if ((counter % 2) == 0)
                    {
                        list += "<tr style='background-color: white;'  class='Text11_gray'>";
                    }
                    else
                    {
                        list += "<tr style='background-color: #EFEFEF;'  class='Text11_gray'>";
                    }
                    list += "<td valign='top'>" + mDef.Id.ToString() + "</td>";
                    list += "<td valign='top'>" + mDef.Alias + "</td>";
                    list += "<td valign='top' align='center'><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&SubPage=Modules&ViewId=" + mDef.Id.ToString() + "'>" + RXServer.Modules.Modules.GetTotalModulesBasedOnModDef(1, 1, mDef.Id) + "</a></td>";
                    list += "<td valign='top'>" + mDef.CreatedDate.ToShortDateString() + "</td>";
                    list += "<td valign='top'>" + mDef.CreatedBy + "</td>";
                    //list += "<td valign='top'>Rights(" + mDef.Id.ToString() + ")</td>";
                    list += "</tr>";

                    counter++;
                }                       
            }
            else
            {
                list += "<tr><td class='Text11_gray'>No Records was found.</td></tr>";
            }

            list += "</table>";   

            this.ltrModDefList.Text = list;

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindModulesData(String ModDefId)
    {
        String function_name = "BindModulesData";
        try
        {
            ContentPlaceHolder cph = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
            Literal help = cph.FindControl("ltrHelpText") as Literal;
            help.Text = RXMali.GetXMLHelpNode("ContentManager/Modules/Text");

            Int32 mDefId = 0;

            Int32.TryParse(ModDefId, out mDefId);
            
            String list = "";

            if (mDefId > 0)
            {

                LiquidCore.ModDef md = new LiquidCore.ModDef(mDefId);
                String modTitle = "";
                modTitle = md.Alias;

                RXServer.Modules.Modules m = new RXServer.Modules.Modules(1, 1, mDefId);

                list += "<span class='Text18_bold_gray'>" + modTitle +"</span>";
                list += "<br />";
                list += "<hr class='line' />";
                list += "<br />";
                list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

                if (m.Count > 0)
                {
                    list += "<tr style='background-color: #666666' class='Text11_white'>";
                    list += "<td valign='top'>Id</td>";
                    list += "<td valign='top'>Page</td>";
                    list += "<td valign='top'>Admin</td>";
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
                        list += "<td valign='top'>" + mod.PagId + "</td>";
                        
                        #region adminModLink

                        String modSrc = "";
                        modSrc = mod.Src;
                        modSrc = modSrc.Replace(".ascx","_Admin.aspx");

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
                            list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + mod.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this module from page( " + mod.PagId + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + mod.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this module from page( " + mod.PagId + " )?')\">Delete</a></td></tr></table></td>";
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

            this.ltrModulesList.Text = list;

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindModulesSubMenuData()
    {
        String function_name = "BindModulesSubMenuData";
        try
        {
            String list = "";

            list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
            list += "<tr><td style='width:10px;'></td>";
            if (RXServer.Web.RequestValues.StaId == "" || RXServer.Web.RequestValues.StaId.ToString() == "1")
            {
                list += "<td valign='middle' style='height:34px;'><a href='AdminView_Admin.aspx?Page=ModDef&StaId=1' class='submenu_on'>Active</a></td>";
            }
            else
            {
                list += "<td valign='middle' style='height:34px;'><a href='AdminView_Admin.aspx?Page=ModDef&StaId=1' class='submenu_off'>Active</a></td>";
            }
            
            list += "<td style='width:10px;'>&nbsp;</td>";
            if (RXServer.Web.RequestValues.StaId.ToString() == "2")
            {
                list += "<td valign='middle' style='height:34px;'><a href='AdminView_Admin.aspx?Page=ModDef&StaId=2' class='submenu_on'>Unactive</a></td>";
            }
            else
            {
                list += "<td valign='middle' style='height:34px;'><a href='AdminView_Admin.aspx?Page=ModDef&StaId=2' class='submenu_off'>Unactive</a></td>";
            }
            list += "<td style='width:10px;'>&nbsp;</td>";
            list += "</tr>";
            list += "</table>";

            this.ltrModuleSubMenuList.Text = list;
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
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
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

}
