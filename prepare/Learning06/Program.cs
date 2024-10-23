using System;

class Program
{
    static void Main(string[] args)
    {
        // New square object
        Square square = new Square("Blue", 2.5);

        // New rectangle object
        Rectangle rectangle = new Rectangle("Red", 5, 4);

        // New circle object
        Circle circle = new Circle("Yellow", 3.2);

        // A list with all objects
        List<Shape> shapeList = new List<Shape>();
        shapeList.Add(square);
        shapeList.Add(rectangle);
        shapeList.Add(circle);

        foreach (Shape shapes in shapeList)
        {
            Console.WriteLine(shapes.GetColor());
            Console.WriteLine(shapes.GetArea());
            Console.WriteLine();
        }
    }
}