using System;

class Homework
{
    static void Main()
    {
        int maxNum = 100;
        bool[] isPrime = new bool[maxNum + 1]; // 默认都初始化为false，即默认都是素数  

        // 初始化数组，除了0和1以外，其他数都认为是素数  
        for (int i = 2; i <= maxNum; i++)
        {
            isPrime[i] = true;
        }

        // 从最小的素数2开始筛选  
        for (int i = 2; i * i <= maxNum; i++)
        {
            // 如果i是素数  
            if (isPrime[i])
            {
                // 标记i的所有倍数为非素数  
                for (int j = i * i; j <= maxNum; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        // 输出素数  
        for (int i = 2; i <= maxNum; i++)
        {
            if (isPrime[i])
            {
                Console.Write(i + " ");
            }
        }
    }
}