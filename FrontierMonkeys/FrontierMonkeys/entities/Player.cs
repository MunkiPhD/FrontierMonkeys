using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using FrontierMonkeys;

namespace FrontierMonkeys.entities {
    class Player : Entity {
        Game game;
        //InputHandler input;
        public Vector2 LastPosition;
        public Texture2D PlayerTexture;
        public int Width { get { return PlayerTexture.Width; } }
        public int Height { get { return PlayerTexture.Height; } }
        public float speed;
        private Vector2 _mousePosition;
        private Texture2D _reticle;
        public int PlayerIndex;

        public Player(Game game)//, InputHandler input)
            : base() {
            this.game = game;
            //this.input = input;

            Vector2 playerPosition = new Vector2(game.GraphicsDevice.Viewport.TitleSafeArea.X, game.GraphicsDevice.Viewport.TitleSafeArea.Y + game.GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            this.Position = playerPosition;
            this.PlayerTexture = game.Content.Load<Texture2D>("player");
            _reticle = game.Content.Load<Texture2D>("reticle");
            this.speed = 15f;
            this.PlayerIndex = 0;
        }



        public void HandleInput(KeyboardState keyboardState,
            GamePadState gamePadState, 
            MouseState mouseState) {
            this.LastPosition = this.Position;


            //KeyboardState keyboardState = input.CurrentKeyboardStates[this.PlayerIndex];
            //GamePadState gamePadState = input.CurrentGamePadStates[this.PlayerIndex];
            //MouseState mouseState = input.CurrentMouseStates[this.PlayerIndex];

            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A) ) {
                Position.X -= speed;
            }

            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D) || gamePadState.DPad.Right == ButtonState.Pressed) {
                Position.X += speed;
            }
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W) || gamePadState.DPad.Up == ButtonState.Pressed) {
                Position.Y -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S) || gamePadState.DPad.Down == ButtonState.Pressed) {
                Position.Y += speed;
            }


            var leftStick = gamePadState.ThumbSticks.Left;
            if (leftStick.Length() != 0.0f) {
                leftStick.Normalize();
                Position.X += leftStick.X * speed;
                Position.Y -= leftStick.Y * speed;
            }
            

            _mousePosition.X = mouseState.X;
            _mousePosition.Y = mouseState.Y;
            //this.Position.X = input.CurrentMouseState.X;
            //this.Position.Y = input.CurrentMouseState.Y;

            //certify that the user is within bounds
            Position.X = MathHelper.Clamp(Position.X, 0, game.GraphicsDevice.Viewport.Width - Width);
            Position.Y = MathHelper.Clamp(Position.Y, 0, game.GraphicsDevice.Viewport.Height - Height);
        }


        
        /// <summary>
        /// Updates the player's actions and actions upon
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime,
             KeyboardState keyboardState,
            GamePadState gamePadState, 
            MouseState mouseState) {
            HandleInput(keyboardState, gamePadState, mouseState);
           // this.LastPosition = this.Position;


           // if (input.CurrentKeyboardState.IsKeyDown(Keys.Left) || input.CurrentKeyboardState.IsKeyDown(Keys.A) || input.CurrentGamePadState.DPad.Left == ButtonState.Pressed) {
           //    Position.X -= speed;
           // }

           // if (input.CurrentKeyboardState.IsKeyDown(Keys.Right) || input.CurrentKeyboardState.IsKeyDown(Keys.D) || input.CurrentGamePadState.DPad.Right == ButtonState.Pressed) {
           //    Position.X += speed;
           // }
           // if (input.CurrentKeyboardState.IsKeyDown(Keys.Up) || input.CurrentKeyboardState.IsKeyDown(Keys.W) || input.CurrentGamePadState.DPad.Up == ButtonState.Pressed) {
           //     Position.Y -= speed;
           // }
           // if (input.CurrentKeyboardState.IsKeyDown(Keys.Down) || input.CurrentKeyboardState.IsKeyDown(Keys.S) || input.CurrentGamePadState.DPad.Down == ButtonState.Pressed) {
           //     Position.Y += speed;
           // }

           // _mousePosition.X = input.CurrentMouseState.X;
           // _mousePosition.Y = input.CurrentMouseState.Y;
           ////this.Position.X = input.CurrentMouseState.X;
           ////this.Position.Y = input.CurrentMouseState.Y;

           // //certify that the user is within bounds
           // Position.X = MathHelper.Clamp(Position.X, 0, game.GraphicsDevice.Viewport.Width - Width);
           // Position.Y = MathHelper.Clamp(Position.Y, 0, game.GraphicsDevice.Viewport.Height - Height);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.Draw(PlayerTexture, Position, Color.White);
            spriteBatch.Draw(_reticle, _mousePosition, Color.White);
        }
    }
}

