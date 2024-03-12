using System;

class Homework
{
    static void Main(string[] args)
    {
        Console.Write("请输入一个正整数：");
        string input = Console.ReadLine();
        long number;
        if (!long.TryParse(input, out number) || number <= 0)
        {
            Console.WriteLine("输入的不是一个正整数，请重新输入！");
            return;
        }

        Console.WriteLine("该数的所有素数因子为：");
        for (long i = 2; i <= Math.Sqrt(number); i++)
        {
            while (number % i == 0)
            {
                Console.Write(i + " ");
                number /= i;
            }
        }
        if (number > 1)
        {
            Console.Write(number);
        }
    }
}