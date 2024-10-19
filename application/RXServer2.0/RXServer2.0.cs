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
using iConsulting.iCDataHandler;
using System.Security.Cryptography;
using iConsulting;
using System.Text;
using System.IO;
using Telerik.WebControls.RadUploadUtils;
using Telerik.RadUploadUtils;
using Telerik.WebControls;
using System.Globalization;
using System.Xml;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Reflection;

namespace RXServer
{
    /// <summary>
    /// Classer enligt ny standard 
    /// Bindable, Sortable
    /// 2007-05-23
    /// </summary>
    #region public class Users
    public class Users : CollectionBase, IDisposable
    {
        static String CLASSNAME = "[Namespace::RXServer][Class::Users]";

        #region Private Variables
        private Int32 m_sit_id = 0;
        #endregion Private Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public Users()
        {
            GetAll();
        }
        public Users(Int32 SitId)
        {
            this.m_sit_id = SitId;
            GetAllBySitId();
        }
        ~Users()
        { xFinalize(); }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
        }
        #endregion Constructors

        #region Private Functions
        private int _Add(User user)
        {
            return List.Add(user);
        }
        private void GetAll()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_USER_COLLECTION + "::All";
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT usr_id FROM usr_users WHERE usr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    User u = new User(Convert.ToInt32(dr["usr_id"].ToString()));
                    this._Add(u);
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetAllBySitId()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAllBySitId]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_USER_COLLECTION + "::SitId" + m_sit_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT usr.usr_id FROM usr_users usr ");
                    sSQL.Append("JOIN uro_usersroles uro ON uro.usr_id = usr.usr_id ");
                    sSQL.Append("JOIN rol_roles rol ON rol.rol_id = uro.rol_id ");
                    sSQL.Append("JOIN asr_authorizedsitesroles asr ON asr.rol_id = rol.rol_id AND asr.sit_id = " + m_sit_id.ToString() + " ");
                    sSQL.Append("WHERE usr.usr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    User u = new User(Convert.ToInt32(dr["usr_id"].ToString()));
                    this._Add(u);
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        #endregion Private Functions

        #region Public Functions
        public static void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_USER_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_USER_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_USER_COLLECTION);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public int Add(User user)
        {
            user.Save();
            return List.Add(user);
        }
        public void Remove(User user)
        {
            user.Deleted = true;
            user.Update();
            List.Remove(user);
        }
        public User this[int index]
        {
            get
            {
                return ((User)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        #endregion Public Functions

        public class User : IDisposable
        {
            static String CLASSNAME = "[Namespace::RXServer.Users][Class::User]";

            #region Private Variables
            private Boolean     m_exists            = false;

            private Int32       m_usr_id            = 0;
            private Int32       m_sta_id            = 0;
            private Int32       m_lng_id            = 0;
            private Int32       m_ust_id            = 0;
            private Int32       m_usr_parentid      = 0;
            private Int32       m_usr_order         = 0;
            private String      m_usr_title         = String.Empty;
            private String      m_usr_alias         = String.Empty;
            private String      m_usr_description   = String.Empty;
            private String      m_usr_loginname     = String.Empty;
            private String      m_usr_password      = String.Empty;
            private String      m_usr_signature     = String.Empty;
            private String      m_usr_firstname     = String.Empty;
            private String      m_usr_lastname      = String.Empty;
            private String      m_usr_tag           = String.Empty;
            private String      m_usr_co            = String.Empty;
            private String      m_usr_address       = String.Empty;
            private String      m_usr_postalcode    = String.Empty;
            private String      m_usr_city          = String.Empty;
            private String      m_usr_country       = String.Empty;
            private String      m_usr_phone1        = String.Empty;
            private String      m_usr_phone2        = String.Empty;
            private String      m_usr_phone3        = String.Empty;
            private String      m_usr_fax           = String.Empty;
            private String      m_usr_mobile        = String.Empty;
            private String      m_usr_url1          = String.Empty;
            private String      m_usr_url2          = String.Empty;
            private String      m_usr_mail1         = String.Empty;
            private String      m_usr_mail2         = String.Empty;
            private String      m_usr_picturepath   = String.Empty;
            private String      m_usr_signaturepath = String.Empty;
            private DateTime    m_usr_createddate   = DateTime.Now;
            private String      m_usr_createdby     = String.Empty;
            private DateTime    m_usr_updateddate   = DateTime.Now;
            private String      m_usr_updatedby     = String.Empty;
            private Boolean     m_usr_hidden        = false;
            private Boolean     m_usr_deleted       = false;
            #endregion Private Variables

            #region Properties

            public Boolean Exist
            {
                get
                {
                    return this.m_exists;
                }
                set
                {
                    this.m_exists = value;
                }
            }
            public Int32 Id
            {
                get
                {
                    return this.m_usr_id;
                }
                set
                {
                    this.m_usr_id = value;
                }
            }
            public Int32 Status
            {
                get
                {
                    return this.m_sta_id;
                }
                set
                {
                    this.m_sta_id = value;
                }
            }
            public Int32 Language
            {
                get
                {
                    return this.m_lng_id;
                }
                set
                {
                    this.m_lng_id = value;
                }
            }
            public Int32 Type
            {
                get
                {
                    return this.m_ust_id;
                }
                set
                {
                    this.m_ust_id = value;
                }
            }
            public Int32 ParentId
            {
                get
                {
                    return this.m_usr_parentid;
                }
                set
                {
                    this.m_usr_parentid = value;
                }
            }
            public Int32 Order
            {
                get
                {
                    return this.m_usr_order;
                }
                set
                {
                    this.m_usr_order = value;
                }
            }
            public String Title
            {
                get
                {
                    return this.m_usr_title;
                }
                set
                {
                    this.m_usr_title = Common.SafeString(value);
                }
            }
            public String Alias
            {
                get
                {
                    return this.m_usr_alias;
                }
                set
                {
                    this.m_usr_alias = Common.SafeString(value);
                }
            }
            public String Description
            {
                get
                {
                    return this.m_usr_description;
                }
                set
                {
                    this.m_usr_description = Common.SafeString(value);
                }
            }
            public String LoginName
            {
                get
                {
                    return this.m_usr_loginname;
                }
                set
                {
                    this.m_usr_loginname = Common.SafeString(value);
                }
            }
            public String Password
            {
                get
                {
                    return this.m_usr_password;
                }
                set
                {
                    this.m_usr_password = Common.SafeString(value);
                }
            }
            public String Signature
            {
                get
                {
                    return this.m_usr_signature;
                }
                set
                {
                    this.m_usr_signature = Common.SafeString(value);
                }
            }
            public String FirstName
            {
                get
                {
                    return this.m_usr_firstname;
                }
                set
                {
                    this.m_usr_firstname = Common.SafeString(value);
                }
            }
            public String LastName
            {
                get
                {
                    return this.m_usr_lastname;
                }
                set
                {
                    this.m_usr_lastname = Common.SafeString(value);
                }
            }
            public String Tag
            {
                get
                {
                    return this.m_usr_tag;
                }
                set
                {
                    this.m_usr_tag = Common.SafeString(value);
                }
            }
            public String Co
            {
                get
                {
                    return this.m_usr_co;
                }
                set
                {
                    this.m_usr_co = Common.SafeString(value);
                }
            }
            public String Address
            {
                get
                {
                    return this.m_usr_address;
                }
                set
                {
                    this.m_usr_address = Common.SafeString(value);
                }
            }
            public String PostalCode
            {
                get
                {
                    return this.m_usr_postalcode;
                }
                set
                {
                    this.m_usr_postalcode = Common.SafeString(value);
                }
            }
            public String City
            {
                get
                {
                    return this.m_usr_city;
                }
                set
                {
                    this.m_usr_city = Common.SafeString(value);
                }
            }
            public String Country
            {
                get
                {
                    return this.m_usr_country;
                }
                set
                {
                    this.m_usr_country = Common.SafeString(value);
                }
            }
            public String Phone1
            {
                get
                {
                    return this.m_usr_phone1;
                }
                set
                {
                    this.m_usr_phone1 = Common.SafeString(value);
                }
            }
            public String Phone2
            {
                get
                {
                    return this.m_usr_phone2;
                }
                set
                {
                    this.m_usr_phone2 = Common.SafeString(value);
                }
            }
            public String Phone3
            {
                get
                {
                    return this.m_usr_phone3;
                }
                set
                {
                    this.m_usr_phone3 = Common.SafeString(value);
                }
            }
            public String Fax
            {
                get
                {
                    return this.m_usr_fax;
                }
                set
                {
                    this.m_usr_fax = Common.SafeString(value);
                }
            }
            public String Mobile
            {
                get
                {
                    return this.m_usr_mobile;
                }
                set
                {
                    this.m_usr_mobile = Common.SafeString(value);
                }
            }
            public String Url1
            {
                get
                {
                    return this.m_usr_url1;
                }
                set
                {
                    this.m_usr_url1 = Common.SafeString(value);
                }
            }
            public String Url2
            {
                get
                {
                    return this.m_usr_url2;
                }
                set
                {
                    this.m_usr_url2 = Common.SafeString(value);
                }
            }
            public String Mail1
            {
                get
                {
                    return this.m_usr_mail1;
                }
                set
                {
                    this.m_usr_mail1 = Common.SafeString(value);
                }
            }
            public String Mail2
            {
                get
                {
                    return this.m_usr_mail2;
                }
                set
                {
                    this.m_usr_mail2 = Common.SafeString(value);
                }
            }
            public String PicturePath
            {
                get
                {
                    return this.m_usr_picturepath;
                }
                set
                {
                    this.m_usr_picturepath = Common.SafeString(value);
                }
            }
            public String SignaturePath
            {
                get
                {
                    return this.m_usr_signaturepath;
                }
                set
                {
                    this.m_usr_signaturepath = Common.SafeString(value);
                }
            }
            public DateTime CreatedDate
            {
                get
                {
                    return this.m_usr_createddate;
                }
                set
                {
                    this.m_usr_createddate = value;
                }
            }
            public string CreatedBy
            {
                get
                {
                    return this.m_usr_createdby;
                }
                set
                {
                    this.m_usr_createdby = Common.SafeString(value);
                }
            }
            public DateTime UpdatedDate
            {
                get
                {
                    return this.m_usr_updateddate;
                }
                set
                {
                    this.m_usr_updateddate = value;
                }
            }
            public string UpdatedBy
            {
                get
                {
                    return this.m_usr_updatedby;
                }
                set
                {
                    this.m_usr_updatedby = Common.SafeString(value);
                }
            }
            public Boolean Hidden
            {
                get
                {
                    return this.m_usr_hidden;
                }
                set
                {
                    this.m_usr_hidden = value;
                }
            }
            public Boolean Deleted
            {
                get
                {
                    return this.m_usr_deleted;
                }
                set
                {
                    this.m_usr_deleted = value;
                }
            }

            #endregion Properties

            #region Constructors
            public User() { }
            public User(Int32 UsrId)
            {
                m_usr_id = UsrId;
                GetById();
            }
            ~User()
            { xFinalize(); }
            public void Dispose()
            {
                xFinalize();
                System.GC.SuppressFinalize(this);
            }
            private void xFinalize()
            {
            }
            #endregion Constructors

            #region Public Functions
            public virtual void Update()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
                try
                {
                    if (this.m_exists)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("UPDATE usr_users SET ");
                        sSQL.Append("sta_id = " + this.m_sta_id.ToString() + ", ");
                        sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                        sSQL.Append("ust_id = " + this.m_ust_id.ToString() + ", ");
                        sSQL.Append("usr_parentid = " + this.m_usr_parentid.ToString() + ", ");
                        sSQL.Append("usr_order = " + this.m_usr_order.ToString() + ", ");
                        sSQL.Append("usr_title = '" + this.m_usr_title.ToString() + "', ");
                        sSQL.Append("usr_alias = '" + this.m_usr_alias.ToString() + "', ");
                        sSQL.Append("usr_description = '" + this.m_usr_description.ToString() + "', ");
                        sSQL.Append("usr_loginname = '" + this.m_usr_loginname.ToString() + "', ");
                        sSQL.Append("usr_password = '" + this.m_usr_password.ToString() + "', ");
                        sSQL.Append("usr_signature = '" + this.m_usr_signature.ToString() + "', ");
                        sSQL.Append("usr_firstname = '" + this.m_usr_lastname.ToString() + "', ");
                        sSQL.Append("usr_tag = '" + this.m_usr_tag.ToString() + "', ");
                        sSQL.Append("usr_co = '" + this.m_usr_co.ToString() + "', ");
                        sSQL.Append("usr_address = '" + this.m_usr_address.ToString() + "', ");
                        sSQL.Append("usr_postalcode = '" + this.m_usr_postalcode.ToString() + "', ");
                        sSQL.Append("usr_city = '" + this.m_usr_city.ToString() + "', ");
                        sSQL.Append("usr_country = '" + this.m_usr_country.ToString() + "', ");
                        sSQL.Append("usr_phone1 = '" + this.m_usr_phone1.ToString() + "', ");
                        sSQL.Append("usr_phone2 = '" + this.m_usr_phone2.ToString() + "', ");
                        sSQL.Append("usr_phone2 = '" + this.m_usr_phone3.ToString() + "', ");
                        sSQL.Append("usr_fax = '" + this.m_usr_fax.ToString() + "', ");
                        sSQL.Append("usr_mobile = '" + this.m_usr_mobile.ToString() + "', ");
                        sSQL.Append("usr_url1 = '" + this.m_usr_url1.ToString() + "', ");
                        sSQL.Append("usr_url2 = '" + this.m_usr_url2.ToString() + "', ");
                        sSQL.Append("usr_mail1 = '" + this.m_usr_mail1.ToString() + "', ");
                        sSQL.Append("usr_mail2 = '" + this.m_usr_mail2.ToString() + "', ");
                        sSQL.Append("usr_picturepath = '" + this.m_usr_picturepath.ToString() + "', ");
                        sSQL.Append("usr_signaturepath = '" + this.m_usr_signaturepath.ToString() + "', ");
                        sSQL.Append("usr_createddate = '" + this.m_usr_createddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        sSQL.Append("usr_createdby = '" + this.m_usr_createdby.ToString() + "', ");
                        sSQL.Append("usr_updateddate = '" + this.m_usr_updateddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        sSQL.Append("usr_updatedby = '" + this.m_usr_updatedby.ToString() + "', ");
                        sSQL.Append("usr_hidden = " + Convert.ToString(!this.m_usr_hidden ? "0" : "1") + ", ");
                        sSQL.Append("usr_deleted = " + Convert.ToString(!this.m_usr_deleted ? "0" : "1") + " ");
                        sSQL.Append("WHERE usr_id = " + m_usr_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());

                        ResetThis();
                        SortAll();

                        if (this.m_usr_deleted)
                            DeleteRelations();
                    }
                    else
                    {
                        Save();
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            public virtual void Save()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                try
                {
                    if (!this.m_exists)
                    {
                        DataSet ds = new DataSet();
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("INSERT INTO usr_users (sta_id, lng_id, ust_id, usr_parentid, usr_order, usr_title, usr_alias, usr_description, usr_loginname, usr_password, usr_signature, usr_firstname, usr_lastname, usr_tag, usr_co, usr_address, usr_postalcode, usr_city, usr_country, usr_phone1, usr_phone2, usr_phone3, usr_fax, usr_mobile, usr_url1, usr_url2, usr_mail1, usr_mail2, usr_picturepath, usr_signaturepath, usr_createddate, usr_createdby, usr_updateddate, usr_updatedby, usr_hidden, usr_deleted) VALUES ( ");
                        sSQL.Append(this.Status.ToString() + ", ");
                        sSQL.Append(this.Language.ToString() + ", ");
                        sSQL.Append(this.Type.ToString() + ", ");
                        sSQL.Append(this.ParentId.ToString() + ", ");
                        sSQL.Append(this.Order.ToString() + ", ");
                        sSQL.Append("'" + this.Title + "', ");
                        sSQL.Append("'" + this.Alias + "', ");
                        sSQL.Append("'" + this.Description + "', ");
                        sSQL.Append("'" + this.LoginName + "', ");
                        sSQL.Append("'" + this.Password + "', ");
                        sSQL.Append("'" + this.Signature + "', ");
                        sSQL.Append("'" + this.FirstName + "', ");
                        sSQL.Append("'" + this.LastName + "', ");
                        sSQL.Append("'" + this.Tag + "', ");
                        sSQL.Append("'" + this.Co + "', ");
                        sSQL.Append("'" + this.Address + "', ");
                        sSQL.Append("'" + this.PostalCode + "', ");
                        sSQL.Append("'" + this.City + "', ");
                        sSQL.Append("'" + this.Country + "', ");
                        sSQL.Append("'" + this.Phone1 + "', ");
                        sSQL.Append("'" + this.Phone2 + "', ");
                        sSQL.Append("'" + this.Phone3 + "', ");
                        sSQL.Append("'" + this.Fax + "', ");
                        sSQL.Append("'" + this.Mobile + "', ");
                        sSQL.Append("'" + this.Url1 + "', ");
                        sSQL.Append("'" + this.Url2 + "', ");
                        sSQL.Append("'" + this.Mail1 + "', ");
                        sSQL.Append("'" + this.Mail2 + "', ");
                        sSQL.Append("'" + this.PicturePath + "', ");
                        sSQL.Append("'" + this.SignaturePath + "', ");
                        sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("0, ");
                        sSQL.Append("0)");
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                        {
                            Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                            this.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                        }

                        ResetThis();
                        SortAll();
                    }
                    else
                    {
                        Update();
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            public void AddToRole(Int32 RolId)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::AddToRole]";
                try
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO uro_usersroles (sta_id, usr_id, rol_id, uro_createddate, uro_createdby, uro_updateddate, uro_updatedby, uro_hidden, uro_deleted) VALUES ( ");
                    sSQL.Append(this.Status.ToString() + ", ");
                    sSQL.Append(this.Id.ToString() + ", ");
                    sSQL.Append(RolId.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                    {
                        Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                    }
                    Roles.ResetThis(); 
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            public void RemoveFromRole(Int32 RolId)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::RemoveFromRole]";
                try
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("UPDATE uro_usersroles SET uro_deleted = 1 WHERE usr_id = " + this.Id.ToString() + " AND rol_id = " + RolId.ToString());
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                    {
                        Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                    }
                    Roles.ResetThis(); 
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            #endregion Public Functions

            #region Private Functions
            private void GetById()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
                DataTable dt = null;
                try
                {
                    String CacheItem = RXServer.Data.CACHEITEM_USER_ID + "::UsrId" + m_usr_id.ToString();
                    if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                    if (dt == null)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("SELECT * FROM usr_users WHERE usr_id = " + m_usr_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                        {
                            dt = oDo.GetDataTable(sSQL.ToString());
                        }
                        RXServer.Data.CacheInsert(CacheItem, dt);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        this.m_usr_id = Convert.ToInt32(dr["usr_id"]);
                        this.m_sta_id = Convert.ToInt32(dr["sta_id"]);
                        this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                        this.m_ust_id = Convert.ToInt32(dr["ust_id"]);
                        this.m_usr_parentid = Convert.ToInt32(dr["usr_parentid"]);
                        this.m_usr_order = Convert.ToInt32(dr["usr_order"]);
                        this.m_usr_title = Convert.ToString(dr["usr_title"]);
                        this.m_usr_alias = Convert.ToString(dr["usr_alias"]);
                        this.m_usr_description = Convert.ToString(dr["usr_description"]);
                        this.m_usr_loginname = Convert.ToString(dr["usr_loginname"]);
                        this.m_usr_password = Convert.ToString(dr["usr_password"]);
                        this.m_usr_signature = Convert.ToString(dr["usr_signature"]);
                        this.m_usr_firstname = Convert.ToString(dr["usr_firstname"]);
                        this.m_usr_lastname = Convert.ToString(dr["usr_lastname"]);
                        this.m_usr_tag = Convert.ToString(dr["usr_tag"]);
                        this.m_usr_co = Convert.ToString(dr["usr_co"]);
                        this.m_usr_address = Convert.ToString(dr["usr_address"]);
                        this.m_usr_postalcode = Convert.ToString(dr["usr_postalcode"]);
                        this.m_usr_city = Convert.ToString(dr["usr_city"]);
                        this.m_usr_country = Convert.ToString(dr["usr_country"]);
                        this.m_usr_phone1 = Convert.ToString(dr["usr_phone1"]);
                        this.m_usr_phone2 = Convert.ToString(dr["usr_phone2"]);
                        this.m_usr_phone3 = Convert.ToString(dr["usr_phone3"]);
                        this.m_usr_fax = Convert.ToString(dr["usr_fax"]);
                        this.m_usr_mobile = Convert.ToString(dr["usr_mobile"]);
                        this.m_usr_url1 = Convert.ToString(dr["usr_url1"]);
                        this.m_usr_url2 = Convert.ToString(dr["usr_url2"]);
                        this.m_usr_mail1 = Convert.ToString(dr["usr_mail1"]);
                        this.m_usr_mail2 = Convert.ToString(dr["usr_mail2"]);
                        this.m_usr_picturepath = Convert.ToString(dr["usr_picturepath"]);
                        this.m_usr_signaturepath = Convert.ToString(dr["usr_signaturepath"]);
                        this.m_usr_createddate = Convert.ToDateTime(dr["usr_createddate"]);
                        this.m_usr_createdby = Convert.ToString(dr["usr_createdby"]);
                        this.m_usr_updateddate = Convert.ToDateTime(dr["usr_updateddate"]);
                        this.m_usr_updatedby = Convert.ToString(dr["usr_updatedby"]);
                        this.m_usr_hidden = Convert.ToBoolean(dr["usr_hidden"]);
                        this.m_usr_deleted = Convert.ToBoolean(dr["usr_deleted"]);
                        this.m_exists = true;
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            private void SortAll()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::SortAll]";
                try
                {
                    Int32 Order = (Int32)OrderMinMax.Min;
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM usr_users WHERE usr_deleted = 0 ORDER BY usr_order");
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                    {
                        DataTable dt = oDo.GetDataTable(sSQL.ToString());
                        foreach (DataRow dr in dt.Rows)
                        {
                            StringBuilder sSQL2 = new StringBuilder();
                            sSQL2.Append("UPDATE usr_users SET usr_order = " + Order.ToString() + " WHERE usr_id = " + dr["usr_id"].ToString());
                            using (iCDataObject oDo2 = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                                oDo2.ExecuteNonQuery(sSQL2.ToString());
                            Order = Order + (Int32)OrderMinMax.Step;
                        }
                        ResetThis();
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            private void DeleteRelations()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
                try
                {
                    // Delete SiteCollection... 
                    // not in use for Objects...

                    // Delete PageCollection...
                    // not in use for Objects...

                    // Delete TaskCollection...
                    // not in use for Objects...

                    // Delete ModuleCollection... 
                    // not in use for Objects...

                    // Delete DocumentCollection...
                    // not in use for Objects...

                    // Delete ObjectCollection...
                    // not in use for Objects...
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            #endregion Private Functions

            #region public class GenericComparer
            public int CompareTo(object obj, string Property)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CompareTo]";
                try
                {
                    Type type = this.GetType();
                    PropertyInfo propertie = type.GetProperty(Property);


                    Type type2 = obj.GetType();
                    PropertyInfo propertie2 = type2.GetProperty(Property);

                    object[] index = null;

                    object Obj1 = propertie.GetValue(this, index);
                    object Obj2 = propertie2.GetValue(obj, index);

                    IComparable Ic1 = (IComparable)Obj1;
                    IComparable Ic2 = (IComparable)Obj2;

                    int ret = Ic1.CompareTo(Ic2);

                    return ret;

                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return 0;
                }
            }
            #endregion public class GenericComparer

        }

        #region public class GenericComparer

        public enum SortOrderEnum
        {
            Ascending,
            Descending
        }

        public enum SortParamEnum
        {
            Id,
            Status,
            Language,
            Type,
            ParentId,
            Order,
            Title,
            Alias,
            Description,
            LoginName,
            Password,
            Signature,
            FirstName,
            LastName,
            Tag,
            Co,
            Address,
            PostalCode,
            City,
            Country,
            Phone1,
            Phone2,
            Phone3,
            Fax,
            Mobile,
            Url1,
            Url2,
            Mail1,
            Mail2,
            PicturePath,
            SignaturePath,
            CreatedDate,
            CreatedBy,
            UpdatedDate,
            UpdatedBy,
            Hidden,
            Deleted
        }

        public class GenericComparer : IComparer
        {
            private String _Property = null;
            private SortOrderEnum _SortOrder = SortOrderEnum.Ascending;

            public String SortProperty
            {
                get { return _Property; }
                set { _Property = value; }
            }

            public SortOrderEnum SortOrder
            {
                get { return _SortOrder; }
                set { _SortOrder = value; }
            }

            public int Compare(object x, object y)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Compare]";
                try
                {
                    User ing1 = (User)x;
                    User ing2 = (User)y;

                    if (this.SortOrder.Equals(SortOrderEnum.Ascending))
                        return ing1.CompareTo(ing2, this.SortProperty);
                    else
                        return ing2.CompareTo(ing1, this.SortProperty);
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return 0;
                }

            }
        }

        public void Sort(SortParamEnum SortBy, SortOrderEnum SortOrder)
        {
            GenericComparer comparer = new GenericComparer();
            comparer.SortProperty = SortBy.ToString();
            comparer.SortOrder = SortOrder;
            this.InnerList.Sort(comparer);
        }

        #endregion public class GenericComparer

    }
    #endregion public class Users

    #region public class Roles
    public class Roles : CollectionBase, IDisposable
    {
        static String CLASSNAME = "[Namespace::RXServer][Class::Roles]";

        #region Private Variables
        private Int32 m_sit_id = 0;
        #endregion Private Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public Roles()
        {
            GetAll();
        }
        public Roles(Int32 SitId)
        {
            this.m_sit_id = SitId;
            GetAllBySitId();
        }
        ~Roles()
        { xFinalize(); }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
        }
        #endregion Constructors

        #region Private Functions
        private int _Add(Role role)
        {
            return List.Add(role);
        }
        private void GetAll()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_ROLE_COLLECTION + "::All";
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT rol_id FROM rol_roles WHERE rol_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    Role r = new Role(Convert.ToInt32(dr["rol_id"].ToString()));
                    this._Add(r);
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetAllBySitId()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAllBySitId]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_ROLE_COLLECTION + "::SitId" + m_sit_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT rol.rol_id FROM rol_roles rol ");
                    sSQL.Append("JOIN asr_authorizedsitesroles asr ON asr.rol_id = rol.rol_id AND asr.sit_id = " + m_sit_id.ToString() + " ");
                    sSQL.Append("WHERE rol.rol_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    Role r = new Role(Convert.ToInt32(dr["rol_id"].ToString()));
                    this._Add(r);
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        #endregion Private Functions

        #region Public Functions
        public static void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_ROLE_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_ROLE_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_ROLE_COLLECTION);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public int Add(Role role)
        {
            role.Save();
            return List.Add(role);
        }
        public void Remove(Role role)
        {
            role.Deleted = true;
            role.Update();
            List.Remove(role);
        }
        public Role this[int index]
        {
            get
            {
                return ((Role)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        #endregion Public Functions

        public class Role : IDisposable
        {
            static String CLASSNAME = "[Namespace::RXServer.Roles][Class::Role]";

            #region Private Variables
            private Boolean     m_exists            = false;

            private Int32       m_rol_id            = 0;
            private Int32       m_sta_id            = 0;
            private Int32       m_lng_id            = 0;
            private Int32       m_rol_parentid      = 0;
            private Int32       m_rol_order         = 0;
            private String      m_rol_title         = String.Empty;
            private String      m_rol_alias         = String.Empty;
            private String      m_rol_description   = String.Empty;
            private DateTime    m_rol_createddate   = DateTime.Now;
            private String      m_rol_createdby     = String.Empty;
            private DateTime    m_rol_updateddate   = DateTime.Now;
            private String      m_rol_updatedby     = String.Empty;
            private Boolean     m_rol_hidden        = false;
            private Boolean     m_rol_deleted       = false;
            #endregion Private Variables

            #region Properties

            public Boolean Exist
            {
                get
                {
                    return this.m_exists;
                }
                set
                {
                    this.m_exists = value;
                }
            }
            public Int32 Id
            {
                get
                {
                    return this.m_rol_id;
                }
                set
                {
                    this.m_rol_id = value;
                }
            }
            public Int32 Status
            {
                get
                {
                    return this.m_sta_id;
                }
                set
                {
                    this.m_sta_id = value;
                }
            }
            public Int32 Language
            {
                get
                {
                    return this.m_lng_id;
                }
                set
                {
                    this.m_lng_id = value;
                }
            }
            public Int32 ParentId
            {
                get
                {
                    return this.m_rol_parentid;
                }
                set
                {
                    this.m_rol_parentid = value;
                }
            }
            public Int32 Order
            {
                get
                {
                    return this.m_rol_order;
                }
                set
                {
                    this.m_rol_order = value;
                }
            }
            public String Title
            {
                get
                {
                    return this.m_rol_title;
                }
                set
                {
                    this.m_rol_title = Common.SafeString(value);
                }
            }
            public String Alias
            {
                get
                {
                    return this.m_rol_alias;
                }
                set
                {
                    this.m_rol_alias = Common.SafeString(value);
                }
            }
            public String Description
            {
                get
                {
                    return this.m_rol_description;
                }
                set
                {
                    this.m_rol_description = Common.SafeString(value);
                }
            }
            public DateTime CreatedDate
            {
                get
                {
                    return this.m_rol_createddate;
                }
                set
                {
                    this.m_rol_createddate = value;
                }
            }
            public string CreatedBy
            {
                get
                {
                    return this.m_rol_createdby;
                }
                set
                {
                    this.m_rol_createdby = Common.SafeString(value);
                }
            }
            public DateTime UpdatedDate
            {
                get
                {
                    return this.m_rol_updateddate;
                }
                set
                {
                    this.m_rol_updateddate = value;
                }
            }
            public string UpdatedBy
            {
                get
                {
                    return this.m_rol_updatedby;
                }
                set
                {
                    this.m_rol_updatedby = Common.SafeString(value);
                }
            }
            public Boolean Hidden
            {
                get
                {
                    return this.m_rol_hidden;
                }
                set
                {
                    this.m_rol_hidden = value;
                }
            }
            public Boolean Deleted
            {
                get
                {
                    return this.m_rol_deleted;
                }
                set
                {
                    this.m_rol_deleted = value;
                }
            }

            #endregion Properties

            #region Constructors
            public Role() { }
            public Role(Int32 RolId)
            {
                m_rol_id = RolId;
                GetById();
            }
            ~Role()
            { xFinalize(); }
            public void Dispose()
            {
                xFinalize();
                System.GC.SuppressFinalize(this);
            }
            private void xFinalize()
            {
            }
            #endregion Constructors

            #region Public Functions
            public virtual void Update()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
                try
                {
                    if (this.m_exists)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("UPDATE rol_roles SET ");
                        sSQL.Append("sta_id = " + this.m_sta_id.ToString() + ", ");
                        sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                        sSQL.Append("rol_parentid = " + this.m_rol_parentid.ToString() + ", ");
                        sSQL.Append("rol_order = " + this.m_rol_order.ToString() + ", ");
                        sSQL.Append("rol_title = '" + this.m_rol_title.ToString() + "', ");
                        sSQL.Append("rol_alias = '" + this.m_rol_alias.ToString() + "', ");
                        sSQL.Append("rol_description = '" + this.m_rol_description.ToString() + "', ");
                        sSQL.Append("rol_createddate = '" + this.m_rol_createddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        sSQL.Append("rol_createdby = '" + this.m_rol_createdby.ToString() + "', ");
                        sSQL.Append("rol_updateddate = '" + this.m_rol_updateddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        sSQL.Append("rol_updatedby = '" + this.m_rol_updatedby.ToString() + "', ");
                        sSQL.Append("rol_hidden = " + Convert.ToString(!this.m_rol_hidden ? "0" : "1") + ", ");
                        sSQL.Append("rol_deleted = " + Convert.ToString(!this.m_rol_deleted ? "0" : "1") + " ");
                        sSQL.Append("WHERE rol_id = " + m_rol_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());

                        ResetThis();
                        SortAll();

                        if (this.m_rol_deleted)
                            DeleteRelations();
                    }
                    else
                    {
                        Save();
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            public virtual void Save()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                try
                {
                    if (!this.m_exists)
                    {
                        DataSet ds = new DataSet();
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("INSERT INTO rol_roles (sta_id, lng_id, rol_parentid, rol_order, rol_title, rol_alias, rol_description, rol_createddate, rol_createdby, rol_updateddate, rol_updatedby, rol_hidden, rol_deleted) VALUES ( ");
                        sSQL.Append(this.Status.ToString() + ", ");
                        sSQL.Append(this.Language.ToString() + ", ");
                        sSQL.Append(this.ParentId.ToString() + ", ");
                        sSQL.Append(this.Order.ToString() + ", ");
                        sSQL.Append("'" + this.Title + "', ");
                        sSQL.Append("'" + this.Alias + "', ");
                        sSQL.Append("'" + this.Description + "', ");
                        sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("0, ");
                        sSQL.Append("0)");
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                        {
                            Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                            this.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                        }

                        ResetThis();
                        SortAll();
                    }
                    else
                    {
                        Update();
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            public void AddToSite(Int32 SitId)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::AddToRole]";
                try
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO asr_authorizedsitesroles (sta_id, sit_id, rol_id, asr_createddate, asr_createdby, asr_updateddate, asr_updatedby, asr_hidden, asr_deleted) VALUES ( ");
                    sSQL.Append(this.Status.ToString() + ", ");
                    sSQL.Append(SitId.ToString() + ", ");
                    sSQL.Append(this.Id.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                    {
                        Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                    }
                    Site.ResetThis();
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            public void RemoveFromSite(Int32 SitId)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::RemoveFromRole]";
                try
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("UPDATE asr_authorizedsitesroles SET asr_deleted = 1 WHERE rol_id = " + this.Id.ToString() + " AND sit_id = " + SitId.ToString());
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                    {
                        Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                    }
                    Site.ResetThis();
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            #endregion Public Functions

            #region Private Functions
            private void GetById()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
                DataTable dt = null;
                try
                {
                    String CacheItem = RXServer.Data.CACHEITEM_ROLE_ID + "::RolId" + m_rol_id.ToString();
                    if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                    if (dt == null)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("SELECT * FROM rol_roles WHERE rol_id = " + m_rol_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                        {
                            dt = oDo.GetDataTable(sSQL.ToString());
                        }
                        RXServer.Data.CacheInsert(CacheItem, dt);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        this.m_rol_id = Convert.ToInt32(dr["rol_id"]);
                        this.m_sta_id = Convert.ToInt32(dr["sta_id"]);
                        this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                        this.m_rol_parentid = Convert.ToInt32(dr["rol_parentid"]);
                        this.m_rol_order = Convert.ToInt32(dr["rol_order"]);
                        this.m_rol_title = Convert.ToString(dr["rol_title"]);
                        this.m_rol_alias = Convert.ToString(dr["rol_alias"]);
                        this.m_rol_description = Convert.ToString(dr["rol_description"]);
                        this.m_rol_createddate = Convert.ToDateTime(dr["rol_createddate"]);
                        this.m_rol_createdby = Convert.ToString(dr["rol_createdby"]);
                        this.m_rol_updateddate = Convert.ToDateTime(dr["rol_updateddate"]);
                        this.m_rol_updatedby = Convert.ToString(dr["rol_updatedby"]);
                        this.m_rol_hidden = Convert.ToBoolean(dr["rol_hidden"]);
                        this.m_rol_deleted = Convert.ToBoolean(dr["rol_deleted"]);
                        this.m_exists = true;
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            private void SortAll()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::SortAll]";
                try
                {
                    Int32 Order = (Int32)OrderMinMax.Min;
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM rol_roles WHERE rol_deleted = 0 ORDER BY rol_order");
                    using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                    {
                        DataTable dt = oDo.GetDataTable(sSQL.ToString());
                        foreach (DataRow dr in dt.Rows)
                        {
                            StringBuilder sSQL2 = new StringBuilder();
                            sSQL2.Append("UPDATE rol_roles SET rol_order = " + Order.ToString() + " WHERE rol_id = " + dr["rol_id"].ToString());
                            using (iCDataObject oDo2 = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                                oDo2.ExecuteNonQuery(sSQL2.ToString());
                            Order = Order + (Int32)OrderMinMax.Step;
                        }
                        ResetThis();
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            private void DeleteRelations()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
                try
                {
                    // Delete SiteCollection... 
                    // not in use for Objects...

                    // Delete PageCollection...
                    // not in use for Objects...

                    // Delete TaskCollection...
                    // not in use for Objects...

                    // Delete ModuleCollection... 
                    // not in use for Objects...

                    // Delete DocumentCollection...
                    // not in use for Objects...

                    // Delete ObjectCollection...
                    // not in use for Objects...
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            #endregion Private Functions

            #region public class GenericComparer
            public int CompareTo(object obj, string Property)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CompareTo]";
                try
                {
                    Type type = this.GetType();
                    PropertyInfo propertie = type.GetProperty(Property);


                    Type type2 = obj.GetType();
                    PropertyInfo propertie2 = type2.GetProperty(Property);

                    object[] index = null;

                    object Obj1 = propertie.GetValue(this, index);
                    object Obj2 = propertie2.GetValue(obj, index);

                    IComparable Ic1 = (IComparable)Obj1;
                    IComparable Ic2 = (IComparable)Obj2;

                    int ret = Ic1.CompareTo(Ic2);

                    return ret;

                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return 0;
                }
            }
            #endregion public class GenericComparer

        }

        #region public class GenericComparer

        public enum SortOrderEnum
        {
            Ascending,
            Descending
        }

        public enum SortParamEnum
        {
            Id,
            Status,
            Language,
            Type,
            ParentId,
            Order,
            Title,
            Alias,
            Description,
            CreatedDate,
            CreatedBy,
            UpdatedDate,
            UpdatedBy,
            Hidden,
            Deleted
        }

        public class GenericComparer : IComparer
        {
            private String _Property = null;
            private SortOrderEnum _SortOrder = SortOrderEnum.Ascending;

            public String SortProperty
            {
                get { return _Property; }
                set { _Property = value; }
            }

            public SortOrderEnum SortOrder
            {
                get { return _SortOrder; }
                set { _SortOrder = value; }
            }


            public int Compare(object x, object y)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Compare]";
                try
                {
                    Role ing1 = (Role)x;
                    Role ing2 = (Role)y;

                    if (this.SortOrder.Equals(SortOrderEnum.Ascending))
                        return ing1.CompareTo(ing2, this.SortProperty);
                    else
                        return ing2.CompareTo(ing1, this.SortProperty);
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return 0;
                }

            }
        }

        public void Sort(SortParamEnum SortBy, SortOrderEnum SortOrder)
        {
            GenericComparer comparer = new GenericComparer();
            comparer.SortProperty = SortBy.ToString();
            comparer.SortOrder = SortOrder;
            this.InnerList.Sort(comparer);
        }

        #endregion public class GenericComparer
    }
    #endregion public class Roles

}

namespace RXServer
{
    namespace Web
    {
        namespace List
        {

            #region public class Meta
            /// <summary>
            /// RXServer.Web.List.Meta
            /// </summary>
            /// <example>The following is an example of initializing a 
            /// <c>RXServer.Web.List.Meta</c> type:
            ///   <code>
            /// protected void Page_Load(object sender, EventArgs e)
            /// {
            ///     if (!Page.IsPostBack)
            ///         BindData();
            /// }
            /// private void BindData()
            /// {
            ///     ListBox1.Items.Clear();
            ///     using (RXServer.Web.List.Meta m = new RXServer.Web.List.Meta(1, 1))
            ///     {
            ///         m.Sort(RXServer.Web.List.Meta.SortParamEnum.Name, RXServer.Web.List.Meta.SortOrderEnum.Ascending);
            ///         foreach (RXServer.Web.List.Meta.Tag t in m)
            ///         {
            ///             ListBox1.Items.Add(new ListItem(t.Name, t.Id.ToString()));
            ///         }
            ///     }
            /// }
            /// protected void Add_Click(object sender, EventArgs e)
            /// {
            ///     using(RXServer.Web.List.Meta m = new RXServer.Web.List.Meta(1, 1))
            ///     {
            ///         m.Add(new RXServer.Web.List.Meta.Tag(TextBox1.Text, TextBox2.Text));
            ///     }
            ///     BindData();
            /// }
            /// protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
            /// {
            ///     using (RXServer.Web.List.Meta.Tag t = new RXServer.Web.List.Meta.Tag(Convert.ToInt32(ListBox1.SelectedValue)))
            ///     {
            ///         t.Deleted = true;
            ///         t.Save();
            ///     }
            ///     BindData();
            /// }
            ///   </code>
            /// </example>
            public class Meta : CollectionBase, IDisposable
            {
                static String CLASSNAME = "[Namespace::RXServer.Web.List][Class::Meta]";

                #region Private Variables
                private Int32 m_sit_id = 0;
                private Int32 m_pag_id = 0;
                #endregion Private Variables

                #region Properties
                #endregion Properties

                #region Constructors
                public Meta()
                {
                    GetAll();
                }
                public Meta(Int32 SitId)
                {
                    this.m_sit_id = SitId;
                    this.m_pag_id = 0;
                    GetAllBySitId();
                }
                public Meta(Int32 SitId, Int32 PagId)
                {
                    this.m_sit_id = SitId;
                    this.m_pag_id = PagId;
                    GetAllBySitIdPagId();
                }
                ~Meta()
                { xFinalize(); }
                public void Dispose()
                {
                    xFinalize();
                    System.GC.SuppressFinalize(this);
                }
                private void xFinalize()
                {
                }
                #endregion Constructors

                #region Private Functions
                private int _Add(Tag tag)
                {
                    return List.Add(tag);
                }
                private void GetAll()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
                    DataTable dt = null;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_META_COLLECTION + "::All";
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem_Meta) + " AND obd_deleted = 0");
                            using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        foreach (DataRow dr in dt.Rows)
                        {
                            Tag t = new Tag(Convert.ToInt32(dr["obd_id"].ToString()));
                            this._Add(t);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                private void GetAllBySitId()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetAllBySitId]";
                    DataTable dt = null;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_META_COLLECTION + "::SitId" + m_sit_id.ToString();
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem_Meta) + " AND sit_id = " + m_sit_id.ToString() + " AND obd_deleted = 0");
                            using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        foreach (DataRow dr in dt.Rows)
                        {
                            Tag t = new Tag(Convert.ToInt32(dr["obd_id"].ToString()));
                            this._Add(t);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                private void GetAllBySitIdPagId()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetAllBySitIdPagId]";
                    DataTable dt = null;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_META_COLLECTION + "::SitId" + m_sit_id.ToString() + "::PagId" + m_pag_id.ToString();
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem_Meta) + " AND sit_id = " + m_sit_id.ToString() + " AND pag_id = " + m_pag_id.ToString() + " AND obd_deleted = 0");
                            using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        foreach (DataRow dr in dt.Rows)
                        {
                            Tag t = new Tag(Convert.ToInt32(dr["obd_id"].ToString()));
                            this._Add(t);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                #endregion Private Functions

                #region Public Functions
                public static void ResetThis()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
                    try
                    {
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_META_ID);
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_META_ALIAS);
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_META_COLLECTION);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                public int Add(Tag tag)
                {
                    tag.SitId = this.m_sit_id;
                    tag.PagId = this.m_pag_id;
                    tag.Save();
                    return List.Add(tag);
                }
                public void Remove(Tag tag)
                {
                    tag.Deleted = true;
                    tag.Update();
                    List.Remove(tag);
                }
                public Tag this[int index]
                {
                    get
                    {
                        return ((Tag)List[index]);
                    }
                    set
                    {
                        List[index] = value;
                    }
                }
                #endregion Public Functions

                public class Tag : IDisposable
                {
                    static String CLASSNAME = "[Namespace::RXServer.Web.List.Meta][Class::Tag]";

                    #region Private Variables
                    private Boolean m_exists = false;

                    private Int32 m_tag_id = 0;
                    private Int32 m_sit_id = 0;
                    private Int32 m_pag_id = 0;
                    private Int32 m_sta_id = 0;
                    private Int32 m_lng_id = 0;
                    private Int32 m_tag_parentid = 0;
                    private Int32 m_tag_order = 0;
                    private String m_tag_title = String.Empty;
                    private String m_tag_alias = String.Empty;
                    private String m_tag_description = String.Empty;
                    private String m_tag_value = String.Empty;
                    private Boolean m_tag_appliestoall = false;
                    private Boolean m_tag_appliestochildren = false;
                    private DateTime m_tag_createddate = DateTime.Now;
                    private String m_tag_createdby = String.Empty;
                    private DateTime m_tag_updateddate = DateTime.Now;
                    private String m_tag_updatedby = String.Empty;
                    private Boolean m_tag_hidden = false;
                    private Boolean m_tag_deleted = false;
                    #endregion Private Variables

                    #region Properties

                    public Boolean Exist
                    {
                        get
                        {
                            return this.m_exists;
                        }
                        set
                        {
                            this.m_exists = value;
                        }
                    }
                    public Int32 SitId
                    {
                        get
                        {
                            return this.m_sit_id;
                        }
                        set
                        {
                            this.m_sit_id = value;
                        }
                    }
                    public Int32 PagId
                    {
                        get
                        {
                            return this.m_pag_id;
                        }
                        set
                        {
                            this.m_pag_id = value;
                        }
                    }
                    public Int32 Id
                    {
                        get
                        {
                            return this.m_tag_id;
                        }
                        set
                        {
                            this.m_tag_id = value;
                        }
                    }
                    public Int32 Status
                    {
                        get
                        {
                            return this.m_sta_id;
                        }
                        set
                        {
                            this.m_sta_id = value;
                        }
                    }
                    public Int32 Language
                    {
                        get
                        {
                            return this.m_lng_id;
                        }
                        set
                        {
                            this.m_lng_id = value;
                        }
                    }
                    public Int32 ParentId
                    {
                        get
                        {
                            return this.m_tag_parentid;
                        }
                        set
                        {
                            this.m_tag_parentid = value;
                        }
                    }
                    public Int32 Order
                    {
                        get
                        {
                            return this.m_tag_order;
                        }
                        set
                        {
                            this.m_tag_order = value;
                        }
                    }
                    public String Name
                    {
                        get
                        {
                            return this.m_tag_title;
                        }
                        set
                        {
                            this.m_tag_title = Common.SafeString(value);
                        }
                    }
                    public String Alias
                    {
                        get
                        {
                            return this.m_tag_alias;
                        }
                        set
                        {
                            this.m_tag_alias = Common.SafeString(value);
                        }
                    }
                    public String Description
                    {
                        get
                        {
                            return this.m_tag_description;
                        }
                        set
                        {
                            this.m_tag_description = Common.SafeString(value);
                        }
                    }
                    public String Value
                    {
                        get
                        {
                            return this.m_tag_value;
                        }
                        set
                        {
                            this.m_tag_value = Common.SafeString(value);
                        }
                    }
                    public Boolean AppliesToAll
                    {
                        get
                        {
                            return this.m_tag_appliestoall;
                        }
                        set
                        {
                            this.m_tag_appliestoall = value;
                        }
                    }
                    public Boolean AppliesToChildren
                    {
                        get
                        {
                            return this.m_tag_appliestochildren;
                        }
                        set
                        {
                            this.m_tag_appliestochildren = value;
                        }
                    }
                    public DateTime CreatedDate
                    {
                        get
                        {
                            return this.m_tag_createddate;
                        }
                        set
                        {
                            this.m_tag_createddate = value;
                        }
                    }
                    public string CreatedBy
                    {
                        get
                        {
                            return this.m_tag_createdby;
                        }
                        set
                        {
                            this.m_tag_createdby = Common.SafeString(value);
                        }
                    }
                    public DateTime UpdatedDate
                    {
                        get
                        {
                            return this.m_tag_updateddate;
                        }
                        set
                        {
                            this.m_tag_updateddate = value;
                        }
                    }
                    public string UpdatedBy
                    {
                        get
                        {
                            return this.m_tag_updatedby;
                        }
                        set
                        {
                            this.m_tag_updatedby = Common.SafeString(value);
                        }
                    }
                    public Boolean Hidden
                    {
                        get
                        {
                            return this.m_tag_hidden;
                        }
                        set
                        {
                            this.m_tag_hidden = value;
                        }
                    }
                    public Boolean Deleted
                    {
                        get
                        {
                            return this.m_tag_deleted;
                        }
                        set
                        {
                            this.m_tag_deleted = value;
                        }
                    }

                    #endregion Properties

                    #region Constructors
                    public Tag() { }
                    public Tag(Int32 TagId)
                    {
                        m_tag_id = TagId;
                        GetById();
                    }
                    public Tag(String Name, String Value)
                    {
                        this.Name = Name;
                        this.Value = Value;
                    }
                    public Tag(String Name, String Value, Boolean AppliesToAll, Boolean AppliesToChildren)
                    {
                        this.Name = Name;
                        this.Value = Value;
                        this.AppliesToAll = AppliesToAll;
                        this.AppliesToChildren = AppliesToChildren;
                    }
                    ~Tag()
                    { xFinalize(); }
                    public void Dispose()
                    {
                        xFinalize();
                        System.GC.SuppressFinalize(this);
                    }
                    private void xFinalize()
                    {
                    }
                    #endregion Constructors

                    #region Public Functions
                    /// <summary>
                    /// Update
                    /// </summary>
                    public virtual void Update()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
                        try
                        {
                            if (this.m_exists)
                            {
                                StringBuilder sSQL = new StringBuilder();
                                sSQL.Append("UPDATE obd_objectdata SET ");
                                sSQL.Append("sta_id = " + this.m_sta_id.ToString() + ", ");
                                sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                                sSQL.Append("obd_parentid = " + this.m_tag_parentid.ToString() + ", ");
                                sSQL.Append("obd_order = " + this.m_tag_order.ToString() + ", ");
                                sSQL.Append("obd_title = '" + this.m_tag_title.ToString() + "', ");
                                sSQL.Append("obd_alias = '" + this.m_tag_alias.ToString() + "', ");
                                sSQL.Append("obd_description = '" + this.m_tag_description.ToString() + "', ");
                                sSQL.Append("obd_varchar1 = '" + this.m_tag_value.ToString() + "', ");
                                sSQL.Append("obd_varchar2 = '" + Convert.ToString(!this.m_tag_appliestoall ? "0" : "1") + "', ");
                                sSQL.Append("obd_varchar3 = '" + Convert.ToString(!this.m_tag_appliestochildren ? "0" : "1") + "', ");
                                sSQL.Append("obd_createddate = '" + this.m_tag_createddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                                sSQL.Append("obd_createdby = '" + this.m_tag_createdby.ToString() + "', ");
                                sSQL.Append("obd_updateddate = '" + this.m_tag_updateddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                                sSQL.Append("obd_updatedby = '" + this.m_tag_updatedby.ToString() + "', ");
                                sSQL.Append("obd_hidden = " + Convert.ToString(!this.m_tag_hidden ? "0" : "1") + ", ");
                                sSQL.Append("obd_deleted = " + Convert.ToString(!this.m_tag_deleted ? "0" : "1") + " ");
                                sSQL.Append("WHERE obd_id = " + m_tag_id.ToString());
                                using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                                    oDo.ExecuteNonQuery(sSQL.ToString());

                                ResetThis();
                                SortAll();

                                if (this.m_tag_deleted)
                                    DeleteRelations();
                            }
                            else
                            {
                                Save();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    /// <summary>
                    /// Save
                    /// </summary>
                    public virtual void Save()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                        try
                        {
                            if (!this.m_exists)
                            {
                                DataSet ds = new DataSet();
                                StringBuilder sSQL = new StringBuilder();
                                sSQL.Append("INSERT INTO obd_objectdata (sta_id, sit_id, pag_id, lng_id, obd_parentid, obd_order, obd_type, obd_title, obd_alias, obd_description, obd_varchar1, obd_varchar2, obd_varchar3, obd_createddate, obd_createdby, obd_updateddate, obd_updatedby, obd_hidden, obd_deleted) VALUES ( ");
                                sSQL.Append(this.Status.ToString() + ", ");
                                sSQL.Append(this.m_sit_id.ToString() + ", ");
                                sSQL.Append(this.m_pag_id.ToString() + ", ");
                                sSQL.Append(this.Language.ToString() + ", ");
                                sSQL.Append(this.ParentId.ToString() + ", ");
                                sSQL.Append(this.Order.ToString() + ", ");
                                sSQL.Append(Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem_Meta) + ", ");
                                sSQL.Append("'" + this.Name + "', ");
                                sSQL.Append("'" + this.Alias + "', ");
                                sSQL.Append("'" + this.Description + "', ");
                                sSQL.Append("'" + this.Value + "', ");
                                sSQL.Append("'" + Convert.ToString(!this.AppliesToAll ? "0" : "1") + "', ");
                                sSQL.Append("'" + Convert.ToString(!this.AppliesToChildren ? "0" : "1") + "', ");
                                sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                sSQL.Append("0, ");
                                sSQL.Append("0)");
                                using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                                {
                                    Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                                    this.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                                }

                                ResetThis();
                                SortAll();
                            }
                            else
                            {
                                Update();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    #endregion Public Functions

                    #region Private Functions
                    private void GetById()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
                        DataTable dt = null;
                        try
                        {
                            String CacheItem = RXServer.Data.CACHEITEM_META_ID + "::TagId" + m_tag_id.ToString();
                            if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                            if (dt == null)
                            {
                                StringBuilder sSQL = new StringBuilder();
                                sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_id = " + m_tag_id.ToString());
                                using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                                {
                                    dt = oDo.GetDataTable(sSQL.ToString());
                                }
                                RXServer.Data.CacheInsert(CacheItem, dt);
                            }
                            if (dt.Rows.Count > 0)
                            {
                                DataRow dr = dt.Rows[0];
                                this.m_tag_id = Convert.ToInt32(dr["obd_id"]);
                                this.m_sta_id = Convert.ToInt32(dr["sta_id"]);
                                this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                                this.m_tag_parentid = Convert.ToInt32(dr["obd_parentid"]);
                                this.m_tag_order = Convert.ToInt32(dr["obd_order"]);
                                this.m_tag_title = Convert.ToString(dr["obd_title"]);
                                this.m_tag_alias = Convert.ToString(dr["obd_alias"]);
                                this.m_tag_description = Convert.ToString(dr["obd_description"]);
                                this.m_tag_value = Convert.ToString(dr["obd_varchar1"]);
                                this.m_tag_appliestoall = Convert.ToBoolean(dr["obd_varchar2"].ToString().Equals(String.Empty) ? false : Convert.ToBoolean(Convert.ToInt32(dr["obd_varchar2"])));
                                this.m_tag_appliestochildren = Convert.ToBoolean(dr["obd_varchar3"].ToString().Equals(String.Empty) ? false : Convert.ToBoolean(Convert.ToInt32(dr["obd_varchar3"])));
                                this.m_tag_createddate = Convert.ToDateTime(dr["obd_createddate"]);
                                this.m_tag_createdby = Convert.ToString(dr["obd_createdby"]);
                                this.m_tag_updateddate = Convert.ToDateTime(dr["obd_updateddate"]);
                                this.m_tag_updatedby = Convert.ToString(dr["obd_updatedby"]);
                                this.m_tag_hidden = Convert.ToBoolean(dr["obd_hidden"]);
                                this.m_tag_deleted = Convert.ToBoolean(dr["obd_deleted"]);
                                this.m_exists = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    private void SortAll()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::SortAll]";
                        try
                        {
                            Int32 Order = (Int32)OrderMinMax.Min;
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_deleted = 0 ORDER BY sit_id, pag_id, obd_type, obd_order");
                            using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                            {
                                DataTable dt = oDo.GetDataTable(sSQL.ToString());
                                foreach (DataRow dr in dt.Rows)
                                {
                                    StringBuilder sSQL2 = new StringBuilder();
                                    sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + Order.ToString() + " WHERE obd_id = " + dr["obd_id"].ToString());
                                    using (iCDataObject oDo2 = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                                        oDo2.ExecuteNonQuery(sSQL2.ToString());
                                    Order = Order + (Int32)OrderMinMax.Step;
                                }
                                ResetThis();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    private void DeleteRelations()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
                        try
                        {
                            // Delete SiteCollection... 
                            // not in use for Objects...

                            // Delete PageCollection...
                            // not in use for Objects...

                            // Delete TaskCollection...
                            // not in use for Objects...

                            // Delete ModuleCollection... 
                            // not in use for Objects...

                            // Delete DocumentCollection...
                            // not in use for Objects...

                            // Delete ObjectCollection...
                            // not in use for Objects...
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    #endregion Private Functions

                    #region public class GenericComparer
                    public int CompareTo(object obj, string Property)
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::CompareTo]";
                        try
                        {
                            Type type = this.GetType();
                            PropertyInfo propertie = type.GetProperty(Property);


                            Type type2 = obj.GetType();
                            PropertyInfo propertie2 = type2.GetProperty(Property);

                            object[] index = null;

                            object Obj1 = propertie.GetValue(this, index);
                            object Obj2 = propertie2.GetValue(obj, index);

                            IComparable Ic1 = (IComparable)Obj1;
                            IComparable Ic2 = (IComparable)Obj2;

                            int ret = Ic1.CompareTo(Ic2);

                            return ret;

                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                            return 0;
                        }
                    }
                    #endregion public class GenericComparer

                }

                #region public class GenericComparer

                public enum SortOrderEnum
                {
                    Ascending,
                    Descending
                }

                public enum SortParamEnum
                {
                    Id,
                    Status,
                    Language,
                    ParentId,
                    Order,
                    Name,
                    Alias,
                    Description,
                    Value,
                    CreatedDate,
                    CreatedBy,
                    UpdatedDate,
                    UpdatedBy,
                    Hidden,
                    Deleted
                }

                public class GenericComparer : IComparer
                {
                    private String _Property = null;
                    private SortOrderEnum _SortOrder = SortOrderEnum.Ascending;

                    public String SortProperty
                    {
                        get { return _Property; }
                        set { _Property = value; }
                    }

                    public SortOrderEnum SortOrder
                    {
                        get { return _SortOrder; }
                        set { _SortOrder = value; }
                    }


                    public int Compare(object x, object y)
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::Compare]";
                        try
                        {
                            Tag ing1 = (Tag)x;
                            Tag ing2 = (Tag)y;

                            if (this.SortOrder.Equals(SortOrderEnum.Ascending))
                                return ing1.CompareTo(ing2, this.SortProperty);
                            else
                                return ing2.CompareTo(ing1, this.SortProperty);
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                            return 0;
                        }

                    }
                }

                public void Sort(SortParamEnum SortBy, SortOrderEnum SortOrder)
                {
                    GenericComparer comparer = new GenericComparer();
                    comparer.SortProperty = SortBy.ToString();
                    comparer.SortOrder = SortOrder;
                    this.InnerList.Sort(comparer);
                }

                #endregion public class GenericComparer
            }
            #endregion public class Meta

        }
    }
}

namespace RXServer
{
    namespace Dev
    {

        #region public class List
        /// <summary>
            /// RXServer.Web.List.Meta
            /// </summary>
            /// <example>The following is an example of initializing a 
            /// <c>RXServer.Web.List.Meta</c> type:
            ///   <code>
            /// protected void Page_Load(object sender, EventArgs e)
            /// {
            ///     if (!Page.IsPostBack)
            ///         BindData();
            /// }
            /// private void BindData()
            /// {
            ///     ListBox1.Items.Clear();
            ///     using (RXServer.Web.List.Meta m = new RXServer.Web.List.Meta(1, 1))
            ///     {
            ///         m.Sort(RXServer.Web.List.Meta.SortParamEnum.Name, RXServer.Web.List.Meta.SortOrderEnum.Ascending);
            ///         foreach (RXServer.Web.List.Meta.Tag t in m)
            ///         {
            ///             ListBox1.Items.Add(new ListItem(t.Name, t.Id.ToString()));
            ///         }
            ///     }
            /// }
            /// protected void Add_Click(object sender, EventArgs e)
            /// {
            ///     using(RXServer.Web.List.Meta m = new RXServer.Web.List.Meta(1, 1))
            ///     {
            ///         m.Add(new RXServer.Web.List.Meta.Tag(TextBox1.Text, TextBox2.Text));
            ///     }
            ///     BindData();
            /// }
            /// protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
            /// {
            ///     using (RXServer.Web.List.Meta.Tag t = new RXServer.Web.List.Meta.Tag(Convert.ToInt32(ListBox1.SelectedValue)))
            ///     {
            ///         t.Deleted = true;
            ///         t.Save();
            ///     }
            ///     BindData();
            /// }
            ///   </code>
            /// </example>
        public class List : CollectionBase, IDisposable
        {
            // exempel på hur man skapar en ny typ av lista
            // i detta fallet personer...
            public class Personer : List 
            {
                public Personer(Int32 SitId, Int32 PagId) : base(SitId, PagId){}
                public int Add(Person itm)
                {
                    return base.Add(itm);
                }
                public void Remove(Person itm)
                {
                    base.Remove(itm);
                }
                public class Person : ListItem
                {
                    public Person() : base(){}
                }
            }

            static String CLASSNAME = "[Namespace::RXServer.Dev][Class::List]";

            #region Private Variables
            private Int32 m_sit_id = 0;
            private Int32 m_pag_id = 0;
            private String m_alias = String.Empty;
            #endregion Private Variables

            #region Properties
            #endregion Properties

            #region Constructors
            public List()
            {
                GetAll();
            }
            public List(Int32 SitId)
            {
                this.m_sit_id = SitId;
                this.m_pag_id = 0;
                GetAllBySitId();
            }
            public List(Int32 SitId, Int32 PagId)
            {
                this.m_sit_id = SitId;
                this.m_pag_id = PagId;
                GetAllBySitIdPagId();
            }
            public List(Int32 SitId, Int32 PagId, String Alias)
            {
                this.m_sit_id = SitId;
                this.m_pag_id = PagId;
                this.m_alias = Alias;
                GetAllBySitIdPagIdAlias();
            }
            public List(Int32 SitId, Int32 PagId, String Alias, Int32 StartIndex, Int32 Limit, String Order)
            {
                this.m_sit_id = SitId;
                this.m_pag_id = PagId;
                this.m_alias = Alias;
                GetLimitedBySitIdPagIdAlias(StartIndex, Limit, Order);
            }
            public List(Int32 SitId, Int32 PagId, String Alias, String PreDate)
            {
                this.m_sit_id = SitId;
                this.m_pag_id = PagId;
                this.m_alias = Alias;
                GetAllBySitIdPagIdAliasPreDate(PreDate);
            }
            ~List()
            { xFinalize(); }
            public void Dispose()
            {
                xFinalize();
                System.GC.SuppressFinalize(this);
            }
            private void xFinalize()
            {
            }
            #endregion Constructors

            #region Private Functions
            private int _Add(ListItem itm)
            {
                return List.Add(itm);
            }
            private void GetAll()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
                DataTable dt = null;
                try
                {
                    String CacheItem = RXServer.Data.CACHEITEM_LIST_COLLECTION + "::All";
                    if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                    if (dt == null)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem) + " AND obd_deleted = 0");
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                        {
                            dt = oDo.GetDataTable(sSQL.ToString());
                        }
                        RXServer.Data.CacheInsert(CacheItem, dt);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListItem i = new ListItem(Convert.ToInt32(dr["obd_id"].ToString()));
                        this._Add(i);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            private void GetAllBySitId()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetAllBySitId]";
                DataTable dt = null;
                try
                {
                    String CacheItem = RXServer.Data.CACHEITEM_LIST_COLLECTION + "::SitId" + m_sit_id.ToString();
                    if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                    if (dt == null)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem) + " AND sit_id = " + m_sit_id.ToString() + " AND obd_deleted = 0");
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                        {
                            dt = oDo.GetDataTable(sSQL.ToString());
                        }
                        RXServer.Data.CacheInsert(CacheItem, dt);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListItem i = new ListItem(Convert.ToInt32(dr["obd_id"].ToString()));
                        this._Add(i);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            private void GetAllBySitIdPagId()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetAllBySitIdPagId]";
                DataTable dt = null;
                try
                {
                    String CacheItem = RXServer.Data.CACHEITEM_LIST_COLLECTION + "::SitId" + m_sit_id.ToString() + "::PagId" + m_pag_id.ToString();
                    if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                    if (dt == null)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem) + " AND sit_id = " + m_sit_id.ToString() + " AND pag_id = " + m_pag_id.ToString() + " AND obd_deleted = 0");
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                        {
                            dt = oDo.GetDataTable(sSQL.ToString());
                        }
                        RXServer.Data.CacheInsert(CacheItem, dt);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListItem i = new ListItem(Convert.ToInt32(dr["obd_id"].ToString()));
                        this._Add(i);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            private void GetAllBySitIdPagIdAlias()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetAllBySitIdPagIdAlias]";
                DataTable dt = null;
                try
                {
                    String CacheItem = RXServer.Data.CACHEITEM_LIST_COLLECTION + "::SitId" + m_sit_id.ToString() + "::PagId" + m_pag_id.ToString() + "::Alias" + m_alias;
                    if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                    if (dt == null)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem) + " AND sit_id = " + m_sit_id.ToString() + " AND pag_id = " + m_pag_id.ToString() + " AND obd_alias = '" + m_alias + "' AND obd_deleted = 0");
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                        {
                            dt = oDo.GetDataTable(sSQL.ToString());
                        }
                        RXServer.Data.CacheInsert(CacheItem, dt);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListItem i = new ListItem(Convert.ToInt32(dr["obd_id"].ToString()));
                        this._Add(i);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }

            private void GetLimitedBySitIdPagIdAlias(Int32 sIndex, Int32 limit, String orderBy)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetLimitedBySitIdPagIdAlias]";
                DataTable dt = null;
                try
                {
                    //String CacheItem = RXServer.Data.CACHEITEM_LIST_COLLECTION + "::SitId" + m_sit_id.ToString() + "::PagId" + m_pag_id.ToString() + "::Alias" + m_alias;
                    //if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                    if (dt == null)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        String _tempOrder = "";
                        if (orderBy != "")
                        {
                            _tempOrder = "ORDER BY " + orderBy;
                        }
                        sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem) + " AND sit_id = " + m_sit_id.ToString() + " AND pag_id = " + m_pag_id.ToString() + " AND obd_alias = '" + m_alias + "' AND obd_deleted = 0 " + _tempOrder + " LIMIT " + sIndex + ", " + limit);
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                        {
                            dt = oDo.GetDataTable(sSQL.ToString());
                        }
                        //RXServer.Data.CacheInsert(CacheItem, dt);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListItem i = new ListItem(Convert.ToInt32(dr["obd_id"].ToString()));
                        this._Add(i);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }

            private void GetAllBySitIdPagIdAliasPreDate(String PreDate)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetAllBySitIdPagIdAliasPreDate]";
                DataTable dt = null;
                try
                {
                    String CacheItem = RXServer.Data.CACHEITEM_LIST_COLLECTION + "::SitId" + m_sit_id.ToString() + "::PagId" + m_pag_id.ToString() + "::Alias" + m_alias + "::PreDate" + PreDate;
                    if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                    if (dt == null)
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("SELECT obd_id, obd_createddate FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem) + " AND sit_id = " + m_sit_id.ToString() + " AND pag_id = " + m_pag_id.ToString() + " AND obd_alias = '" + m_alias + "' AND obd_deleted = 0");
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                        {
                            dt = oDo.GetDataTable(sSQL.ToString());
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (!dr["obd_createddate"].ToString().Contains(PreDate))
                                    dr.Delete();
                            }
                            dt.AcceptChanges();
                        }
                        RXServer.Data.CacheInsert(CacheItem, dt);
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListItem i = new ListItem(Convert.ToInt32(dr["obd_id"].ToString()));
                        this._Add(i);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            #endregion Private Functions

            #region Public Functions
            public static void ResetThis()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
                try
                {
                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_LIST_ID);
                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_LIST_ALIAS);
                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_LIST_COLLECTION);
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                }
            }
            public virtual int Add(ListItem itm)
            {
                itm.SitId = this.m_sit_id;
                itm.PagId = this.m_pag_id;
                itm.Save();
                return List.Add(itm);
            }
            public virtual void Remove(ListItem itm)
            {
                itm.Deleted = true;
                itm.Update();
                List.Remove(itm);
            }
            public virtual ListItem this[int index]
            {
                get
                {
                    return ((ListItem)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }
            #endregion Public Functions

            public class ListItem : IDisposable
            {
                static String CLASSNAME = "[Namespace::RXServer.Dev.List][Class::ListItem]";

                #region Private Variables
                private Boolean m_exists = false;

                private Int32 m_itm_id = 0;
                private Int32 m_sit_id = 0;
                private Int32 m_pag_id = 0;
                private Int32 m_sta_id = 0;
                private Int32 m_lng_id = 0;
                private Int32 m_itm_parentid = 0;
                private Int32 m_itm_order = 0;
                private String m_itm_title = String.Empty;
                private String m_itm_alias = String.Empty;
                private String m_itm_description = String.Empty;
                private String m_itm_value1 = String.Empty;
                private String m_itm_value2 = String.Empty;
                private String m_itm_value3 = String.Empty;
                private String m_itm_value4 = String.Empty;
                private String m_itm_value5 = String.Empty;
                private String m_itm_value6 = String.Empty;
                private String m_itm_value7 = String.Empty;
                private String m_itm_value8 = String.Empty;
                private String m_itm_value9 = String.Empty;
                private String m_itm_value10 = String.Empty;
                private String m_itm_value11 = String.Empty;
                private String m_itm_value12 = String.Empty;
                private String m_itm_value13 = String.Empty;
                private String m_itm_value14 = String.Empty;
                private String m_itm_value15 = String.Empty;
                private String m_itm_value16 = String.Empty;
                private String m_itm_value17 = String.Empty;
                private String m_itm_value18 = String.Empty;
                private String m_itm_value19 = String.Empty;
                private String m_itm_value20 = String.Empty;
                private String m_itm_value21 = String.Empty;
                private String m_itm_value22 = String.Empty;
                private String m_itm_value23 = String.Empty;
                private String m_itm_value24 = String.Empty;
                private String m_itm_value25 = String.Empty;
                private String m_itm_value26 = String.Empty;
                private String m_itm_value27 = String.Empty;
                private String m_itm_value28 = String.Empty;
                private String m_itm_value29 = String.Empty;
                private String m_itm_value30 = String.Empty;
                private String m_itm_value31 = String.Empty;
                private String m_itm_value32 = String.Empty;
                private String m_itm_value33 = String.Empty;
                private String m_itm_value34 = String.Empty;
                private String m_itm_value35 = String.Empty;
                private String m_itm_value36 = String.Empty;
                private String m_itm_value37 = String.Empty;
                private String m_itm_value38 = String.Empty;
                private String m_itm_value39 = String.Empty;
                private String m_itm_value40 = String.Empty;
                private String m_itm_value41 = String.Empty;
                private String m_itm_value42 = String.Empty;
                private String m_itm_value43 = String.Empty;
                private String m_itm_value44 = String.Empty;
                private String m_itm_value45 = String.Empty;
                private String m_itm_value46 = String.Empty;
                private String m_itm_value47 = String.Empty;
                private String m_itm_value48 = String.Empty;
                private String m_itm_value49 = String.Empty;
                private String m_itm_value50 = String.Empty;
                private DateTime m_itm_createddate = DateTime.Now;
                private String m_itm_createdby = String.Empty;
                private DateTime m_itm_updateddate = DateTime.Now;
                private String m_itm_updatedby = String.Empty;
                private Boolean m_itm_hidden = false;
                private Boolean m_itm_deleted = false;
                #endregion Private Variables

                #region Properties

                public Boolean Exist
                {
                    get
                    {
                        return this.m_exists;
                    }
                    set
                    {
                        this.m_exists = value;
                    }
                }
                public Int32 SitId
                {
                    get
                    {
                        return this.m_sit_id;
                    }
                    set
                    {
                        this.m_sit_id = value;
                    }
                }
                public Int32 PagId
                {
                    get
                    {
                        return this.m_pag_id;
                    }
                    set
                    {
                        this.m_pag_id = value;
                    }
                }
                public Int32 Id
                {
                    get
                    {
                        return this.m_itm_id;
                    }
                    set
                    {
                        this.m_itm_id = value;
                    }
                }
                public Int32 Status
                {
                    get
                    {
                        return this.m_sta_id;
                    }
                    set
                    {
                        this.m_sta_id = value;
                    }
                }
                public Int32 Language
                {
                    get
                    {
                        return this.m_lng_id;
                    }
                    set
                    {
                        this.m_lng_id = value;
                    }
                }
                public Int32 ParentId
                {
                    get
                    {
                        return this.m_itm_parentid;
                    }
                    set
                    {
                        this.m_itm_parentid = value;
                    }
                }
                public Int32 Order
                {
                    get
                    {
                        return this.m_itm_order;
                    }
                    set
                    {
                        this.m_itm_order = value;
                    }
                }
                public String Name
                {
                    get
                    {
                        return this.m_itm_title;
                    }
                    set
                    {
                        this.m_itm_title = Common.SafeString(value);
                    }
                }
                public String Alias
                {
                    get
                    {
                        return this.m_itm_alias;
                    }
                    set
                    {
                        this.m_itm_alias = Common.SafeString(value);
                    }
                }
                public String Description
                {
                    get
                    {
                        return this.m_itm_description;
                    }
                    set
                    {
                        this.m_itm_description = Common.SafeString(value);
                    }
                }
                public String Value1
                {
                    get
                    {
                        return this.m_itm_value1;
                    }
                    set
                    {
                        this.m_itm_value1 = Common.SafeString(value);
                    }
                }
                public String Value2
                {
                    get
                    {
                        return this.m_itm_value2;
                    }
                    set
                    {
                        this.m_itm_value2 = Common.SafeString(value);
                    }
                }
                public String Value3
                {
                    get
                    {
                        return this.m_itm_value3;
                    }
                    set
                    {
                        this.m_itm_value3 = Common.SafeString(value);
                    }
                }
                public String Value4
                {
                    get
                    {
                        return this.m_itm_value4;
                    }
                    set
                    {
                        this.m_itm_value4 = Common.SafeString(value);
                    }
                }
                public String Value5
                {
                    get
                    {
                        return this.m_itm_value5;
                    }
                    set
                    {
                        this.m_itm_value5 = Common.SafeString(value);
                    }
                }
                public String Value6
                {
                    get
                    {
                        return this.m_itm_value6;
                    }
                    set
                    {
                        this.m_itm_value6 = Common.SafeString(value);
                    }
                }
                public String Value7
                {
                    get
                    {
                        return this.m_itm_value7;
                    }
                    set
                    {
                        this.m_itm_value7 = Common.SafeString(value);
                    }
                }
                public String Value8
                {
                    get
                    {
                        return this.m_itm_value8;
                    }
                    set
                    {
                        this.m_itm_value8 = Common.SafeString(value);
                    }
                }
                public String Value9
                {
                    get
                    {
                        return this.m_itm_value9;
                    }
                    set
                    {
                        this.m_itm_value9 = Common.SafeString(value);
                    }
                }
                public String Value10
                {
                    get
                    {
                        return this.m_itm_value10;
                    }
                    set
                    {
                        this.m_itm_value10 = Common.SafeString(value);
                    }
                }
                public String Value11
                {
                    get
                    {
                        return this.m_itm_value11;
                    }
                    set
                    {
                        this.m_itm_value11 = Common.SafeString(value);
                    }
                }
                public String Value12
                {
                    get
                    {
                        return this.m_itm_value12;
                    }
                    set
                    {
                        this.m_itm_value12 = Common.SafeString(value);
                    }
                }
                public String Value13
                {
                    get
                    {
                        return this.m_itm_value13;
                    }
                    set
                    {
                        this.m_itm_value13 = Common.SafeString(value);
                    }
                }
                public String Value14
                {
                    get
                    {
                        return this.m_itm_value14;
                    }
                    set
                    {
                        this.m_itm_value14 = Common.SafeString(value);
                    }
                }
                public String Value15
                {
                    get
                    {
                        return this.m_itm_value15;
                    }
                    set
                    {
                        this.m_itm_value15 = Common.SafeString(value);
                    }
                }
                public String Value16
                {
                    get
                    {
                        return this.m_itm_value16;
                    }
                    set
                    {
                        this.m_itm_value16 = Common.SafeString(value);
                    }
                }
                public String Value17
                {
                    get
                    {
                        return this.m_itm_value17;
                    }
                    set
                    {
                        this.m_itm_value17 = Common.SafeString(value);
                    }
                }
                public String Value18
                {
                    get
                    {
                        return this.m_itm_value18;
                    }
                    set
                    {
                        this.m_itm_value18 = Common.SafeString(value);
                    }
                }
                public String Value19
                {
                    get
                    {
                        return this.m_itm_value19;
                    }
                    set
                    {
                        this.m_itm_value19 = Common.SafeString(value);
                    }
                }
                public String Value20
                {
                    get
                    {
                        return this.m_itm_value20;
                    }
                    set
                    {
                        this.m_itm_value20 = Common.SafeString(value);
                    }
                }
                public String Value21
                {
                    get
                    {
                        return this.m_itm_value21;
                    }
                    set
                    {
                        this.m_itm_value21 = Common.SafeString(value);
                    }
                }
                public String Value22
                {
                    get
                    {
                        return this.m_itm_value22;
                    }
                    set
                    {
                        this.m_itm_value22 = Common.SafeString(value);
                    }
                }
                public String Value23
                {
                    get
                    {
                        return this.m_itm_value23;
                    }
                    set
                    {
                        this.m_itm_value23 = Common.SafeString(value);
                    }
                }
                public String Value24
                {
                    get
                    {
                        return this.m_itm_value24;
                    }
                    set
                    {
                        this.m_itm_value24 = Common.SafeString(value);
                    }
                }
                public String Value25
                {
                    get
                    {
                        return this.m_itm_value25;
                    }
                    set
                    {
                        this.m_itm_value25 = Common.SafeString(value);
                    }
                }
                public String Value26
                {
                    get
                    {
                        return this.m_itm_value26;
                    }
                    set
                    {
                        this.m_itm_value26 = Common.SafeString(value);
                    }
                }
                public String Value27
                {
                    get
                    {
                        return this.m_itm_value27;
                    }
                    set
                    {
                        this.m_itm_value27 = Common.SafeString(value);
                    }
                }
                public String Value28
                {
                    get
                    {
                        return this.m_itm_value28;
                    }
                    set
                    {
                        this.m_itm_value28 = Common.SafeString(value);
                    }
                }
                public String Value29
                {
                    get
                    {
                        return this.m_itm_value29;
                    }
                    set
                    {
                        this.m_itm_value29 = Common.SafeString(value);
                    }
                }
                public String Value30
                {
                    get
                    {
                        return this.m_itm_value30;
                    }
                    set
                    {
                        this.m_itm_value30 = Common.SafeString(value);
                    }
                }
                public String Value31
                {
                    get
                    {
                        return this.m_itm_value31;
                    }
                    set
                    {
                        this.m_itm_value31 = Common.SafeString(value);
                    }
                }
                public String Value32
                {
                    get
                    {
                        return this.m_itm_value32;
                    }
                    set
                    {
                        this.m_itm_value32 = Common.SafeString(value);
                    }
                }
                public String Value33
                {
                    get
                    {
                        return this.m_itm_value33;
                    }
                    set
                    {
                        this.m_itm_value33 = Common.SafeString(value);
                    }
                }
                public String Value34
                {
                    get
                    {
                        return this.m_itm_value34;
                    }
                    set
                    {
                        this.m_itm_value34 = Common.SafeString(value);
                    }
                }
                public String Value35
                {
                    get
                    {
                        return this.m_itm_value35;
                    }
                    set
                    {
                        this.m_itm_value35 = Common.SafeString(value);
                    }
                }
                public String Value36
                {
                    get
                    {
                        return this.m_itm_value36;
                    }
                    set
                    {
                        this.m_itm_value36 = Common.SafeString(value);
                    }
                }
                public String Value37
                {
                    get
                    {
                        return this.m_itm_value37;
                    }
                    set
                    {
                        this.m_itm_value37 = Common.SafeString(value);
                    }
                }
                public String Value38
                {
                    get
                    {
                        return this.m_itm_value38;
                    }
                    set
                    {
                        this.m_itm_value38 = Common.SafeString(value);
                    }
                }
                public String Value39
                {
                    get
                    {
                        return this.m_itm_value39;
                    }
                    set
                    {
                        this.m_itm_value39 = Common.SafeString(value);
                    }
                }
                public String Value40
                {
                    get
                    {
                        return this.m_itm_value40;
                    }
                    set
                    {
                        this.m_itm_value40 = Common.SafeString(value);
                    }
                }
                public String Value41
                {
                    get
                    {
                        return this.m_itm_value41;
                    }
                    set
                    {
                        this.m_itm_value41 = Common.SafeString(value);
                    }
                }
                public String Value42
                {
                    get
                    {
                        return this.m_itm_value42;
                    }
                    set
                    {
                        this.m_itm_value42 = Common.SafeString(value);
                    }
                }
                public String Value43
                {
                    get
                    {
                        return this.m_itm_value43;
                    }
                    set
                    {
                        this.m_itm_value43 = Common.SafeString(value);
                    }
                }
                public String Value44
                {
                    get
                    {
                        return this.m_itm_value44;
                    }
                    set
                    {
                        this.m_itm_value44 = Common.SafeString(value);
                    }
                }
                public String Value45
                {
                    get
                    {
                        return this.m_itm_value45;
                    }
                    set
                    {
                        this.m_itm_value45 = Common.SafeString(value);
                    }
                }
                public String Value46
                {
                    get
                    {
                        return this.m_itm_value46;
                    }
                    set
                    {
                        this.m_itm_value46 = Common.SafeString(value);
                    }
                }
                public String Value47
                {
                    get
                    {
                        return this.m_itm_value47;
                    }
                    set
                    {
                        this.m_itm_value47 = Common.SafeString(value);
                    }
                }
                public String Value48
                {
                    get
                    {
                        return this.m_itm_value48;
                    }
                    set
                    {
                        this.m_itm_value48 = Common.SafeString(value);
                    }
                }
                public String Value49
                {
                    get
                    {
                        return this.m_itm_value49;
                    }
                    set
                    {
                        this.m_itm_value49 = Common.SafeString(value);
                    }
                }
                public String Value50
                {
                    get
                    {
                        return this.m_itm_value50;
                    }
                    set
                    {
                        this.m_itm_value50 = Common.SafeString(value);
                    }
                }
                public DateTime CreatedDate
                {
                    get
                    {
                        return this.m_itm_createddate;
                    }
                    set
                    {
                        this.m_itm_createddate = value;
                    }
                }
                public string CreatedBy
                {
                    get
                    {
                        return this.m_itm_createdby;
                    }
                    set
                    {
                        this.m_itm_createdby = Common.SafeString(value);
                    }
                }
                public DateTime UpdatedDate
                {
                    get
                    {
                        return this.m_itm_updateddate;
                    }
                    set
                    {
                        this.m_itm_updateddate = value;
                    }
                }
                public string UpdatedBy
                {
                    get
                    {
                        return this.m_itm_updatedby;
                    }
                    set
                    {
                        this.m_itm_updatedby = Common.SafeString(value);
                    }
                }
                public Boolean Hidden
                {
                    get
                    {
                        return this.m_itm_hidden;
                    }
                    set
                    {
                        this.m_itm_hidden = value;
                    }
                }
                public Boolean Deleted
                {
                    get
                    {
                        return this.m_itm_deleted;
                    }
                    set
                    {
                        this.m_itm_deleted = value;
                    }
                }

                #endregion Properties

                #region Constructors
                public ListItem() { }
                public ListItem(Int32 ItmId)
                {
                    m_itm_id = ItmId;
                    GetById();
                }
                ~ListItem()
                { xFinalize(); }
                public void Dispose()
                {
                    xFinalize();
                    System.GC.SuppressFinalize(this);
                }
                private void xFinalize()
                {
                }
                #endregion Constructors

                #region Public Functions
                /// <summary>
                /// Update
                /// </summary>
                public virtual void Update()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
                    try
                    {
                        if (this.m_exists)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("UPDATE obd_objectdata SET ");
                            sSQL.Append("sta_id = " + this.m_sta_id.ToString() + ", ");
                            sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                            sSQL.Append("obd_parentid = " + this.m_itm_parentid.ToString() + ", ");
                            sSQL.Append("obd_order = " + this.m_itm_order.ToString() + ", ");
                            sSQL.Append("obd_title = '" + this.m_itm_title.ToString() + "', ");
                            sSQL.Append("obd_alias = '" + this.m_itm_alias.ToString() + "', ");
                            sSQL.Append("obd_description = '" + this.m_itm_description.ToString() + "', ");
                            sSQL.Append("obd_varchar1 = '" + this.m_itm_value1.ToString() + "', ");
                            sSQL.Append("obd_varchar2 = '" + this.m_itm_value2.ToString() + "', ");
                            sSQL.Append("obd_varchar3 = '" + this.m_itm_value3.ToString() + "', ");
                            sSQL.Append("obd_varchar4 = '" + this.m_itm_value4.ToString() + "', ");
                            sSQL.Append("obd_varchar5 = '" + this.m_itm_value5.ToString() + "', ");
                            sSQL.Append("obd_varchar6 = '" + this.m_itm_value6.ToString() + "', ");
                            sSQL.Append("obd_varchar7 = '" + this.m_itm_value7.ToString() + "', ");
                            sSQL.Append("obd_varchar8 = '" + this.m_itm_value8.ToString() + "', ");
                            sSQL.Append("obd_varchar9 = '" + this.m_itm_value9.ToString() + "', ");
                            sSQL.Append("obd_varchar10 = '" + this.m_itm_value10.ToString() + "', ");
                            sSQL.Append("obd_varchar11 = '" + this.m_itm_value11.ToString() + "', ");
                            sSQL.Append("obd_varchar12 = '" + this.m_itm_value12.ToString() + "', ");
                            sSQL.Append("obd_varchar13 = '" + this.m_itm_value13.ToString() + "', ");
                            sSQL.Append("obd_varchar14 = '" + this.m_itm_value14.ToString() + "', ");
                            sSQL.Append("obd_varchar15 = '" + this.m_itm_value15.ToString() + "', ");
                            sSQL.Append("obd_varchar16 = '" + this.m_itm_value16.ToString() + "', ");
                            sSQL.Append("obd_varchar17 = '" + this.m_itm_value17.ToString() + "', ");
                            sSQL.Append("obd_varchar18 = '" + this.m_itm_value18.ToString() + "', ");
                            sSQL.Append("obd_varchar19 = '" + this.m_itm_value19.ToString() + "', ");
                            sSQL.Append("obd_varchar20 = '" + this.m_itm_value20.ToString() + "', ");
                            sSQL.Append("obd_varchar21 = '" + this.m_itm_value21.ToString() + "', ");
                            sSQL.Append("obd_varchar22 = '" + this.m_itm_value22.ToString() + "', ");
                            sSQL.Append("obd_varchar23 = '" + this.m_itm_value23.ToString() + "', ");
                            sSQL.Append("obd_varchar24 = '" + this.m_itm_value24.ToString() + "', ");
                            sSQL.Append("obd_varchar25 = '" + this.m_itm_value25.ToString() + "', ");
                            sSQL.Append("obd_varchar26 = '" + this.m_itm_value26.ToString() + "', ");
                            sSQL.Append("obd_varchar27 = '" + this.m_itm_value27.ToString() + "', ");
                            sSQL.Append("obd_varchar28 = '" + this.m_itm_value28.ToString() + "', ");
                            sSQL.Append("obd_varchar29 = '" + this.m_itm_value29.ToString() + "', ");
                            sSQL.Append("obd_varchar30 = '" + this.m_itm_value30.ToString() + "', ");
                            sSQL.Append("obd_varchar31 = '" + this.m_itm_value31.ToString() + "', ");
                            sSQL.Append("obd_varchar32 = '" + this.m_itm_value32.ToString() + "', ");
                            sSQL.Append("obd_varchar33 = '" + this.m_itm_value33.ToString() + "', ");
                            sSQL.Append("obd_varchar34 = '" + this.m_itm_value34.ToString() + "', ");
                            sSQL.Append("obd_varchar35 = '" + this.m_itm_value35.ToString() + "', ");
                            sSQL.Append("obd_varchar36 = '" + this.m_itm_value36.ToString() + "', ");
                            sSQL.Append("obd_varchar37 = '" + this.m_itm_value37.ToString() + "', ");
                            sSQL.Append("obd_varchar38 = '" + this.m_itm_value38.ToString() + "', ");
                            sSQL.Append("obd_varchar39 = '" + this.m_itm_value39.ToString() + "', ");
                            sSQL.Append("obd_varchar40 = '" + this.m_itm_value40.ToString() + "', ");
                            sSQL.Append("obd_varchar41 = '" + this.m_itm_value41.ToString() + "', ");
                            sSQL.Append("obd_varchar42 = '" + this.m_itm_value42.ToString() + "', ");
                            sSQL.Append("obd_varchar43 = '" + this.m_itm_value43.ToString() + "', ");
                            sSQL.Append("obd_varchar44 = '" + this.m_itm_value44.ToString() + "', ");
                            sSQL.Append("obd_varchar45 = '" + this.m_itm_value45.ToString() + "', ");
                            sSQL.Append("obd_varchar46 = '" + this.m_itm_value46.ToString() + "', ");
                            sSQL.Append("obd_varchar47 = '" + this.m_itm_value47.ToString() + "', ");
                            sSQL.Append("obd_varchar48 = '" + this.m_itm_value48.ToString() + "', ");
                            sSQL.Append("obd_varchar49 = '" + this.m_itm_value49.ToString() + "', ");
                            sSQL.Append("obd_varchar50 = '" + this.m_itm_value50.ToString() + "', ");
                            sSQL.Append("obd_createddate = '" + this.m_itm_createddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                            sSQL.Append("obd_createdby = '" + this.m_itm_createdby.ToString() + "', ");
                            sSQL.Append("obd_updateddate = '" + this.m_itm_updateddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                            sSQL.Append("obd_updatedby = '" + this.m_itm_updatedby.ToString() + "', ");
                            sSQL.Append("obd_hidden = " + Convert.ToString(!this.m_itm_hidden ? "0" : "1") + ", ");
                            sSQL.Append("obd_deleted = " + Convert.ToString(!this.m_itm_deleted ? "0" : "1") + " ");
                            sSQL.Append("WHERE obd_id = " + m_itm_id.ToString());
                            using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                                oDo.ExecuteNonQuery(sSQL.ToString());

                            ResetThis();
                            SortAll();

                            if (this.m_itm_deleted)
                                DeleteRelations();
                        }
                        else
                        {
                            Save();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                /// <summary>
                /// Save
                /// </summary>
                public virtual void Save()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        if (!this.m_exists)
                        {
                            DataSet ds = new DataSet();
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("INSERT INTO obd_objectdata (sta_id, sit_id, pag_id, lng_id, obd_parentid, obd_order, obd_type, obd_title, obd_alias, obd_description, obd_varchar1, obd_varchar2, obd_varchar3, obd_varchar4, obd_varchar5, obd_varchar6, obd_varchar7, obd_varchar8, obd_varchar9, obd_varchar10, obd_varchar11, obd_varchar12, obd_varchar13, obd_varchar14, obd_varchar15, obd_varchar16, obd_varchar17, obd_varchar18, obd_varchar19, obd_varchar20, obd_varchar21, obd_varchar22, obd_varchar23, obd_varchar24, obd_varchar25, obd_varchar26, obd_varchar27, obd_varchar28, obd_varchar29, obd_varchar30, obd_varchar31, obd_varchar32, obd_varchar33, obd_varchar34, obd_varchar35, obd_varchar36, obd_varchar37, obd_varchar38, obd_varchar39, obd_varchar40, obd_varchar41, obd_varchar42, obd_varchar43, obd_varchar44, obd_varchar45, obd_varchar46, obd_varchar47, obd_varchar48, obd_varchar49, obd_varchar50, obd_createddate, obd_createdby, obd_updateddate, obd_updatedby, obd_hidden, obd_deleted) VALUES ( ");
                            sSQL.Append(this.Status.ToString() + ", ");
                            sSQL.Append(this.m_sit_id.ToString() + ", ");
                            sSQL.Append(this.m_pag_id.ToString() + ", ");
                            sSQL.Append(this.Language.ToString() + ", ");
                            sSQL.Append(this.ParentId.ToString() + ", ");
                            sSQL.Append(this.Order.ToString() + ", ");
                            sSQL.Append(Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_ListItem) + ", ");
                            sSQL.Append("'" + this.Name + "', ");
                            sSQL.Append("'" + this.Alias + "', ");
                            sSQL.Append("'" + this.Description + "', ");
                            sSQL.Append("'" + this.Value1 + "', ");
                            sSQL.Append("'" + this.Value2 + "', ");
                            sSQL.Append("'" + this.Value3 + "', ");
                            sSQL.Append("'" + this.Value4 + "', ");
                            sSQL.Append("'" + this.Value5 + "', ");
                            sSQL.Append("'" + this.Value6 + "', ");
                            sSQL.Append("'" + this.Value7 + "', ");
                            sSQL.Append("'" + this.Value8 + "', ");
                            sSQL.Append("'" + this.Value9 + "', ");
                            sSQL.Append("'" + this.Value10 + "', ");
                            sSQL.Append("'" + this.Value11 + "', ");
                            sSQL.Append("'" + this.Value12 + "', ");
                            sSQL.Append("'" + this.Value13 + "', ");
                            sSQL.Append("'" + this.Value14 + "', ");
                            sSQL.Append("'" + this.Value15 + "', ");
                            sSQL.Append("'" + this.Value16 + "', ");
                            sSQL.Append("'" + this.Value17 + "', ");
                            sSQL.Append("'" + this.Value18 + "', ");
                            sSQL.Append("'" + this.Value19 + "', ");
                            sSQL.Append("'" + this.Value20 + "', ");
                            sSQL.Append("'" + this.Value21 + "', ");
                            sSQL.Append("'" + this.Value22 + "', ");
                            sSQL.Append("'" + this.Value23 + "', ");
                            sSQL.Append("'" + this.Value24 + "', ");
                            sSQL.Append("'" + this.Value25 + "', ");
                            sSQL.Append("'" + this.Value26 + "', ");
                            sSQL.Append("'" + this.Value27 + "', ");
                            sSQL.Append("'" + this.Value28 + "', ");
                            sSQL.Append("'" + this.Value29 + "', ");
                            sSQL.Append("'" + this.Value30 + "', ");
                            sSQL.Append("'" + this.Value31 + "', ");
                            sSQL.Append("'" + this.Value32 + "', ");
                            sSQL.Append("'" + this.Value33 + "', ");
                            sSQL.Append("'" + this.Value34 + "', ");
                            sSQL.Append("'" + this.Value35 + "', ");
                            sSQL.Append("'" + this.Value36 + "', ");
                            sSQL.Append("'" + this.Value37 + "', ");
                            sSQL.Append("'" + this.Value38 + "', ");
                            sSQL.Append("'" + this.Value39 + "', ");
                            sSQL.Append("'" + this.Value40 + "', ");
                            sSQL.Append("'" + this.Value41 + "', ");
                            sSQL.Append("'" + this.Value42 + "', ");
                            sSQL.Append("'" + this.Value43 + "', ");
                            sSQL.Append("'" + this.Value44 + "', ");
                            sSQL.Append("'" + this.Value45 + "', ");
                            sSQL.Append("'" + this.Value46 + "', ");
                            sSQL.Append("'" + this.Value47 + "', ");
                            sSQL.Append("'" + this.Value48 + "', ");
                            sSQL.Append("'" + this.Value49 + "', ");
                            sSQL.Append("'" + this.Value50 + "', ");
                            sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                            if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                            sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                            if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                            sSQL.Append("0, ");
                            sSQL.Append("0)");
                            using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                            {
                                Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                                this.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                            }

                            this.m_exists = true;
                            ResetThis();
                            SortAll();
                        }
                        else
                        {
                            Update();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                public void ChangeOrderUp()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderUp]";
                    try
                    {
                        this.m_itm_order = this.m_itm_order + 3;
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + this.m_itm_order.ToString() + " WHERE obd_id = " + this.m_itm_id.ToString());
                        using (iCDataObject oDo2 = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                            oDo2.ExecuteNonQuery(sSQL2.ToString());
                        SortAll();
                        GetById();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                public void ChangeOrderDown()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderDown]";
                    try
                    {
                        if (this.m_itm_order > 2)
                        {
                            this.m_itm_order = this.m_itm_order - 3;
                            StringBuilder sSQL2 = new StringBuilder();
                            sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + this.m_itm_order.ToString() + " WHERE obd_id = " + this.m_itm_id.ToString());
                            using (iCDataObject oDo2 = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                                oDo2.ExecuteNonQuery(sSQL2.ToString());
                            SortAll();
                            GetById();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                #endregion Public Functions

                #region Private Functions
                private void GetById()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
                    DataTable dt = null;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_LIST_ID + "::ItmId" + m_itm_id.ToString();
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_id = " + m_itm_id.ToString());
                            using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            this.m_itm_id = Convert.ToInt32(dr["obd_id"]);
                            this.m_sta_id = Convert.ToInt32(dr["sta_id"]);
                            this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                            this.m_itm_parentid = Convert.ToInt32(dr["obd_parentid"]);
                            this.m_itm_order = Convert.ToInt32(dr["obd_order"]);
                            this.m_itm_title = Convert.ToString(dr["obd_title"]);
                            this.m_itm_alias = Convert.ToString(dr["obd_alias"]);
                            this.m_itm_description = Convert.ToString(dr["obd_description"]);
                            this.m_itm_value1 = Convert.ToString(dr["obd_varchar1"]);
                            this.m_itm_value2 = Convert.ToString(dr["obd_varchar2"]);
                            this.m_itm_value3 = Convert.ToString(dr["obd_varchar3"]);
                            this.m_itm_value4 = Convert.ToString(dr["obd_varchar4"]);
                            this.m_itm_value5 = Convert.ToString(dr["obd_varchar5"]);
                            this.m_itm_value6 = Convert.ToString(dr["obd_varchar6"]);
                            this.m_itm_value7 = Convert.ToString(dr["obd_varchar7"]);
                            this.m_itm_value8 = Convert.ToString(dr["obd_varchar8"]);
                            this.m_itm_value9 = Convert.ToString(dr["obd_varchar9"]);
                            this.m_itm_value10 = Convert.ToString(dr["obd_varchar10"]);
                            this.m_itm_value11 = Convert.ToString(dr["obd_varchar11"]);
                            this.m_itm_value12 = Convert.ToString(dr["obd_varchar12"]);
                            this.m_itm_value13 = Convert.ToString(dr["obd_varchar13"]);
                            this.m_itm_value14 = Convert.ToString(dr["obd_varchar14"]);
                            this.m_itm_value15 = Convert.ToString(dr["obd_varchar15"]);
                            this.m_itm_value16 = Convert.ToString(dr["obd_varchar16"]);
                            this.m_itm_value17 = Convert.ToString(dr["obd_varchar17"]);
                            this.m_itm_value18 = Convert.ToString(dr["obd_varchar18"]);
                            this.m_itm_value19 = Convert.ToString(dr["obd_varchar19"]);
                            this.m_itm_value20 = Convert.ToString(dr["obd_varchar20"]);
                            this.m_itm_value21 = Convert.ToString(dr["obd_varchar21"]);
                            this.m_itm_value22 = Convert.ToString(dr["obd_varchar22"]);
                            this.m_itm_value23 = Convert.ToString(dr["obd_varchar23"]);
                            this.m_itm_value24 = Convert.ToString(dr["obd_varchar24"]);
                            this.m_itm_value25 = Convert.ToString(dr["obd_varchar25"]);
                            this.m_itm_value26 = Convert.ToString(dr["obd_varchar26"]);
                            this.m_itm_value27 = Convert.ToString(dr["obd_varchar27"]);
                            this.m_itm_value28 = Convert.ToString(dr["obd_varchar28"]);
                            this.m_itm_value29 = Convert.ToString(dr["obd_varchar29"]);
                            this.m_itm_value30 = Convert.ToString(dr["obd_varchar30"]);
                            this.m_itm_value31 = Convert.ToString(dr["obd_varchar31"]);
                            this.m_itm_value32 = Convert.ToString(dr["obd_varchar32"]);
                            this.m_itm_value33 = Convert.ToString(dr["obd_varchar33"]);
                            this.m_itm_value34 = Convert.ToString(dr["obd_varchar34"]);
                            this.m_itm_value35 = Convert.ToString(dr["obd_varchar35"]);
                            this.m_itm_value36 = Convert.ToString(dr["obd_varchar36"]);
                            this.m_itm_value37 = Convert.ToString(dr["obd_varchar37"]);
                            this.m_itm_value38 = Convert.ToString(dr["obd_varchar38"]);
                            this.m_itm_value39 = Convert.ToString(dr["obd_varchar39"]);
                            this.m_itm_value40 = Convert.ToString(dr["obd_varchar40"]);
                            this.m_itm_value41 = Convert.ToString(dr["obd_varchar41"]);
                            this.m_itm_value42 = Convert.ToString(dr["obd_varchar42"]);
                            this.m_itm_value43 = Convert.ToString(dr["obd_varchar43"]);
                            this.m_itm_value44 = Convert.ToString(dr["obd_varchar44"]);
                            this.m_itm_value45 = Convert.ToString(dr["obd_varchar45"]);
                            this.m_itm_value46 = Convert.ToString(dr["obd_varchar46"]);
                            this.m_itm_value47 = Convert.ToString(dr["obd_varchar47"]);
                            this.m_itm_value48 = Convert.ToString(dr["obd_varchar48"]);
                            this.m_itm_value49 = Convert.ToString(dr["obd_varchar49"]);
                            this.m_itm_value50 = Convert.ToString(dr["obd_varchar50"]);
                            this.m_itm_createddate = Convert.ToDateTime(dr["obd_createddate"]);
                            this.m_itm_createdby = Convert.ToString(dr["obd_createdby"]);
                            this.m_itm_updateddate = Convert.ToDateTime(dr["obd_updateddate"]);
                            this.m_itm_updatedby = Convert.ToString(dr["obd_updatedby"]);
                            this.m_itm_hidden = Convert.ToBoolean(dr["obd_hidden"]);
                            this.m_itm_deleted = Convert.ToBoolean(dr["obd_deleted"]);
                            this.m_exists = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                private void SortAll()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::SortAll]";
                    try
                    {
                        Int32 Order = (Int32)OrderMinMax.Min;
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_deleted = 0 ORDER BY sta_id, lng_id, sit_id, pag_id, mod_id, obd_parentid, obd_type, obd_alias, obd_order");
                        using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                        {
                            DataTable dt = oDo.GetDataTable(sSQL.ToString());
                            foreach (DataRow dr in dt.Rows)
                            {
                                StringBuilder sSQL2 = new StringBuilder();
                                sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + Order.ToString() + " WHERE obd_id = " + dr["obd_id"].ToString());
                                using (iCDataObject oDo2 = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                                    oDo2.ExecuteNonQuery(sSQL2.ToString());
                                Order = Order + (Int32)OrderMinMax.Step;
                            }
                            ResetThis();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                private void DeleteRelations()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
                    try
                    {
                        // Delete SiteCollection... 
                        // not in use for Objects...

                        // Delete PageCollection...
                        // not in use for Objects...

                        // Delete TaskCollection...
                        // not in use for Objects...

                        // Delete ModuleCollection... 
                        // not in use for Objects...

                        // Delete DocumentCollection...
                        // not in use for Objects...

                        // Delete ObjectCollection...
                        // not in use for Objects...
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                #endregion Private Functions

                #region public class GenericComparer
                public int CompareTo(object obj, string Property)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::CompareTo]";
                    try
                    {
                        Type type = this.GetType();
                        PropertyInfo propertie = type.GetProperty(Property);


                        Type type2 = obj.GetType();
                        PropertyInfo propertie2 = type2.GetProperty(Property);

                        object[] index = null;

                        object Obj1 = propertie.GetValue(this, index);
                        object Obj2 = propertie2.GetValue(obj, index);

                        IComparable Ic1 = (IComparable)Obj1;
                        IComparable Ic2 = (IComparable)Obj2;

                        int ret = Ic1.CompareTo(Ic2);

                        return ret;

                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return 0;
                    }
                }
                #endregion public class GenericComparer

            }

            #region public class GenericComparer

            public enum SortOrderEnum
            {
                Ascending,
                Descending
            }

            public enum SortParamEnum
            {
                Id,
                Status,
                Language,
                ParentId,
                Order,
                Name,
                Alias,
                Description,
                Value1,
                Value2,
                Value3,
                Value4,
                Value5,
                Value6,
                Value7,
                Value8,
                Value9,
                Value10,
                Value11,
                Value12,
                Value13,
                Value14,
                Value15,
                Value16,
                Value17,
                Value18,
                Value19,
                Value20,
                Value21,
                Value22,
                Value23,
                Value24,
                Value25,
                Value26,
                Value27,
                Value28,
                Value29,
                Value30,
                Value31,
                Value32,
                Value33,
                Value34,
                Value35,
                Value36,
                Value37,
                Value38,
                Value39,
                Value40,
                Value41,
                Value42,
                Value43,
                Value44,
                Value45,
                Value46,
                Value47,
                Value48,
                Value49,
                Value50,
                CreatedDate,
                CreatedBy,
                UpdatedDate,
                UpdatedBy,
                Hidden,
                Deleted
            }

            public class GenericComparer : IComparer
            {
                private String _Property = null;
                private SortOrderEnum _SortOrder = SortOrderEnum.Ascending;

                public String SortProperty
                {
                    get { return _Property; }
                    set { _Property = value; }
                }

                public SortOrderEnum SortOrder
                {
                    get { return _SortOrder; }
                    set { _SortOrder = value; }
                }


                public int Compare(object x, object y)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Compare]";
                    try
                    {
                        ListItem ing1 = (ListItem)x;
                        ListItem ing2 = (ListItem)y;

                        if (this.SortOrder.Equals(SortOrderEnum.Ascending))
                            return ing1.CompareTo(ing2, this.SortProperty);
                        else
                            return ing2.CompareTo(ing1, this.SortProperty);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return 0;
                    }

                }
            }

            public void Sort(SortParamEnum SortBy, SortOrderEnum SortOrder)
            {
                GenericComparer comparer = new GenericComparer();
                comparer.SortProperty = SortBy.ToString();
                comparer.SortOrder = SortOrder;
                this.InnerList.Sort(comparer);
            }

            #endregion public class GenericComparer
        }
        #endregion public class List

    }
}