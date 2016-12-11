using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Level
{
    enum Direction { Top,Right,Bottom,Left};

    class CVector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CVector2(int x,int y)
        {
            X = x;
            Y = y;
        }
    }

    class NotAwfullyElaborateAlgorithm
    {
        #region Variables

        private int[,]      m;
        private int         mSize;
        private int maxCoridorLength;
        private int maxRoomSize;
        //private int coridorToRoomRatio;
        private int ratioAcceptableDeviation;
        private int acceptableWallCount;
        private int remainingCells;

        private int roomCells = 0,corridorCells=1,totalCellsOccupied=1;
        private bool lastBlockIsRoom = true;

        Random randyTheRandomNumber;
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public NotAwfullyElaborateAlgorithm(int MSize=30, int maxCoridorLength=6,int maxRoomSize=15,int ratioAcceptableDeviation=8,int acceptableWallCount=400)
        {
            mSize = MSize;
            m = new int[MSize, MSize];
            this.maxCoridorLength = maxCoridorLength;
            this.maxRoomSize = maxRoomSize;
            this.ratioAcceptableDeviation = ratioAcceptableDeviation;
            this.acceptableWallCount = acceptableWallCount;

            randyTheRandomNumber = new Random();
        }
        #endregion

        #region Public methods
        public int[,] CreatePath()
        {
            remainingCells = mSize * mSize - 1;
            m[0, 0] = 1;

            CVector2 currentPos = new CVector2(0, 0);

            while(remainingCells>acceptableWallCount)
            {
                currentPos = buildBlock(currentPos);
            }
            return m;
        }
        #endregion

        #region Private methods

        private CVector2 buildBlock(CVector2 pos)
        {
            try
            {
                Direction dir = CheckAvailableCells(pos);

                if (lastBlockIsRoom)
                {
                    buildCorridor(pos, dir);
                }
                else
                {
                    int cellDiff = corridorCells - roomCells;
                    if (cellDiff > ratioAcceptableDeviation)
                    {
                        buildRoom(pos, dir);
                    }
                    else if (cellDiff < -ratioAcceptableDeviation)
                    {
                        buildCorridor(pos, dir);
                    }
                    else if (randyTheRandomNumber.Next(2) == 0)
                    {
                        buildCorridor(pos, dir);
                    }
                    else
                    {
                        buildRoom(pos, dir);
                    }

                }
            }
            catch
            {
                //Force EXIT - Temporary
                remainingCells = 0;
            }
            

            return pos;
        }

        private Direction CheckAvailableCells(CVector2 pos)
        {
            Direction preferedDir = (Direction)randyTheRandomNumber.Next(4);

            if(CheckStartCell(preferedDir,pos))
            {
                return preferedDir;
            }
            else if (CheckStartCell(preferedDir+1, pos))
            {
                return preferedDir+1;
            }
            else if (CheckStartCell(preferedDir-1, pos))
            {
                return preferedDir-1;
            }
            else if (CheckStartCell(preferedDir+2, pos))
            {
                return preferedDir+2;
            }
            else
            {
                throw new Exception();
            }

        }

        private bool CheckStartCell(Direction dir, CVector2 pos)
        {
            switch (dir)
            {
                case Direction.Top:
                    {
                        return pos.Y - 2 > 0 && m[pos.X, pos.Y - 1] == 0 && m[pos.X, pos.Y-2] == 0;
                    }
                case Direction.Left:
                    {
                        return pos.X - 2 > 0 && m[pos.X -1, pos.Y] == 0 && m[pos.X - 2, pos.Y] == 0;
                    }
                case Direction.Right:
                    {
                        return pos.X + 1 < mSize && m[pos.X + 1, pos.Y] == 0 && m[pos.X + 2, pos.Y] == 0;
                    }
                case Direction.Bottom:
                    {
                        return pos.Y + 1 < mSize && m[pos.X, pos.Y + 1] == 0 && m[pos.X, pos.Y+2] == 0;
                    }
            }
            return false;
        }

        private CVector2 buildCorridor(CVector2 pos, Direction direction)
        {
            int lenght = randyTheRandomNumber.Next(maxCoridorLength) + 1;



            return pos;
        }

        private CVector2 buildRoom(CVector2 pos, Direction direction)
        {
            int size = randyTheRandomNumber.Next(maxRoomSize-3) + 4;

            return pos;
        }

        #endregion
    }
}
