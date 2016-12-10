using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities.Non_Tangible
{
    class Effect
    {
        #region Variables
        #endregion

        #region Properties
        public String Description { get; protected set; }
        #endregion

        #region Constructors
        public Effect(GameEntity entity)
        {
            Description = "The item had no effect";
        }
        #endregion

        #region Public methods
        #endregion

        #region Private methods
        #endregion
    }
}
