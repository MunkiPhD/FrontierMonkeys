using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FrontierMonkeys.Levels {
    class Layer {
        private Texture2D[] _textures;
        public float scrollRate;
        private Vector2 _position;
        private Vector2 _positionTwo;
        public Viewport viewport;
        private Vector2 _internalPosition;

        public Layer(ContentManager content, string basePath, Viewport viewport) {   //, float scrollRate) {
            // Assumes each layer only has 3 segments.
            //Textures = new Texture2D[3];
            //for (int i = 0; i < 3; ++i)
            //    Textures[i] = content.Load<Texture2D>(basePath + "_" + i);
            this.viewport = viewport;

            //ScrollRate = scrollRate;
            _textures = new Texture2D[1];
            _textures[0] = content.Load<Texture2D>(basePath);
            scrollRate = 5.0f;
            _position = new Vector2(0, 0);
            _positionTwo = new Vector2(0, -_textures[0].Height);
            _internalPosition = new Vector2(0, 0);
        }


        public void Update(GameTime gameTime) {
            _position.Y += scrollRate;
            _positionTwo.Y += scrollRate;

            //_internalPosition.Y += scrollRate;
            //if (_internalPosition.Y <= _textures[0].Height) {
            //    return;
            //}
            //if (_internalPosition.Y >= viewport.Height) {
            //    _internalPosition.Y = 0;
            //    var temp = _position;
            //    //_position 
            //}
            if (_position.Y >= viewport.Height) {
                _position.Y = -_textures[0].Height;
            }
            if (_positionTwo.Y >= viewport.Height) {
                _positionTwo.Y = -_textures[0].Height;
            } 
            
        }


        public void Draw(SpriteBatch spriteBatch, float cameraPosition) {
            //// Assume each segment is the same width.
            //int segmentWidth = Textures[0].Width;

            //// Calculate which segments to draw and how much to offset them.
            //float x = cameraPosition * ScrollRate;
            //int leftSegment = (int)Math.Floor(x / segmentWidth);
            //int rightSegment = leftSegment + 1;
            //x = (x / segmentWidth - leftSegment) * -segmentWidth;

            //spriteBatch.Draw(Textures[leftSegment % Textures.Length], new Vector2(x, 0.0f), Color.White);
            //spriteBatch.Draw(Textures[rightSegment % Textures.Length], new Vector2(x + segmentWidth, 0.0f), Color.White);
            spriteBatch.Draw(_textures[0], _position, Color.White);
            spriteBatch.Draw(_textures[0], _positionTwo, Color.White);

        }
    }
}
