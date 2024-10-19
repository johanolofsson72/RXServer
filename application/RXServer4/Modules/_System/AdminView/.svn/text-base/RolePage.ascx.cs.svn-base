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

public partial class Modules__System_AdminView_RolePage : System.Web.UI.UserControl
{
    String class_name = "Modules__System_AdminView_RolePage";
    String ErrorList = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            ErrorList = "";
            this.ErrorBox.Visible = false;
            HideErrors();

            if (RXServer.Web.RequestValues.Page == "Roles")
            {

                this.RolePage_1.Visible = false;

                this.RoleSubMenu.Visible = true;
                BindRolesSubMenuData();
                BindRolesSubMenuData2();

                switch (RXServer.Web.RequestValues.SubPage)
                {
                    case "ViewUser":
                        this.RolePage_4.Visible = true;
                        break;

                    case "Add":
                        this.RolePage_3.Visible = true;
                        break;

                    case "Edit":
                        this.RolePage_2.Visible = true;
                        if (!Page.IsPostBack)
                        {
                            BindEditRoleData(RXServer.Web.RequestValues.ViewId.ToString());
                        }
                        break;

                    default:

                        this.RolePage_1.Visible = true;
                        if (RXServer.Web.RequestValues.DelId != "")
                        {
                            if (Request["remove"] != null)
                            {
                                if (Request["remove"] == "all")
                                {
                                    RemoveUsers(RXServer.Web.RequestValues.DelId);
                                }
                                else
                                {
                                    DeleteRole(RXServer.Web.RequestValues.DelId);
                                }
                            }
                            else
                            {
                                DeleteRole(RXServer.Web.RequestValues.DelId);
                            }

                        }
                        else
                        {
                            BindRolesData();
                        }
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

    public void BindRolesData()
    {
        String function_name = "BindRolesData";
        try
        {
            ContentPlaceHolder cph = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
            Literal help = cph.FindControl("ltrHelpText") as Literal;
            help.Text = RXMali.GetXMLHelpNode("ContentManager/Roles/Text");

            RXServer.Auth.Roles r = new RXServer.Auth.Roles();
            String list = "";

            list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

            if (r.Count > 0)
            {
                list += "<tr style='background-color: #666666' class='Text11_white'>";
                list += "<td valign='top'>Id</td>";
                list += "<td valign='top'>Title</td>";
                list += "<td valign='top'>Users</td>";
                list += "<td valign='top'>Space</td>";
                list += "<td valign='top'>Created</td>";
                //list += "<td valign='top'>Modules Rights</td>";
                //list += "<td valign='top'>Pages Rights</td>";
                list += "<td valign='top'>Delete</td>";
                list += "<td valign='top'>Edit</td>";
                list += "</tr>";

                Int32 counter = 0;

                foreach (LiquidCore.Roles.Role role in r)
                {
                    if ((counter % 2) == 0)
                    {
                        list += "<tr style='background-color: white;'  class='Text11_gray'>";
                    }
                    else
                    {
                        list += "<tr style='background-color: #EFEFEF;'  class='Text11_gray'>";
                    }
                    list += "<td valign='top'>" + role.Id.ToString() + "</td>";
                    list += "<td valign='top'>" + role.Title + "</td>";
                    list += "<td valign='top'><a href='AdminView_Admin.aspx?Page=Users&RolId=" + role.Id.ToString() + "'>" + RXServer.Auth.Users.GetTotalRoleUsers(role.Id) + "</a></td>";
                    list += "<td valign='top'>" + GetRoleDirectorySize(role.Id) + "</td>";
                    list += "<td valign='top'>" + role.CreatedDate.ToShortDateString() + "</td>";
                    //list += "<td valign='top'>TotalModRights(" + role.Id + ")</td>";
                    //list += "<td valign='top'>TotalPageRights(" + role.Id + ")</td>";
                    if (RXServer.Auth.Users.GetTotalRoleUsers(role.Id) > 0)
                    {
						list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + role.Id.ToString() + "&remove=all' onclick=\"return confirm('WARNING! This will delete all the users belonging to this role( " + role.Title + " ). Are you sure you want to do this?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_empty.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + role.Id.ToString() + "&remove=all' onclick=\"return confirm('WARNING! This will delete all the users belonging to this role( " + role.Title + " ). Are you sure you want to do this?')\">Empty</a></td></tr></table></td>";
                    }
                    else
                    {
                        list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + role.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to delete this role( " + role.Title + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + role.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to delete this role( " + role.Title + " )?')\">Delete</a></td></tr></table></td>";
                    }
                    list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&SubPage=Edit&ViewId=" + role.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_edit.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&SubPage=Edit&ViewId=" + role.Id.ToString() + "'>&nbsp;Edit</a></td></tr></table></td></td>";
                    list += "</tr>";

                    counter++;
                }
            }
            else
            {
                list += "<tr><td class='Text11_gray'>No Records was found.</td></tr>";
            }

            list += "</table>";

            this.ltrRoleList.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindRolesSubMenuData()
    {
        String function_name = "BindRolesSubMenuData";
        try
        {
            String list = "";

            this.ltrRoleSubMenuList.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindRolesSubMenuData2()
    {
        String function_name = "BindRolesSubMenuData2";
        try
        {
            String list = "";
            list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
            list += "<tr>";
            list += "<td style='width:10px;'><td><img src='../../../App_Themes/WebAdmin/Images/submenu_divider.gif' class='img_noborder' /></td><td style='width:10px;'>";
            if (RXServer.Web.RequestValues.SubPage == "Add")
            {
                list += "<td style='height:34px;'><a href='AdminView_Admin.aspx?Page=Roles&SubPage=Add'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='AdminView_Admin.aspx?Page=Roles&SubPage=Add' class='submenu_on'>Add Role</a></td>";
            }
            else
            {
                list += "<td style='height:34px;'><a href='AdminView_Admin.aspx?Page=Roles&SubPage=Add'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='AdminView_Admin.aspx?Page=Roles&SubPage=Add' class='submenu_off'>Add Role</a></td>";
            }
            list += "<td style='width:20px; height:34px;'></td>";
            list += "</tr>";
            list += "</table>";


            this.ltrRoleSubMenuList2.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindEditRoleData(string roleId)
    {
        String function_name = "BindEditRoleData";
        try
        {
            Int32 rId = 0;
            Int32.TryParse(roleId, out rId);
            if (rId > 0)
            {
                RXServer.Auth.Roles.Role r = new RXServer.Auth.Roles.Role(rId);
                this.txtEditRoleName.Text = r.Title;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private Boolean AddRole(string rolename, string foldername)
    {
        String function_name = "AddRole";
        try
        {
            if (ValidateRole(rolename, foldername))
            {
                Int32 rId = 0;

                rId = RXServer.Auth.Roles.CreateRole(rolename);

                RXServer.Auth.Roles.Role r = new RXServer.Auth.Roles.Role(rId);
                r.Alias = "System";
                r.Description = foldername;
                r.Save();
                
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    private Boolean EditRole(string rolename, string foldername, Int32 roleId)
    {
        String function_name = "EditRole";
        try
        {
            RXServer.Auth.Roles.Role r = new RXServer.Auth.Roles.Role(roleId);

            if (r.Title != rolename)
            {
                if (!RXServer.Auth.Roles.RoleNameExist(rolename))
                {
                    r.Title = rolename;
                    r.Description = foldername;
                    r.Save();

                    return true;
                }
                else
                {
                    ErrorList += "- Role already exists!<br />";
                    return false;
                }
            }
            else if(r.Title == rolename)
            {
                r.Description = foldername;
                r.Save();

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    public Boolean DeleteRole(string roleId)
    {
        String function_name = "DeleteRole";
        try
        {
            Int32 rId = 0;
            Int32.TryParse(roleId, out rId);

            RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(rId);
            string activeDir = Server.MapPath("~/Upload/Users/" + role.Description + "/");

            role.Delete();

            string Url = "";

            Url = RXMali.GetLastUrl(Request.Url.ToString());
            Url = Url.Replace("&DelId=" + rId, "");

            this.Script.Text = "<script language='javascript'>viewMessage('Role deleted!');</script>";

            RXServer.Web.Redirect.To(Url);

            return true;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    public Boolean RemoveUsers(string roleId)
    {
        String function_name = "RemoveUsers";
        try
        {
            Int32 rId = 0;
            Int32.TryParse(roleId, out rId);

            RXServer.Auth.Users u = new RXServer.Auth.Users(rId);

            if (u.Count > 0)
            {
                foreach (LiquidCore.Users.User us in u)
                {
                    if (us.Id != RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name))
                    {
                        us.DeleteFromRole(rId);
						us.Delete();
                    }
                }
                String Url = "";
                Url = RXMali.GetLastUrl(Request.Url.ToString());
                Url = Url.Replace("&DelId=" + rId + "&remove=all", "");

                this.Script.Text = "<script language='javascript'>viewMessage('Users removed from Role!');</script>";

                RXServer.Web.Redirect.To(Url);

                return true;

            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    private Boolean ValidateRole(string rolename, string foldername)
    {
        String function_name = "ValidateRole";
        try
        {
            Boolean valid = true;

            if (RXServer.Auth.Roles.RoleNameExist(rolename))
            {
                ErrorList += "- Role already exists!<br />";
                this.imgError3_1.Visible = true;
                valid = false;
            }
            if (rolename == "")
            {
                ErrorList += "- Please fill in a rolename!<br />";
                this.imgError3_1.Visible = true;
                valid = false;
            }

            return valid;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    protected void btnAddRole_Click(object sender, EventArgs e)
    {
        String function_name = "btnAddRole_Click";
        try
        {
            if (AddRole(this.txtRoleName.Text, this.txtRoleName.Text))
            {
                this.txtRoleName.Text = "";

                string Url = "";

                Url = RXMali.GetLastUrl(Request.Url.ToString());
                Url = Url.Replace("&SubPage=Add", "");

                this.Script.Text = "<script language='javascript'>viewMessage('Role created!');</script>";
               
                RXServer.Web.Redirect.To(Url);
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = ErrorList;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnEditRole_Click(object sender, EventArgs e)
    {
        String function_name = "btnEditRole_Click";
        try
        {
            Int32 roleId = 0;
            Int32.TryParse(RXServer.Web.RequestValues.ViewId.ToString(), out roleId);

            if (EditRole(this.txtEditRoleName.Text, this.txtEditRoleName.Text, roleId))
            {
                this.txtEditRoleName.Text = "";

                string Url = "";

                Url = RXMali.GetLastUrl(Request.Url.ToString());
                Url = Url.Replace("&SubPage=Edit&ViewId=" + RXServer.Web.RequestValues.ViewId, "");

                this.Script.Text = "<script language='javascript'>viewMessage('Role edited!');</script>";

                RXServer.Web.Redirect.To(Url);

            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = ErrorList;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public string GetRoleDirectorySize(Int32 RoleId)
    {
        String function_name = "GetRoleDirectorySize";
        try
        {
            RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(RoleId);
            string activeDir = Server.MapPath("~/Upload/Users/" + role.Description + "/");

            if (System.IO.Directory.Exists(activeDir))
            {
                DirectoryInfo d = new DirectoryInfo(activeDir);
                long size = RXMali.DirSize(d);
                double temp = size / 1024;

                return Math.Round(temp) + " kb";
            }
            else
            {
                return "0 kb";
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return "0 kb";
        }


    }

    public void HideErrors()
    {
        String function_name = "HideErrors";
        try
        {
            // Add Role
            this.imgError3_1.Visible = false;


            // Edit Role
            //this.imgError2_1.Visible = false;
            //this.imgError2_2.Visible = false;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
}
