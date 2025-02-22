﻿using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Background;
using Project.Classes.Visuals;
using System.Collections.Generic;


namespace Project.Classes.Animations
{
    internal class DrawingManager
    {
        private SpriteBatch spriteBatch;
        // TODO: onderscheid statisch en geanimeerd tekenen? 
        public DrawingManager(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Draw(IEnumerable<IDraw> drawables, bool camera)
        {
            if (camera)
                spriteBatch.Begin(transformMatrix: Camera.GetTheCamera().translation, samplerState: SamplerState.PointClamp);
            else
                spriteBatch.Begin();

            foreach (var d in drawables)
            {

                d.Draw(spriteBatch);

            }
            spriteBatch.End();
        }
    }
}
