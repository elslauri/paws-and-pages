using Microsoft.Xna.Framework;

namespace Project.Classes.Visuals.Animations
{
    internal class TwoDirectionalAnimationStrategy : IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, string state, Vector2 speed)
        {
            string animation = state;
            if (speed.X < 0)
            {
                animation += "_left";
            }
            else if (speed.X > 0)
            {
                animation += "_right";
            }
            animationManager.SetAnimation(animation);
        }
    }
}
