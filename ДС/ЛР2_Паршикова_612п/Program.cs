using System;

public class Lab2
{
    public static void Main(string[] args)
    {
        int YES = 1; int NO = 0;
        Console.Write("Write down the size of the matrix--> ");
        int N = int.Parse(Console.ReadLine());
        int[,] array = new int[N, N];

        Console.WriteLine("Write down the contiguity matrix (only \"o\" or \"1\")");
    
        InputArray(N, array);
        Console.WriteLine("\nContiguity matrix:");
        OutputArray(N, array);

        Console.WriteLine("\nThe matrix raised to the power of 2");
        int[,] ArrayPower2 = ArrayPow2(N, array);
        OutputArray(N, ArrayPower2);

        Console.WriteLine("\nThe matrix raised to the power of 4");
        int[,] ArrayPower4 = ArrayPow2(N, ArrayPower2);
        OutputArray(N, ArrayPower4);

        Console.WriteLine("\nThe matrix raised to the power of 8");
        int[,] ArrayPower8 = ArrayPow2(N, ArrayPower4);
        OutputArray(N, ArrayPower8);

        int choose;

        do
        {
            Console.Write("\nThe length of the ways--> ");
            int AmWays = int.Parse(Console.ReadLine());

            Console.Write("\nMatrix of the number of paths of the length [");
            Console.Write(AmWays);
            Console.WriteLine("]:");

            int[,] WayAmount = FromTopToTopLength(N, array, AmWays);
            OutputArray(N, WayAmount);
            choose = ChooseYesOrNo(YES, NO);
        } while (choose == YES);
    }

    private static int ChooseYesOrNo(int YES, int NO)
    {
        Console.WriteLine("Would you like to repeat the action?");
        Console.Write("YES--> 1\tNo--> 0\t");
        int choose = int.Parse(Console.ReadLine());
        while (choose != YES && choose!=NO)
        {
            Console.Write("The chosen option is not avaluable. Try again-->");
            choose = int.Parse(Console.ReadLine());
        }

        return choose;
    }

    private static int[,] FromTopToTopLength(int N, int[,] array, int AmWays)
    { int[,] tempArray = new int[N,N];
        for (int s = 0; s < AmWays; s++)
        {
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    tempArray[row, col] = ArrayWayS(N, array, row, col);

                }
            }
        }
        return array;
    }

    private static int ArrayWayS(int N, int[,] array, int row, int col)
    {
        int[,] TempArray=new int [N,N];
        int sum = 0;

        for (int k = 0; k < N; k++)
        {
            TempArray[row, col] = array[row, k] * array[k, col];
            sum = sum+ TempArray[row, col];
        }
        return sum;
    }

    private static int[,] ArrayPow2(int N, int[,] array)
    {
        int[,] ArrayUpp2 = new int[N, N];
       
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    ArrayUpp2[row, col] = pow2(N, array, row, col);
                }
            }
        
        return ArrayUpp2;
    }

    private static int pow2(int N, int[,] array, int row, int col)
    {
        int[,] MultipliedArray = array;
        int sum = 0;
        for (int k = 0; k < N; k++)
        {
            MultipliedArray[row, col] = MultipliedArray[row, k] & array[k, col];
            sum |= MultipliedArray[row, col];
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
