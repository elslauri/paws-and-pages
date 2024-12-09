using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Project.Classes.GameObjects;
using IDrawable = Project.Classes.GameObjects.IDrawable;

namespace Project.Classes.Background
{
    public class Map : IDrawable
    {
        private Vector2 mapTileSize = new(40, 25); //times 48x48
        private Sprite[,] tiles;

        public Vector2 TileSize { get; set; }
        public Vector2 MapSize { get; set; }

        //aah
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Microsoft.Xna.Framework.Rectangle SourceRectangle { get; set; }
        public Microsoft.Xna.Framework.Color Color { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }



        public Map(List<Texture2D> textures)
        {
            tiles = new Sprite[(int)mapTileSize.X, (int)mapTileSize.Y];

            // textures[0]; only one type of texture

            TileSize = new Vector2(textures[0].Width, textures[0].Height);
            MapSize = new Vector2(TileSize.X * mapTileSize.X, TileSize.Y * mapTileSize.Y);

            for (int y = 0; y < mapTileSize.Y; y++)
            {
                for (int x = 0; x < mapTileSize.X; x++)
                {
                    tiles[x, y] = new Sprite(textures[0], new Vector2(x * TileSize.X, y * TileSize.Y));

                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < mapTileSize.Y; y++)
            {
                for (int x = 0; x < mapTileSize.X; x++)
                {
                    tiles[x, y].Draw(spriteBatch);
                }
            }
        }
    }
}
