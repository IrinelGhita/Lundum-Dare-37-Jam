using LD37.Entities.Non_Tangible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities.Items
{

    class Armour : Item
    {
        #region Properties
        public int Resistance { get; protected set; }
        #endregion

        #region Constructors
        public Armour(string Name, string Description, int Value, int Resistance, Equipable Slot, bool isPlaceholder=false) : base(Name, Description, Value,Slot)
        {
            this.Resistance = Resistance;
            IsPlaceholder = isPlaceholder;
        }
        #endregion

        #region Private methods

        #endregion

        #region Public methods

        public override Effect Use()
        {

            return new Effect(EffectType.Equip, 0);
        }

        #endregion
    }
}
