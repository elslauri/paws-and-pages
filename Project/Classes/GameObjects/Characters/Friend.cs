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

        public Friend(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, Character player, List<ICollidable> obstacles) : 
            base(animationManager, scale, position, speed, obstacles, new TwoDirectionalAnimationStrategy())
        {
            this.player = player;

            movementManager = new MovementManager();

        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        private void Move()
        {
            movementManager.MoveWithTarget(this, player, new Vector2(50f, -20f));
        }
    }
}
