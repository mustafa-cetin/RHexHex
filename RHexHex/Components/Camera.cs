using Microsoft.Xna.Framework;

namespace RHexHex.Components
{
    internal class Camera
    {
        private GraphicsDeviceManager graphics;

        private float scale;

        public Matrix TransformMatrix { get; private set; }
        private Vector3 cameraPosition;
        private Vector3 cameraOrigin;

        public float rotation;
        public Camera(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.scale = 1;
            this.rotation = 0;
            cameraPosition = Vector3.Zero;
            cameraOrigin = new Vector3(-graphics.PreferredBackBufferWidth / 2,- graphics.PreferredBackBufferHeight / 2, 0);
            SetPositionToMatrix();
        }
        public void SetCameraPosition(Vector3 cameraPos)
        {
            cameraPosition = cameraPos;
            SetPositionToMatrix();
        }
        public void SetCameraPosition(float x,float y, float z)
        {
            cameraPosition = new Vector3(x, y, z);
            SetPositionToMatrix();
        }
        public void SetCameraPositionX(float x)
        {
            cameraPosition.X = x;
            SetPositionToMatrix();
        }
        public void SetCameraPositionY(float y)
        {
            cameraPosition.Y = y;
            SetPositionToMatrix();
        }
        public void SetCameraPositionZ(float z)
        {
            cameraPosition.Z = z;
            SetPositionToMatrix();
        }
        public void SetScale(float newScale)
        {
            scale = newScale;
            SetPositionToMatrix();
        }
        public void AddScale(float newScale)
        {
            scale += newScale;
            SetPositionToMatrix();
        }
        public void AddPosition(Vector3 cameraPos)
        {
            cameraPosition += cameraPos;
            SetPositionToMatrix();
        }
        public void AddPosition(float x,float y,float z)
        {
            cameraPosition.X += x;
            cameraPosition.Y += y;
            cameraPosition.Z += z;
            SetPositionToMatrix();
        }
        public void AddRotation(float radian)
        {
            this.rotation += radian;
            SetPositionToMatrix();
        }

        private void SetPositionToMatrix() 
        {
             Matrix rotateMatrix = Matrix.CreateRotationZ(rotation);

            // TransformMatrix = Matrix.CreateTranslation((1 / scale) * -cameraPosition) * Matrix.CreateScale(scale);

            TransformMatrix = Matrix.CreateTranslation(-cameraPosition)
                * Matrix.CreateTranslation(Vector3.Transform((1 / scale) * -cameraOrigin, Matrix.Invert(rotateMatrix)))
                * Matrix.CreateScale(scale)
                * rotateMatrix;
            ;
        }
    }
}
