using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathOfTheWraithGame
{ 
    //globals class to handle global scope properties

    public static class Globals
    {
        public static float Seconds { get; set; }
        public static SpriteBatch SpriteBatch { get; set;}

        public static ContentManager Content {  get; set;}

        public static GraphicsDeviceManager Graphics {  get; set;}

        public static void Update(GameTime gameTime)
        {
            Seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
    }
}
