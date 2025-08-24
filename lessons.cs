using System;
using System.Collections.Generic;
using System.Linq;

class Lesson
{
    public string Subject { get; set; }
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }

    public Lesson(string subject, TimeSpan start, TimeSpan end)
    {
        Subject = subject;
        Start = start;
        End = end;
    }

    public bool IsNow(DateTime currentTime)
    {
        return currentTime.TimeOfDay >= Start && currentTime.TimeOfDay <= End;
    }

    public override string ToString()
    {
        return $"{Subject} ({Start:hh\\:mm} - {End:hh\\:mm})";
    }
}

class DaySchedule
{
    public DayOfWeek Day { get; set; }
    public List<Lesson> Lessons { get; set; }

    public DaySchedule(DayOfWeek day)
    {
        Day = day;
        Lessons = new List<Lesson>();
    }
}

class Program
{
    static List<DaySchedule> weekSchedule = new List<DaySchedule>();

    static void Main()
    {
        InitializeSchedule();
        Console.WriteLine("Ласкаво просимо в систему розкладу студента!");

        while (true)
        {
            Console.WriteLine("\n--- Меню ---");
            Console.WriteLine("1. Поточна пара");
            Console.WriteLine("2. Наступна пара");
            Console.WriteLine("3. Пари сьогодні");
            Console.WriteLine("4. Пари завтра");
            Console.WriteLine("5. Пари до кінця тижня");
            Console.WriteLine("6. Вихід");
            Console.Write("Виберіть пункт: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowCurrentLesson();
                    break;
                case "2":
                    ShowNextLesson();
                    break;
                case "3":
                    ShowLessonsToday();
                    break;
                case "4":
                    ShowLessonsTomorrow();
                    break;
                case "5":
                    ShowLessonsTillEndOfWeek();
                    break;
                case "6":
                    Console.WriteLine("Вихід з програми...");
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }

    static void InitializeSchedule()
    {
        var monday = new DaySchedule(DayOfWeek.Monday);
        monday.Lessons.Add(new Lesson("Математика", new TimeSpan(9, 0, 0), new TimeSpan(10, 30, 0)));
        monday.Lessons.Add(new Lesson("Фізика", new TimeSpan(10, 45, 0), new TimeSpan(12, 15, 0)));
        monday.Lessons.Add(new Lesson("Інформатика", new TimeSpan(13, 0, 0), new TimeSpan(14, 30, 0)));

        var tuesday = new DaySchedule(DayOfWeek.Tuesday);
        tuesday.Lessons.Add(new Lesson("Хімія", new TimeSpan(9, 0, 0), new TimeSpan(10, 30, 0)));
        tuesday.Lessons.Add(new Lesson("Література", new TimeSpan(10, 45, 0), new TimeSpan(12, 15, 0)));
        tuesday.Lessons.Add(new Lesson("Історія", new TimeSpan(13, 0, 0), new TimeSpan(14, 30, 0)));

        weekSchedule.Add(monday);
        weekSchedule.Add(tuesday);
    }

    static DaySchedule GetScheduleForDay(DateTime date)
    {
        return weekSchedule.FirstOrDefault(d => d.Day == date.DayOfWeek);
    }

    static void ShowCurrentLesson()
    {
        DateTime now = DateTime.Now;
        var today = GetScheduleForDay(now);
        if (today == null)
        {
            Console.WriteLine("Сьогодні пар немає.");
            return;
        }

        var current = today.Lessons.FirstOrDefault(l => l.IsNow(now));
        if (current != null)
            Console.WriteLine($"Зараз йде пара: {current}");
        else
            Console.WriteLine("Зараз пар немає.");
    }

    static void ShowNextLesson()
    {
        DateTime now = DateTime.Now;
        var today = GetScheduleForDay(now);
        if (today == null)
        {
            Console.WriteLine("Сьогодні пар немає.");
            return;
        }

        var next = today.Lessons.FirstOrDefault(l => l.Start > now.TimeOfDay);
        if (next != null)
            Console.WriteLine($"Наступна пара: {next}");
        else
            Console.WriteLine("Наступних пар сьогодні немає.");
    }

    static void ShowLessonsToday()
    {
        DateTime todayDate = DateTime.Now;
        var today = GetScheduleForDay(todayDate);
        if (today == null || today.Lessons.Count == 0)
        {
            Console.WriteLine("Сьогодні пар немає.");
            return;
        }

        Console.WriteLine("--- Пари сьогодні ---");
        foreach (var lesson in today.Lessons)
            Console.WriteLine(lesson);
    }

    static void ShowLessonsTomorrow()
    {
        DateTime tomorrowDate = DateTime.Now.AddDays(1);
        var tomorrow = GetScheduleForDay(tomorrowDate);
        if (tomorrow == null || tomorrow.Lessons.Count == 0)
        {
            Console.WriteLine("Завтра пар немає.");
            return;
        }

        Console.WriteLine("--- Пари завтра ---");
        foreach (var lesson in tomorrow.Lessons)
            Console.WriteLine(lesson);
    }

    static void ShowLessonsTillEndOfWeek()
    {
        DateTime now = DateTime.Now;
        DayOfWeek today = now.DayOfWeek;
        Console.WriteLine("--- Пари до кінця тижня ---");
        foreach (var day in weekSchedule)
        {
            if (day.Day >= today)
            {
                Console.WriteLine($"\n{day.Day}:");
                foreach (var lesson in day.Lessons)
                    Console.WriteLine(lesson);
            }
        }
    }
}
