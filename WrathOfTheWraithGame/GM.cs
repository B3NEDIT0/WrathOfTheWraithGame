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
using System.Security.Policy;
using SharpDX.MediaFoundation;



//using a different class to manage game stuff. 

namespace WrathOfTheWraithGame
{
    public class GM
    {
        #region 
        private Texture2D warriorTexture;
        private Texture2D sentryTexture;
        private Texture2D buttonTexture;
        private Texture2D sliderTexture;
        private Texture2D healthTexture;
        private Texture2D energyTexture;

        private List<Rectangle> obstacleList;
        private List<Button> mainMenuButtons;

        private Matrix cameraTranslation;
        public Stats playerStats;
        

        public Effect specialBulletOne;
        public Effect hitEffect;
        public Effect enemyIndicationEffect;
        public Effect followingParticleEffect;

        public Player player;
        public Sentry testSentry;
        public ShipWrecker testWrecker;
        public Dominator testDom;
        public Sprite healthBar;
        public Sprite energyBar;

        //main menu
        private Button newSaveButton;
        private Button loadSaveButton;
        private Button helpButton;
        private Button settingsButton;
        private Button exitButton;

        //new save
        private Button warriorButton;
        private Button rangerButton;
        private float specBulOneShaderTimer;

        //character creation
        private Sprite playerNameText;

        private Slider sfxSlider;
        private Slider musicSlider;
        private Slider masterSlider;


        private Texture2D tileSet;
        private Dictionary<Vector2, int>baseCavernTileMap = new();
        private List<Rectangle> cavernRectList;
        #endregion


        private void CameraTranslation()
        {
            float uX = (Globals.Resolution.X / 2) - (player.Position.X );
           
            float uY = (Globals.Resolution.Y / 2) - (player.Position.Y );
            
            cameraTranslation = Matrix.CreateTranslation(uX, uY, 0f);
            
        }

        public GM() {
            followingParticleEffect = Globals.Content.Load<Effect>("ExplodingStars");
            warriorTexture = Globals.Content.Load<Texture2D>("warriororb");
            sentryTexture = Globals.Content.Load<Texture2D>("enemy2");
            buttonTexture = Globals.Content.Load<Texture2D>("WOTW_button");
            sliderTexture = Globals.Content.Load<Texture2D>("FullVolumeBar");
            healthTexture = Globals.Content.Load<Texture2D>("health");
            energyTexture = Globals.Content.Load<Texture2D>("energy");
            hitEffect = Globals.Content.Load<Effect>("Ember");
            enemyIndicationEffect = Globals.Content.Load<Effect>("enemyIndicator");
            specialBulletOne = Globals.Content.Load<Effect>("teleport");

            player = new Player(warriorTexture, new Vector2(1024,768), new Rectangle(), Color.White);
            testSentry = new ();
            testWrecker = new ();
            testDom = new();

            newSaveButton = new Button(buttonTexture, "New Save", new Vector2(Globals.Resolution.X / 2 +buttonTexture.Width, (1) * 280 - 150));
            loadSaveButton = new Button(buttonTexture, "Load Save", new Vector2(Globals.Resolution.X / 2 + buttonTexture.Width , (2) * 280 - 150));
            helpButton = new Button(buttonTexture, "Help", new Vector2(Globals.Resolution.X / 2 + buttonTexture.Width , (3) * 280 - 150));
            settingsButton = new Button(buttonTexture, "Settings", new Vector2(Globals.Resolution.X / 2 + buttonTexture.Width, (4) * 280 - 150));
            exitButton = new Button(buttonTexture, "Exit", new Vector2(Globals.Resolution.X / 2 + buttonTexture.Width, (5) * 280 - 150));
            playerNameText = new Sprite(buttonTexture, new Vector2(Globals.Resolution.X / 2 + buttonTexture.Width, (3) * 280 - 150), true);

            warriorButton = new Button(buttonTexture, "Warrior", new Vector2(Globals.Resolution.X / 2 + buttonTexture.Width, (2) * 280 - 150));
            rangerButton = new Button(buttonTexture, "Ranger", new Vector2(Globals.Resolution.X / 2 + buttonTexture.Width, (4) * 280 - 150));
            Globals.MainMenuButtons = new List<Button>();

            sfxSlider = new Slider(new Vector2(Globals.Resolution.X / 2 + sliderTexture.Width, (1) * 280 - 150));
            musicSlider = new Slider(new Vector2(Globals.Resolution.X / 2 + sliderTexture.Width, (3) * 280 - 150));
            masterSlider = new Slider(new Vector2(Globals.Resolution.X / 2 + sliderTexture.Width, (5) * 280 - 150));

            playerStats = new();

            Globals.CurrentGameState = Globals.GameState.MainMenu;///////////////////////////////////
        }
        
