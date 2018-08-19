using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using ProjectHaeia.Assets;
using ProjectHaeia.Input;
using ProjectHaeia.Services;

namespace ProjectHaeia
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ProjectHaeia : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;

        private TiledMap _basicMap;
        private TiledMapRenderer _mapRenderer;

        
        private MouseController _mouseController;
        private KeyboardController _keyboardController;
        private ICameraService _cameraService;

        public ProjectHaeia()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
                        
            {
                // TODO: implement dependency injection
                _cameraService = new CameraService(this);

                var mouseService = new MouseService(_cameraService);
                _mouseController = new MouseController(mouseService, _cameraService);
                var keyboardService = new KeyboardService(_cameraService);
                _keyboardController = new KeyboardController(this, keyboardService);
            }

            // Map
            var assetManager = new AssetManager(this);
            assetManager.Initialize();
            _basicMap = assetManager.BasicMap;
            _mapRenderer = new TiledMapRenderer(graphics.GraphicsDevice);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _mapRenderer.Update(_basicMap, gameTime);
            _mouseController.Update();
            _keyboardController.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _cameraService.View);
            _mapRenderer.Draw(_basicMap, _cameraService.View);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
