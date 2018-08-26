using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using System;
using Microsoft.Xna.Framework.Content;

namespace ProjectHaeia.Assets
{
    public class AssetManager : IAssetManager
    {
        public TiledMap BasicMap { get; private set; }

        private readonly ContentManager _contentManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManager"/> class.
        /// </summary>
        /// <param name="contentManager">The content manager.</param>
        public AssetManager(ContentManager contentManager)
        {
            _contentManager = contentManager;

            LoadContent();
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        private void LoadContent()
        {
            try
            {
                BasicMap = _contentManager.Load<TiledMap>("Maps/BasicMap");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString(), "Error while loading assets!");
                Environment.Exit(-1);
            }
        }
    }
}
