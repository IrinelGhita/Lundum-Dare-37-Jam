using LD37.Entities.Non_Tangible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities.Items
{
    class Curative:Item
    {
        #region Variables
        int healingAmount;
        #endregion

        #region Constructors
        public Curative(int healingAmount) : base(healingAmount<10 ? "Lesser healing potion" : healingAmount<30? "Healing potion" : "Greater healing potion","This potion heals for "+healingAmount+" hp",healingAmount*3)
        {
            this.healingAmount = healingAmount;
        }
        #endregion

        #region Private methods

        #endregion

        #region Public methods

        public override Effect Use()
        {
            return new Effect(EffectType.Cure,healingAmount);
        }

        #endregion
    }
}
