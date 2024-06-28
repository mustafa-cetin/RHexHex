using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RHexHex.Objects;
using System.Collections.Generic;

namespace RHexHex.Scenes
{
    internal class GameScene : Scene
    {

        private InputManager inputManager;

        private float speed;

        private RotatingObject rotatingObject;
        private Texture2D blackSquare;
        private Texture2D circleTexture;

        private List<NeedleObject> needleObjects;


        private int hak;

        private ContentLoader<SpriteFont> fontLoader;
        private SpriteFont circleFont;

        private ThrowBall throwBall;

        private Vector2 needleCircleOrigin;

        private bool clicked;

        private float needleCircleScale;
        private Vector2 stickSize;

        private float throwTime;
      
        public GameScene(SceneManager sceneManager, GraphicsDeviceManager graphics, ContentLoader<Texture2D> textureLoader, Color backgroundColor, ContentLoader<SpriteFont> fontLoader) : base(sceneManager, graphics, textureLoader, backgroundColor)
        {
            this.fontLoader = fontLoader;
        }

        public override void OnCreate()
        {
            inputManager = new InputManager();
            needleCircleScale = 0.08f;
            stickSize = new Vector2(0.07f, 1.8f);
            throwTime = 0.05f;
        }
        public override void Enter()
        {
            circleTexture = textureLoader.GetContent("CircleTex");
            blackSquare = textureLoader.GetContent("WhiteSquare");
            circleFont = fontLoader.GetContent("CircleFont");


            rotatingObject = new RotatingObject(new Vector2(0,-graphics.PreferredBackBufferHeight/4), Color.Black, 0f, 0.3f);
            rotatingObject.SetTexture(circleTexture);

            needleCircleOrigin = new Vector2(circleTexture.Width / 2, (1 / needleCircleScale) * (-rotatingObject.GetRadius() - stickSize.Y* this.blackSquare.Height+ 68.699524f));


            throwBall = new ThrowBall(
                circleTexture,
                new Vector2(0, +graphics.PreferredBackBufferHeight / 4),
                Color.Black,
                Vector2.One * 0.08f,
                throwTime,
                rotatingObject.GetPosition()-needleCircleScale*(needleCircleOrigin- new Vector2(circleTexture.Width / 2, circleTexture.Height / 2))    //new Vector2(0,48.58f)
                );


            needleObjects = new List<NeedleObject>();
            speed = 1;
            hak = 7;


           // Debug.WriteLine(rotatingObject.GetRadius());
        }

        public override void Exit()
        {
            
        }
        // pozisyon değiştirmeden origin değiğştir hexapawa imzasıyla


        public override void OnRemove()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            inputManager.Update();
            
            throwBall.Throw(gameTime);

            if (inputManager.GetKey(Keys.M))
            {
                SceneCamera.AddRotation(.1f);
            }


            if (!CheckCollisionsBetweenNeedles())
            {
                if (clicked && !throwBall.Throwed)
                {
                    clicked = false;
                    NeedleObject needleObject = new NeedleObject(
                        rotatingObject.GetPosition(),
                        Color.Black,
                        0f,
                        stickSize,
                        needleCircleScale,
                        rotatingObject.GetRadius()
                        );

                    needleObject.SetTexture(blackSquare);
                    needleObject.SetCircleTexture(circleTexture);
                    needleObjects.Add(needleObject);
                 //   Debug.WriteLine(needleObject.GetInGamePosition());
                    speed++;

                }

                if (inputManager.GetMouseButtonDown(0) && hak>0 && !clicked && !throwBall.Throwed)
                {
                    clicked = true;
                    throwBall.ClickThrow();
                    hak--;

                }

                foreach (var item in needleObjects)
                {

                    item.Rotate((float)gameTime.ElapsedGameTime.TotalSeconds*speed);
                }

            }
            else
            {
                sceneManager.SwitchToScene(0);
            }

            // 0,070000805 1,7849993 2,800003
        } 
        public override void Draw(GameTime gameTime)
        {
            foreach (var item in needleObjects)
            {
                item.Draw(spriteBatch, gameTime);
            }
            rotatingObject.Draw(spriteBatch,gameTime);
            spriteBatch.DrawString(circleFont, hak.ToString(), rotatingObject.GetPosition(), Color.White,0f, 0.5f * circleFont.MeasureString(hak.ToString()),1f,SpriteEffects.None,0f);
            
            if (hak>0)
            {
                throwBall.Draw(spriteBatch, gameTime);
            }


        }

        public bool CheckCollisionsBetweenNeedles()
        {

            foreach (var item in needleObjects)
            {
                // check collision
                foreach (var item1 in needleObjects)
                {

                    if (!item.Equals(item1))
                    {
                        if (Vector2.Distance(item.GetInGamePosition(), item1.GetInGamePosition()) <= 2 * item.GetRadius())
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }


    }
}
