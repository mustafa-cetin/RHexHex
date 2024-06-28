using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RHexHex.Objects
{
    internal abstract class GObject
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Color color;
        protected float rotation;
        protected Vector2 origin;
        protected Vector2 scale;

        public abstract void Draw(SpriteBatch spriteBatch,GameTime gameTime);
    }
}
