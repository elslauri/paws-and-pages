using Project.Classes.GameObjects.Items;
using System.Collections.Generic;

namespace Project.Classes.Scenes
{
    internal class LevelCompletionChecker
    {
        public bool IsLevelComplete(List<Order> orders)
        {
            foreach (var order in orders)
            {
                if (!order.IsComplete)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
