using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

//sprite class that will be used for general textures and sprites to be loaded in.

namespace WrathOfTheWraithGame
{
    public class Sprite
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected float scale;
        protected Rectangle boundBox;
        protected Vector2 origin;
        protected bool isCollidable = false;
        protected string buttonText;
        protected bool writable = false;
        protected SpriteFont font;


        public Sprite() { }
        public Sprite(Texture2D _texture)
        {
            texture = _texture;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            this.boundBox = new Rectangle((int)this.position.X,(int)this.position.Y, (int)  _texture.Width,(int) _texture.Height);
        }

        public Sprite(Texture2D _texture, Vector2 pos, bool _writable)
        {
            texture = _texture;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            this.boundBox = new Rectangle((int)this.position.X, (int)this.position.Y, (int)_texture.Width, (int)_texture.Height);
            position = pos;
            writable = _writable;
            font = Globals.Content.Load<SpriteFont>("menuFont");
        }

        public Sprite(Texture2D _texture, bool _isCollidable)
        {
            texture = _texture;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            this.isCollidable = _isCollidable;
        }

        StringBuilder builder = new StringBuilder();
        /*ublic void Window_TextInput(object sender, TextInputEventArgs e)
        {
            if (e.Key == Keys.Back)
            {
                if (builder.Length > 0)
                    builder.Remove(builder.Length - 1, 1);

            }
            else
                builder.Append(e.Character);

            this.Window.Title = builder.ToString();
        }*/


        public virtual void Update()
        { 
            if(this.writable)
            {
                float buttonX = this.boundBox.X + this.boundBox.Width / 2 - (font.MeasureString(this.buttonText).X / 2);
                float buttonY = this.boundBox.Y + this.boundBox.Height / 2 - (font.MeasureString(this.buttonText).Y / 2);

                

                //Globals.SpriteBatch.DrawString(_font, this.buttonText, new Vector2(buttonX, buttonY), Color.White);
                Globals.SpriteBatch.DrawString(font, this.buttonText, new Vector2(buttonX - 50f, buttonY - 10f), Color.White, 0f, new Vector2(0, 0), 3f, SpriteEffects.None, 0f);
            }
        }




        public static Texture2D PlayerEffectCanvas(Player player)
        {

            RenderTarget2D rt = new(Globals.GraphicsDevice, (int)Globals.Resolution.X, (int)Globals.Resolution.Y);

            Globals.SpriteBatch.Begin();

            player.Draw(player.position);
            Globals.SpriteBatch.End();


            Globals.GraphicsDevice.SetRenderTarget(null);

            return rt;
        }


        public virtual void Draw() { }


        public virtual void Draw(Vector2 pos)
        {
            Globals.SpriteBatch.Draw(texture, pos, Color.White);
        }

        

        public virtual void Draw(Vector2 pos, float scale)
        {
    
            Globals.SpriteBatch.Draw(texture, pos, null,
            Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

        }

        public float Scale { get { return scale; } set { scale = value; } }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Texture2D Texture { get { return texture; } set { texture = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }


    }
}
