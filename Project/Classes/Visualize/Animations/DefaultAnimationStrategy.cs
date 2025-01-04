using Microsoft.Xna.Framework;

namespace Project.Classes.Visuals.Animations
{
    internal class DefaultAnimationStrategy : IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, AnimationState state, Vector2 speed)
        {
            animationManager.SetAnimation(state);
        }
    }
}
