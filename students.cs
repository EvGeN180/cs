using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Ім'я: {Name}, Вік: {Age}";
    }
}

public class User
{
    public string Username { get; private set; }
    private string password;

    public User(string username, string password)
    {
        Username = username;
        password = password;
    }

    public bool Authenticate(string password)
    {
        return password == password;
    }

    public void ChangePassword(string newPassword)
    {
        password = newPassword;
        Console.WriteLine("Пароль успішно змінено.");
    }
}

public class Program
{
    private static List<Student> students = new List<Student>();
    private static User currentUser;

    static void Main(string[] args)
    {
        currentUser = new User("admin", "password123");

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Ласкаво просимо до системи управління студентами!");

        while (true)
        {
            Console.WriteLine("Будь ласка, авторизуйтесь.");
            Console.Write("Логін: ");
            string username = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();

            if (username == currentUser.Username && currentUser.Authenticate(password))
            {
                Console.WriteLine("\nАвторизація успішна!");
                break;
            }
            else
            {
                Console.WriteLine("Невірний логін або пароль. Спробуйте ще раз.");
            }
        }

        while (true)
        {
            ShowMenu();
            Console.Write("\nВведіть команду: ");
            string command = Console.ReadLine().ToLower();

            try
            {
                switch (command)
                {
                    case "1":
                    case "добавити":
                        AddStudent();
                        break;
                    case "2":
                    case "видалити":
                        RemoveStudent();
                        break;
                    case "3":
                    case "вивести":
                        ShowAllStudents();
                        break;
                    case "4":
                    case "очистити":
                        ClearStudentsList();
                        break;
                    case "5":
                    case "пароль":
                        ChangeUserPassword();
                        break;
                    case "6":
                    case "вийти":
                        Console.WriteLine("Дякуємо за використання програми!");
                        return;
                    case "help":
                        ShowHelp();
                        break;
                    default:
                        Console.WriteLine("Невідома команда. Спробуйте 'help'.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка: {ex.Message}");
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n----------------------------------");
        Console.WriteLine("Меню управління студентами:");
        Console.WriteLine("1. Добавити студента (або 'добавити')");
        Console.WriteLine("2. Видалити студента (або 'видалити')");
        Console.WriteLine("3. Вивести всіх студентів (або 'вивести')");
        Console.WriteLine("4. Очистити список (або 'очистити')");
        Console.WriteLine("5. Змінити пароль (або 'пароль')");
        Console.WriteLine("6. Вийти з програми (або 'вийти')");
        Console.WriteLine("----------------------------------");
    }

    static void ShowHelp()
    {
        Console.WriteLine("\n--- Довідка по командам ---");
        Console.WriteLine("Добавити: додає нового студента до списку.");
        Console.WriteLine("Видалити: видаляє студента за його ID.");
        Console.WriteLine("Вивести: показує всіх студентів у списку.");
        Console.WriteLine("Очистити: видаляє всіх студентів зі списку.");
        Console.WriteLine("Пароль: дозволяє змінити пароль поточного користувача.");
        Console.WriteLine("Вийти: закриває програму.");
        Console.WriteLine("help: показує цю довідку.");
        Console.WriteLine("-----------------------------");
    }

    static void AddStudent()
    {
        Console.WriteLine("\n--- Додати студента ---");
        Console.Write("Введіть ID: ");
        int id = int.Parse(Console.ReadLine());

        if (students.Any(s => s.Id == id))
        {
            Console.WriteLine("Студент з таким ID вже існує.");
            return;
        }

        Console.Write("Введіть ім'я: ");
        string name = Console.ReadLine();
        Console.Write("Введіть вік: ");
        int age = int.Parse(Console.ReadLine());

        students.Add(new Student(id, name, age));
        Console.WriteLine("Студента успішно додано.");
    }

    static void RemoveStudent()
    {
        Console.WriteLine("\n--- Видалити студента ---");
        Console.Write("Введіть ID студента для видалення: ");
        int id = int.Parse(Console.ReadLine());

        Student studentToRemove = students.FirstOrDefault(s => s.Id == id);
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            Console.WriteLine($"Студента з ID {id} успішно видалено.");
        }
        else
        {
            Console.WriteLine($"Студента з ID {id} не знайдено.");
        }
    }

    static void ShowAllStudents()
    {
        Console.WriteLine("\n--- Список всіх студентів ---");
        if (students.Count == 0)
        {
            Console.WriteLine("Список порожній.");
        }
        else
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

    static void ClearStudentsList()
    {
        students.Clear();
        Console.WriteLine("\nСписок студентів очищено.");
    }

    static void ChangeUserPassword()
    {
        Console.WriteLine("\n--- Зміна пароля ---");
        Console.Write("Введіть новий пароль: ");
        string newPassword = Console.ReadLine();
        currentUser.ChangePassword(newPassword);
    }
}
