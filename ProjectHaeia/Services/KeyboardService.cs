using Microsoft.Xna.Framework;

namespace ProjectHaeia.Services
{
    public interface IKeyboardService
    {
        void ExitGame(ProjectHaeia game);
        void MoveCamera(Direction direction);
    }

    public class KeyboardService : IKeyboardService
    {
        private readonly ICameraService _cameraService;

        // TODO: put into config/worldsettings
        private readonly float MOVE_SPEED = 3f;

        public KeyboardService(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void ExitGame(ProjectHaeia game)
        {
            game.Exit();
        }

        public void MoveCamera(Direction direction)
        {
            Vector2 position = _cameraService.Position;

            switch (direction)
            {
                case Direction.Up:
                    position -= Vector2.UnitY * MOVE_SPEED;
                    _cameraService.MoveCamera(position);
                    break;
                case Direction.Down:
                    position += Vector2.UnitY * MOVE_SPEED;
                    _cameraService.MoveCamera(position);
                    break;
                case Direction.Left:
                    position -= Vector2.UnitX * MOVE_SPEED;
                    _cameraService.MoveCamera(position);
                    break;
                case Direction.Right:
                    position += Vector2.UnitX * MOVE_SPEED;
                    _cameraService.MoveCamera(position);
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
