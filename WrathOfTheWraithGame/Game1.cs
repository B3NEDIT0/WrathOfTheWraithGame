using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WrathOfTheWraithGame
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GM gameManager;
        float timeAmount;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 2048;
            _graphics.PreferredBackBufferHeight = 1536;
            _graphics.ApplyChanges();
            timeAmount = 0;

            Globals.Content = Content;
            gameManager = new GM();
            gameManager.Resolution.X = 2048;
            gameManager.Resolution.Y = 1536;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
            gameManager.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.Update(gameTime);
            gameManager.Update(gameTime);
            timeAmount += Globals.Seconds;
            //gameManager.emberEffect.Parameters["time"].SetValue(timeAmount);
           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            gameManager.Draw();

            base.Draw(gameTime);
        }
    }
}