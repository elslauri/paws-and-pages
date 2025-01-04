using Microsoft.Xna.Framework;
using Project.Classes.Visuals.Animations;

namespace Project.Classes.Visualize.Animations.AnimationStrategies
{
    internal class DefaultAnimationStrategy : IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, AnimationState state, Vector2 speed)
        {
            animationManager.SetAnimation(state);
        }
    }
}
