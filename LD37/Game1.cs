﻿using LD37.Entities;
using LD37.GameLogic;
using LD37.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LD37
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        #region Variables
        public static Random RND = new Random();

        GraphicsDeviceManager   graphics;
        SpriteBatch             spriteBatch;

        // Singletons
        SpriteManager       spriteManager;
        CollisionManager    collisionManager;
        EntityManager       entityManager;
        #endregion


        public Game1()
        {           
            graphics                                = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth       = 960;
            graphics.PreferredBackBufferHeight      = 960;

            Content.RootDirectory                   = "Content";            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here            

            spriteManager   = SpriteManager.Instance;
            entityManager   = EntityManager.Instance;


            entityManager.GameEntityLists.Add(new TestEntity());
            entityManager.GameEntityLists.Add(new TestEntity2());

            new Level.LevelEditor().GenerateLevel(25);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here                   
            spriteManager.Load(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            collisionManager = new CollisionManager(entityManager.GameEntityLists);
            collisionManager.CollideDetect();

            for (int i = 0; i < entityManager.GameEntityLists.Count; i++)
            {
                entityManager.GameEntityLists[i].Update();
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            // Draw all the entities
            for (int i = 0; i < entityManager.GameEntityLists.Count; i++)
            {
                spriteBatch.Draw(
                    spriteManager.GetSprite(entityManager.GameEntityLists[i].SpriteName), 
                    entityManager.GameEntityLists[i].Position, 
                    Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
