using System;
using System.Collections.Generic;
using System.Text;

namespace BombBros
{
    public class GameTime
    {
        private float _deltaTime = 0;
        private float _timeScale = 1;
        public float TimeScale { get { return _timeScale; } set { _timeScale = value; } }
        public float DeltaTime { get { return _deltaTime * _timeScale; } set { _deltaTime = value; } }
        public float DeltaTimeUnscaled { get { return _deltaTime; } }
        public float TotalTimeElapsed { get; private set; }
        public GameTime()
        {

        }
        public void Update(float deltaTime, float totalTimeElapsed)
        {
            DeltaTime = deltaTime;
            TotalTimeElapsed = totalTimeElapsed;

        }

      


    }
}
