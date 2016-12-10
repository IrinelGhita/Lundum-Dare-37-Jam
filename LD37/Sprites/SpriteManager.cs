using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Sprites
{
    class SpriteManager
    {
        #region Singleton logic
        private static readonly SpriteManager instance = new SpriteManager();

        static SpriteManager()
        {

        }

        public static SpriteManager Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Variables
        private Dictionary<string, Texture2D> spriteDictionary;
        #endregion

        private SpriteManager()
        {
            
        }

        #region Public methods
        public Texture2D GetSprite(string SpriteName)
        {
            return spriteDictionary[SpriteName];
        }

        public void Load(ContentManager Content)
        {
            spriteDictionary = SpriteLoader.Instance.LoadSprites(Content);
        }
        #endregion


        #region Private methods
        #endregion
    }
}
