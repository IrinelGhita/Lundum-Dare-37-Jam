using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Level
{
    class LevelEditor
    {
        #region Veriables
        private readonly int size = 30;

        private int[,] levelLayout;
        #endregion

        #region Proeprties
        #endregion

        #region Constructors
        public LevelEditor()
        {
            InitLevelLayout();
        }
        #endregion

        #region Public methods
        // Complexity = number of different wall routes        
        public void GenerateLevel(int Complexity)
        {
            for (var i = 0; i < Complexity; i++)
            {
                DrunkenWalkAlgorithm drunk = new DrunkenWalkAlgorithm(levelLayout, size);
                drunk.CreatePath();
                levelLayout = drunk.GetLevel();
            }
        }
        #endregion

        #region Private methods
        // Initializez the layout of the level
        private void InitLevelLayout()
        {
            levelLayout = new int[size, size];
        }
        #endregion
    }
}
