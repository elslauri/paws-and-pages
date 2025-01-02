using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using Project.Classes.Movement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects.Characters
{
    internal class NPC : Character
    {
        private MovementManager movementManager;

        public NPC(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, List<ICollidable> obstacles) : 
            base(animationManager, scale, position, speed, obstacles)
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
