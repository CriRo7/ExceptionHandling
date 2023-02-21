using System;
using System.Linq;

namespace Task3.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string UserId { get; } 
        public UserNotFoundException(string message): base(message) { }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public UserNotFoundException(string message, string userId) : base(message)
        {
            UserId = userId;
        }
    }
}