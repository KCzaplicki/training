using System;

namespace TrainingXUnit
{
    public class Motor : IMotor
    {
        private bool _running;

        public void Start()
        {
            if (_running)
            {
                throw new InvalidOperationException($"{nameof(Start)} can't be performed");
            }

            _running = true;
        }

        public void Stop()
        {
            if (!_running)
            {
                throw new InvalidOperationException($"{nameof(Stop)} can't be performed");
            }

            _running = false;
        }
    }
}
