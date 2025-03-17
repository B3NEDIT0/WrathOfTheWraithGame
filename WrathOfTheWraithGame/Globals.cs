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
        public enum ProjectileType { SentryBullet, }
        public static float DeltaTime { get; set; }
        public static Dictionary<Vector2, int> CurrentTileMap { get; set; } 
        public static Dictionary<Vector2, int> CurrentNonObstacles { get; set; }

        

        public static List<Button> MainMenuButtons { get; set; }    
        public static Dictionary<Vector2, int> CurrentObstacles { get; set; }
        public static GameTime GameTime { get; set; }
        public static SpriteBatch SpriteBatch { get; set;}

        public static bool CanEnd { get; set; }

        public enum GameState { MainMenu, Settings, Saves, ClassSelection, CharacterCreation, MapOptions, HelpScreen, Mausoleum, Cavern, }

        public static GameState CurrentGameState { get; set; }

        public static ContentManager Content {  get; set;}

        public static Vector2 Resolution { get; set; }

        public static int MapSizeX { get; set; }

        public static int MapSizeY { get; set; }

        public static GraphicsDeviceManager GraphicsManager {  get; set;}
        public static GraphicsDevice GraphicsDevice { get; set; }

        public static void Update(GameTime gameTime)
        {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            GameTime = gameTime;
            
        }

        public static float Mod(float x, float y)
        {
            return x - y * (float)Math.Floor((decimal)(x / y));
        }
    }
}
