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
using System.Runtime.Serialization;

/// <summary>
/// Contains the data for a cart.
/// </summary>
[Serializable()]  
public class CartModel
{
    /// <summary>
    /// Product to be stored in cart.
    /// </summary>
    [Serializable()] 
    public class Product
    {
        private String _productId;
		private String _categoryId;
		private String _artId;
        private String _name;
        private decimal _price;
        private decimal _vat;
        private int _quantity;
        private bool _isInStock;
        private String _choice;

        /*
         * Default constructor shouldn't be accessible from the outside.
         */
        private Product()
        {}

        public Product(String productId, String categoryId, String artId, String name, decimal price, decimal vat, int quantity, bool isInStock, String choice)
        {
            _productId = productId;
			_categoryId = categoryId;
			_artId = artId;
            _name = name;
            _price = price;
            _vat = vat;
            _quantity = quantity;
            _isInStock = isInStock;
            _choice = choice;
        }

        public String ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }

		public String CategoryId
		{
			get
			{
				return _categoryId;
			}
			set
			{
				_categoryId = value;
			}
		}

		public String ArtId
		{
			get
			{
				return _artId;
			}
			set
			{
				_artId = value;
			}
		}

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public decimal Vat
        {
            get
            {
                return _vat;
            }
            set
            {
                _vat = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        public bool IsInStock
        {
            get
            {
                return _isInStock;
            }
            set
            {
                _isInStock = value;
            }
        }

        public String Choice
        {
            get
            {
                return _choice;
            }
            set
            {
                _choice = value;
            }
        }
    }

    private System.Collections.Generic.List<Product> _products;

    /*
     * Default constructor.
     */
    public CartModel()
    {
        _products = new System.Collections.Generic.List<Product>();
    }

    /*
     * Adds product to cart.
     * If it allready exists the quantity will be increased instead.
     */
    public void Add(Product product)
    {
        int pos = Find(product.Name, product.Choice);
        if (pos == -1)
        {
            _products.Add(product);
        }
        else
        {
            _products[pos].Quantity += product.Quantity;
        }
		RXServer.Web.Cookie.WriteObjectToCookie(this, "cart_off4all");
    }

    /*
     * Adds product to cart.
     * If it allready exists the quantity will be increased instead.
     */
    public void Add(String productId, String categoryId, String artId, String name, decimal price, decimal vat, int quantity, bool isInStock, String choice)
    {
        Add(new Product(productId, categoryId, artId, name, price, vat, quantity, isInStock, choice));
    }

    /*
     * Delete item at supplied index.
     */
    public void DeleteAt(int index)
    {
        _products.RemoveAt(index);
		RXServer.Web.Cookie.WriteObjectToCookie(this, "cart_off4all");
    }

    /*
     * Empty cart
     */
    public void EmptyCart()
    {
        _products.Clear();
		RXServer.Web.Cookie.WriteObjectToCookie(this, "cart_off4all");
    }

    /*
     * Indexer that returns product at a certain index.
     * Returns null if the index is invalid.
     */
    public Product this[int index]
    {
        get
        {
            if (index > -1 && index < _products.Count)
            {
                return _products[index];
            }
            return null;
        }
    }

    /*
     * Returns the number of products in the cart.
     */
    public int Count()
    {
        return _products.Count;
    }

    /*
     * Returns index of product if names matches.
     * Returns -1 if the product isn't present.
     */
    private int Find(String prdName, String prdChoice)
    {
        int position = 0;
        foreach (Product prd in _products)
        {
            if (prd.Name.Equals(prdName) && prd.Choice.Equals(prdChoice))
            {
                return position;
            }
            position++;
        }
        return -1;
    }

    /*
     * Returns the cart for the current session.
     */
    public static CartModel Current
    {
        get
        {
            if (HttpContext.Current.Session["Cart"] == null)
            {
                CartModel cart = (CartModel)RXServer.Web.Cookie.ReadObjectFromCookie("cart_off4all");  
                if (cart != null)
                {
                    HttpContext.Current.Session["Cart"] = cart;
                }
                else
                {
                    HttpContext.Current.Session["Cart"] = new CartModel();
                }

            }
            return (CartModel)HttpContext.Current.Session["Cart"];
        }
    }
}
