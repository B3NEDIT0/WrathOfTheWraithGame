using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrathOfTheWraithGame
{
    public class ShipWrecker : Enemy
    {
        private float timer;
        private float waitTime;
        private Dictionary<Vector2, int> teleportGrid = new();
        private float angle;
        private Random rand;
        private readonly float ANGLESPIN = MathHelper.Tau / 5f; // 5 rotations 
        public ShipWrecker() {
            this.position = new Vector2(600, 600);
            this.Texture = Globals.Content.Load<Texture2D>("pinkenemy1");
            rand = new Random();    
            waitTime = rand.Next(5, 10);
            teleportGrid = Globals.CurrentObstacles;
           
        }

        public void Update(Player player)
        {
            if(isActive)
            {
                this.angle = MathHelper.Lerp(this.angle, ANGLESPIN, 0.01f);
                if(angle == ANGLESPIN)
                {

                }
            }

            if(!isActive)
            {
                this.idleCount += Globals.DeltaTime;
                this.timer += Globals.DeltaTime;
                this.position.Y += MathF.Sin(idleCount * 2f) * .5f;
                if(this.timer >= waitTime)
                {
                    this.isActive = true;
                    this.timer = 0;
                    this.waitTime = rand.Next(5, 10);   
                }

            }
        }

        
        public Vector2 GetTeleportPos(Player player)
        {
            float radius = 10f;
            float angle = 0.25f * MathF.Tau * (float)rand.NextDouble();
            Vector2 dir = Vector2.Normalize(new Vector2(1, angle));

            return dir; 
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(texture, this.position, this.boundBox, Color.White,angle, this.origin, 1f, SpriteEffects.None, 0f);
        }


    }
}
