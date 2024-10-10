using System.Reflection.Metadata.Ecma335;

class Order {
    // Attributes
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(List<Product> products, Customer customer) {
        _products = products;
        _customer = customer;
    }

    // Methods

    // Calculates the total price of the order including shipping costs
    public double CalculateTotalPrice() {
        double total = 0;
        double shippingCost = _customer.IsLivingUSA() ? 5.0 : 35.0;

        foreach (var product in _products) {
            total += product.CalculateProductTotalPrice();
        }

        return total + shippingCost;
    }

    // A string containing the packing label
    public string DisplayPackingLabel() {
        string label = "Packing Label:\n";

        foreach (var product in _products) {
            label += product.GetProductInfo() + "\n";
        }

        return label;
    }

    // A string containing the shipping label
    public string DisplayShippingLabel() {
        return $"Shipping Label:\n{_customer.DisplayCustomerInfo()}";
    }
}