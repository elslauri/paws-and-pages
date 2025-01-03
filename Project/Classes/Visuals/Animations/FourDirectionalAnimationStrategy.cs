

using Microsoft.Xna.Framework;
using System;

namespace Project.Classes.Visuals.Animations
{
    internal class FourDirectionalAnimationStrategy : IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, AnimationState state, Vector2 speed)
        {
            if (speed == Vector2.Zero)
            {
                animationManager.SetAnimation(AnimationState.Idle);
                return;
            }

            float angle = MathF.Atan2(speed.Y, speed.X) * (180 / MathF.PI);

            AnimationState newState = angle switch
            {
                >= -45 and <= 45 => AnimationState.Walk_Right,
                > 45 and < 135 => AnimationState.Walk_Down,
                >= 135 or <= -135 => AnimationState.Walk_Left,
                > -135 and < -45 => AnimationState.Walk_Up,
                _ => AnimationState.Idle
            };
            // this looks crazy but it makes sense in my head:
            // imagine the character the center of a circle,
            // the sprite animation depends on the "zone" of degrees
            // this is how I define the border between up, left, right and down

            animationManager.SetAnimation(newState);
        }
    }
}
