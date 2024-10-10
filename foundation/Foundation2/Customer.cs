using System.Net.Sockets;

class Customer {
    // Attributes
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address) {
        _name = name;
        _address = address;
    }

    // Methods

    // Checks if the customer is living in the USA
    public bool IsLivingUSA() {
        return _address.IsLivingUSA();
    }

    // Returns a string containing the customer details
    public string DisplayCustomerInfo() {
        return $"\nName: {_name}\nAddress:\n{_address.DisplayAddress()}";
    }
}