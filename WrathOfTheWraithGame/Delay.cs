using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathOfTheWraithGame
{
    public class Delay
    {
        public float Timer = 0f;
        public float sleepTime = 0f;

        public Delay(float _sleepTime)
        {
            this.sleepTime = _sleepTime;
        }

        public delegate void TimedMethod();

        public void Wait(Delay.TimedMethod func)
        {
            
            if (this.Timer <= this.sleepTime)
            {
                this.Timer += Globals.DeltaTime;
                func();
            }
            
        }
    }
}
