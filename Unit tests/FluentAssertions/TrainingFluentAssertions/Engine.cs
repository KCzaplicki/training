using System;
using System.Threading.Tasks;

namespace TrainingFluentAssertions
{
    public class Engine
    {
        private readonly IMotor _motor;
        private readonly ISensor _sensor;

        public Engine(IMotor motor, ISensor sensor)
        {
            _motor = motor;
            _sensor = sensor;
        }

        public async Task<(bool success, double result)> Run()
        {
            _motor.Start();
            await Task.Delay(TimeSpan.FromSeconds(1));
            var result = _sensor.GetValue();
            _motor.Stop();

            return (true, result);
        }

        public void SetSensorMinValue(double value)
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} out of range 0-1.");
            }

            _sensor.MinValue = value;
        }
    }
}
