using Microsoft.Xna.Framework;
using Project.Classes.Animations;

namespace Project.Classes.GameObjects.Characters
{
    internal interface INPCFactory
    {
        NPC CreateNPC(AnimationManager animationManager, Vector2 position );
    }
}
