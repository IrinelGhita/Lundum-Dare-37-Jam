using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities.Non_Tangible
{
    enum EffectType { None, Cure, InstantDamage, Equip};

    class Effect
    {
        
        #region Variables
        #endregion

        #region Properties
        public String Description { get; protected set; }
        #endregion

        #region Constructors
        public Effect(EffectType effect, int intensity)
        {
            switch(effect)
            {
                case EffectType.Cure:
                    {
                        Description = "+" + intensity + " HP";
                        break;
                    }
                case EffectType.InstantDamage:
                    {
                        Description = intensity + " damage";
                        break;
                    }
                case EffectType.None:
                    {
                        Description = "The item had no effect";
                        break;
                    }
            }                       
        }
        #endregion

        #region Public methods
        #endregion

        #region Private methods
        #endregion
    }
}
