using System;

public class Lab2
{
    public static void Main(string[] args)
    {
        int YES = 1; int NO = 0;
        Console.Write("Write down the size of the matrix--> ");
        int N = int.Parse(Console.ReadLine());
        int[,] array = new int[N, N];

        InputArray(N, array);
        Console.WriteLine("\nContiguity matrix:");
        OutputArray(N, array);

        Console.Write("\nBring the matrix to a power of--> ");
        int Power = int.Parse(Console.ReadLine());
        int[,] ArrayPower = ArrayPow2(N, array, Power);
        OutputArray(N, ArrayPower);


        Console.Write("\nThe length of the ways--> ");
        int AmWays = int.Parse(Console.ReadLine());

        Console.Write("\nMatrix of the number of paths of the length [");
        Console.Write(AmWays);
        Console.WriteLine("]:");

        int[,] WayAmount = FromTopToTopLength(N, array, AmWays);
        OutputArray(N, WayAmount);
    }

    private static int [,] FromTopToTopLength(int N,int[,] array, int AmWays)
    {
        for (int s = 0; s < AmWays; s++)
        {
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    array[row,col]=ArrayWayS(N, array, row, col);

                }
            }
        }
        return array;
    }

    private static int ArrayWayS(int N, int[,] array, int row, int col)
    {
        int[,] TempArray = array;
        int sum = 0;
        
        for (int k = 0; k < N; k++)
        {
            TempArray[row, col] = TempArray[row, k] * array[k, col];
            sum += TempArray[row, col];
        }
        return sum;
    }

    private static int [,] ArrayPow2(int N, int[,] array,int Power)
    {int[,] ArrayUpp2= new int [N,N];
        for (int k = 0; k < Power; k++)
        {
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    ArrayUpp2[row, col] = pow2(N, array, row, col);
                }
            }
        }
        return ArrayUpp2;
    }

    private static int  pow2(int N, int[,] array, int row, int col)
    { int[,] MultipliedArray = array;
        int sum = 0;
        for (int k = 0; k < N; k++)
        {
            MultipliedArray[row, col] = MultipliedArray[row,k]& array[k,col];
            sum|= MultipliedArray[row, col];
        }
        return sum;
    }

    private static void InputArray(int N, int[,] array)
    {
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                Console.Write("Write down [");
                Console.Write(row);
                Console.Write("][");
                Console.Write(col);
                Console.Write("] number of matrix--> ");
                array[row, col] = int.Parse(Console.ReadLine());

            }
        }
    }   
    private static void OutputArray(int N, int[,] array)
    {
        for (int row = 0; row < N; row++)
        { 
            for (int col = 0; col < N; col++)
            { 
            
         
                Console.Write(array[row, col]);
                Console.Write("\t");
            }
            Console.WriteLine();
        }
    }
}

