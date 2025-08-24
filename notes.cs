using System;
using System.IO;

class NoteManager
{
    private string folderPath;

    public NoteManager(string path)
    {
        folderPath = path;

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    public void CreateNote()
    {
        Console.Write("Введіть назву нотатки (без розширення): ");
        string name = Console.ReadLine();
        string filePath = Path.Combine(folderPath, name + ".txt");

        if (File.Exists(filePath))
        {
            Console.WriteLine("Нотатка з такою назвою вже існує.");
            return;
        }

        Console.WriteLine("Введіть текст нотатки (пустий рядок для завершення):");
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                writer.WriteLine(line);
            }
        }

        Console.WriteLine("Нотатку створено.");
    }

    public void ViewAllNotes()
    {
        string[] files = Directory.GetFiles(folderPath, "*.txt");
        if (files.Length == 0)
        {
            Console.WriteLine("Нотаток немає.");
            return;
        }

        Console.WriteLine("\nСписок нотаток:");
        foreach (var file in files)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
    }

    public void ViewNote(string name)
    {
        string filePath = Path.Combine(folderPath, name + ".txt");
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Нотатку не знайдено.");
            return;
        }

        Console.WriteLine($"\n--- {name} ---");
        string content = File.ReadAllText(filePath);
        Console.WriteLine(content);
    }

    public void EditNote(string name)
    {
        string filePath = Path.Combine(folderPath, name + ".txt");
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Нотатку не знайдено.");
            return;
        }

        Console.WriteLine("Введіть новий текст нотатки (пустий рядок для завершення):");
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                writer.WriteLine(line);
            }
        }

        Console.WriteLine("Нотатку оновлено.");
    }

    public void DeleteNote(string name)
    {
        string filePath = Path.Combine(folderPath, name + ".txt");
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Нотатку не знайдено.");
            return;
        }

        File.Delete(filePath);
        Console.WriteLine("Нотатку видалено.");
    }

    public void ShowFileInfo(string name)
    {
        string filePath = Path.Combine(folderPath, name + ".txt");
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Нотатку не знайдено.");
            return;
        }

        FileInfo fi = new FileInfo(filePath);
        Console.WriteLine($"\nІнформація про файл '{name}':");
        Console.WriteLine($"Розмір: {fi.Length} байт");
        Console.WriteLine($"Дата створення: {fi.CreationTime}");
        Console.WriteLine($"Останній доступ: {fi.LastAccessTime}");
        Console.WriteLine($"Остання зміна: {fi.LastWriteTime}");
    }
}

class Program{
    static void Main()
    {
        string folder = "C:\\Users\\Admin\\Desktop\\IT STEP\\C#\\ConsoleApp2\\ConsoleApp2"; 
        NoteManager manager = new NoteManager(folder);

        while (true)
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1. Створити нову нотатку");
            Console.WriteLine("2. Переглянути всі нотатки");
            Console.WriteLine("3. Відкрити нотатку");
            Console.WriteLine("4. Редагувати нотатку");
            Console.WriteLine("5. Видалити нотатку");
            Console.WriteLine("6. Інформація про файл (розмір, дата створення, останній доступ)");
            Console.WriteLine("7. Вийти");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateNote();
                    break;
                case "2":
                    manager.ViewAllNotes();
                    break;
                case "3":
                    Console.Write("Введіть назву нотатки: ");
                    string viewName = Console.ReadLine();
                    manager.ViewNote(viewName);
                    break;
                case "4":
                    Console.Write("Введіть назву нотатки для редагування: ");
                    string editName = Console.ReadLine();
                    manager.EditNote(editName);
                    break;
                case "5":
                    Console.Write("Введіть назву нотатки для видалення: ");
                    string delName = Console.ReadLine();
                    manager.DeleteNote(delName);
                    break;
                case "6":
                    Console.Write("Введіть назву нотатки для інформації: ");
                    string infoName = Console.ReadLine();
                    manager.ShowFileInfo(infoName);
                    break;
                case "7":
                    Console.WriteLine("Вихід з програми...");
                    return;
                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    break;
            }
        }
    }
}
