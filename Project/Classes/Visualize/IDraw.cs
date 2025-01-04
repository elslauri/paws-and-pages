using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project.Classes.Visuals
{
    public interface IDraw
    {
        // Texture2D Texture { get; }
        Vector2 Position { get; set; }
        //Color Color { get; }
        // float Rotation { get; }
        // Vector2 Origin { get; }
        //  float Scale { get; }

        void Draw(SpriteBatch spriteBatch);

        // TODO: removed the SourceRectangle because only necessary for static non animated objects so maybe move to another interface? 
    }
}
