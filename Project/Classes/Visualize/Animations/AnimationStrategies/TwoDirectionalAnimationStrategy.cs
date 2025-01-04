using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Project.Classes.Visuals.Animations;

namespace Project.Classes.Visualize.Animations.AnimationStrategies
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
            else if (speed.Y < 0)
            {
                animationManager.SetAnimation(AnimationState.Walk_Left);
            }
            else if (speed.Y > 0)
            {
                animationManager.SetAnimation(AnimationState.Walk_Right);
            }
            else
            {
                animationManager.SetAnimation(AnimationState.Idle);
            }
        }
    }
}
