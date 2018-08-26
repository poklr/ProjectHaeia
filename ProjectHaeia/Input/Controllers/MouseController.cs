using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectHaeia.Camera;
using ProjectHaeia.Enums;
using ProjectHaeia.Input.Managers;

namespace ProjectHaeia.Input.Controllers
{
    public class MouseController : IMousePosition
    {
        private readonly IMouseManager _mouseManager;

        private MouseState _previousMouseState;
        private int _previousScrollValue;

        public MouseController(IMouseManager mouseManager)
        {
            _mouseManager = mouseManager;
            _previousMouseState = Mouse.GetState();
            _previousScrollValue = _previousMouseState.ScrollWheelValue;
        }

        public void Update()
        {
            MouseState currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
            {
                _mouseManager.ButtonPressed(currentMouseState, MouseButton.Left);
            }

            if (currentMouseState.ScrollWheelValue > _previousScrollValue)
            {
                _mouseManager.ZoomIn();
            }
            else if (currentMouseState.ScrollWheelValue < _previousScrollValue)
            {
                _mouseManager.ZoomOut();
            }

            _previousMouseState = currentMouseState;
            _previousScrollValue = currentMouseState.ScrollWheelValue;
        }

        public Vector2 GetWorldMousePosition()
        {
            return _mouseManager.GetWorldMousePosition(Mouse.GetState());
        }
    }
}
