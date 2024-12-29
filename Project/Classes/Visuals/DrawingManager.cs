using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Background;
using System.Collections.Generic;


namespace Project.Classes.Animations
{
    internal class DrawingManager
    {
        private SpriteBatch spriteBatch;
        // statisch tekenen en geanimeerd tekenen
        public DrawingManager(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Draw(IEnumerable<GameObjects.IDraw> drawables)
        {
            spriteBatch.Begin(transformMatrix: Camera.GetTheCamera().translation, samplerState: SamplerState.PointClamp);

            foreach (var d in drawables)
            {

                d.Draw(spriteBatch);

            }
            spriteBatch.End();
        }
    }
}
