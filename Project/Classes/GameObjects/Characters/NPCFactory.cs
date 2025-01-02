using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Characters
{
    internal class NPCFactory : INPCFactory
    {
        private readonly float scale;
        private readonly Vector2 speed;
        private readonly List<ICollidable> obstacles;
     

        public NPCFactory(float scale, Vector2 speed, List<ICollidable> obstacles)
        {
            this.scale = scale;
            this.speed = speed;
            this.obstacles = obstacles;
        }

        public NPC CreateNPC(AnimationManager animationManager, Vector2 position)
        {
            return new NPC(animationManager, scale, position, speed, obstacles);
        }
    }
}
