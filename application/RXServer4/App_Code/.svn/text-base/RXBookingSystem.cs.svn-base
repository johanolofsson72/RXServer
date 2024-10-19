using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LiquidCore.LiquidCore.Definition;

namespace RXServer.Lib
{
	/// <summary>
	/// Summary description for Bookings
	/// </summary>
	public class Bookings
	{
		public class Bookables : LiquidCore.Objects
		{
			public class Item : LiquidCore.Objects.Item
			{
				public Item() : base()
				{ }

				public Item(int id) : base(id)
				{ }

				public new void Save()
				{
					this.Alias = "BookableItem";
					base.Save();
				}
			}

			public class AddOns : LiquidCore.Objects
			{
			}

            public Bookables(String Alias, ObjectsDefinition.Param[] parameters) : base(Alias, parameters)
			{

			}
		}

		public Bookings(ObjectsDefinition.Param[] parameters, DateTime startDate, DateTime endDate)
		{
		}
	}
}
