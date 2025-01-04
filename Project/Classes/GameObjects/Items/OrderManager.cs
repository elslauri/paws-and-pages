using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Characters.NPC;
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
                Order tempOrder = new Order(npc, texture, font, GetRandomAmount(minBooks, maxBooks));
                orders.Add(tempOrder);
            }
            return orders;
        }

        /// <summary>
        /// returns an order as anint with the amount between the min and max values (inclusive)
        /// </summary>
        /// <param name="minBooks"></param>
        /// <param name="maxBooks">inclusive!</param>
        /// <returns>order as an int</returns>
        private int GetRandomAmount(int minBooks, int maxBooks)
        {
            return rng.Next(minBooks, maxBooks + 1);
        }
    }
}
