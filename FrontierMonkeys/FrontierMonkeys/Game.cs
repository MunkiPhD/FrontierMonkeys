#region File Description
//-----------------------------------------------------------------------------
// Game.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using GameStateManagement;
using Microsoft.Xna.Framework;

namespace FrontierMonkeys {
    /// <summary>
    /// Sample showing how to manage different game states, with transitions
    /// between menu screens, a loading screen, the game itself, and a pause
    /// menu. This main game class is extremely simple: all the interesting
    /// stuff happens in the ScreenManager component.
    /// </summary>
    public class FrontierMonkeys : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        ScreenManager screenManager;
        ScreenFactory screenFactory;

        /// <summary>
        /// The main game constructor.
        /// </summary>
        public FrontierMonkeys() {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            TargetElapsedTime = TimeSpan.FromTicks(333333);


            // Create the screen factory and add it to the Services
            screenFactory = new ScreenFactory();
            Services.AddService(typeof(IScreenFactory), screenFactory);

            // Create the screen manager component.
            screenManager = new ScreenManager(this);
            Components.Add(screenManager);

            // On Windows and Xbox we just add the initial screens
            AddInitialScreens();
        }

        private void AddInitialScreens() {
            // Activate the first screens.
            screenManager.AddScreen(new BackgroundScreen(), null);

            // We have different menus for Windows Phone to take advantage of the touch interface
            screenManager.AddScreen(new MainMenuScreen(), null);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime) {
            graphics.GraphicsDevice.Clear(Color.Black);

            // The real drawing happens inside the screen manager component.
            base.Draw(gameTime);
        }

    }
}
//using System.Collections.Generic;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using FrontierMonkeys.entities;

//namespace FrontierMonkeys {
//    /// <summary>
//    /// This is the main type for your game
//    /// </summary>
//    public class Game : Microsoft.Xna.Framework.Game {
//        GraphicsDeviceManager graphics;
//        SpriteBatch spriteBatch;
//        List<Entity> entityList = new List<Entity>();
//        Player player;
//        InputHandler input;

//        public Game() {
//            graphics = new GraphicsDeviceManager(this);
//            Content.RootDirectory = "Content";
//        }

//        /// <summary>
//        /// Allows the game to perform any initialization it needs to before starting to run.
//        /// This is where it can query for any required services and load any non-graphic
//        /// related content.  Calling base.Initialize will enumerate through any components
//        /// and initialize them as well.
//        /// </summary>
//        protected override void Initialize() {
//            // TODO: Add your initialization logic here
//            input = new InputHandler();
//            player = new Player(this, input);

//            entityList.Add(player);


//            base.Initialize();
//        }

//        /// <summary>
//        /// LoadContent will be called once per game and is the place to load
//        /// all of your content.
//        /// </summary>
//        protected override void LoadContent() {
//            // Create a new SpriteBatch, which can be used to draw textures.
//            spriteBatch = new SpriteBatch(GraphicsDevice);

//            // TODO: use this.Content to load your game content here
//        }

//        /// <summary>
//        /// UnloadContent will be called once per game and is the place to unload
//        /// all content.
//        /// </summary>
//        protected override void UnloadContent() {
//            // TODO: Unload any non ContentManager content here
//        }

//        /// <summary>
//        /// Allows the game to run logic such as updating the world,
//        /// checking for collisions, gathering input, and playing audio.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Update(GameTime gameTime) {
//            // Allows the game to exit
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
//                this.Exit();

//            // TODO: Add your update logic here

//            //invoke the update method for all the entities
//            foreach (Entity item in entityList) {
//                item.Update(gameTime);
//            }

//            //remove all the entities that are not active
//            entityList.RemoveAll(x => x.isActive == false);


//            //update the base
//            base.Update(gameTime);
//        }

//        /// <summary>
//        /// This is called when the game should draw itself.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Draw(GameTime gameTime) {
//            GraphicsDevice.Clear(Color.CornflowerBlue);
//            // TODO: Add your drawing code here


//            //start the spritebatch rendering
//            spriteBatch.Begin();

//            //update the inputs before updating the entities
//            input.UpdateStates();

//            //draw all the entities
//            foreach (Entity item in entityList) {
//                item.Draw(spriteBatch);
//            }

//            //end the spritebatch rendering
//            spriteBatch.End();


//            //draw the base
//            base.Draw(gameTime);
//        }
//    }
//}
