using SFML.System;

namespace ShellEngine6.Engine
{
    public static class Settings
    {
        public static uint WIDTH = 1200;
        public static uint HEIGHT = 800;

        public static uint HALFWIDTH = 600;
        public static uint HALFHEIGHT = 400;

        public static uint FPS = 60;

        public static uint TILESIZE = 50;

        public static double FOV = Math.PI / 3;
        public static double HALFFOV = FOV / 2;
        public static uint NUMRAYS = 1200;
        public static int MAXDEPTH = 800;
        public static double DELTAANGLE = FOV / NUMRAYS;
        public static double DISTANCE = NUMRAYS / (2 * Math.Tan(HALFFOV));
        public static double PROJECTIVECOEF = 1 * DISTANCE * TILESIZE; // 50000
        public static double SCALE = 1;

        public static Vector2f PlayerPosition = new Vector2f(600, 400);
        public static double PlayerAngle = 90;
        public static float PlayerSpeed = 0.2f;
    }
}
