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
        public      Vector2     hitboxSize      { get; set; }
        public      String      spriteName      { get; set; }
        public      String      entityType      { get; set; }

        public      Rectangle   hitbox          { get { return CalculateHitbox(); }}        
        #endregion

        #region Constructors
        public AbstractEntity()
        {
            position    = new Vector2(0, 0);
            hitboxSize  = new Vector2(50, 50);            
        }        
        #endregion

        #region Public methods
        public virtual bool CanCollide(AbstractEntity CollidedEntity)
        {
            return true;
        }

        public virtual void OnCollision(AbstractEntity CollidedEntity)
        {

        }
        #endregion

        #region Private methods
        private Rectangle CalculateHitbox()
        {
            return new Rectangle(position.ToPoint(), hitboxSize.ToPoint());
        }
        #endregion
    }
}
