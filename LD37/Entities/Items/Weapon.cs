using LD37.Entities.Non_Tangible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities.Items
{
    enum WeaponType { Melee, Ranged};

    class Weapon : Item 
    {
        #region Properties
        public int Damage { get; protected set; }
        public WeaponType Type { get; protected set; }
        #endregion

        #region Constructors
        public Weapon(string Name, string Description, int Value, int Damage, WeaponType Type) : base(Name, Description, Value)
        {
            this.Damage = Damage;
            this.Type = Type;
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
