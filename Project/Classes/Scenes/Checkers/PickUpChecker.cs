using Project.Classes.GameObjects.Characters;
using Project.Classes.GameObjects.Items;
using System.Collections.Generic;

namespace Project.Classes.Scenes.Checkers
{
    internal class PickUpChecker
    {
        private MainCharacter player;
        private List<Book> books;
        private List<Book> booksToBeDeleted;

        public PickUpChecker(MainCharacter player, List<Book> books, List<Book> booksToBeDeleted)
        {
            this.player = player;
            this.books = books;
            this.booksToBeDeleted = booksToBeDeleted;
        }


        /// <summary>
        /// Checks if the player has picked up a book and removes it from the drawn books
        /// </summary>
        public void CheckBookPickUp()
        {
            foreach (Book book in books)
            {
                if (player.ColBox.IsCollidingWith(book.ColBox))
                {
                    booksToBeDeleted.Add(book);
                    player.PickUpBook();
                }
            }
            RemoveToBeDeletedBooks();
        }
        private void RemoveToBeDeletedBooks()
        {
            foreach (Book book in booksToBeDeleted)
            {
                books.Remove(book);
            }
            booksToBeDeleted.Clear();
        }
    }
}
