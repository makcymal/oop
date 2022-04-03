namespace Factory
{
    interface IIngredientFactory
    {
        public string GetDough();
        public string GetSause();
        public string GetMeat();
        public string GetTomatoes();
        public string GetVegetable();
        public string GetOlives();
        public string GetMushrooms();
        public string GetSecretIngredient();
        public string GetCheese();
        public string GetSpices();
    }

    class NyIngredientFactory : IIngredientFactory
    {
        public string GetDough() => "Thin dough";
        public string GetSause() => ", pesto";
        public string GetMeat() => ", chicken pieces";
        public string GetTomatoes() => ", pink tomatoes";
        public string GetVegetable() => ", red onion";
        public string GetOlives() => ", green olives";
        public string GetMushrooms() => ", champignons";
        public string GetSecretIngredient() => ", jalapeno";
        public string GetCheese() => ", mozzarella";
        public string GetSpices() => ", Provencal herbs";
    }

    class LaIngredientFactory : IIngredientFactory
    {
        public string GetDough() => "Ordinary dough";
        public string GetSause() => ", alfredo";
        public string GetMeat() => ", bacon";
        public string GetTomatoes() => ", red tomatoes";
        public string GetVegetable() => ", sweet pepper";
        public string GetOlives() => ", black olives";
        public string GetMushrooms() => ", porcini";
        public string GetSecretIngredient() => ", pineapple";
        public string GetCheese() => ", parmesan";
        public string GetSpices() => ", garlic";
    }

    abstract class Pizza
    {
        public IIngredientFactory currFactory;
        public string name;
        public int nIngreds = 0;
        public string[] ingredients = new string[10];

        public abstract void Prepare();

        static public void Bake()
        {
            Console.WriteLine("Your pizza is baking!");
        }

        static public void Cut()
        {
            Console.WriteLine("Now we are going to cut your pizza");
        }

        static public void Box()
        {
            Console.WriteLine("Now pizza in the box");
        }
    }

    class Carbonara : Pizza
    {
        public Carbonara(IIngredientFactory factory)
        {
            currFactory = factory;
            name = "Carbonara";
        }

        public override void Prepare()
        {
            ingredients[nIngreds++] = currFactory.GetDough();
            ingredients[nIngreds++] = currFactory.GetSause();
            ingredients[nIngreds++] = currFactory.GetMeat();
            ingredients[nIngreds++] = currFactory.GetTomatoes();
            ingredients[nIngreds++] = currFactory.GetSpices();
        }
    }

    class VeggiePizza : Pizza
    {
        public VeggiePizza(IIngredientFactory factory)
        {
            currFactory = factory;
            name = "VeggiePizza";
        }

        public override void Prepare()
        {
            ingredients[nIngreds++] = currFactory.GetDough();
            ingredients[nIngreds++] = currFactory.GetSause();
            ingredients[nIngreds++] = currFactory.GetTomatoes();
            ingredients[nIngreds++] = currFactory.GetVegetable();
            ingredients[nIngreds++] = currFactory.GetMushrooms();
            ingredients[nIngreds++] = currFactory.GetSecretIngredient();
        }
    }

    class GreekPizza : Pizza
    {
        public GreekPizza(IIngredientFactory factory)
        {
            currFactory = factory;
            name = "GreekPizza";
        }

        public override void Prepare()
        {
            ingredients[nIngreds++] = currFactory.GetDough();
            ingredients[nIngreds++] = currFactory.GetSause();
            ingredients[nIngreds++] = currFactory.GetVegetable();
            ingredients[nIngreds++] = currFactory.GetOlives();
            ingredients[nIngreds++] = currFactory.GetSecretIngredient();
            ingredients[nIngreds++] = currFactory.GetSpices();
        }
    }


    abstract class PizzaStore
    {
        public abstract Pizza OrderPizza(string type);
    }

    class NyPizzaStore : PizzaStore
    {
        IIngredientFactory currFactory = new NyIngredientFactory();

        public override Pizza OrderPizza(string type)
        {
            Pizza pizza;
            if (type == "Carbonara")
                pizza = new Carbonara(currFactory);
            else if (type == "VeggiePizza")
                pizza = new VeggiePizza(currFactory);
            else
                pizza = new GreekPizza(currFactory);

            Console.WriteLine(pizza.name);
            pizza.Prepare();
            for (int i = 0; i < pizza.nIngreds; ++i)
                Console.Write(pizza.ingredients[i]);
            Console.WriteLine();

            Pizza.Bake();
            Pizza.Cut();
            Pizza.Box();
            Console.WriteLine();
            return pizza;
        }
    }

    class LaPizzaStore : PizzaStore
    {
        IIngredientFactory currFactory = new LaIngredientFactory();

        public override Pizza OrderPizza(string type)
        {
            Pizza pizza;
            if (type == "Carbonara")
                pizza = new Carbonara(currFactory);
            else if (type == "VeggiePizza")
                pizza = new VeggiePizza(currFactory);
            else
                pizza = new GreekPizza(currFactory);

            Console.WriteLine(pizza.name);
            pizza.Prepare();
            for (int i = 0; i < pizza.nIngreds; ++i)
                Console.Write(pizza.ingredients[i]);
            Console.WriteLine();

            Pizza.Bake();
            Pizza.Cut();
            Pizza.Box();
            Console.WriteLine();
            return pizza;
        }
    }

    class Factory
    {
        static void Main()
        {
            PizzaStore NY = new NyPizzaStore();
            PizzaStore LA = new LaPizzaStore();

            NY.OrderPizza("Carbonara");
            LA.OrderPizza("GreekPizza");
            NY.OrderPizza("VeggiePizza");
        }
    }
}
