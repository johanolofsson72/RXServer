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

public partial class Modules_Modules_EditModules_EditModules_2 : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Modules_EditModules_EditModules_2";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
			if (RXServer.Auth.HasCurrentRoleEditRights(RXServer.Web.RequestValues.PagId))
            {
                this.ltrTextImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showEditModules2_Large(1," + PagId + "," + this.ModId + ",1);" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminbar_add.gif\" alt='Add Module' title='Add Module' /></a>";
                this.ltrText.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showEditModules2_Large(1," + PagId + "," + this.ModId + ",1);" + "\" class='adminbar'>Add Module</a>";


                this.EditModuls_holder2.Visible = true;
                //this.hplText.NavigateUrl = "javascript:showEditModules2(1," + PagId + "," + this.ModId + ",2);";
                //this.hplTextImg.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_add.gif";
                //this.hplText.Text = "Add Module";
                //this.hplTextImg.NavigateUrl = "javascript:showEditModules2(1," + PagId + "," + this.ModId + ",2);";

                switch (RXMali.GetLastUrl(this.Page.MasterPageFile))
                {

                    case "Template3.master":
                        this.ltrTextImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showEditModules2_Small(1," + PagId + "," + this.ModId + ",2);" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminbar_add.gif\" alt='Add Module' title='Add Module' /></a>";
                        this.ltrText.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showEditModules2_Small(1," + PagId + "," + this.ModId + ",2);" + "\" class='adminbar'>Add Module</a>";
                        this.EditModuls_holder2.Attributes.Add("style", "position:relative; float: left; height: 35px; width: 215px; display:inline;");
                        break;

                    case "Template4.master":
                        this.ltrTextImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showEditModules2_Large(1," + PagId + "," + this.ModId + ",2);" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminbar_add.gif\" alt='Add Module' title='Add Module' /></a>";
                        this.ltrText.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showEditModules2_Large(1," + PagId + "," + this.ModId + ",2);" + "\" class='adminbar'>Add Module</a>";
                        this.EditModuls_holder2.Attributes.Add("style", "position:relative; float: left; height: 35px; width: 665px; display:inline;");
                        break;

                    case "Template6.master":
                        this.ltrTextImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showEditModules2_Small(1," + PagId + "," + this.ModId + ",2);" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminbar_add.gif\" alt='Add Module' title='Add Module' /></a>";
                        this.ltrText.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showEditModules2_Small(1," + PagId + "," + this.ModId + ",2);" + "\" class='adminbar'>Add Module</a>";
                        this.EditModuls_holder2.Attributes.Add("style", "position:relative; float: left; height: 35px; width: 215px; display:inline;");
                        break;

                    default:

                        this.EditModuls_holder2.Attributes.Add("style", "position:relative; float: left; height: 35px; width: 440px; display:inline;");
                        break;

                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
