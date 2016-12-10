using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    class TestEntity2 : GameEntity
    {
        #region Variables

        #endregion

        #region Constructors
        public TestEntity2() : base("statue",100, 10)
        {
            this.SpriteName = "statue_form";
            position.Y = 100;
        }
        #endregion

        #region Public methods
        public override void Update()
        {
        }

        public override void OnCollision(AbstractEntity CollidedEntity)
        {
            Console.WriteLine("'Tuti gatu matii");
            base.OnCollision(CollidedEntity);
        }
        #endregion

        #region Private methods
        #endregion
    }
}
