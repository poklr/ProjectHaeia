using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectHaeia.Enums;

namespace ProjectHaeia.Input.Managers
{
    public interface IMouseManager
    {
        void ButtonPressed(MouseState mouseState, MouseButton button);
        Vector2 GetWorldMousePosition(MouseState mouseState);
        void ZoomIn();
        void ZoomOut();
    }
}
