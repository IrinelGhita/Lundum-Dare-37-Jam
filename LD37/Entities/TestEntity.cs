using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    class TestEntity : GameEntity
    {
        #region Variables

        #endregion

        #region Constructors
        public TestEntity() : base("lich",100, 10)
        {
            this.SpriteName = "lich_form";
        }
        #endregion

        #region Public methods
        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                position.Y += 5;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                position.Y -= 5;
        }

        public override void OnCollision(AbstractEntity CollidedEntity)
        {
            Console.WriteLine("A dat tampitul ala cu viteza!");
            base.OnCollision(CollidedEntity);
        }
        #endregion

        #region Private methods
        #endregion
    }
}
