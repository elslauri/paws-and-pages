
using Microsoft.Xna.Framework;
using Project.Classes.Visuals.Animations;


namespace Project.Classes.Visualize.Animations.AnimationStrategies
{
    internal interface IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, AnimationState state, Vector2 speed);

    }
}
