#region File Description
//-----------------------------------------------------------------------------
// InputState.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FrontierMonkeys {
    /// <summary>
    /// Helper for reading input from keyboard, gamepad, and touch input. This class 
    /// tracks both the current and previous state of the input devices, and implements 
    /// query methods for high level input actions such as "move up through the menu"
    /// or "pause the game".
    /// </summary>
    public class InputState {
        public const int MaxInputs = 4;

        public  KeyboardState CurrentKeyboardState;
        public  GamePadState CurrentGamePadState;
        public  MouseState CurrentMouseState;

        public  KeyboardState LastKeyboardState;
        public  GamePadState LastGamePadState;
        public  MouseState LastMouseState;


        private bool _gamePadWasConnected;
        public bool GamePadWasConnected { get {
            return _gamePadWasConnected;
        } }


        /// <summary>
        /// Constructs a new input state.
        /// </summary>
        public InputState() {
            CurrentKeyboardState = new KeyboardState();
            CurrentGamePadState = new GamePadState();
            CurrentMouseState = new MouseState();

            LastKeyboardState = new KeyboardState();
            LastGamePadState = new GamePadState();
            LastMouseState = new MouseState();


            //GamePadWasConnected = new bool();
        }

        /// <summary>
        /// Reads the latest state user input.
        /// </summary>
        public void Update() {
            //for (int i = 0; i < MaxInputs; i++) {
            LastKeyboardState = CurrentKeyboardState;
            LastGamePadState = CurrentGamePadState;
                LastMouseState = CurrentMouseState;

                CurrentKeyboardState = Keyboard.GetState();
                CurrentGamePadState= GamePad.GetState(0, GamePadDeadZone.Circular);
                CurrentMouseState = Mouse.GetState();

                // Keep track of whether a gamepad has ever been
                // connected, so we can detect if it is unplugged.
                //if (CurrentGamePadStates[i].IsConnected) {
                //    GamePadWasConnected[i] = true;
                //}
                if (CurrentGamePadState.IsConnected)
                    _gamePadWasConnected = true;
            //}

        }


        /// <summary>
        /// Helper for checking if a key was pressed during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a keypress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public bool IsKeyPressed(Keys key, PlayerIndex? controllingPlayer, out PlayerIndex playerIndex) {
            if (controllingPlayer.HasValue) {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return CurrentKeyboardState.IsKeyDown(key);
            } else {
                // Accept input from any player.
                //return (IsKeyPressed(key, PlayerIndex.One, out playerIndex) ||
                //        IsKeyPressed(key, PlayerIndex.Two, out playerIndex) ||
                //        IsKeyPressed(key, PlayerIndex.Three, out playerIndex) ||
                //        IsKeyPressed(key, PlayerIndex.Four, out playerIndex));
                return (IsKeyPressed(key, PlayerIndex.One, out playerIndex));
            }
        }


        /// <summary>
        /// Helper for checking if a button was pressed during this update.
        /// The controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a button press
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public bool IsButtonPressed(Buttons button, PlayerIndex? controllingPlayer, out PlayerIndex playerIndex) {
            if (controllingPlayer.HasValue) {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return CurrentGamePadState.IsButtonDown(button);
            } else {
                // Accept input from any player.
                //return (IsButtonPressed(button, PlayerIndex.One, out playerIndex) ||
                //        IsButtonPressed(button, PlayerIndex.Two, out playerIndex) ||
                //        IsButtonPressed(button, PlayerIndex.Three, out playerIndex) ||
                //        IsButtonPressed(button, PlayerIndex.Four, out playerIndex));
                return (IsButtonPressed(button, PlayerIndex.One, out playerIndex) );
            }
        }


        /// <summary>
        /// Helper for checking if a key was newly pressed during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a keypress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public bool IsNewKeyPress(Keys key, PlayerIndex? controllingPlayer, out PlayerIndex playerIndex) {
            if (controllingPlayer.HasValue) {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentKeyboardState.IsKeyDown(key) &&
                        LastKeyboardState.IsKeyUp(key));
            } else {
                // Accept input from any player.
                //return (IsNewKeyPress(key, PlayerIndex.One, out playerIndex) ||
                //        IsNewKeyPress(key, PlayerIndex.Two, out playerIndex) ||
                //        IsNewKeyPress(key, PlayerIndex.Three, out playerIndex) ||
                //        IsNewKeyPress(key, PlayerIndex.Four, out playerIndex));
                return (IsNewKeyPress(key, PlayerIndex.One, out playerIndex) );
            }
        }


        /// <summary>
        /// Helper for checking if a button was newly pressed during this update.
        /// The controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a button press
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public bool IsNewButtonPress(Buttons button, PlayerIndex? controllingPlayer, out PlayerIndex playerIndex) {
            if (controllingPlayer.HasValue) {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentGamePadState.IsButtonDown(button) &&
                        LastGamePadState.IsButtonUp(button));
            } else {
                // Accept input from any player.
                //return (IsNewButtonPress(button, PlayerIndex.One, out playerIndex) ||
                //        IsNewButtonPress(button, PlayerIndex.Two, out playerIndex) ||
                //        IsNewButtonPress(button, PlayerIndex.Three, out playerIndex) ||
                //        IsNewButtonPress(button, PlayerIndex.Four, out playerIndex));
                return (IsNewButtonPress(button, PlayerIndex.One, out playerIndex) );
            }
        }
    }
}
