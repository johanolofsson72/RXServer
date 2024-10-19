using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Security.Permissions;
using System.Threading;
using Telerik.Web;


public partial class Modules_Links_InternalLink : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Links_InternalLink";

    Int32 LinkedId;
    public String LinkId
    {
        set
        {
            //this.lblHideCommentId.Text = value.ToString();
            Int32.TryParse(value, out LinkedId);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (!Page.IsPostBack)
            {
                if (RXServer.Web.RequestValues.ModId == 0)
                {
                    populateDDL1();
                }
                else
                {
                    populateDDL1();
                    bindData();
                }
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
            setSelectedItem(LinkedId);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
        
    }

    private void setSelectedItem(int linkedId)
    {
        String function_name = "setSelectedItem";
        try
        {
            //Check ddl1
            RXServer.Modules.Menu.Item m = new RXServer.Modules.Menu.Item(linkedId);
            int i = 0;

            if (m.Level.Equals(1))
            {
                foreach (ListItem li in this.ddlLevel1.Items)
                {

                    if (li.Value == Convert.ToString(linkedId))
                    {
                        this.ddlLevel1.SelectedIndex = i;
                        populateDDL2(linkedId);
                        return;
                    }
                    i++;
                }
            }

            else if (m.Level.Equals(2))
            {
                //Check ddl1
                foreach (ListItem li in this.ddlLevel1.Items)
                {
                    if (li.Value == m.Parents[0].ToString())
                    {
                        this.ddlLevel1.SelectedIndex = i;
                    }
                    i++;
                }
                //Check ddl2
                populateDDL2(m.Parents[0]);
                i = 0;
                foreach (ListItem li in this.ddlLevel2.Items)
                {
                    if (li.Value == Convert.ToString(linkedId))
                    {
                        this.ddlLevel2.SelectedIndex = i;
                    }
                    i++;
                }
            }

            else if (m.Level.Equals(3))
            {
                //Check ddl1
                foreach (ListItem li in this.ddlLevel1.Items)
                {
                    if (li.Value == m.Parents[1].ToString())
                    {
                        this.ddlLevel1.SelectedIndex = i;
                    }
                    i++;
                }
                //Check ddl2
                populateDDL2(m.Parents[1]);
                i = 0;
                foreach (ListItem li in this.ddlLevel2.Items)
                {
                    if (li.Value == m.Parents[0].ToString())
                    {
                        this.ddlLevel2.SelectedIndex = i;
                    }
                    i++;
                }

                //Check ddl3
                populateDDL3(m.Parents[0]);
                i = 0;
                foreach (ListItem li in this.ddlLevel3.Items)
                {
                    if (li.Value == Convert.ToString(linkedId))
                    {
                        this.ddlLevel3.SelectedIndex = i;
                    }
                    i++;
                }
            }

            else if (m.Level.Equals(4))
            {
                //Check ddl1
                foreach (ListItem li in this.ddlLevel1.Items)
                {
                    if (li.Value == m.Parents[2].ToString())
                    {
                        this.ddlLevel1.SelectedIndex = i;
                    }
                    i++;
                }
                //Check ddl2
                populateDDL2(m.Parents[2]);
                i = 0;
                foreach (ListItem li in this.ddlLevel2.Items)
                {
                    if (li.Value == m.Parents[1].ToString())
                    {
                        this.ddlLevel2.SelectedIndex = i;
                    }
                    i++;
                }

                //Check ddl3
                populateDDL3(m.Parents[1]);
                i = 0;
                foreach (ListItem li in this.ddlLevel3.Items)
                {
                    if (li.Value == m.Parents[0].ToString())
                    {
                        this.ddlLevel3.SelectedIndex = i;
                    }
                    i++;
                }

                //Check ddl4
                populateDDL4(m.Parents[0]);
                i = 0;
                foreach (ListItem li in this.ddlLevel4.Items)
                {
                    if (li.Value == Convert.ToString(linkedId))
                    {
                        this.ddlLevel4.SelectedIndex = i;
                    }
                    i++;
                }
            }
            else if (m.Level.Equals(5))
            {
                //Check ddl1
                foreach (ListItem li in this.ddlLevel1.Items)
                {
                    if (li.Value == m.Parents[3].ToString())
                    {
                        this.ddlLevel1.SelectedIndex = i;
                    }
                    i++;
                }
                //Check ddl2
                populateDDL2(m.Parents[3]);
                i = 0;
                foreach (ListItem li in this.ddlLevel2.Items)
                {
                    if (li.Value == m.Parents[2].ToString())
                    {
                        this.ddlLevel2.SelectedIndex = i;
                    }
                    i++;
                }

                //Check ddl3
                populateDDL3(m.Parents[2]);
                i = 0;
                foreach (ListItem li in this.ddlLevel3.Items)
                {
                    if (li.Value == m.Parents[1].ToString())
                    {
                        this.ddlLevel3.SelectedIndex = i;
                    }
                    i++;
                }

                //Check ddl4
                populateDDL4(m.Parents[1]);
                i = 0;
                foreach (ListItem li in this.ddlLevel4.Items)
                {
                    if (li.Value == m.Parents[0].ToString())
                    {
                        this.ddlLevel4.SelectedIndex = i;
                    }
                    i++;
                }

                //Check ddl5
                populateDDL5(m.Parents[0]);
                i = 0;
                foreach (ListItem li in this.ddlLevel5.Items)
                {
                    if (li.Value == Convert.ToString(linkedId))
                    {
                        this.ddlLevel5.SelectedIndex = i;
                    }
                    i++;
                }

            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
            
    }

    private void populateDDL1()
    {
        String function_name = "populateDDL1";
        try
        {
            int ModId = RXServer.Web.RequestValues.ModId;
            int PagId = RXServer.Web.RequestValues.PagId;
            int SitId = RXServer.Web.RequestValues.SitId;
            
            this.ddlLevel1.Items.Add(new ListItem("Choose category", "0"));
            this.ddlLevel2.Items.Add(new ListItem("-", "0"));
            this.ddlLevel3.Items.Add(new ListItem("-", "0"));
            this.ddlLevel4.Items.Add(new ListItem("-", "0"));
            this.ddlLevel5.Items.Add(new ListItem("-", "0"));

            RXServer.Modules.Menu m = new RXServer.Modules.Menu(1,0,1);
            if (m.Count > 0)
            {
                foreach (LiquidCore.Menu.Item mi in m)
                {
                    this.ddlLevel1.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                }
            }

            RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, 0, 2);
            if (m2.Count > 0)
            {
                foreach (LiquidCore.Menu.Item mi2 in m2)
                {
                    this.ddlLevel1.Items.Add(new ListItem(Server.HtmlDecode(mi2.Title.ToString()), mi2.Id.ToString()));
                }
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    private void populateDDL2(int pageParentId)
    {
        String function_name = "populateDDL2";
        try
        {
            if (pageParentId != 0)
            {
                RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, pageParentId, 1);
                if (m.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi in m)
                    {
                        this.ddlLevel2.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                    }
                }
                RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, pageParentId, 2);
                if (m2.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi2 in m2)
                    {
                        this.ddlLevel2.Items.Add(new ListItem(Server.HtmlDecode(mi2.Title.ToString()), mi2.Id.ToString()));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void populateDDL3(int pageParentId)
    {
        String function_name = "populateDDL3";
        try
        {
            if (pageParentId != 0)
            {
                RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, pageParentId, 1);
                if (m.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi in m)
                    {
                        this.ddlLevel3.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                    }
                }
                RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, pageParentId, 2);
                if (m2.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi2 in m2)
                    {
                        this.ddlLevel3.Items.Add(new ListItem(Server.HtmlDecode(mi2.Title.ToString()), mi2.Id.ToString()));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void populateDDL4(int pageParentId)
    {
        String function_name = "populateDDL4";
        try
        {
            if (pageParentId != 0)
            {
                RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, pageParentId, 1);
                if (m.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi in m)
                    {
                        this.ddlLevel4.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                    }
                }
                RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, pageParentId, 2);
                if (m2.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi2 in m2)
                    {
                        this.ddlLevel4.Items.Add(new ListItem(Server.HtmlDecode(mi2.Title.ToString()), mi2.Id.ToString()));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void populateDDL5(int pageParentId)
    {
        String function_name = "populateDDL5";
        try
        {
            if (pageParentId != 0)
            {                
                RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, pageParentId, 2);
                if (m.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi in m)
                    {
                        this.ddlLevel5.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }


    protected void ddlLevel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel1_SelectedIndexChanged";
        try
        {
            //insertFileIfPostBack();

            this.ddlLevel2.Items.Clear();
            this.ddlLevel3.Items.Clear();
            this.ddlLevel4.Items.Clear();
            this.ddlLevel5.Items.Clear();

            this.ddlLevel2.Items.Add(new ListItem("Choose category", "0"));
            this.ddlLevel3.Items.Add(new ListItem("-", "0"));
            this.ddlLevel4.Items.Add(new ListItem("-", "0"));
            this.ddlLevel5.Items.Add(new ListItem("-", "0"));

            populateDDL2(Convert.ToInt32(this.ddlLevel1.SelectedItem.Value));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void ddlLevel2_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel2_SelectedIndexChanged";
        try
        {
            //insertFileIfPostBack();

            this.ddlLevel3.Items.Clear();
            this.ddlLevel4.Items.Clear();
            this.ddlLevel5.Items.Clear();
            this.ddlLevel3.Items.Add(new ListItem("Choose category ", "0"));
            this.ddlLevel4.Items.Add(new ListItem("- ", "0"));
            this.ddlLevel5.Items.Add(new ListItem("- ", "0"));
            
            populateDDL3(Convert.ToInt32(this.ddlLevel2.SelectedItem.Value));

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    protected void ddlLevel3_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel3_SelectedIndexChanged";
        try
        {
            //insertFileIfPostBack();

            this.ddlLevel4.Items.Clear();
            this.ddlLevel5.Items.Clear();
            this.ddlLevel4.Items.Add(new ListItem("Choose category ", "0"));
            this.ddlLevel5.Items.Add(new ListItem("- ", "0"));

            populateDDL4(Convert.ToInt32(this.ddlLevel3.SelectedItem.Value));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void ddlLevel4_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel4_SelectedIndexChanged";
        try
        {

            this.ddlLevel5.Items.Clear();
            this.ddlLevel5.Items.Add(new ListItem("Choose category ", "0"));

            populateDDL5(Convert.ToInt32(this.ddlLevel4.SelectedItem.Value));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void ddlLevel5_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel5_SelectedIndexChanged";
        try
        {

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

  

}
