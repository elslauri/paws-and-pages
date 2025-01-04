using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Classes.Scenes.Levels
{
    internal class AdvancedLevel : Level
    {
        public AdvancedLevel(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager, int[,] floorPlan, int minBooksPerOrder, int maxBooksPerOrder)
            : base(graphics, spriteBatch, content, gameManager, floorPlan, minBooksPerOrder, maxBooksPerOrder)
        {
        }
    }
}
