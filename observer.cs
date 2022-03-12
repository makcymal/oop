namespace Observer
{
    interface IManager
    {
        void RegisterDisplay(IDisplay display);
        void UnregisterDisplay(int index);
        void UpdateDisplays();
    }

    class WeatherData : IManager
    {
        IDisplay[] allDisplays = new IDisplay[10];
        int countDisplays = 0;

        public void RegisterDisplay(IDisplay display)
        {
            if (display != null)
                allDisplays[countDisplays++] = display;
        }

        public void UnregisterDisplay(int index)
        {
            for (int i = index; i < allDisplays.Length - 1; i++)
                allDisplays[i] = allDisplays[i + 1];
            countDisplays--;
        }

        public void UpdateDisplays()
        {
            foreach (IDisplay display in allDisplays)
                if (display != null)
                    display.Update(GetTemperature(), GetHumidity(), GetPressure());
        }

        readonly Random rnd = new();

        float GetTemperature() => rnd.Next(-10, 10);
        float GetHumidity() => rnd.Next(40, 80);
        float GetPressure() => rnd.Next(740, 760);

        public void MeasurementsChanged()
        {
            UpdateDisplays();
        }
    }

    interface IDisplay
    {
        void Update(float temperature, float humidity, float pressure);
        void Display();
    }

    class CurrentConditionsDisplay : IDisplay
    {
        float temperature, humidity, pressure;

        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Now: {temperature} degrees Celcius");
            Console.WriteLine($"     {humidity} percent humidity");
            Console.WriteLine($"     {pressure} millimeters of Mercury");
            Console.WriteLine();
        }
    }

    class StatisticsDisplay : IDisplay
    {
        float temperature, humidity, pressure;
        readonly Random rnd = new();

        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Temperature is {rnd.Next(5, 25)}% above average");
            Console.WriteLine($"Humidity is {rnd.Next(10, 30)}% below average");
            Console.WriteLine($"Pressure is {rnd.Next(1, 5)}% above average");
            Console.WriteLine();
        }
    }

    class ForecastDisplay : IDisplay
    {
        float temperature, humidity, pressure;
        readonly Random rnd = new();

        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Tomorrow: temperature is expected to be {temperature * rnd.Next(85, 100) / 100} degrees Celcius");
            Console.WriteLine($"          humidity is expected to be {humidity * rnd.Next(105, 110) / 100} percent humidity");
            Console.WriteLine($"          pressure is expected to be {pressure * rnd.Next(95, 105) / 100} millimeters of Mercury");
            Console.WriteLine();
        }
    }

    class Observer
    {
        public static void Main()
        {
            WeatherData weather = new();
            CurrentConditionsDisplay currDisplay = new();
            ForecastDisplay foreDisplay = new();

            weather.RegisterDisplay(currDisplay);
            weather.RegisterDisplay(foreDisplay);
            weather.MeasurementsChanged();

            StatisticsDisplay statDisplay = new();

            weather.RegisterDisplay(statDisplay);
            weather.UnregisterDisplay(1);
            weather.MeasurementsChanged();
        }
    }
}
