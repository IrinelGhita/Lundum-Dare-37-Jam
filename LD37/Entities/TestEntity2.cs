using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    class TestEntity2 : UpdatableAbstractEntity
    {
        #region Variables

        #endregion

        #region Constructors
        public TestEntity2() : base()
        {
            this.spriteName = "bat_form";
            this.hitboxSize = new Vector2(32, 32);
        }

        public TestEntity2(Vector2 Position) : this()
        {
            this.position = Position;
        }
        #endregion

        #region Public methods
        public override void Update()
        {
        }

        public override void OnCollision(AbstractEntity CollidedEntity)
        {
            base.OnCollision(CollidedEntity);

            Console.WriteLine("'Tuti gatu matii!");
        }
        #endregion

        #region Private methods
        #endregion
    }
}
