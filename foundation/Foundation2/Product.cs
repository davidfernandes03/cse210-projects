using System.Security.Cryptography;

class Product {
    // Attributes
    private string _name;
    private int _productID;
    private double _price;
    private int _quantity;

    // Constructor
    public Product(string name, int productID, double price, int quantity) {
        _name = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }

    // Methods

    // Calculates the total price for the product based on its quantity
    public double CalculateProductTotalPrice() {
        return _price * _quantity;
    }

    // Returns a string containing the product details
    public string GetProductInfo() {
        return $"\nName: {_name}\nProduct ID: {_productID}\nPrice: {_price}\nQuantity: {_quantity}";
    }
}