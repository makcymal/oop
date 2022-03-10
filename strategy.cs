using System; 


namespace Strategy {

  interface iQuackStrategy {
    public void quack();
  }

  class NormalQuack : iQuackStrategy {
    public void quack() {
      Console.WriteLine("quack");
    }
  }

  class ScreamQuack : iQuackStrategy {
    public void quack() {
      Console.WriteLine("QUAOUAOUAO");
    }
  }

  class SilentQuack : iQuackStrategy {
    public void quack() {
      Console.WriteLine("");
    }
  }


  interface iSwimStrategy {
    public void swim();
  }

  class NormalSwimming : iSwimStrategy {
    public void swim() {
      Console.WriteLine("just give me some bread");
    }
  }

  class UnderwaterSwimming : iSwimStrategy {
    public void swim() {
      Console.WriteLine("I`m drowning!");
    }
  }


  interface iFlyingStrategy {
    public void fly();
  }

  class NormalFlying : iFlyingStrategy {
    public void fly() {
      Console.WriteLine("I`m flying to warmer climes");
    }
  }

  class FLyLikeWhale : iFlyingStrategy {
    public void fly() {
      Console.WriteLine("I`m tired(");
    }
  }


  interface iDisplayStrategy {
    public void display();
  }
  
  class NormalDisplay : iDisplayStrategy {
    public void display() {
      Console.WriteLine("this is duck");
    }
  }

  class ErrorDisplay : iDisplayStrategy {
    public void display() {
      Console.WriteLine("that duck is busy");
    }
  }
  

  class Duck {
    private iQuackStrategy quackStrategy;
    private iSwimStrategy swimStrategy;
    private iFlyingStrategy flyStrategy;
    private iDisplayStrategy displayStrategy;

    public Duck(iQuackStrategy quackStrategy, iSwimStrategy swimStrategy, iFlyingStrategy flyStrategy, iDisplayStrategy displayStrategy) {
      this.quackStrategy = quackStrategy;
      this.swimStrategy = swimStrategy;
      this.flyStrategy = flyStrategy;
      this.displayStrategy = displayStrategy;
    }

    public void Quack() {
      quackStrategy.quack();
    }

    public void Swim() {
      swimStrategy.swim();
    }

    public void Fly() {
      flyStrategy.fly();
    }

    public void Display() {
      displayStrategy.display();
    }
  }


  class Program {

    static void Test(Duck duck) {
      duck.Quack();
      duck.Swim();
      duck.Fly();
      duck.Display();
    }

    static void Main() {
      Duck MandarinDuck = new Duck (new ScreamQuack(), new NormalSwimming(), new NormalFlying(), new NormalDisplay());
      Duck PlushDuck  = new Duck (new SilentQuack(), new UnderwaterSwimming(), new FLyLikeWhale(), new ErrorDisplay());

      Program.Test(MandarinDuck);
      Program.Test(PlushDuck);
    }
  }
}

