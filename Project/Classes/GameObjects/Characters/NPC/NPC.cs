using Microsoft.Xna.Framework;
using Project.Classes.Collision;
using Project.Classes.Movement;
using Project.Classes.Visualize.Animations.AnimationStrategies;
using Project.Classes.Visuals.Animations;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Characters.NPC
{
    internal class NPC : Character
    {
        private MovementManager movementManager;

        public NPC(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, List<ICollidable> obstacles) :
            base(animationManager, scale, position, speed, obstacles, new FourDirectionalAnimationStrategy())
        {
            movementManager = new MovementManager();
        }

        public void Update(GameTime gameTime)
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
