

using System;
using System.Globalization;

int task;

string task1 = "1. Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел строго больше 0 ввёл пользователь.";
string task2 = "2. Написать программу, которая на вход принимает массив из любого количества элементов (не менее 6)в промежутке от 0 до 100,\r\n а на выходе выводит этот же массив, но отсортированный по возрастанию(от меньшего числа к большему).";

int SelectionTask()
{
    Console.WriteLine(task1);
    Console.WriteLine(task2);
    Console.Write("Выберите задачу (от 1 до 2): ");
    if (!int.TryParse(Console.ReadLine(), out int task) || task > 2 || task < 1)
    {
        Console.Clear();
        task = SelectionTask();
    }
    return task;
}

int[] ParseArrayStringToInt(string[] numS, int minNumber = Int32.MinValue, int maxNumber = Int32.MaxValue)
{
    int[] numInt = new int[numS.Length];
    int j = 0;
    for (int i = 0; i < numS.Length; i++)
    {
        if (int.TryParse(numS[i], out numInt[j]) && minNumber < numInt[j] && maxNumber > numInt[j]) j++;
    }
    Array.Resize(ref numInt, j);

    return numInt;
}

int[] InputAndWriteconsoleArray(string ConsoleWrite, int minNumber = Int32.MinValue, int maxNumber = Int32.MaxValue)
{
    Console.WriteLine(ConsoleWrite);
    string[] numS = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    int[] numInt = ParseArrayStringToInt(numS, minNumber, maxNumber);
    Console.WriteLine($"Введённый массив: {String.Join(" ", numInt)}");
    return numInt;
}


//Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел строго больше 0 ввёл пользователь.

int CountPositive(int[] num)
{
    int count = 0;
    for (int i = 0; i < num.Length; i++)
    {
        if (num[i] > 0) count++;
    }
    return count;
}

//Написать программу, которая на вход принимает массив из любого количества элементов (не менее 6)в промежутке от 0 до 100,
//    а на выходе выводит этот же массив, но отсортированный по возрастанию(от меньшего числа к большему).

int[] SortAscend(int[] Array)
{
    Boolean sort = false;
    int Temp;
    int length = Array.Length;
    for (int j = 1; j < length; j++)
    {
        if (!sort)
        {
            for (int i = 0; i < length - j; i++)
            {
                sort = true;
                if (Array[i] > Array[i + 1])
                {
                    Temp = Array[i];
                    Array[i] = Array[i + 1];
                    Array[i + 1] = Temp;
                    sort = false;
                }
            }
        }
    }
    return Array;
}


//--------------------------------------------
string? working = "y";
while (working.ToLower() == "Y".ToLower())
{
    Console.Clear();
    task = SelectionTask();
    if (task == 1)
    {
        int[] numInt = InputAndWriteconsoleArray("Введите массив чисел:");
        Console.WriteLine($"Положительных чисел в массиве: {CountPositive(numInt)}");
    }
    else if (task == 2)
    {
        int[] numInt = InputAndWriteconsoleArray("Введите массив из любого количества элементов (не менее 6) в промежутке от 0 до 100:", 0, 100);
        int minLength = 6;
        if (minLength > numInt.Length) Console.WriteLine("Введённый вами массив менее необходимой длины");
        else Console.WriteLine($"Отсортированный массив:\r\n{String.Join(" ",SortAscend(numInt))}");
    }
    
    Console.WriteLine("Введите 'Y' для продолжения или любой другой символ для закрытия...");
    working = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(working))
    {
        working = "n";
    }
}
