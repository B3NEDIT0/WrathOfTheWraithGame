using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrathOfTheWraithGame
{
    public class Enemy : Sprite
    {
        protected float health;
        protected string enemy_type;
        protected Vector2 dirVector;
        protected bool isActive = false;
        protected float idleCount;
        protected Vector2 gridCell;

        public enum ENEMY_MOVEMENT_TYPE
        { Teleport,Navigate,Bulldoze }

        
        public Enemy() { }
        
        public Enemy(Texture2D spriteTexture, Vector2 position) { 
            boundBox = new Rectangle((int)position.X, (int)position.Y, spriteTexture.Width, spriteTexture.Height);
        }
        public virtual void Initialise() { }

        public float Health { get { return health; } set {  health = value; } }

        public Rectangle BoundBox { get { return boundBox; } set { boundBox = value; } }

    }
}

