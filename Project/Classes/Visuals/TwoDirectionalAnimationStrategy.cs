using Microsoft.Xna.Framework;
using Project.Classes.Animations;

namespace Project.Classes.Visuals
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
