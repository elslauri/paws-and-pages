using Microsoft.Xna.Framework;

namespace Project.Classes.Visuals.Animations
{
    internal class TwoDirectionalAnimationStrategy : IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, AnimationState state, Vector2 speed)
        {
            if (speed.X < 0)
            {
                animationManager.SetAnimation(AnimationState.Walk_Left);

            }
            else if (speed.X > 0)
            {
                animationManager.SetAnimation(AnimationState.Walk_Right);

            }
        }
    }
}
