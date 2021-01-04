using System;

namespace TrainingFluentAssertions
{
    public class Sensor : ISensor
    {
        private readonly Random _rand;

        public double MinValue { get; set; }

        public Sensor()
        {
            _rand = new Random();
        }

        public double GetValue() 
        {
            var value = _rand.NextDouble();

            return MinValue < value ? value : MinValue + value;
        }
    }
}
