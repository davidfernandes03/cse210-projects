public class Square : Shape
{
    private double _size;

    public Square(string color, double size) : base(color)
    {
        _size = size;
    }

    public override double GetArea()
    {
        return _size * 4;
    }
}