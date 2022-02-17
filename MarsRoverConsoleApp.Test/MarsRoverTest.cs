using MarsRoverConsoleApp.Enums;
using MarsRoverConsoleApp.Helper;
using MarsRoverConsoleApp.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarsRoverConsoleApp.Test
{
    public class MarsRoverTest
    {
        [Fact]
        public void Program_Test_North_Success()
        {
            RoverPosition roverPosition = new RoverPosition()
            {
                X = 1,
                Y = 2,
                Direction = DirectionEnum.N
            };

            var upperRights = new List<string>() { "5", "5" };
            var commands = "LMLMLMLMM";

            Service.GoAround(upperRights, commands, roverPosition);

            var realresult = roverPosition.X + " " + roverPosition.Y + " " + roverPosition.Direction.ToString();

            Assert.Equal("1 3 N", realresult);
        }

        [Fact]
        public void Program_Test_East_Success()
        {
            RoverPosition roverPosition = new RoverPosition()
            {
                X = 3,
                Y = 3,
                Direction = DirectionEnum.E
            };

            var upperRights = new List<string>() { "15", "15" };
            var commands = "MMRMMRMRRM";

            Service.GoAround(upperRights, commands, roverPosition);

            var realresult = roverPosition.X + " " + roverPosition.Y + " " + roverPosition.Direction.ToString();

            Assert.Equal("5 1 E", realresult);
        }

        [Fact]
        public void Program_Test_East_Fail_BoundException()
        {
            RoverPosition roverPosition = new RoverPosition()
            {
                X = 3,
                Y = 3,
                Direction = DirectionEnum.E
            };

            var upperRights = new List<string>() { "2", "2" };
            var commands = "MMRMMRMRRM";

            Response response = Service.GoAround(upperRights, commands, roverPosition);

            var realresult = roverPosition.X + " " + roverPosition.Y + " " + roverPosition.Direction.ToString();

            Assert.False(response.IsSuccess);
        }
    }
}
