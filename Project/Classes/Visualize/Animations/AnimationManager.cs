﻿using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Classes.Visuals.Animations
{
    public enum AnimationState { Idle, Walk_Up, Walk_Left, Walk_Right, Walk_Down, Walk_LeftUp, Walk_LeftDown, Walk_RightUp, Walk_RightDown } 


    internal class AnimationManager
    {
        private Dictionary<string, Animation> animations;
        private Animation currentAnimation;

        public AnimationManager()
        {
            animations = new Dictionary<string, Animation>();
        }

        public void AddAnimation(AnimationState key, Animation animation)
        {
            animations[key.ToString()] = animation;
            if (currentAnimation == null)
                currentAnimation = animation;
        }

        public void SetAnimation(AnimationState animationKey)
        {
            if (animations.TryGetValue(animationKey.ToString(), out var animation))
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
            var frame = currentAnimation.GetCurrentFrameSourceRectangle();
            var origin = Vector2.Zero; 
            spriteBatch.Draw(currentAnimation.Texture, position, frame, Color.White, 0f, origin, scale, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Get the size of one frame
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="numberOfWidthSprites"></param>
        /// <param name="numberOfHeightSprites"></param>
        /// <returns></returns>
        public Vector2 GetCurrentFrameSize()
        {
            //int widthOfFrame = width / numberOfWidthSprites;
            //int heightOfFrame = height / numberOfHeightSprites;

            //return new Vector2(widthOfFrame, heightOfFrame);

            Rectangle frame = currentAnimation.Frames[0].SourceRectangle;
            return new Vector2(frame.Width, frame.Height);
        }

    }
}
