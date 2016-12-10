using LD37.Entities.Non_Tangible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities.Items
{
    class Curative:Item
    {
        #region Properties

        #endregion

        #region Constructors
        public Curative() : base()
        {
        }
        #endregion

        #region Private methods

        #endregion

        #region Public methods

        public override Effect Use(GameEntity entity)
        {

            return new Effect(entity);
        }

        #endregion
    }
}
