namespace WorkWithFIles;
using System;
using System.IO;
using System.Linq;

class Program
{
    const string path = "text.txt";

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("----Меню----");
            Console.WriteLine("1. К-ть певного слова");
            Console.WriteLine("2. Замінити підрядок");
            Console.WriteLine("3. Порахувати голосні");
            Console.WriteLine("4. К-сть слів");
            Console.WriteLine("5. Перевернути слово");
            Console.WriteLine("6. Додати рядок, якщо нема його");
            Console.WriteLine("7. Видалити всі цифри");
            Console.WriteLine("8. Знайти рядки по словам");
            Console.WriteLine("9. Вихід");
            Console.Write("Ваш вибір: ");

            string choise = Console.ReadLine();
            Console.WriteLine();

            switch (choise)
            {
                case "1":
                    CoutWordFind();
                    break;
                case "2":
                    ReplaceSubstring();
                    break;
                case "3":
                    CoutVowes();
                    break;
                case "4":
                    CountWords();
                    break;
                case "5":
                    ReverseWord();
                    break;
                case "6":
                    AddLineIfNotExists();
                    break;
                case "7":
                    RemoveDigits();
                    break;
                case "8":
                    FindLinesByWord();
                    break;
                case "9":
                    return; // вихід
                default:
                    Console.WriteLine("Невірний вибір!");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CoutWordFind()
    {
        Console.Write("Слово для пошуку: ");
        string target = Console.ReadLine();
        int count = 0;

        foreach (var line in File.ReadLines(path))
        {
            var splitLine = line.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            count += splitLine.Count(w => w.Equals(target, StringComparison.OrdinalIgnoreCase));
        }

        Console.WriteLine($"Слово \"{target}\" зустрічається {count} раз(и).");
    }

    static void ReplaceSubstring()
    {
        Console.Write("Що замінити: ");
        string oldWord = Console.ReadLine();
        Console.Write("На що замінити: ");
        string newWord = Console.ReadLine();

        string text = File.ReadAllText(path);
        text = text.Replace(oldWord, newWord, StringComparison.OrdinalIgnoreCase);
        File.WriteAllText(path, text);

        Console.WriteLine("Заміна виконана.");
    }

    static void CoutVowes()
    {
        string vowels = "аеєиіїоуюяАЕЄИІЇОУЮЯ";
        int count = 0;

        foreach (var line in File.ReadLines(path))
        {
            count += line.Count(ch => vowels.Contains(ch));
        }

        Console.WriteLine($"Кількість голосних: {count}");
    }

    static void CountWords()
    {
        int totalWords = 0;

        foreach (var line in File.ReadLines(path))
        {
            totalWords += line.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        Console.WriteLine($"Загальна кількість слів: {totalWords}");
    }

    static void ReverseWord()
    {
        Console.Write("Введіть слово для перевороту: ");
        string word = Console.ReadLine();
        string reversed = new string(word.Reverse().ToArray());

        Console.WriteLine($"Результат: {reversed}");
    }

    static void AddLineIfNotExists()
    {
        Console.Write("Введіть рядок: ");
        string newLine = Console.ReadLine();

        var lines = File.ReadAllLines(path).ToList();
        if (!lines.Contains(newLine))
        {
            lines.Add(newLine);
            File.WriteAllLines(path, lines);
            Console.WriteLine("Рядок додано.");
        }
        else
        {
            Console.WriteLine("Такий рядок вже існує.");
        }
    }

    static void RemoveDigits()
    {
        string text = File.ReadAllText(path);
        text = new string(text.Where(ch => !char.IsDigit(ch)).ToArray());
        File.WriteAllText(path, text);

        Console.WriteLine("Цифри видалено.");
    }

    static void FindLinesByWord()
    {
        Console.Write("Введіть слово для пошуку у рядках: ");
        string target = Console.ReadLine();

        var lines = File.ReadAllLines(path);
        var found = lines.Where(line => line.Contains(target, StringComparison.OrdinalIgnoreCase)).ToList();

        if (found.Count > 0)
        {
            Console.WriteLine("Знайдені рядки:");
            foreach (var l in found)
                Console.WriteLine(l);
        }
        else
        {
            Console.WriteLine("Нічого не знайдено.");
        }
    }
}
