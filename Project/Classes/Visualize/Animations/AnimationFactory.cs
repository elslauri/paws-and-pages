﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Classes.Visuals.Animations
{
    internal class AnimationFactory
    {
        private FrameExtractor extractor;

        public AnimationFactory()
        {
            extractor = new FrameExtractor();
        }


        public Animation CreateAnimationFromSpriteSheet(Texture2D texture, int columns, int rows)
        {
            var frames = extractor.GetFrames(texture.Width, texture.Height, columns, rows);
            return new Animation(texture, frames);
        }
    }
}
