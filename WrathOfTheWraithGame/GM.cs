using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Input;
//using a different class to manage game stuff. 

namespace WrathOfTheWraithGame
{
    public class GM
    {
        private Vector2 canvasPos = new(0, 0);
        private Sprite canvas;
        private Texture2D canvasTexture;
        public Effect emberEffect;
        public Effect followingParticleEffect; 
        private Texture2D tileSet;
        private int particleCount;
        private Dictionary<Vector2, int>baseMausoleumTileMap = new Dictionary<Vector2, int>();
        private List<Rectangle> rectList;
        public Vector2 Resolution;
        

        public GM() {
            followingParticleEffect = Globals.Content.Load<Effect>("ExplodingStars");
        }
        
        public void LoadContent()
        {
            canvasTexture = Globals.Content.Load<Texture2D>("ACTUALBACKGROUNDSHADERIMAGE-export");
            emberEffect = Globals.Content.Load<Effect>("Ember");
            followingParticleEffect = Globals.Content.Load<Effect>("ExplodingStars");
            baseMausoleumTileMap = Tilemap.Load("../../../BaseMausoleum.txt");
            tileSet = Globals.Content.Load<Texture2D>("tilemapSet");

            canvas = new(canvasTexture);
            rectList = new() { new Rectangle(128, 0, 64, 64), new Rectangle(0, 0, 64, 64), new Rectangle(64, 0, 64, 64) };
        }

        public void Update(GameTime _gt)
        {
            
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin();
            Tilemap.Draw(baseMausoleumTileMap, rectList, tileSet);
            Globals.SpriteBatch.End();
            Globals.SpriteBatch.Begin();
            canvas.Draw(Vector2.Zero, 2f);
            Globals.SpriteBatch.End();
        }

    }
}
