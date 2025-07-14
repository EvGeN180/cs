//виправте класи так щоб код працював
Bread bread = new Bread { Weight = 80 };
Butter butter = new Butter { Weight = 20 };
Sandwich sandwich = bread + butter;
Console.WriteLine(sandwich.Weight);
//2-5 рядки змінювати не можна
class Bread
{
    public int Weight { get; set; }
    //тут рішення

    public static Sandwich operator +(Bread b, Butter bt)
    {
        return new Sandwich { Weight = b.Weight + bt.Weight };
    }


    //написати код між цими коментарями
}

class Butter
{
    public int Weight { get; set; }
}

class Sandwich
{
    public int Weight { get; set; }
}
