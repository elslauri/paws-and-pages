using Microsoft.Xna.Framework;

namespace Project.Classes.Visuals.Animations
{
    internal class DefaultAnimationStrategy : IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, string state, Vector2 speed)
        {
            animationManager.SetAnimation(state);
        }
    }
}
