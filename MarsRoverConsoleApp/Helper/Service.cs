using MarsRoverConsoleApp.Enums;
using MarsRoverConsoleApp.Position;
using System;
using System.Collections.Generic;

namespace MarsRoverConsoleApp.Helper
{
    public static class Service
    {
        public static Response GoAround(List<string> UpperRihgts, string commands, RoverPosition roverPosition)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        MoveDirectSameDirection(roverPosition);
                        break;
                    case 'L':
                        ChangeDirectionWithLeft(roverPosition);
                        break;
                    case 'R':
                        ChangeDirectionWithRight(roverPosition);
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }

                if (roverPosition.X < 0 || roverPosition.X > Convert.ToInt32(UpperRihgts[0]))
                {
                    return new Response
                    {
                        Data = roverPosition,
                        ErrorMessage = "Girilen komutlar sonucunda alt sınır aşıldı.",
                        IsSuccess = false
                    };
                }
                if (roverPosition.Y < 0 || roverPosition.Y > Convert.ToInt32(UpperRihgts[1]))
                {
                    return new Response
                    {
                        Data = roverPosition,
                        ErrorMessage = "Girilen komutlar sonucunda üst sınır aşıldı.",
                        IsSuccess = false
                    };
                }
            }

            return new Response
            {
                Data = roverPosition,
                ErrorMessage = ""
            };

        }

        public static void MoveDirectSameDirection(RoverPosition roverPosition)
        {
            switch (roverPosition.Direction)
            {
                case DirectionEnum.N:
                    roverPosition.Y = roverPosition.Y + 1;
                    break;
                case DirectionEnum.S:
                    roverPosition.Y = roverPosition.Y - 1;
                    break;
                case DirectionEnum.E:
                    roverPosition.X = roverPosition.X + 1;
                    break;
                case DirectionEnum.W:
                    roverPosition.X = roverPosition.X - 1;
                    break;
                default:
                    break;
            }
        }

        public static void ChangeDirectionWithLeft(RoverPosition roverPosition)
        {
            switch (roverPosition.Direction)
            {
                case DirectionEnum.N:
                    roverPosition.Direction = DirectionEnum.W;
                    break;
                case DirectionEnum.S:
                    roverPosition.Direction = DirectionEnum.E;
                    break;
                case DirectionEnum.E:
                    roverPosition.Direction = DirectionEnum.N;
                    break;
                case DirectionEnum.W:
                    roverPosition.Direction = DirectionEnum.S;
                    break;
                default:
                    break;
            }
        }

        public static void ChangeDirectionWithRight(RoverPosition roverPosition)
        {
            switch (roverPosition.Direction)
            {
                case DirectionEnum.N:
                    roverPosition.Direction = DirectionEnum.E;
                    break;
                case DirectionEnum.S:
                    roverPosition.Direction = DirectionEnum.W;
                    break;
                case DirectionEnum.E:
                    roverPosition.Direction = DirectionEnum.S;
                    break;
                case DirectionEnum.W:
                    roverPosition.Direction = DirectionEnum.N;
                    break;
                default:
                    break;
            }
        }
    }
}
