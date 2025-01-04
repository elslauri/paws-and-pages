using Microsoft.Xna.Framework;
using Project.Classes.Collision;
using Project.Classes.Movement;
using Project.Classes.Visualize.Animations.AnimationStrategies;
using Project.Classes.Visuals.Animations;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project.Classes.GameObjects.Characters.NPC
{
    internal class NPC : Character
    {
        private MovementManager movementManager;


        public NPC(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, float maxSpeed, IAnimationStrategy animationStrategy, List<ICollidable> obstacles = null) :
            base(animationManager, scale, position, speed, maxSpeed, obstacles, animationStrategy)
        {
            movementManager = new MovementManager();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }
        private void Move()
        {
            movementManager.Move(this);
        }
    }
}
