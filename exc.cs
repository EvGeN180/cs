try
{
    Console.Write("Enter your age: ");
    int age = int.Parse(Console.ReadLine());

    if (age < 0 || age > 120)
        throw new Exception("Age must be from 1 to 120!");

    Console.WriteLine("Your age: " + age);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
