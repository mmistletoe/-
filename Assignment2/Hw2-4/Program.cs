using System;

class Homework
{
    static void Main()
    {
        int[,] matrix = {
            { 1, 2, 3, 4 },
            { 5, 1, 2, 3 },
            { 9, 5, 1, 2 }
        };

        bool isToeplitz = IsToeplitzMatrix(matrix);
        Console.WriteLine("Is the matrix a Toeplitz matrix? " + isToeplitz);
    }

    static bool IsToeplitzMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // 遍历矩阵的每个元素  
        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = 0; j < cols - 1; j++)
            {
                // 比较当前元素与其右下方的元素是否相等  
                if (matrix[i, j] != matrix[i + 1, j + 1])
                {
                    return false; // 如果不相等，则不是托普利茨矩阵  
                }
            }
        }

        return true; // 所有元素都满足条件，是托普利茨矩阵  
    }
}