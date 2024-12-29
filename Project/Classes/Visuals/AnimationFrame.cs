using Microsoft.Xna.Framework;

namespace Project.Classes.Animations
{
    internal class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        public AnimationFrame(Rectangle sourceRectangle)
        {
            this.SourceRectangle = sourceRectangle;
        }
    }
}
