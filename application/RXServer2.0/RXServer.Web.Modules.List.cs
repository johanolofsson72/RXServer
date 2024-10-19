using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel;
using System.Data;
using iConsulting.iCDataHandler;

namespace RXServer
{
    namespace Web
    {
        namespace Modules
        {

            #region public class List
            public class List : CollectionBase, IDisposable
            {
                string CLASSNAME = "[Namespace::RXServer.Web.Modules][Class::List]";
                private IListItem[] m_listitems = new IListItem[0];
                private Int32 m_sit_id;
                private Int32 m_pag_id;
                private Int32 m_mod_id;
                private Int32 m_lng_id;
                private String m_datasource;
                private String m_connectionstring;
                private DataTable m_dtlistitems;
                public Int32 DefId = 0;
                public String ContentPane = String.Empty;
                private RXServer.ObjectType m_objecttype = RXServer.ObjectType.RXServerDefined_Modules_ListItem;
                public virtual IListItem[] Items
                {
                    get { return this.m_listitems; }
                }
                public DataTable DataTable()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
                    try
                    {
                        return m_dtlistitems;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return new DataTable();
                    }
                }
                public DataTable DataTable(ObjectSortField SortField, SortOrder SortOrder)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
                    try
                    {
                        DataView v = new DataView(m_dtlistitems);
                        v.Sort = RetriveSortField(SortField) + Convert.ToString((Int32)SortOrder == 1 ? String.Empty : " DESC");
                        return v.ToTable();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return new DataTable();
                    }
                }
                public static void Create(Int32 SitId, Int32 PagId, Int32 DefId, String ContentPane, Int32 Language)
                {
                    string FUNCTIONNAME = "[Namespace::RXServer.Web.Modules][Class::List][Function::Create]";
                    try
                    {
                        // Skapa modulen som ska kunna läsas in items framöver...
                        // Nu använd SitId och PagId som Alias
                        // Detta gör att endast en modul kan finnas på varje sida.
                        RXServer.Module mSource = new RXServer.Module(SitId, PagId, SitId.ToString() + PagId.ToString(), RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                        mSource.ModuleDefinitionId = DefId;
                        mSource.Name = "List";
                        mSource.Language = Language;
                        mSource.Pane = ContentPane;
                        if(mSource.Exist && mSource.Deleted)
                            mSource.Deleted = false;
                        mSource.Save();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                public List(RXServer.ObjectType ObjectType, Int32 SitId, Int32 PagId, Int32 ModId)
                {
                    this.m_objecttype = ObjectType;
                    this.m_datasource = RXServer.Data.DataSource;
                    this.m_connectionstring = RXServer.Data.ConnectionString;
                    this.m_sit_id = SitId;
                    this.m_pag_id = PagId;
                    this.m_mod_id = ModId;
                    GetAll();
                }
                public List(String Alias, Int32 SitId, Int32 PagId)
                {
                    this.m_objecttype = RXServer.ObjectType.RXServerDefined_Modules_ListItem_Dropdown;
                    this.m_datasource = RXServer.Data.DataSource;
                    this.m_connectionstring = RXServer.Data.ConnectionString;
                    this.m_sit_id = SitId;
                    this.m_pag_id = PagId;
                    GetAllAlias(Alias);
                }
                ~List()
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
                }
                private String RetriveSortField(ObjectSortField SortField)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::RetriveSortField]";
                    try
                    {

                        if ((Int32)SortField == 1) return "obd_id";
                        if ((Int32)SortField == 2) return "lng_id";
                        if ((Int32)SortField == 3) return "obd_parentid";
                        if ((Int32)SortField == 4) return "sit_id";
                        if ((Int32)SortField == 5) return "pag_id";
                        if ((Int32)SortField == 64) return "mod_id";
                        if ((Int32)SortField == 6) return "obd_order";
                        if ((Int32)SortField == 7) return "obd_title";
                        if ((Int32)SortField == 8) return "obd_alias";
                        if ((Int32)SortField == 9) return "obd_description";
                        if ((Int32)SortField == 10) return "obd_varchar1";
                        if ((Int32)SortField == 11) return "obd_varchar2";
                        if ((Int32)SortField == 12) return "obd_varchar3";
                        if ((Int32)SortField == 13) return "obd_varchar4";
                        if ((Int32)SortField == 14) return "obd_varchar5";
                        if ((Int32)SortField == 15) return "obd_varchar6";
                        if ((Int32)SortField == 16) return "obd_varchar7";
                        if ((Int32)SortField == 17) return "obd_varchar8";
                        if ((Int32)SortField == 18) return "obd_varchar9";
                        if ((Int32)SortField == 19) return "obd_varchar10";
                        if ((Int32)SortField == 20) return "obd_varchar11";
                        if ((Int32)SortField == 21) return "obd_varchar12";
                        if ((Int32)SortField == 22) return "obd_varchar13";
                        if ((Int32)SortField == 23) return "obd_varchar14";
                        if ((Int32)SortField == 24) return "obd_varchar15";
                        if ((Int32)SortField == 25) return "obd_varchar16";
                        if ((Int32)SortField == 26) return "obd_varchar17";
                        if ((Int32)SortField == 27) return "obd_varchar18";
                        if ((Int32)SortField == 28) return "obd_varchar19";
                        if ((Int32)SortField == 29) return "obd_varchar20";
                        if ((Int32)SortField == 30) return "obd_varchar21";
                        if ((Int32)SortField == 31) return "obd_varchar22";
                        if ((Int32)SortField == 32) return "obd_varchar23";
                        if ((Int32)SortField == 33) return "obd_varchar24";
                        if ((Int32)SortField == 34) return "obd_varchar25";
                        if ((Int32)SortField == 35) return "obd_varchar26";
                        if ((Int32)SortField == 36) return "obd_varchar27";
                        if ((Int32)SortField == 37) return "obd_varchar28";
                        if ((Int32)SortField == 38) return "obd_varchar29";
                        if ((Int32)SortField == 39) return "obd_varchar30";
                        if ((Int32)SortField == 40) return "obd_varchar31";
                        if ((Int32)SortField == 41) return "obd_varchar32";
                        if ((Int32)SortField == 42) return "obd_varchar33";
                        if ((Int32)SortField == 43) return "obd_varchar34";
                        if ((Int32)SortField == 44) return "obd_varchar35";
                        if ((Int32)SortField == 45) return "obd_varchar36";
                        if ((Int32)SortField == 46) return "obd_varchar37";
                        if ((Int32)SortField == 47) return "obd_varchar38";
                        if ((Int32)SortField == 48) return "obd_varchar39";
                        if ((Int32)SortField == 49) return "obd_varchar40";
                        if ((Int32)SortField == 50) return "obd_varchar41";
                        if ((Int32)SortField == 51) return "obd_varchar42";
                        if ((Int32)SortField == 52) return "obd_varchar43";
                        if ((Int32)SortField == 53) return "obd_varchar44";
                        if ((Int32)SortField == 54) return "obd_varchar45";
                        if ((Int32)SortField == 55) return "obd_varchar46";
                        if ((Int32)SortField == 56) return "obd_varchar47";
                        if ((Int32)SortField == 57) return "obd_varchar48";
                        if ((Int32)SortField == 58) return "obd_varchar49";
                        if ((Int32)SortField == 59) return "obd_varchar50";
                        if ((Int32)SortField == 60) return "obd_createddate";
                        if ((Int32)SortField == 61) return "obd_createdby";
                        if ((Int32)SortField == 62) return "obd_updateddate";
                        if ((Int32)SortField == 63) return "obd_updatedby";
                        return String.Empty;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return String.Empty;
                    }
                }
                private void GetAll()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
                    DataTable dt = null;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_OBJECT_COLLECTION + "::SitId" + this.m_sit_id.ToString() + "::PagId" + this.m_pag_id.ToString() + "::ModId" + this.m_mod_id.ToString() + "::ObjectType" + Convert.ToString((Int32)this.m_objecttype);
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_id = " + this.m_mod_id.ToString() + " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) + " AND obd_deleted = 0 ORDER BY obd_order");
                            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            this.m_dtlistitems = dt;
                            Int32 index = 0;
                            this.m_listitems = new IListItem[dt.Rows.Count];
                            foreach (DataRow dr in dt.Rows)
                            {
                                this.m_listitems[index] = new IListItem();
                                this.m_listitems[index].Id = Convert.ToInt32(dr["obd_id"]);
                                this.m_listitems[index].Language = Convert.ToInt32(dr["lng_id"]);
                                this.m_listitems[index].ParentId = Convert.ToInt32(dr["obd_parentid"]);
                                this.m_listitems[index].Order = Convert.ToInt32(dr["obd_order"]);
                                this.m_listitems[index].ObjectType = (ObjectType)Convert.ToInt32(dr["obd_type"]);
                                this.m_listitems[index].Name = Convert.ToString(dr["obd_title"]);
                                this.m_listitems[index].Alias = Convert.ToString(dr["obd_alias"]);
                                this.m_listitems[index].Description = Convert.ToString(dr["obd_description"]);
                                this.m_listitems[index].Field1 = Convert.ToString(dr["obd_varchar1"]);
                                this.m_listitems[index].Field2 = Convert.ToString(dr["obd_varchar2"]);
                                this.m_listitems[index].Field3 = Convert.ToString(dr["obd_varchar3"]);
                                this.m_listitems[index].Field4 = Convert.ToString(dr["obd_varchar4"]);
                                this.m_listitems[index].Field5 = Convert.ToString(dr["obd_varchar5"]);
                                this.m_listitems[index].Field6 = Convert.ToString(dr["obd_varchar6"]);
                                this.m_listitems[index].Field7 = Convert.ToString(dr["obd_varchar7"]);
                                this.m_listitems[index].Field8 = Convert.ToString(dr["obd_varchar8"]);
                                this.m_listitems[index].Field9 = Convert.ToString(dr["obd_varchar9"]);
                                this.m_listitems[index].Field10 = Convert.ToString(dr["obd_varchar10"]);
                                this.m_listitems[index].Field11 = Convert.ToString(dr["obd_varchar11"]);
                                this.m_listitems[index].Field12 = Convert.ToString(dr["obd_varchar12"]);
                                this.m_listitems[index].Field13 = Convert.ToString(dr["obd_varchar13"]);
                                this.m_listitems[index].Field14 = Convert.ToString(dr["obd_varchar14"]);
                                this.m_listitems[index].Field15 = Convert.ToString(dr["obd_varchar15"]);
                                this.m_listitems[index].Field16 = Convert.ToString(dr["obd_varchar16"]);
                                this.m_listitems[index].Field17 = Convert.ToString(dr["obd_varchar17"]);
                                this.m_listitems[index].Field18 = Convert.ToString(dr["obd_varchar18"]);
                                this.m_listitems[index].Field19 = Convert.ToString(dr["obd_varchar19"]);
                                this.m_listitems[index].Field20 = Convert.ToString(dr["obd_varchar20"]);
                                this.m_listitems[index].Field21 = Convert.ToString(dr["obd_varchar21"]);
                                this.m_listitems[index].Field22 = Convert.ToString(dr["obd_varchar22"]);
                                this.m_listitems[index].Field23 = Convert.ToString(dr["obd_varchar23"]);
                                this.m_listitems[index].Field24 = Convert.ToString(dr["obd_varchar24"]);
                                this.m_listitems[index].Field25 = Convert.ToString(dr["obd_varchar25"]);
                                this.m_listitems[index].Field26 = Convert.ToString(dr["obd_varchar26"]);
                                this.m_listitems[index].Field27 = Convert.ToString(dr["obd_varchar27"]);
                                this.m_listitems[index].Field28 = Convert.ToString(dr["obd_varchar28"]);
                                this.m_listitems[index].Field29 = Convert.ToString(dr["obd_varchar29"]);
                                this.m_listitems[index].Field30 = Convert.ToString(dr["obd_varchar30"]);
                                this.m_listitems[index].Field31 = Convert.ToString(dr["obd_varchar31"]);
                                this.m_listitems[index].Field32 = Convert.ToString(dr["obd_varchar32"]);
                                this.m_listitems[index].Field33 = Convert.ToString(dr["obd_varchar33"]);
                                this.m_listitems[index].Field34 = Convert.ToString(dr["obd_varchar34"]);
                                this.m_listitems[index].Field35 = Convert.ToString(dr["obd_varchar35"]);
                                this.m_listitems[index].Field36 = Convert.ToString(dr["obd_varchar36"]);
                                this.m_listitems[index].Field37 = Convert.ToString(dr["obd_varchar37"]);
                                this.m_listitems[index].Field38 = Convert.ToString(dr["obd_varchar38"]);
                                this.m_listitems[index].Field39 = Convert.ToString(dr["obd_varchar39"]);
                                this.m_listitems[index].Field40 = Convert.ToString(dr["obd_varchar40"]);
                                this.m_listitems[index].Field41 = Convert.ToString(dr["obd_varchar41"]);
                                this.m_listitems[index].Field42 = Convert.ToString(dr["obd_varchar42"]);
                                this.m_listitems[index].Field43 = Convert.ToString(dr["obd_varchar43"]);
                                this.m_listitems[index].Field44 = Convert.ToString(dr["obd_varchar44"]);
                                this.m_listitems[index].Field45 = Convert.ToString(dr["obd_varchar45"]);
                                this.m_listitems[index].Field46 = Convert.ToString(dr["obd_varchar46"]);
                                this.m_listitems[index].Field47 = Convert.ToString(dr["obd_varchar47"]);
                                this.m_listitems[index].Field48 = Convert.ToString(dr["obd_varchar48"]);
                                this.m_listitems[index].Field49 = Convert.ToString(dr["obd_varchar49"]);
                                this.m_listitems[index].Field50 = Convert.ToString(dr["obd_varchar50"]);
                                this.m_listitems[index].CreatedDate = Convert.ToDateTime(dr["obd_createddate"]);
                                this.m_listitems[index].CreatedBy = Convert.ToString(dr["obd_createdby"]);
                                this.m_listitems[index].UpdatedDate = Convert.ToDateTime(dr["obd_updateddate"]);
                                this.m_listitems[index].UpdatedBy = Convert.ToString(dr["obd_updatedby"]);
                                this.m_listitems[index].Hidden = Convert.ToBoolean(dr["obd_hidden"]);
                                this.m_listitems[index].Deleted = Convert.ToBoolean(dr["obd_deleted"]);
                                this.m_listitems[index].Exist = true;
                                index++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                private void GetAllAlias(String Alias)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetAllAlias]";
                    DataTable dt = null;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_OBJECT_COLLECTION + "::SitId" + this.m_sit_id.ToString() + "::PagId" + this.m_pag_id.ToString() + "::Alias" + Alias + "::ObjectType" + Convert.ToString((Int32)this.m_objecttype);
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND obd_alias = '" + Alias + "' AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) + " AND obd_deleted = 0 ORDER BY obd_order");
                            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            this.m_dtlistitems = dt;
                            Int32 index = 0;
                            this.m_listitems = new IListItem[dt.Rows.Count];
                            foreach (DataRow dr in dt.Rows)
                            {
                                this.m_listitems[index] = new IListItem();
                                this.m_listitems[index].Id = Convert.ToInt32(dr["obd_id"]);
                                this.m_listitems[index].Language = Convert.ToInt32(dr["lng_id"]);
                                this.m_listitems[index].ParentId = Convert.ToInt32(dr["obd_parentid"]);
                                this.m_listitems[index].Order = Convert.ToInt32(dr["obd_order"]);
                                this.m_listitems[index].ObjectType = (ObjectType)Convert.ToInt32(dr["obd_type"]);
                                this.m_listitems[index].Name = Convert.ToString(dr["obd_title"]);
                                this.m_listitems[index].Alias = Convert.ToString(dr["obd_alias"]);
                                this.m_listitems[index].Description = Convert.ToString(dr["obd_description"]);
                                this.m_listitems[index].Field1 = Convert.ToString(dr["obd_varchar1"]);
                                this.m_listitems[index].Field2 = Convert.ToString(dr["obd_varchar2"]);
                                this.m_listitems[index].Field3 = Convert.ToString(dr["obd_varchar3"]);
                                this.m_listitems[index].Field4 = Convert.ToString(dr["obd_varchar4"]);
                                this.m_listitems[index].Field5 = Convert.ToString(dr["obd_varchar5"]);
                                this.m_listitems[index].Field6 = Convert.ToString(dr["obd_varchar6"]);
                                this.m_listitems[index].Field7 = Convert.ToString(dr["obd_varchar7"]);
                                this.m_listitems[index].Field8 = Convert.ToString(dr["obd_varchar8"]);
                                this.m_listitems[index].Field9 = Convert.ToString(dr["obd_varchar9"]);
                                this.m_listitems[index].Field10 = Convert.ToString(dr["obd_varchar10"]);
                                this.m_listitems[index].Field11 = Convert.ToString(dr["obd_varchar11"]);
                                this.m_listitems[index].Field12 = Convert.ToString(dr["obd_varchar12"]);
                                this.m_listitems[index].Field13 = Convert.ToString(dr["obd_varchar13"]);
                                this.m_listitems[index].Field14 = Convert.ToString(dr["obd_varchar14"]);
                                this.m_listitems[index].Field15 = Convert.ToString(dr["obd_varchar15"]);
                                this.m_listitems[index].Field16 = Convert.ToString(dr["obd_varchar16"]);
                                this.m_listitems[index].Field17 = Convert.ToString(dr["obd_varchar17"]);
                                this.m_listitems[index].Field18 = Convert.ToString(dr["obd_varchar18"]);
                                this.m_listitems[index].Field19 = Convert.ToString(dr["obd_varchar19"]);
                                this.m_listitems[index].Field20 = Convert.ToString(dr["obd_varchar20"]);
                                this.m_listitems[index].Field21 = Convert.ToString(dr["obd_varchar21"]);
                                this.m_listitems[index].Field22 = Convert.ToString(dr["obd_varchar22"]);
                                this.m_listitems[index].Field23 = Convert.ToString(dr["obd_varchar23"]);
                                this.m_listitems[index].Field24 = Convert.ToString(dr["obd_varchar24"]);
                                this.m_listitems[index].Field25 = Convert.ToString(dr["obd_varchar25"]);
                                this.m_listitems[index].Field26 = Convert.ToString(dr["obd_varchar26"]);
                                this.m_listitems[index].Field27 = Convert.ToString(dr["obd_varchar27"]);
                                this.m_listitems[index].Field28 = Convert.ToString(dr["obd_varchar28"]);
                                this.m_listitems[index].Field29 = Convert.ToString(dr["obd_varchar29"]);
                                this.m_listitems[index].Field30 = Convert.ToString(dr["obd_varchar30"]);
                                this.m_listitems[index].Field31 = Convert.ToString(dr["obd_varchar31"]);
                                this.m_listitems[index].Field32 = Convert.ToString(dr["obd_varchar32"]);
                                this.m_listitems[index].Field33 = Convert.ToString(dr["obd_varchar33"]);
                                this.m_listitems[index].Field34 = Convert.ToString(dr["obd_varchar34"]);
                                this.m_listitems[index].Field35 = Convert.ToString(dr["obd_varchar35"]);
                                this.m_listitems[index].Field36 = Convert.ToString(dr["obd_varchar36"]);
                                this.m_listitems[index].Field37 = Convert.ToString(dr["obd_varchar37"]);
                                this.m_listitems[index].Field38 = Convert.ToString(dr["obd_varchar38"]);
                                this.m_listitems[index].Field39 = Convert.ToString(dr["obd_varchar39"]);
                                this.m_listitems[index].Field40 = Convert.ToString(dr["obd_varchar40"]);
                                this.m_listitems[index].Field41 = Convert.ToString(dr["obd_varchar41"]);
                                this.m_listitems[index].Field42 = Convert.ToString(dr["obd_varchar42"]);
                                this.m_listitems[index].Field43 = Convert.ToString(dr["obd_varchar43"]);
                                this.m_listitems[index].Field44 = Convert.ToString(dr["obd_varchar44"]);
                                this.m_listitems[index].Field45 = Convert.ToString(dr["obd_varchar45"]);
                                this.m_listitems[index].Field46 = Convert.ToString(dr["obd_varchar46"]);
                                this.m_listitems[index].Field47 = Convert.ToString(dr["obd_varchar47"]);
                                this.m_listitems[index].Field48 = Convert.ToString(dr["obd_varchar48"]);
                                this.m_listitems[index].Field49 = Convert.ToString(dr["obd_varchar49"]);
                                this.m_listitems[index].Field50 = Convert.ToString(dr["obd_varchar50"]);
                                this.m_listitems[index].CreatedDate = Convert.ToDateTime(dr["obd_createddate"]);
                                this.m_listitems[index].CreatedBy = Convert.ToString(dr["obd_createdby"]);
                                this.m_listitems[index].UpdatedDate = Convert.ToDateTime(dr["obd_updateddate"]);
                                this.m_listitems[index].UpdatedBy = Convert.ToString(dr["obd_updatedby"]);
                                this.m_listitems[index].Hidden = Convert.ToBoolean(dr["obd_hidden"]);
                                this.m_listitems[index].Deleted = Convert.ToBoolean(dr["obd_deleted"]);
                                this.m_listitems[index].Exist = true;
                                index++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }

                public class CustomList : RXServer.Dev.List
                {
                    public CustomList(Int32 SitId, Int32 PagId, String Alias) : base(SitId, PagId, Alias) { }
                    public CustomList(Int32 SitId, Int32 PagId, String Alias, String PreDate) : base(SitId, PagId, Alias, PreDate) { }
                    public CustomList(Int32 SitId, Int32 PagId, String Alias, Int32 StartIndex, Int32 Limit, String Order) : base(SitId, PagId, Alias, StartIndex, Limit, Order) { }
                    public int Add(CustomListItem itm)
                    {
                        return base.Add(itm);
                    }
                    public void Remove(CustomListItem itm)
                    {
                        base.Remove(itm);
                    }
                    public class CustomListItem : RXServer.Dev.List.ListItem
                    {
                        public CustomListItem() : base() { }
                        public CustomListItem(Int32 ItmId) : base(ItmId) { }
                    }
                }

                public class BloggList : RXServer.Dev.List
                {
                    public BloggList(String Field10, Int32 SitId, Int32 PagId) 
                        : base(SitId, PagId) 
                    {
                        for (Int32 i = 0; i < base.InnerList.Count; i++)
                        {
                            RXServer.Dev.List.ListItem li = (RXServer.Dev.List.ListItem)base.List[i];
                            if (!li.Value10.ToLower().Equals(Field10.ToLower()))
                            {
                                base.InnerList.Remove(li);
                                i = -1;
                            }
                        }
                    }
                    public BloggList(Int32 SitId, Int32 PagId, String Alias) : base(SitId, PagId, Alias) { }
                    public BloggList(Int32 SitId, Int32 PagId, String Alias, String PreDate) : base(SitId, PagId, Alias, PreDate) { }
                    public int Add(BloggListItem itm)
                    {
                        return base.Add(itm);
                    }
                    public void Remove(BloggListItem itm)
                    {
                        base.Remove(itm);
                    }
                    public class BloggListItem : RXServer.Dev.List.ListItem
                    {
                        public BloggListItem() : base() { }
                    }
                }

                public class Products : List
                {
                    public Products(Int32 SitId, Int32 PagId, Int32 ModId)  : base(ObjectType.RXServerDefined_Modules_ListItem_Products, SitId, PagId, ModId)
                    { }
                    public void CreateXmlFile(String filename)
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::CreateXmlFile]";
                        try
                        {
                            DataSet ds = new DataSet("Products");
                            DataTable dt = base.DataTable(ObjectSortField.Title, SortOrder.Ascending);
                            dt.TableName = "ProductItem";
                            ds.Tables.Add(dt);

                            ArrayList a = new ArrayList();
                            foreach (DataColumn dc in dt.Columns)
                            {
                                if (dc.ColumnName.ToLower().Equals("obd_id"))
                                    dc.ColumnName = "id";
                                else if (dc.ColumnName.ToLower().Equals("obd_title"))
                                    dc.ColumnName = "title";
                                else if (dc.ColumnName.ToLower().Equals("obd_description"))
                                    dc.ColumnName = "desc";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar1"))
                                    dc.ColumnName = "url";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar2"))
                                    dc.ColumnName = "link";
                                else
                                    a.Add(dc.ColumnName);
                            }
                            foreach (String name in a)
                            {
                                dt.Columns.Remove(name);
                            }
                            dt.AcceptChanges();
                            ds.WriteXml(filename);  
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    public class Item : IListItem
                    {
                        string CLASSNAME = "[Namespace::RXServer.Web.Modules.List.Products][Class::Item]";
                        public String Url
                        {
                            get { return base.Field1; }
                            set { base.Field1 = value; }
                        }
                        public String Link
                        {
                            get { return base.Field2; }
                            set { base.Field2 = value; }
                        }
                        public Item() { }
                        public Item(Int32 LisId) : base(LisId) { }
                        public Item(Int32 SitId, Int32 PagId) : base(RXServer.ObjectType.RXServerDefined_Modules_ListItem_Products, SitId, PagId) { }
                    }
                }

                public class Materials : List
                {
                    public Materials(Int32 SitId, Int32 PagId, Int32 ModId) : base(ObjectType.RXServerDefined_Modules_ListItem_Material, SitId, PagId, ModId)
                    { }
                    public void CreateXmlFile(String filename)
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::CreateXmlFile]";
                        try
                        {
                            DataSet ds = new DataSet("Materials");
                            DataTable dt = base.DataTable(ObjectSortField.Title, SortOrder.Ascending);
                            dt.TableName = "MaterialItem";
                            ds.Tables.Add(dt);

                            ArrayList a = new ArrayList();
                            foreach (DataColumn dc in dt.Columns)
                            {
                                if (dc.ColumnName.ToLower().Equals("obd_id"))
                                    dc.ColumnName = "id";
                                else if (dc.ColumnName.ToLower().Equals("obd_title"))
                                    dc.ColumnName = "title";
                                else if (dc.ColumnName.ToLower().Equals("obd_description"))
                                    dc.ColumnName = "desc";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar1"))
                                    dc.ColumnName = "url";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar2"))
                                    dc.ColumnName = "imgurl";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar3"))
                                    dc.ColumnName = "imgalt";
                                else
                                    a.Add(dc.ColumnName);
                            }
                            foreach (String name in a)
                            {
                                dt.Columns.Remove(name);
                            }
                            dt.AcceptChanges();
                            ds.WriteXml(filename);
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    public class Item : IListItem
                    {
                        string CLASSNAME = "[Namespace::RXServer.Web.Modules.ListItem][Class::Materials]";
                        public String Url
                        {
                            get { return base.Field1; }
                            set { base.Field1 = value; }
                        }
                        public String ImgUrl
                        {
                            get { return base.Field2; }
                            set { base.Field2 = value; }
                        }
                        public String ImgAlt
                        {
                            get { return base.Field3; }
                            set { base.Field3 = value; }
                        }
                        public Item() { }
                        public Item(Int32 LisId) : base(LisId) { }
                        public Item(Int32 SitId, Int32 PagId) : base(RXServer.ObjectType.RXServerDefined_Modules_ListItem_Material, SitId, PagId) { }
                    }
                }

                public class Mail : List
                {
                    public Mail(Int32 SitId, Int32 PagId, Int32 ModId)  : base(ObjectType.RXServerDefined_Modules_ListItem_Mail, SitId, PagId, ModId)
                    { }
                    public void CreateXmlFile(String filename)
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::CreateXmlFile]";
                        try
                        {
                            DataSet ds = new DataSet("Mail");
                            DataTable dt = base.DataTable(ObjectSortField.Title, SortOrder.Ascending);
                            dt.TableName = "MailItem";
                            ds.Tables.Add(dt);

                            ArrayList a = new ArrayList();
                            foreach (DataColumn dc in dt.Columns)
                            {
                                if (dc.ColumnName.ToLower().Equals("obd_id"))
                                    dc.ColumnName = "id";
                                else if (dc.ColumnName.ToLower().Equals("obd_title"))
                                    dc.ColumnName = "title";
                                else if (dc.ColumnName.ToLower().Equals("obd_description"))
                                    dc.ColumnName = "desc";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar1"))
                                    dc.ColumnName = "mailto";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar2"))
                                    dc.ColumnName = "name";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar3"))
                                    dc.ColumnName = "company";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar4"))
                                    dc.ColumnName = "city";
                                else
                                    a.Add(dc.ColumnName);
                            }
                            foreach (String name in a)
                            {
                                dt.Columns.Remove(name);
                            }
                            dt.AcceptChanges();
                            ds.WriteXml(filename);
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    public class Item : IListItem
                    {
                        string CLASSNAME = "[Namespace::RXServer.Web.Modules.ListItem][Class::Mail]";
                        public String MailTo
                        {
                            get { return base.Field1; }
                            set { base.Field1 = value; }
                        }
                        public new String Name
                        {
                            get { return base.Field2; }
                            set { base.Field2 = value; }
                        }
                        public String Company
                        {
                            get { return base.Field3; }
                            set { base.Field3 = value; }
                        }
                        public String City
                        {
                            get { return base.Field4; }
                            set { base.Field4 = value; }
                        }
                        public Item() { }
                        public Item(Int32 LisId) : base(LisId) { }
                        public Item(Int32 SitId, Int32 PagId) : base(RXServer.ObjectType.RXServerDefined_Modules_ListItem_Mail, SitId, PagId) { }
                    }
                }

                public class Contacts : List
                {
                    public Contacts(String Alias, Int32 SitId, Int32 PagId)
                        : base(Alias, SitId, PagId)
                    { }
                    public void CreateXmlFile(String filename)
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::CreateXmlFile]";
                        try
                        {
                            DataSet ds = new DataSet("Contacts");
                            DataTable dt = base.DataTable(ObjectSortField.Title, SortOrder.Ascending);
                            dt.TableName = "ContactsItem";
                            ds.Tables.Add(dt);

                            ArrayList a = new ArrayList();
                            foreach (DataColumn dc in dt.Columns)
                            {
                                if (dc.ColumnName.ToLower().Equals("obd_id"))
                                    dc.ColumnName = "id";
                                else if (dc.ColumnName.ToLower().Equals("obd_title"))
                                    dc.ColumnName = "title";
                                else if (dc.ColumnName.ToLower().Equals("obd_description"))
                                    dc.ColumnName = "desc";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar1"))
                                    dc.ColumnName = "mailto";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar2"))
                                    dc.ColumnName = "name";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar3"))
                                    dc.ColumnName = "company";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar4"))
                                    dc.ColumnName = "city";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar5"))
                                    dc.ColumnName = "header";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar6"))
                                    dc.ColumnName = "text";
                                else
                                    a.Add(dc.ColumnName);
                            }
                            foreach (String name in a)
                            {
                                dt.Columns.Remove(name);
                            }
                            dt.AcceptChanges();
                            ds.WriteXml(filename);
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    public class Item : IListItem
                    {
                        string CLASSNAME = "[Namespace::RXServer.Web.Modules.ListItem][Class::Contacts]";
                        public String MailTo
                        {
                            get { return base.Field1; }
                            set { base.Field1 = value; }
                        }
                        public new String Name
                        {
                            get { return base.Field2; }
                            set { base.Field2 = value; }
                        }
                        public String Company
                        {
                            get { return base.Field3; }
                            set { base.Field3 = value; }
                        }
                        public String City
                        {
                            get { return base.Field4; }
                            set { base.Field4 = value; }
                        }
                        public String Header
                        {
                            get { return base.Field5; }
                            set { base.Field5 = value; }
                        }
                        public String Text
                        {
                            get { return base.Field6; }
                            set { base.Field6 = value; }
                        }
                        public Int32 ReadMorePagId
                        {
                            get { return base.Field7.Equals("") ? 0 : Convert.ToInt32(base.Field7); }
                            set { base.Field7 = value.ToString(); }
                        }
                        public Int32 ReadMoreModId
                        {
                            get { return base.Field8.Equals("") ? 0 : Convert.ToInt32(base.Field8); }
                            set { base.Field8 = value.ToString(); }
                        }
                        public String ReadMoreTemplate = String.Empty;
                        public String ReadMoreContentPane = String.Empty;
                        private RXServer.Object settings; 
                        public Item() { }
                        public Item(Int32 LisId) 
                            : base(LisId) 
                        {
                            //settings = new Object(base.Alias + "_Settings", RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                            //ReadMorePagId = settings.PagId;
                            //ReadMoreModId = settings.ModId;
                        }
                        public Item(String Alias, Int32 SitId, Int32 PagId, String ReadMorePageTemplate, String ReadMoreContentPane) 
                            : base(Alias, SitId, PagId)
                        {
                            this.ReadMoreTemplate = ReadMorePageTemplate;
                            this.ReadMoreContentPane = ReadMoreContentPane;
                            //settings = new Object(base.Alias + "_Settings", RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                            //ReadMorePagId = settings.PagId;
                            //ReadMoreModId = settings.ModId; 
                        }
                        public override void Save()
                        {
                            if (this.ReadMorePagId.Equals(0))
                            {
                                // Create readmore article things...
                                using (RXServer.Page org = new RXServer.Page(base.SitId, base.PagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                {
                                    // Create readmore page...
                                    using (RXServer.Page read = new RXServer.Page(base.SitId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                    {
                                        read.Name = base.Name;
                                        read.Alias = base.Alias;
                                        read.Skin = this.ReadMoreTemplate;
                                        read.Theme = org.Theme;
                                        read.ParentId = base.PagId;
                                        read.Hidden = true;
                                        read.Refresh = false;
                                        read.Save();
                                        this.ReadMorePagId = read.Id;

                                        // Read Model database and create modules...
                                        foreach (Model.ModuleDefinition md in Model.Settings.GetPageModules(base.PagId))
                                        {
                                            if (!md.DefinitionId.Equals(0))
                                            {
                                                using (RXServer.Module m = new RXServer.Module(CurrentValues.SitId, this.ReadMorePagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                                {
                                                    m.Order = 1;
                                                    m.ModuleDefinitionId = md.DefinitionId;
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

                                        // Create readmore module...
                                        using (RXServer.Module m = new RXServer.Module(base.SitId, this.ReadMorePagId, this.ReadMoreModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                        {
                                            m.ModuleDefinitionId = 23;
                                            m.Name = base.Name;
                                            m.Language = base.Language;
                                            m.Pane = this.ReadMoreContentPane;
                                            m.Skin = this.ReadMoreTemplate;
                                            m.Refresh = false;
                                            m.SSL = true;
                                            m.Save();
                                            this.ReadMoreModId = m.Id;

                                            // Create readmore object...
                                            using (RXServer.Object o = new RXServer.Object(this.ObjectType, base.SitId, this.ReadMorePagId, this.ReadMoreModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                            {
                                                o.Name = base.Name;
                                                o.ModId = this.ReadMoreModId;
                                                o.Alias = base.Alias;
                                                o.Field1 = base.Field1;
                                                o.Field2 = base.Field2;
                                                o.Field3 = base.Field3;
                                                o.Field4 = base.Field4;
                                                o.Field5 = base.Field5;
                                                o.Field6 = base.Field6;
                                                o.Field7 = "0";
                                                o.Field8 = base.Field8;
                                                o.Field9 = base.Field9;
                                                o.Field10 = base.Field10;
                                                o.Field11 = base.Field11;
                                                o.Field12 = base.Field12;
                                                o.Field13 = base.Field13;
                                                o.Field14 = base.Field14;
                                                o.Field15 = base.Field15;
                                                o.Field16 = base.Field16;
                                                o.Field17 = base.Field17;
                                                o.Field18 = base.Field18;
                                                o.Field19 = base.Field19;
                                                o.Field20 = base.Field20;
                                                o.Field21 = base.Field21;
                                                o.Field22 = base.Field22;
                                                o.Field23 = base.Field23;
                                                o.Field24 = base.Field24;
                                                o.Field25 = base.Field25;
                                                o.Field26 = base.Field26;
                                                o.Field27 = base.Field27;
                                                o.Field28 = base.Field28;
                                                o.Field29 = base.Field29;
                                                o.Field30 = base.Field30;
                                                o.Refresh = false;
                                                o.Save();
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Update readmore object...
                                using (RXServer.Object o = new RXServer.Object(this.ObjectType, base.SitId, this.ReadMorePagId, this.ReadMoreModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                {
                                    o.Name = base.Name;
                                    o.ModId = this.ReadMoreModId;
                                    o.Alias = this.Alias;
                                    o.Field1 = base.Field1;
                                    o.Field2 = base.Field2;
                                    o.Field3 = base.Field3;
                                    o.Field4 = base.Field4;
                                    o.Field5 = base.Field5;
                                    o.Field6 = base.Field6;
                                    o.Field7 = "0";
                                    o.Field8 = base.Field8;
                                    o.Field9 = base.Field9;
                                    o.Field10 = base.Field10;
                                    o.Field11 = base.Field11;
                                    o.Field12 = base.Field12;
                                    o.Field13 = base.Field13;
                                    o.Field14 = base.Field14;
                                    o.Field15 = base.Field15;
                                    o.Field16 = base.Field16;
                                    o.Field17 = base.Field17;
                                    o.Field18 = base.Field18;
                                    o.Field19 = base.Field19;
                                    o.Field20 = base.Field20;
                                    o.Field21 = base.Field21;
                                    o.Field22 = base.Field22;
                                    o.Field23 = base.Field23;
                                    o.Field24 = base.Field24;
                                    o.Field25 = base.Field25;
                                    o.Field26 = base.Field26;
                                    o.Field27 = base.Field27;
                                    o.Field28 = base.Field28;
                                    o.Field29 = base.Field29;
                                    o.Field30 = base.Field30;
                                    o.Refresh = false;
                                    o.Save();
                                }
                            }
                            base.Save();
                        }
                    }
                }

                public class Dropdown : List
                {
                    /// <summary>
                    /// This is the default constructor, use this when mod_id is present...
                    /// </summary>
                    /// <param name="UserDefined"></param>
                    /// <param name="SitId"></param>
                    /// <param name="PagId"></param>
                    /// <param name="ModId"></param>
                    //public Dropdown(String Alias, Int32 SitId, Int32 PagId, Int32 ModId)
                    //    : base(Alias, SitId, PagId, ModId)
                    //{ }
                    /// <summary>
                    /// Use this when you cant define mod_id, alias will be used insted...
                    /// </summary>
                    /// <param name="UserDefined"></param>
                    /// <param name="SitId"></param>
                    /// <param name="PagId"></param>
                    public Dropdown(String Alias, Int32 SitId, Int32 PagId)
                        : base(Alias, SitId, PagId)
                    { }
                    public void CreateXmlFile(String filename)
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::CreateXmlFile]";
                        try
                        {
                            DataSet ds = new DataSet("Dropdown");
                            DataTable dt = base.DataTable(ObjectSortField.Title, SortOrder.Ascending);
                            dt.TableName = "DropdownItem";
                            ds.Tables.Add(dt);

                            ArrayList a = new ArrayList();
                            foreach (DataColumn dc in dt.Columns)
                            {
                                if (dc.ColumnName.ToLower().Equals("obd_id"))
                                    dc.ColumnName = "id";
                                else if (dc.ColumnName.ToLower().Equals("obd_title"))
                                    dc.ColumnName = "key";
                                else if (dc.ColumnName.ToLower().Equals("obd_varchar1"))
                                    dc.ColumnName = "value";
                                else
                                    a.Add(dc.ColumnName);
                            }
                            foreach (String name in a)
                            {
                                dt.Columns.Remove(name);
                            }
                            dt.AcceptChanges();
                            ds.WriteXml(filename);
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    public class Item : IListItem
                    {
                        string CLASSNAME = "[Namespace::RXServer.Web.Modules.ListItem][Class::Dropdown]";
                        public String Key
                        {
                            get { return base.Name; }
                            set { base.Name = value; }
                        }
                        public new String Value
                        {
                            get { return base.Field1; }
                            set { base.Field1 = value; }
                        }
                        public Item() { }
                        public Item(Int32 LisId) : base(LisId) { }
                        public Item(String Alias, Int32 SitId, Int32 PagId) : base(Alias, SitId, PagId) { }
                    }
                }

                public class IListItem : RXServer.Object
                {
                    string CLASSNAME = "[Namespace::RXServer.Web.Modules][Class::ListItem]";
                    private RXServer.Module mSource;
                    public IListItem() { }
                    public IListItem(Int32 LisId) : base(LisId, RXServer.Data.DataSource, RXServer.Data.ConnectionString) { }
                    public IListItem(RXServer.ObjectType ObjectType, Int32 SitId, Int32 PagId)
                        : base(ObjectType, SitId, PagId, SitId.ToString() + PagId.ToString(), RXServer.Data.DataSource, RXServer.Data.ConnectionString)
                    {
                        // gör så att jag kan skapa fler än ett alternativ i db...
                        base.Exist = false;
                        mSource = new RXServer.Module(SitId, PagId, SitId.ToString() + PagId.ToString(), RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                    }
                    public IListItem(String Alias, Int32 SitId, Int32 PagId)
                        : base(RXServer.ObjectType.RXServerDefined_Modules_ListItem_Dropdown, SitId, PagId, Alias, RXServer.Data.DataSource, RXServer.Data.ConnectionString)
                    {
                        // gör så att jag kan skapa fler än ett alternativ i db...
                        base.Exist = false;
                        mSource = new RXServer.Module(SitId, PagId, Alias, RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                    }
                    public override void Save()
                    {
                        if (mSource != null)
                            base.ModId = mSource.Id;
                        base.Refresh = true;
                        base.Save();
                    }
                }
            }

            #endregion public class List

        }
    }
}