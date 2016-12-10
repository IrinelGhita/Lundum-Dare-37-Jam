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
        private List<UpdatableAbstractEntity> entityList;
        #endregion

        #region Constructors
        public CollisionManager(List<UpdatableAbstractEntity> EntityList)
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
                    if (entityList[i].hitbox.Intersects(entityList[j].hitbox))
                    {
                        // Check if both entities can collide with each other
                        if (entityList[i].CanCollide(entityList[j]) &&
                            entityList[j].CanCollide(entityList[i]))
                        {
                            // Call the OnCollision method of both entities
                            entityList[i].OnCollision(entityList[j]);
                            entityList[j].OnCollision(entityList[i]);
                        }
                    }
                }
            }
        }
        #endregion

        #region Private methods
        #endregion
    }
}
