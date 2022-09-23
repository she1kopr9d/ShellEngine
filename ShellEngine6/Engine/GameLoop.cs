using SFML.Graphics;
using SFML.Window;
using System.Diagnostics;

namespace ShellEngine6.Engine
{
    public class GameLoop
    {
        private RenderWindow _screen;
        private Player _player;
        private Draw _brush;
        private RayCasting _rayCasting;

        public void Run()
        {
            _screen = new RenderWindow(new VideoMode(Settings.WIDTH, Settings.HEIGHT), "ShellEngine6");
            _screen.KeyPressed += Window_KeyPressed;
            _screen.KeyReleased += Window_KeyReleased;
            _player = new Player();
            _brush = new Draw(_screen);
            _rayCasting = new RayCasting(_brush);
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            long lastTime;
            
            while (_screen.IsOpen)
            {
                timer.Start();
                _screen.DispatchEvents();
                _screen.Clear();
                _player.Movement();
                _rayCasting.Update(_player.X, _player.Y, _player.Angle);
                _screen.Display();
                timer.Stop();
                lastTime = 1 / Settings.FPS * 1000 - timer.ElapsedMilliseconds;
                if (lastTime > 0)
                    Thread.Sleep((int)(lastTime));
                timer.Restart();
            }
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e) => _player.KeyAdd(e);

        private void Window_KeyReleased(object sender, KeyEventArgs e) => _player.KeyRemove(e);
    }
}
