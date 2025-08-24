using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> words = new List<string>();
        int choice;

        do
        {
            Console.WriteLine("\n--- Меню ---");
            Console.WriteLine("1. Ввести масив слів");
            Console.WriteLine("2. Вивести весь список");
            Console.WriteLine("3. Вивести список по довжині");
            Console.WriteLine("4. Видалити конкретний елемент");
            Console.WriteLine("5. Додати елемент");
            Console.WriteLine("6. Вихід");
            Console.Write("Виберіть пункт: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Невірний ввід, спробуйте ще раз.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    InputArray(words);
                    break;
                case 2:
                    PrintArray(words);
                    break;
                case 3:
                    PrintByLength(words);
                    break;
                case 4:
                    DeleteElement(words);
                    break;
                case 5:
                    AddElement(words);
                    break;
                case 6:
                    Console.WriteLine("Вихід");
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }

        } while (choice != 6);
    }

    static void InputArray(List<string> words)
    {
        words.Clear();
        Console.Write("Скільки слів ви хочете ввести? ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Невірне число.");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Слово {i + 1}: ");
            string word = Console.ReadLine();
            words.Add(word);
        }
    }

    static void PrintArray(List<string> words)
    {
        if (words.Count == 0)
        {
            Console.WriteLine("Список порожній.");
            return;
        }

        Console.WriteLine("\nСписок слів:");
        foreach (var w in words)
        {
            Console.WriteLine(w);
        }
    }

    static void PrintByLength(List<string> words)
    {
        Console.Write("Введіть довжину слова для фільтра: ");
        if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
        {
            Console.WriteLine("Невірна довжина.");
            return;
        }

        var filtered = words.Where(w => w.Length == length).ToList();
        if (filtered.Count == 0)
        {
            Console.WriteLine("Слів з такою довжиною не знайдено.");
            return;
        }

        Console.WriteLine($"Слова довжини {length}:");
        foreach (var w in filtered)
        {
            Console.WriteLine(w);
        }
    }

    static void DeleteElement(List<string> words)
    {
        Console.Write("Введіть слово для видалення: ");
        string toDelete = Console.ReadLine();
        if (words.Remove(toDelete))
        {
            Console.WriteLine("Слово видалено.");
        }
        else
        {
            Console.WriteLine("Слово не знайдено.");
        }
    }

    static void AddElement(List<string> words)
    {
        Console.Write("Введіть нове слово: ");
        string newWord = Console.ReadLine();
        words.Add(newWord);
        Console.WriteLine("Слово додано.");
    }
}
