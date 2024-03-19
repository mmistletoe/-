public interface IShape
{
    double CalculateArea();
    bool IsValid();
}

public abstract class ShapeBase : IShape
{
    // 是否为合法形状  
    protected bool _isValid = true;

    // 抽象方法，需要在派生类中实现  
    public abstract double CalculateArea();

    // 判断形状是否合法  
    public virtual bool IsValid()
    {
        return _isValid;
    }

    // 设置形状是否合法  
    protected void SetValidity(bool isValid)
    {
        _isValid = isValid;
    }
}

// 长方形类  
public class Rectangle : ShapeBase
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override bool IsValid()
    {
        // 假设宽度和高度都大于0才为合法  
        return Width > 0 && Height > 0;
    }
}

// 正方形类，继承自长方形，并添加正方形的特性  
public class Square : Rectangle
{
    public Square(double side) : base(side, side)
    {
    }
}

// 三角形类  
public class Triangle : ShapeBase
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double baseLength, double height)
    {
        Base = baseLength;
        Height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * Base * Height;
    }

    public override bool IsValid()
    {
        // 假设底和高都大于0才为合法  
        return Base > 0 && Height > 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 创建长方形对象  
        Rectangle rectangle = new Rectangle(5, 10);
        Console.WriteLine("Rectangle Area: " + rectangle.CalculateArea());
        Console.WriteLine("Rectangle Is Valid: " + rectangle.IsValid());

        // 创建正方形对象  
        Square square = new Square(5);
        Console.WriteLine("Square Area: " + square.CalculateArea());
        Console.WriteLine("Square Is Valid: " + square.IsValid());

        // 创建三角形对象  
        Triangle triangle = new Triangle(3, 4);
        Console.WriteLine("Triangle Area: " + triangle.CalculateArea());
        Console.WriteLine("Triangle Is Valid: " + triangle.IsValid());
    }
}