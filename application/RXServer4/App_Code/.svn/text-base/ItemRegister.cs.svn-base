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
using System.Collections.Generic;
using System.Xml;
using System.Text;


/// <summary>
/// ItemRegister is an interface for easy handling of the items.
/// </summary>
public class ItemRegister
{
	private String _name;
	private List<Node> _nodes;
	private int _rootId;

	private static ItemRegister _instance; //Singleton instance.

	/// <summary>
	/// Class representing a node in the tree.
	/// </summary>
	public class Node
	{
		public enum DataNodeType { Bool, Decimal, Textfield, Htmltextfield, Image, NodeMising };

		private String _name;
		private int _stackability;
		private List<String> _parentRestrictions;
		private int _childCount;
		private List<IDataNode> _data;

		/// <summary>
		/// Generic interface for data items in a node.
		/// </summary>
		public interface IDataNode
		{
			/// <summary>
			/// Gets the name.
			/// </summary>
			String Name
			{
				get;
			}

			/// <summary>
			/// Gets the default value.
			/// </summary>
			String Default
			{
				get;
			}

			/// <summary>
			/// Gets if empty value is allowed.
			/// </summary>
			Boolean AllowEmpty
			{
				get;
			}
		}

		/// <summary>
		/// Concrete datatype. Stores a bool.
		/// </summary>
		public class Bool : IDataNode
		{
			private String _name;
			private String _default;
			private Boolean _allowEmpty;

			/// <summary>
			/// Constructor.
			/// </summary>
			public Bool(String name, String defaultValue, Boolean allowEmpty)
			{
				_name = name;
				_default = defaultValue;
				_allowEmpty = allowEmpty;
			}

			/// <summary>
			/// Gets the name.
			/// </summary>
			public String Name
			{
				get
				{
					return _name;
				}
			}

			/// <summary>
			/// Get the default value.
			/// </summary>
			public String Default
			{
				get
				{
					return _default;
				}
			}

			/// <summary>
			/// Gets if empty value is allowed.
			/// </summary>
			public Boolean AllowEmpty
			{
				get
				{
					return _allowEmpty;
				}
			}
		}

		/// <summary>
		/// Concrete datatype. Stores a decimal.
		/// </summary>
		public class Decimal : IDataNode
		{
			private String _name;
			private String _default;
			private Boolean _allowEmpty;

			/// <summary>
			/// Constructor.
			/// </summary>
			public Decimal(String name, String defaultValue, Boolean allowEmpty)
			{
				_name = name;
				_default = defaultValue;
				_allowEmpty = allowEmpty;
			}

			/// <summary>
			/// Gets the name.
			/// </summary>
			public String Name
			{
				get
				{
					return _name;
				}
			}

			/// <summary>
			/// Get the default value.
			/// </summary>
			public String Default
			{
				get
				{
					return _default;
				}
			}

			/// <summary>
			/// Gets if empty value is allowed.
			/// </summary>
			public Boolean AllowEmpty
			{
				get
				{
					return _allowEmpty;
				}
			}
		}

		/// <summary>
		/// Concrete datatype. Stores a string.
		/// </summary>
		public class TextField : IDataNode
		{
			private String _name;
			private String _default;
			private Boolean _allowEmpty;

			/// <summary>
			/// Constructor.
			/// </summary>
			public TextField(String name, String defaultValue, Boolean allowEmpty)
			{
				_name = name;
				_default = defaultValue;
				_allowEmpty = allowEmpty;
			}

			/// <summary>
			/// Gets the name.
			/// </summary>
			public String Name
			{
				get
				{
					return _name;
				}
			}

			/// <summary>
			/// Get the default value.
			/// </summary>
			public String Default
			{
				get
				{
					return _default;
				}
			}

			/// <summary>
			/// Gets if empty value is allowed.
			/// </summary>
			public Boolean AllowEmpty
			{
				get
				{
					return _allowEmpty;
				}
			}
		}

		/// <summary>
		/// Concrete datatype. Stores a string of html text.
		/// </summary>
		public class HtmlTextField : IDataNode
		{
			private String _name;
			private String _default;
			private Boolean _allowEmpty;

			/// <summary>
			/// Constructor.
			/// </summary>
			public HtmlTextField(String name, String defaultValue, Boolean allowEmpty)
			{
				_name = name;
				_default = defaultValue;
				_allowEmpty = allowEmpty;
			}

			/// <summary>
			/// Gets the name.
			/// </summary>
			public String Name
			{
				get
				{
					return _name;
				}
			}

			/// <summary>
			/// Get the default value.
			/// </summary>
			public String Default
			{
				get
				{
					return _default;
				}
			}

			/// <summary>
			/// Gets if empty value is allowed.
			/// </summary>
			public Boolean AllowEmpty
			{
				get
				{
					return _allowEmpty;
				}
			}
		}

		/// <summary>
		/// Concrete datatype. Stores an image.
		/// </summary>
		public class Image : IDataNode
		{
			private String _name;
			private List<String> _extensions;
			private int _sizeLimit;

			/// <summary>
			/// Constructor.
			/// </summary>
			public Image(String name, List<String> extensions, int sizeLimit)
			{
				_name = name;
				_extensions = extensions;
				_sizeLimit = sizeLimit;
			}

			/// <summary>
			/// Gets the name.
			/// </summary>
			public String Name
			{
				get
				{
					return _name;
				}
			}

			public String Default
			{
				get
				{
					return "";
				}
			}

			/// <summary>
			/// Returns a copy of the list of extensions.
			/// </summary>
			/// <returns>Copy of the extension list.</returns>
			public List<String> CopyExtensionList()
			{
				return new List<String>(_extensions);
			}

			/// <summary>
			/// Returns a copy óf the size limit.
			/// </summary>
			/// <returns>Copy of size limit.</returns>
			public int CopySize()
			{
				return _sizeLimit;
			}

			/// <summary>
			/// Checks if extension is allowed.
			/// </summary>
			/// <param name="extension">The extension as a string.</param>
			/// <returns>True if extension is allowed. Else false.</returns>
			public bool IsExtensionAllowed(String extension)
			{
				return (ExtensionIndex(extension) > -1);
			}

