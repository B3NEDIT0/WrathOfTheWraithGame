using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework;

//sprite class that will be used for general textures and sprites to be loaded in.

namespace WrathOfTheWraithGame
{
    public class Sprite
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected float scale;

        public Sprite() { }
        public Sprite(Texture2D _texture) {
            this.texture = _texture;
        } 

        public virtual void Update()
        {

        }

        public virtual void Draw(Vector2 pos) {
            Globals.SpriteBatch.Draw(texture, pos, Color.White);
        }

        public virtual void Draw(Vector2 pos, float scale)
        {
            Globals.SpriteBatch.Draw(this.texture, pos, null,
            Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public float Scale {  get { return scale; } set {  scale = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }


    }
}
