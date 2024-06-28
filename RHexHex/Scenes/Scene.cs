using RHexHex.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RHexHex.Scenes
{
    abstract class Scene
    {
        protected SceneManager sceneManager;

        protected SpriteBatch spriteBatch;
        protected GraphicsDeviceManager graphics;
        private Color backgroundColor;
        protected ContentLoader<Texture2D> textureLoader;


        public Camera SceneCamera { get; protected set; }
        public Color BackgroundColor { get => backgroundColor; set => backgroundColor = value; }

        public Scene(SceneManager sceneManager, GraphicsDeviceManager graphics, ContentLoader<Texture2D> textureLoader,Color backgroundColor)
        {
            this.sceneManager = sceneManager;
            this.graphics = graphics;
            this.textureLoader = textureLoader;
            this.backgroundColor = backgroundColor;
            SceneCamera = new Camera(graphics);
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void OnCreate();
        public abstract void OnRemove();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        public void SetSpriteBatch(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }
    }
}
