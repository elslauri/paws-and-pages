using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Visuals.Animations;

namespace Project.Classes.GameObjects.Characters.NPC
{
    internal class NPCStyle : INPCStyle
    {
        private Texture2D idleTexture;
        private Texture2D walkUpTexture;
        private Texture2D walkLeftTexture;
        private Texture2D walkRightTexture;
        private Texture2D walkDownTexture;

        public NPCStyle(Texture2D idleTexture, Texture2D walkUpTexture, Texture2D walkLeftTexture, Texture2D walkRightTexture, Texture2D walkDownTexture)
        {
            this.idleTexture = idleTexture;
            this.walkUpTexture = walkUpTexture;
            this.walkLeftTexture = walkLeftTexture;
            this.walkRightTexture = walkRightTexture;
            this.walkDownTexture = walkDownTexture;
        }

        public Animation CreateIdleAnimation(AnimationFactory animationFactory)
        {
            return CreateAnimation(animationFactory, idleTexture);
        }
        public Animation CreateWalkUpAnimation(AnimationFactory animationFactory)
        {
            return CreateAnimation(animationFactory, walkUpTexture);
        }
        public Animation CreateWalkLeftAnimation(AnimationFactory animationFactory)
        {
            return CreateAnimation(animationFactory, walkLeftTexture);
        }
        public Animation CreateWalkDownAnimation(AnimationFactory animationFactory)
        {
            return CreateAnimation(animationFactory, walkDownTexture);
        }
        public Animation CreateWalkRightAnimation(AnimationFactory animationFactory)
        {
            return CreateAnimation(animationFactory, walkRightTexture);

        }


        private Animation CreateAnimation(AnimationFactory animationFactory, Texture2D texture)
        {
            return animationFactory.CreateAnimationFromSpriteSheet(texture, 8, 1);

        }
    }
}
