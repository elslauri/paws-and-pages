using Project.Classes.Visuals.Animations;

namespace Project.Classes.GameObjects.Characters.NPC
{
    internal interface INPCStyle
    {
        public Animation CreateIdleAnimation(AnimationFactory animationFactory);
        public Animation CreateWalkUpAnimation(AnimationFactory animationFactory);
        public Animation CreateWalkLeftAnimation(AnimationFactory animationFactory);
        public Animation CreateWalkDownAnimation(AnimationFactory animationFactory);
        public Animation CreateWalkRightAnimation(AnimationFactory animationFactory);

    }
}
