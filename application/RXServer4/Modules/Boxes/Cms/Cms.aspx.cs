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
using Telerik.Web.UI;
using System.Text;
using System.Globalization;

public partial class Modules_Boxes_Cms_Cms : System.Web.UI.Page
{
    static string CurrentUser = String.Empty;
    bool AutoCreatedItems = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        // inloggad ???
        if (RXServer.Auth.IsInRole("CRM_USERS"))
        {
            Panel1.Visible = false;
            Panel2.Visible = true; 
            if (!Page.IsPostBack)
            {
                BindData();
                BindData_StatusInfo();
                BindData_Events();
                BindData_NewContact();
                BindData_AllContacts();
                BindData_AllCompanies();
                BindData_AllEvents();
            }
        }
        else
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
    }

    public void BindData()
    {
        switch (RXServer.Auth.AuthorizedUser.Identity.Name)
        {
            case "jool":
                {
                    CurrentUser = "johan olofsson";
                    AutoCreatedItems = false;
                    break;
                }
            case "bjan":
                {
                    CurrentUser = "björn andersson";
                    AutoCreatedItems = false;
                    break;
                }
            case "chjo":
                {
                    CurrentUser = "charlie jolin";
                    AutoCreatedItems = true;
                    break;
                }
            case "daol":
                {
                    CurrentUser = "david olandersson";
                    AutoCreatedItems = false;
                    break;
                }
            case "dale":
                {
                    CurrentUser = "daniel lenneer";
                    AutoCreatedItems = false;
                    break;
                }
            default:
                {
                    break;
                }
        }

        RXServer.Modules.Crm.Events meve = new RXServer.Modules.Crm.Events("RXServer.Modules.Crm.Events.Event", CurrentUser);
        meve.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value6, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
        ddMyEvents.DataSource = meve;
        ddMyEvents.DataBind();

        RXServer.Modules.Crm.ToDo todo = new RXServer.Modules.Crm.ToDo("RXServer.Modules.Crm.ToDo.Item", CurrentUser);
        todo.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value6, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
        ddThings.DataSource = todo;
        ddThings.DataBind();

        // kolla om det ska hämtas data från databasen som ska hjälpa användaren att veta när det är dags att
        // kontakta en kund/kontakt...
        if (AutoCreatedItems && todo.Count < 10 && CurrentUser.Length > 0)
            FindAndAutoCreateToDoThings();

        autothings.Visible = AutoCreatedItems;
    }
    public void BindData_StatusInfo()
    {
        lblTotalNewEvents.Text = BookedNewContactEventTotal();
        lblEventBookedTotal.Text = BookedEventTotal();
        lblEventPerformed.Text = EventPerformed();
        lblEventBudget.Text = EventBudget();
        if (Convert.ToInt32(lblTotalNewEvents.Text) + 4 < Convert.ToInt32(lblEventBudget.Text))
            ClientScript.RegisterStartupScript(this.GetType(), "blinker", "doBlink1('" + lblTotalNewEvents.ClientID + "');", true);
        else if (Convert.ToInt32(lblTotalNewEvents.Text) + 3 < Convert.ToInt32(lblEventBudget.Text))
            ClientScript.RegisterStartupScript(this.GetType(), "blinker", "doBlink1('" + lblTotalNewEvents.ClientID + "');", true);
        else if (Convert.ToInt32(lblTotalNewEvents.Text) + 2 < Convert.ToInt32(lblEventBudget.Text))
            ClientScript.RegisterStartupScript(this.GetType(), "blinker", "doBlink1('" + lblTotalNewEvents.ClientID + "');", true);
        else if (Convert.ToInt32(lblTotalNewEvents.Text) + 1 < Convert.ToInt32(lblEventBudget.Text))
            ClientScript.RegisterStartupScript(this.GetType(), "blinker", "doBlink1('" + lblTotalNewEvents.ClientID + "');", true);
        else
            ClientScript.RegisterStartupScript(this.GetType(), "green", "doGreen('" + lblTotalNewEvents.ClientID + "');", true);
    }
    public void BindData_Events()
    {
        using (RXServer.Modules.Crm.Contacts cs = new RXServer.Modules.Crm.Contacts("RXServer.Modules.Crm.Contacts.Contact"))
        {
            cs.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value16, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
            ddEContacts.Items.Clear();
            ddEContacts.Items.Add(new ListItem("Välj kontakt", "-1"));
            ddEContacts.Items.Add(new ListItem("Ingen", "-2"));
            foreach (LiquidCore.List.Item c in cs)
            {
                ddEContacts.Items.Add(new ListItem("(" + GetCompanyById(c.Value16) + ") " + c.Value3, c.Id.ToString()));
            }
        } 
        using (RXServer.Modules.Crm.Companies ns = new RXServer.Modules.Crm.Companies("RXServer.Modules.Crm.Companies.Company"))
        {
            ns.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value3, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
            ddECompanies.Items.Clear();
            ddECompanies.Items.Add(new ListItem("Välj företag", "-1"));
            ddECompanies.Items.Add(new ListItem("Inget", "-2"));
            foreach (LiquidCore.List.Item c in ns)
            {
                ddECompanies.Items.Add(new ListItem(c.Value3, c.Id.ToString()));
            }
        }
    }
    public void BindData_NewContact()
    {
        using (RXServer.Modules.Crm.Contacts cs = new RXServer.Modules.Crm.Contacts("RXServer.Modules.Crm.Contacts.Contact"))
        {
            cs.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value16, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
            rlbRelations.Items.Clear();
            rlbRelations.Items.Add(new ListItem("Välj referrens eller lägg till ny", "-1"));
            rlbRelations.Items.Add(new ListItem("Lägg till ny", "0"));
            rlbRelations.Items.Add(new ListItem("Ingen", "-2"));
            foreach (LiquidCore.List.Item c in cs)
            {
                rlbRelations.Items.Add(new ListItem("(" + GetCompanyById(c.Value16) + ") " + c.Value3, c.Id.ToString()));
            }
            rlbRelations.SelectedIndex = 2;
        }

        using (RXServer.Modules.Crm.Networks ns = new RXServer.Modules.Crm.Networks("RXServer.Modules.Crm.Networks.Network"))
        {
            ns.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value3, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
            rlbNetworks.Items.Clear();
            rlbNetworks.Items.Add(new ListItem("Välj nätverk eller lägg till nytt", "-1"));
            rlbNetworks.Items.Add(new ListItem("Lägg till nytt", "0"));
            rlbNetworks.Items.Add(new ListItem("Inget", "-2"));
            foreach (LiquidCore.List.Item c in ns)
            {
                rlbNetworks.Items.Add(new ListItem(c.Value3, c.Id.ToString()));
            }
            rlbNetworks.SelectedIndex = 2;
        }
    }
    public void BindData_AllContacts()
    {

        RXServer.Modules.Crm.Contacts cot = new RXServer.Modules.Crm.Contacts("RXServer.Modules.Crm.Contacts.Contact");
        cot.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value3, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
        dlContacts.DataSource = cot;
        dlContacts.DataBind();
    }
    public void BindData_AllCompanies()
    {
        RXServer.Modules.Crm.Companies cos = new RXServer.Modules.Crm.Companies("RXServer.Modules.Crm.Companies.Company");
        cos.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value3, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
        dlCompanies.DataSource = cos;
        dlCompanies.DataBind();
    }
    public void BindData_AllEvents()
    {
        RXServer.Modules.Crm.Events eve = new RXServer.Modules.Crm.Events("RXServer.Modules.Crm.Events.Event");
        eve.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value6, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
        ddAllEvents.DataSource = eve;
        ddAllEvents.DataBind();
    }


    #region New Contact
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        RadTabStrip2.Tabs[1].Selected = true;
        RadMultiPage2.SelectedIndex = 1;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        RadTabStrip2.Tabs[2].Selected = true;
        RadMultiPage2.SelectedIndex = 2;
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Int32 Network = 0;
        Int32 Company = 0;
        Int32 Relation = 0;
        if (txtName.Text.Length > 0 &&
            txtCompany.Text.Length > 0 &&
            txtRole.Text.Length > 0 &&
            txtPhone.Text.Length > 0 &&
            txtMail.Text.Length > 0)
        {
            // spara eventuellt referrens-kontakt 
            Relation = Convert.ToInt32(rlbRelations.SelectedValue);
            if (rlbRelations.SelectedValue.Equals("0"))
            {
                RXServer.Modules.Crm.Contacts.Contact r = new RXServer.Modules.Crm.Contacts.Contact();
                r.SitId = RXServer.Web.RequestValues.SitId;
                r.PagId = RXServer.Web.RequestValues.PagId;
                r.ModId = RXServer.Web.RequestValues.ModId;
                r.Name = txtRelation.Text;
                r.Role = "Referrens";
                r.Save();
                Relation = r.Id;
            }

            // spara eventuellt nätverk
            bool NetworkExist = false;
            Network = Convert.ToInt32(rlbNetworks.SelectedValue);
            using (RXServer.Modules.Crm.Networks nw = new RXServer.Modules.Crm.Networks("RXServer.Modules.Crm.Networks.Network"))
            {
                foreach (LiquidCore.List.Item i in nw)
                    if (i.Value3.ToLower().Equals(txtNetwork.Text.ToLower()))
                    {
                        Network = i.Id;
                        NetworkExist = true;
                    }
            }
            if (rlbNetworks.SelectedValue.Equals("0") && !NetworkExist)
            {
                RXServer.Modules.Crm.Networks.Network n = new RXServer.Modules.Crm.Networks.Network();
                n.SitId = RXServer.Web.RequestValues.SitId;
                n.PagId = RXServer.Web.RequestValues.PagId;
                n.ModId = RXServer.Web.RequestValues.ModId;
                n.Name = txtNetwork.Text;
                n.Save();
                Network = n.Id;
            }

            // spara företag
            bool CompanyExist = false;
            using (RXServer.Modules.Crm.Companies nw = new RXServer.Modules.Crm.Companies("RXServer.Modules.Crm.Companies.Company"))
            {
                foreach (LiquidCore.List.Item i in nw)
                    if (i.Value3.ToLower().Equals(txtCompany.Text.ToLower()))
                    {
                        Company = i.Id;
                        CompanyExist = true;
                    }
            }
            if (!CompanyExist)
            {
                RXServer.Modules.Crm.Companies.Company c = new RXServer.Modules.Crm.Companies.Company();
                c.SitId = RXServer.Web.RequestValues.SitId;
                c.PagId = RXServer.Web.RequestValues.PagId;
                c.ModId = RXServer.Web.RequestValues.ModId;
                c.Name = txtCompany.Text;
                c.Phone1 = txtPhone.Text;
                c.Email1 = txtMail.Text;
                c.Type = (chkOldCompany.Checked ? 0 : 3);
                c.Save();
                Company = c.Id;
            }

            // spara kontakt
            bool ContactExist = false;
            Int32 ContactId = 0;
            using (RXServer.Modules.Crm.Contacts nw = new RXServer.Modules.Crm.Contacts("RXServer.Modules.Crm.Contacts.Contact"))
            {
                foreach (LiquidCore.List.Item i in nw)
                    if (i.Value3.ToLower().Equals(txtName.Text.ToLower()))
                    {
                        ContactId = i.Id;
                        CompanyExist = true;
                    }
            }
            if (!ContactExist)
            {
                RXServer.Modules.Crm.Contacts.Contact d = new RXServer.Modules.Crm.Contacts.Contact();
                d.SitId = RXServer.Web.RequestValues.SitId;
                d.PagId = RXServer.Web.RequestValues.PagId;
                d.ModId = RXServer.Web.RequestValues.ModId;
                d.Name = txtName.Text;
                d.Role = txtRole.Text;
                d.BusinessPhone = txtPhone.Text;
                d.BusinessEmail = txtMail.Text;
                d.Description = txtComment.Text;
                if (Company > 0)
                    d.Company = new RXServer.Modules.Crm.Companies.Company(Company);
                if (Network > 0)
                    d.Network = new RXServer.Modules.Crm.Networks.Network(Network);
                d.Save();
                ContactId = d.Id;
            }

            // spara relation
            if (Relation > 0 && ContactId > 0)
            {
                RXServer.Modules.Crm.Relations.Relation rr = new RXServer.Modules.Crm.Relations.Relation();
                rr.SitId = RXServer.Web.RequestValues.SitId;
                rr.PagId = RXServer.Web.RequestValues.PagId;
                rr.ModId = RXServer.Web.RequestValues.ModId;
                if (Relation > 0)
                    rr.Contact1 = new RXServer.Modules.Crm.Contacts.Contact(Relation);
                if (ContactId > 0)
                    rr.Contact2 = new RXServer.Modules.Crm.Contacts.Contact(ContactId);
                rr.Comment = "";
                rr.Save();
            }

            // reload data
            BindData_NewContact();
            BindData_AllContacts();
            BindData_Events();

            // om nytt möte ska bokas
            if (chkMeeting.Checked)
            {
                RadTabStrip1.Tabs[1].Selected = true;
                RadMultiPage1.SelectedIndex = 1;

                // set values...
                if (Company > 0 && ContactId > 0)
                {
                    ddECompanies.SelectedValue = Company.ToString();
                    ddEContacts.SelectedValue = ContactId.ToString();
                    ddWho.SelectedValue = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CurrentUser);
                    txtEStartDate.SelectedDate = DateTime.Now;
                    txtEEndDate.SelectedDate = DateTime.Now;
                    txtEComment.Text = "";
                }
            }
            else
            {
                RadTabStrip2.Tabs[0].Selected = true;
                RadMultiPage2.SelectedIndex = 0;

                RadTabStrip1.Tabs[2].Selected = true;
                RadMultiPage1.SelectedIndex = 2;
            }

            // clean
            txtName.Text = String.Empty;
            txtCompany.Text = String.Empty;
            txtRole.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtMail.Text = String.Empty;
            txtComment.Text = String.Empty;
            chkOldCompany.Checked = false;
        }
        else
        {
            RadTabStrip2.Tabs[1].Selected = true;
            RadMultiPage2.SelectedIndex = 1;
        }
    }
    protected void rlbRelations_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rlbRelations.SelectedValue.Equals("0"))
        {
            txtRelation.Visible = true;
            txtRelation.Text = "Ny referrens...";
            txtRelation.Focus();
        }
    }
    protected void rlbNetworks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rlbNetworks.SelectedValue.Equals("0"))
        {
            txtNetwork.Visible = true;
            txtNetwork.Text = "Nytt nätverk...";
            txtNetwork.Focus();
        }
    }
    #endregion
    #region New Event
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Int32 Company = 0;
        Int32 Contact = 0; 
        DateTime StartDate = DateTime.Now;
        DateTime EndDate = DateTime.Now;
        try
        {
            DateTime.TryParse(txtEStartDate.SelectedDate.ToString(), out StartDate);
            DateTime.TryParse(txtEEndDate.SelectedDate.ToString(), out EndDate);
            if (StartDate.Year < 2001)
                StartDate = DateTime.Now;
            if (EndDate.Year < 2001)
                EndDate = DateTime.Now;

            // spara möte event telefonsamtal
            Company = Convert.ToInt32(ddECompanies.SelectedValue);
            Contact = Convert.ToInt32(ddEContacts.SelectedValue);
            RXServer.Modules.Crm.Events.Event d = new RXServer.Modules.Crm.Events.Event();
            d.SitId = RXServer.Web.RequestValues.SitId;
            d.PagId = RXServer.Web.RequestValues.PagId;
            d.ModId = RXServer.Web.RequestValues.ModId;
            if (Company > 0)
                d.Company = new RXServer.Modules.Crm.Companies.Company(Company);
            if (Contact > 0)
                d.Contact = new RXServer.Modules.Crm.Contacts.Contact(Contact);
            d.Title = txtETitle.Text;
            d.Place = txtEPlace.Text;
            d.Type = ddType.SelectedValue;
            d.OpenedBy = ddWho.SelectedValue;
            d.OpenedDate = StartDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
            d.DueDate = EndDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
            d.Comment = txtEComment.Text;
            d.Save();

            // spara eventuellt fler som ska på mötet...
            if (ddWho2.SelectedIndex > 0)
            {
                d = new RXServer.Modules.Crm.Events.Event();
                d.SitId = RXServer.Web.RequestValues.SitId;
                d.PagId = RXServer.Web.RequestValues.PagId;
                d.ModId = RXServer.Web.RequestValues.ModId;
                if (Company > 0)
                    d.Company = new RXServer.Modules.Crm.Companies.Company(Company);
                if (Contact > 0)
                    d.Contact = new RXServer.Modules.Crm.Contacts.Contact(Contact);
                d.Title = txtETitle.Text;
                d.Place = txtEPlace.Text;
                d.Type = ddType.SelectedValue;
                d.OpenedBy = ddWho2.SelectedValue;
                d.OpenedDate = StartDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                d.DueDate = EndDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                d.Comment = txtEComment.Text;
                d.Save();
            }

            RadTabStrip1.Tabs[4].Selected = true;
            RadMultiPage1.SelectedIndex = 4;

            // erase from todo
            Int32 TransportId = 0;
            if (Session["TransportId"] != null)
            {
                TransportId = Convert.ToInt32(Session["TransportId"].ToString());
                if (TransportId > 0)
                {
                    RXServer.Modules.Crm.ToDo.Item c = new RXServer.Modules.Crm.ToDo.Item(TransportId);
                    c.Value2 = "2";
                    c.Save();
                    RadTabStrip1.Tabs[5].Selected = true;
                    RadMultiPage1.SelectedIndex = 5;
                }
            }

            // clean
            txtETitle.Text = String.Empty;
            txtEPlace.Text = String.Empty;
            ddType.SelectedIndex = 0;
            ddWho.SelectedIndex = 0;
            ddWho2.SelectedIndex = 0;
            ddECompanies.SelectedIndex = 0;
            ddEContacts.SelectedIndex = 0;
            txtEComment.Text = String.Empty;
            Session["TransportId"] = "0";

            // jump
            BindData();
            BindData_AllEvents();
            BindData_StatusInfo();
            BindData_Events();
        }
        catch (Exception ex)
        {
            RadTabStrip2.Tabs[2].Selected = true;
            RadTabStrip3.Tabs[0].Selected = true;
            RadMultiPage3.SelectedIndex = 0;
        }
    }
    protected void ddECompanies_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEPhone.Text = "";
        lblEMail.Text = "";
        lblEMail.NavigateUrl = "";
        Int32 Company = Convert.ToInt32(ddECompanies.SelectedValue);
        using (RXServer.Modules.Crm.Contacts cs = new RXServer.Modules.Crm.Contacts("RXServer.Modules.Crm.Contacts.Contact"))
        {
            cs.Sort(LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Value3, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Ascending);
            ddEContacts.Items.Clear();
            ddEContacts.Items.Add(new ListItem("Välj kontakt", "-1"));
            ddEContacts.Items.Add(new ListItem("Ingen", "-2"));
            foreach (LiquidCore.List.Item c in cs)
            {
                if (Company.Equals(Convert.ToInt32(c.Value16)))
                    ddEContacts.Items.Add(new ListItem(c.Value3, c.Id.ToString()));
            }
        }
    }
    protected void ddEContacts_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEPhone.Text = "";
        lblEMail.Text = "";
        lblEMail.NavigateUrl = "";
        Int32 Contact = Convert.ToInt32(ddEContacts.SelectedValue);
        using (RXServer.Modules.Crm.Contacts.Contact c = new RXServer.Modules.Crm.Contacts.Contact(Contact))
        {
            lblEPhone.Text = c.BusinessPhone;
            lblEMail.Text = c.BusinessEmail;
            lblEMail.NavigateUrl = "mailto:" + c.BusinessEmail;
        }
    }
    #endregion
    #region All Contacts
    public void dlContacts_CancelCommand(Object Sender, DataListCommandEventArgs e)
    {
        dlContacts.EditItemIndex = -1;
        BindData();
    }
    public void dlContacts_EditCommand(Object Sender, DataListCommandEventArgs e)
    {
        dlContacts.EditItemIndex = e.Item.ItemIndex;
        Int32 Id = (Int32)dlContacts.DataKeys[e.Item.ItemIndex];
        BindData_AllContacts();
        TextBox txtCName = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCName");
        Label txtCCompany = (Label)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCCompany");
        TextBox txtCRole = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCRole");
        TextBox txtCPhone = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCPhone");
        TextBox txtCMail = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCMail");
        TextBox txtCComment = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCComment");
        RXServer.Modules.Crm.Contacts.Contact c = new RXServer.Modules.Crm.Contacts.Contact(Id);
        txtCName.Text = c.Name;
        txtCCompany.Text = c.Company.Name;
        txtCRole.Text = c.Role;
        txtCPhone.Text = c.BusinessPhone;
        txtCMail.Text = c.BusinessEmail;
        txtCComment.Text = c.Description;
    }
    public void dlContacts_UpdateCommand(Object Sender, DataListCommandEventArgs e)
    {
        Int32 Id = (Int32)dlContacts.DataKeys[e.Item.ItemIndex];
        TextBox txtCName = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCName");
        Label txtCCompany = (Label)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCCompany");
        TextBox txtCRole = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCRole");
        TextBox txtCPhone = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCPhone");
        TextBox txtCMail = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCMail");
        TextBox txtCComment = (TextBox)dlContacts.Items[dlContacts.EditItemIndex].FindControl("txtCComment");
        RXServer.Modules.Crm.Contacts.Contact c = new RXServer.Modules.Crm.Contacts.Contact(Id);
        c.Name = txtCName.Text;
        //c.Company.Name = txtCCompany.Text;
        c.Role = txtCRole.Text;
        c.BusinessPhone = txtCPhone.Text;
        c.BusinessEmail = txtCMail.Text;
        c.Description = txtCComment.Text;
        c.Save();
        dlContacts.EditItemIndex = -1;
        BindData_AllContacts();
    }
    public void dlContacts_DeleteCommand(Object Sender, DataListCommandEventArgs e)
    {
        dlContacts.EditItemIndex = e.Item.ItemIndex;
        Int32 Id = (Int32)dlContacts.DataKeys[e.Item.ItemIndex];
        RXServer.Modules.Crm.Contacts.Contact c = new RXServer.Modules.Crm.Contacts.Contact(Id);
        c.Delete();
        dlContacts.EditItemIndex = -1;
        BindData_AllContacts();
    }
    public String GetCompanyById(String Id)
    {
        if (Id.Equals("0") || Id.Equals(String.Empty))
            return "Saknas";
        return new RXServer.Modules.Crm.Companies.Company(Convert.ToInt32(Id)).Name;
    }
    public String GetCompanyDesc(String longer)
    {
        if (longer.Equals(String.Empty))
            return "Saknas...";
        else if (longer.Length > 15)
            return longer.Substring(0, 15) + "...";
        else
            return longer;
    }
    public String GetNetworkByNetId(String NetId)
    {
        if (NetId.Equals("0") || NetId.Equals(String.Empty))
            return "Saknas";
        return new RXServer.Modules.Crm.Networks.Network(Convert.ToInt32(NetId)).Name;
    }
    #endregion
    #region All Companies
    public void dlCompanies_CancelCommand(Object Sender, DataListCommandEventArgs e)
    {
        dlCompanies.EditItemIndex = -1;
        BindData();
    }
    public void dlCompanies_EditCommand(Object Sender, DataListCommandEventArgs e)
    {
        dlCompanies.EditItemIndex = e.Item.ItemIndex;
        Int32 Id = (Int32)dlCompanies.DataKeys[e.Item.ItemIndex];
        BindData_AllCompanies();
        TextBox txtName = (TextBox)dlCompanies.Items[dlCompanies.EditItemIndex].FindControl("txtName");
        TextBox txtRating = (TextBox)dlCompanies.Items[dlCompanies.EditItemIndex].FindControl("txtRating");
        TextBox txtStatus = (TextBox)dlCompanies.Items[dlCompanies.EditItemIndex].FindControl("txtStatus");
        TextBox txtOrgNr = (TextBox)dlCompanies.Items[dlCompanies.EditItemIndex].FindControl("txtOrgNr");
        DropDownList ddAllaBolag = (DropDownList)dlCompanies.Items[dlCompanies.EditItemIndex].FindControl("ddAllaBolag");
        RXServer.Modules.Crm.Companies.Company c = new RXServer.Modules.Crm.Companies.Company(Id);
        txtName.Text = c.Name;
        //txtRating.Text = c.Rating;
        //txtStatus.Text = c.Status;
        txtOrgNr.Text = c.OrgNr;

        DropDownList d = GetAllaBolag(c.Name);
        ddAllaBolag.Items.Clear();
        if (d.Items.Count > 0)
            ddAllaBolag = d;
        else
            ddAllaBolag.Items.Add(new ListItem("saknas info om detta bolag"));
    }
    public void dlCompanies_UpdateCommand(Object Sender, DataListCommandEventArgs e)
    {
        Int32 Id = (Int32)dlCompanies.DataKeys[e.Item.ItemIndex];
        TextBox txtName = (TextBox)dlCompanies.Items[dlCompanies.EditItemIndex].FindControl("txtName");
        TextBox txtRating = (TextBox)dlCompanies.Items[dlCompanies.EditItemIndex].FindControl("txtRating");
        TextBox txtStatus = (TextBox)dlCompanies.Items[dlCompanies.EditItemIndex].FindControl("txtStatus");
        TextBox txtOrgNr = (TextBox)dlCompanies.Items[dlCompanies.EditItemIndex].FindControl("txtOrgNr");
        RXServer.Modules.Crm.Companies.Company c = new RXServer.Modules.Crm.Companies.Company(Id);
        c.Name = txtName.Text;
        //c.Rating = txtRating.Text;
        //c.Status = txtStatus.Text;
        c.OrgNr = txtOrgNr.Text;
        c.Save();
        dlCompanies.EditItemIndex = -1;
        BindData_AllCompanies();
    }
    public void dlCompanies_DeleteCommand(Object Sender, DataListCommandEventArgs e)
    {
        dlCompanies.EditItemIndex = e.Item.ItemIndex;
        Int32 Id = (Int32)dlCompanies.DataKeys[e.Item.ItemIndex];
        RXServer.Modules.Crm.Companies.Company c = new RXServer.Modules.Crm.Companies.Company(Id);
        c.Delete();
        dlCompanies.EditItemIndex = -1;
        BindData_AllCompanies();
    }
    public String GetContactById(String Id)
    {
        if (Id.Equals("0") || Id.Equals(String.Empty))
            return "Saknas";
        return new RXServer.Modules.Crm.Contacts.Contact(Convert.ToInt32(Id)).Name;
    }
    #endregion
    #region Relations
    #endregion
    #region All Events
    public void ddAllEvents_CancelCommand(Object Sender, DataListCommandEventArgs e)
    {
        ddAllEvents.EditItemIndex = -1;
        BindData();
    }
    public void ddAllEvents_EditCommand(Object Sender, DataListCommandEventArgs e)
    {
        ddAllEvents.EditItemIndex = e.Item.ItemIndex;
        Int32 Id = (Int32)ddAllEvents.DataKeys[e.Item.ItemIndex];
        BindData_AllEvents();
        Label txtVWho = (Label)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVWho");
        Label txtVType = (Label)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVType");
        Label txtVCompany = (Label)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVCompany");
        Label txtVContact = (Label)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVContact");
        TextBox txtVTitle = (TextBox)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVTitle");
        RadDateTimePicker txtVStartDate = (RadDateTimePicker)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVStartDate");
        RadDateTimePicker txtVEndDate = (RadDateTimePicker)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVEndDate");
        TextBox txtVComment = (TextBox)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVComment");
        DateTime StartDate = DateTime.Now;
        DateTime EndDate = DateTime.Now;
        RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
        DateTime.TryParse(c.OpenedDate, out StartDate);
        DateTime.TryParse(c.DueDate, out EndDate);
        if (StartDate.Year < 2001)
            StartDate = DateTime.Now;
        if (EndDate.Year < 2001)
            EndDate = DateTime.Now;
        txtVWho.Text = c.OpenedBy;
        txtVType.Text = c.Type;
        txtVCompany.Text = GetCompanyById(c.Company.Id.ToString());
        txtVContact.Text = GetContactById(c.Contact.Id.ToString());
        txtVTitle.Text = c.Title;
        txtVStartDate.SelectedDate = StartDate;
        txtVEndDate.SelectedDate = EndDate;
        txtVComment.Text = c.Comment;
    }
    public void ddAllEvents_UpdateCommand(Object Sender, DataListCommandEventArgs e)
    {
        Int32 Id = (Int32)ddAllEvents.DataKeys[e.Item.ItemIndex];
        Label txtVWho = (Label)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVWho");
        Label txtVType = (Label)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVType");
        Label txtVCompany = (Label)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVCompany");
        Label txtVContact = (Label)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVContact");
        TextBox txtVTitle = (TextBox)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVTitle");
        RadDateTimePicker txtVStartDate = (RadDateTimePicker)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVStartDate");
        RadDateTimePicker txtVEndDate = (RadDateTimePicker)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVEndDate");
        TextBox txtVComment = (TextBox)ddAllEvents.Items[ddAllEvents.EditItemIndex].FindControl("txtVComment");
        RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
        c.Title = txtVTitle.Text;
        c.OpenedDate = txtVStartDate.SelectedDate.ToString();
        c.DueDate = txtVEndDate.SelectedDate.ToString();
        c.Comment = txtVComment.Text;
        c.Save();
        ddAllEvents.EditItemIndex = -1;
        BindData_AllEvents();
    }
    public void ddAllEvents_DeleteCommand(Object Sender, DataListCommandEventArgs e)
    {
        ddAllEvents.EditItemIndex = e.Item.ItemIndex;
        Int32 Id = (Int32)ddAllEvents.DataKeys[e.Item.ItemIndex];
        RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
        c.Delete();
        ddAllEvents.EditItemIndex = -1;
        BindData_AllEvents();
        BindData_StatusInfo();
    }
    public void ddAllEvents_ItemCommand(Object Sender, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("done"))
        {
            ddAllEvents.EditItemIndex = e.Item.ItemIndex;
            Int32 Id = (Int32)ddAllEvents.DataKeys[e.Item.ItemIndex];
            RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
            c.Value2 = "2";
            c.Save();
            ddAllEvents.EditItemIndex = -1;
            BindData_AllEvents();
        }
    }
    public String IsEventTheFirstForThisContact(String ConId, String Data)
    {
        Int32 Counter = 0;
        bool FoundEarlier = false;
        RXServer.Modules.Crm.Events ee = new RXServer.Modules.Crm.Events("RXServer.Modules.Crm.Events.Event", true);
        foreach (LiquidCore.List.Item c in ee)
            if (c.Value17.Equals(ConId))
            {
                Counter++;
                Int32 _id = 0;
                Int32.TryParse(c.Value16, out _id);
                if (!new RXServer.Modules.Crm.Companies.Company(_id).Type.Equals(3))
                    FoundEarlier = true;
            }
        if (FoundEarlier)
            Counter++;
        return Data + " (" + Counter.ToString() + ")";
    }
    public String BookedNewContactEventTotal()
    {
        RXServer.Modules.Crm.Events ee = new RXServer.Modules.Crm.Events("RXServer.Modules.Crm.Events.Event", true, true);
        return ee.Count.ToString();
    }
    public String BookedEventTotal()
    {
        RXServer.Modules.Crm.Events ee = new RXServer.Modules.Crm.Events("RXServer.Modules.Crm.Events.Event", true);
        return ee.Count.ToString();
    }
    public String EventPerformed()
    {
        Int32 Counter = 0;
        RXServer.Modules.Crm.Events ee = new RXServer.Modules.Crm.Events("RXServer.Modules.Crm.Events.Event", true);
        foreach (LiquidCore.List.Item c in ee)
            if (c.Value2.Equals("2"))
                Counter++;
        return Counter.ToString();
    }
    public String EventBudget()
    {
        DateTime StartDate = DateTime.Now;
        DateTime.TryParse("2011-08-01", out StartDate);
        DateTime EndDate = DateTime.Now;
        DateTime.TryParse("2011-12-31", out EndDate);
        DateTime NowDate = DateTime.Now;

        TimeSpan t = NowDate.Subtract(StartDate);
        return ((t.Days / 7) * 7).ToString();
        //return "147";
    }
    #endregion
    #region My Events
    public void ddMyEvents_CancelCommand(Object Sender, DataListCommandEventArgs e)
    {
        ddMyEvents.EditItemIndex = -1;
        BindData();
    }
    public void ddMyEvents_EditCommand(Object Sender, DataListCommandEventArgs e)
    {
        ddMyEvents.EditItemIndex = e.Item.ItemIndex;
        Int32 Id = (Int32)ddMyEvents.DataKeys[e.Item.ItemIndex];
        BindData();
        Label txtVWho = (Label)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVWho");
        Label txtVType = (Label)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVType");
        Label txtVCompany = (Label)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVCompany");
        Label txtVContact = (Label)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVContact");
        TextBox txtVTitle = (TextBox)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVTitle");
        RadDateTimePicker txtVStartDate = (RadDateTimePicker)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVStartDate");
        RadDateTimePicker txtVEndDate = (RadDateTimePicker)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVEndDate");
        TextBox txtVComment = (TextBox)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVComment");
        DateTime StartDate = DateTime.Now;
        DateTime EndDate = DateTime.Now;
        RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
        DateTime.TryParse(c.OpenedDate, out StartDate);
        DateTime.TryParse(c.DueDate, out EndDate);
        if (StartDate.Year < 2001)
            StartDate = DateTime.Now;
        if (EndDate.Year < 2001)
            EndDate = DateTime.Now;
        txtVWho.Text = c.OpenedBy;
        txtVType.Text = c.Type;
        txtVCompany.Text = GetCompanyById(c.Company.Id.ToString());
        txtVContact.Text = GetContactById(c.Contact.Id.ToString());
        txtVTitle.Text = c.Title;
        txtVStartDate.SelectedDate = StartDate;
        txtVEndDate.SelectedDate = EndDate;
        txtVComment.Text = c.Comment;
    }
    public void ddMyEvents_UpdateCommand(Object Sender, DataListCommandEventArgs e)
    {
        Int32 Id = (Int32)ddMyEvents.DataKeys[e.Item.ItemIndex];
        Label txtVWho = (Label)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVWho");
        Label txtVType = (Label)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVType");
        Label txtVCompany = (Label)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVCompany");
        Label txtVContact = (Label)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVContact");
        TextBox txtVTitle = (TextBox)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVTitle");
        RadDateTimePicker txtVStartDate = (RadDateTimePicker)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVStartDate");
        RadDateTimePicker txtVEndDate = (RadDateTimePicker)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVEndDate");
        TextBox txtVComment = (TextBox)ddMyEvents.Items[ddMyEvents.EditItemIndex].FindControl("txtVComment");
        RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
        c.Title = txtVTitle.Text;
        c.OpenedDate = txtVStartDate.SelectedDate.ToString();
        c.DueDate = txtVEndDate.SelectedDate.ToString();
        c.Comment = txtVComment.Text;
        c.Save();
        ddMyEvents.EditItemIndex = -1;
        BindData();
    }
    public void ddMyEvents_DeleteCommand(Object Sender, DataListCommandEventArgs e)
    {
        ddMyEvents.EditItemIndex = e.Item.ItemIndex;
        Int32 Id = (Int32)ddMyEvents.DataKeys[e.Item.ItemIndex];
        RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
        c.Delete();
        ddMyEvents.EditItemIndex = -1;
        BindData();
        BindData_StatusInfo();
    }
    public void ddMyEvents_ItemCommand(Object Sender, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("done"))
        {
            ddMyEvents.EditItemIndex = e.Item.ItemIndex;
            Int32 Id = (Int32)ddMyEvents.DataKeys[e.Item.ItemIndex];
            RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
            c.Value2 = "2";
            c.Save();
            ddMyEvents.EditItemIndex = -1;
            BindData();
        }
    }
    #endregion
    #region My Things
    public void ddThings_CancelCommand(Object Sender, DataListCommandEventArgs e)
    {
        //ddThings.EditItemIndex = -1;
        //BindData();
    }
    public void ddThings_EditCommand(Object Sender, DataListCommandEventArgs e)
    {
        //ddThings.EditItemIndex = e.Item.ItemIndex;
        //Int32 Id = (Int32)ddThings.DataKeys[e.Item.ItemIndex];
        //BindData();
        //Label txtVWho = (Label)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVWho");
        //Label txtVType = (Label)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVType");
        //Label txtVCompany = (Label)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVCompany");
        //Label txtVContact = (Label)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVContact");
        //TextBox txtVTitle = (TextBox)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVTitle");
        //RadDateTimePicker txtVStartDate = (RadDateTimePicker)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVStartDate");
        //RadDateTimePicker txtVEndDate = (RadDateTimePicker)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVEndDate");
        //TextBox txtVComment = (TextBox)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVComment");
        //DateTime StartDate = DateTime.Now;
        //DateTime EndDate = DateTime.Now;
        //RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
        //DateTime.TryParse(c.OpenedDate, out StartDate);
        //DateTime.TryParse(c.DueDate, out EndDate);
        //if (StartDate.Year < 2001)
        //    StartDate = DateTime.Now;
        //if (EndDate.Year < 2001)
        //    EndDate = DateTime.Now;
        //txtVWho.Text = c.OpenedBy;
        //txtVType.Text = c.Type;
        //txtVCompany.Text = GetCompanyById(c.Company.Id.ToString());
        //txtVContact.Text = GetContactById(c.Contact.Id.ToString());
        //txtVTitle.Text = c.Title;
        //txtVStartDate.SelectedDate = StartDate;
        //txtVEndDate.SelectedDate = EndDate;
        //txtVComment.Text = c.Comment;
    }
    public void ddThings_UpdateCommand(Object Sender, DataListCommandEventArgs e)
    {
        //Int32 Id = (Int32)ddThings.DataKeys[e.Item.ItemIndex];
        //Label txtVWho = (Label)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVWho");
        //Label txtVType = (Label)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVType");
        //Label txtVCompany = (Label)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVCompany");
        //Label txtVContact = (Label)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVContact");
        //TextBox txtVTitle = (TextBox)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVTitle");
        //RadDateTimePicker txtVStartDate = (RadDateTimePicker)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVStartDate");
        //RadDateTimePicker txtVEndDate = (RadDateTimePicker)ddThings.Items[ddThings.EditItemIndex].FindControl("txtVEndDate");
        //TextBox txtVComment = (TextBox)ddThings.Items[ddMyEvents.EditItemIndex].FindControl("txtVComment");
        //RXServer.Modules.Crm.Events.Event c = new RXServer.Modules.Crm.Events.Event(Id);
        //c.Title = txtVTitle.Text;
        //c.OpenedDate = txtVStartDate.SelectedDate.ToString();
        //c.DueDate = txtVEndDate.SelectedDate.ToString();
        //c.Comment = txtVComment.Text;
        //c.Save();
        //ddThings.EditItemIndex = -1;
        //BindData();
    }
    public void ddThings_DeleteCommand(Object Sender, DataListCommandEventArgs e)
    {
        ddThings.EditItemIndex = e.Item.ItemIndex;
        Int32 Id = (Int32)ddThings.DataKeys[e.Item.ItemIndex];
        RXServer.Modules.Crm.ToDo.Item c = new RXServer.Modules.Crm.ToDo.Item(Id);
        c.Value2 = "4";
        c.Save();
        BindData();
    }
    public void ddThings_ItemCommand(Object Sender, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("create"))
        {
            RadTabStrip1.Tabs[1].Selected = true;
            RadMultiPage1.SelectedIndex = 1;
            RadTabStrip3.Tabs[0].Selected = true;
            RadMultiPage3.SelectedIndex = 0;
            
            ddThings.EditItemIndex = e.Item.ItemIndex;
            Int32 Id = (Int32)ddThings.DataKeys[e.Item.ItemIndex];
            Session["TransportId"] = Id.ToString();

            RXServer.Modules.Crm.ToDo.Item c = new RXServer.Modules.Crm.ToDo.Item(Id);
            txtETitle.Text = c.Title;
            txtEPlace.Text = c.Place;
            ddWho.SelectedValue = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(c.OpenedBy);
            ddECompanies.SelectedValue = c.Value16;
            ddEContacts.SelectedValue = c.Value17;
            txtEStartDate.SelectedDate = DateTime.Now;
            txtEEndDate.SelectedDate = DateTime.Now;
            txtEComment.Text = c.Comment;
        }
    }
    private void FindAndAutoCreateToDoThings()
    {
        StringBuilder sSQL = new StringBuilder();
        sSQL.AppendLine("SELECT CONVERT(con.obd_varchar16,SIGNED) AS Company, ");
        sSQL.AppendLine("con.obd_id AS Contact, ");
        sSQL.AppendLine("IFNULL((SELECT eve.obd_varchar7 ");
        sSQL.AppendLine("FROM obd_objectdata eve WHERE eve.obd_alias = 'RXServer.Modules.Crm.Events.Event' ");
        sSQL.AppendLine("AND CONVERT(eve.obd_varchar16,SIGNED) = CONVERT(con.obd_varchar16,SIGNED) AND eve.obd_deleted = 0 LIMIT 1),'2001-01-01 01:01:01') AS TDate");
        sSQL.AppendLine("FROM obd_objectdata con");
        sSQL.AppendLine("WHERE CONVERT(con.obd_varchar16,SIGNED) > 0 ");
        sSQL.AppendLine("AND con.obd_alias = 'RXServer.Modules.Crm.Contacts.Contact' AND con.obd_deleted = 0");
        sSQL.AppendLine("ORDER BY TDate ASC LIMIT 12");
        foreach (DataRow dr in RXServer.Data.Direct.GetDataTable(sSQL.ToString()).Rows)
        {
            Int32 Company = 0;
            Int32 Contact = 0;
            Int32.TryParse(dr["Company"].ToString(), out Company);
            Int32.TryParse(dr["Contact"].ToString(), out Contact);
            if (Company > 0 && Contact > 0)
            {
                Boolean Found = false;
                foreach (LiquidCore.List.Item ti in new RXServer.Modules.Crm.ToDo("RXServer.Modules.Crm.ToDo.Item"))
                    if (ti.Value16.Equals(Company.ToString()) && ti.Value17.Equals(Contact.ToString()))
                        Found = true;
                if (!Found)
                    AutoCreateToDoThings(Company, Contact, CurrentUser);
            }
        }
        ddThings.EditItemIndex = -1;
        //BindData();
    }
    private void AutoCreateToDoThings(Int32 Company, Int32 Contact, String CUser)
    {
        RXServer.Modules.Crm.ToDo.Item d = new RXServer.Modules.Crm.ToDo.Item();
        d.SitId = RXServer.Web.RequestValues.SitId;
        d.PagId = RXServer.Web.RequestValues.PagId;
        d.ModId = RXServer.Web.RequestValues.ModId;
        if (Company > 0)
            d.Company = new RXServer.Modules.Crm.Companies.Company(Company);
        if (Contact > 0)
            d.Contact = new RXServer.Modules.Crm.Contacts.Contact(Contact);
        d.Title = "Återkontakta";
        d.Place = "[plats]";
        d.Type = "[möte]";
        d.OpenedBy = CUser;
        d.OpenedDate = DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        d.DueDate = DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        d.Comment = "[kommentar]";
        d.Save();
    }
    public String GetNetworkByContact(String Contact)
    {
        if (Contact.Equals("0") || Contact.Equals(String.Empty))
            return "Saknas";
        return new RXServer.Modules.Crm.Contacts.Contact(Convert.ToInt32(Contact)).Network.Name;
    }
    #endregion
    #region Network
    #endregion
    #region Login
    public Boolean CheckUser(string username, string pass)
    {
        String function_name = "CheckUser";
        try
        {
            if (RXServer.Auth.Users.UserNameExist(username))
            {
                Int32 uId = RXServer.Auth.Users.GetUserId(username);
                RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(uId);
                if (u.Password == pass)
                {
                    if (u.Status == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, function_name, String.Empty);
            return false;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (CheckUser(txtUser.Text, txtPass.Text))
            RXServer.Auth.LogIn(txtUser.Text, txtPass.Text);
        ClientScript.RegisterStartupScript(this.GetType(), "winclose1", "window.parent.location = window.parent.location.href;", true);

    }
    //protected void lnkLogOut_Click(object sender, EventArgs e)
    //{
    //    RXServer.Auth.LogOut();
    //    ClientScript.RegisterStartupScript(this.GetType(), "winclose2", "window.parent.location = window.parent.location.href;", true);
    //}
    #endregion

    public DropDownList GetAllaBolag(String var)
    {
        // hämta och parsa från allabolag...
        return new DropDownList();
    }

}