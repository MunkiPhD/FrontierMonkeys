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
        private float _rotationAngle;
        private Vector2 _playerOrigin;
        private Vector2 _reticleOrigin;
        private bool _drawReticle = false;
        private List<Projectile> _projectiles;

        public Player(Game game)//, InputHandler input)
            : base() {
            this.game = game;
            //this.input = input;

            Vector2 playerPosition = new Vector2(game.GraphicsDevice.Viewport.TitleSafeArea.X, game.GraphicsDevice.Viewport.TitleSafeArea.Y + game.GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            this.Position = playerPosition;
            this.PlayerTexture = game.Content.Load<Texture2D>("player");
            _reticle = game.Content.Load<Texture2D>("cursor");
            this.speed = 15f;
            this.PlayerIndex = 0;

            _playerOrigin = new Vector2(PlayerTexture.Width / 2, PlayerTexture.Height / 2);
            _reticleOrigin = new Vector2(_reticle.Width / 2, _reticle.Height / 2);
            _projectiles = new List<Projectile>();
        }


        /// <summary>
        /// Handles the input for the player that is received from the player
        /// </summary>
        /// <param name="keyboardState"></param>
        /// <param name="gamePadState"></param>
        /// <param name="mouseState"></param>
        public void HandleInput(KeyboardState keyboardState, GamePadState gamePadState, MouseState mouseState) {
            this.LastPosition = this.Position;
            this._drawReticle = !gamePadState.IsConnected; //determine whether to draw the reticle by whether a gamepad is plugged in or not


            // if a gamepad is not connected, use the mouse. otherwise, read the input from the gamepad
            if (_drawReticle) {
                HandleKeyboardInput(keyboardState);
                HandleMouseInput(mouseState);

            } else {
                HandleGamepadInput(gamePadState);
            }

            // certify that the user is within bounds
            Position.X = MathHelper.Clamp(Position.X, _playerOrigin.X, game.GraphicsDevice.Viewport.Width - _playerOrigin.X);
            Position.Y = MathHelper.Clamp(Position.Y, _playerOrigin.Y, game.GraphicsDevice.Viewport.Height - _playerOrigin.Y);
        }



        /// <summary>
        /// Handles the mouse input
        /// </summary>
        /// <param name="mouseState">The mouse input state</param>
        private void HandleMouseInput(MouseState mouseState) {
            _mousePosition = new Vector2(mouseState.X, mouseState.Y);
            float xDistance = _mousePosition.X - (Position.X);// + (PlayerTexture.Width / 2));
            float yDistance = _mousePosition.Y - (Position.Y);// - (PlayerTexture.Height / 2));
            _rotationAngle = (float)Math.PI / 2 + (float)Math.Atan2(yDistance, xDistance);

            if (mouseState.LeftButton == ButtonState.Pressed) {
                _projectiles.Add(new Projectile(game.GraphicsDevice.Viewport, game.Content.Load<Texture2D>("shot"), Position, _rotationAngle));
            }
        }



        /// <summary>
        /// Handles the input from the keyboard
        /// </summary>
        /// <param name="keyboardState"></param>
        private void HandleKeyboardInput(KeyboardState keyboardState) {
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A)) {
                Position.X -= speed;
            }

            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D)) {
                Position.X += speed;
            }

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)) {
                Position.Y -= speed;
            }

            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)) {
                Position.Y += speed;
            }
        }

        /// <summary>
        /// Handles the gamepad state input 
        /// </summary>
        /// <param name="gamePadState">The GamePadState that contains the input information</param>
        private void HandleGamepadInput(GamePadState gamePadState) {
            // look at the DPad
            if (gamePadState.DPad.Left == ButtonState.Pressed) {
                Position.X -= speed;
            }

            if (gamePadState.DPad.Right == ButtonState.Pressed) {
                Position.X += speed;
            }

            if (gamePadState.DPad.Up == ButtonState.Pressed) {
                Position.Y -= speed;
            }

            if (gamePadState.DPad.Down == ButtonState.Pressed) {
                Position.Y += speed;
            }

            // look at the left stick
            var leftStick = gamePadState.ThumbSticks.Left;
            if (leftStick.Length() != 0.0f) {
                leftStick.Normalize();
                Position.X += leftStick.X * speed;
                Position.Y -= leftStick.Y * speed;
            }

            // look at the right stick and get the rotation angle
            var rightStick = gamePadState.ThumbSticks.Right;
            if (rightStick.Length() != 0.0f)
                _rotationAngle = (float)Math.Atan2(rightStick.X, rightStick.Y);

            if (gamePadState.IsButtonDown(Buttons.RightTrigger)) {
                _projectiles.Add(new Projectile(game.GraphicsDevice.Viewport, game.Content.Load<Texture2D>("shot"), Position, _rotationAngle));
            }
        }



        /// <summary>
        /// Updates the player's actions and actions upon
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime,
             KeyboardState keyboardState,
            GamePadState gamePadState,
            MouseState mouseState) {

            _projectiles.RemoveAll(x => x.isActive == false);
            foreach (Projectile projectile in _projectiles) {
                projectile.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            //spriteBatch.Draw(PlayerTexture, Position, Color.White);
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, _rotationAngle, _playerOrigin, 1.0f, SpriteEffects.None, 0);

            if (_drawReticle)
                spriteBatch.Draw(_reticle, _mousePosition, null, Color.White, 0, _reticleOrigin, 1.0f, SpriteEffects.None, 0);

            foreach (Projectile projectile in _projectiles) {
                projectile.Draw(spriteBatch);
            }
        }
    }
}

