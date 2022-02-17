using System;

namespace MarsRoverConsoleApp
{
    public class Response
    {
        public Object Data { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}
