using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Visuals;

namespace Project.Classes.UI
{
    internal class Bubble : IDraw
    {
        public Vector2 Position { get; set; }

        private Texture2D texture;
        
        private Vector2 position;

        public int Width { get; private set; }
        public int Height { get; private set; }

        private Rectangle[] sourceRectangles;
        private Rectangle[] destinationRectangles;

        private readonly int cornerSize;

        private readonly SpriteFont font;
        private Color textColor;
        private string message = "";
        private Vector2 textPos;

        

        public Bubble(Texture2D texture, SpriteFont font)
        {
            this.texture = texture;
            
            cornerSize = 10; 

            this.font = font;
            textColor = new Color(201, 173, 161);


            sourceRectangles = new Rectangle[9];
            destinationRectangles = new Rectangle[9];

            sourceRectangles[0] = new(0, 0, cornerSize, cornerSize);
            sourceRectangles[1] = new(cornerSize, 0, this.texture.Width - 2 * cornerSize, cornerSize);
            sourceRectangles[2] = new(this.texture.Width - cornerSize, 0, cornerSize, cornerSize);
            sourceRectangles[3] = new(0, cornerSize, cornerSize, this.texture.Height - 2 * cornerSize);
            sourceRectangles[4] = new(cornerSize, cornerSize, this.texture.Width - 2 * cornerSize, this.texture.Height - 2 * cornerSize);
            sourceRectangles[5] = new(this.texture.Width - cornerSize, cornerSize, cornerSize, this.texture.Height - 2 * cornerSize);
            sourceRectangles[6] = new(0, this.texture.Height - cornerSize, cornerSize, cornerSize);
            sourceRectangles[7] = new(cornerSize, this.texture.Height - cornerSize, this.texture.Width - 2 * cornerSize, cornerSize);
            sourceRectangles[8] = new(this.texture.Width - cornerSize, this.texture.Height - cornerSize, cornerSize, cornerSize);
        }

        public void CalculateDestinationRectangles()
        {
            var textSize = font.MeasureString(message);
            Width = (int)textSize.X + 2 * cornerSize;
            Height = (int)textSize.Y + 2 * cornerSize;

            int x = (int)position.X;
            int y = (int)position.Y;
            int w = Width - 2 * cornerSize;
            int h = Height - 2 * cornerSize;

            textPos = new(x + cornerSize, y + cornerSize);

            destinationRectangles[0] = new(x, y, cornerSize, cornerSize);
            destinationRectangles[1] = new(x + cornerSize, y, w, cornerSize);
            destinationRectangles[2] = new(x + Width - cornerSize, y, cornerSize, cornerSize);
            destinationRectangles[3] = new(x, y + cornerSize, cornerSize, h);
            destinationRectangles[4] = new(x + cornerSize, y + cornerSize, w, h);
            destinationRectangles[5] = new(x + Width - cornerSize, y + cornerSize, cornerSize, h);
            destinationRectangles[6] = new(x, y + Height - cornerSize, cornerSize, cornerSize);
            destinationRectangles[7] = new(x + cornerSize, y + Height - cornerSize, w, cornerSize);
            destinationRectangles[8] = new(x + Width - cornerSize, y + Height - cornerSize, cornerSize, cornerSize);
        }

        public void SetMessage(string message)
        {
            this.message = message;
            CalculateDestinationRectangles();
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
            CalculateDestinationRectangles();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < sourceRectangles.Length; i++)
            {
                spriteBatch.Draw(texture, destinationRectangles[i], sourceRectangles[i], Color.White);
            }

            spriteBatch.DrawString(font, message, textPos, textColor);
        }
    }
}


// For this code I copied almost letter by letter from a tutorial I found online.
// For the other tutorials I watched, I did my own thing with what I learned, but this one is almost a perfect copy. 
// This is the link: https://www.youtube.com/watch?v=vR9pozv9bjM
