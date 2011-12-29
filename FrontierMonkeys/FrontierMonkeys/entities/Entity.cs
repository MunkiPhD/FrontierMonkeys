using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FrontierMonkeys.entities {
    class Entity {
        public bool isActive;
        public Vector2 Position;

        public Entity() {
            isActive = true; //set isActive to true by default
        }

        public virtual void Update(GameTime gameTime) {
            Console.WriteLine("Update not implamented");
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            Console.WriteLine("Draw not implamented");
        }
    }
}
