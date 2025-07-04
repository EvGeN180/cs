using System;

class CoffeeMachine
{
    public void MakeCoffee()
    {
        Console.WriteLine("Наливання води");
        Console.WriteLine("Помел кавових зерен");
        Console.WriteLine("Приготування напою");
        Console.WriteLine("Смачного!");
    }
}

class Program
{
    static void Main()
    {
        CoffeeMachine machine = new CoffeeMachine();
        machine.MakeCoffee();
    }
}
