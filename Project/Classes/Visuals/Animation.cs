using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Visuals
{
    internal class Animation
    {
        public Texture2D Texture { get; }
        public List<AnimationFrame> Frames { get; }
        public int Fps { get; }

        private int counter;
        private double secondCounter;

        public Animation(Texture2D texture, List<AnimationFrame> frames, int fps = 8)
        {
            Texture = texture;
            Frames = frames;
            Fps = fps;

            counter = 0;
            secondCounter = 0;
        }
        public void Update(GameTime gameTime)
        {
            // CurrentFrame = frames[0]; this reset where?

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

           // CurrentFrame = frames[counter];

            if (secondCounter >= 1d / Fps)
            {
                counter++;
                if (counter >= Frames.Count)
                {
                    counter = 0;
                }
              //  CurrentFrame = frames[counter];
                secondCounter = 0;

            }
        }
        public Rectangle GetCurrentFrameSourceRectangle()
        {
            return Frames[counter].SourceRectangle;
        }

    }
}
