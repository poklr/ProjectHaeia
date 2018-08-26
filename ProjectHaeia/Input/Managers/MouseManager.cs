using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectHaeia.Camera;
using ProjectHaeia.Enums;
using System.Diagnostics;

namespace ProjectHaeia.Input.Managers
{
    // TODO: turn into a thread/task?
    public class MouseManager : IMouseManager
    {
        private readonly ICameraManager _cameraManager;

        public MouseManager(ICameraManager cameraManager)
        {
            _cameraManager = cameraManager;
        }

        public void ButtonPressed(MouseState mouseState, MouseButton button)
        {
            var position = GetWorldMousePosition(mouseState);

            Debug.WriteLine("Position: " + position + " - Mousebutton: " + button);
        }

        public Vector2 GetWorldMousePosition(MouseState mouseState)
        {
            return Vector2.Transform(new Vector2(mouseState.X, mouseState.Y), Matrix.Invert(_cameraManager.View));
        }

        public void ZoomIn()
        {
            _cameraManager.ZoomIn();
        }

        public void ZoomOut()
        {
            _cameraManager.ZoomOut();
        }
    }
}
