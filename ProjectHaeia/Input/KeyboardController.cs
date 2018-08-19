using Microsoft.Xna.Framework.Input;
using ProjectHaeia.Services;

namespace ProjectHaeia.Input
{
    public class KeyboardController
    {
        private readonly ProjectHaeia _game;
        private readonly IKeyboardService _keyboardService;

        private KeyboardState _previousKeyboardState;

        public KeyboardController(ProjectHaeia game, IKeyboardService keyboardService)
        {
            _game = game;
            _keyboardService = keyboardService;
            _previousKeyboardState = Keyboard.GetState();
        }

        public void Update()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.Escape))
                _keyboardService.ExitGame(_game);

            if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
                _keyboardService.MoveCamera(Direction.Up);

            if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
                _keyboardService.MoveCamera(Direction.Down);

            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
                _keyboardService.MoveCamera(Direction.Left);

            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
                _keyboardService.MoveCamera(Direction.Right);

            _previousKeyboardState = currentKeyboardState;
        }
    }
}