			/// <summary>
			/// Returns index of a given extension.
			/// </summary>
			/// <param name="extension">The extension to search for.</param>
			/// <returns>Returns the index for the extension. -1 if not found.</returns>
			public int ExtensionIndex(String extension)
			{
				return _extensions.FindIndex(
					delegate(String ext)
					{
						return (ext == extension);
					});
			}

			/// <summary>
			/// Gets if empty value is allowed.
			/// </summary>
			public Boolean AllowEmpty
			{
				get
				{
					return true;
				}
			}
		}

		/// <summary>
		/// Class holding name and type for a specific data node.
		/// </summary>
		public class DataNodeDefinition
		{
			private String _name;
			private DataNodeType _type;
			private int _id;
			private Boolean _allowEmpty;

			/// <summary>
			/// Constructor.
			/// </summary>
			public DataNodeDefinition(DataNodeType type, String name, int id, Boolean allowEmpty)
			{
				_name = name;
				_type = type;
				_id = id;
				_allowEmpty = allowEmpty;
			}

			/// <summary>
			/// Gets node name.
			/// </summary>
			public String Name
			{
				get
				{
					return _name;
				}
			}

			/// <summary>
			/// Gets data node type.
			/// </summary>
			public DataNodeType Type
			{
				get
				{
					return _type;
				}
			}

			/// <summary>
			/// Get the id.
			/// </summary>
			public int Id
			{
				get
				{
					return _id;
				}
			}

			/// <summary>
			/// Get if node allows empty data.
			/// </summary>
			public Boolean AllowEmpty
			{
				get
				{
					return _allowEmpty;
				}
			}
		}

		/// <summary>
		/// Class representing an image in the tree.
		/// Inc. path, size restrictions and extension restrictions.
		/// </summary>
		public class ImageDefinition
		{
			private String _path;
			private String _pathLarge;
			private String _pathThumb;
			private int _size;
			private List<String> _extensions;

			/// <summary>
			/// Constructor.
			/// </summary>
			public ImageDefinition(String path, String pathLarge, String pathThumb, int size, List<String> extensions)
			{
				_path = path;
				_pathLarge = pathLarge;
				_pathThumb = pathThumb;
				_size = size;
				_extensions = extensions;
			}

			/// <summary>
			/// Get the path.
			/// </summary>
			public String Path
			{
				get
				{
					return _path;
				}
			}

			/// <summary>
			/// Get the path to large image.
			/// </summary>
			public String PathLarge
			{
				get
				{
					return _pathLarge;
				}
			}

			/// <summary>
			/// Get the path to thumb image.
			/// </summary>
			public String PathThumb
			{
				get
				{
					return _pathThumb;
				}
			}

			/// <summary>
			/// Gets the extensions.
			/// </summary>
			public List<String> Extensions
			{
				get
				{
					return _extensions;
				}
			}

			/// <summary>
			/// Gets the size.
			/// </summary>
			public int Size
			{
				get
				{
					return _size;
				}
			}
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public Node(String name, int stackability, List<String> parentRestrictions, int childCount, List<IDataNode> data)
		{
			_name = name;
			_stackability = stackability;
			_parentRestrictions = parentRestrictions;
			_childCount = childCount;
			_data = data;
		}

		/// <summary>
		/// Checks of the given parent type is allowed for this node.
		/// </summary>
		/// <param name="parent">Parent type to check for.</param>
		/// <returns>True of allowed, otherwise false.</returns>
		public bool IsParentAllowed(String parent)
		{
			return (ParentIndex(parent) > -1);
		}

