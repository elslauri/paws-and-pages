
using Microsoft.Xna.Framework;


namespace Project.Classes.Visuals.Animations
{
    internal interface IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, AnimationState state, Vector2 speed);

    }
}
