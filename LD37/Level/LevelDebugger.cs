using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Level
{
    class LevelDebugger
    {
        #region Variables
        private int[,]  level;
        private int     levelSize;
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public LevelDebugger(int[,] Level, int LevelSize)
        {
            this.level     = Level;
            this.levelSize = LevelSize;
        }
        #endregion

        #region Public methods
        public void PrintLevel()
        {
            Console.WriteLine();
            for (int i = 0; i < levelSize; i++)
            {
                for (int j = 0; j < levelSize; j++)
                    Console.Write(level[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion

        #region Private methods
        #endregion
    }
}
