using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.Animations;
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
        
        
        public Friend(Texture2D texture, int numberOfSprites, float scale, Vector2 position, Vector2 speed) : base(texture,numberOfSprites, position, scale)
        {

        }

        public void Update(GameTime gameTime)
        {
            MoveWithMouse();
            base.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }
        private void MoveWithMouse()
        {
            MouseState state = Mouse.GetState();
            Vector2 mouseVector = new Vector2(state.X, state.Y);

            var direction = mouseVector - base.Position;
            direction.Normalize();
            var distance = Vector2.Multiply(direction,0.1f);
            base.Speed += direction;
            base.Speed = Limit(base.Speed, 10);
            base.Position += base.Speed;
        }

        // TODO: read the ppt about accelaration
        private Vector2 Limit(Vector2 v, float max)
        {
            float length = v.Length();
            if (length > max)
            {
                float ratio = max / length;
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

    }
}
