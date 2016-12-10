using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Level
{
    class LeeAlgorithm
    {
        #region Veriables
        private int[,]  m;
        private int     mSize;
        private Point   startPoint, endPoint;

        private bool    algorithmRunning = true;        
        #endregion

        #region Proeprties
        #endregion

        #region Constructors
        public LeeAlgorithm(int[,] M, int MSize, Point StartPoint, Point EndPoint)
        {
            this.m          = M;
            this.mSize      = MSize;
            this.startPoint = StartPoint;
            this.endPoint   = EndPoint;

            m[StartPoint.X, StartPoint.Y]   = 1;
            m[EndPoint.X,   EndPoint.Y  ]   = -1;
        }
        #endregion

        #region Public methods
        public void FindPath()
        {
            AssignValues(startPoint.X, startPoint.Y, 2);

            int value = 2;

            while (algorithmRunning && value <= mSize)
            {
                for (int i = 0; i < mSize; i++)
                {
                    for (int j = 0; j < mSize; j++)
                    {
                        if (m[i, j] == value)
                        {
                            AssignValues(i, j, value + 1);
                        }
                    }
                }


                value++;
            }


                                 
        }     
        
        public int[,] GetLevelLayout()
        {
            int value           = m[endPoint.X, endPoint.Y];       
            while (value > 0)
            {
                for (int i = 0; i < mSize; i++)
                {
                    for (int j = 0; j < mSize; j++)
                    {
                        if (m[i, j] == value)
                        {
                            m[i, j] = -2;
                            value--;
                        }                                          
                    }
                }
            }

            ResetM();

            ConsolePrintM();
            return m;
        }
        #endregion

        #region Private methods
        // Recursive function
        private void BuildWall(int X, int Y, int Value)
        {
            m[X, Y] = -2;

            if (Value == 0)
                return;

                    if (NotOutOfBounds(X - 1, Y) && m[X - 1, Y] == Value - 1)
                BuildWall(X - 1, Y, Value - 1);
            else    if (NotOutOfBounds(X + 1, Y) && m[X + 1, Y] == Value - 1)
                BuildWall(X + 1, Y, Value - 1);
            else    if (NotOutOfBounds(X, Y - 1) && m[X, Y - 1] == Value - 1)
                BuildWall(X, Y - 1, Value - 1);
            else    if (NotOutOfBounds(X, Y + 1) && m[X, Y + 1] == Value - 1)
                BuildWall(X, Y + 1, Value - 1);
        }

        // Checks if we can assign values to the elements next to the location
        private void AssignValues(int X, int Y, int Value)
        {
            if (IsValid(X - 1, Y))
                Mark(X - 1, Y, Value);
            if (IsValid(X + 1, Y))
                Mark(X + 1, Y, Value);
            if (IsValid(X, Y - 1))
                Mark(X, Y -1, Value);
            if (IsValid(X, Y + 1))
                Mark(X, Y + 1, Value);
        }

        
        private void Mark(int X, int Y, int Value)
        {
            m[X, Y] = Value;

            if (m[X, Y] == -1)
            {
                algorithmRunning = false;
                return;
            }                       
        }

        private bool IsValid(int X, int Y)
        {
            return  NotOutOfBounds(X, Y) &&
                    (m[X, Y] == 0 || m[X, Y] == -1);
        }

        private bool NotOutOfBounds(int X, int Y)
        {
            return X >= 0 && X < mSize &&
                   Y >= 0 && Y < mSize;
        }

        private void ResetM()
        {
            for (int i = 0; i < mSize; i++)
                for (int j = 0; j < mSize; j++)
                    if (m[i, j] != -2)
                        m[i, j] = 0;

        }

        private void ConsolePrintM()
        {
            for (int i = 0; i < mSize; i++)
            {
                for (int j = 0; j < mSize; j++)
                {
                    Console.Write(m[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
        #endregion
    }
}
