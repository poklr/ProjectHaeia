using Microsoft.Xna.Framework;
using ProjectHaeia.Camera;
using System;

namespace ProjectHaeia.Input.Managers
{
    public class KeyboardManager : IKeyboardManager
    {
        private readonly ICameraManager _cameraManager;

        // TODO: put into config/worldsettings
        private const float MOVE_SPEED = 3f;
        
        public event EventHandler ExitKeyPressed;

        public KeyboardManager(ICameraManager cameraService)
        {
            _cameraManager = cameraService;
        }

        public void ExitGame()
        {
            ExitKeyPressed?.Invoke(this, EventArgs.Empty);
        }

        public void MoveCamera(Direction direction)
        {
            Vector2 position = _cameraManager.Position;

            switch (direction)
            {
                case Direction.Up:
                    position -= Vector2.UnitY * MOVE_SPEED;
                    _cameraManager.MoveCamera(position);
                    break;
                case Direction.Down:
                    position += Vector2.UnitY * MOVE_SPEED;
                    _cameraManager.MoveCamera(position);
                    break;
                case Direction.Left:
                    position -= Vector2.UnitX * MOVE_SPEED;
                    _cameraManager.MoveCamera(position);
                    break;
                case Direction.Right:
                    position += Vector2.UnitX * MOVE_SPEED;
                    _cameraManager.MoveCamera(position);
                    break;
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
