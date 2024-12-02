using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace WrathOfTheWraithGame
{
    public class Button : Sprite
    {
        private Action _onClick;  // Action to perform when button is clicked
        private Color _hoverColor = Color.Red;
        private Color _clickedColor = Color.Lime;
        private bool _isHovered;
        private bool _isClicked;

        public Button(Texture2D texture)
            : base(texture) { }
        

        public void Update(GameTime gameTime)
        {
            // Update button state (check for hover and click)
            MouseState mouseState = Mouse.GetState();
            Rectangle buttonRectangle = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);

            _isHovered = buttonRectangle.Contains(mouseState.Position);

            if (_isHovered)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    _isClicked = true;
                }
                else if (_isClicked)
                {
                    _isClicked = false;
                    _onClick.Invoke();  // Invoke the click action
                }
            }
        }

        public override void Draw(Vector2 pos)
        {
            Color buttonColor = Color.White;

            if (_isHovered)
            {
                buttonColor = _hoverColor;
            }

            if (_isClicked)
            {
                buttonColor = _clickedColor;
            }

            // Draw the button with the correct color
            Globals.SpriteBatch.Draw(texture, Position, buttonColor);
        }
    }
}
