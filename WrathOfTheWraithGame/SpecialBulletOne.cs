using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace WrathOfTheWraithGame
{
    public class SpecialBulletOne : Projectile
    {
        public Effect shaderEffect; 
        
        public SpecialBulletOne() { this.Texture = Globals.Content.Load<Texture2D>("bullet"); this.VELOCITY = 30f; this.shaderEffect = Globals.Content.Load<Effect>("teleport"); }

        public override void Update()
        {
            this.position += this.VELOCITY * this.dir;
            this.shaderEffect.Parameters["t"].SetValue(Globals.DeltaTime);
            this.shaderEffect.Parameters["coords"].SetValue(new Vector2((this.Position.X + this.Texture.Width / 2) / Globals.Resolution.X, (this.Position.Y + this.Texture.Height / 2) / Globals.Resolution.Y));
        }

        public void Draw(Vector2 pos, float scale, bool overriden)
        {
            Globals.SpriteBatch.Begin();
            this.Draw(pos, scale);
            Globals.SpriteBatch.End();
        }
    }
}
