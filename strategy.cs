namespace Strategy
{

    interface IQuackStrategy
    {
        public void Quack();
    }

    class NormalQuack : IQuackStrategy
    {
        public void Quack()
        {
            Console.WriteLine("quack");
        }
    }

    class ScreamQuack : IQuackStrategy
    {
        public void Quack()
        {
            Console.WriteLine("QUAOUAOUAO");
        }
    }

    class SilentQuack : IQuackStrategy
    {
        public void Quack()
        {
            Console.WriteLine("");
        }
    }


    interface ISwimStrategy
    {
        public void Swim();
    }

    class NormalSwimming : ISwimStrategy
    {
        public void Swim()
        {
            Console.WriteLine("just give me some bread");
        }
    }

    class UnderwaterSwimming : ISwimStrategy
    {
        public void Swim()
        {
            Console.WriteLine("I`m drowning!");
        }
    }


    interface IFlyingStrategy
    {
        public void Fly();
    }

    class NormalFlying : IFlyingStrategy
    {
        public void Fly()
        {
            Console.WriteLine("I`m flying to warmer climes");
        }
    }

    class FLyLikeWhale : IFlyingStrategy
    {
        public void Fly()
        {
            Console.WriteLine("I`m tired(");
        }
    }


    interface IDisplayStrategy
    {
        public void Display();
    }

    class NormalDisplay : IDisplayStrategy
    {
        public void Display()
        {
            Console.WriteLine("this is duck");
        }
    }

    class ErrorDisplay : IDisplayStrategy
    {
        public void Display()
        {
            Console.WriteLine("that duck is busy");
        }
    }


    class Duck
    {
        private IQuackStrategy quackStrategy;
        private ISwimStrategy swimStrategy;
        private IFlyingStrategy flyStrategy;
        private IDisplayStrategy displayStrategy;

        public Duck(IQuackStrategy quackStrategy, ISwimStrategy swimStrategy, IFlyingStrategy flyStrategy, IDisplayStrategy displayStrategy)
        {
            this.quackStrategy = quackStrategy;
            this.swimStrategy = swimStrategy;
            this.flyStrategy = flyStrategy;
            this.displayStrategy = displayStrategy;
        }

        public void Quack()
        {
            quackStrategy.Quack();
        }

        public void Swim()
        {
            swimStrategy.Swim();
        }

        public void Fly()
        {
            flyStrategy.Fly();
        }

        public void Display()
        {
            displayStrategy.Display();
        }
    }


    public class Strategy
    {
        static void Test(Duck duck)
        {
            duck.Quack();
            duck.Swim();
            duck.Fly();
            duck.Display();
        }

        public static void Main()
        {
            Duck MandarinDuck = new(new ScreamQuack(), new NormalSwimming(), new NormalFlying(), new NormalDisplay());
            Duck PlushDuck = new(new SilentQuack(), new UnderwaterSwimming(), new FLyLikeWhale(), new ErrorDisplay());

            Test(MandarinDuck);
            Test(PlushDuck);
        }
    }
}
