
using System.Globalization;

Console.Write("Write down the size of your field--> ");
int r = int.Parse(Console.ReadLine());

int[,] field = new int[r, r];

FillTheMatrix(r, field);

int[,] field_of_paths = new int[r, r];

FindTheMinValueOfTheCell(r, field, field_of_paths);

//FindNumberOfPaths(r, field);

Console.WriteLine("In each cell of the field the number of ways to get in it is wrote:");

PrintTheMatrix(r, field);
PrintTheMatrix(r, field_of_paths);

int f = r - 1;
int h = f;

//do
//{
//    int min = Math.Min(field_of_paths[f - 1, h], Math.Min(field_of_paths[f, h - 1], field_of_paths[f - 1, h - 1]));
//    if (field_of_paths[f - 1, h] == min)
//    {
//        f--;
//        Console.WriteLine($"index of minimum [ {f}, {h}]");

//    }

//    else if (field_of_paths[f, h - 1] == min)
//    {
//        h--;
//        Console.WriteLine($"index of minimum [ {f}, {h }]");

//    }
//    else if (field_of_paths[f - 1, h - 1] == min)
//    {
//        f--;
//        h--;
//        Console.WriteLine($"index of minimum [ {f}, {h}]");

//    }
//}while(f!=0||h!=0);

//if (f == 0)
//    do
//    {
//        Console.WriteLine($"index of minimum [ {0}, {h}]");
//        h--;
//    } while (h!=0);
//else if(h == 0)
//    do
//    {
//        Console.WriteLine($"index of minimum [ {f}, {0}]");
//        f--;
//    } while (f!= 0);


////static void FindNumberOfPaths(int r, int[,] field)
////{
////    for (int n = 0; n < r; n++)
////    {
////        field[0, n] = 1;
////        field[n, 0] = 1;
////    }
////    for (int i = 1; i < r; i++)
////    {
////        for (int j = 1; j < r; j++)
////        {
////            field[i, j] = field[i - 1, j] + field[i, j - 1];
////        }
////    }
////}

static void PrintTheMatrix(int r, int[,] field)
{
    for (int k = 0; k < r; k++)
    {
        for (int s = 0; s < r; s++)
        {
            Console.Write(field[k, s] + "\t");
        }
        Console.WriteLine();
    }
}

static void FillTheMatrix(int r, int[,] field)
{
    for (int i = 0; i < r; i++)
    {
        for (int j = 0; j < r; j++)
        {
            field[i, j] = int.Parse(Console.ReadLine());
        }
    }
}

static void FindTheMinValueOfTheCell(int r, int[,] field, int[,] field_of_paths)
{
    field_of_paths[0, 0] = field[0,0];
    for (int i = 1; i < r; i++)
    {
        field_of_paths[i, 0] = field_of_paths[i - 1, 0] + field[i, 0];
    }
    for (int j = 1; j < r; j++)
    {
        field_of_paths[0, j] = field_of_paths[0, j - 1] + field[0, j];
    }
   
    for (int i = 1; i < r; i++)
    { 
        for (int j = 1; j < r; j++)
        {
           
            field_of_paths[i, j] = Math.Min(field_of_paths[i - 1, j], Math.Min(field_of_paths[i, j - 1], field_of_paths[i - 1, j - 1])) + field[i, j];
        }
    }
}