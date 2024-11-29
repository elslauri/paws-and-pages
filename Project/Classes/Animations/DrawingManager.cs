using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Animations
{
    internal class DrawingManager
    {
        private SpriteBatch spriteBatch;

        public DrawingManager(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Draw( IEnumerable<IDrawable> drawables, Box test)
        {
            spriteBatch.Begin();
            test.Draw(spriteBatch);
            foreach (var d in drawables)
            {
                
                d.Draw(spriteBatch);
                
            }
            spriteBatch.End();
        }
    }
}
