/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

int[,] matrix1 = GetArray(1, 10);
int[,] matrix2 = GetArray(1, 10);
int[,] resultMatrix = MatrixProduct(matrix1, matrix2);

PrintArray("Матрица №1", matrix1);
PrintArray("Матрица №2", matrix2);
PrintArray("Произведение матриц", resultMatrix);

//Первый метод для создания двух матриц. 
int[,] GetArray(int minValue, int maxValue)

{
    Console.Clear();
    Console.Write("Введите количество строк массива: ");
    int rows = int.Parse(Console.ReadLine());

    Console.Write("Введите количество столбцов массива: ");
    int columns = int.Parse(Console.ReadLine());
    Console.WriteLine();

    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);

        }
    }
    Console.WriteLine();
    return result;
}

//Второй метод для нахождения произведения двух матриц и размещения результата в двухмерном массиве. 
int[,] MatrixProduct(int[,] arr1, int[,] arr2)
{
    //Количество строк и столбцов новой матрицы выбираем исходя из того, что две матрицы равны по размеру. 
    //В случае, если две матрицы по размеру не равны, код и формула будут другими. 
    int newRows = arr1.GetLength(0);
    int newColumns = arr1.GetLength(1);
    int[,] matrixProduct = new int[newRows, newColumns];

    for (int i = 0; i < newRows; i++)
    {
        for (int j = 0; j < newColumns; j++)
        {
            //Для того, чтобы воспользоваться формулой для перемножения двух матриц потребуется третий цикл, 
            //чтобы передавать изменения индексов первой и второй матриц. 
            for (int k = 0; k < newColumns; k++)
            {
                matrixProduct[i, j] += arr1[i, k] * arr2[k, j];
            }

        }
    }
    return matrixProduct;
}

//Метод для печати массива. Передадим параметром строку, чтобы отображать название матриц. 
void PrintArray(string message, int[,] inArray)
{
    Console.WriteLine(message);
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($" {inArray[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}