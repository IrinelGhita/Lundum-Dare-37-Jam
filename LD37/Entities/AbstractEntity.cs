using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    abstract class AbstractEntity
    {
        #region Variables
        public      Vector2     position        { get; set; }
        public      String      spriteName      { get; set; }
        public      String      entityType      { get; set; }
        public      Rectangle   hitBox          { get; set; }        
        #endregion

        #region Constructors
        public AbstractEntity()
        {

        }
        #endregion

        #region Public methods
        public void Update()
        {

        }

        public bool CanCollide(AbstractEntity CollidedEntity)
        {
            return true;
        }

        public void OnCollision(AbstractEntity CollidedEntity)
        {

        }
        #endregion

        #region Private methods
        #endregion
    }
}
