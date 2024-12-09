using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects;
using Project.Classes.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project.Classes.Background
{
    internal class Floor : IGameObject, GameObjects.IDrawable
    {

        #region members
        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public Color Color { get; set; }

        public float Rotation { get; set; }

        public Vector2 Origin { get; set; }

        public float Scale { get; set; }

        #endregion

        // TODO: refactor everything that needs to be drawn with / without animation
        public Floor(Texture2D texture, float scale, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
            this.Scale = scale;
            SourceRectangle = new Rectangle(0, 0, 16, 16);
            Color = Color.White;
            Rotation = 0f;
            Origin = Vector2.Zero;
        }

        public void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(Texture, Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects.None, 0f);
        }
        

    }
}
