using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RHexHex.Scenes;

namespace RHexHex.DebugScripts
{
    internal class DebugSc
    {
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphics;

        private ContentLoader<SpriteFont> _fontLoader;

        private InputManager _inputManager;


        private Vector2 mousePos;
        private Vector2 editedMousePos;

        private SceneManager _sceneManager;

        private SpriteFont defaultFont;

        public DebugSc(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, ContentLoader<SpriteFont> fontLoader,SceneManager sceneManager)
        {
            _spriteBatch = spriteBatch;
            _graphics = graphics;
            _fontLoader = fontLoader;
            _sceneManager = sceneManager;
            Start();    
        }

        public void Start()
        {
            _inputManager = new InputManager();
            defaultFont = _fontLoader.GetContent("defaultFont");
        }

        public void Update(GameTime gameTime)
        {
            _inputManager.Update();

            mousePos = _inputManager.GetMousePosition();
            editedMousePos = Vector2.Transform(mousePos, Matrix.Invert(_sceneManager.GetSceneCameraMatrix()));
        }



        public void Draw(GameTime gameTime)
        {

            _spriteBatch.Begin();
            _spriteBatch.DrawString(defaultFont, editedMousePos.X + " " + editedMousePos.Y, mousePos + new Vector2(25, 0) + new Vector2(1, 1), Color.Black);
            _spriteBatch.DrawString(defaultFont, editedMousePos.X + " " + editedMousePos.Y, mousePos + new Vector2(25, 0) + new Vector2(-1, 1), Color.Black);
            _spriteBatch.DrawString(defaultFont, editedMousePos.X + " " + editedMousePos.Y, mousePos + new Vector2(25, 0) + new Vector2(-1, -1), Color.Black);
            _spriteBatch.DrawString(defaultFont, editedMousePos.X + " " + editedMousePos.Y, mousePos + new Vector2(25, 0) + new Vector2(1, -1), Color.Black);
            _spriteBatch.DrawString(defaultFont, editedMousePos.X + " " + editedMousePos.Y, mousePos + new Vector2(25, 0), Color.White);
            _spriteBatch.End();
        }



    }
}
