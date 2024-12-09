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

namespace Project.Classes.Animations
{
    internal class DrawingManager
    {
        private SpriteBatch spriteBatch;

        public DrawingManager(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Draw( IEnumerable<GameObjects.IDrawable> drawables, Matrix translation)
        {
            spriteBatch.Begin(transformMatrix: translation);
            foreach (var d in drawables)
            {
                
                d.Draw(spriteBatch);
                
            }
            spriteBatch.End();
        }
    }
}
