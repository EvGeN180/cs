using System;

abstract class Shape
{
    public abstract double GetPerimeter();
    public abstract double GetArea();
    public virtual string GetInfo() => "Hello Shape";
}

class Rectangle : Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public override double GetArea() => Width * Height;
    public override double GetPerimeter() => (Width + Height) * 2;
    public override string GetInfo() => "Hello Rectangle";
}

class Circle : Shape
{
    public double Radius { get; set; }
    public override double GetArea() => Radius * Radius * 3.14;
    public override double GetPerimeter() => 3.14 * 2 * Radius;
    public override string GetInfo() => "Hello Circle";
}

class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public override double GetPerimeter() => A + B + C;
    public override double GetArea()
    {
        double s = GetPerimeter() / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C)); // Heron's formula
    }
    public override string GetInfo() => "Hello Triangle";
}


class Square : Shape
{
    public double Side { get; set; }
    public override double GetPerimeter() => 4 * Side;
    public override double GetArea() => Side * Side;
    public override string GetInfo() => "Hello Square";
}

class Program
{
    static void Main()
    {
        Shape rect = new Rectangle { Width = 5, Height = 3 };
        Shape circle = new Circle { Radius = 4 };
        Shape triangle = new Triangle { A = 3, B = 4, C = 5 };
        Shape square = new Square { Side = 4 };
        Console.WriteLine(rect.GetInfo() + $": Area = {rect.GetArea()}, Perimeter = {rect.GetPerimeter()}");
        Console.WriteLine(circle.GetInfo() + $": Area = {circle.GetArea()}, Perimeter = {circle.GetPerimeter()}");
        Console.WriteLine(triangle.GetInfo() + $": Area = {triangle.GetArea()}, Perimeter = {triangle.GetPerimeter()}");
        Console.WriteLine(square.GetInfo() + $": Area = {square.GetArea()}, Perimeter = {square.GetPerimeter()}");
    }
}
