using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace ProjectHaeia.Services
{
    public interface ICameraService
    {
        Vector2 Position { get; }
        Matrix View { get; }
        Rectangle VisibleArea { get; }

        void MoveCamera(Vector2 position);
        void ZoomIn();
        void ZoomOut();
    }

    public class CameraService : ICameraService
    {
        public Vector2 Position { get; private set; }
        public Matrix View { get; private set; }
        public Rectangle VisibleArea { get; private set; }

        private readonly float SCALE = 0.025f; // TODO: Get this from a config file (player/world)
        private readonly float MAX_ZOOM = 2f; // TODO: Get this from a config file (player/world)
        private readonly float MIN_ZOOM = 0.5f; // TODO: Get this from a config file (player/world)

        private readonly ProjectHaeia _game;
        private Rectangle _viewport;
        private float _zoom;

        public CameraService(ProjectHaeia game)
        {
            _game = game;
            _viewport = _game.GraphicsDevice.Viewport.Bounds;
            _zoom = 1.0f; // TODO: Get this from a config file (player/world)?

            //Position = new Vector2(200f, 200f); 
            Position = Vector2.Zero;

            UpdateView();
        }

        public void MoveCamera(Vector2 position)
        {
            Position = position;

            UpdateView();
        }

        public void ZoomIn()
        {
            _zoom += SCALE;

            if (_zoom >= MAX_ZOOM) 
                _zoom = MAX_ZOOM;

            UpdateView();
        }

        public void ZoomOut()
        {
            _zoom -= SCALE;

            if (_zoom < MIN_ZOOM)
                _zoom = MIN_ZOOM;

            UpdateView();
        }

        private void UpdateView()
        {
            View = Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                   Matrix.CreateScale(_zoom) *
                   Matrix.CreateTranslation(new Vector3(_viewport.Width / 2.0f, _viewport.Height / 2.0f, 0));

            UpdateVisibleArea();
        }

        private void UpdateVisibleArea()
        {
            Vector2 viewportWorldPosition = Vector2.Transform(Vector2.Zero, Matrix.Invert(View));

            VisibleArea = new Rectangle(
                (int)viewportWorldPosition.X, 
                (int)viewportWorldPosition.Y, 
                (int)(_viewport.Width / _zoom), 
                (int)(_viewport.Height / _zoom));
        }
    }
}
