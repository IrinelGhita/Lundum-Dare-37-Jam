using LD37.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameLogic
{
    class CollisionManager
    {
        #region Variables
        private List<GameEntity> entityList;
        #endregion

        #region Constructors
        public CollisionManager(List<GameEntity> EntityList)
        {            
            this.entityList = EntityList;
        }
        #endregion

        #region Public methods
        public void CollideDetect()
        {
            // Every possible entity combination will happen only once
            for (int i = 0; i < entityList.Count - 1; i++)
            {
                for (int j = i + 1; j < entityList.Count; j++)
                {
                    // Check if the two hitboxes intersect
                    if (entityList[i].HitBox.Intersects(entityList[j].HitBox))
                    {
                        entityList[i].OnCollision(entityList[j]);
                        entityList[j].OnCollision(entityList[i]);
                    }
                }
            }
        }
        #endregion

        #region Private methods
        #endregion
    }
}
