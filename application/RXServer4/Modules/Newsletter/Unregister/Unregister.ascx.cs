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

public partial class Modules_Newsletter_Unregister_Unregister : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Newsletter_Unregister_Unregister";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.Unregister_admin.Visible = true;
                this.img_AdminEdit.OnClientClick = "javascript:showAdminUnregister(1," + this.PagId + "," + this.ModId + "); return false;";
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
            this.lblTitle.Text = Server.HtmlDecode(sm.Text1);
            this.lblText.Text = Server.HtmlDecode(sm.Text4);
            this.lbnRemove.Text = RXMali.GetXMLNode("Modules/UnregisterMail/button");

            if (RXServer.Web.RequestValues.v1 == "")
            {
                this.txtMail.Text = RXMali.GetXMLNode("Common/youremail");
                this.txtMail.Attributes.Add("onclick", "this.value='';");
            }
            else
            {
                this.txtMail.Text = RXServer.Web.RequestValues.v1;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void lbnRemove_Click(object sender, EventArgs e)
    {
        String function_name = "bindData";
        try
        {
            Boolean valid = true;
            String Errors = "";
            this.lblError.Visible = false;
            this.lblSuccess.Visible = false;
            this.rptGroups.Visible = false;

            if (!RXMali.IsEmail(this.txtMail.Text))
            {
                valid = false;
                Errors += " - " + RXMali.GetXMLNode("Error/email") + "<br/>";
            }

            if (GetMailListsByMail(this.txtMail.Text) < 1)
            {
                valid = false;
                Errors += " - " + RXMali.GetXMLNode("Modules/UnregisterMail/Error/mail_dont_exists") + "<br/>";
            }

            if (valid)
            {

                if (GetMailListsByMail(this.txtMail.Text) == 1)
                {
                    RemoveMail(this.txtMail.Text, "0");
                }
                else
                {
                    this.rptGroups.Visible = true;
                    BindGroupList(this.txtMail.Text);
                }
            }
            else
            {
                this.lblError.Visible = true;
                this.lblError.Text = Errors;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    private Int32 GetMailListsByMail(string mail)
    {
        String function_name = "GetMailListsByMail";
        try
        {
            String sql = "SELECT obd_id ";
            sql += "FROM obd_objectdata ";
            sql += "WHERE obd_alias LIKE 'MailItem%' ";
            sql += "AND obd_varchar25 = '" + mail + "' ";
            sql += "AND obd_deleted = 0 ";

            DataSet dataSet = new DataSet("dataSet");
            dataSet = RXServer.Data.Direct.GetDataSet(sql);

            if (dataSet.Tables.Count > 0)
            {
                return dataSet.Tables[0].Rows.Count;
            }

            return 0;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return 0;
        }
    }
    private void RemoveMail(string mail, string id)
    {
        String function_name = "RemoveMail";
        try
        {
            String groupname = "";
            String info = "";
            this.lblSuccess.Visible = true;

            if (id == "0")
            {
                String sql = "SELECT t1.obd_varchar25 AS groupname, t2.obd_id AS id ";
                sql += "FROM obd_objectdata AS t1, obd_objectdata AS t2 ";
                sql += "WHERE t1.obd_alias LIKE 'MailGroup' ";
                sql += "AND t2.obd_varchar25 = '" + mail + "' ";
                sql += "AND t2.obd_varchar26 = t1.obd_id ";
                sql += "AND t1.obd_deleted = 0 ";
                sql += "AND t2.obd_deleted = 0 ";

                DataSet dataSet = new DataSet("dataSet");
                dataSet = RXServer.Data.Direct.GetDataSet(sql);

                if (dataSet.Tables.Count > 0)
                {
                    DataTable myDataTable = dataSet.Tables[0];
                    foreach (DataRow dRow in myDataTable.Rows)
                    {
                        groupname = dRow["groupname"].ToString();
                        Int32 delId = 0;
                        Int32.TryParse(dRow["id"].ToString(), out delId);
                        RXServer.Modules.Base.List.Item m = new LiquidCore.List.Item(delId);
                        m.Delete();

                        info = " - " + this.txtMail.Text + " " + RXMali.GetXMLNode("Modules/UnregisterMail/Success/removed") + " " + groupname + " <br/>";
                    }
                }
            }
            else
            {
                String sql = "SELECT t1.obd_varchar25 AS groupname, t2.obd_id AS id ";
                sql += "FROM obd_objectdata AS t1, obd_objectdata AS t2 ";
                sql += "WHERE t1.obd_alias LIKE 'MailGroup' ";
                sql += "AND t2.obd_varchar25 = '" + mail + "' ";
                sql += "AND t2.obd_id = " + id + " "; 
                sql += "AND t2.obd_varchar26 = t1.obd_id ";
                sql += "AND t1.obd_deleted = 0 ";
                sql += "AND t2.obd_deleted = 0 ";

                DataSet dataSet = new DataSet("dataSet");
                dataSet = RXServer.Data.Direct.GetDataSet(sql);

                if (dataSet.Tables.Count > 0)
                {
                    DataTable myDataTable = dataSet.Tables[0];
                    foreach (DataRow dRow in myDataTable.Rows)
                    {
                        groupname = dRow["groupname"].ToString();
                        Int32 delId = 0;
                        Int32.TryParse(dRow["id"].ToString(), out delId);
                        RXServer.Modules.Base.List.Item m = new LiquidCore.List.Item(delId);
                        m.Delete();

                        info = " - " + this.txtMail.Text + " " + RXMali.GetXMLNode("Modules/UnregisterMail/Success/removed") + " " + groupname + " <br/>";
                    }
                }
            }

            this.lblSuccess.Text = info;
            BindGroupList(this.txtMail.Text);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void lbnGroup_Command(object sender, EventArgs e)
    {
        String function_name = "lbnGroup_Command";
        try
        {
            string id = ((LinkButton)sender).CommandArgument.ToString();
            RemoveMail(this.txtMail.Text, id);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindGroupList(String mail)
    {
        String function_name = "BindGroupList";
        try
        {

            String sql = "SELECT t1.obd_varchar25 AS groupname, t2.obd_id AS id ";
            sql += "FROM obd_objectdata AS t1, obd_objectdata AS t2 ";
            sql += "WHERE t1.obd_alias LIKE 'MailGroup' ";
            sql += "AND t2.obd_varchar25 = '" + mail + "' ";
            sql += "AND t2.obd_varchar26 = t1.obd_id ";
            sql += "AND t1.obd_deleted = 0 ";
            sql += "AND t2.obd_deleted = 0 ";

            DataSet dataSet = new DataSet("dataSet");
            dataSet = RXServer.Data.Direct.GetDataSet(sql);

            if (dataSet.Tables.Count > 0)
            {
                DataTable myDataTable = dataSet.Tables[0];
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    this.rptGroups.Visible = true;
                    this.rptGroups.DataSource = myDataTable;
                    this.rptGroups.DataBind();
                }
                else
                {
                    this.rptGroups.Visible = false;
                }
            }


        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void rptGroups_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        String function_name = "rptGroups_ItemCommand";
        try
        {

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }        
    }
}
