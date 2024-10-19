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

public partial class Modules__System_PageTemplate_PageTemplate : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules__System_PageTemplate_PageTemplate";

    protected override void OnInit(EventArgs e)
    {
        String function_name = "OnInit";
        try
        {
            if (RXServer.Auth.HasCurrentRoleEditRights(RXServer.Web.RequestValues.PagId))
            {
                this.PageTemplate_holder.Visible = true;

				Int32 PagId = RXServer.Web.RequestValues.PagId;
				if (PagId == 0)
				{
					PagId = 1;
				}
				RXServer.Modules.Menu.Item m = new RXServer.Modules.Menu.Item(PagId);

                if (m.Template == "Template0.master")
                {
                    //this.hplPageTemplateTxt.NavigateUrl = "javascript:showPageTemplate(1," + PagId + "," + this.ModId + ",'Set');";
                    //this.hplPageTemplateImg.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_add.gif";
                    //this.lblPageTemplateText.Text = "Select PageTemplate";
                    //this.hplPageTemplateImg.NavigateUrl = "javascript:showPageTemplate(1," + PagId + "," + this.ModId + ",'Set');";

                    this.ltrPageTemplateImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showPageTemplate(1," + PagId + "," + this.ModId + ",'Set');" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminbar_add.gif\" alt='Select PageTemplate' title='Select PageTemplate' /></a>";
                    this.ltrPageTemplateTxt.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showPageTemplate(1," + PagId + "," + this.ModId + ",'Set');" + "\" class='adminbar'>Select PageTemplate</a>";

                }
                else
                {
                    //this.hplPageTemplateTxt.NavigateUrl = "javascript:showPageTemplate(1," + PagId + "," + this.ModId + ",'Remove');";
                    //this.hplPageTemplateImg.ImageUrl = "~/App_Themes/WebAdmin/Images/v.gif";
                    //this.lblPageTemplateText.Text = "Remove PageTemplate";
                    //this.hplPageTemplateImg.NavigateUrl = "javascript:showPageTemplate(1," + PagId + "," + this.ModId + ",'Remove');";

                    this.ltrPageTemplateImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showPageTemplate(1," + PagId + "," + this.ModId + ",'Remove');" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminbar_delete.gif\" alt='Remove PageTemplate' title='Remove PageTemplate' /></a>";
                    this.ltrPageTemplateTxt.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "javascript:showPageTemplate(1," + PagId + "," + this.ModId + ",'Remove');" + "\" class='adminbar'>Remove PageTemplate</a>";

                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    } 

}
