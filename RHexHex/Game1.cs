using RHexHex.Components;
using RHexHex.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RHexHex.DebugScripts;
using System.Diagnostics;

namespace RHexHex
{
    public class Game1 : Game
    {

       
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont defaultFont;

        private SceneManager sceneManager;
        Camera camera;

        float scale;

        private ContentLoader<Texture2D> textureLoader;
        private ContentLoader<SpriteFont> fontLoader;

        int startSceneId;

        private DebugSc debugSc;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 480;
            _graphics.PreferredBackBufferHeight = 640;
            _graphics.ApplyChanges();

            textureLoader = new ContentLoader<Texture2D>(Content);
            fontLoader = new ContentLoader<SpriteFont>(Content);



            scale = 1;
            camera = new Camera(_graphics);
            camera.SetScale(scale);
            sceneManager = new SceneManager();

            SplashScreenScene splashScene = new SplashScreenScene(sceneManager, _graphics,textureLoader, Color.Black);
            int splashSceneId = sceneManager.Add(splashScene);

            SplashScreen2Scene splash2Scene = new SplashScreen2Scene(sceneManager, _graphics, textureLoader, Color.Wheat,fontLoader);
            int splash2SceneId = sceneManager.Add(splash2Scene);
            splash2Scene.PreviousColor = splashScene.BackgroundColor;

            GameScene gameScene = new GameScene(sceneManager, _graphics, textureLoader, Color.Wheat,fontLoader);
            int gameSceneId = sceneManager.Add(gameScene);

            splash2Scene.SetSceneToSwitch(gameSceneId);

            startSceneId = splashSceneId;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            sceneManager.SetSpriteBatchToScenes(_spriteBatch);
            
            textureLoader.AddContent("StartImg2", "SplashImages/StartImg2");
            textureLoader.AddContent("FinetasyText", "SplashImages/finetasytext");
            textureLoader.AddContent("CircleTex", "Sprites/circle-512");
            textureLoader.AddContent("WhiteSquare", "Sprites/whitesquare");

            fontLoader.AddContent("defaultFont", "defaultFont");
            fontLoader.AddContent("CircleFont", "CircleFont");
            fontLoader.AddContent("HelveticaHexa","SpriteFonts/HelveticaHexa");

            Content

            // TODO: use this.Content to load your game content here
        }


        protected override void BeginRun()
        {
            defaultFont = fontLoader.GetContent("defaultFont");
            
            sceneManager.SwitchToScene(startSceneId);

            debugSc = new DebugSc(_spriteBatch, _graphics, fontLoader, sceneManager);
            base.BeginRun();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            sceneManager.Update(gameTime);
            debugSc.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(sceneManager.GetSceneBackgroundColor());

            // TODO: Add your drawing code here

            _spriteBatch.Begin(transformMatrix: sceneManager.GetSceneCameraMatrix());
            sceneManager.Draw(gameTime);
            _spriteBatch.End();

           // debugSc.Draw(gameTime);




            base.Draw(gameTime);
        }

    }
}
