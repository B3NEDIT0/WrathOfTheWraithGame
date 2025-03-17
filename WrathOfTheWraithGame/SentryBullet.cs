using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrathOfTheWraithGame
{
    public class SentryBullet : Projectile
    {
        private Vector2 dir;
        public SentryBullet(Vector2 direction) {
            this.dir = direction;
            this.texture = Globals.Content.Load<Texture2D>("bullet");
        }

        public override void Update()
        {
            this.position += Vector2.Normalize(this.dir) * 0.1f;
        }
        


    }
}
