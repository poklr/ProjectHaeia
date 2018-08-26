using Microsoft.Xna.Framework;

namespace ProjectHaeia.Camera
{
    public interface ICameraManager
    {
        Matrix View { get; }
        Vector2 Position { get; }
        void MoveCamera(Vector2 position);
        void ZoomIn();
        void ZoomOut();
    }
}
