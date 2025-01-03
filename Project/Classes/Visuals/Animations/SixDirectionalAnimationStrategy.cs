

using Microsoft.Xna.Framework;

namespace Project.Classes.Visuals.Animations
{
    internal class SixDirectionalAnimationStrategy : IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, AnimationState state, Vector2 speed)
        {
            AnimationState newState = (speed.X, speed.Y) switch
            {
                ( < 0, < 0) => AnimationState.Walk_LeftUp,
                ( < 0, > 0) => AnimationState.Walk_LeftDown,
                ( > 0, < 0) => AnimationState.Walk_RightUp,
                ( > 0, > 0) => AnimationState.Walk_RightDown,
                ( < 0, 0) => AnimationState.Walk_LeftDown,
                ( > 0, 0) => AnimationState.Walk_RightDown,
                (0, < 0) => AnimationState.Walk_Up,
                (0, > 0) => AnimationState.Walk_Down,
                _ => AnimationState.Idle
            };

            animationManager.SetAnimation(newState);
        }
    }
}
