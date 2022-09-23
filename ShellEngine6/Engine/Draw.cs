using SFML.Window;
using SFML.System;
using SFML.Graphics;

namespace ShellEngine6.Engine
{
    public class Draw
    {
        private RenderWindow _screen;
        private RectangleShape _shape = new RectangleShape();

        public Draw(RenderWindow screen)
        {
            _screen = screen;
        }
        public void Rect(int x, int y, int sizeX, int sizeY, Color color) =>
            Rect(new Vector2f(x, y), sizeX, sizeY, color);

        public void Rect(Vector2f position, int sizeX, int sizeY, Color color)
        {
            _shape.Size = new Vector2f(sizeX, sizeY);
            _shape.Position = position;
            _screen.Draw(_shape);
        }
    }
}
