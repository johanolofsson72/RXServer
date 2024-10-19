using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Text;
using iConsulting.iCDataHandler; 

namespace RXServer
{
    public static class Authentication
    {
        static string CLASSNAME = "[Namespace::RXServer][Class::Authentication]";
        public static Boolean IsAuthenticated
        {
            get
            { 
                Boolean IsAuthenticated = false;
                if (HttpContext.Current.Session["RXServer.Authentication.IsAuthenticated"] != null)
                    Boolean.TryParse(HttpContext.Current.Session["RXServer.Authentication.IsAuthenticated"].ToString(), out IsAuthenticated);
                return IsAuthenticated;
            }
            set
            {
                HttpContext.Current.Session["RXServer.Authentication.IsAuthenticated"] = value;
            }
        }

        /// <summary>
        /// Only use this for Bayer website.
        /// </summary>
        public static void SignIn(String Email, String Password, String Role, Int32 Group)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SignIn]";
            try
            {
                RXServer.Authentication.User.Identity.Name = Email;
                RXServer.Authentication.User.Identity.Password = Password;
                RXServer.Authentication.User.Identity.Role = Role;
                RXServer.Authentication.User.Identity.Group = Group;
                RXServer.Authentication.User.Identity.Profile.NickName = String.Empty;
                RXServer.Authentication.User.Identity.Profile.Presentation = String.Empty;
                RXServer.Authentication.User.Identity.Profile.Signature = String.Empty;
                RXServer.Authentication.IsAuthenticated = true;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        /// <summary>
        /// Only use this for Bayer website.
        /// </summary>
        public static void SignInAndRedirect(String Email, String Password, String Role, Int32 Group, String Redirect)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SignInAndRedirect]";
            try
            {
                SignIn(Email, Password, Role, Group);
                if (RXServer.Authentication.IsAuthenticated)
                    HttpContext.Current.Response.Redirect(Redirect, false);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="Role"></param>
        /// <param name="Group"></param>
        /// <param name="Redirect"></param>
        public static void SignInAndRedirectFromSSL(String Email, String Password, String Role, Int32 Group, String Redirect)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SignInAndRedirectFromSSL]";
            try
            {
                SignIn(Email, Password, Role, Group);
                if (RXServer.Authentication.IsAuthenticated)
                {
                    HttpContext.Current.Session["INSSL"] = "0";
                    HttpContext.Current.Response.Redirect(Redirect, false);
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        public static void SignIn(String Email, String Password)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SignIn]"; 
            try
            {
                String Role = String.Empty;
                Int32 Group = 0;
                String NickName = String.Empty;
                String Signature = String.Empty;
                String Presentation = String.Empty;

                if (_SignIn(Email, Password, out Role, out Group, out NickName, out Signature, out Presentation))
                {
                    RXServer.Authentication.User.Identity.Name = Email;
                    RXServer.Authentication.User.Identity.Password = Password;
                    RXServer.Authentication.User.Identity.Role = Role;
                    RXServer.Authentication.User.Identity.Group = Group;
                    RXServer.Authentication.User.Identity.Profile.NickName = NickName;
                    RXServer.Authentication.User.Identity.Profile.Presentation = Signature;
                    RXServer.Authentication.User.Identity.Profile.Signature = Presentation;
                    RXServer.Authentication.IsAuthenticated = true;
                } 
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        public static void SignInAndRedirect(String Email, String Password, String Redirect)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SignInAndRedirect]";
            try
            {
                SignIn(Email, Password);
                if (RXServer.Authentication.IsAuthenticated)
                    HttpContext.Current.Response.Redirect(Redirect, false);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        private static Boolean _SignIn(String Email, String Password, out String Role, out Int32 Group, out String NickName, out String Signature, out String Presentation)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::_SignIn]";
            Boolean Valid = false;
            Role = String.Empty;
            Group = 0;
            NickName = String.Empty;
            Signature = String.Empty;
            Presentation = String.Empty;
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("SELECT usr_users.usr_id, ");
                sSQL.Append("ugr_usersgroups.grp_id, ");
                sSQL.Append("rol_roles.rol_alias, ");
                sSQL.Append("obd_objectdata.obd_varchar2, ");
                sSQL.Append("obd_objectdata.obd_varchar3, ");
                sSQL.Append("obd_objectdata.obd_varchar4 FROM usr_users ");
                sSQL.Append("JOIN ugr_usersgroups ON ugr_usersgroups.usr_id = usr_users.usr_id ");
                sSQL.Append("JOIN uro_usersroles ON uro_usersroles.usr_id = usr_users.usr_id ");
                sSQL.Append("JOIN rol_roles ON rol_roles.rol_id = uro_usersroles.rol_id ");
                sSQL.Append("JOIN obd_objectdata ON obd_objectdata.obd_varchar1 = usr_users.usr_id ");
                sSQL.Append("WHERE ");
                sSQL.Append("usr_users.usr_loginname = '" + Email + "' AND ");
                sSQL.Append("usr_users.usr_password = '" + RXServer.Security.Encrypt(Password) + "'");
                using (iCDataObject oDO = new iCDataObject(Data.DataSource, Data.ConnectionString, false, true))
                {
                    DataTable dt = oDO.GetDataTable(sSQL.ToString());
                    if (dt.Rows.Count > 0)
                    { 
                        // Data Values...
                        Data.Group = Convert.ToInt32(dt.Rows[0]["grp_id"].ToString());
                        Data.Login = Email;
                        Data.Password = RXServer.Security.Encrypt(Password);

                        // Auth Values...
                        Role = dt.Rows[0]["rol_alias"].ToString();
                        Group = Convert.ToInt32(dt.Rows[0]["grp_id"].ToString());
                        NickName = dt.Rows[0]["obd_varchar2"].ToString();
                        Signature = dt.Rows[0]["obd_varchar3"].ToString();
                        Presentation = dt.Rows[0]["obd_varchar4"].ToString();

                        Valid = true;
                    }
                }
                return Valid;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
                return false;
            }
        }

        public static void SignOut()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SignOut]";
            try
            {
                HttpContext.Current.Session.Abandon();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        public static class User
        {
            //static string CLASSNAME = "[Namespace::RXServer::Authentication][Class::User]";
            public static class Identity
            {
                //static string CLASSNAME = "[Namespace::RXServer::Authentication::User][Class::Identity]";
                public static String Name
                {
                    get
                    {
                        String Name = String.Empty;
                        if (HttpContext.Current.Session != null)
                            if (HttpContext.Current.Session["RXServer.Authentication.User.Identity.Name"] != null)
                                Name = HttpContext.Current.Session["RXServer.Authentication.User.Identity.Name"].ToString();
                        return Name;
                    }
                    set
                    {
                        HttpContext.Current.Session["RXServer.Authentication.User.Identity.Name"] = value;
                    }
                }
                public static String Password
                {
                    get
                    {
                        String Password = String.Empty;
                        if (HttpContext.Current.Session != null)
                            if (HttpContext.Current.Session["RXServer.Authentication.User.Identity.Password"] != null)
                                Password = HttpContext.Current.Session["RXServer.Authentication.User.Identity.Password"].ToString();
                        return Password;
                    }
                    set
                    {
                        HttpContext.Current.Session["RXServer.Authentication.User.Identity.Password"] = value;
                    }
                }
                public static String Role
                {
                    get
                    {
                        String Role = String.Empty;
                        if (HttpContext.Current.Session != null)
                            if (HttpContext.Current.Session["RXServer.Authentication.User.Identity.Role"] != null)
                                Role = HttpContext.Current.Session["RXServer.Authentication.User.Identity.Role"].ToString();
                        return Role;
                    }
                    set
                    {
                        HttpContext.Current.Session["RXServer.Authentication.User.Identity.Role"] = value;
                    }
                }
                public static Int32 Group
                {
                    get
                    {
                        Int32 Group = 0;
                        if (HttpContext.Current.Session != null)
                            if (HttpContext.Current.Session["RXServer.Authentication.User.Identity.Group"] != null)
                                Int32.TryParse(HttpContext.Current.Session["RXServer.Authentication.User.Identity.Group"].ToString(), out Group);
                        return Group;
                    }
                    set
                    {
                        HttpContext.Current.Session["RXServer.Authentication.User.Identity.Group"] = value;
                    }
                }

                public static class Profile
                {
                    //static string CLASSNAME = "[Namespace::RXServer::Authentication::User::Identity][Class::Profile]";
                    public static String NickName
                    {
                        get
                        {
                            String NickName = String.Empty;
                            if (HttpContext.Current.Session != null)
                                if (HttpContext.Current.Session["RXServer.Authentication.User.Identity.Profile.NickName"] != null)
                                    NickName = HttpContext.Current.Session["RXServer.Authentication.User.Identity.Profile.NickName"].ToString();
                            return NickName;
                        }
                        set
                        {
                            HttpContext.Current.Session["RXServer.Authentication.User.Identity.Profile.NickName"] = value;
                        }
                    }
                    public static String Presentation
                    {
                        get
                        {
                            String Presentation = String.Empty;
                            if (HttpContext.Current.Session != null)
                                if (HttpContext.Current.Session["RXServer.Authentication.User.Identity.Profile.Presentation"] != null)
                                    Presentation = HttpContext.Current.Session["RXServer.Authentication.User.Identity.Profile.Presentation"].ToString();
                            return Presentation;
                        }
                        set
                        {
                            HttpContext.Current.Session["RXServer.Authentication.User.Identity.Profile.Presentation"] = value;
                        }
                    }
                    public static String Signature
                    {
                        get
                        {
                            String Signature = String.Empty;
                            if (HttpContext.Current.Session != null)
                                if (HttpContext.Current.Session["RXServer.Authentication.User.Identity.Profile.Signature"] != null)
                                    Signature = HttpContext.Current.Session["RXServer.Authentication.User.Identity.Profile.Signature"].ToString();
                            return Signature;
                        }
                        set
                        {
                            HttpContext.Current.Session["RXServer.Authentication.User.Identity.Profile.Signature"] = value;
                        }
                    }
                }
            }
        }
    }
}


