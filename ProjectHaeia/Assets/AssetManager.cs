using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using System;

namespace ProjectHaeia.Assets
{
    public class AssetManager
    {
        public TiledMap BasicMap { get; private set; }

        private readonly ProjectHaeia _game;               

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManager"/> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public AssetManager(ProjectHaeia game)
        {
            _game = game;
        }

        /// <summary>
        /// Initializes the asset manager.
        /// </summary>
        public void Initialize()
        {
            LoadContent();
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        private void LoadContent()
        {
            try
            {
                BasicMap = _game.Content.Load<TiledMap>("Maps/BasicMap");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString(), "Error while loading assets!");
                Environment.Exit(-1);
            }
        }
    }
}
