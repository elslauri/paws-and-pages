using Microsoft.Xna.Framework;
using Project.Classes.Animations;

namespace Project.Classes.Visuals
{
    internal class DefaultAnimationStrategy: IAnimationStrategy
    {
        public void SetAnimation(AnimationManager animationManager, string state, Vector2 speed)
        {
            animationManager.SetAnimation(state);
        }
    }
}
