using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RHexHex.Objects
{
    internal class ThrowBall : GObject
    {


        private float time;
        private Vector2 velocity;

        private Vector2 target;

        private Vector2 throwingPos;
        private bool throwed;

        public bool Throwed { get => throwed; set => throwed = value; }

        public ThrowBall(Texture2D texture,Vector2 position, Color color, Vector2 scale,float time,Vector2 target)
        {
            this.texture = texture;
            this.origin= new Vector2(texture.Width/2, texture.Height/2);
            this.position = position;
            this.color = color;
            this.scale = scale;
            this.time = time;
            this.target = target;
            this.rotation = 0;
            velocity = (target - position) / time;
            throwed = false;
        }
        public void ClickThrow()
        {
            throwed = true;
            throwingPos = position;
        }
        public void Throw(GameTime gameTime)
        {
            
            if (throwingPos.Y-target.Y>=0 && throwed)
            {
                throwingPos += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (throwingPos.Y - throwingPos.Y <= 0)
            {
                throwed = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (throwed)
            {
                spriteBatch.Draw(texture, throwingPos, null, color, rotation, origin, scale, SpriteEffects.None, 0f);
            }
            spriteBatch.Draw(texture, position, null, color,  rotation, origin,scale, SpriteEffects.None, 0f);
        }
    }
}
