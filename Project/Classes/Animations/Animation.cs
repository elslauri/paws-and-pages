using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        
        public void Update(GameTime gameTime) 
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 8;
            if (secondCounter >= 1d/fps)
            {
                counter++;
                secondCounter = 0;
            }
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
        
        /// <summary>
        /// Gets frames based on texture properties
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="numberOfWidthSprites"></param>
        /// <param name="numberOfHeightSprites"></param>
        public void GetFramesFromTextureProperties (int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width/numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;


            for (int y = 0; y <= height-heightOfFrame; y+= heightOfFrame)
            {
                for (int x = 0; x <= width-widthOfFrame; x+= widthOfFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x,y,widthOfFrame,heightOfFrame)));
                }
            }

            CurrentFrame = frames[0];
        }
    }
}
