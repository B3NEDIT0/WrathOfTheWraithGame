using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Specialized;
using SharpDX.DirectWrite;
using System.Runtime.InteropServices;

namespace WrathOfTheWraithGame
{
    public class Sentry : Enemy
    {
        private float moveCount;
        private float randCount;
        private Random rand = new();
        private float dirCount;
        private Vector2 initPos;
        private readonly float DIR_SCALE_F = 300f;
        private readonly float AMP = 1.5f;
        
        public Sentry() {
            this.position = new Vector2(500, 500);
            this.Texture = Globals.Content.Load<Texture2D>("enemy2");
            this.isActive = false;
            this.randCount = rand.Next(2, 3);
        }

        public Vector2 GetRandDirection(Vector2 playerPos)
        {  
            Vector2 baseDir = playerPos - this.position;
            float baseAngle = MathF.Atan2(baseDir.Y, baseDir.X) + MathF.PI / 12; // generate angle 30 deg more than angle of baseDir
            float finalAngle = baseAngle - ((float)rand.NextDouble() * MathF.PI / 6); //generate direction with x-component 1 and y-coordinate of the angle that is within 60 deg
                                                                   // of the angle range
            this.randCount = rand.Next(2, 3);
            return Vector2.Normalize(new Vector2(1f, finalAngle));
        }

        public void Move(Vector2 playerPos)
        {
            this.dirCount += Globals.DeltaTime;
            this.position = this.initPos + (MathF.Max(MathF.Sin(dirCount * AMP) * DIR_SCALE_F, -0.01f) * this.dirVector);
        }
        
        public void Update(Vector2 playerPos)
        {
            if(isActive)
            {
                if (this.dirVector == Vector2.Zero && this.moveCount == 0 && Vector2.Distance(playerPos, this.Position) < 1000f) { this.dirVector = GetRandDirection(playerPos); }

                if (this.position != DIR_SCALE_F * this.dirVector)
                {
                    Move(playerPos);
                }
                else
                {
                    this.dirVector = Vector2.Zero;
                    this.moveCount = 0;
                    this.isActive = false;
                }
            }

            if(!isActive)
            {

                if (moveCount >= randCount)
                {
                    this.moveCount = 0;
                    this.dirVector = Vector2.Zero;
                    this.initPos = this.position;
                    this.isActive = true;
                }
                else
                {
                    this.moveCount += Globals.DeltaTime;
                    this.idleCount += Globals.DeltaTime;
                    this.position.Y += MathF.Sin(idleCount * 2f) * .5f;
                }
            }

        }

        
        public void FindPath()
        {

        }
    }
}
