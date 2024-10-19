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

public partial class Modules__System_PageTemplate_PageTemplate_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules__System_PageTemplate_PageTemplate_Admin";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.SubMenu.Visible = true;
            if (RXServer.Web.RequestValues.Mode == "Set")
            {
                this.ltrHelpText.Text = RXMali.GetXMLHelpNode("PageTemplate/Set");
                this.lblHeaderPage1.Text = "Choose a Template";
                this.Page_1.Visible = true;
            }
            else if (RXServer.Web.RequestValues.Mode == "Remove")
            {
                this.ltrHelpText.Text = RXMali.GetXMLHelpNode("PageTemplate/Remove");
                this.lblHeaderPage2.Text = "Remove Template";
                this.Page_2.Visible = true;
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - Couldn't load data. Please close the window and try again";
            }

            SetTemplates(RXServer.Web.RequestValues.PagId);
            if (!Page.IsPostBack)
            {
                UnCheckButtons();
            }


        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnChangePageTemplate_Click(object sender, EventArgs e)
    {
        String function_name = "btnChangePageTemplate_Click";
        try
        {
            #region PageTemplateSelector

            if (this.pageTemplate1.Checked)
            {
                RXServer.Modules.Menu.Item o = new RXServer.Modules.Menu.Item(RXServer.Web.CurrentValues.PagId);
                o.Template = "Template1.master";
                o.ModelId = 1;
                o.Save();

                //RXServer.Lib.Model.CheckPageForModelUpdate(1, RXServer.Web.RequestValues.PagId, 1);
            }

            if (this.pageTemplate2.Checked)
            {
                RXServer.Modules.Menu.Item o = new RXServer.Modules.Menu.Item(RXServer.Web.CurrentValues.PagId);
                o.Template = "Template2.master";
                o.ModelId = 1;
                o.Save();

                //RXServer.Lib.Model.CheckPageForModelUpdate(1, RXServer.Web.RequestValues.PagId, 1);
            }

            if (this.pageTemplate3.Checked)
            {
                RXServer.Modules.Menu.Item o = new RXServer.Modules.Menu.Item(RXServer.Web.CurrentValues.PagId);
                o.Template = "Template3.master";
                o.ModelId = 1;
                o.Save();

                //RXServer.Lib.Model.CheckPageForModelUpdate(1, RXServer.Web.RequestValues.PagId, 1);
            }

            if (this.pageTemplate4.Checked)
            {
                RXServer.Modules.Menu.Item o = new RXServer.Modules.Menu.Item(RXServer.Web.CurrentValues.PagId);
                o.Template = "Template4.master";
                o.ModelId = 1;
                o.Save();

                //RXServer.Lib.Model.CheckPageForModelUpdate(1, RXServer.Web.RequestValues.PagId, 16);
            }

            this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";

            #endregion
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnRemovePageTemplate_Click(object sender, EventArgs e)
    {
        String function_name = "btnRemovePageTemplate_Click";
        try
        {
            RXServer.Modules.Modules m = RXServer.Modules.Modules.GetModulesByPagId(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId);
            foreach (LiquidCore.Module mod in m)
            {
                if (!mod.AllPages)
                {
                    mod.Delete();
                }
            }

            RXServer.Modules.Menu.Item mi = new RXServer.Modules.Menu.Item(RXServer.Web.RequestValues.PagId);
            mi.Template = "Template0.master";
            mi.ModelId = 1;
            mi.Save();

            this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imgTemplate1_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imgTemplate1_Click";
        try
        {
            UnCheckButtons();
            this.pageTemplate1.Checked = true;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imgTemplate2_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imgTemplate2_Click";
        try
        {
            UnCheckButtons();
            this.pageTemplate2.Checked = true;
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imgTemplate3_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imgTemplate3_Click";
        try
        {
            UnCheckButtons();
            this.pageTemplate3.Checked = true;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imgTemplate4_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imgTemplate4_Click";
        try
        {
            UnCheckButtons();
            this.pageTemplate4.Checked = true;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void UnCheckButtons()
    {
        String function_name = "UnCheckButtons";
        try
        {
            this.pageTemplate1.Checked = false;
            this.pageTemplate2.Checked = false;
            this.pageTemplate3.Checked = false;
            this.pageTemplate4.Checked = false;
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void SetTemplates(Int32 pagId)
    {
        String function_name = "SetTemplates";
        try
        {
            RXServer.Modules.Menu.Item m = new RXServer.Modules.Menu.Item(pagId);
            if (m.Level ==  1)
            {
                this.Level12.Visible = true;
            }
            else if (m.Level ==  2)
            {
                this.Level12.Visible = true;
                this.Level34.Visible = true;
            }
            else
            {
                this.Level34.Visible = true;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
