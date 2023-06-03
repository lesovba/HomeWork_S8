/*Задача 60. ***...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0, 1, 0)
34(1, 0, 0) 41(1, 1, 0)
27(0, 0, 1) 90(0, 1, 1)
26(1, 0, 1) 55(1, 1, 1)*/

//Проверял работу кода для трехмерного массива 2Х2Х2. 

Console.Write("Введите количество строк массива: ");
int rows = int.Parse(Console.ReadLine());

Console.Write("Введите количество столбцов массива: ");
int columns = int.Parse(Console.ReadLine());

Console.Write("Введите третью размерность массива: ");
int thirdDim = int.Parse(Console.ReadLine());

int[,,] array = GetArray(rows, columns, thirdDim, 0, 100);
PrintArray(array);

int[,,] GetArray(int m, int n, int o, int minValue, int maxValue)

{
    int[,,] result = new int[m, n, o];

    //Заполняем трехмерный массив с помощью трёх вложенных циклов.
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int k = 0; k < o; k++)
            //Создадим проверку совпадения элемента новым циклом.
            {
                //Используем bool для того, чтобы отметить совпадение элемента с уже имеющимся.  
                bool check = false;
                //Рандомайзер поместим в переменную для того, чтобы сравнивать элементы в условии.
                int temp = new Random().Next(1, 100);

                //Ищем текущий элемент с помощью l от 0 до k включительно.
                for (int l = 0; l <= k; l++)
                {
                    //В случае того, если элемент уже есть в массиве - прерываем цикл по l,
                    //возвращаемся обратно в цикл по k.
                    //Вторая часть условия для того, чтобы иметь доступ ко всем элементам массива, 
                    //иначе в цикле по l будем пропускать предыдущие элементы по i и j.     
                    if ((result[l, j, k] == temp) || (result[i, l, k] == temp) || (result[i, j, l] == temp) || (result[m - l - 1, j, k] == temp) || (result[i, m - l - 1, k] == temp) || (result[i, j, o - l - 1] == temp))
                    {
                        check = true;
                        break;
                    }

                }
                //Если такого элемента нет, записываем его в наш трехмерный массив.      
                if (check == false)
                {
                    result[i, j, k] = temp;
                }
                else
                    //Если совпадение было, откатываем счетчик на цикл ранее, чтобы повторить его.  
                    k--;
            }
        }
    }
    return result;
}

void PrintArray(int[,,] inArray)
{
    Console.WriteLine();
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int k = 0; k < inArray.GetLength(2); k++)
            {
                Console.Write($"{inArray[i, j, k]} {(i, j, k)}  ");
                //Добавим нолик к однозначным числам для красоты вывода)
                if (inArray[i, j, k] < 10)
                    Console.Write($"0{inArray[i, j, k]} {(i, j, k)}  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}