        public void LoadContent()
        {
            baseCavernTileMap = Tilemap.Load("../../../BaseCavern.txt");
            tileSet = Globals.Content.Load<Texture2D>("tilemapSet-export");
 ;          cavernRectList = new() { new Rectangle(0, 0, 64, 64), new Rectangle(64, 0, 64, 64), new Rectangle(128, 0, 64, 64), new Rectangle(192, 0, 64, 64) };


            Globals.MainMenuButtons.Add(newSaveButton);
            Globals.MainMenuButtons.Add(loadSaveButton);
            Globals.MainMenuButtons.Add(helpButton);
            Globals.MainMenuButtons.Add(settingsButton);
            Globals.MainMenuButtons.Add(exitButton);
        }

        public void Update(GameTime _gt)
        {

            if (Globals.CurrentGameState == Globals.GameState.Cavern)
            {
                //followingParticleEffect.Parameters["time"].SetValue(timeAmount);
                foreach (var item in player.specialBulletsOne) item.Update();
                foreach (var item in player.specialBulletsTwo) item.Update();
                player.Update();
                hitEffect.Parameters["time"].SetValue(1 - player.hitTimer);
                testSentry.Update(player.Position);
                testWrecker.Update();


                followingParticleEffect.Parameters["playerPos"].SetValue(new Vector2( (player.Position.X + player.Texture.Width / 2) / Globals.Resolution.X, ((player.Position.Y + player.Texture.Height / 2)) / Globals.Resolution.Y));
                specialBulletOne.Parameters["t"].SetValue(Globals.DeltaTime);
                enemyIndicationEffect.Parameters["t"].SetValue(Globals.DeltaTime);
                CameraTranslation();
            }

            if (Globals.CurrentGameState == Globals.GameState.MainMenu)
            {
                newSaveButton.Update(Globals.GameTime);
                loadSaveButton.Update(Globals.GameTime);
                settingsButton.Update(Globals.GameTime);
                helpButton.Update(Globals.GameTime);
                exitButton.Update(Globals.GameTime);

            }

            if(Globals.CurrentGameState == Globals.GameState.ClassSelection)
            {
                warriorButton.Update(Globals.GameTime);
                rangerButton.Update(Globals.GameTime);
            }

            if(Globals.CurrentGameState == Globals.GameState.Settings)
            {
                sfxSlider.Update();
                musicSlider.Update();
                masterSlider.Update();
            }

            if(Globals.CurrentGameState == Globals.GameState.CharacterCreation)
            {
                playerNameText.Update();
                playerNameText.Update();
            }
        }

        

        public void Draw()
        {

            if (Globals.CurrentGameState == Globals.GameState.Cavern)
            {


                //draw tilemap and camera translation
                Globals.SpriteBatch.Begin(transformMatrix: cameraTranslation);
                Tilemap.Draw(baseCavernTileMap, cavernRectList, tileSet);
                testSentry.Draw(testSentry.Position);
                testWrecker.Draw(testWrecker.Position);
                testDom.Draw(testDom.Position);
                Globals.SpriteBatch.End();



                //render target for player light 
                var playerEffectRT = Sprite.PlayerEffectCanvas(player);
                Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, followingParticleEffect);
                Globals.SpriteBatch.Draw(playerEffectRT, new Vector2(0, 0), Color.White);
                Globals.SpriteBatch.End();
                playerEffectRT.Dispose();

                var specAbilityOneRT = new RenderTarget2D(Globals.GraphicsDevice, (int)Globals.Resolution.X, (int)Globals.Resolution.Y);
                foreach (var item in player.specialBulletsOne)
                {
                    item.Draw(item.Position, 0.5f, true);
                    Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, item.shaderEffect);
                    Globals.SpriteBatch.Draw(specAbilityOneRT, new Vector2(0, 0), Color.White);
                    Globals.SpriteBatch.End();
                }
                foreach(var item in player.specialBulletsTwo)
                {
                    item.Draw();
                }
                specAbilityOneRT.Dispose();
                Globals.GraphicsDevice.SetRenderTarget(null);




            }


            if(Globals.CurrentGameState == Globals.GameState.Mausoleum)
            {
                Globals.GraphicsDevice.DepthStencilState = new DepthStencilState()
                {
                    StencilEnable = true,
                    StencilFunction = CompareFunction.Equal,
                    ReferenceStencil = 1 // Only render shadows where obstacles exist
                };

            }

            if (Globals.CurrentGameState == Globals.GameState.MainMenu)
            {
                newSaveButton.Draw();
                loadSaveButton.Draw();
                settingsButton.Draw();
                helpButton.Draw();
                exitButton.Draw();
            }
            if (Globals.CurrentGameState == Globals.GameState.ClassSelection)
            {
                warriorButton.Draw();
                rangerButton.Draw();
            }

            if (Globals.CurrentGameState == Globals.GameState.Settings)
            {
                sfxSlider.Draw();
                masterSlider.Draw();
                musicSlider.Draw();
            }

            if(Globals.CurrentGameState == Globals.GameState.CharacterCreation)
            {
                playerNameText.Update();
            }
        }





    }
}
