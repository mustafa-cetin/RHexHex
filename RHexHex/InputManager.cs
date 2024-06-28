using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RHexHex
{
    internal class InputManager
    {
        private KeyboardState keyboardState;
        private KeyboardState lastKeyboardState;

        private MouseState mouseState;
        private MouseState lastMouseState;
        
        public InputManager()
        {
            keyboardState=Keyboard.GetState();
            lastKeyboardState=Keyboard.GetState();
            mouseState = Mouse.GetState();
            lastMouseState = Mouse.GetState();
        }
        public void Update()
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            lastMouseState = mouseState;
            mouseState = Mouse.GetState();
            
        }

        public bool GetKey(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }
        public bool GetKeyDown(Keys key)
        {
            return lastKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key);
        }
        public bool GetKeyUp(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }


        public Vector2 GetWorldMousePosition(Matrix cameraTransformMatrix)
        {
            return Vector2.Transform(GetMousePosition(), Matrix.Invert(cameraTransformMatrix));
        }
        public Vector2 GetMousePosition()
        {
            return mouseState.Position.ToVector2();
        }


        // 0 left, 1 middle, 2 right
        public bool GetMouseButtonDown(int buttonId)
        {
            switch (buttonId)
            {
                case 0:
                    return mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released;
                case 1:
                    return mouseState.MiddleButton == ButtonState.Pressed && lastMouseState.MiddleButton == ButtonState.Released;
                case 2:
                    return mouseState.RightButton == ButtonState.Pressed && lastMouseState.RightButton == ButtonState.Released;
                default:
                    break;
            }
            return false;
        }
        public bool GetMouseButton(int buttonId)
        {
            switch (buttonId)
            {
                case 0:
                    return mouseState.LeftButton == ButtonState.Pressed;
                case 1:
                    return mouseState.MiddleButton == ButtonState.Pressed;
                case 2:
                    return mouseState.RightButton == ButtonState.Pressed;
                default:
                    break;
            }
            return false;
        }
        public bool GetMouseButtonUp(int buttonId)
        {
            switch (buttonId)
            {
                case 0:
                    return mouseState.LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed;
                case 1:
                    return mouseState.MiddleButton == ButtonState.Released && lastMouseState.MiddleButton == ButtonState.Pressed;
                case 2:
                    return mouseState.RightButton == ButtonState.Released && lastMouseState.RightButton == ButtonState.Pressed;
                default:
                    break;
            }
            return false;
        }


    }
}
