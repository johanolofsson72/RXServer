using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using iConsulting.iCDataHandler;
using RXServer.Web.Model;

namespace RXServer
{
    namespace Web
    {
        namespace Menus
        {

            #region public class Menu

            /// <summary>
            /// RXServer.Web.Menus.Menu m = (RXServer.Web.Menus.Menu)this.RXMenu;
            /// </summary>

            [Serializable]
            public class Menu : IDisposable, IEnumerable
            {
                string CLASSNAME = "[Namespace::RXServer][Class::Menu]";

                #region DataHandler Variables

                private string m_datasource;
                private string m_connectionstring;

                #endregion DataHandler Variables

                #region Private Variables

                private MenuItem m_menuitem;
                private MenuItem[] m_menuitems = new MenuItem[0];
                private Int32 m_sit_id;
                private Int32 m_pag_parentid;
                private Int32 m_selectedid = 0;
                private Boolean m_autoupdate;
                private Boolean m_includehidden;
                private DataTable m_dtmenuitems;
                private Boolean m_refresh;
                private MenuSettings m_settings;

                #endregion Private Variables

                #region Properties


                public IEnumerator GetEnumerator()
                {
                    return new RXMenuItemEnum(this.m_menuitems);
                }

                public MenuItem this[Int32 index]
                {
                    get
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::MenuItem]";
                        try
                        {
                            this.m_menuitem = (MenuItem)this.m_menuitems[index];
                            return this.m_menuitem;
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                            return new MenuItem(this.m_sit_id, 0);
                        }
                    }
                }

