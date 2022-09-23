using SFML.Window;
using SFML.System;

namespace ShellEngine6.Engine
{
    public class Player
    {
        public double Angle => _playerAngle;
        public int X => (int)(_x);
        public int Y => (int)(_y);

        private double _x, _y;
        private double _playerAngle;

        private bool[] _keyFlags = new bool[6];
        private Keyboard.Key[] _keys = new Keyboard.Key[]
        {
            Keyboard.Key.W,
            Keyboard.Key.S,
            Keyboard.Key.A,
            Keyboard.Key.D,
            Keyboard.Key.Left,
            Keyboard.Key.Right
        };

        public Player()
        {
            _x = Settings.PlayerPosition.X;
            _y = Settings.PlayerPosition.Y;
            _playerAngle = Settings.PlayerAngle;
        }

        public Vector2f Position() => new Vector2f((int)_y, (int)_x);

        public void KeyAdd(KeyEventArgs keys)
        {
            for (int i = 0; i < 6; i++)
                _keyFlags[i] = _keyFlags[i] | _keys[i] == keys.Code;
        }

        public void KeyRemove(KeyEventArgs keys)
        {
            for (int i = 0; i < 6; i++)
                _keyFlags[i] = _keyFlags[i] ^ _keys[i] == keys.Code;
        }

        public void Movement()
        {
            double sinA = Math.Sin(_playerAngle);
            double cosA = Math.Cos(_playerAngle);

            if (_keyFlags[0] == true)
            {
                _x += Settings.PlayerSpeed * cosA;
                _y += Settings.PlayerSpeed * sinA;
                Console.WriteLine("W");
            }
            if (_keyFlags[1] == true)
            {
                _x += -Settings.PlayerSpeed * cosA;
                _y += -Settings.PlayerSpeed * sinA;
                Console.WriteLine("S");
            }
            if (_keyFlags[2] == true)
            {
                _x += Settings.PlayerSpeed * sinA;
                _y += -Settings.PlayerSpeed * cosA;
                Console.WriteLine("A");
            }
            if (_keyFlags[3] == true)
            {
                _x += -Settings.PlayerSpeed * sinA;
                _y += Settings.PlayerSpeed * cosA;
                Console.WriteLine("D");
            }
            if (_keyFlags[4] == true)
            {
                _playerAngle -= 0.003;
                Console.WriteLine("Left");
            }
            if (_keyFlags[5] == true)
            {
                _playerAngle += 0.003;
                Console.WriteLine("Right");
            }
        }
    }
}
