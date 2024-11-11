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

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        
        public void Update() 
        {
            CurrentFrame = frames[counter];
            counter++;
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
        
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
