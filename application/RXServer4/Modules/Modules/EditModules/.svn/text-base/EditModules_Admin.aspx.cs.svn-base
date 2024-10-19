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

public partial class Modules_Modules_EditModules_EditModules_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Modules_EditModules_EditModules_Admin";

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
 
    //protected void btnAddModule_10_Click(object sender, EventArgs e)
    //{
    //    String function_name = "btnAddModule_10_Click";
    //    try
    //    {
    //        Int32 ConPaId, PagId = 0;

    //        Int32.TryParse(Request["PagId"], out PagId);
    //        Int32.TryParse(Request["ConPa"], out ConPaId);

    //        if (PagId > 0 && ConPaId > 0)
    //        {
    //            String conPa = "";

    //            conPa = "ContentPane2_Info";

    //            RXServer.Modules.InfoBox.Create(1, PagId, 30, conPa, 1, 1, false, false);
    //        }

    //        this.MessageBox.Visible = true;
    //        this.ltrMessage.Text = " -  InfoBox was added to your page.";

    //    }
    //    catch (Exception ex)
    //    {
    //        this.ErrorBox.Visible = true;
    //        this.ltrErrors.Text = ex.ToString();
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}
    //protected void btnAddModule_11_Click(object sender, EventArgs e)
    //{
    //    String function_name = "btnAddModule_11_Click";
    //    try
    //    {
    //        Int32 ConPaId, PagId = 0;

    //        Int32.TryParse(Request["PagId"], out PagId);
    //        Int32.TryParse(Request["ConPa"], out ConPaId);

    //        if (PagId > 0 && ConPaId > 0)
    //        {
    //            String conPa = "";

    //            conPa = "ContentPane1";

    //            RXServer.Modules.InfoBox.Create(1, PagId, 76, conPa, 1, 1, false, false);
    //        }

    //        this.MessageBox.Visible = true;
    //        this.ltrMessage.Text = " -  WelcomeBox was added to your page.";

    //    }
    //    catch (Exception ex)
    //    {
    //        this.ErrorBox.Visible = true;
    //        this.ltrErrors.Text = ex.ToString();
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}
    //protected void btnAddModule_12_Click(object sender, EventArgs e)
    //{
    //    String function_name = "btnAddModule_12_Click";
    //    try
    //    {
    //        Int32 ConPaId, PagId = 0;

    //        Int32.TryParse(Request["PagId"], out PagId);
    //        Int32.TryParse(Request["ConPa"], out ConPaId);

    //        if (PagId > 0 && ConPaId > 0)
    //        {
    //            String conPa = "";

    //            if (ConPaId == 1)
    //            {
    //                conPa = "ContentPane1";
    //            }
    //            else if (ConPaId == 2)
    //            {
    //                conPa = "ContentPane2";
    //            }
    //            else
    //            {
    //                conPa = "[ SET CONTENTPANE ]";
    //            }

    //            RXServer.Modules.InfoBox.Create(1, PagId, 63, conPa, 1, 1, false, false);
    //        }

    //        this.MessageBox.Visible = true;
    //        this.ltrMessage.Text = " -  LoginBox was added to your page.";

    //    }
    //    catch (Exception ex)
    //    {
    //        this.ErrorBox.Visible = true;
    //        this.ltrErrors.Text = ex.ToString();
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}


    //protected void imbAddModule_1_Click(object sender, ImageClickEventArgs e)
    //{
    //    String function_name = "imbAddModule_1_Click";
    //    try
    //    {
    //        Int32 ConPaId, PagId = 0;

    //        Int32.TryParse(Request["PagId"], out PagId);
    //        Int32.TryParse(Request["ConPa"], out ConPaId);

    //        if (PagId > 0 && ConPaId > 0)
    //        {
    //            String conPa = "";

    //            if (ConPaId == 1)
    //            {
    //                conPa = "ContentPane1";
    //            }
    //            else if (ConPaId == 2)
    //            {
    //                conPa = "ContentPane2";
    //            }
    //            else
    //            {
    //                conPa = "[ SET CONTENTPANE ]";
    //            }

    //            RXServer.Modules.LiteBox.Create(1, PagId, 58, conPa, 1, 1, false, false);

    //            this.MessageBox.Visible = true;
    //            this.ltrMessage.Text = " -  Article Box 1 was added to your page.";
    //        }
    //        else
    //        {
    //            this.ErrorBox.Visible = true;
    //            this.ltrErrors.Text = " - Article Box 1 wasn't added to your page. Please contact your admin";
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        this.ErrorBox.Visible = true;
    //        this.ltrErrors.Text = ex.ToString();
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}
    //protected void imbAddModule_2_Click(object sender, ImageClickEventArgs e)
    //{
    //    String function_name = "imbAddModule_2_Click";
    //    try
    //    {
    //        Int32 ConPaId, PagId = 0;

    //        Int32.TryParse(Request["PagId"], out PagId);
    //        Int32.TryParse(Request["ConPa"], out ConPaId);

    //        if (PagId > 0 && ConPaId > 0)
    //        {
    //            String conPa = "";

    //            if (ConPaId == 1)
    //            {
    //                conPa = "ContentPane1";
    //            }
    //            else if (ConPaId == 2)
    //            {
    //                conPa = "ContentPane2";
    //            }
    //            else
    //            {
    //                conPa = "[ SET CONTENTPANE ]";
    //            }

    //            RXServer.Modules.LiteBox2.Create(1, PagId, 65, conPa, 1, 1, false, false);

    //            this.MessageBox.Visible = true;
    //            this.ltrMessage.Text = " -  Article Box 2 was added to your page.";

    //        }
    //        else
    //        {
    //            this.ErrorBox.Visible = true;
    //            this.ltrErrors.Text = " - Article Box 2 wasn't added to your page. Please contact your admin"; 
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        this.ErrorBox.Visible = true;
    //        this.ltrErrors.Text = ex.ToString();
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}
    //protected void imbAddModule_3_Click(object sender, ImageClickEventArgs e)
    //{
    //    String function_name = "imbAddModule_3_Click";
    //    try
    //    {
    //        Int32 ConPaId, PagId;

    //        Int32.TryParse(Request["PagId"], out PagId);
    //        Int32.TryParse(Request["ConPa"], out ConPaId);

    //        if (PagId > 0 && ConPaId > 0)
    //        {
    //            String conPa = "";

    //            if (ConPaId == 1)
    //            {
    //                conPa = "ContentPane1";
    //            }
    //            else if (ConPaId == 2)
    //            {
    //                conPa = "ContentPane2";
    //            }
    //            else
    //            {
    //                conPa = "[ SET CONTENTPANE ]";
    //            }

    //            RXServer.Modules.News.Create(1, PagId, 32, conPa, 1, 1, false, false);

    //            this.MessageBox.Visible = true;
    //            this.ltrMessage.Text = " -  News Box was added to your page.";
    //        }
    //        else
    //        {
    //            this.ErrorBox.Visible = true;
    //            this.ltrErrors.Text = " - News Box wasn't added to your page. Please contact your admin";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        this.ErrorBox.Visible = true;
    //        this.ltrErrors.Text = ex.ToString();
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}
    //protected void imbAddModule_4_Click(object sender, ImageClickEventArgs e)
    //{
    //    String function_name = "imbAddModule_4_Click";
    //    try
    //    {
    //        Int32 ConPaId, PagId;

    //        Int32.TryParse(Request["PagId"], out PagId);
    //        Int32.TryParse(Request["ConPa"], out ConPaId);

    //        if (PagId > 0 && ConPaId > 0)
    //        {
    //            String conPa = "";

    //            if (ConPaId == 1)
    //            {
    //                conPa = "ContentPane1";
    //            }
    //            else if (ConPaId == 2)
    //            {
    //                conPa = "ContentPane2";
    //            }
    //            else
    //            {
    //                conPa = "[ SET CONTENTPANE ]";
    //            }

    //            RXServer.Modules.Calendar.Create(1, PagId, 31, conPa, 1, 1, false, false);

    //            this.MessageBox.Visible = true;
    //            this.ltrMessage.Text = " -  Calendar Box was added to your page.";
    //        }
    //        else
    //        {
    //            this.ErrorBox.Visible = true;
    //            this.ltrErrors.Text = " - Calendar Box wasn't added to your page. Please contact your admin";
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        this.ErrorBox.Visible = true;
    //        this.ltrErrors.Text = ex.ToString();
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}

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

                //RXServer.Modules.RSS_Feeder.Create(1, PagId, 66, conPa, 1, 1, false, false);

                this.MessageBox.Visible = true;
                this.ltrMessage.Text = " -  RSS Feeder Box was added to your page.";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - RSS Feeder Box wasn't added to your page. Please contact your admin";
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imbAddModule_6_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbAddModule_6_Click";
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

                RXServer.Modules.TextModule.Create(1, PagId, 71, conPa, 1, 1, false, false);

                this.MessageBox.Visible = true;
                this.ltrMessage.Text = " -  Text Box was added to your page.";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - Text Box wasn't added to your page. Please contact your admin";
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imbAddModule_7_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbAddModule_7_Click";
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

                RXServer.Modules.StandardModule.Create(1, PagId, 87, conPa, 1, 1, false, false);

                this.MessageBox.Visible = true;
                this.ltrMessage.Text = " -  Tag Cloud was added to your page.";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - Tag Cloud wasn't added to your page. Please contact your admin";
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
