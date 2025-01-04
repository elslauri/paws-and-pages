using Microsoft.Xna.Framework;
using Project.Classes.Visuals.Animations;

namespace Project.Classes.GameObjects.Characters.NPC
{
    internal interface INPCFactory
    {
        NPC CreateNPC(AnimationManager animationManager, Vector2 position, Vector2 speed, float maxSpeed);
        public NPC CreateRandomNPC(Vector2 position, NpcMoveType npcMoveType);
    }
}
