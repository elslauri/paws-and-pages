using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Collision;
using Project.Classes.Movement;
using Project.Classes.Visualize.Animations.AnimationStrategies;
using Project.Classes.Visuals.Animations;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Characters
{
    internal class Friend : Character
    {
        private MovementManager movementManager;
        private Character player;

        public Friend(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, float maxSpeed, Character player, IAnimationStrategy animationStrategy, List<ICollidable> obstacles = null) :
            base(animationManager, scale, position, speed, maxSpeed, obstacles, animationStrategy)
        {
            this.player = player;

            movementManager = new MovementManager();

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }


        private void Move()
        {
            movementManager.MoveWithTarget(this, player, new Vector2(75f, -20f));
        }
    }
}
