using LD37.Entities.Non_Tangible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    abstract class Item :AbstractEntity
    {
        #region Properties

        public String Name { get; set; }
        public String Description { get; set; }
        public String Value { get; set; }

        #endregion

        #region Constructors
        public Item() : base()
        {
        }
        #endregion

        #region Private methods

        #endregion

        #region Public methods

        public virtual Effect Use(GameEntity entity)
        {

            return new Effect(entity);
        }

        #endregion
    }
}