                public MenuItem[] Items
                {
                    get
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::MenuItem]";
                        try
                        {
                            return this.m_menuitems;
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                            return new MenuItem[0];
                        }
                    }
                }

                public MenuItem GetMenuItem(Int32 Id)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetMenuItem]";
                    try
                    {
                        foreach (MenuItem m in this.m_menuitems)
                        {
                            if (m.Id == Id)
                            {
                                return m;
                            }
                        }
                        return new MenuItem(this.m_sit_id, 0);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return new MenuItem(this.m_sit_id, 0);
                    }
                }

                public bool Contains(Int32 Id)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
                    try
                    {
                        foreach (MenuItem m in this.m_menuitems)
                        {
                            if (m.Id == Id)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return false;
                    }
                }

                public bool Contains(string Name)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
                    try
                    {
                        foreach (MenuItem m in this.m_menuitems)
                        {
                            if (m.Name.ToLower() == Name.ToLower())
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return false;
                    }
                }

                public bool Refresh
                {
                    get
                    {
                        return this.m_refresh;
                    }
                    set
                    {
                        this.m_refresh = value;
                    }
                }


                #endregion Properties

                #region Constructors

                public Menu() { }

                public Menu(Int32 SitId, Int32 PageParentId)
                {
                    this.m_datasource = RXServer.Data.DataSource;
                    this.m_connectionstring = RXServer.Data.ConnectionString;
                    this.m_sit_id = SitId;
                    this.m_pag_parentid = PageParentId;
                    this.m_autoupdate = false;
                    this.m_includehidden = false;
                    this.m_refresh = true;
                    this.m_settings = new MenuSettings(SitId, PageParentId);
                    GetAll(0);
                }
                public Menu(Int32 SitId, Int32 PageParentId, Boolean IncludeHidden)
                {
                    this.m_datasource = RXServer.Data.DataSource;
                    this.m_connectionstring = RXServer.Data.ConnectionString;
                    this.m_sit_id = SitId;
                    this.m_pag_parentid = PageParentId;
                    this.m_autoupdate = false;
                    this.m_includehidden = IncludeHidden;
                    this.m_refresh = true;
                    this.m_settings = new MenuSettings(SitId, PageParentId);
                    GetAll(0);
                }
                public Menu(Int32 SitId, Int32 PageParentId, Int32 SelectedId)
                {
                    this.m_datasource = RXServer.Data.DataSource;
                    this.m_connectionstring = RXServer.Data.ConnectionString;
                    this.m_sit_id = SitId;
                    this.m_pag_parentid = PageParentId;
                    this.m_selectedid = SelectedId;
                    this.m_autoupdate = false;
                    this.m_includehidden = false;
                    this.m_refresh = true;
                    this.m_settings = new MenuSettings(SitId, PageParentId);
                    GetAll(0);
                }
                public Menu(Int32 SitId, Int32 PageParentId, String Status)
                {
                    this.m_datasource = RXServer.Data.DataSource;
                    this.m_connectionstring = RXServer.Data.ConnectionString;
                    this.m_sit_id = SitId;
                    this.m_pag_parentid = PageParentId;
                    this.m_autoupdate = false;
                    this.m_includehidden = false;
                    this.m_refresh = true;
                    this.m_settings = new MenuSettings(SitId, PageParentId);
                    Int32 s = 0;
                    Int32.TryParse(Status, out s);
                    GetAll(s);
                }

                ~Menu()
                {
                    xFinalize();
                }
                public void Dispose()
                {
                    xFinalize();
                    System.GC.SuppressFinalize(this);
                }
                private void xFinalize()
                {
                    if (!this.Refresh)
                        ResetThis();
                    if (RXServer.Data.ActivateGC)
                        GC.Collect();
                }
                #endregion Constructors

                #region Public Methods

                public void Add(MenuItem menuitem)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
                    try
                    {
                        this.Add(ref menuitem);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                public void Add(ref MenuItem menuitem)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
                    try
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("INSERT INTO pag_pages (sit_id, lng_id, sta_id, pag_parentid, pag_order, ");
                        sSQL.Append("pag_title, pag_alias, pag_description, pag_theme, pag_skin, pag_createddate, ");
                        sSQL.Append("pag_createdby, pag_updateddate, pag_updatedby, ");
                        sSQL.Append("pag_hidden, pag_deleted) VALUES (");
                        sSQL.Append(menuitem.SiteId.ToString() + ", ");
                        sSQL.Append(menuitem.Language.ToString() + ", ");
                        sSQL.Append(menuitem.Status.ToString() + ", ");
                        sSQL.Append(menuitem.ParentId.ToString() + ", ");
                        sSQL.Append(menuitem.Order.ToString() + ", ");
                        sSQL.Append("'" + menuitem.Name + "', ");
                        sSQL.Append("'" + menuitem.Alias + "', ");
                        sSQL.Append("'" + menuitem.Description + "', ");
                        sSQL.Append("'" + menuitem.Theme + "', ");
                        sSQL.Append("'" + menuitem.Skin + "', ");
                        sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append(menuitem.Hidden + ",");
                        sSQL.Append("0)");
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        {
                            oDo.ExecuteNonQuery(sSQL.ToString());
                            menuitem.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                        }

                        foreach (Int32 r in menuitem.AuthorizedEditRoles)
                        {
                            sSQL = new StringBuilder();
                            sSQL.Append("INSERT INTO apr_authorizedpagesroles (pag_id, rol_id, apr_createddate, apr_createdby, apr_updateddate, apr_updatedby, apr_hidden, apr_deleted) VALUES ( ");
                            sSQL.Append(menuitem.Id.ToString() + ", ");
                            sSQL.Append(r.ToString() + ", ");
                            sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                            if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                            sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                            if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                            sSQL.Append("0, ");
                            sSQL.Append("0)");
                            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                oDo.ExecuteNonQuery(sSQL.ToString());
                        }

                        foreach (Int32 g in menuitem.AuthorizedEditGroups)
                        {
                            sSQL = new StringBuilder();
                            sSQL.Append("INSERT INTO apg_authorizedpagesgroups (pag_id, grp_id, apg_createddate, apg_createdby, apg_updateddate, apg_updatedby, apg_hidden, apg_deleted) VALUES ( ");
                            sSQL.Append(menuitem.Id.ToString() + ", ");
                            sSQL.Append(g.ToString() + ", ");
                            sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                            if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                            sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                            if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                            sSQL.Append("0, ");
                            sSQL.Append("0)");
                            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                oDo.ExecuteNonQuery(sSQL.ToString());
                        }

                        SortAll();
                        GetAll(0);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }

                public void Remove(MenuItem menuitem)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
                    try
                    {
                        this.Remove(menuitem.Id);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }

                public void Remove(Int32 id)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
                    try
                    {
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("UPDATE pag_pages SET pag_deleted = 1 ");
                        sSQL.Append("WHERE pag_id = " + id.ToString());
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                        SortAll();
                        GetAll(0);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }

                public void Clear()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Clear]";
                    try
                    {
                        this.m_menuitems = null;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }

                public Int32 Count()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Count]";
                    try
                    {
                        return this.m_menuitems.Length;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return 0;
                    }
                }

                public DataTable DataTable()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
                    try
                    {
                        return m_dtmenuitems;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return new DataTable();
                    }
                }

                public DataTable DataTable(PageSortField SortField, SortOrder SortOrder)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
                    try
                    {
                        DataView v = new DataView(m_dtmenuitems);
                        v.Sort = RetriveSortField(SortField) + Convert.ToString((Int32)SortOrder == 1 ? String.Empty : " DESC");
                        return v.ToTable();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return new DataTable();
                    }
                }

                #endregion Public Methods

                #region Private Methods

                private void ResetThis()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
                    try
                    {
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ID);
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ALIAS);
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_COLLECTION);
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ROLES);
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_GROUPS);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                private String RetriveSortField(PageSortField SortField)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::RetriveSortField]";
                    try
                    {

                        if ((Int32)SortField == 1) return "pag_id";
                        if ((Int32)SortField == 2) return "sit_id";
                        if ((Int32)SortField == 3) return "lng_id";
                        if ((Int32)SortField == 4) return "pag_order";
                        if ((Int32)SortField == 5) return "pag_parentid";
                        if ((Int32)SortField == 6) return "pag_title";
                        if ((Int32)SortField == 7) return "pag_alias";
                        if ((Int32)SortField == 8) return "pag_description";
                        if ((Int32)SortField == 9) return "pag_theme";
                        if ((Int32)SortField == 10) return "pag_skin";
                        if ((Int32)SortField == 11) return "pag_createddate";
                        if ((Int32)SortField == 12) return "pag_createdby";
                        if ((Int32)SortField == 13) return "pag_updateddate";
                        if ((Int32)SortField == 14) return "pag_updatedby";
                        return String.Empty;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return String.Empty;
                    }
                }
                private void GetAll(Int32 Status)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
                    DataTable dt = null;
                    if (!this.Refresh)
                        return;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_PAGE_COLLECTION + "::SitId" + this.m_sit_id.ToString() + "::PageParentId" + this.m_pag_parentid.ToString() + "::IncludeHidden" + this.m_includehidden.ToString() + "::Status" + Status.ToString();
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            if (this.m_pag_parentid == 0)
                                sSQL.Append("SELECT * FROM pag_pages WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_parentid = 0" + (!this.m_includehidden ? " AND pag_hidden = 0" : String.Empty) + (Status.Equals(0) ? String.Empty : " AND sta_id = " + Status.ToString()) + " AND pag_deleted = 0 ORDER BY pag_order");
                            else
                                sSQL.Append("SELECT * FROM pag_pages WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_parentid = " + this.m_pag_parentid.ToString() + (!this.m_includehidden ? " AND pag_hidden = 0" : String.Empty) + (Status.Equals(0) ? String.Empty : " AND sta_id = " + Status.ToString()) + " AND pag_deleted = 0 ORDER BY pag_order");
                            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            this.m_dtmenuitems = dt;
                            Int32 index = 0;
                            this.m_menuitems = new MenuItem[dt.Rows.Count];
                            foreach (DataRow dr in dt.Rows)
                            {
                                this.m_menuitems[index] = new MenuItem();
                                this.m_menuitems[index].Settings = new MenuItemSettings(Convert.ToInt32(dr["sit_id"]), Convert.ToInt32(dr["pag_id"])); 
                                this.m_menuitems[index].Id = Convert.ToInt32(dr["pag_id"]);
                                this.m_menuitems[index].SiteId = Convert.ToInt32(dr["sit_id"]);
                                this.m_menuitems[index].Language = Convert.ToInt32(dr["lng_id"]);
                                try
                                {
                                    Int32 sid = 0;
                                    Int32.TryParse(dr["sta_id"].ToString(), out sid);
                                    this.m_menuitems[index].Status = sid;
                                }
                                catch { }
                                this.m_menuitems[index].ParentId = Convert.ToInt32(dr["pag_parentid"]);
                                this.m_menuitems[index].Order = Convert.ToInt32(dr["pag_order"]);
                                this.m_menuitems[index].Name = Convert.ToString(dr["pag_title"]);
                                this.m_menuitems[index].Alias = Convert.ToString(dr["pag_alias"]);
                                this.m_menuitems[index].Description = Convert.ToString(dr["pag_description"]);
                                this.m_menuitems[index].AuthorizedEditRoles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["pag_id"]));
                                this.m_menuitems[index].AuthorizedEditGroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["pag_id"]));
                                this.m_menuitems[index].Theme = Convert.ToString(dr["pag_theme"]);
                                this.m_menuitems[index].Skin = Convert.ToString(dr["pag_skin"]);
                                this.m_menuitems[index].CreatedDate = Convert.ToDateTime(dr["pag_createddate"]);
                                this.m_menuitems[index].CreatedBy = Convert.ToString(dr["pag_createdby"]);
                                this.m_menuitems[index].UpdatedDate = Convert.ToDateTime(dr["pag_updateddate"]);
                                this.m_menuitems[index].UpdatedBy = Convert.ToString(dr["pag_updatedby"]);
                                this.m_menuitems[index].Hidden = Convert.ToBoolean(dr["pag_hidden"]);
                                this.m_menuitems[index].Deleted = Convert.ToBoolean(dr["pag_deleted"]);
                                this.m_menuitems[index].Exist = true;
                                this.m_menuitems[index].Settings.Selected = SelectedPages.IsSelected(Convert.ToInt32(dr["pag_id"]));
                                this.m_menuitems[index].Settings.Index = index;
                                this.m_menuitems[index].Settings.Placement = index.Equals(0) ? MenuItemPlacement.First : (index.Equals(this.m_menuitems.Length - 1) ? MenuItemPlacement.Last : MenuItemPlacement.Middle);  
                                index++;
                            }
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
                    if (!this.Refresh)
                        return;
                    try
                    {
                        Int32 Order = (Int32)OrderMinMax.Min;
                        StringBuilder sSQL = new StringBuilder();
                        sSQL.Append("SELECT * FROM pag_pages WHERE pag_deleted = 0 ORDER BY sit_id, sta_id, pag_parentid, pag_order");
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                        {
                            DataTable dt = oDo.GetDataTable(sSQL.ToString());
                            foreach (DataRow dr in dt.Rows)
                            {
                                StringBuilder sSQL2 = new StringBuilder();
                                sSQL2.Append("UPDATE pag_pages SET pag_order = " + Order.ToString() + " WHERE pag_id = " + dr["pag_id"].ToString());
                                using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
                private Int32[] GetAuthorizedEditRoles(Int32 PagId)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
                    Int32[] Roles;
                    DataTable dt = null;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_PAGE_ROLES + "::PagId" + PagId.ToString();
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT * FROM apr_authorizedpagesroles WHERE pag_id = " + PagId.ToString() + " AND apr_deleted = 0");
                            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        Roles = new Int32[dt.Rows.Count];
                        for (Int32 i = 0; i < dt.Rows.Count; i++)
                            Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                        return Roles;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return new Int32[0];
                    }
                }
                private Int32[] GetAuthorizedEditGroups(Int32 PagId)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
                    Int32[] Groups;
                    DataTable dt = null;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_PAGE_GROUPS + "::PagId" + PagId.ToString();
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT * FROM apg_authorizedpagesgroups WHERE pag_id = " + PagId.ToString() + " AND apg_deleted = 0");
                            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        Groups = new Int32[dt.Rows.Count];
                        for (Int32 i = 0; i < dt.Rows.Count; i++)
                            Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                        return Groups;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return new Int32[0];
                    }
                }

                #endregion Private Methods

            }
            #endregion public class PageCollection

            #region public class MenuItem
            public class MenuItem : RXServer.Page
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Menus][Class::MenuItem]";
                public MenuItemSettings Settings;

                public Menu MenuItems
                {
                    get
                    {
                        return new Menu(base.SiteId, base.Id);
                    }
                }
                public String PageTemplate
                {
                    get
                    {
                        return base.Skin;
                    }
                    set
                    {
                        base.Skin = Common.SafeString(value);
                    }
                }
                public String ImageUrl
                {
                    get
                    {
                        String[] x = base.Description.Split(';');
                        if(x.Length > 0)
                            return x[0];
                        return String.Empty;
                    }
                    set
                    {
                        String[] x = base.Description.Split(';');
                        String xValue = String.Empty;
                        if (x.Length > 2)
                            xValue = Common.SafeString(value) + ";" + x[1] + ";" + x[2];
                        else
                            xValue = Common.SafeString(value) + ";;";
                        base.Description = xValue; 
                    }
                }
                public String OverImageUrl
                {
                    get
                    {
                        String[] x = base.Description.Split(';');
                        if (x.Length > 1)
                            return x[1];
                        return String.Empty;
                    }
                    set
                    {
                        String[] x = base.Description.Split(';');
                        String xValue = String.Empty;
                        if (x.Length > 2)
                            xValue = x[0] + ";" + Common.SafeString(value) + ";" + x[2];
                        else
                            xValue = ";" + Common.SafeString(value) + ";";
                        base.Description = xValue;
                    }
                }
                public String SelectedImageUrl
                {
                    get
                    {
                        String[] x = base.Description.Split(';');
                        if (x.Length > 2)
                            return x[2];
                        return String.Empty;
                    }
                    set
                    {
                        String[] x = base.Description.Split(';');
                        String xValue = String.Empty;
                        if (x.Length > 2)
                            xValue = x[0] + ";" + x[1] + ";" + Common.SafeString(value);
                        else
                            xValue = ";;" + Common.SafeString(value);
                        base.Description = xValue;
                    }
                }
                public String ImageExtraUrl
                {
                    get { return Settings.ImageExtraUrl; }
                    set { Settings.ImageExtraUrl = value; Settings.Save(); }
                }
                public String ImageExtraOverUrl
                {
                    get { return Settings.ImageExtraOverUrl; }
                    set { Settings.ImageExtraOverUrl = value; Settings.Save(); }
                }
                public String ImageExtraText
                {
                    get { return Settings.ImageExtraText; }
                    set { Settings.ImageExtraText = value; Settings.Save(); }
                }
                public String UrlName
                {
                    get { return Settings.UrlName; }
                    set { Settings.UrlName = value; Settings.Save(); }
                }

                public Int32 Level
                {
                    get
                    {
                        if (!base.ParentId.Equals(0))
                        {
                            switch (base.Parents.Length)
                            {
                                case 1:
                                    return 2;
                                case 2:
                                    return 3;
                                case 3:
                                    return 4;
                                case 4:
                                    return 5;
                                case 5:
                                    return 6;
                                case 6:
                                    return 7;
                                case 7:
                                    return 8;
                                case 8:
                                    return 9;
                            }
                        }
                        return 1;
                    }
                }

                public MenuItem()
                    : base(RXServer.Data.DataSource, RXServer.Data.ConnectionString)
                {
                    Settings = new MenuItemSettings();
                }

                public MenuItem(String UrlName)
                    : base(UrlName, RXServer.Data.DataSource, RXServer.Data.ConnectionString, true)
                {
                    Settings = new MenuItemSettings(this.SiteId, this.Id);
                    Settings.Selected = true;
                }

                public MenuItem(Int32 SitId, Int32 PagId)
                    : base(SitId, PagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString)
                {
                    Settings = new MenuItemSettings(SitId, PagId);
                    Settings.Selected = true;
                }

                // denna används bara av RXServer.Web.Menus.MenuItem i syfte av RXServer.Web.UrlRewrite
                public MenuItem(String Alias, String DataSource, String ConnectionString)
                    : base(Alias, DataSource, ConnectionString)
                {
                    Settings = new MenuItemSettings(this.SiteId, this.Id);
                    Settings.Selected = true;
                }

                public override void Save()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        if (base.Id.Equals(0))
                        {
                            // Set the skin...
                            String NewSkin = String.Empty;
                            if (base.ParentId.Equals(0))
                            {
                                NewSkin = Model.Settings.GetLevelPageTemplate(1);
                                if (NewSkin.Length.Equals(0))
                                    base.Skin = this.PageTemplate;
                                else
                                    base.Skin = NewSkin;

                            }
                            else
                            {
                                using (Menus.MenuItem m = new Menus.MenuItem(CurrentValues.SitId, base.ParentId))
                                {
                                    NewSkin = Model.Settings.GetLevelPageTemplate(m.Level + 1);
                                    if (NewSkin.Length.Equals(0))
                                        base.Skin = this.PageTemplate;
                                    else
                                        base.Skin = NewSkin;
                                }
                            }

                            base.SiteId = CurrentValues.SitId;
                            base.Order = Convert.ToInt32(RXServer.OrderMinMax.Max); 
                            base.Language = System.Threading.Thread.CurrentThread.CurrentCulture.LCID;
                            //base.Refresh = false;

                            // Save the main object...
                            base.Save();

                            using (Menus.MenuItem m = new Menus.MenuItem(CurrentValues.SitId, base.ParentId))
                            {
                                this.Settings = m.Settings;
                                this.Settings.PagId = this.Id;
                                this.Settings.Exist = false; 
                                this.Settings.Save();  
                            }

                            // Read Model database and create modules...
                            foreach (Model.ModuleDefinition md in Model.Settings.GetPageModules(base.Id))
                            {
                                if (!md.DefinitionId.Equals(0))
                                {
                                    using (RXServer.Module m = new RXServer.Module(CurrentValues.SitId, base.Id, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                    {
                                        m.Order = 1;
                                        m.ModuleDefinitionId = md.DefinitionId;
                                        m.Secure = md.Secure;
                                        m.Name = md.Name;
                                        m.Alias = md.Name;
                                        m.Description = md.Name;
                                        m.Language = base.Language;
                                        m.Pane = md.ContentPane;
                                        m.Skin = md.Skin;
                                        m.Refresh = false;
                                        m.Save();
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Update the main object...
                            base.Save();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                    }
                }
            }
            #endregion public class MenuItem

            #region public class MenuSettings
            public class MenuSettings : Object
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Menus][Class::MenuSettings]";

                public String Type
                {
                    get { return base.Field1; }
                    set { base.Field1 = value; }
                }

                public MenuSettings(Int32 SitId, Int32 MenId)
                    : base(ObjectType.RXServerDefined_MenuSettings, SitId, MenId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString)
                {
                }

                public override void Save()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        base.Name = "MenuSettings";
                        base.Alias = "MenuSettings";
                        base.Description = "MenuSettings";
                        base.Save();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                    }
                }
            }
            #endregion public class MenuSettings

            #region public class MenuItemSettings
            public class MenuItemSettings : Object
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Menus][Class::MenuItemSettings]";

                public String Type
                {
                    get { return base.Field1; }
                    set { base.Field1 = value; }
                }
                public String BackColor
                {
                    get { return base.Field2; }
                    set { base.Field2 = value; }
                }
                public Boolean Selected
                {
                    get { return base.Field3.Equals("1") ? true : false; }
                    set { base.Field3 = value.Equals(true) ? "1" : "0"; }
                }
                public String ForeColor
                {
                    get { return base.Field4; }
                    set { base.Field4 = value; }
                }
                public String LineColor
                {
                    get { return base.Field5; }
                    set { base.Field5 = value; }
                }
                public Int32 Index
                {
                    get 
                    {
                        Int32 i = -1;
                        Int32.TryParse(base.Field6, out i); 
                        return i; 
                    }
                    set { base.Field6 = value.ToString(); }
                }
                public String MetaTitle
                {
                    get { return base.Field7; }
                    set { base.Field7 = value; }
                }
                public String MetaKeywords
                {
                    get { return base.Field8; }
                    set { base.Field8 = value; }
                }
                public String MetaDescription
                {
                    get { return base.Field9; }
                    set { base.Field9 = value; }
                }
                public String ControlDate
                {
                    get { return base.Field10; }
                    set { base.Field10 = value; }
                }
                //public String SelectedImageUrl
                //{
                //    get { return base.Field11; }
                //    set { base.Field11 = value; }
                //}
                //public String ImageUrl
                //{
                //    get { return base.Field12; }
                //    set { base.Field12 = value; }
                //}
                //public String ImageOverUrl
                //{
                //    get { return base.Field13; }
                //    set { base.Field13 = value; }
                //}
                public String ImageExtraUrl
                {
                    get { return base.Field14; }
                    set { base.Field14 = value; }
                }
                public String ImageExtraOverUrl
                {
                    get { return base.Field15; }
                    set { base.Field15 = value; }
                }
                public String ImageExtraText
                {
                    get { return base.Field16; }
                    set { base.Field16 = value; }
                }
                public String UrlName
                {
                    get { return base.Field17; }
                    set { base.Field17 = value; }
                }
                public MenuItemPlacement Placement
                {
                    get
                    {
                        if (base.Field7.Equals("0"))
                            return MenuItemPlacement.First;
                        else if (base.Field7.Equals("1"))
                            return MenuItemPlacement.Middle;
                        else if (base.Field7.Equals("2"))
                            return MenuItemPlacement.Last;  
                        else
                            return MenuItemPlacement.Middle;  
                    }
                    set 
                    {
                        if (value.Equals(MenuItemPlacement.First))
                            base.Field7 = "0";
                        else if (value.Equals(MenuItemPlacement.Middle))
                            base.Field7 = "1";
                        else if (value.Equals(MenuItemPlacement.Last))
                            base.Field7 = "2";
                    }
                }

                public MenuItemSettings()
                    : base(ObjectType.RXServerDefined_MenuItemSettings, RXServer.Data.DataSource, RXServer.Data.ConnectionString)
                {
                }


                public MenuItemSettings(Int32 SitId, Int32 ItmId)
                    : base(ObjectType.RXServerDefined_MenuItemSettings, SitId, ItmId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString)
                {
                }
                
                public override void Save()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        base.Name = "ItemSettings";
                        base.Alias = "ItemSettings";
                        base.Description = "ItemSettings";
                        base.Save();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                    }
                }
            }
            #endregion public class MenuItemSettings

            #region public enum MenuItemPlacement
            public enum MenuItemPlacement
            { 
                First = 0,
                Middle = 1,
                Last = 2
            }
            #endregion public enum MenuItemPlacement

        }
    }
}
