using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Collision;
using Project.Classes.Visuals.Animations;
using System;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Characters.NPC
{
    internal class NPCFactory : INPCFactory
    {
        private readonly float scale;
        private readonly Vector2 speed;
        private readonly List<ICollidable> obstacles;
        private readonly AnimationFactory animationFactory;
        private readonly List<INPCStyle> npcStyles;

        public NPCFactory(float scale, Vector2 speed, List<ICollidable> obstacles, AnimationFactory animationFactory, List<INPCStyle> npcStyles)
        {
            this.scale = scale;
            this.speed = speed;
            this.obstacles = obstacles;
            this.animationFactory = animationFactory;
            this.npcStyles = npcStyles;
        }

        public NPC CreateNPC(AnimationManager animationManager, Vector2 position)
        {
            return new NPC(animationManager, scale, position, speed, obstacles);
        }
        public NPC CreateRandomNPC(Vector2 position)
        {
            INPCStyle npcStyle = GetRandomStyle();
            AnimationManager manager = new AnimationManager();
            manager.AddAnimation(AnimationState.Idle, npcStyle.CreateIdleAnimation(animationFactory));
            manager.AddAnimation(AnimationState.Walk_Up, npcStyle.CreateWalkUpAnimation(animationFactory));
            manager.AddAnimation(AnimationState.Walk_Left, npcStyle.CreateWalkLeftAnimation(animationFactory));
            manager.AddAnimation(AnimationState.Walk_Down, npcStyle.CreateWalkDownAnimation(animationFactory));
            manager.AddAnimation(AnimationState.Walk_Right, npcStyle.CreateWalkRightAnimation(animationFactory));
            return CreateNPC(manager, position);
        }

        /// <summary>
        /// Get a random NPCStyle
        /// </summary>
        /// <returns>INPCStyle</returns>
        public INPCStyle GetRandomStyle()
        {
            int index = new Random().Next(npcStyles.Count);
            return npcStyles[index];
        }

    }
}
