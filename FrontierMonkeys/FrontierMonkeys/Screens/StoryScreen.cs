using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FrontierMonkeys.Screens {
    class StoryScreen : GameScreen {
        InputAction storyContinue;
        SpriteFont gameFont;
        ContentManager content;


        public StoryScreen() {
            storyContinue = new InputAction(
              new Buttons[] { Buttons.A, Buttons.Start },
              new Keys[] { Keys.Enter, Keys.Space },
              true);
        }

        public override void HandleInput(Microsoft.Xna.Framework.GameTime gameTime, InputState input) {
            PlayerIndex playerIndex;
            if (storyContinue.Evaluate(input,null, out playerIndex)) {
                //OnSelectEntry(selectedEntry, playerIndex);
            }
        }

        public override void Activate(bool instancePreserved) {
            if (!instancePreserved) {
                if (content == null)
                    content = new ContentManager(ScreenManager.Game.Services, "Content");

                gameFont = content.Load<SpriteFont>("gamefont");

                // once the load has finished, we use ResetElapsedTime to tell the game's
                // timing mechanism that we have just finished a very long frame, and that
                // it should not try to catch up.
                ScreenManager.Game.ResetElapsedTime();
                        
            }

        }
    }

}
 