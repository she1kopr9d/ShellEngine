using SFML.Graphics;
using SFML.System;

namespace ShellEngine6.Engine
{
    public class RayCasting
    {
        private Draw _brush;
        private char[,] _map = new char[,]
        {
            { 'W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W'},
            { 'W','.','W','.','.','.','.','.','.','.','.','W','.','.','.','.','.','.','.','.','.','.','.','W'},
            { 'W','.','W','.','W','W','W','W','.','W','.','W','.','.','.','.','.','.','.','.','.','.','.','W'},
            { 'W','.','W','.','.','.','.','.','.','W','.','W','.','.','.','.','.','.','.','.','.','.','.','W'},
            { 'W','.','W','.','.','.','.','.','.','W','.','W','.','.','.','.','.','.','.','.','.','.','.','W'},
            { 'W','.','W','.','W','W','W','W','.','W','.','W','.','.','.','.','.','.','.','.','.','.','.','W'},
            { 'W','.','.','.','.','.','.','.','.','W','.','.','.','.','.','.','.','.','.','.','.','.','.','W'},
            { 'W','.','W','W','W','W','W','W','.','W','.','W','W','W','W','W','W','W','W','W','.','.','.','W'},
            { 'W','.','.','W','.','.','.','W','.','W','.','.','.','.','.','.','.','.','.','W','.','.','.','W'},
            { 'W','.','.','W','.','W','.','W','.','W','.','.','.','.','.','.','.','.','.','W','W','W','W','W'},
            { 'W','.','.','.','.','W','.','W','.','W','.','W','W','W','W','W','W','.','.','W','.','.','.','W'},
            { 'W','.','W','W','W','W','.','W','.','W','.','W','.','.','.','.','W','.','.','W','.','.','.','W'},
            { 'W','.','.','W','.','.','.','W','.','W','.','W','.','.','W','.','W','.','.','W','W','W','.','W'},
            { 'W','.','.','W','.','W','W','W','.','W','.','W','W','W','W','.','W','.','.','.','.','.','.','W'},
            { 'W','.','.','W','.','.','.','.','.','W','.','.','.','.','.','.','W','.','.','.','.','.','.','W'},
            { 'W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W'}
        };

        public RayCasting(Draw brush)
        {
            _brush = brush;
        }

        public void Update(double x, double y, double angle)
        {
            double curAngle = angle - Settings.HALFFOV;
            double xO, yO;
            xO = x;
            yO = y;
            for (int ray = 0; ray < Settings.NUMRAYS; ray++)
            {
                double sinA = Math.Sin(curAngle);
                double cosA = Math.Cos(curAngle);
                for (double depth = 0; depth < Settings.MAXDEPTH; depth++)
                {
                    x = xO + depth * cosA;
                    y = yO + depth * sinA;
                    if (_map[(int)(x / Settings.TILESIZE), (int)(y / Settings.TILESIZE)] == 'W')
                    {
                        if (depth == 0)
                            break;
                        depth *= Math.Cos(angle - curAngle);
                        double projectiveHeight = Settings.PROJECTIVECOEF / depth;
                        byte colorByte = (byte)(255 / (1 + depth * depth * 0.00002));
                        _brush.Rect((int)(ray * Settings.SCALE),
                            (int)(Settings.HALFHEIGHT - (int)(projectiveHeight / 2)),
                            (int)(Settings.SCALE),
                            (int)(projectiveHeight),
                            new Color(colorByte, (byte)(colorByte / 2), (byte)(colorByte / 3)));
                        break;
                    }
                }
                curAngle += Settings.DELTAANGLE;
            }
        }
    }
}
