using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LD37.Sprites
{
    // Loads all the sprites, then returns a dictionary of sprites
    public sealed class SpriteLoader
    {
        #region Singleton logic

        private static readonly SpriteLoader instance = new SpriteLoader();

        static SpriteLoader()
        {

        }        

        public static SpriteLoader Instance
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

        // Real constructor
        private SpriteLoader()
        {
            spriteDictionary = new Dictionary<string, Texture2D>();
        }

        #region Public Methods
        public Dictionary<string, Texture2D> LoadSprites(ContentManager Content)
        {
            LoadAllSpritesFromFolder(Content);

            return spriteDictionary;
        }
        #endregion

        #region Private Methods
        private void LoadAllSpritesFromFolder(ContentManager Content)
        {                                    
            // Execute for each file in the Content\PNG\ folder
            foreach (string path in Directory.GetFiles(Content.RootDirectory + "/PNG/"))
            {
                // Execute only for .png files
                if (Path.GetExtension(path) == ".png")
                {
                    // Log the loading to the console
                    Console.WriteLine("Loading sprite {0}", path);
                    // Add the sprite to the dictionary
                    spriteDictionary.Add(GetFileName(path), Content.Load<Texture2D>("PNG/" + GetFileName(path)));
                }
            }
        }

        private string GetFileName(String FullPath)
        {            
            return Path.GetFileNameWithoutExtension(FullPath);
        }
        #endregion
    }
}
