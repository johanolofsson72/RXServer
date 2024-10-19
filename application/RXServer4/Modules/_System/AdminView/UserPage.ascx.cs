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

public partial class Modules__System_AdminView_UserPage : System.Web.UI.UserControl
{
    String class_name = "Modules__System_AdminView_UserPage";
    String ErrorList = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            ErrorList = "";
            this.ErrorBox.Visible = false;
            HideErrors();


            if (RXServer.Web.RequestValues.Page == "Users")
            {
                this.UserPage_1.Visible = false;
                this.UserPage_2.Visible = false;
                this.UserPage_3.Visible = false;
                this.UserSubMenu.Visible = true;
                if (!Page.IsPostBack)
                {
                    BindUserSubMenuData();
                }
                BindUserSubMenuData2();

                ContentPlaceHolder cph = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
                Literal help = cph.FindControl("ltrHelpText") as Literal;

                switch (RXServer.Web.RequestValues.SubPage)
                {
                    case "View":
                        this.UserPage_2.Visible = true;
                        help.Text = RXMali.GetXMLHelpNode("ContentManager/Users/Edit");

                        if (!Page.IsPostBack)
                        {
                            BindViewUserData();
                        }
                        break;

                    case "Add":
                        if (!Page.IsPostBack)
                        {
                            LoadRolesData();
                        }
                        help.Text = RXMali.GetXMLHelpNode("ContentManager/Users/Add");
                        this.UserPage_3.Visible = true;
                        break;

                    case "Edit":

                        break;

                    default:

                        this.UserPage_1.Visible = true;
                        if (RXServer.Web.RequestValues.DelId != "")
                        {
                            DeleteUser(RXServer.Web.RequestValues.DelId);
                        }
                        else
                        {

                            BindUserData();
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

    public void BindUserData()
    {
        String function_name = "BindUserData";
        try
        {
            ContentPlaceHolder cph = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
            Literal help = cph.FindControl("ltrHelpText") as Literal;
            help.Text = RXMali.GetXMLHelpNode("ContentManager/Users/List");

            Int32 rId = 0;

            Int32.TryParse(RXServer.Web.RequestValues.RolId.ToString(), out rId);
                     
            String list = "";
            
            String Url = "";
            Int32 limit = 10;
            Int32 total = 0;
            Int32 index = RXServer.Web.RequestValues.Index;
            Int32 page = (index / limit) + 1;
            Int32 pages = 0;

            Url = RXMali.GetLastUrl(Request.Url.ToString());


            // Hämtar Users baserat på RolId
            RXServer.Auth.Users u = new RXServer.Auth.Users(rId, LiquidCore.LiquidCore.Definition.UsersDefinition.SortParamEnum.Id, LiquidCore.LiquidCore.Definition.UsersDefinition.SortOrderEnum.Ascending, index, limit);

            total = RXServer.Auth.Users.GetTotalRoleUsers(rId);

            list += "<table cellspacing='0' cellpadding='5' style='width: 100%; border: solid 1px #CCCCCC;'>";

            if (u.Count > 0)
            {
                list += "<tr style='background-color: #666666' class='Text11_white'>";
                list += "<td valign='top'>Id</td>";
                list += "<td valign='top'>Username</td>";
                list += "<td valign='top'>Firstname</td>";
                list += "<td valign='top'>Lastname</td>";
				list += "<td valign='top'>User page</td>";
                list += "<td valign='top'>Space</td>";
                list += "<td valign='top'>Created</td>";
                list += "<td valign='top' align='center'>Status</td>";
                list += "<td valign='top'>Delete</td>";
                list += "<td valign='top'>Edit</td>";
                list += "</tr>";

                Int32 counter = 0;

                foreach (LiquidCore.Users.User us in u)
                {
                    if ((counter % 2) == 0)
                    {
                        list += "<tr style='background-color: white;'  class='Text11_gray'>";
                    }
                    else
                    {
                        list += "<tr style='background-color: #EFEFEF;'  class='Text11_gray'>";
                    }
                    list += "<td valign='top'><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&SubPage=View&ViewId=" + us.Id.ToString() + "' class='underline'>" + us.Id.ToString() + "</a></td>";
                    list += "<td valign='top'>" + us.LoginName + "</td>";
                    list += "<td valign='top'>" + us.FirstName + "</td>";
                    list += "<td valign='top'>" + us.LastName + "</td>";

					LiquidCore.Menu menu = new LiquidCore.Menu(us.Id.ToString());
					if (menu.Count > 0)
					{
						list += "<td valign='top'><a href='../../../Default.aspx?pagId=" + menu[0].Id + "' target='_parent'>Link</a></td>";
					}
					else
					{
						list += "<td valign='top'></td>";
					}
                    
					list += "<td valign='top'>" + GetUserDirectorySize(us.Id) + "</td>";
                    list += "<td valign='top'>" + us.CreatedDate.ToShortDateString() + "</td>";
                    if(us.Status == 1)
                    {
                        list += "<td valign='top' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_user_active.gif' title='Active' class='img_noborder' /></td>";
                    }
                    else
                    {
                        list += "<td valign='top' align='center'><img src='../../../App_Themes/WebAdmin/Images/icon_user_unactive.gif' title='Unactive' class='img_noborder' /></td>";
                    }
                    
                    list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + us.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this user( " + us.LoginName + " )?')\"><img src='../../../App_Themes/WebAdmin/Images/icon_bullet_delete.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&DelId=" + us.Id.ToString() + "' onclick=\"return confirm('Are you sure you want to remove this user( " + us.LoginName + " )?')\">Delete</a></td></tr></table></td>";
                    list += "<td valign='top'><table cellpadding='0' cellspacing='0'><tr><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&SubPage=View&ViewId=" + us.Id.ToString() + "'><img src='../../../App_Themes/WebAdmin/Images/icon_edit.gif' class='img_noborder' /></a></td><td><a href='" + RXMali.GetLastUrl(Request.Url.ToString()) + "&SubPage=View&ViewId=" + us.Id.ToString() + "'>&nbsp;Edit</a></td></tr></table></td>";
                    
                    list += "</tr>";
                    counter++;
                }
            }
            else
            {
                list += "<tr><td class='Text11_gray'>No Records was found.</td></tr>";
            }

            list += "</table>";

            #region Paging

            if (total > 0)
            {
                double t1, t2;
                t1 = total;
                t2 = limit;
                pages = (int)Math.Ceiling(t1 / t2);
                Url = Url.Replace("&Index=" + index, "");

                if (RXServer.Web.RequestValues.PagId > 0)
                {
                    Url = Url + "&PagId=" + RXServer.Web.RequestValues.PagId;
                }

                list += "<table cellspacing='0' cellpadding='0' style='width: 100%;'><tr>";
                list += "<td colspan='10' style='text-align: right' class='Text11_gray'><div style='position:relative; padding: 0px; margin: 0px; float: right'><table cellspacing='0' cellpadding='5'><tr>";
                list += "<td>Page " + page + "  of " + pages + "</td>";
                
                if (page > 1)
                {
                    list += "<td style='width:5px;'><a href='" + Url + "&Index=" + (index - limit) + "' class='paging_on'>«</a></td>";
                }
                else
                {
                    list += "<td style='width:5px;'>&nbsp;</td>";
                }

                if ((page) > 3)
                {
                    list += "<td><a href='" + Url + "&Index=" + 0 + "' class='paging_on'>1</a></td><td>...</td>";
                }

                for (int i = 0; i < pages; i++)
                {
                    if (i < page + 2 && i > (page - 4))
                    {
                        Int32 ix = i * limit;
                        if ((i + 1) == page)
                        {
                            list += "<td style='background-color: #CCCCCC;'>" + (i + 1) + "</td>";
                        }
                        else
                        {
                            list += "<td><a href='" + Url + "&Index=" + ix + "' class='paging_on'>" + (i + 1) + "</a></td>";
                        }
                    }
                }
                if ((page + 2) < pages)
                {
                    Int32 ix = (pages-1) * limit;
                    list += "<td>...</td><td><a href='" + Url + "&Index=" + ix + "' class='paging_on'>" + (pages) + "</a></td>";
                }


                if (page < pages)
                {
                    list += "<td style='width:5px;'><a href='" + Url + "&Index=" + (index + limit) + "' class='paging_on'>»</a></td>";
                }
                else
                {
                    list += "<td style='width:5px;'>&nbsp;</td>";
                }

                list += "<tr></table></div></td></tr></table>";
            }

            #endregion

            this.ltrUserList.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindViewUserData()
    {
        String function_name = "BindViewUserData";
        try
        {
            Int32 userId, RolId = 0;

            Int32.TryParse(RXServer.Web.RequestValues.ViewId.ToString(), out userId);

            // Hämtar Users baserat på RolId
            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(userId);
            this.txtUsrAddress.Text = u.Address;
            this.txtUsrCity.Text = u.City;
            this.txtUsrCO.Text = u.CO;
            this.txtUsrCountry.Text = u.Country;
            this.txtUsrFax.Text = u.Fax;
            this.txtUsrFirstName.Text = u.FirstName;
            this.txtUsrLastName.Text = u.LastName;
            this.txtUsrMail.Text = u.Mail;
            this.txtUsrMiddleName.Text = u.MiddleName;
            this.txtUsrMobile.Text = u.Mobile;
            this.txtUsrPhone.Text = u.Phone;
            this.txtUsrPostalCode.Text = u.PostalCode;
            this.txtUsrUsername.Text = u.UserName;

            ArrayList roles = new ArrayList();
            roles = u.GetRoles();
            Int32.TryParse(roles[0].ToString(), out RolId);

            foreach (LiquidCore.Roles.Role r in new LiquidCore.Roles())
            {
                this.ddlUsrRoles.Items.Add(new ListItem(r.Title, r.Id.ToString()));
                if (RolId == r.Id)
                {
                    this.ddlUsrRoles.SelectedValue = r.Id.ToString();
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

    public void BindUserSubMenuData()
    {
        String function_name = "BindUserSubMenuData";
        try
        {
            this.ddlUserRoles.Items.Add(new ListItem("All Users", "0"));

            foreach (LiquidCore.Roles.Role r in new LiquidCore.Roles())
            {
                if (r.Id > 0)
                {   
                    this.ddlUserRoles.Items.Add(new ListItem(r.Title, r.Id.ToString()));
                    if (RXServer.Web.RequestValues.RolId == r.Id.ToString())
                    {
                        this.ddlUserRoles.SelectedValue = r.Id.ToString();
                    }
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

    public void BindUserSubMenuData2()
    {
        String function_name = "BindUserSubMenuData2";
        try
        {
            String list = "";

            list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
            list += "<tr>";
            list += "<td style='width:10px;'><td><img src='../../../App_Themes/WebAdmin/Images/submenu_divider.gif' class='img_noborder' /></td><td style='width:10px;'>";
            if (RXServer.Web.RequestValues.SubPage == "Add")
            {
                list += "<td><a href='AdminView_Admin.aspx?Page=Users&SubPage=Add'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='AdminView_Admin.aspx?Page=Users&SubPage=Add' class='submenu_on'>Add User</a></td>";
            }
            else
            {
                list += "<td><a href='AdminView_Admin.aspx?Page=Users&SubPage=Add'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='AdminView_Admin.aspx?Page=Users&SubPage=Add' class='submenu_off'>Add User</a></td>";
            }
            list += "<td style='width:20px; height:34px;'></td>";
            list += "</tr>";
            list += "</table>";


            this.ltrUserSubMenuList2.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    public Boolean DeleteUser(string uId)
    {
        String function_name = "DeleteUser";
        try
        {
            Int32 UserId = 0;
            Int32.TryParse(uId, out UserId);
            if (UserId != RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name))
            {
                Int32 RolId = 0;

                RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(UserId);
                ArrayList roles = new ArrayList();

                if(u.StartPage > 0)
                {
                    RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(u.StartPage);
                    mItem.Delete();
                }
                
                roles = u.GetRoles();

                RXServer.Auth.Users.DeleteUser(UserId);

                Int32.TryParse(roles[0].ToString(),out RolId);

                // Rensa alla hans filer

                if (RolId > 0)
                {
                    RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(RolId);
                    string activeDir = Server.MapPath("~/Upload/Users/" + role.Description + "/" + UserId + "/");

                    if (System.IO.Directory.Exists(activeDir))
                    {
                        foreach (string sFile in System.IO.Directory.GetFiles(activeDir))
                        {
                            do
                            {
                                try
                                {
                                    System.IO.File.Delete(sFile);
                                }
                                catch
                                {
                                }

                            } while (System.IO.File.Exists(sFile));
                            
                        }                       
                    }

                }

                string Url = "";

                Url = RXMali.GetLastUrl(Request.Url.ToString());
                Url = Url.Replace("&DelId=" + UserId, "");

                RXServer.Web.Redirect.To(Url);

                return true;
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = " - You cant delete yourself!";
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

    public string GetUserDirectorySize(Int32 UserId)
    {
        String function_name = "GetUserDirectorySize";
        try
        {
            Int32 RolId = 0;

            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(UserId);
            ArrayList roles = new ArrayList();

            roles = u.GetRoles();

            Int32.TryParse(roles[0].ToString(), out RolId);

            RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(RolId);
            string activeDir = Server.MapPath("~/Upload/Users/" + role.Description + "/" + UserId + "/");

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

    private void LoadRolesData()
    {
        String function_name = "LoadRolesData";
        try
        {
            this.ddlRoles.Items.Add(new ListItem("Choose Role", "0"));

            foreach (LiquidCore.Roles.Role r in new LiquidCore.Roles())
            {
                if (r.Id > 0)
                {
                    this.ddlRoles.Items.Add(new ListItem(r.Title, r.Id.ToString()));
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

    private Boolean AddUser(string user, string pw1, string pw2, string mail, string roleId)
    {
        String function_name = "AddUser";
        try
        {
            if (ValidateUser(user, pw1, pw2, mail, roleId))
            {
                Int32 uId, rId, userPage = 0;
                Int32.TryParse(roleId, out rId);

                uId = RXServer.Auth.Users.CreateUser(user, mail, "User", pw1, rId);
                if (uId > 0)
                {
					RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item();
					mItem.SitId = 1;
					mItem.Language = 1;
					mItem.Status = 3;
					mItem.ParentId = 0;
					mItem.Template = "Template1.master";
					mItem.Title = Server.HtmlEncode("User page (" + user + ")").Replace("'", "`");
					mItem.Alias = uId.ToString();
					mItem.ModelId = 1;
					mItem.Hidden = false;
					mItem.Save();
 
                    CreateUserFolder(rId, uId);
 
                    return true;
                }

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
    private Boolean EditUser(string userId)
    {
        String function_name = "EditUser";
        try
        {
            Int32 uId, rId = 0;
            Int32.TryParse(userId, out uId);

            if (uId > 0)
            {

                Boolean valid = true;

                RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(uId);

                if (u.LoginName != this.txtUsrUsername.Text)
                {
                    if(!RXServer.Auth.Users.UserNameExist(this.txtUsrUsername.Text))
                    {
                        u.LoginName = this.txtUsrUsername.Text;
                    }
                    else
                    {
                        ErrorList += " - Username already exists!<br />";
                        valid = false;
                    }                    
                }               
                if (u.Mail != this.txtUsrMail.Text)
                {
                    if(!RXServer.Auth.Users.UserEmailExist(this.txtUsrMail.Text))
                    {
                        u.Mail = this.txtUsrMail.Text;
                    }
                    else
                    {
                        ErrorList += " - Email already exists!<br />";
                        valid = false;
                    }                    
                }
                

                ArrayList roles = new ArrayList();
                roles = u.GetRoles();

                if (roles[0].ToString() != this.ddlUsrRoles.SelectedValue)
                {
                    Int32.TryParse(roles[0].ToString(), out rId);
                    u.DeleteFromRole(rId);

                    Int32.TryParse(this.ddlUsrRoles.SelectedValue, out rId);
                    u.AddToRole(rId);
                }                                

                u.Address = this.txtUsrAddress.Text;
                u.City = this.txtUsrCity.Text;
                u.CO = this.txtUsrCO.Text;
                u.Country = this.txtUsrCountry.Text;
                u.Fax = this.txtUsrFax.Text;
                u.FirstName = this.txtUsrFirstName.Text;
                u.LastName = this.txtUsrLastName.Text;
                u.MiddleName = this.txtUsrMiddleName.Text;
                u.Mobile = this.txtUsrMobile.Text;
                u.Phone = this.txtUsrPhone.Text;
                u.PostalCode = this.txtUsrPostalCode.Text;

                u.Save();
                return valid;
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

    private Boolean ValidateUser(string username, string pw1, string pw2, string mail, string roleId)
    {
        String function_name = "ValidateUser";
        try
        {
            Boolean valid = true;
           
            if (!RXMali.IsEmail(mail))
            {
                ErrorList += " - Invalid Email<br />";
                this.imgError3_2.Visible = true;
                valid = false;
            }

            if (username == "")
            {
                ErrorList += " - You need to fill in a username<br />";
                this.imgError3_3.Visible = true;
                valid = false;
            }

            if (pw1 != pw2 || pw1 == "" || pw2 == "")
            {
                ErrorList += " - Your passwords doesnt match<br />";
                this.imgError3_4a.Visible = true;
                this.imgError3_4b.Visible = true;
                valid = false;
            }
            if (RXServer.Auth.Users.UserNameExist(username))
            {
                ErrorList += " - Username already exists<br />";
                this.imgError3_3.Visible = true;
                valid = false;
            }
            if (RXServer.Auth.Users.UserEmailExist(mail))
            {
                ErrorList += " - Email already exists<br />";
                this.imgError3_2.Visible = true;
                valid = false;
            }
            if (this.ddlRoles.SelectedItem.Value == "0")
            {
                ErrorList += " - Please select a Role<br />";
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

    protected void btnEditUser_Click(object sender, EventArgs e)
    {
        String function_name = "btnEditUser_Click";
        try
        {
            if (EditUser(RXServer.Web.RequestValues.ViewId))
            {

                string Url = "";

                Url = RXMali.GetLastUrl(Request.Url.ToString());
                Url = Url.Replace("&SubPage=View&ViewId=" + RXServer.Web.RequestValues.ViewId, "");

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
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        String function_name = "btnAddUser_Click";
        try
        {
            if (AddUser(this.txtUsername.Text, this.txtPassword.Text, this.txtPassword2.Text, this.txtEmail.Text, this.ddlRoles.SelectedItem.Value))
            {
                this.txtEmail.Text = "";
                this.txtPassword.Text = "";
                this.txtPassword2.Text = "";
                this.txtUsername.Text = "";

                string Url = "";

                Url = RXMali.GetLastUrl(Request.Url.ToString());
                Url = Url.Replace("&SubPage=Add", "&RolId=" + this.ddlRoles.SelectedItem.Value);

                RXServer.Web.Redirect.To(Url);

            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = ErrorList;
            }
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void CreateUserFolder(Int32 roleId, Int32 userId)
    {
        String function_name = "CreateUserFolder";
        try
        {
            RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(roleId);

            string activeDir = Server.MapPath("~/Upload/Users/" + role.Description + "/");
            string newPath = System.IO.Path.Combine(activeDir, userId.ToString());

            System.IO.Directory.CreateDirectory(newPath);

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
            this.imgError3_1.Visible = false;
            this.imgError3_2.Visible = false;
            this.imgError3_3.Visible = false;
            this.imgError3_4a.Visible = false;
            this.imgError3_4b.Visible = false;

            // Edit User
            this.imgError2_1.Visible = false;
            this.imgError2_2.Visible = false;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
    protected void ddlUserRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlUserRoles_SelectedIndexChanged";
        try
        {
            RXServer.Web.Redirect.To("AdminView_Admin.aspx?Page=Users&RolId=" + this.ddlUserRoles.SelectedItem.Value);
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}


