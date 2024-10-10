class Address {
    // Attributes
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Constructor
    public Address(string street, string city, string state, string country) {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Initializes a new instance of the Address class without a state
    public Address(string street, string city, string country) {
        _street = street;
        _city = city;
        _country = country;
        _state = null;
    }

    // Methods

    // Checks if the address is in the USA
    public bool IsLivingUSA() {
        return _country.ToUpper() == "USA";
    }

    // Returns a string containing the address details
    public string DisplayAddress() {
        if (string.IsNullOrEmpty(_state)) {
            return $"{_street}\n{_city}\n{_country}";
        }
        else {
            return $"{_street}\n{_city}, {_state}\n{_country}";
        }
    }
}