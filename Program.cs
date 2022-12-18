using System.Diagnostics;
using System.Security.Cryptography;

namespace TrafficLights
{
    internal class Program
    {
        private const int MapWidth = 35;
        private const int MapHeight = 20;

        private const int ScreenWidth = MapWidth * 3;
        private const int ScreenHeight = MapHeight * 3;

        private const int TrafficSizeX = 3;
        private const int TrafficSizeY = 7;
        static void Main()
        {
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
            Console.SetBufferSize(ScreenWidth, ScreenHeight);
            Console.CursorVisible = false;

            TrafficLights tf = new TrafficLights(TrafficSizeX, TrafficSizeY);
            Stopwatch sw = new Stopwatch();
            for (int i = 2; i <= 6; i += 2)
            {
                tf.Draw();
                sw.Restart();

                switch (i)
                {
                    case 2:
                        while (sw.ElapsedMilliseconds < 15000) { }
                        Task.Run(() => Console.Beep(600, 200));
                        break;

                    case 4:
                        while (sw.ElapsedMilliseconds < 1000) { }
                        Task.Run(() => Console.Beep(800, 600));
                        break;

                    case 6:
                        while (sw.ElapsedMilliseconds < 20000) { }
                        Task.Run(() => Console.Beep(600, 200));
                        break;
                }
                tf.SwitchLight(ref i);
            }
            Console.ReadKey();
        }
    }
}