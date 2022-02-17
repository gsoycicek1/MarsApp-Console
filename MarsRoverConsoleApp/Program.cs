using MarsRoverConsoleApp.Enums;
using MarsRoverConsoleApp.Helper;
using MarsRoverConsoleApp.Position;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Input Upper Right Coordinates
            Console.WriteLine("Plato için X ve Y üst sınırlarını giriniz (Örn: 5 5)");
            var upperRightCoordinate = Console.ReadLine().Trim().Split(' ');

            List<string> upperRightCoordinates = new List<string>();
            upperRightCoordinates.AddRange(upperRightCoordinate.Select(w => w.ToString()));
            #endregion

            #region Input Initial start rover position
            Console.WriteLine("Başlangıç noktasını giriniz (Örn: 1 3 N)");
            var initialPoints = Console.ReadLine().ToUpper().Trim().Split(' ');

            RoverPosition roverPosition = new RoverPosition();
            if (initialPoints.Count() == 3)
            {
                roverPosition.X = Convert.ToInt32(initialPoints[0]);
                roverPosition.Y = Convert.ToInt32(initialPoints[1]);
                roverPosition.Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), initialPoints[2]);
            }
            #endregion

            #region Input Commands
            Console.WriteLine("Komutları giriniz (Örn: LMMMLRMML)");
            var moves = Console.ReadLine().ToUpper();
            #endregion

            #region Call RoverPosition
            Response response = Service.GoAround(upperRightCoordinates, moves, roverPosition);
            #endregion

            #region Write Result
            Console.WriteLine("");
            if (response.IsSuccess) Console.WriteLine("Son Konum: " + roverPosition.X + " " + roverPosition.Y + " " + roverPosition.Direction.ToString());
            else Console.WriteLine("Hata: " + response.ErrorMessage);
            #endregion

        }
    }
}
