using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RHexHex.Scenes
{
    internal class SceneManager
    {
        private Dictionary<int, Scene> scenes;
        private Scene currentScene;
        private int insertedSceneId;

        public SceneManager()
        {
            currentScene = null;
            scenes = new Dictionary<int, Scene>();
            insertedSceneId = 0;
        }

        public int Add(Scene scene)
        {
            scene.OnCreate();
            scenes.Add(insertedSceneId, scene);
            insertedSceneId++;
            return insertedSceneId - 1;
        }

        public void SwitchToScene(int sceneId)
        {
            if (currentScene != null)
            {
                currentScene.Exit();
            }
            currentScene = scenes[sceneId];
            currentScene.Enter();

            //Debug.WriteLine("Switched to scene id: " + sceneId);
        }
        public void Draw(GameTime gameTime)
        {
            if (currentScene != null)
            {
                currentScene.Draw(gameTime);
            }
        }
        public void Update(GameTime gameTime)
        {
            if (currentScene != null)
            {
                currentScene.Update(gameTime);
            }
        }
        public void SetSpriteBatchToScenes(SpriteBatch spriteBatch)
        {
            foreach (var scene in scenes)
            {
                scene.Value.SetSpriteBatch(spriteBatch);
            }
        }
        public Color GetSceneBackgroundColor()
        {
            if (currentScene!=null)
            {
                return currentScene.BackgroundColor;
            }
            return Color.White;
        }
        public Matrix GetSceneCameraMatrix()
        {
            if (currentScene!=null)
            {
                return currentScene.SceneCamera.TransformMatrix;
            }
            return Matrix.Identity;
        }

    }
}
