using TrafficLights.Enums;

namespace TrafficLights
{
    public class TrafficLights
    {
        private readonly int _sizeX;
        private readonly int _sizeY;
        Bulb[,] bulbs;

        public TrafficLights(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            bulbs = new Bulb[sizeY, sizeX]; 
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    if (y % 2 == 1 && x == 1)
                    {
                        switch (y)
                        {
                            case 1:
                                bulbs[y, x] = new Bulb(BulbType.Red);
                                bulbs[y, x].TurnOn();
                                break;
                            case 3:
                                bulbs[y, x] = new Bulb(BulbType.Yellow);
                                break;
                            case 5:
                                bulbs[y, x] = new Bulb(BulbType.Green);
                                break;
                        }
                    }
                    else
                    {
                        bulbs[y, x] = new Bulb(BulbType.Empty);
                    }
                }
            }
        }
        public void SwitchLight(ref int i)
        {
            if (i <= 4)
            {
                bulbs[i - 1, 1].TurnOff();
                bulbs[i + 1, 1].TurnOn();
            }
            else if (i == 6)
            {
                bulbs[i - 1, 1].TurnOff();
                i = 0;
                bulbs[i + 1, 1].TurnOn();
            }
        }
        public void Draw()
        {
            for (int y = 0; y < _sizeY + 3; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    if (y < _sizeY)
                    {
                        bulbs[y, x].Draw(x + 9, y + 2);
                    }
                    else if (y >= _sizeY && x == 1)
                    {
                        Bulb block = new Bulb(BulbType.Empty);
                        block.Draw(x + 9, y + 2);
                    }
                }
            }
        }

    }
}
