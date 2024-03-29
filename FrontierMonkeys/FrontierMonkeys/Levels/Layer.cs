﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FrontierMonkeys.Levels {
    class Layer {
        private Texture2D[] _textures;


        public Layer(ContentManager content, string basePath) {   //, float scrollRate) {
            // Assumes each layer only has 3 segments.
            //Textures = new Texture2D[3];
            //for (int i = 0; i < 3; ++i)
            //    Textures[i] = content.Load<Texture2D>(basePath + "_" + i);

            //ScrollRate = scrollRate;
            _textures = new Texture2D[1];
            _textures[0] = content.Load<Texture2D>(basePath);
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
            spriteBatch.Draw(_textures[0], new Vector2(0, 0), Color.White);
        }
    }
}
