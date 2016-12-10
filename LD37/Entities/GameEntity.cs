using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    abstract class GameEntity : AbstractEntity
    {

        #region Variables
        protected int currentHP, maxHP, damage;
        #endregion

        #region Properties
        public int HP { get { return currentHP; } }
        public int MaxHP { get { return maxHP; } }
        public string Name { get; protected set; }
        public int Damage { get { return damage; } }
        #endregion

        #region Constructors
        public GameEntity(string Name,int maxHP, int damage) : base()
        {
            this.damage = damage;
            this.maxHP = maxHP;
            currentHP = maxHP;
            this.Name = Name;
        }
        #endregion

        #region Public methods
        public virtual void OnCollision(AbstractEntity CollidedEntity)
        {

        }
        #endregion

        #region Private methods
        #endregion
    }
}
