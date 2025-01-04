using Microsoft.Xna.Framework;
using Project.Classes.GameObjects.Characters.NPC;
using System.Collections.Generic;

namespace Project.Classes.Scenes.Levels
{
    internal class LevelConfiguration
    {
        public int[,] FloorPlan { get; set; }
        public int MinBooksPerOrder { get; set; }
        public int MaxBooksPerOrder { get; set; }
        public List<(Vector2 position, NpcMoveType npcMoveType)> NpcData { get; set; }


        public LevelConfiguration(int[,] floorPlan, int minBooksPerOrder, int maxBooksPerOrder, List<(Vector2 position, NpcMoveType npcMoveType)> npcData)
        {
            FloorPlan = floorPlan;
            MinBooksPerOrder = minBooksPerOrder;
            MaxBooksPerOrder = maxBooksPerOrder;
            NpcData = npcData;
        }
    }
}
