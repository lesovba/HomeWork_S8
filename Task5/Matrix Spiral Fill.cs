/*Задача 62 *** Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/

/*Код работает для квадратных матриц, где количество рядов и колонок равны.*/
Console.WriteLine("Введите размер матрицы (количество рядов и колонок равны): ");
int size = int.Parse(Console.ReadLine());
Console.WriteLine();
int[,] spiralMatrix = SpiralMatrixFill(size);

PrintArray(spiralMatrix);
Console.WriteLine();

//Суть моего метода состоит в том, чтобы получить все индексы элементов по завершении внешнего цикла, 
//а дальше последовательно выражать элементы через предыдущие. 
int[,] SpiralMatrixFill(int size)
{
    int[,] matrix = new int[size, size];
    //Инициализируем matrix[0, 0] для того, чтобы через него выражать последующие элементы. 
    matrix[0, 0] = 1;
    //Инициализируем переменную temp для того, чтобы хранить последний элемент, который получаем по завершении последнего цикла.
    //Его необходимо использовать для выражения элементов в последующих проходах по циклу k.  
    int temp = 0;
    //Для того, чтобы выразить все индексы через k, достаточно дойти до k=size/2.
    for (int k = 0; k <= size / 2; k++)
    {
        for (int j = k; j < (size - k); j++)
        {
            //Для того, чтобы получить следующий элемент, выражаем его через предыдущий. 
            //Для нулевого цикла необходимо оставить второй индекс matrix[k, 0] равным 0. 
            //По-другому я выразить его не смог. 
            if (k == 0)
                matrix[k, j] = matrix[k, 0] + j;
            //Для последующих циклов (при k не равному 0) последующие элементы выражаются следующим образом:             
            else
                matrix[k, j] = temp + j + 1 - k;
        }
        for (int i = k; i < (size - k); i++)
        {
            matrix[i, size - 1 - k] = matrix[k, size - 1 - k] + i - k;
        }
        for (int j = size - 1 - k; j >= k; j--)
        {
            matrix[size - 1 - k, j] = matrix[size - 1 - k, size - 1 - k] + (size - 1 - j - k);
        }
        for (int i = size - 1 - k; i > k; i--)
        {
            matrix[i, k] = matrix[size - 1 - k, k] + (size - 1 - i - k);
            temp = matrix[i, k];
        }
    }
    return matrix;
}

//Метод для вывода массива в консоль. 
void PrintArray(int[,] inArray)
{

    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            if (inArray[i, j] < 10)
                Console.Write($"0{inArray[i, j]} ");
            else
                Console.Write($"{inArray[i, j]} ");

        }
        Console.WriteLine();
    }
}