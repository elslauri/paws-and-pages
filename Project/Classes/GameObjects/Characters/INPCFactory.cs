using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Characters
{
    internal interface INPCFactory
    {
        NPC CreateNPC(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, List<ICollidable> obstacles, Texture2D blockTexture );
    }
}
