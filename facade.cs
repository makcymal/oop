namespace Facade
{
    public class Amplifier
    {
        int volume = 0;
        public void On() => Console.WriteLine("Amplifier turns on");
        public void Off() => Console.WriteLine("Amplifier turns off");
        public void SetVolume(int vol)
        {
            this.volume = vol;
        }
    }

    public class DvdPlayer
    {
        private Amplifier amplifier;
        public DvdPlayer(Amplifier amp)
        {
            this.amplifier = amp;
        }
        public void On() => Console.WriteLine("Dvd turns on");
        public void Off() => Console.WriteLine("Dvd turns off");
        public void Play(string name) => Console.WriteLine(name + " begins");
        public void Pause() => Console.WriteLine("Movie paused");
    }

    public class SaltedPopcornPopper
    {
        public void On() => Console.WriteLine("Let`s explode some salted corn seeds");
        public void Off() => Console.WriteLine("The salted popcorn era has come to an end(");
        public void Pop() => Console.WriteLine("Thermonuclear popcorn!");
    }

    public class SweetPopcornPopper
    {
        public void On() => Console.WriteLine("Let`s explode some sweet corn seeds");
        public void Off() => Console.WriteLine("The sweet popcorn era has come to an end(");
        public void Pop() => Console.WriteLine("Turbulent popcorn!");
    }

    public class CheesePopcornPopper
    {
        public void On() => Console.WriteLine("Let`s explode some cheese corn seeds");
        public void Off() => Console.WriteLine("The cheese popcorn era has come to an end(");
        public void Pop() => Console.WriteLine("Infernal popcorn!");
    }

    public class HomeCinemaFacade
    {
        Amplifier amplifier;
        DvdPlayer dvdPlayer;
        SaltedPopcornPopper saltedPopcorn;
        SweetPopcornPopper sweetPopcorn;
        CheesePopcornPopper cheesePopcorn;

        public HomeCinemaFacade(Amplifier amp, DvdPlayer dvd, SaltedPopcornPopper salt, SweetPopcornPopper sweet, CheesePopcornPopper cheese)
        {
            this.amplifier = amp;
            this.dvdPlayer = dvd;
            this.saltedPopcorn = salt;
            this.sweetPopcorn = sweet;
            this.cheesePopcorn = cheese;
        }
        public void WatchMovie(string name)
        {
            this.amplifier.On();
            this.dvdPlayer.On();

            this.saltedPopcorn.On();
            this.saltedPopcorn.Pop();

            this.sweetPopcorn.On();
            this.sweetPopcorn.Pop();

            this.cheesePopcorn.On();
            this.cheesePopcorn.Pop();

            this.amplifier.SetVolume(100);
            this.dvdPlayer.Play(name);
        }
    }

    class Facade
    {
        static void Main()
        {
            Amplifier amp = new Amplifier();
            DvdPlayer dvd = new DvdPlayer(amp);
            SaltedPopcornPopper salt = new SaltedPopcornPopper();
            SweetPopcornPopper sweet = new SweetPopcornPopper();
            CheesePopcornPopper cheese = new CheesePopcornPopper();

            HomeCinemaFacade theatre = new HomeCinemaFacade(amp, dvd, salt, sweet, cheese);
            theatre.WatchMovie("Titanic");
        }
    }
}
