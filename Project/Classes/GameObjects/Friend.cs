using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Formats.Asn1.AsnWriter;

namespace Project.Classes.GameObjects
{
    internal class Friend : IGameObject
    {
        // move later
        private Texture2D texture;
        Animation animation;

        // TODO: refactor
        private Vector2 position;
        private Vector2 speed;
        
        public Friend(Texture2D texture, int numberOfSprites, Vector2 position, Vector2 speed)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;

            // TODO: number of animations
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, numberOfSprites, 1);
        }

        public void Update(GameTime gameTime)
        {
            MoveWithMouse();
            animation.Update(gameTime);
   
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White);

            // TODO: also needs drawing? move draw from character to abstract spriteDrawer class? 
        }
        private void MoveWithMouse()
        {
            MouseState state = Mouse.GetState();
            Vector2 mouseVector = new Vector2(state.X, state.Y);

            var direction = mouseVector - position;
            direction.Normalize();
            var distance = Vector2.Multiply(direction,0.1f);
            speed += direction;
            speed = Limit(speed, 10);
            position += speed;
        }

        // TODO: read the ppt about accelaration
        private Vector2 Limit(Vector2 v, float max)
        {
            float length = v.Length();
            if (length > max)
            {
                float ratio = max / length;
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

    }
}
