using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NVorbis.Contracts;
using Project.Classes.Animations;
using Project.Classes.Collision;
using Project.Classes.Input;
using Project.Classes.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Formats.Asn1.AsnWriter;

namespace Project.Classes.GameObjects.Characters
{
    internal class Friend : Character
    {
        private MovementManager movementManager;
        private Character player;

        public Friend(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, Character player, List<ICollidable> obstacles,Texture2D blockTexture) : 
            base(animationManager, scale, position, speed, obstacles, blockTexture)
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
            movementManager.MoveWithTarget(this, player, new Vector2(0, -20f));
        }
    }
}
