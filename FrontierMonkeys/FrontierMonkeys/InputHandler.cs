using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FrontierMonkeys {
    class InputHandler {
        Game game { get; set; }
        private KeyboardState _previousKeyboardState;
        private KeyboardState _currentKeyboardState;
        private MouseState _previousMouseState;
        private MouseState _currentMouseState;
        private GamePadState _currentGamePadState;
        private GamePadState _previousGamePadState;


        public InputHandler() { }


        /// <summary>
        /// Update the states of the input devides
        /// </summary>
        public void UpdateStates() {
            //set the previous states as the current state
            _previousKeyboardState = _currentKeyboardState;
            _previousMouseState = _currentMouseState;
            _previousGamePadState = _currentGamePadState;

            //set the current states as what's actually happening
            _currentKeyboardState = Keyboard.GetState();
            _currentMouseState = Mouse.GetState();
            _currentGamePadState = GamePad.GetState(PlayerIndex.One);
        }


        public KeyboardState CurrentKeyboardState {
            get {
                return _currentKeyboardState;
            }
        }
        public KeyboardState PreviousKeyboardState {
            get {
                return _previousKeyboardState;
            }
        }
        public MouseState CurrentMouseState {
            get {
                return _currentMouseState;
            }
        }
        public MouseState PreviousMouseState {
            get {
                return _previousMouseState;
            }
        }
        public GamePadState CurrentGamePadState {
            get {
                return _currentGamePadState;
            }
        }
        public GamePadState PreviousGamePadState {
            get {
                return _previousGamePadState;
            }
        }
    }
}
