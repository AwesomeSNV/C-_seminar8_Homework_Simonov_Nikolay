Console.Write("Введите колличество строк первого и второго массивов: ");
int rows = int.Parse(Console.ReadLine()!);
Console.Write("Введите колличество столбцов первого и второго массивов: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array = GetArray(rows, columns, 0, 100);
Console.WriteLine("Первый исходный массив:");
PrintArray(array);
Console.WriteLine();

int[,] secondArray = GetArray(rows, columns, 0, 100);
Console.WriteLine("Второй исходный массив:");
PrintArray(secondArray);
Console.WriteLine();

// К заданию с семинара
SortArrayLine(array);
Console.WriteLine("Массив с упорядоченными элементами по возрастанию в каждом нечетном столбце:");
PrintArray(array);

// К заданию 54
SelectionSortArray(array);
Console.WriteLine("Массив с упорядоченными элементами по убыванию в каждой строке:");
PrintArray(array);
Console.WriteLine();

// Отсортировать нечетные столбцы массива по возрастанию. Вывести массив изначальный и массив с отсортированными нечетными столбцами

void SortArrayLine(int[,] array)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        if (j % 2 != 0)
        {
            for (int i = 0; i < array.GetLength(1) - 1; i++)
            {
                for (int k = 0; k < array.GetLength(1) - 1; k++)
                {
                    if (array[k + 1,j] < array[k, j])
                    {
                        int temporary = array[k + 1, j];
                        array[k +1, j] = array[k, j];
                        array[k, j] = temporary;
                    }
                }
            }
        }
    }
}

// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

void SelectionSortArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - 1; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    int temporary = array[i, k + 1];
                    array[i, k + 1] = array[i, k];
                    array[i, k] = temporary;
                }
            }
        }
    }
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int lineNumber = 0;
int sumLine = SumLineElements(array, 0);
for (int i = 1; i < array.GetLength(0); i++)
{
    int temp = SumLineElements(array, i);
    if (sumLine > temp)
    {
        sumLine = temp;
        lineNumber = i;
    }
}
Console.WriteLine($"Строка с наименьшей суммой элементов: {lineNumber + 1}. Сумма элементов в строке: {sumLine}.");
int SumLineElements(int[,] array, int i)
{
    int sumLine = array[i, 0];
    for (int j = 1; j < array.GetLength(1); j++)
    {
        sumLine += array[i, j];
    }
    return sumLine;
}

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] resultArray = new int[rows,columns];
MultiplyArray(array, secondArray, resultArray);
Console.WriteLine("Произведение двух матриц: ");
PrintArray(resultArray);

void MultiplyArray(int[,] array, int[,] secondArray, int[,] resultArray)
{
    for (int i = 0; i < resultArray.GetLength(0); i++)
    {
        for (int j = 0; j < resultArray.GetLength(1); j++)
        {
            int multiply = 0;
            for (int k = 0; k < array.GetLength(1); k++)
            {
                multiply += array[i, k] * secondArray[k, j];
            }
            resultArray[i, j] = multiply;
        }
    }
}

// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


Console.WriteLine("Введите размеры трехмерного массива X - Y - Z: ");
Console.Write("Введите X: ");
int x = int.Parse(Console.ReadLine()!);
Console.Write("Введите Y: ");
int y = int.Parse(Console.ReadLine()!);
Console.Write("Введите Z: ");
int z = int.Parse(Console.ReadLine()!);
int[,,] array3d = new int[x,y,z];
GetArray3D(array3d);
PrintArray3D(array3d);
Console.WriteLine();

void GetArray3D(int[,,] array3d)
{
    int[] temporary = new int[array3d.GetLength(0) * array3d.GetLength(1) * array3d.GetLength(2)];
    int number = 0;
    for (int i = 0; i < temporary.GetLength(0); i++)
    {
        temporary[i] = new Random().Next(10, 100);
        number = temporary[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (temporary[i] == temporary[j])
                {
                    temporary[i] = new Random().Next(10, 100);
                    j = 0;
                    number = temporary[i];
                }
                number = temporary[i];
            }
        }
    }
    int count = 0;
    for (int x = 0; x < array3d.GetLength(0); x++)
    {
        for (int y = 0; y < array3d.GetLength(1); y++)
        {
            for (int z = 0; z < array3d.GetLength(0); z++)
            {
                array3d[x, y, z] = temporary[count];
                count++;
            }
        }
    }
}

void PrintArray3D(int[,,] array3d)
{
    for (int i = 0; i < array3d.GetLength(0); i++)
    {
        for (int j = 0; j < array3d.GetLength(1); j++)
        {
            for (int k = 0; k < array3d.GetLength(0); k++)
            {
                Console.Write($"{array3d[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
}

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.Write("Введите колличество строк и столбцов квадратного двухмерного массива: ");
int number = int.Parse(Console.ReadLine()!);
int[,] arraySqare = new int[number,number];
int temporary = 1;
int iSqr = 0;
int jSqr = 0;
while(temporary<=arraySqare.GetLength(0) * arraySqare.GetLength(1))
{
    arraySqare[iSqr,jSqr] = temporary;
    temporary++;
    if(iSqr <= jSqr + 1 && iSqr + jSqr < arraySqare.GetLength(1) - 1)
    {
        jSqr++;
    }
    else if(iSqr < jSqr && iSqr + jSqr >= arraySqare.GetLength(0) - 1)
    {
        iSqr++;
    }
    else if(iSqr >= jSqr && iSqr + jSqr > arraySqare.GetLength(1) - 1)
    {
        jSqr--;
    }
    else
    {
        iSqr--;
    }
}

PrintArray(arraySqare);
Console.WriteLine();


// Если решено:
// 1-2 задачи - удовлетворительно
// 3-4 - хорошо
// 5 - отлично

// Рекомендовано решить(задача с семинара)



//General Methods

int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}