using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WrathOfTheWraithGame
{
    public class SpecialBulletTwo : Projectile
    {
        public float angle;
        public SpecialBulletTwo() { 
            this.Texture = Globals.Content.Load<Texture2D>("bullet");
            this.VELOCITY = 50f;
            
        }

        public override void Update()
        {
            this.position += this.VELOCITY * this.dir;
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Begin();
            this.Draw(this.position, 1f);
            Globals.SpriteBatch.End();
        }
    }
}
