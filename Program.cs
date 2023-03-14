// Написать программу, которая из имеющегося массива строк формирует массив из строк, 
// длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры, 
// либо задать на старте выполнение алгоритма. При решении не рекомендуется пользоваться коллекциями, 
// лучше обойтись исключительными массивами.

bool inWork = true;
Random random = new Random();

#region Switch

while (inWork)
{
    Console.Clear();
    Console.WriteLine("Инициализация программы");
    Console.WriteLine("====================================");
    Console.Write($"Выберите варианты заполнения массива:"
    + "\n Нажмите \"1\" - заполненить массив вручную"
    + "\n Нажмите \"2\" - автозаполнение массива"
    + "\n Введите \"3\" - выйти из программы"
    + "\n Введите ваш вариант: ");
    
    if (int.TryParse(Console.ReadLine(), out int i))
    {
        switch (i)
        {
            case 1:
                {
                    //Console.Clear();
                    HandArr();
                    Exit();
                    break;
                }

            case 2:
                {
                    Console.Clear();
                    AutoArr();
                    Exit();
                    break;
                }

            case 3: inWork = false; break;
        }
    }
}
#endregion

#region Tasks

void AutoArr()
{
    string[] array = CreateAutoArr(random.Next(1, 7));
    Console.WriteLine("Сгенерированный массив:");
    PrintArray(array);
    Console.WriteLine();
    Console.WriteLine("Новый массив:");
    PrintArray(SearchThrElem(array));
}

void HandArr()
{
    string[] array = CreateArr(ReadInt("Введи колличество элемментов в массиве"));
    Console.WriteLine("Ваш массив:");
    PrintArray(array);
    Console.WriteLine();
    Console.WriteLine("Новый массив:");
    PrintArray(SearchThrElem(array));
}

#endregion

#region MetodsForTasks

int ReadInt(string argName)
{
    Console.Write($"{argName}: ");

    int number = 0;
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("Вы ввели не то, введите нужные данные");
    }
    return number;
}

string ReadString(string argName)
{
    Console.Write($"{argName}: ");
    return Console.ReadLine();
}

string[] CreateArr(int size)
{
    string[] array = new string[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = ReadString($"{i + 1} элемент");
    }
    return array;
}

string RandomWord()
{
    string word = "";
    string[] randomSymbol = {"a", "b", "c", "d", "e", "f", "g", "h", "i","j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u",
                            "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "=", "-", ")", "*", "_", "+", "()"};                       
    for (int i = 0; i < random.Next(1, 8); i++)
    {
        word += randomSymbol[random.Next(0, randomSymbol.Length)];
    }
    return word;
}

string[] CreateAutoArr(int size)
{
    string[] array = new string[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = RandomWord();
    }
    return array;
}

string[] DeleteEmptyElementsArray(string[] array, int size)
{
    string[] newArr = new string[size];
    for (int i = 0; i < newArr.Length; i++)
    {
        newArr[i] = array[i];
    }
    return newArr;
}

string[] SearchThrElem(string[] array)
{
    int k = 0;
    string[] newArr = new string[array.Length];

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= 3)
        {
            newArr[k] = array[i];
            k++;
        }
    }
    return DeleteEmptyElementsArray(newArr, k);
}

void PrintArray(string[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1)
        {
            Console.Write($"\"{array[i]}\"");
        }
        else
        {
            Console.Write($"\"{array[i]}\", ");
        }
    }
    Console.WriteLine("]");
}

void Exit()
{
    Console.WriteLine("====================================");
    Console.WriteLine("Нажмите любую клавишу");
    Console.ReadKey();
}

#endregion