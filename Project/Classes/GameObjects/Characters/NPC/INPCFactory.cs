using Microsoft.Xna.Framework;
using Project.Classes.Visuals.Animations;

namespace Project.Classes.GameObjects.Characters.NPC
{
    internal interface INPCFactory
    {
        NPC CreateNPC(AnimationManager animationManager, Vector2 position);
    }
}
