using Project.Classes.GameObjects.Characters;
using Project.Classes.GameObjects.Items;
using System.Collections.Generic;

namespace Project.Classes.Scenes.Checkers
{
    internal class DeliveryChecker
    {
        private MainCharacter player;
        private List<Order> orders;

        public DeliveryChecker(MainCharacter player, List<Order> orders)
        {
            this.player = player;
            this.orders = orders;
        }

        /// <summary>
        /// Checks if the player has delivered a book
        /// </summary>
        public void CheckBookDelivery()
        {
            foreach (Order order in orders)
            {
                if (player.ColBox.IsCollidingWith(order.Orderer.ColBox) && !order.IsComplete)
                {
                    player.DeliverBooksTo(order);
                }
            }
        }
    }
}
