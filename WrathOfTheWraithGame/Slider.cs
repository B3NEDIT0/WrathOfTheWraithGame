using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics.Eventing.Reader;

namespace WrathOfTheWraithGame
{
    public class Slider : Sprite
    {
        public Effect shd;
        public float activated;
        public float amount;
        public Slider(Vector2 _pos) {
            this.texture = Globals.Content.Load<Texture2D>("FullVolumeBar");
            this.shd = Globals.Content.Load<Effect>("SliderShader");
            this.amount = 1;
            this.boundBox = new Rectangle((int)this.position.X, (int)this.position.Y, (int)this.texture.Width, (int)this.texture.Height);
            this.position = _pos;
        }

        public override void Update()
        {
            MouseState mouse = Mouse.GetState();

            Rectangle mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);
            if (mouse.X > this.position.X && mouse.X < this.position.X + this.texture.Width )
            {
                this.amount = (mouse.X - this.position.X ) / this.Texture.Width;
                shd.Parameters["amount"].SetValue(this.amount);
                
            }
            else
            {
                shd.Parameters["amount"].SetValue(this.amount);

            }

            
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Begin(effect: this.shd);
            Globals.SpriteBatch.Draw(texture, this.position, null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.FlipHorizontally, 0f);
            //Globals.SpriteBatch.Draw(texture, this.position, Color.White);
            Globals.SpriteBatch.End();
        }

    }
}
