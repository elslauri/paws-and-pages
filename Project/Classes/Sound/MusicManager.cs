using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Project.Classes.Sound
{
    internal class MusicManager
    {
        private Song levelMusic;
        private Song menuMusic;
        
        public void Initialize(ContentManager content)
        {
            levelMusic = content.Load<Song>("levelMusic");
            menuMusic = content.Load<Song>("menuMusic");

            MediaPlayer.Volume = 0.1f;
        }

        public void PlayMenuMusic()
        {
            LetTheMusicPlay(menuMusic);
        }
        public void PlayLevelMusic()
        {
            LetTheMusicPlay(levelMusic);
        }
        private void LetTheMusicPlay(Song song)
        {
            if (MediaPlayer.State != MediaState.Stopped)
            {
                MediaPlayer.Stop();
            }
            MediaPlayer.Play(song);
        }
    }
}