		/// <summary>
		/// Returns the index of the parent in the list.
		/// </summary>
		/// <param name="parent">Parent to find index of.</param>
		/// <returns>Index of parent. -1 of not found.</returns>
		public int ParentIndex(String parent)
		{
			return _parentRestrictions.FindIndex(
				delegate(String par)
				{
					return (par == parent);
				});
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		public String Name
		{
			get
			{
				return _name;
			}
		}

		/// <summary>
		/// Gets the stackability.
		/// </summary>
		public int Stackability
		{
			get
			{
				return _stackability;
			}
		}

		/// <summary>
		/// Gets the child count.
		/// </summary>
		public int ChildCount
		{
			get
			{
				return _childCount;
			}
		}

		/// <summary>
		/// Returns a copy of the parent restriction list.
		/// </summary>
		/// <returns>Copy of parent restrictions.</returns>
		public List<String> CopyParentRestrictions()
		{
			List<String> restrictions = new List<String>(_parentRestrictions);
			return restrictions;
		}

		/// <summary>
		/// Gets the data node at a certain index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>The data node.</returns>
		public IDataNode this[int index]
		{
			get
			{
				return _data[index];
			}
		}

		/// <summary>
		/// Gets the data node by name.
		/// </summary>
		/// <param name="name">Data node name.</param>
		/// <returns>The data node.</returns>
		public IDataNode this[String name]
		{
			get
			{
				foreach(IDataNode dataNode in _data)
				{
					if(dataNode.Name.Equals(name))
					{
						return dataNode;
					}
				}

				return null;
			}
		}

		/// <summary>
		/// Gets the number of data nodes.
		/// </summary>
		public int DataNodeCount
		{
			get
			{
				return _data.Count;
			}
		}
		
		/// <summary>
		/// Returns data node type.
		/// </summary>
		/// <param name="name">Name of node to find.</param>
		/// <returns>Node type.</returns>
		public DataNodeType GetDataNodeType(String name)
		{
			IDataNode dataNode = _data.Find(
				delegate(IDataNode input)
				{
					return (input.Name == name);
				});

			if (dataNode == null)
			{
				return DataNodeType.NodeMising;
			}
			else if (dataNode is Image)
			{
				return DataNodeType.Image;
			}
			else if (dataNode is Bool)
			{
				return DataNodeType.Bool;
			}
			else if (dataNode is Decimal)
			{
				return DataNodeType.Decimal;
			}
			else if (dataNode is HtmlTextField)
			{
				return DataNodeType.Htmltextfield;
			}
			else
			{
				return DataNodeType.Textfield;
			}
		}

		/// <summary>
		/// Checks of node has a certain data node.
		/// </summary>
		/// <param name="name">Data node to look for.</param>
		/// <returns>True if exists.</returns>
		public bool HasDataNode(String name)
		{
			foreach(IDataNode dataNode in _data)
			{
				if (dataNode.Name.Equals(name))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Returns the extension list for an image.
		/// </summary>
		/// <param name="name">Name of image node.</param>
		/// <returns>Extension list.</returns>
		public List<String> GetExtensionList(String name)
		{
			foreach(IDataNode dataNode in _data)
			{
				if (dataNode.Name.Equals(name))
				{
					return ((Image)dataNode).CopyExtensionList();
				}
			}
			return null;
		}

		/// <summary>
		/// Returns the size restrictions.
		/// </summary>
		/// <param name="name">Name of image node,</param>
		/// <returns>Size restriction.</returns>
		public int GetSize(String name)
		{
			foreach (IDataNode dataNode in _data)
			{
				if (dataNode.Name.Equals(name))
				{
					return ((Image)dataNode).CopySize();
				}
			}
			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
	}

	/// <summary>
	/// Private constructor for ItemRegister.
	/// </summary>
	private ItemRegister()
	{
		String path = HttpContext.Current.Request.PhysicalApplicationPath + "\\itemregister.xml";
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(path);

		XmlElement root = xmlDoc.DocumentElement;
		_name = root.SelectNodes("name")[0].InnerText;
		_nodes = new List<Node>();
		CreateNodes(root);

		LiquidCore.Objects rootNode = new LiquidCore.Objects("ItemRegister");
		if (rootNode.Count == 0)
		{
			LiquidCore.Objects.Item rootObject = new LiquidCore.Objects.Item();
			rootObject.Alias = "ItemRegister";
			rootObject.Value1 = _name;
			_rootId = rootObject.Id;
			rootObject.Save();
		}
		else
		{
			_rootId = rootNode[0].Id;
		}
	}

	/// <summary>
	/// Adds the nodes into the class represenation of the XmlDoc.
	/// </summary>
	/// <param name="root">The Xml root node.</param>
	private void CreateNodes(XmlElement root)
	{
		XmlNodeList nodes = root.SelectNodes("node");
		foreach (XmlNode node in nodes)
		{
			String name = node.SelectNodes("name")[0].InnerText;
			int stackability = Convert.ToInt32(node.SelectNodes("stackability")[0].InnerText);

			String[] parentRestrictionsString = node.SelectNodes("parentrestrictions")[0].InnerText.Split('|');
			List<String> parentRestrictionsList = new List<String>();
			foreach (String s in parentRestrictionsString)
			{
				parentRestrictionsList.Add(s);
			}

			int childCount = Convert.ToInt32(node.SelectNodes("childcount")[0].InnerText);

			List<Node.IDataNode> data = CreateDataNodes(node.SelectNodes("data")[0]);

			Node newNode = new Node(name, stackability, parentRestrictionsList, childCount, data);
			_nodes.Add(newNode);
		}
	}

	/// <summary>
	/// Adds the data fields to a node.
	/// </summary>
	/// <param name="xmlData">Node holding the data fields.</param>
	private List<Node.IDataNode> CreateDataNodes(XmlNode xmlData)
	{
		List<Node.IDataNode> data = new List<Node.IDataNode>();
		XmlNodeList textFields = xmlData.SelectNodes("textfield");
		foreach (XmlNode textField in textFields)
		{
			String defaultValue;
			if (textField.Attributes["default"] != null)
			{
				defaultValue = textField.Attributes["default"].Value;
			}
			else
			{
				defaultValue = "";
			}

			Boolean allowEmpty;
			if (textField.Attributes["allowEmpty"] != null)
			{
				if (!Boolean.TryParse(textField.Attributes["allowEmpty"].Value, out allowEmpty))
				{
					allowEmpty = true;
				}
			}
			else
			{
				allowEmpty = true;
			}

			Node.TextField newTextField = new Node.TextField(textField.InnerText, defaultValue, allowEmpty);
			data.Add(newTextField);
		}

		XmlNodeList decimalFields = xmlData.SelectNodes("decimal");
		foreach (XmlNode decimalField in decimalFields)
		{
			String defaultValue;
			if (decimalField.Attributes["default"] != null)
			{
				defaultValue = decimalField.Attributes["default"].Value;
			}
			else
			{
				defaultValue = "";
			}

			Boolean allowEmpty;
			if (decimalField.Attributes["allowEmpty"] != null)
			{
				if (!Boolean.TryParse(decimalField.Attributes["allowEmpty"].Value, out allowEmpty))
				{
					allowEmpty = true;
				}
			}
			else
			{
				allowEmpty = true;
			}

			Node.Decimal newDecimalField = new Node.Decimal(decimalField.InnerText, defaultValue, allowEmpty);
			data.Add(newDecimalField);
		}

		XmlNodeList boolFields = xmlData.SelectNodes("bool");
		foreach (XmlNode boolField in boolFields)
		{
			String defaultValue;
			if (boolField.Attributes["default"] != null)
			{
				defaultValue = boolField.Attributes["default"].Value;
			}
			else
			{
				defaultValue = "";
			}

			Boolean allowEmpty;
			if (boolField.Attributes["allowEmpty"] != null)
			{
				if (!Boolean.TryParse(boolField.Attributes["allowEmpty"].Value, out allowEmpty))
				{
					allowEmpty = true;
				}
			}
			else
			{
				allowEmpty = true;
			}

			Node.Bool newBoolField = new Node.Bool(boolField.InnerText, defaultValue, allowEmpty);
			data.Add(newBoolField);
		}

		XmlNodeList htmlTextFields = xmlData.SelectNodes("htmltextfield");
		foreach (XmlNode htmlTextField in htmlTextFields)
		{
			String defaultValue;
			if (htmlTextField.Attributes["default"] != null)
			{
				defaultValue = htmlTextField.Attributes["default"].Value;
			}
			else
			{
				defaultValue = "";
			}

			Boolean allowEmpty;
			if (htmlTextField.Attributes["allowEmpty"] != null)
			{
				if (!Boolean.TryParse(htmlTextField.Attributes["allowEmpty"].Value, out allowEmpty))
				{
					allowEmpty = true;
				}
			}
			else
			{
				allowEmpty = true;
			}

			Node.HtmlTextField newHtmlTextField = new Node.HtmlTextField(htmlTextField.InnerText, defaultValue, allowEmpty);
			data.Add(newHtmlTextField);
		}

		XmlNodeList images = xmlData.SelectNodes("image");
		foreach (XmlNode image in images)
		{
			String name = image.SelectNodes("name")[0].InnerText;

			String[] imageExtensionsString = image.SelectNodes("extensions")[0].InnerText.Split('|');
			List<String> imageExtensionsList = new List<String>();
			foreach (String s in imageExtensionsString)
			{
				imageExtensionsList.Add(s);
			}

			int size = Convert.ToInt32(image.SelectNodes("sizelimit")[0].InnerText);
			Node.Image newImage = new Node.Image(name, imageExtensionsList, size);
			data.Add(newImage);
		}

		return data;
	}

	/// <summary>
	/// Method for fetching the current instance of ItemRegister.
	/// </summary>
	/// <returns>The current ItemRegister.</returns>
	public static ItemRegister GetInstance()
	{
		if (_instance == null)
		{
			_instance = new ItemRegister();
		}

		return _instance;
	}

	/// <summary>
	/// Gets the name of the item register.
	/// </summary>
	public String Name
	{
		get
		{
			return _name;
		}
	}

	/// <summary>
	/// Gets root node id
	/// </summary>
	public int RootId
	{
		get
		{
			return _rootId;
		}
	}

	/// <summary>
	/// Returns a list of node id:s under a certain parent.
	/// </summary>
	/// <param name="id">Id of the parent to base of. 0 if root.</param>
	/// <returns>List of node id:s.</returns>
	public List<int> GetNodeIdsUnderParent(int id)
	{
		int parentId;
		if (id == 0)
		{
			parentId = _rootId;
		}
		else
		{
			parentId = id;
		}

		if (NodeExists(parentId))
		{
			LiquidCore.Objects nodes = new LiquidCore.Objects("Node_" + parentId);
			List<int> ids = new List<int>();
			foreach (LiquidCore.Objects.Item node in nodes)
			{
				ids.Add(node.Id);
			}

			return ids;
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Returns a list of node id:s under a certain parent and of a certain type.
	/// </summary>
	/// <param name="id">Id of the prarent to base of. 0 if root.</param>
	/// <param name="type">Type of nodes to return.</param>
	/// <returns>List of node id:s.</returns>
	public List<int> GetNodeIdsUnderParent(int id, String type)
	{
		int parentId;
		if (id == 0)
		{
			parentId = _rootId;
		}
		else
		{
			parentId = id;
		}

		if (NodeExists(parentId))
		{
			LiquidCore.Objects nodes = new LiquidCore.Objects("Node_" + parentId);
			List<int> ids = new List<int>();
			foreach (LiquidCore.Objects.Item node in nodes)
			{
				if (node.Value1.Equals(type))
				{
					ids.Add(node.Id);
				}
			}

			return ids;
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Returns node type of certain node.
	/// </summary>
	/// <param name="id">Node to get type of.</param>
	/// <returns>Node type.</returns>
	public String GetNodType(int id)
	{
        LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(id);
		return node.Value1;
	}

	/// <summary>
	/// Checks of node exists.
	/// </summary>
	/// <param name="id">Id on node to look for.</param>
	/// <returns>True if existing.</returns>
	public bool NodeExists(int id)
	{
        LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(id);
		return (node != null);
	}

	/// <summary>
	/// Returns a list of data node definitions.
	/// </summary>
	/// <param name="nodeId">Node to fetch data nodes from.</param>
	/// <returns>List of data node definitions.</returns>
	public List<Node.DataNodeDefinition> GetDataNodes(int nodeId)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			List<Node.DataNodeDefinition> definitions = new List<Node.DataNodeDefinition>();
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
			LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(nodeId);
			foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				String name = dataNode.Value1;
				Boolean allowEmpty = this[node.Value1][name].AllowEmpty;
				Node.DataNodeType type = this[node.Value1].GetDataNodeType(dataNode.Value1);
				int id = dataNode.Id;
				Node.DataNodeDefinition def = new Node.DataNodeDefinition(type, name, id, allowEmpty);
				definitions.Add(def);
			}

			return definitions;
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Fetch data from bool data node.
	/// </summary>
	/// <param name="dataNodeId">Id of the data node.</param>
	/// <returns>Data.</returns>
	public bool GetBoolData(int dataNodeId)
	{
		if (NodeExists(dataNodeId) && IsDataNode(dataNodeId))
		{
            LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(dataNodeId);
			bool value;
			if (Boolean.TryParse(node.Value2, out value))
			{
				return value;
			}
			else
			{
				return false;
			}
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Fetch data from bool data node.
	/// </summary>
	/// <param name="name">Name of bool data field.</param>
	/// <param name="nodeId">Id of node owning the bool data node.</param>
	/// <returns>Data.</returns>
	public bool GetBoolData(String name, int nodeId)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
			foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if (dataNode.Value1.Equals(name))
				{
					bool value;
					if (Boolean.TryParse(dataNode.Value2, out value))
					{
						return value;
					}
					else
					{
						return false;
					}
				}
			}

			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Fetch data from decimal data node.
	/// </summary>
	/// <param name="dataNodeId">Id of the data node.</param>
	/// <returns>Data.</returns>
	public Decimal GetDecimalData(int dataNodeId)
	{
		if (NodeExists(dataNodeId) && IsDataNode(dataNodeId))
		{
			LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(dataNodeId);
			Decimal value;
			if (Decimal.TryParse(node.Value2, out value))
			{
				return value;
			}
			else
			{
				return 0;
			}
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Fetch data from decimal data node.
	/// </summary>
	/// <param name="name">Name of decimal data field.</param>
	/// <param name="nodeId">Id of node owning the decimal data node.</param>
	/// <returns>Data.</returns>
	public Decimal GetDecimalData(String name, int nodeId)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
			foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if (dataNode.Value1.Equals(name))
				{
					Decimal value;
					if (Decimal.TryParse(dataNode.Value2, out value))
					{
						return value;
					}
					else
					{
						return 0;
					}
				}
			}

			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Fetch data from text data node.
	/// </summary>
	/// <param name="dataNodeId">Id of the data node.</param>
	/// <returns>Data.</returns>
	public String GetTextFieldData(int dataNodeId)
	{
		if (NodeExists(dataNodeId) && IsDataNode(dataNodeId))
		{
            LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(dataNodeId);
			return node.Value2;
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Fetch data from text data node.
	/// </summary>
	/// <param name="name">Name of text data field.</param>
	/// <param name="nodeId">Id of node owning the text data node.</param>
	/// <returns></returns>
	public String GetTextFieldData(String name, int nodeId)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
			foreach(LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if(dataNode.Value1.Equals(name))
				{
					return dataNode.Value2;
				}
			}

			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Fetch data from html text data node.
	/// </summary>
	/// <param name="dataNodeId">Id of the data node.</param>
	/// <returns>Data.</returns>
	public String GetHtmlTextFieldData(int dataNodeId)
	{
		if (NodeExists(dataNodeId) && IsDataNode(dataNodeId))
		{
            LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(dataNodeId);
			return HttpContext.Current.Server.HtmlDecode(node.Value2).Replace("`", "'");
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Fetch data from html text data node.
	/// </summary>
	/// <param name="name">Name of html text data field.</param>
	/// <param name="nodeId">Id of node owning the html text data node.</param>
	/// <returns></returns>
	public String GetHtmlTextFieldData(String name, int nodeId)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
			foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if (dataNode.Value1.Equals(name))
				{
					return HttpContext.Current.Server.HtmlDecode(dataNode.Value2).Replace("`", "'");
				}
			}

			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Returns image data.
	/// </summary>
	/// <param name="dataNodeId">Id for data node.</param>
	/// <returns>Image data wrapped in an ImageDefinition object.</returns>
	public Node.ImageDefinition GetImageData(int dataNodeId)
	{
		if (NodeExists(dataNodeId) && IsDataNode(dataNodeId))
		{
            LiquidCore.Objects.Item image = new LiquidCore.Objects.Item(dataNodeId);
            LiquidCore.Objects.Item parent = new LiquidCore.Objects.Item(image.ParentId);
			String path = image.Value2;
			String pathLarge = image.Value3;
			String pathThumb = image.Value4;
			int size = this[parent.Value1].GetSize(image.Value1);
			List<String> extensions = this[parent.Value1].GetExtensionList(image.Value1);
			return new Node.ImageDefinition(path, pathLarge, pathThumb, size, extensions);
		}
		else
		{
			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
	}

	/// <summary>
	/// Returns image data.
	/// </summary>
	/// <param name="nodeId">Node holding the image.</param>
	/// <param name="name">Name of image data node.</param>
	/// <returns>Image data wrapped in an ImageDefinition object.</returns>
	public Node.ImageDefinition GetImageData(int nodeId, String name)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
            foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if (dataNode.Value1.Equals(name))
				{
                    LiquidCore.Objects.Item image = new LiquidCore.Objects.Item(dataNode.Id);
                    LiquidCore.Objects.Item parent = new LiquidCore.Objects.Item(image.ParentId);
					String path = image.Value2;
					String pathLarge = image.Value3;
					String pathThumb = image.Value4;
					int size = this[parent.Value1].GetSize(image.Value1);
					List<String> extensions = this[parent.Value1].GetExtensionList(image.Value1);
					return new Node.ImageDefinition(path, pathLarge, pathThumb, size, extensions);
				}
			}

			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Returns id of data node under certain node.
	/// </summary>
	/// <param name="name">Name of data node.</param>
	/// <param name="nodeId">Node owning the data node.</param>
	/// <returns>Data ndoe id.</returns>
	public int GetDataNodeId(String name, int nodeId)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
            foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if (dataNode.Value1.Equals(name))
				{
					return dataNode.Id;
				}
			}

			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Returns id of the parent node.
	/// </summary>
	/// <param name="nodeId">Node to fetch parent from.</param>
	/// <returns>Parent id. 0 denotes item register root node.</returns>
	public int GetParentNodeId(int nodeId)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(nodeId);
			return node.ParentId;
		}
		throw new ItemRegisterExceptions.NodeMissingException();
	}

	/// <summary>
	/// Sets the data in a bool data node.
	/// </summary>
	/// <param name="nodeId">Data node to set data on.</param>
	/// <param name="data">Data to set.</param>
	public void SetBoolData(int nodeId, bool data)
	{
		if (NodeExists(nodeId) && IsDataNode(nodeId))
		{
			LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(nodeId);
			node.Value2 = data.ToString();
			node.Save();
		}
		else
		{
			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
	}

	/// <summary>
	/// Sets the data in a bool data node.
	/// </summary>
	/// <param name="nodeId">Node owning the bool data field to save to.</param>
	/// <param name="fieldName">Bool data field to save to.</param>
	/// <param name="data">Data to save.</param>
	public void SetBoolData(int nodeId, String fieldName, bool data)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
			foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if (dataNode.Value1.Equals(fieldName))
				{
					dataNode.Value2 = data.ToString();
					dataNode.Save();
					return;
				}
			}
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Sets the data in a decimal data node.
	/// </summary>
	/// <param name="nodeId">Data node to set data on.</param>
	/// <param name="data">Data to set.</param>
	public void SetDecimalData(int nodeId, Decimal data)
	{
		if (NodeExists(nodeId) && IsDataNode(nodeId))
		{
			LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(nodeId);
			node.Value2 = data.ToString(); ;
			node.Save();
		}
		else
		{
			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
	}

	/// <summary>
	/// Sets the data in a decimal data node.
	/// </summary>
	/// <param name="nodeId">Node owning the decimal data field to save to.</param>
	/// <param name="fieldName">Decimal data field to save to.</param>
	/// <param name="data">Data to save.</param>
	public void SetDecimalData(int nodeId, String fieldName, Decimal data)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
			foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if (dataNode.Value1.Equals(fieldName))
				{
					dataNode.Value2 = data.ToString();
					dataNode.Save();
					return;
				}
			}
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Sets the data in a text data node.
	/// </summary>
	/// <param name="nodeId">Data node to set data on.</param>
	/// <param name="data">Data to set.</param>
	public void SetTextFieldData(int nodeId, String data)
	{
		if (NodeExists(nodeId) && IsDataNode(nodeId))
		{
			LiquidCore.Objects.Item dataNode = new LiquidCore.Objects.Item(nodeId);
			Boolean allowEmpty = this[new LiquidCore.Objects.Item(dataNode.ParentId).Value1][dataNode.Value1].AllowEmpty;
			if (!allowEmpty && data.Equals(""))
			{
				throw new ItemRegisterExceptions.EmptyValueNotAllowedException();
			}
			else
			{
				dataNode.Value2 = data.ToString(); ;
				dataNode.Save();
			}
		}
		else
		{
			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
	}

	/// <summary>
	/// Sets the data in a text data node.
	/// </summary>
	/// <param name="nodeId">Node owning the text data field to save to.</param>
	/// <param name="fieldName">Text data field to save to.</param>
	/// <param name="data">Data to save.</param>
	public void SetTextFieldData(int nodeId, String fieldName, String data)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
			foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if (dataNode.Value1.Equals(fieldName))
				{
					Boolean allowEmpty = this[new LiquidCore.Objects.Item(nodeId).Value1][fieldName].AllowEmpty;
					if (!allowEmpty && data.Equals(""))
					{
						throw new ItemRegisterExceptions.EmptyValueNotAllowedException();
					}
					else
					{
						dataNode.Value2 = data.ToString(); ;
						dataNode.Save();
						return;
					}
				}
			}
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Sets the data in a html text data node.
	/// </summary>
	/// <param name="nodeId">Data node to set data on.</param>
	/// <param name="data">Data to set.</param>
	public void SetHtmlTextFieldData(int nodeId, String data)
	{
		if (NodeExists(nodeId) && IsDataNode(nodeId))
		{
			LiquidCore.Objects.Item dataNode = new LiquidCore.Objects.Item(nodeId);
			Boolean allowEmpty = this[new LiquidCore.Objects.Item(dataNode.ParentId).Value1][dataNode.Value1].AllowEmpty;
			if (!allowEmpty && data.Equals(""))
			{
				throw new ItemRegisterExceptions.EmptyValueNotAllowedException();
			}
			else
			{
				dataNode.Value2 = data.ToString(); ;
				dataNode.Save();
			}
		}
		else
		{
			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
	}

	/// <summary>
	/// Sets the data in a html text data node.
	/// </summary>
	/// <param name="nodeId">Node owning the html text data field to save to.</param>
	/// <param name="fieldName">Html text data field to save to.</param>
	/// <param name="data">Data to save.</param>
	public void SetHtmlTextFieldData(int nodeId, String fieldName, String data)
	{
		if (NodeExists(nodeId) && IsNode(nodeId))
		{
			LiquidCore.Objects dataNodes = new LiquidCore.Objects("DataNode_" + nodeId);
			foreach (LiquidCore.Objects.Item dataNode in dataNodes)
			{
				if (dataNode.Value1.Equals(fieldName))
				{
					Boolean allowEmpty = this[new LiquidCore.Objects.Item(nodeId).Value1][fieldName].AllowEmpty;
					if (!allowEmpty && data.Equals(""))
					{
						throw new ItemRegisterExceptions.EmptyValueNotAllowedException();
					}
					else
					{
						dataNode.Value2 = data.ToString(); ;
						dataNode.Save();
					}
				}
			}
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Stores the image path in the database.
	/// </summary>
	/// <param name="path">Path to store.</param>
	/// <param name="nodeId">Data node to store the path under.</param>
	public void SetImagePath(String path, int nodeId)
	{
		if (NodeExists(nodeId) && IsDataNode(nodeId))
		{
			LiquidCore.Objects.Item image = new LiquidCore.Objects.Item(nodeId);
			image.Value2 = path;
			image.Save();
		}
		else
		{
			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
	}

	/// <summary>
	/// Stores the large image path in the database.
	/// </summary>
	/// <param name="path">Path to store.</param>
	/// <param name="nodeId">Data node to store the path under.</param>
	public void SetImageLargePath(String path, int nodeId)
	{
		if (NodeExists(nodeId) && IsDataNode(nodeId))
		{
			LiquidCore.Objects.Item image = new LiquidCore.Objects.Item(nodeId);
			image.Value3 = path;
			image.Save();
		}
		else
		{
			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
	}

	/// <summary>
	/// Stores the thumb image path in the database.
	/// </summary>
	/// <param name="path">Path to store.</param>
	/// <param name="nodeId">Data node to store the path under.</param>
	public void SetImageThumbPath(String path, int nodeId)
	{
		if (NodeExists(nodeId) && IsDataNode(nodeId))
		{
			LiquidCore.Objects.Item image = new LiquidCore.Objects.Item(nodeId);
			image.Value4 = path;
			image.Save();
		}
		else
		{
			throw new ItemRegisterExceptions.DataNodeMissingException();
		}
	}

	/// <summary>
	/// Checks of row in db is item register node.
	/// </summary>
	/// <param name="nodeId">Id of node to check.</param>
	/// <returns>True if node.</returns>
	private bool IsNode(int nodeId)
	{
		LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(nodeId);
		return (node.Alias.Equals("Node_" + node.ParentId));
	}

	/// <summary>
	/// Checks of node is data node.
	/// </summary>
	/// <param name="nodeId">Id of node to check.</param>
	/// <returns>True if data node.</returns>
	private bool IsDataNode(int nodeId)
	{
        LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(nodeId);
		return (node.Alias.Equals("DataNode_" + node.ParentId));
	}

	/// <summary>
	/// Check if a certain node id is the root node of the item register.
	/// </summary>
	/// <param name="nodeId">Node to check.</param>
	/// <returns>True if root node.</returns>
	public bool IsRootNode(int nodeId)
	{
		return (nodeId == _rootId);
	}

	/// <summary>
	/// Create a new node.
	/// </summary>
	/// <param name="nodeType">Type of node to create.</param>
	/// <param name="parentId">Id of parent node.</param>
	/// <returns>Id for the new node.</returns>
	public int NewNode(String nodeType, int parentId, String title)
	{
		LiquidCore.Objects.Item parent;
		if(parentId == 0)
		{
			parent = new LiquidCore.Objects.Item(_rootId);
			parentId = _rootId;
		}
		else
		{
			parent = new LiquidCore.Objects.Item(parentId);
		}

		if(parent != null)
		{
			bool nodeTypeExists = IsNodeTypeExisting(nodeType);
			bool parentAllowed = this[nodeType].IsParentAllowed(parent.Value1);
			bool stackRoomRemaing = IsRoomRemainingInStack(nodeType, parentId);
			bool childCountReached = IsChildCountReached(parentId);

            if (!nodeTypeExists)
			{
				throw new ItemRegisterExceptions.NodeTypeNotExistingException();
			}
			else if (!parentAllowed)
			{
				throw new ItemRegisterExceptions.ParentNotAllowedException();
			}
			else if (!stackRoomRemaing)
			{
				throw new ItemRegisterExceptions.StackRoomReachedException();
			}
			else if (childCountReached)
			{
				throw new ItemRegisterExceptions.ChildCountReachedException();
			}
			else
			{
                LiquidCore.Objects.Item nodeObject = new LiquidCore.Objects.Item();
                nodeObject.ParentId = parent.Id;
                nodeObject.Alias = "Node_" + parent.Id;
                nodeObject.Value1 = nodeType;
                nodeObject.Save();

                for (int n = 0; n < this[nodeType].DataNodeCount; n++)
                {
                    Node.IDataNode dataNode = this[nodeType][n];
                    LiquidCore.Objects.Item dataNodeObject = new LiquidCore.Objects.Item();
                    dataNodeObject.ParentId = nodeObject.Id;
                    dataNodeObject.Alias = "DataNode_" + nodeObject.Id;
                    dataNodeObject.Value1 = dataNode.Name;
					if (dataNodeObject.Value1.Equals("Titel"))
					{
						dataNodeObject.Value2 = title;
					}
					else
					{
						dataNodeObject.Value2 = dataNode.Default;
					}
                    dataNodeObject.Save();
                }
                return nodeObject.Id;
			}
		}
		else
		{
			throw new ItemRegisterExceptions.NodeMissingException();
		}
	}

	/// <summary>
	/// Deletes a node.
	/// </summary>
	/// <param name="id">Node to delete.</param>
	public void DeleteNode(int id)
	{
		if (NodeExists(id))
        {
            LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(id);
            node.Delete();
		}
	}
	
	/// <summary>
	/// Moves node up.
	/// </summary>
	/// <param name="id">Node to move.</param>
	public void MoveNodeUp(int id)
	{
		if (NodeExists(id))
        {
            LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(id);
			node.ChangeOrderUp();
		}
    }

    /// <summary>
    /// Is it possible to move this stack of nodes to the parent node.
    /// </summary>
    /// <param name="id">Node to move.</param>
    /// <param name="id_dest">Destination node.</param>
    /// <param name="level">Stackability level.</param>
    /// <returns>bool</returns> 
    private bool IsNodeLeafMovable(int id, int id_dest, int level)
    {
        foreach (int child in this.GetNodeIdsUnderParent(id))
        {
            if (this.GetNodType(child).Equals(this.GetNodType(id_dest)))
            {
                if (this[this.GetNodType(child)].Stackability >= level)
                {
                    return IsNodeLeafMovable(child, id_dest, level + 1);
                }
                else
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// Retrive the current node level and chain of id's.
    /// </summary>
    /// <param name="id">Node to check.</param>
    /// <param name="chain">Chain of parent id´s for this node.</param>
    /// <returns>int current level</returns> 
    public int GetCurrentNodeLevel(int id, ref System.Collections.ArrayList chain)
    {
        int x = 0;
        using (LiquidCore.Objects.Item i = new LiquidCore.Objects.Item(id))
        {
            if (i.HasParent)
                x = GetCurrentNodeLevel(i.ParentId, ref chain) + 1;
            chain.Add(i.Id.ToString()); 
        }
        return x;
    }

    /// <summary>
    /// Moves node to other parent by drag and drop.
    /// </summary>
    /// <param name="id_dest">Source Node to move.</param>
    /// <param name="id_source">Destination Node to move to.</param>
    /// <param name="position">Relesed node position.</param>
    public void MoveNodeTo(int id_dest, int id_source, string position)
    {
        bool bigmove = false;
        int id_old = 0;

        if (!position.Equals("Above") && !position.Equals("Below") && !position.Equals("Over"))
            return;

        using (LiquidCore.Objects.Item obd_dest = new LiquidCore.Objects.Item(id_dest))
        {
            using (LiquidCore.Objects.Item obd_source = new LiquidCore.Objects.Item(id_source))
            {
                bigmove = obd_source.ParentId != obd_dest.ParentId;
            }
        }

        if (!position.Equals("Over") && bigmove)
        {
            id_old = id_dest;
            id_dest = this.GetParentNodeId(id_dest); 
        }
        if (position.Equals("Over") || bigmove)
        {
            // Check if the two nodes exists...
            if (NodeExists(id_dest) && NodeExists(id_source))
            {
                // Get validators for source, leaf and destination nodes...
                bool obd_dest_IsChildCountReached = this.IsChildCountReached(id_dest);
                bool obd_dest_IsRoomRemainingInStack = this.IsRoomRemainingInStack(this.GetNodType(id_source), id_dest);
                bool obd_source_IsParentAllowed = this[this.GetNodType(id_source)].IsParentAllowed(this.GetNodType(id_dest));
                bool obd_source_leaf_IsMovePossible = IsNodeLeafMovable(id_source, id_dest, 2);

                // Check validators for source, leaf and destination nodes...
                if (!obd_source_leaf_IsMovePossible)
                    return;
                if (!obd_source_IsParentAllowed)
                    return;
                else if (!obd_dest_IsRoomRemainingInStack)
                    return;
                else if (obd_dest_IsChildCountReached)
                    return;

                using (LiquidCore.Objects.Item obd_dest = new LiquidCore.Objects.Item(id_dest))
                {
                    using (LiquidCore.Objects.Item obd_source = new LiquidCore.Objects.Item(id_source))
                    {
                        if (bigmove)
                        {
                            using (LiquidCore.Objects.Item obd_old = new LiquidCore.Objects.Item(id_old))
                            {
                                if (position.Equals("Above"))
                                {
                                    if (obd_old.Order > 1)
                                        obd_source.Order = obd_old.Order - 1;
                                }
                                else if (position.Equals("Below"))
                                    obd_source.Order = obd_old.Order + 1;
                            }
                        }
                        obd_source.ParentId = obd_dest.Id;
                        obd_source.Alias = obd_source.Alias.Substring(0, obd_source.Alias.IndexOf("_") + 1) + obd_dest.Id.ToString();
                        obd_source.Save();
                    }
                }
            }

        }
        else if (position.Equals("Above"))
        {
            using (LiquidCore.Objects.Item obd_dest = new LiquidCore.Objects.Item(id_dest))
            {
                using (LiquidCore.Objects.Item obd_source = new LiquidCore.Objects.Item(id_source))
                {
                    if (obd_dest.Order > 1)
                        obd_source.Order = obd_dest.Order - 1;
                    obd_source.Save();
                }
            }
        }
        else
        {
            using (LiquidCore.Objects.Item obd_dest = new LiquidCore.Objects.Item(id_dest))
            {
                using (LiquidCore.Objects.Item obd_source = new LiquidCore.Objects.Item(id_source))
                {
                    obd_source.Order = obd_dest.Order + 1;
                    obd_source.Save();
                }
            }
        }
    }

	/// <summary>
	/// Moves node down.
	/// </summary>
	/// <param name="id">Node to move.</param>
	public void MoveNodeDown(int id)
	{
		if (NodeExists(id))
        {
            LiquidCore.Objects.Item node = new LiquidCore.Objects.Item(id);
            node.ChangeOrderDown();
		}
    }

    /// <summary>
    /// Checks if the node has children.
    /// </summary>
    /// <param name="Id">Node to check children for.</param>
    /// <returns>True has children.</returns>
    public bool HasChildren(int Id)
    {
        LiquidCore.Objects oo = new LiquidCore.Objects(Id);
        if(oo.Count.Equals(0))
            return false;
        foreach (LiquidCore.Objects.Item o in oo)
            if (o.Alias.Equals("Node_" + Id.ToString()))
                return true;
        return false;
    }

	/// <summary>
	/// Fetch a list of allowed child types for a certain node.
	/// </summary>
	/// <param name="parentId">Node to fetch allowed childs for.</param>
	/// <returns>List of child types.</returns>
	public List<String> FetchPossibleNodeTypeForParent(int parentId)
	{
		List<String> allowedNodes = new List<String>();
		String parentType = new LiquidCore.Objects.Item(parentId).Value1;
		foreach (Node node in _nodes)
		{
			if (node.IsParentAllowed(parentType))
			{
				allowedNodes.Add(node.Name);
			}
		}

		return allowedNodes;
	}

	/// <summary>
	/// Checks if node type exists in the current item register.
	/// </summary>
	/// <param name="nodeType">Node type to check.</param>
	/// <returns>True if existing.</returns>
	private bool IsNodeTypeExisting(string nodeType)
	{
		return (this[nodeType] != null);
	}

	/// <summary>
	/// Checks if the child count has been reached.
	/// </summary>
	/// <param name="parentId">Node to check child count for.</param>
	/// <returns>True count has been reached.</returns>
	private bool IsChildCountReached(int parentId)
	{
		if (parentId == _rootId)
		{
			return false;
		}

		LiquidCore.Objects.Item parent = new LiquidCore.Objects.Item(parentId);
		if (this[parent.Value1].ChildCount == 0)
		{
			return false;
		}

		LiquidCore.Objects childs = new LiquidCore.Objects(parentId);
		if (childs.Count < this[parent.Value1].ChildCount)
		{
			return false;
		}
		else
		{
			return true;
		}
    }

	/// <summary>
	/// Checks if the defined stackability allows more nodes.
	/// </summary>
	/// <param name="nodeType">Type of new node.</param>
	/// <param name="parentId">Parent node.</param>
	/// <returns></returns>
	private bool IsRoomRemainingInStack(string nodeType, int parentId)
	{
		int stackability = this[nodeType].Stackability;
		if (stackability == 0)
		{
			return true;
		}
		else
		{
			LiquidCore.Objects.Item parent = new LiquidCore.Objects.Item(parentId);
			int currentStackLevel = CalculateCurrentStackLevel(nodeType, parentId, 0);
			if (currentStackLevel > stackability)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}

	/// <summary>
	/// Calculate the current stack level.
	/// </summary>
	/// <param name="nodeType">Type of new node.</param>
	/// <param name="parentId">Parent node.</param>
	/// <returns></returns>
	private int CalculateCurrentStackLevel(string nodeType, int parentId, int level)
	{
		LiquidCore.Objects.Item parent = new LiquidCore.Objects.Item(parentId);
		if (parentId == 0 || !parent.Value1.Equals(nodeType))
		{
			return level;
		}
		else
		{
			return CalculateCurrentStackLevel(nodeType, parent.ParentId, (level + 1));
		}
	}

	/// <summary>
	/// Get the node by name.
	/// </summary>
	/// <param name="name">Node name.</param>
	/// <returns>Node.</returns>
	private Node this[String name]
	{
		get
		{
			foreach (Node n in _nodes)
			{
				if (n.Name.Equals(name))
				{
					return n;
				}
			}

			return null;
		}
	}

}

namespace ItemRegisterExceptions
{
	public class NodeTypeNotExistingException : Exception
	{ }

	public class ParentNotAllowedException : Exception
	{ }

	public class StackRoomReachedException : Exception
	{ }

	public class ChildCountReachedException : Exception
	{ }

	public class NodeMissingException : Exception
	{ }

	public class DataNodeMissingException : Exception
	{ }

	public class DataNodeTypeMissmatchException : Exception
	{ }

	public class EmptyValueNotAllowedException : Exception
	{ }
}