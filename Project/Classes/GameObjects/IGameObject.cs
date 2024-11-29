using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects
{
    internal interface IGameObject
    {
        void Update(GameTime gameTime);
       // moved to IDrawable
       //void Draw(SpriteBatch spriteBatch);
    }
}
