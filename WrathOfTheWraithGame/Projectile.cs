using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WrathOfTheWraithGame
{
    public class Projectile : Sprite
    {
        protected float VELOCITY;
        protected Globals.ProjectileType projectileType;
        protected Vector2 dir; //normalised direction of projectle (a general direction vector)
        

        public Projectile() {
            this.Texture = Globals.Content.Load<Texture2D>("bullet");
        }

        public override void Update()
        {
            
        }

        public Vector2 Dir{ get { return dir; } set { dir = value; } }

    }
}
