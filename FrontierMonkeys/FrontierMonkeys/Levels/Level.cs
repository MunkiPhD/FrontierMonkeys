using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using FrontierMonkeys.entities;
using Microsoft.Xna.Framework.Graphics;

namespace FrontierMonkeys.Levels {
    class Level : IDisposable {
        private Layer[] _layers;
        private const int ENTITY_LAYERS  = 1;
        // Entities in the level.
        public Player Player {
            get { return player; }
        }
        Player player;

        // Level content.        
        public ContentManager Content {
            get { return content; }
        }
        ContentManager content;

        public Level(IServiceProvider serviceProvider, int levelIndex, Player thePlayer) {
            // create the content manager
            this.content = new ContentManager(serviceProvider, "Content");

            // load the layers for now
            _layers = new Layer[1];
            _layers[0] = new Layer(content, "Backgrounds/Layer0");
            // _layers[1] = new Layer(content, "Backgrounds/Layer1");
            // _layers[2] = new Layer(content, "Backgrounds/Layer2");
            this.player = thePlayer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="keyboardState"></param>
        /// <param name="gamePadState"></param>
        /// <param name="touchState"></param>
        /// <param name="accelState"></param>
        /// <param name="orientation"></param>
        public void Update(
           GameTime gameTime,
            KeyboardState keyboardState,
            GamePadState gamePadState, 
            MouseState mouseState,
           DisplayOrientation orientation) {
            // Pause while the player is dead or time is expired.
            if (!Player.isActive) {
                // Still want to perform physics on the player.
                //Player.ApplyPhysics(gameTime);
                //} else if (ReachedExit) {
                //    // Animate the time being converted into points.
                //    int seconds = (int)Math.Round(gameTime.ElapsedGameTime.TotalSeconds * 100.0f);
                //    seconds = Math.Min(seconds, (int)Math.Ceiling(TimeRemaining.TotalSeconds));
                //    timeRemaining -= TimeSpan.FromSeconds(seconds);
                //    score += seconds * PointsPerSecond;
            } else {
                Player.Update(gameTime,keyboardState, gamePadState, mouseState);
                //UpdateMovableTiles(gameTime);
                //UpdateGems(gameTime);

                // Falling off the bottom of the level kills the player.
                //    if (Player.BoundingRectangle.Top >= Height * Tile.Height)
                //        OnPlayerKilled(null);

                //    UpdateEnemies(gameTime);

                //    // The player has reached the exit if they are standing on the ground and
                //    // his bounding rectangle contains the center of the exit tile. They can only
                //    // exit when they have collected all of the gems.
                //    if (Player.IsAlive &&
                //        Player.IsOnGround &&
                //        Player.BoundingRectangle.Contains(exit)) {
                //        OnExitReached();
                //    }
                //}

                //// Clamp the time remaining at zero.
                //if (timeRemaining < TimeSpan.Zero)
                //    timeRemaining = TimeSpan.Zero;
            }
        }

        public void HandleInput(InputState input) {
            player.HandleInput(input.CurrentKeyboardState, input.CurrentGamePadState, input.CurrentMouseState);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            var cameraPosition = 0.0f;
            //for (int i = 0; i <= ENTITY_LAYERS; ++i)
            //    _layers[i].Draw(spriteBatch, cameraPosition);
            _layers[0].Draw(spriteBatch, cameraPosition);
            spriteBatch.End();

            //ScrollCamera(spriteBatch.GraphicsDevice.Viewport);
            //Matrix cameraTransform = Matrix.CreateTranslation(-cameraPosition, 0.0f, 0.0f);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, null);

            //DrawTiles(spriteBatch);

            //foreach (MovableTile tile in movableTiles)
           //     tile.Draw(gameTime, spriteBatch);

           // foreach (Gem gem in gems)
            //    gem.Draw(gameTime, spriteBatch);

            Player.Draw(gameTime, spriteBatch );

            //foreach (Enemy enemy in enemies)
            //    enemy.Draw(gameTime, spriteBatch);

            spriteBatch.End();


            //spriteBatch.Begin();

            //for (int i = EntityLayer + 1; i < layers.Length; ++i)
            //    layers[i].Draw(spriteBatch, cameraPosition);

            //spriteBatch.End();

        }

        #region IDisposable Members

        public void Dispose() {
            throw new NotImplementedException();
        }

        #endregion
    }
}
