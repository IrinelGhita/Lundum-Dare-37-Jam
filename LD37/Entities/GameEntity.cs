using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    abstract class GameEntity : AbstractEntity
    {

        #region Variables
        int currentHP, maxHP, damage;
        #endregion

        #region Properties
        public int HP { get { return currentHP; } }
        public int MaxHP { get { return maxHP; } }
        public String Name { get; set; }
        public int Damage { get { return damage; } }
        #endregion

        #region Constructors
        public GameEntity(int maxHP, int damage) : base()
        {
            this.damage = damage;
            this.maxHP = maxHP;
            currentHP = maxHP;
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
