using Microsoft.Xna.Framework.Audio;
using Project.Classes.GameObjects.Characters;
using System.Net.Mime;

namespace Project.Classes.Sound
{
    internal class SoundEffectManager
    {
        private SoundEffect pickUpBook;
        public SoundEffectManager(MainCharacter player, SoundEffect pickUpBook)
        {
            this.pickUpBook = pickUpBook;
            player.OnPickUp += PlayPickUpSound;
        }
        private void PlayPickUpSound(int books)
        {
            pickUpBook.Play();
        }
    }
}
