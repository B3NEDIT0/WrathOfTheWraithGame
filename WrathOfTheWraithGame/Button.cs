using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace WrathOfTheWraithGame
{
    public class Button : Sprite
    {
        private Action _onClick;  // Action to perform when button is clicked
        private Color buttonColor;
        private Rectangle buttonRectangle;
        private Color _hoverColor;
        private bool _isHovered;
        private string buttonText;
        private bool _isClicked;
        private SpriteFont _font;


        public Button(Texture2D texture, string _buttonText, Vector2 pos) {
            this.texture = texture;
            this.position = pos;
            this.boundBox = new Rectangle((int)this.position.X  , (int)this.position.Y, (int)texture.Width, (int)texture.Height);
            this._isHovered = false;
            _font = Globals.Content.Load<SpriteFont>("menuFont");
            this.buttonText = _buttonText;

            
        }

        public string ButtonText { get { return buttonText; } set {  buttonText = value; } }    
        

        public void Update(GameTime gameTime)
        {
            // Update button state (check for hover and click)
            _isHovered = false;
            MouseState mouseState = Mouse.GetState();
            
            Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 1,1);

            if (mouseRect.Intersects(this.boundBox))
            {
                this._isHovered = true;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    this._isClicked = true;

                    switch (buttonText)
                    {
                        case ("Exit"):
                            Globals.CanEnd = true;
                            break;
                        case ("New Save"):
                            Globals.CurrentGameState = Globals.GameState.ClassSelection;
                            break;
                        case ("Warrior"): case ("Ranger"):
                            Globals.CurrentGameState = Globals.GameState.CharacterCreation;
                            break;
                        case ("Settings"):
                            Globals.CurrentGameState = Globals.GameState.Settings;
                            break;


                    }
                }

            }
            else this._isHovered = false;   

            if (this._isHovered)
            {
                this.buttonColor = Color.Red;
            }

          

        }

        public override void Draw()
        {
            if (!_isHovered)
            {
                this.buttonColor = Color.White;
            }


            Globals.SpriteBatch.Begin();
            // Draw the button with the correct color
            Globals.SpriteBatch.Draw(texture, this.position, this.buttonColor);

            if (this.buttonText is not null)
            {
                float buttonX = this.boundBox.X + this.boundBox.Width / 2 - (_font.MeasureString(this.buttonText).X / 2);
                float buttonY = this.boundBox.Y + this.boundBox.Height / 2 - (_font.MeasureString(this.buttonText).Y / 2);

                //Globals.SpriteBatch.DrawString(_font, this.buttonText, new Vector2(buttonX, buttonY), Color.White);
                Globals.SpriteBatch.DrawString(_font, this.buttonText, new Vector2(buttonX- 50f, buttonY-10f), Color.White, 0f, new Vector2(0,0), 3f, SpriteEffects.None, 0f);
            }

            Globals.SpriteBatch.End();
        }

        public Color HoverColor { get { return _hoverColor; } set { _hoverColor = value; } }
    }

    
}
