using MarsRoverConsoleApp.Enums;

namespace MarsRoverConsoleApp.Position
{
    public class RoverPosition
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public DirectionEnum Direction { get; set; } = DirectionEnum.N;
    }
}
