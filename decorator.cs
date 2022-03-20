namespace Decorator
{
    public interface IBeverage
    {
        public string GetDescription();
        public int GetCost();
    }

    public class HouseBlend : IBeverage
    {
        public string GetDescription() => "It`s House Blend";
        public int GetCost() => 280;
    }

    public class DarkRoast : IBeverage
    {
        public string GetDescription() => "It`s Dark Roast";
        public int GetCost() => 250;
    }

    public class Decaf : IBeverage
    {
        public string GetDescription() => "It`s Decaf";
        public int GetCost() => 300;
    }

    public class Espresso : IBeverage
    {
        public string GetDescription() => " It`s Espresso";
        public int GetCost() => 200;
    }

    public interface ICondiment : IBeverage {}

    public class Milk : ICondiment
    {
        IBeverage beverage;
        public Milk(IBeverage beverage)
        {
            this.beverage = beverage;
        }
        public string GetDescription() => beverage.GetDescription() + " with milk";
        public int GetCost() => beverage.GetCost() + 20;
    }

    public class Mocha : ICondiment
    {
        IBeverage beverage;
        public Mocha(IBeverage beverage)
        {
            this.beverage = beverage;
        }
        public string GetDescription() => beverage.GetDescription() + " with mocha";
        public int GetCost() => beverage.GetCost() + 30;
    }

    public class Soy : ICondiment
    {
        IBeverage beverage;
        public Soy(IBeverage beverage)
        {
            this.beverage = beverage;
        }
        public string GetDescription() => beverage.GetDescription() + " with soy";
        public int GetCost() => beverage.GetCost() + 10;
    }

    public class Whip: ICondiment
    {
        IBeverage beverage;
        public Whip(IBeverage beverage)
        {
            this.beverage = beverage;
        }
        public string GetDescription() => beverage.GetDescription() + " with whip";
        public int GetCost() => beverage.GetCost() + 40;
    }

    class Decorator
    {
        public static void Main()
        {
            IBeverage beverage = new Whip(new Mocha(new Decaf()));
            Console.WriteLine(beverage.GetDescription());
            Console.WriteLine(beverage.GetCost());
        }
    }
}