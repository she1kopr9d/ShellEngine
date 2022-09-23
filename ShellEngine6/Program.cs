using System;
using SFML.Graphics;
using SFML.Window;

namespace ShellEngine6
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC key to close window");
            var window = new Engine.GameLoop();
            window.Run();

            Console.WriteLine("All done");
        }
    }
}