using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace WrathOfTheWraithGame
{
    public class Player : Sprite
    {

        public float HEALTH = 100;
        public const float DISPLACEMENT = 5f;
        public float specAbilityOneCooldown = 5f;
        public float specAbilityTwoCooldown = 10f;
        public bool isHit = false;
        public bool specAbilityOneActivated = false;
        public bool specAbilityTwoActivated = false;
        public Vector2 directionVec = new();
        public Vector2 mousePos;
        public float hitTimer = 1f;
        public bool hasClicked;
        public bool isControllable = true;
        private KeyboardState currentKey;
        private KeyboardState lastKey;
        public List<SpecialBulletOne> specialBulletsOne;
        public List<SpecialBulletTwo> specialBulletsTwo;
        public SpecialBulletOne specBulOne;

        public Player(Texture2D _texture) : base(_texture) { }
        public Player(Texture2D spriteTexture, Vector2 spritePosition, Rectangle boundBox, Color spriteColor)
        {
            boundBox.Width = spriteTexture.Width;
            boundBox.Height = spriteTexture.Height;
            texture = spriteTexture;
            position = spritePosition;
            specBulOne = new SpecialBulletOne();
            specialBulletsOne = new List<SpecialBulletOne>();
            specialBulletsTwo = new List<SpecialBulletTwo>();
        }

        public override void Update()
        {
            boundBox.X = (int)this.position.X;
            boundBox.Y = (int)this.position.Y;
            Input();
            timeHit();
        }

        //timer for player getting hit shader
        public void timeHit()
        {
            if (this.HEALTH <= 0)
            {
                Globals.CanEnd = true;
            }

        }


        public void Input()
        {
            lastKey = currentKey;
            currentKey = Keyboard.GetState();
            #region keyPuts
            if (Keyboard.GetState().GetPressedKeys().Length > 0 && this.isControllable)
            {
                
                if(currentKey.IsKeyDown(Keys.X) && lastKey.IsKeyUp(Keys.X))
                {
                    this.HEALTH -= 50;
                }





                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    directionVec = new Vector2(1, 0);

                    position += DISPLACEMENT * directionVec;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    directionVec = new Vector2(-1, 0);
                     position += DISPLACEMENT * directionVec; 
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    directionVec = new Vector2(0, 1);
                    position += DISPLACEMENT * directionVec;

                }
                else if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    directionVec = new Vector2(0, -1);
                    position += DISPLACEMENT * directionVec;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    position.Y += DISPLACEMENT / 2.1f;
                    position.X -= DISPLACEMENT / 2.1f;
                    directionVec = new Vector2(-1, -1);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    position.Y -= DISPLACEMENT / 2.1f;
                    position.X -= DISPLACEMENT / 2.1f;
                    directionVec = new Vector2(-1, 1);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    position.Y += DISPLACEMENT / 2.1f;
                    position.X += DISPLACEMENT / 2.1f;
                    directionVec = new Vector2(1, -1);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    position.Y -= DISPLACEMENT / 2.1f;
                    position.X += DISPLACEMENT / 2.1f;
                    directionVec = new Vector2(1, 1);
                }
            }
            

            if (Keyboard.GetState().IsKeyDown(Keys.Q) && !isHit)
            {
                isHit = true;
            }
            #endregion

            #region mouse



            if (currentKey.IsKeyDown(Keys.D3) && lastKey.IsKeyUp(Keys.D3))
            {
                this.hasClicked = true;
                this.specAbilityOneActivated = true;
                mousePos = new Vector2((float)Mouse.GetState().X, (float)Mouse.GetState().Y);


                var specialBulletOne = specBulOne.Clone() as SpecialBulletOne;

                specialBulletOne.Position = this.Position + new Vector2(texture.Width / 2, texture.Height / 2);
                specialBulletOne.Dir = Vector2.Normalize(mousePos - position);
                specialBulletsOne.Add(specialBulletOne);
            }

            if(currentKey.IsKeyDown(Keys.D2) && lastKey.IsKeyUp(Keys.D2))
            {
                this.specAbilityTwoActivated = true;

                for(int i = 0; i  < 4; i++) {
                    var specialBulletTwo = specBulOne.Clone() as SpecialBulletTwo;

                    specialBulletTwo.Position = this.Position;
                    specialBulletTwo.Dir = Vector2.Normalize(new Vector2(1, i/4f * (MathHelper.Tau) ));
                    specialBulletsTwo.Add(specialBulletTwo);
                }
            }

        

            if (this.hasClicked && this.hitTimer > 0) this.hitTimer -= Globals.DeltaTime;

            if (this.specAbilityOneActivated && this.specAbilityOneCooldown > 0) this.specAbilityOneCooldown -= Globals.DeltaTime;

            if (this.hitTimer <= 0)
            {
                this.hasClicked = false;
                this.hitTimer = 1;
            }

            if (this.specAbilityOneCooldown <= 0) this.specAbilityOneCooldown = 10f; this.specAbilityOneActivated = false;

            #endregion 
        }

        
        
       


       
    }
}
