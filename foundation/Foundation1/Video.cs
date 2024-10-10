class Video {
    // Attributes
    private string _title;
    private string _author;
    private int _lenght;
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int lenght) {
        _title = title;
        _author = author;
        _lenght = lenght;
        _comments = new List<Comment>();
    }

    // Methods
    public int GetCommentsTotal() {
        return _comments.Count;
    }

    public void DisplayVideoDetails() {
        Console.WriteLine();
        Console.WriteLine($"Title: {_title}, Author: {_author}, Lenght: {_lenght} seconds");
        Console.WriteLine();
        Console.WriteLine($"Number of comments: {GetCommentsTotal()}");

        foreach (Comment comment in _comments) {
            Console.WriteLine(comment.GetCommentsDetails());
        }
    }

    public void AddComment(Comment comment) {
        _comments.Add(comment);
    }
}