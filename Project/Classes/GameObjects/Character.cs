using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects
{
    internal class Character : IGameObject
    {
        private Texture2D texture;
        Animation animation;

        private Vector2 startPos = new Vector2(0, 0);
        

        // scale adjusted for testing on my screen
        private float scale = 3f;

        public Character(Texture2D texture)
        {
            this.texture = texture;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, startPos, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public void Update()
        {
            animation.Update();
        }
    }
}
