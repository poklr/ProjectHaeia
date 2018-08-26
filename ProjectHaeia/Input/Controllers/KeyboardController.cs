using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectHaeia.Input.Managers;
using System;

namespace ProjectHaeia.Input.Controllers
{
    public class KeyboardController
    {
        private readonly IKeyboardManager _keyboardManager;

        private KeyboardState _previousKeyboardState;

        public KeyboardController(IKeyboardManager keyboardManager)
        {
            _keyboardManager = keyboardManager;
            _previousKeyboardState = Keyboard.GetState();
        }

        public void Update()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.Escape))
                _keyboardManager.ExitGame();

            if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
                _keyboardManager.MoveCamera(Direction.Up);

            if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
                _keyboardManager.MoveCamera(Direction.Down);

            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
                _keyboardManager.MoveCamera(Direction.Left);

            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
                _keyboardManager.MoveCamera(Direction.Right);

            _previousKeyboardState = currentKeyboardState;
        }
    }
}
