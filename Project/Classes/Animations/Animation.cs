﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
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
    }
}
