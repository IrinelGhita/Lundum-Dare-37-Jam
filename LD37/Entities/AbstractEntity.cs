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
        #endregion

        #region Private methods
        #endregion
    }
}
