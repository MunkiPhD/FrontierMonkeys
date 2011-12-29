using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace FrontierMonkeys.entities {
    class Player : Entity {
        Game game;
        InputHandler input;
        public Vector2 LastPosition;
        public Texture2D PlayerTexture;
        public int Width { get { return PlayerTexture.Width; } }
        public int Height { get { return PlayerTexture.Height; } }
        public float speed;
        private Vector2 _mousePosition;
        private Texture2D _reticle;

        public Player(Game game, InputHandler input)
            : base() {
            this.game = game;
            this.input = input;

            Vector2 playerPosition = new Vector2(game.GraphicsDevice.Viewport.TitleSafeArea.X, game.GraphicsDevice.Viewport.TitleSafeArea.Y + game.GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            this.Position = playerPosition;
            this.PlayerTexture = game.Content.Load<Texture2D>("player");
            _reticle = game.Content.Load<Texture2D>("reticle");
            this.speed = 7f;
        }


        /// <summary>
        /// Updates the player's actions and actions upon
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime) {
            this.LastPosition = this.Position;


            if (input.CurrentKeyboardState.IsKeyDown(Keys.Left) || input.CurrentKeyboardState.IsKeyDown(Keys.A) || input.CurrentGamePadState.DPad.Left == ButtonState.Pressed) {
               Position.X -= speed;
            }

            if (input.CurrentKeyboardState.IsKeyDown(Keys.Right) || input.CurrentKeyboardState.IsKeyDown(Keys.D) || input.CurrentGamePadState.DPad.Right == ButtonState.Pressed) {
               Position.X += speed;
            }
            if (input.CurrentKeyboardState.IsKeyDown(Keys.Up) || input.CurrentKeyboardState.IsKeyDown(Keys.W) || input.CurrentGamePadState.DPad.Up == ButtonState.Pressed) {
                Position.Y -= speed;
            }
            if (input.CurrentKeyboardState.IsKeyDown(Keys.Down) || input.CurrentKeyboardState.IsKeyDown(Keys.S) || input.CurrentGamePadState.DPad.Down == ButtonState.Pressed) {
                Position.Y += speed;
            }

            _mousePosition.X = input.CurrentMouseState.X;
            _mousePosition.Y = input.CurrentMouseState.Y;
           //this.Position.X = input.CurrentMouseState.X;
           //this.Position.Y = input.CurrentMouseState.Y;

            //certify that the user is within bounds
            Position.X = MathHelper.Clamp(Position.X, 0, game.GraphicsDevice.Viewport.Width - Width);
            Position.Y = MathHelper.Clamp(Position.Y, 0, game.GraphicsDevice.Viewport.Height - Height);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(PlayerTexture, Position, Color.White);
            spriteBatch.Draw(_reticle, _mousePosition, Color.White);
        }
    }
}

