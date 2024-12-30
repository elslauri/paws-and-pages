using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Visuals;

namespace Project.Classes.Animations
{
    internal class AnimationManager
    {
        private Dictionary<string, Animation> animations;
        private Animation currentAnimation;

        public AnimationManager()
        {
            animations = new Dictionary<string, Animation>();
        }

        public void AddAnimation(string key, Animation animation)
        {
            animations[key] = animation;
            if (currentAnimation == null)
                currentAnimation = animation;
        }
        
        public void SetAnimation(string animationKey)
        {
            if(animations.TryGetValue(animationKey, out var animation))
            {
                currentAnimation = animation;
            }
        }
      
        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float scale)
        {
            spriteBatch.Draw(currentAnimation.Texture, position, currentAnimation.GetCurrentFrameSourceRectangle(), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Get the size of one frame
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="numberOfWidthSprites"></param>
        /// <param name="numberOfHeightSprites"></param>
        /// <returns></returns>
        public Vector2 getCurrentFrameSize()
        {
            //int widthOfFrame = width / numberOfWidthSprites;
            //int heightOfFrame = height / numberOfHeightSprites;

            //return new Vector2(widthOfFrame, heightOfFrame);

            Rectangle frame = currentAnimation.Frames[0].SourceRectangle;
            return new Vector2(frame.Width, frame.Height);
        }
    }
}
