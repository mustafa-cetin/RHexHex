using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RHexHex.Scenes
{
    internal class SplashScreenScene : Scene
    {
        Texture2D startImage;

        private bool pass;


        private float maxTimer;
        private float timer;

        private float idealScale;
        private Color imageColor;
        private float imageAlpha;
        public SplashScreenScene(SceneManager sceneManager, GraphicsDeviceManager graphics, ContentLoader<Texture2D> textureLoader, Color backgroundColor) : base(sceneManager, graphics,textureLoader, backgroundColor)
        {

        }

        public override void OnCreate()
        {

            idealScale = 1f;
        }

        public override void OnRemove()
        {

        }

        public override void Enter()
        {
            startImage = textureLoader.GetContent("StartImg2");
            idealScale = (float)graphics.PreferredBackBufferHeight / startImage.Height;

            maxTimer = 3;
            pass = true;
            imageAlpha = 1;
            imageColor = new Color(Color.White, imageAlpha);
            timer = 0;
        }

        public override void Exit()
        {

        }


        public override void Update(GameTime gameTime)
        {

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= 1 & pass)
            {
                imageAlpha -= (float)gameTime.ElapsedGameTime.TotalSeconds / (maxTimer - 1);
            }
            if (timer >= maxTimer && pass)
            {
                pass = false;
                sceneManager.SwitchToScene(1);
            }


        }
        public override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Draw(startImage,
           Vector2.Zero,
           null,
           imageColor*imageAlpha,
           0f,
           new Vector2(startImage.Width / 2, startImage.Height / 2),
           idealScale,
           SpriteEffects.None,
           0f);
  
        }

    }
}
