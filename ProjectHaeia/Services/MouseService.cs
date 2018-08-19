using Microsoft.Xna.Framework;
using ProjectHaeia.Enums;
using System.Diagnostics;

namespace ProjectHaeia.Services
{
    public interface IMouseService
    {
        void ButtonPressed(Vector2 position, MouseButton button);
        void ZoomIn();
        void ZoomOut();
    }

    // TODO: turn into a thread/task?
    public class MouseService : IMouseService
    {
        private readonly ICameraService _cameraService;

        public MouseService(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void ButtonPressed(Vector2 position, MouseButton button)
        {
            Debug.WriteLine("Position: " + position + " - Mousebutton: " + button);
        }

        public void ZoomIn()
        {
            _cameraService.ZoomIn();
        }

        public void ZoomOut()
        {
            _cameraService.ZoomOut();
        }
    }
}
