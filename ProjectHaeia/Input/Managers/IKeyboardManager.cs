using Microsoft.Xna.Framework;
using System;

namespace ProjectHaeia.Input.Managers
{
    public interface IKeyboardManager
    {
        void ExitGame();
        void MoveCamera(Direction direction);
        event EventHandler ExitKeyPressed;
    }
}
