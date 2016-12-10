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
        Vector2     position;
        Rectangle   hitBox;
        #endregion

        #region Properties
        public Vector2      Position        { get { return position; } set { position = value; } }
        public String       SpriteName      { get; set; }
        public String       EntityType      { get; set; }
        public Vector2      HitBoxSize      { get; set; }
        public Rectangle    HitBox          { get { return GetHitBox(); } set { hitBox = value; } }        
        #endregion

        #region Constructors
        public AbstractEntity()
        {
            HitBoxSize  = new Vector2(32, 32);
            hitBox      = new Rectangle(position.ToPoint(), HitBoxSize.ToPoint());
        }
        #endregion

        #region Public methods
        public virtual void Update()
        {

        }
       
        #endregion

        #region Private methods
        private Rectangle GetHitBox()
        {
            hitBox.Location = position.ToPoint();
            return hitBox;
        }
        #endregion
    }
}
