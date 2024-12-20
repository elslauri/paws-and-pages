using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Project.Classes.Animations
{
    internal class FrameExtractor
    {
        /// <summary>
        /// Gets frames based on texture properties
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="numberOfWidthSprites"></param>
        /// <param name="numberOfHeightSprites"></param>
        public List<AnimationFrame> GetFrames(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            var frames = new List<AnimationFrame>();
            Vector2 frameSize = getFrameSize(width, height, numberOfWidthSprites, numberOfHeightSprites);

            for (int y = 0; y <= height - frameSize.Y; y += (int)frameSize.Y)
            {
                for (int x = 0; x <= width - frameSize.X; x += (int)frameSize.X)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, y, (int)frameSize.X, (int)frameSize.Y)));
                }
            }

            return frames;
        }

        /// <summary>
        /// Get the size of one frame
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public Vector2 getFrameSize(int width, int height, int columns, int rows)
        {
            return new Vector2(width / columns, height / rows);
        }
    }
}
