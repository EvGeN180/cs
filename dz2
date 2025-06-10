//const int sizeA = 5;
//const int rowsB = 3;
//const int colsB = 4;

//int[] A = new int[sizeA];
//double[,] B = new double[rowsB, colsB];

//Random rand = new Random();
//Console.WriteLine($"Введіть {sizeA} цілих чисел для масиву A:");
//for (int i = 0; i < sizeA; i++)
//{
//    A[i] = int.Parse(Console.ReadLine());
//}

//for (int i = 0; i < rowsB; i++)
//{
//    for (int j = 0; j < colsB; j++)
//    {
//        B[i, j] = rand.NextDouble() * 10;
//    }
//}
//Console.WriteLine("\nМасив A:");
//for (int i = 0; i < sizeA; i++)
//{
//    Console.Write(A[i] + " ");
//}
//Console.WriteLine();
//Console.WriteLine("\nМасив B:");
//for (int i = 0; i < rowsB; i++)
//{
//    for (int j = 0; j < colsB; j++)
//    {
//        Console.Write($"{B[i, j]:F2}");
//    }
//    Console.WriteLine();
//}

//double max = A[0];
//double min = A[0];
//double sum = 0;
//double product = 1;

//int sumEvenA = 0;
//for (int i = 0; i < sizeA; i++)
//{
//    if (A[i] > max) max = A[i];
//    if (A[i] < min) min = A[i];
//    sum += A[i];
//    product *= A[i];
//    if (A[i] % 2 == 0)
//        sumEvenA += A[i];
//}

//double sumOddColsB = 0;
//for (int i = 0; i < rowsB; i++)
//{
//    for (int j = 0; j < colsB; j++)
//    {
//        if (B[i, j] > max) max = B[i, j];
//        if (B[i, j] < min) min = B[i, j];
//        sum += B[i, j];
//        product *= B[i, j];
//        if (j % 2 == 1)
//            sumOddColsB += B[i, j];
//    }
//}

//Console.WriteLine($"\nЗагальний максимум: {max:F2}");
//Console.WriteLine($"Загальний мінімум: {min:F2}");
//Console.WriteLine($"Загальна сума: {sum:F2}");
//Console.WriteLine($"Загальний добуток: {product:E2}"); 
//Console.WriteLine($"Сума парних елементів масиву A: {sumEvenA}");
//Console.WriteLine($"Сума елементів непарних стовпців масиву B: {sumOddColsB:F2}");

//const int size = 5;
//int[,] arr = new int[size, size];
//Random rand = new Random();

//for (int i = 0; i < size; i++)
//    for (int j = 0; j < size; j++)
//        arr[i, j] = rand.Next(-100, 101);

//Console.WriteLine("Масив 5x5:");
//for (int i = 0; i < size; i++)
//{
//    for (int j = 0; j < size; j++)
//        Console.Write($"{arr[i, j],5}");
//    Console.WriteLine();
//}

//int min = arr[0, 0], max = arr[0, 0];
//int minIndex = 0, maxIndex = 0; 

//for (int i = 0; i < size; i++)
//{
//    for (int j = 0; j < size; j++)
//    {
//        int linearIndex = i * size + j;
//        if (arr[i, j] < min)
//        {
//            min = arr[i, j];
//            minIndex = linearIndex;
//        }
//        if (arr[i, j] > max)
//        {
//            max = arr[i, j];
//            maxIndex = linearIndex;
//        }
//    }
//}


//int start = Math.Min(minIndex, maxIndex);
//int end = Math.Max(minIndex, maxIndex);
//int sumBetween = 0;

//for (int idx = start + 1; idx < end; idx++)
//{
//    int row = idx / size;
//    int col = idx % size;
//    sumBetween += arr[row, col];
//}

//Console.WriteLine($"\nМінімальний елемент: {min} (індекс {minIndex})");
//Console.WriteLine($"Максимальний елемент: {max} (індекс {maxIndex})");
//Console.WriteLine($"Сума елементів між мінімальним і максимальним: {sumBetween}");



Console.Write("Введіть рядок: ");
string text = Console.ReadLine();

Console.Write("Введіть ключ (зсув): ");
int shift = int.Parse(Console.ReadLine());

char[] result = new char[text.Length];

for (int i = 0; i < text.Length; i++)
{
    char c = text[i];

    if (char.IsLetter(c))
    {
        char offset = char.IsUpper(c) ? 'A' : 'a';
        int pos = c - offset;
        int newPos = (pos + shift) % 26;
        if (newPos < 0)
            newPos += 26;
        result[i] = (char)(offset + newPos);
    }
    else
    {
        result[i] = c; 
    }
}

string unknown = new string(result);
Console.WriteLine("Зашифрований текст: " + unknown);

for (int i = 0; i < unknown.Length; i++)
{
    char c = unknown[i];

    if (char.IsLetter(c))
    {
        char offset = char.IsUpper(c) ? 'A' : 'a';
        int pos = c - offset;
        int newPos = (pos - shift) % 26;
        if (newPos < 0)
            newPos += 26;
        result[i] = (char)(offset + newPos);
    }
    else
    {
        result[i] = c;
    }
}

string known = new string(result);
Console.WriteLine("Розшифрований текст: " + known);
