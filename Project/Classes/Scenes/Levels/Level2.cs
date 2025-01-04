using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Classes.Scenes.Levels
{
    internal class Level2 : Level
    {
        public Level2(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager, int[,] floorPlan)
            : base(graphics, spriteBatch, content, gameManager, floorPlan)
        {
        }
    }
}
