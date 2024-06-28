using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RHexHex.Scenes
{
    internal class SplashScreen2Scene : Scene
    {

        private Color previousColor;
        private Color myOriginColor;

        private float lerpAmount;
        public Color PreviousColor { get => previousColor; set => previousColor = value; }

        private Texture2D finetasyTextImage;
        private Color imageColor;
        private float imageAlpha;

        private float timer;

        private int sceneToSwitch;

        private ContentLoader<SpriteFont> fontLoader;
        private SpriteFont hexaStudiosFont;
        public SplashScreen2Scene(SceneManager sceneManager, GraphicsDeviceManager graphics, ContentLoader<Texture2D> textureLoader, Color backgroundColor,ContentLoader<SpriteFont> fontLoader) : base(sceneManager, graphics,textureLoader, backgroundColor)
        {
            this.fontLoader = fontLoader;
        }


        public override void OnCreate()
        {
            sceneToSwitch = 0;
        }

        public override void OnRemove()
        {

        }

        public override void Enter()
        {
            finetasyTextImage = textureLoader.GetContent("FinetasyText");
            hexaStudiosFont = fontLoader.GetContent("HelveticaHexa");

            myOriginColor = BackgroundColor;
            BackgroundColor = PreviousColor;
            imageColor = Color.Black;
            imageAlpha = 0f;
            timer = 0f;
        }

        public override void Exit()
        {
          
        }


        public override void Update(GameTime gameTime)
        {
            lerpAmount += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer>=1)
            {
                if (imageAlpha >= 0)
                {
                    imageAlpha -= (float)gameTime.ElapsedGameTime.TotalSeconds / 2;
                }
                else
                {
                    imageAlpha = 0f;
                    sceneManager.SwitchToScene(sceneToSwitch);
                }
            }
            else
            {

                if (imageAlpha>=1)
                {
                    imageAlpha = 1f;
                    timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    imageAlpha += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

            }

            BackgroundColor =Color.Lerp(PreviousColor, myOriginColor,lerpAmount);
        }
        public override void Draw(GameTime gameTime)
        {
        //    spriteBatch.Draw(finetasyTextImage,
        //Vector2.Zero,
        //null,
        //imageColor * imageAlpha,
        //0f,
        //new Vector2(finetasyTextImage.Width / 2, finetasyTextImage.Height / 2),
        //.3f,
        //SpriteEffects.None,
        //0f);
        //
        spriteBatch.DrawString(hexaStudiosFont, "HEXA STUDIOS", Vector2.Zero, imageColor*imageAlpha, 0f,
                0.5f * hexaStudiosFont.MeasureString("HEXA STUDIOS"), .8f, SpriteEffects.None, 0f);
        }
        public void SetSceneToSwitch(int sceneId)
        {
            sceneToSwitch = sceneId;
        }
    }
}
