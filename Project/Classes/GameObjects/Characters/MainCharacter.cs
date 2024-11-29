using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Classes.Input;
using Project.Classes.Movement;
using Project.Classes.Collision;
using static System.Net.Mime.MediaTypeNames;

namespace Project.Classes.GameObjects.Characters
{
    internal class MainCharacter : Character
    {
        private MovementManager movementManager;

        private List<ICollidable> obstacles;

        public MainCharacter(Texture2D texture, int spriteColumns, int spriteRows, float scale, Vector2 startPos, Vector2 speed, List<ICollidable> obstacles, Texture2D blockTexture) : base(texture, spriteColumns, spriteRows, scale, startPos, speed, blockTexture)
        {
            movementManager = new MovementManager();
            InputReader = new KeyboardReader();
            this.obstacles = obstacles;
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }

        private void Move()
        {
            movementManager.MoveWithKeys(this, obstacles);
        }


    }
}
