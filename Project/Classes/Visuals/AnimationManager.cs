using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Project.Classes.Animations
{
    internal class AnimationManager
    {
        public AnimationFrame CurrentFrame { get; set; }

       
        private List<AnimationFrame> frames;
        private int counter;
        private double secondCounter;
        private int fps;

        private FrameExtractor extractor;

        public AnimationManager(int fps = 8)
        {
            frames = new List<AnimationFrame>();
            this.fps = fps;
            extractor = new FrameExtractor();
        }
        
        public void Update(GameTime gameTime) 
        {
            

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            CurrentFrame = frames[counter];

            if (secondCounter >= 1d/fps)
            {
                counter++;
                if(counter >= frames.Count)
                {
                    counter = 0;
                }
                CurrentFrame = frames[counter];
                secondCounter = 0;

            }
        }


        /// <summary>
        /// Load frames from spritesheet and adds it to a the frames list. Uses the extractor class to get the frames
        /// </summary>
        /// <param name="textureWidth"></param>
        /// <param name="textureHeight"></param>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        public void LoadFramesFromSpriteSheet(int textureWidth, int textureHeight, int columns, int rows)
        {
           frames.AddRange(extractor.GetFrames(textureWidth, textureHeight, columns, rows));
            CurrentFrame = frames[0]; // ok to be here?
        }

        public Rectangle GetCurrentFrameSourceRectangle()
        {
            return CurrentFrame.SourceRectangle;
        }

        // TODO: move this logic to somewhere else
        /// <summary>
        /// Get the size of one frame
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="numberOfWidthSprites"></param>
        /// <param name="numberOfHeightSprites"></param>
        /// <returns></returns>
        public Vector2 getFrameSize(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            return new Vector2(widthOfFrame, heightOfFrame);
        }
    }
}
