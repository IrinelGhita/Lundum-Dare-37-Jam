using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Level
{
    class DrunkenWalkAlgorithm
    {
        #region Variables
        private static readonly int MAXIMUM_NUMBER_OF_STEPS = 25;

        private int[,]      m;
        private int         mSize;
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public DrunkenWalkAlgorithm(int [,] M, int MSize)
        {
            this.m      = M;
            this.mSize  = MSize;   
        }
        #endregion

        #region Public methods
        public void CreatePath()
        {
            Point curPoint = new Point(-1, -1);
            while (!ISValidPoint(curPoint))
            {
                curPoint = new Point(Game1.RND.Next(0, mSize), Game1.RND.Next(0, mSize));
            }

            int numberOfSteps = Game1.RND.Next(0, MAXIMUM_NUMBER_OF_STEPS);

            for (int i = 0; i < numberOfSteps; i++)
            {
                m[curPoint.X, curPoint.Y] = 1;
                curPoint = GetRandomDirection(curPoint);
            }

            LevelDebugger ld = new LevelDebugger(m, mSize);
            ld.PrintLevel();
        }

        public int[,] GetLevel()
        {
            return m;
        }
        #endregion

        #region Private methods
        private Point GetRandomDirection(Point Point)
        {
            Point newPoint  = new Point(Point.X, Point.Y);
            int direction   = Game1.RND.Next(0, 5);
            switch (direction)
            {
                case 1: // UP
                    newPoint.Y--;
                    break;

                case 2: // Down
                    newPoint.Y++;
                    break;

                case 3: // Left
                    newPoint.X--;
                    break;

                case 4: // Right
                    newPoint.X++;
                    break;

                default: // Left
                    newPoint.X--;
                    break;
            }

            if (!ISValidPoint(newPoint))
                return GetRandomDirection(Point);

            return newPoint;
        }

        private bool ISValidPoint(Point Point)
        {
            if (Point.X < 0 || Point.X >= mSize || Point.Y < 0 || Point.Y >= mSize)
                return false;

            if (m[Point.X, Point.Y] != 0)
                return false;

            return true;
        }
        #endregion
    }
}
