using Microsoft.Xna.Framework;

namespace Project.Classes
{
    public static class Globals
    {
        public static int WindowSizeX { get; } = 1600;
        public static int WindowSizeY { get; } = 960;

        public static int MapSizeX { get; } = 2400;
        public static int MapSizeY { get; } = 1680;

        public static bool ShowCollision { get; } = false;

        public static Color BackGroundColor { get; } = new Color(52, 52, 79); 

    }
}
