using System;
using System.Collections.Generic;
using System.Linq;

class Pizza
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }

    public Pizza(string name, List<string> ingredients)
    {
        Name = name;
        Ingredients = ingredients;
    }

    public void Print()
    {
        Console.WriteLine($"{Name} ({string.Join(", ", Ingredients)})");
    }
}

class Order
{
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public void AddPizza(Pizza pizza)
    {
        Pizzas.Add(pizza);
        Console.WriteLine($"Додано {pizza.Name} до замовлення.");
    }

    public void PrintBasket()
    {
        if (Pizzas.Count == 0)
        {
            Console.WriteLine("Ваша корзинка порожня.");
            return;
        }

        Console.WriteLine("\n--- Ваша корзинка ---");
        int i = 1;
        foreach (var pizza in Pizzas)
        {
            Console.Write($"{i}. ");
            pizza.Print();
            i++;
        }
    }

    public void Checkout()
    {
        Console.WriteLine("\n--- Чек ---");
        int total = 0;
        foreach (var pizza in Pizzas)
        {
            int price = 100 + pizza.Ingredients.Count * 20;
            Console.Write($"{pizza.Name}: {price} грн (інгредієнти: {string.Join(", ", pizza.Ingredients)})\n");
            total += price;
        }
        Console.WriteLine($"Загальна сума: {total} грн");
        Console.WriteLine("Дякуємо за покупку!");
    }
}

class Program
{
    static List<Pizza> predefinedPizzas = new List<Pizza>
    {
        new Pizza("Маргарита", new List<string>{"Помідори", "Сир", "Базилік"}),
        new Pizza("Пепероні", new List<string>{"Пепероні", "Сир", "Помідори"}),
        new Pizza("Гавайська", new List<string>{"Шинка", "Ананас", "Сир", "Помідори"})
    };

    static List<string> allIngredients = new List<string>
    {
        "Помідори", "Сир", "Базилік", "Пепероні", "Шинка", "Ананас", "Гриби", "Перець", "Оливки", "Цибуля"
    };

    static void Main()
    {
        Console.WriteLine("Вітаємо у Генераторі піци!");
        Order order = new Order();

        while (true)
        {
            Console.WriteLine("\nЩо бажаєте зробити?");
            Console.WriteLine("1. Вибрати готову піцу");
            Console.WriteLine("2. Зібрати піцу вручну");
            Console.WriteLine("3. Вибрати готову піцу та додати інгредієнти");
            Console.WriteLine("4. Переглянути корзинку");
            Console.WriteLine("5. Підтвердити замовлення та вийти");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ChoosePredefinedPizza(order);
                    break;
                case "2":
                    BuildPizzaManually(order);
                    break;
                case "3":
                    CustomizePredefinedPizza(order);
                    break;
                case "4":
                    order.PrintBasket();
                    break;
                case "5":
                    order.PrintBasket();
                    order.Checkout();
                    return;
                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    break;
            }
        }
    }

    static void ChoosePredefinedPizza(Order order)
    {
        Console.WriteLine("\nДоступні піци:");
        for (int i = 0; i < predefinedPizzas.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            predefinedPizzas[i].Print();
        }
        Console.Write("Введіть номер піци: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= predefinedPizzas.Count)
        {
            Pizza selected = predefinedPizzas[num - 1];
            order.AddPizza(new Pizza(selected.Name, new List<string>(selected.Ingredients)));
        }
        else
        {
            Console.WriteLine("Невірний номер.");
        }
    }

    static void BuildPizzaManually(Order order)
    {
        Console.Write("Введіть назву вашої піци: ");
        string name = Console.ReadLine();
        List<string> ingredients = new List<string>();

        Console.WriteLine("Виберіть інгредієнти (введіть пустий рядок щоб завершити):");
        foreach (var ing in allIngredients)
        {
            Console.WriteLine("- " + ing);
        }

        while (true)
        {
            Console.Write("Інгредієнт: ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (allIngredients.Contains(input))
                ingredients.Add(input);
            else
                Console.WriteLine("Невідомий інгредієнт, спробуйте ще раз.");
        }

        order.AddPizza(new Pizza(name, ingredients));
    }

    static void CustomizePredefinedPizza(Order order)
    {
        Console.WriteLine("\nДоступні піци:");
        for (int i = 0; i < predefinedPizzas.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            predefinedPizzas[i].Print();
        }
        Console.Write("Введіть номер піци: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= predefinedPizzas.Count)
        {
            Pizza selected = predefinedPizzas[num - 1];
            List<string> newIngredients = new List<string>(selected.Ingredients);

            Console.WriteLine("Додайте інгредієнти (введіть пустий рядок щоб завершити):");
            foreach (var ing in allIngredients)
            {
                Console.WriteLine("- " + ing);
            }

            while (true)
            {
                Console.Write("Інгредієнт: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                if (allIngredients.Contains(input) && !newIngredients.Contains(input))
                    newIngredients.Add(input);
                else
                    Console.WriteLine("Невідомий або вже доданий інгредієнт.");
            }

            order.AddPizza(new Pizza(selected.Name + " (з додатками)", newIngredients));
        }
        else
        {
            Console.WriteLine("Невірний номер.");
        }
    }
}
