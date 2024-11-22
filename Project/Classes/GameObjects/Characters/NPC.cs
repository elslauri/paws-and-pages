using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public NPC(Texture2D texture, int numberOfSprites, float scale, Vector2 position, Vector2 speed) : base(texture, numberOfSprites, scale, position, speed)
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
