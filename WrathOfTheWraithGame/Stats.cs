using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathOfTheWraithGame
{
    public class Stats
    {
        private string name;
        private float movementSpeedMultiplier;
        private float damageMultiplier;
        private int numOfItems;
        private int waveNumber;
        private int lives;
        private int health;


        public int NumOfItems { get; set; }
        public int WaveNumber { get; set; }
        public int Lives { get; set; }
        public int Health{ get; set; }

        public float SpeedMultiplier { get; set; }
        public float DamageMultiplier { get; set; }
        public string Name{ get; set; }


    }
}
