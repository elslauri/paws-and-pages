using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NVorbis.Contracts;
using Project.Classes.Animations;
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

namespace Project.Classes.GameObjects
{
    internal class Friend : Character
    {
        private MovementManager movementManager;
        private Character player;

        public Friend(Texture2D texture, int numberOfSprites, float scale, Vector2 position, Vector2 speed, Character player) : base(texture,numberOfSprites, scale, position, speed)
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
            movementManager.MoveWithMC(this, player);
        }
    }
}
