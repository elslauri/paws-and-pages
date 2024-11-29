using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Animations
{
    public interface IDrawable
    {
        Texture2D Texture { get; }
        Vector2 Position { get; set; }
        Rectangle SourceRectangle { get; }
        Color Color { get; }
        float Rotation { get; }
        Vector2 Origin { get; }
        float Scale { get; }

        void Draw(SpriteBatch spriteBatch);

    }
}
