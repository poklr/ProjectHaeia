using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectHaeia.Enums;
using ProjectHaeia.Services;

namespace ProjectHaeia.Input
{
    public class MouseController
    {
        private readonly IMouseService _mouseService;
        private readonly ICameraService _cameraService;

        private MouseState _previousMouseState;
        private int _previousScrollValue;

        public MouseController(IMouseService mouseService, ICameraService cameraService)
        {
            _mouseService = mouseService;
            _cameraService = cameraService;
            _previousMouseState = Mouse.GetState();
            _previousScrollValue = _previousMouseState.ScrollWheelValue;
        }

        public void Update()
        {
            MouseState currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
            {
                _mouseService.ButtonPressed(GetWorldMousePosition(currentMouseState), MouseButton.Left);
            }

            if (currentMouseState.ScrollWheelValue > _previousScrollValue)
            {
                _mouseService.ZoomIn();
            }
            else if (currentMouseState.ScrollWheelValue < _previousScrollValue)
            {
                _mouseService.ZoomOut();
            }

            _previousMouseState = currentMouseState;
            _previousScrollValue = currentMouseState.ScrollWheelValue;
        }

        public Vector2 GetWorldMousePosition()
        {
            return GetWorldMousePosition(_previousMouseState);
        }

        private Vector2 GetWorldMousePosition(MouseState mouseState)
        {
            return Vector2.Transform(new Vector2(mouseState.X, mouseState.Y), Matrix.Invert(_cameraService.View));
        }
    }
}
