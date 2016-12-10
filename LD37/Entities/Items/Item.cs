using LD37.Entities.Non_Tangible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    class Item :AbstractEntity
    {
        public enum Equipable { Headgear, Chest, Boots, Shield, Gloves, Cloak, MeleeWeapon, Ranged, None };

        #region Properties

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Value { get; protected set; }
        public bool IsPlaceholder { get; protected set; }
        public Equipable EquipableSlot { get; protected set; }

        #endregion

        #region Constructors
        public Item(string Name, string Description, int Value, Equipable EquipableSlot=Equipable.None) : base()
        {
            this.Name = Name;
            this.Description = Description;
            this.Value = Value;
            this.EquipableSlot = EquipableSlot;
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
