using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    abstract class GameEntity : AbstractEntity
    {

        #region Variables
        #endregion

        #region Constructors
        public GameEntity():base()
        {
        }
        #endregion

        #region Public methods
        public virtual void OnCollision(AbstractEntity CollidedEntity)
        {

        }
        #endregion

        #region Private methods
        #endregion
    }
}
