using Microsoft.Xna.Framework;
using Project.Classes.Collision;
using Project.Classes.Visualize.Animations.AnimationStrategies;
using Project.Classes.Visuals.Animations;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project.Classes.GameObjects.Characters.NPC
{
    public enum NpcMoveType { Calm, Walk, Panic }
    internal class NPCFactory : INPCFactory
    {
        private readonly float scale;
        private readonly List<ICollidable> obstacles;
        private readonly AnimationFactory animationFactory;
        private readonly List<INPCStyle> npcStyles;

        public NPCFactory(float scale, List<ICollidable> obstacles, AnimationFactory animationFactory, List<INPCStyle> npcStyles)
        {
            this.scale = scale;
            this.obstacles = obstacles;
            this.animationFactory = animationFactory;
            this.npcStyles = npcStyles;
        }

        public NPC CreateNPC(AnimationManager animationManager, Vector2 position, Vector2 speed, float maxSpeed)
        {
            return new NPC(animationManager, scale, position, speed, maxSpeed, new FourDirectionalAnimationStrategy(), obstacles);
        }
        public NPC CreateRandomNPC(Vector2 position, NpcMoveType npcMoveType)
        {
            INPCStyle npcStyle = GetRandomStyle();
            AnimationManager manager = SetAnimations(npcStyle);
            Vector2 speed = new Vector2(0,0);
            float maxSpeed = 0f;
            switch (npcMoveType)
            {   
                case NpcMoveType.Calm:
                    speed = new Vector2(0,0);
                    maxSpeed = 0f;
                    break;
                case NpcMoveType.Walk:
                    speed = new Vector2(0.5f, 0.5f);
                    maxSpeed = 2f;
                    break;
                case NpcMoveType.Panic:
                    speed = new Vector2(1, 1);
                    maxSpeed = 3f;
                    break;
            }

            return CreateNPC(manager, position, speed, maxSpeed);
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


        private AnimationManager SetAnimations(INPCStyle npcStyle)
        {
            AnimationManager manager = new AnimationManager();
            manager.AddAnimation(AnimationState.Idle, npcStyle.CreateIdleAnimation(animationFactory));
            manager.AddAnimation(AnimationState.Walk_Up, npcStyle.CreateWalkUpAnimation(animationFactory));
            manager.AddAnimation(AnimationState.Walk_Left, npcStyle.CreateWalkLeftAnimation(animationFactory));
            manager.AddAnimation(AnimationState.Walk_Down, npcStyle.CreateWalkDownAnimation(animationFactory));
            manager.AddAnimation(AnimationState.Walk_Right, npcStyle.CreateWalkRightAnimation(animationFactory));
            return manager;
        }

    }
}
