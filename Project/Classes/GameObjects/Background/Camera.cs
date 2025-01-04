using Microsoft.Xna.Framework;
using Project.Classes.Visuals;

namespace Project.Classes.GameObjects.Background
{
    public class Camera : IGameObject
    {
        public Matrix translation;
        public Map map { get; set; }

        private IDraw anchor;

        private static Camera theCamera;
        private Camera() { }
        public static Camera GetTheCamera() // check if no problem
        {
            if (theCamera == null)
            {
                theCamera = new Camera();
            }
            return theCamera;
        }

        public void Initialize(Map map, IDraw anchor)
        {
            this.map = map;
            this.anchor = anchor;
        }

        public void Update(GameTime gameTime)
        {
            CalculateTranslation();
        }


        /// <summary>
        /// This function calculates the translation for the spritebatch. This gives the effect of a moving camera. 
        /// </summary>
        private void CalculateTranslation()
        {
            var dx = Globals.WindowSizeX / 2 - anchor.Position.X;
            dx = MathHelper.Clamp(dx, -map.MapSize.X + Globals.WindowSizeX + map.TileSize.X / 2, map.TileSize.X / 2);
            var dy = Globals.WindowSizeY / 2 - anchor.Position.Y;
            dy = MathHelper.Clamp(dy, -map.MapSize.Y + Globals.WindowSizeY + map.TileSize.Y / 2, map.TileSize.Y / 2);
            translation = Matrix.CreateTranslation(dx, dy, 0);
        }
    }
}
