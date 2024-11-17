using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects
{
    internal class NPC : Character
    {
        private Vector2 acceleration = new Vector2(0.1f, 0.1f);

        public NPC(Texture2D texture, int numberOfSprites, Vector2 position,float scale) : base(texture, numberOfSprites, position, scale)
        {
            base.Speed = new Vector2(0.1f, 0.1f);

        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }

        private void Move()
        {
            base.Position += base.Speed;
            base.Speed += acceleration;
            float maxSpeed = 5;
            base.Speed = Limit(base.Speed, maxSpeed);

            // TODO: collision box
            if (base.Position.X  + base.Speed.X > 1600 - 64 || base.Position.X + base.Speed.X < 0)
            {
                base.Speed = new Vector2(base.Speed.X < 0 ? 1 : -1, base.Speed.Y);
                acceleration.X *= -1;
            }
            if (base.Position.Y + base.Speed.Y > 960 - 96 || base.Position.Y + base.Speed.Y < 0)
            {
                base.Speed = new Vector2(base.Speed.X, base.Speed.Y < 0 ? 1 : -1);
                acceleration.Y *= -1;

            }
        }
        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() >max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

    }
}
