using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Project.Classes.Collision;
using System.Diagnostics;
using Project.Classes.Animations;

namespace Project.Classes.GameObjects.Items
{
    internal class Bookshelve : ICollidable, IDraw
    {
        public Texture2D Texture { get; set; }

        public Rectangle SourceRectangle { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public Color Color { get; set; }
        public CollisionBox BoxCollision { get; set; }

        public float Rotation { get; set; }

        public Vector2 Origin { get; set; }

        public float Scale { get; set; }

        public Bookshelve(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            Position = position + new Vector2(Texture.Width / 2, Texture.Height / 2);
            Color = Color.White;
            Scale = 3f;

            Size = new Vector2( Texture.Width, Texture.Height);

            Origin = new Vector2(0, 0); 

            SourceRectangle = new Rectangle(0,0, 64, 48);


            //BoxCollision = new CollisionBox(Position, Size, texture);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(Texture, Position, SourceRectangle, Color.White, 0f, Origin, Scale, SpriteEffects.None, 0f);
          
        }
    }
}
