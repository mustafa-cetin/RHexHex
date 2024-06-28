using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RHexHex.Objects
{
    internal class RotatingObject : GObject
    {
        private float radius;
        private float nScale;
        public RotatingObject(Vector2 position, Color color, float rotation, float nScale)
        {
            this.position = position;
            this.color = color;
            this.rotation = rotation;
            this.nScale = nScale;
        }
        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
            origin=new Vector2(texture.Width/2,texture.Height/2);
            radius = nScale * texture.Width / 2;
        }
        public override void Draw(SpriteBatch spriteBatch,GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, null, color, rotation, origin, nScale, SpriteEffects.None, 0f);
            
        }

        // origin mantığı normal origin zerodaymış gibi çiz -origin kadar ötele sonra scale et
        public Vector2 GetPosition()
        {
            return position;
        }
        public Vector2 GetOrigin()
        {
            return origin;
        }
        public float GetRadius()
        {
            return radius;
        }


    }
}
