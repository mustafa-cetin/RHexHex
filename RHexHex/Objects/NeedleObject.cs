using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RHexHex.Objects
{
    internal class NeedleObject : GObject
    {


        private Texture2D circleTexture;
        private Vector2 circleOrigin;
        private float radius;

        private float circleScale;

        private float rotationObjectRadius;

        public NeedleObject(Vector2 position, Color color, float rotation, Vector2 scale,float circleScale, float rotationObjectRadius)
        {
            this.position = position;
            this.color = color;
            this.rotation = rotation;
            this.scale = scale;
            this.circleScale = circleScale;
            this.rotationObjectRadius = rotationObjectRadius;
        }
        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
            //   origin = new Vector2(texture.Width / 2, (1 / scale.Y) * -2.8f);

            origin = new Vector2(texture.Width / 2, (1 / scale.Y) * (-rotationObjectRadius +50f));
        }


        public void SetCircleTexture(Texture2D texture)
        {
            this.circleTexture = texture;
            circleOrigin = new Vector2(circleTexture.Width / 2, (1 / circleScale) * (-rotationObjectRadius - scale.Y* this.texture.Height+ 68.699524f));
            // origin scale carpildigi icin mesafe degisiyo bu yuzden 1/0,08f ekleyerek aradaki mesafenin sabit kalmasini sagladik
            radius = circleScale * circleTexture.Width / 2;
        }



        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, null, Color.Black, rotation, origin, scale, SpriteEffects.None, 0f);

            spriteBatch.Draw(circleTexture, position, null, Color.Black, rotation, circleOrigin, circleScale, SpriteEffects.None, 0f);
        }
        public void Rotate(float rotation)
        {
            this.rotation += rotation;
            if (this.rotation<=360)
            {
                this.rotation %= 360;
            }
        }
        public Vector2 GetInGamePosition()
        {
            Matrix rotationMatrix = Matrix.CreateRotationZ(rotation);
            Vector2 inGameCirclePos = position - circleScale * Vector2.Transform(circleOrigin - new Vector2(circleTexture.Width / 2, circleTexture.Height / 2), rotationMatrix);
            return inGameCirclePos;
        }
        public float GetRadius()
        {
            return radius;
        }
    }
}
