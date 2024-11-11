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
        //private Rectangle rectangle;
        //private int moveX = 0;

        // scale adjusted for testing on my screen
        private float scale = 3f;

        public Character(Texture2D texture)
        {
            this.texture = texture;
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(32, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(64, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(96, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(128, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(160, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(192, 0, 32, 32)));
            animation.AddFrame(new AnimationFrame(new Rectangle(224, 0, 32, 32)));
            //rectangle = new Rectangle(moveX, 0, 32, 32);
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
