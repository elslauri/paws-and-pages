
using Microsoft.Xna.Framework;


namespace Project.Classes.Visuals.Animations
{
    internal interface IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, string state, Vector2 speed);

    }
}
