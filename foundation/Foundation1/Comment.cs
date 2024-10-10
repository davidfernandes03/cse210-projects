class Comment {
    // Attributes
    private string _name;
    private string _text;

    // Constructor
    public Comment(string name, string text) {
        _name = name;
        _text = text;
    }

    // Methods
    public string GetCommentsDetails() {
        return $"{_name}: {_text}";
    }
}