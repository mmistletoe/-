using System;
namespace Homework1
{
    class Homework1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数字：");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入运算符：");
            string op = Console.ReadLine();

            Console.WriteLine("请输入第二个数字：");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = Calculate(num1, num2, op);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static double Calculate(double num1, double num2, string op)
        {
            switch (op)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    if (num2 != 0)
                        return num1 / num2;
                    else
                        throw new DivideByZeroException();
                default:
                    throw new InvalidOperationException(op);
            }
        }
    }
}
