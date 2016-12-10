﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Entities
{
    class TestEntity : UpdatableAbstractEntity
    {
        #region Variables

        #endregion

        #region Constructors
        public TestEntity() : base()
        {
            this.spriteName = "lich_form";
            this.hitboxSize = new Vector2(32, 32);
        }
        #endregion

        #region Public methods
        public override void Update()
        {
            Vector2 newPos = position;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                newPos.Y += 5;

            position = newPos;
        }

        public override void OnCollision(AbstractEntity CollidedEntity)
        {
            base.OnCollision(CollidedEntity);

            Console.WriteLine("A dat tampitul ala cu viteza!");
        }
        #endregion

        #region Private methods
        #endregion
    }
}
