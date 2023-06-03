/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку 
с наименьшей суммой элементов.
Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/
//

int[,] array = GetArray(1, 10);

ChooseMinRowSum(array);
//В первом методе создаем и выводим его в консоль. 
int[,] GetArray(int minValue, int maxValue)

{
    Console.Clear();
    Console.Write("Введите количество строк массива: ");
    int rows = int.Parse(Console.ReadLine());

    Console.Write("Введите количество столбцов массива не равное количеству строк: ");
    int columns = int.Parse(Console.ReadLine());
    Console.WriteLine();

    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
            Console.Write($" {result[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    return result;
}

//Во втором методе ищем сумму ряда. Будем принимать в метод индекс, для того чтобы впоследствии была возможность выбирать ряд. 
int[] FindRowSum(int[,] arr, int indexI)
{
    int[] sumRow = new int[arr.GetLength(0)];
    int i = indexI;
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            {
                sumRow[i] += arr[i, j];
            }
        }
    }
    return sumRow;
}

//Третий метод для отображения номера ряда с минимальной суммой и самой минимальной суммы. 
void ChooseMinRowSum(int[,] arr)
{
    //В методе будем индексировать сам метод по i (там лежит одномерный массив), 
    //чтобы не использовать дополнительный массив. 
    int minSum = FindRowSum(arr, 0)[0];
    int numberOfString = 0;

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        if (FindRowSum(arr, i)[i] < minSum)
        {
            minSum = FindRowSum(arr, i)[i];
            numberOfString = i;
        }
    }
    //В финальном сообщении для наглядности нумеровать ряды будем с 1 (индекс+1). 
    Console.WriteLine($"Номер ряда с минимальной суммой {numberOfString + 1}, минимальная сумма равна {minSum}");
    Console.WriteLine();
}