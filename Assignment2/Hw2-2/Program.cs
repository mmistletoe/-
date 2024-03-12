using System;

class Homework
{
    static void Main(string[] args)
    {
        // 示例数组  
        int[] numbers = { 5, 2, 9, 1, 5, 6 };

        
        (int max, int min, double avg, int sum) = FindMinMaxAvgSum(numbers);
        Console.WriteLine("最大值: " + max);
        Console.WriteLine("最小值: " + min);
        Console.WriteLine("平均值: " + avg);
        Console.WriteLine("总和: " + sum);
    }

    static (int max, int min, double avg, int sum) FindMinMaxAvgSum(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("数组不能为空或没有元素");
        }

        int max = array[0];
        int min = array[0];
        int sum = 0;
        double avg = 0;

        foreach (int num in array)
        {
            sum += num;
            if (num > max)
            {
                max = num;
            }
            if (num < min)
            {
                min = num;
            }
        }

        avg = (double)sum / array.Length;

        return (max, min, avg, sum);
    }
}