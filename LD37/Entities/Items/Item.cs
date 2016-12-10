using LD37.Entities.Non_Tangible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    abstract class Item :AbstractEntity
    {
        #region Variables

        public String name { get; set; }
        public String description { get; set; }
        public String value { get; set; }

        #endregion

        #region Constructors
        public Item() : base()
        {
        }
        #endregion

        #region Private methods

        #endregion

        #region Public methods

        public virtual Effect Use(AbstractEntity entity)
        {

            return new Effect();
        }

        #endregion
    }
}
