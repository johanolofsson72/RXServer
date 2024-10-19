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

public partial class Modules_Modules_EditModules_EditModulesLarge_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Modules_EditModules_EditModulesLarge_Admin";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("EditModules/Text");
            this.SubMenu.Visible = true;
            this.lblHeaderPage1.Text = "Add Boxes";
            this.Page_1.Visible = true;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void imbAddModule_1_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbAddModule_1_Click";
        try
        {
            Int32 ConPaId, PagId;

            Int32.TryParse(Request["PagId"], out PagId);
            Int32.TryParse(Request["ConPa"], out ConPaId);

            if (PagId > 0 && ConPaId > 0)
            {
                String conPa = "";

                if (ConPaId == 1)
                {
                    conPa = "ContentPane1";
                }
                else if (ConPaId == 2)
                {
                    conPa = "ContentPane2";
                }
                else
                {
                    conPa = "[ SET CONTENTPANE ]";
                }

                int modId = RXServer.Modules.MediaModule.Create(1, PagId, 89, conPa, 1, 1, false, false);
				LiquidCore.Module m = new LiquidCore.Module(modId);
				m.CacheTime = 20;
				m.Save();

                this.MessageBox.Visible = true;
                this.ltrMessage.Text = " - Media Module was added to your page.";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - Media Module wasn't added to your page. Please contact your admin";
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imbAddModule_2_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbAddModule_2_Click";
        try
        {
            Int32 ConPaId, PagId;

            Int32.TryParse(Request["PagId"], out PagId);
            Int32.TryParse(Request["ConPa"], out ConPaId);

            if (PagId > 0 && ConPaId > 0)
            {
                String conPa = "";

                if (ConPaId == 1)
                {
                    conPa = "ContentPane1";
                }
                else if (ConPaId == 2)
                {
                    conPa = "ContentPane2";
                }
                else
                {
                    conPa = "[ SET CONTENTPANE ]";
                }

                int modId = RXServer.Modules.TextModule.Create(1, PagId, 71, conPa, 1, 1, false, false);
				LiquidCore.Module m = new LiquidCore.Module(modId);
				m.CacheTime = 20;
				m.Save();

                this.MessageBox.Visible = true;
                this.ltrMessage.Text = " -  Text Module was added to your page.";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - Text Module wasn't added to your page. Please contact your admin";
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imbAddModule_110_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbAddModule_110_Click";
        try
        {
            Int32 ConPaId, PagId;

            Int32.TryParse(Request["PagId"], out PagId);
            Int32.TryParse(Request["ConPa"], out ConPaId);

            if (PagId > 0 && ConPaId > 0)
            {
                String conPa = "";

                if (ConPaId == 1)
                {
                    conPa = "ContentPane1";
                }
                else if (ConPaId == 2)
                {
                    conPa = "ContentPane2";
                }
                else
                {
                    conPa = "[ SET CONTENTPANE ]";
                }

                int modId = RXServer.Modules.TextModule.Create(1, PagId, 110, conPa, 1, 1, false, false);
                LiquidCore.Module m = new LiquidCore.Module(modId);
                m.CacheTime = 20;
                m.Save();

                this.MessageBox.Visible = true;
                this.ltrMessage.Text = " -  Cms Module was added to your page.";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - Cms Module wasn't added to your page. Please contact your admin";
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imbAddModule_3_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbAddModule_2_Click";
        try
        {
            Int32 ConPaId, PagId;

            Int32.TryParse(Request["PagId"], out PagId);
            Int32.TryParse(Request["ConPa"], out ConPaId);

            if (PagId > 0 && ConPaId > 0)
            {
                String conPa = "";

                if (ConPaId == 1)
                {
                    conPa = "ContentPane1";
                }
                else if (ConPaId == 2)
                {
                    conPa = "ContentPane2";
                }
                else
                {
                    conPa = "[ SET CONTENTPANE ]";
                }

                int modId = RXServer.Modules.StandardModule.Create(1, PagId, 95, conPa, 1, 1, false, false);
				LiquidCore.Module m = new LiquidCore.Module(modId);
				m.CacheTime = 20;
				m.Save();

                // Skapar 4st Tablistobjekt

                for (int k = 0; k < 4; k++)
                {
                    RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item();

					i.Alias = "StartBox_" + modId;
                    i.Status = 1;
                    i.Language = 1;
                    i.SitId = 1;
                    i.PagId = PagId;
					i.ModId = modId;
                    i.Save();
                }

                this.MessageBox.Visible = true;
                this.ltrMessage.Text = " - Big Teasers Module was added to your page.";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - Big Teasers Module wasn't added to your page. Please contact your admin";
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imbAddModule_4_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbAddModule_4_Click";
        try
        {
            Int32 ConPaId, PagId;

            Int32.TryParse(Request["PagId"], out PagId);
            Int32.TryParse(Request["ConPa"], out ConPaId);

            if (PagId > 0 && ConPaId > 0)
            {
                String conPa = "";

                if (ConPaId == 1)
                {
                    conPa = "ContentPane1";
                }
                else if (ConPaId == 2)
                {
                    conPa = "ContentPane2";
                }
                else
                {
                    conPa = "[ SET CONTENTPANE ]";
                }

                int modId = RXServer.Modules.StandardModule.Create(1, PagId, 96, conPa, 1, 1, false, false);
				LiquidCore.Module m = new LiquidCore.Module(modId);
				m.CacheTime = 20;
				m.Save();
                                
                this.MessageBox.Visible = true;
                this.ltrMessage.Text = " - Teaser Module was added to your page.";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - Teaser Module wasn't added to your page. Please contact your admin";
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
	protected void imbAddModule_5_Click(object sender, ImageClickEventArgs e)
	{
		String function_name = "imbAddModule_5_Click";
		try
		{
			Int32 ConPaId, PagId;

			Int32.TryParse(Request["PagId"], out PagId);
			Int32.TryParse(Request["ConPa"], out ConPaId);

			if (PagId > 0 && ConPaId > 0)
			{
				String conPa = "";

				if (ConPaId == 1)
				{
					conPa = "ContentPane1";
				}
				else if (ConPaId == 2)
				{
					conPa = "ContentPane2";
				}
				else
				{
					conPa = "[ SET CONTENTPANE ]";
				}

				RXServer.Modules.StandardModule.Create(1, PagId, 100, conPa, 1, 1, false, false);

				this.MessageBox.Visible = true;
				this.ltrMessage.Text = " - Shop Box was added to your page.";
			}
			else
			{
				this.ErrorBox.Visible = true;
				this.ltrErrors.Text = " - Shop Box wasn't added to your page. Please contact your admin";
			}

		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

    protected void Add_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "Add_Click";
        try
        {
            Int32 ConPaId, PagId;

            Int32.TryParse(Request["PagId"], out PagId);
            Int32.TryParse(Request["ConPa"], out ConPaId);

            if (PagId > 0 && ConPaId > 0)
            {
                String conPa = "";

                if (ConPaId == 1)
                {
                    conPa = "ContentPane1";
                }
                else if (ConPaId == 2)
                {
                    conPa = "ContentPane2";
                }
                else
                {
                    conPa = "[ SET CONTENTPANE ]";
                }

                RXServer.Modules.StandardModule.Create(1, PagId, 77, conPa, 1, 1, false, false);

                this.MessageBox.Visible = true;
                this.ltrMessage.Text = " -  Add was added to your page.";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - Add wasn't added to your page. Please contact your admin";
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
