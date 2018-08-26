using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectHaeia.Camera
{
    public interface ICameraView
    {
        Matrix View { get; }
        Rectangle VisibleArea { get; }
    }
}
