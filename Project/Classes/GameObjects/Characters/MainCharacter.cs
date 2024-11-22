using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Classes.Input;
using Project.Classes.Movement;

namespace Project.Classes.GameObjects.Characters
{
    internal class MainCharacter : Character
    {
        private MovementManager movementManager;
        // here the right place? 

        public MainCharacter(Texture2D texture, int numberOfSprites, float scale, Vector2 startPos, Vector2 speed) : base(texture, numberOfSprites, scale, startPos, speed)
        {
            movementManager = new MovementManager();
            InputReader = new KeyboardReader();
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }

        private void Move()
        {
            movementManager.MoveWithKeys(this);
        }
    }
}
