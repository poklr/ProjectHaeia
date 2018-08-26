using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using ProjectHaeia.Assets;
using ProjectHaeia.Camera;
using ProjectHaeia.Input;
using ProjectHaeia.Input.Controllers;
using ProjectHaeia.Input.Managers;
using System;

namespace ProjectHaeia
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ProjectHaeia : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        private TiledMap _basicMap;
        private TiledMapRenderer _mapRenderer;

        private MouseController _mouseController;
        private KeyboardController _keyboardController;

        private ICameraView _camera;

        private IContainer _container;

        public ProjectHaeia()
        {
            _graphics = new GraphicsDeviceManager(this);
            Window.AllowUserResizing = true;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Dependency Injection setup.
        /// </summary>
        private void ConfigureServices()
        {
            var builder = new ContainerBuilder();

            // Monogame 
            Content.RootDirectory = "Content";
            builder.RegisterInstance(Content).AsSelf();
            builder.RegisterInstance(new SpriteBatch(GraphicsDevice)).AsSelf();
            builder.RegisterInstance(GraphicsDevice).AsSelf();

            // Managers
            builder.RegisterAssemblyTypes(typeof(ProjectHaeia).Assembly)
                .Where(t => t.Name.EndsWith("Manager"))
                .AsImplementedInterfaces()
                .SingleInstance();

            // Controllers
            builder.RegisterAssemblyTypes(typeof(ProjectHaeia).Assembly)
                .Where(t => t.Name.EndsWith("Controller"))
                .SingleInstance();

            // Other
            builder.RegisterType<MouseController>().As<IMousePosition>()
                .AsImplementedInterfaces()
                .SingleInstance();

            _container = builder.Build();
        }

        protected override void LoadContent()
        {
            ConfigureServices();

            _keyboardController = _container.Resolve<KeyboardController>();
            _mouseController = _container.Resolve<MouseController>();
            _camera = _container.Resolve<ICameraView>();
            _spriteBatch = _container.Resolve<SpriteBatch>();

            // Game exit event handler
            var keyboardManager = _container.Resolve<IKeyboardManager>();
            keyboardManager.ExitKeyPressed += HandleExitGame;

            // Map
            _basicMap = _container.Resolve<IAssetManager>().BasicMap;
            _mapRenderer = new TiledMapRenderer(_graphics.GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            _mapRenderer.Update(_basicMap, gameTime);
            _mouseController.Update();
            _keyboardController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _camera.View);
            _mapRenderer.Draw(_basicMap, _camera.View);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void HandleExitGame(object sender, EventArgs eventArgs)
        {
            Exit();
        }
    }
}
