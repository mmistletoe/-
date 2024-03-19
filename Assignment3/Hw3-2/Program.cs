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


public class ShapeFactory
{
    public static IShape CreateShape(string shapeType, params double[] dimensions)
    {
        switch (shapeType)
        {
            case "Rectangle":
                if (dimensions.Length == 2)
                {
                    return new Rectangle(dimensions[0], dimensions[1]);
                }
                break;
            case "Square":
                if (dimensions.Length == 1)
                {
                    return new Square(dimensions[0]);
                }
                break;
            case "Triangle":
                if (dimensions.Length == 2)
                {
                    return new Triangle(dimensions[0], dimensions[1]);
                }
                break;
            default:
                throw new ArgumentException("Invalid shape type.");
        }

        throw new ArgumentException("Invalid dimensions for the specified shape.");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        double totalArea = 0;

        for (int i = 0; i < 10; i++)
        {
            // 随机选择形状类型  
            string shapeType = i % 3 == 0 ? "Rectangle" : (i % 3 == 1 ? "Square" : "Triangle");

            // 根据形状类型随机生成尺寸  
            double[] dimensions = new double[shapeType == "Rectangle" || shapeType == "Triangle" ? 2 : 1];
            for (int j = 0; j < dimensions.Length; j++)
            {
                dimensions[j] = rand.NextDouble() * 10; // 生成0到10之间的随机尺寸  
            }

            // 使用工厂创建形状对象  
            IShape shape = ShapeFactory.CreateShape(shapeType, dimensions);

            // 计算并累加面积  
            totalArea += shape.CalculateArea();

            // 输出形状类型和面积  
            Console.WriteLine($"Shape {i + 1}: Type={shapeType}, Area={shape.CalculateArea()}");
        }

        // 输出总面积  
        Console.WriteLine("Total Area: " + totalArea);
    }
}