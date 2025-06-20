using System;

class Program
{
    //1
    static long GetProductInRange(int start, int end)
    {
        long product = 1;
        for (int i = start; i <= end; i++)
            product *= i;
        return product;
    }

    //2
    static bool IsFibonacci(int n)
    {
        bool IsPerfectSquare(int x)
        {
            int s = (int)Math.Sqrt(x);
            return s * s == x;
        }

        return IsPerfectSquare(5 * n * n + 4) || IsPerfectSquare(5 * n * n - 4);
    }

    // 3
    static void SortArray(int[] arr, bool ascending = true)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if ((ascending && arr[i] > arr[j]) || (!ascending && arr[i] < arr[j]))
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }

    static void Main()
    {
        // 1
        Console.WriteLine("Task 1: Product in range 2 to 5 = " + GetProductInRange(2, 5));

        // 2
        Console.WriteLine("Task 2: Is 21 a Fibonacci number? " + IsFibonacci(21));

        // 3
        int[] arr = { 5, 2, 9, 1, 7 };
        SortArray(arr, ascending: false);
        Console.WriteLine("Task 3: Sorted array (descending): " + string.Join(", ", arr));

        // 4
        City city = new City();
        city.InputData();
        city.PrintData();

        // 5
        Employee emp = new Employee();
        emp.InputData();
        emp.PrintData();

        // 6
        Airplane airplane = new Airplane();
        airplane.InputData();
        airplane.PrintData();
        airplane.PrintData("Details");

        // 7
        Matrix matrix = new Matrix(2, 2);
        matrix.InputData();
        matrix.PrintData();
        Console.WriteLine("Matrix Max: " + matrix.GetMax());
        Console.WriteLine("Matrix Min: " + matrix.GetMin());
    }
}

//4
class City
{
    private string cityName;
    private string countryName;
    private int population;
    private string phoneCode;
    private string[] districts;

    public void InputData()
    {
        Console.Write("Enter city name: ");
        cityName = Console.ReadLine();
        Console.Write("Enter country name: ");
        countryName = Console.ReadLine();
        Console.Write("Enter population: ");
        population = int.Parse(Console.ReadLine());
        Console.Write("Enter phone code: ");
        phoneCode = Console.ReadLine();
        Console.Write("Enter districts (comma separated): ");
        districts = Console.ReadLine().Split(',');
    }

    public void PrintData()
    {
        Console.WriteLine($"City: {cityName}, Country: {countryName}, Population: {population}, Phone code: {phoneCode}");
        Console.WriteLine("Districts: " + string.Join(", ", districts));
    }

    public string GetCityName() => cityName;
    public int GetPopulation() => population;
}

//5
class Employee
{
    private string fullName;
    private string birthDate;
    private string phone;
    private string email;
    private string position;
    private string duties;

    public void InputData()
    {
        Console.Write("Enter full name: ");
        fullName = Console.ReadLine();
        Console.Write("Enter birth date: ");
        birthDate = Console.ReadLine();
        Console.Write("Enter phone: ");
        phone = Console.ReadLine();
        Console.Write("Enter email: ");
        email = Console.ReadLine();
        Console.Write("Enter position: ");
        position = Console.ReadLine();
        Console.Write("Enter duties: ");
        duties = Console.ReadLine();
    }

    public void PrintData()
    {
        Console.WriteLine($"Name: {fullName}, Birth Date: {birthDate}, Phone: {phone}, Email: {email}, Position: {position}");
        Console.WriteLine($"Duties: {duties}");
    }

    public string GetPhone() => phone;
    public string GetPosition() => position;
}

//6
class Airplane
{
    private string name;
    private string manufacturer;
    private int year;
    private string type;

    public Airplane() { }

    public Airplane(string name, string manufacturer, int year, string type)
    {
        this.name = name;
        this.manufacturer = manufacturer;
        this.year = year;
        this.type = type;
    }

    public void InputData()
    {
        Console.Write("Enter airplane name: ");
        name = Console.ReadLine();
        Console.Write("Enter manufacturer: ");
        manufacturer = Console.ReadLine();
        Console.Write("Enter year: ");
        year = int.Parse(Console.ReadLine());
        Console.Write("Enter type: ");
        type = Console.ReadLine();
    }

    public void PrintData()
    {
        Console.WriteLine($"Airplane: {name}, Manufacturer: {manufacturer}, Year: {year}, Type: {type}");
    }

    public void PrintData(string prefix)
    {
        Console.WriteLine($"{prefix} - Airplane: {name}, Manufacturer: {manufacturer}, Year: {year}, Type: {type}");
    }

    public string GetTypeName() => type;
}

//7
class Matrix
{
    private int[,] data;
    private int rows, cols;

    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        data = new int[rows, cols];
    }

    public void InputData()
    {
        Console.WriteLine("Enter matrix elements:");
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Element [{i}][{j}]: ");
                data[i, j] = int.Parse(Console.ReadLine());
            }
    }

    public void PrintData()
    {
        Console.WriteLine("Matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(data[i, j] + " ");
            Console.WriteLine();
        }
    }

    public int GetMax()
    {
        int max = data[0, 0];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if (data[i, j] > max)
                    max = data[i, j];
        return max;
    }

    public int GetMin()
    {
        int min = data[0, 0];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if (data[i, j] < min)
                    min = data[i, j];
        return min;
    }
}

