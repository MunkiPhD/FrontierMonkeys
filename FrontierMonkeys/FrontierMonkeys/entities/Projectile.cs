using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace FrontierMonkeys.entities {
    class Projectile : Entity{
        public Texture2D texture;
        public Viewport viewport;
        public float speed;
        public int damage;
        public int width { get { return texture.Width; } }
        public int height { get { return texture.Height; } }
        public float rotation;

        public Projectile(Viewport viewPort, Texture2D texture, Vector2 position, float rotation) {
            this.texture = texture;
            this.texture = texture;
            this.viewport = viewPort;
            this.Position = position;
            this.isActive = true;
            this.speed = 10f;
            this.damage = 5;
            this.rotation = rotation;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, Position, null, Color.White,rotation, new Vector2(width / 2, height / 2), 1f, SpriteEffects.None, 0f);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            //Matrix rotationMatrix = Matrix.CreateRotationZ(rotation);
            //Position = Vector2.Transform(new Vector2(0,-1), rotationMatrix);
            Position.X += (float)Math.Tan(rotation) + speed;
            Position.Y -= (float)Math.Sin(rotation) + speed;
           // Position = new Vector2((float)Math.Cos(rotation) * speed, (float)Math.Sin(rotation) * speed);
            //Position.X += (float)Math.Sinh(rotation) * speed;
            //Position.Y += (float)Math.Cosh(rotation) * speed;
            var xLocation = Position.X + texture.Width / 2;
            if ( xLocation > viewport.Width || xLocation < 0)
                isActive = false;

            var yLocation =  Position.Y + texture.Height / 2;
            if ( yLocation > viewport.Height || yLocation < 0)
                isActive = false;
        }
    }
}
