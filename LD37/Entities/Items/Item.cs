using LD37.Entities.Non_Tangible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    class Item :AbstractEntity
    {
        #region Properties

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Value { get; protected set; }

        #endregion

        #region Constructors
        public Item(string Name, string Description, int Value) : base()
        {
            this.Name = Name;
            this.Description = Description;
            this.Value = Value;
        }
        #endregion

        #region Private methods

        #endregion

        #region Public methods

        public virtual Effect Use()
        {

            return new Effect(EffectType.None,0);
        }

        #endregion
    }
}
