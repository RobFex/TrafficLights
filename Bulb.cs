using TrafficLights.Enums;

namespace TrafficLights
{
    public class Bulb
    {
        private ConsoleColor _color;
        
        public BulbType Type { get; set; }
        public Status Status = Status.Off;

        public Bulb(BulbType bType)
        {
            Type = bType;
            if (Status == Status.On)
            {
                switch (Type)
                {
                    case BulbType.Green:
                        _color = ConsoleColor.Green;
                        break;

                    case BulbType.Yellow:
                        _color = ConsoleColor.Yellow;
                        break;

                    case BulbType.Red:
                        _color = ConsoleColor.Red;
                        break;
                }
            }
            else if (Status == Status.Off && Type != BulbType.Empty)
            {
                _color = ConsoleColor.Gray;
            }
        }

        public void Draw(int x, int y)
        {
            Pixel bulb = new Pixel(_color, x, y, 5);
            bulb.Draw();
        }

        public void TurnOn()
        {
            Status = Status.On;
            switch (Type)
            {
                case BulbType.Green:
                    _color = ConsoleColor.Green;
                    break;

                case BulbType.Yellow:
                    _color = ConsoleColor.Yellow;
                    break;

                case BulbType.Red:
                    _color = ConsoleColor.Red;
                    break;
            }
        }
        public void TurnOff()
        {
            Status = Status.Off;
            if (Type != BulbType.Empty)
            {
                _color = ConsoleColor.Gray;
            }
        }
    }
}
