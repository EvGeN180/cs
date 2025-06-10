//Console.Write("Введіть число: ");
//int n = int.Parse(Console.ReadLine());

//if (n < 1 || n > 100)
//    Console.WriteLine("Помилка!");
//else if (n % 15 == 0)
//    Console.WriteLine("Fizz Buzz");
//else if (n % 3 == 0)
//    Console.WriteLine("Fizz");
//else if (n % 5 == 0)
//    Console.WriteLine("Buzz");
//else
//    Console.WriteLine(n);




//Console.Write("Введіть число: ");
//double num = double.Parse(Console.ReadLine());

//Console.Write("Введіть відсоток: ");
//double percent = double.Parse(Console.ReadLine());

//double result = num * percent / 100;

//Console.WriteLine($"Результат: {result}");




//Console.WriteLine("Введіть чотири цифри:");

//string num1 = Console.ReadLine();
//string num2 = Console.ReadLine();
//string numt3 = Console.ReadLine();
//string num4 = Console.ReadLine();

//string number = num1+num2+numt3+num4;

//Console.WriteLine($"Сформоване число: {number}");



//Console.Write("Введіть шестизначне число: ");
//string number = Console.ReadLine();

//if (number.Length != 6)
//{
//    Console.WriteLine("Помилка: число має бути шестизначним.");
//    return;
//}

//Console.Write("Введіть перший номер розряду для заміни (1-6): ");
//int pos1 = int.Parse(Console.ReadLine()) - 1;

//Console.Write("Введіть другий номер розряду для заміни (1-6): ");
//int pos2 = int.Parse(Console.ReadLine()) - 1;

//char[] digits = number.ToCharArray();

//char temp = digits[pos1];
//digits[pos1] = digits[pos2];
//digits[pos2] = temp;

//string result = new string(digits);

//Console.WriteLine($"Результат: {result}");


//using System.Globalization;

//Console.Write("Введіть дату у форматі dd.MM.yyyy: ");
//DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

//string season = "";

//if (date.Month == 12 || date.Month == 1 || date.Month == 2)
//    season = "Winter";
//else if (date.Month >= 3 && date.Month <= 5)
//    season = "Spring";
//else if (date.Month >= 6 && date.Month <= 8)
//    season = "Summer";
//else if (date.Month >= 9 && date.Month <= 11)
//    season = "Autumn";

//Console.WriteLine($"{season} {date.DayOfWeek}");


//Console.Write("Введіть температуру: ");
//double temp = double.Parse(Console.ReadLine());

//Console.Write("Оберіть одиницю конвертації (1 - F to C, 2 - C to F): ");
//int choice = int.Parse(Console.ReadLine());

//if (choice == 1)
//{
//    double celsius = (temp - 32) * 5 / 9;
//    Console.WriteLine($"Температура в Цельсіях: {celsius:F2}");
//}
//else if (choice == 2)
//{
//    double fahrenheit = (temp * 9 / 5) + 32;
//    Console.WriteLine($"Температура в Фаренгейтах: {fahrenheit:F2}");
//}
//else
//{
//    Console.WriteLine("Помилка: невірний вибір.");
//}

Console.Write("Введіть перше число: ");
int a = int.Parse(Console.ReadLine());

Console.Write("Введіть друге число: ");
int b = int.Parse(Console.ReadLine());

int start = Math.Min(a, b);
int end = Math.Max(a, b);

Console.WriteLine($"Парні числа в діапазоні від {start} до {end}:");

for (int i = start; i <= end; i++)
{
    if (i % 2 == 0)
        Console.WriteLine(i);
}