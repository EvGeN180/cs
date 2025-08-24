using System;
using System.Collections.Generic;
class Owner
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public Owner(string name, string phone, string address)
    {
        Name = name;
        Phone = phone;
        Address = address;
    }

    public override string ToString()
    {
        return $"{Name}, {Phone}, {Address}";
    }
}

class Animal
{
    public string Name { get; set; }
    public string Species { get; set; } 
    public int Age { get; set; }
    public Owner Owner { get; set; }

    public Animal(string name, string species, int age, Owner owner)
    {
        Name = name;
        Species = species;
        Age = age;
        Owner = owner;
    }

    public override string ToString()
    {
        return $"{Name}, {Species}, {Age}, {Owner.Name}";
    }
}

class Vet
{
    public string Name { get; set; }
    public string Specialization { get; set; }

    public Vet(string name, string specialization)
    {
        Name = name;
        Specialization = specialization;
    }

    public override string ToString()
    {
        return $" {Name}, {Specialization}";
    }
}

class Appointment
{
    public Animal Animal { get; set; }
    public Vet Vet { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }

    public Appointment(Animal animal, Vet vet, DateTime date, string notes)
    {
        Animal = animal;
        Vet = vet;
        Date = date;
        Notes = notes;
    }

    public override string ToString()
    {
        return $" {Date},  {Animal.Name}, {Vet.Name},{Notes}";
    }
}

class Treatment
{
    public string Description { get; set; }
    public decimal Cost { get; set; }

    public Treatment(string description, decimal cost)
    {
        Description = description;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"{Description}, {Cost} грн";
    }
}

class Program
{
    static void Main()
    {
       Owner owner1 = new Owner("Денчік", "+380999999", "Kyiv, Ukraine");
        Animal animal1 = new Animal("Стьопка", "Кіт", 3, owner1);
        Vet vet1 = new Vet("Тетяна Олександрівно", "Хірург");

        Appointment appointment1 = new Appointment(animal1, vet1, DateTime.Now, "Огляд перед вакцинацією");
        Treatment treatment1 = new Treatment("Вакцинація від сказу",1000);

        Console.WriteLine(owner1);
        Console.WriteLine(animal1);
        Console.WriteLine(vet1);
        Console.WriteLine(appointment1);
        Console.WriteLine(treatment1);
    }
}
