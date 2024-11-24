using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project.Classes.Animations
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }

       
        private List<AnimationFrame> frames;
        private int counter;
        private double secondCounter;
        private int fps;

        private FrameExtractor extractor;

        public Animation(int fps = 8)
        {
            frames = new List<AnimationFrame>();
            this.fps = fps;
            extractor = new FrameExtractor();
        }
        
        public void Update(GameTime gameTime) 
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            
            if (secondCounter >= 1d/fps)
            {
                counter++;
                CurrentFrame = frames[0];
                secondCounter = 0;
            }
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void LoadFramesFromSpriteSheet(int textureWidth, int textureHeight, int columns, int rows)
        {
            frames.AddRange(extractor.GetFrames(textureWidth, textureHeight, columns, rows));
        }
        

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
