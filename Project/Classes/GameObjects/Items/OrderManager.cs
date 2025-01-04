using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Characters.NPC;
using Project.Classes.UI;
using System;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Items
{
    internal class OrderManager
    {
        private List<NPC> allNPCs;
        private Random rng;
        private Texture2D texture;
        private SpriteFont font;
        public OrderManager(List<NPC> npcs, Texture2D texture, SpriteFont font)
        {
            allNPCs = npcs;
            this.texture = texture;
            this.font = font;
            rng = new Random();
        }

        public List<Order> GenerateOrders(int minBooks, int maxBooks)
        {
            List<Order> orders = new List<Order>();
            foreach (NPC npc in allNPCs)
            {
                Order tempOrder = new Order(npc, texture, font);
                tempOrder.SetOrderMessage(GetRandomOrder(minBooks, maxBooks));
                orders.Add(tempOrder);
            }
            return orders;
        }

        /// <summary>
        /// returns an order as a string with the amount between the min and max values (inclusive)
        /// </summary>
        /// <param name="minBooks"></param>
        /// <param name="maxBooks">inclusive!</param>
        /// <returns>order as a string</returns>
        private string GetRandomOrder(int minBooks, int maxBooks)
        {
            int order = rng.Next(minBooks, maxBooks + 1);
            if (order == 1)
            {
                return $"{order} book please";
            }
            else
            {
                return $"{order} books please";
            }
        }
    }
}
