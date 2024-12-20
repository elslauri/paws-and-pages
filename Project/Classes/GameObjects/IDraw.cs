﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project.Classes.GameObjects
{
    public interface IDraw
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
