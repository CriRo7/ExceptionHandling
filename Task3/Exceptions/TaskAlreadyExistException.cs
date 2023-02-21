using System;
using Task3.DoNotChange;

namespace Task3.Exceptions
{
    public class TaskAlreadyExistException : Exception
    {
        public UserTask Task { get; }
        public TaskAlreadyExistException(string message) : base(message) { }

        public TaskAlreadyExistException(string message, UserTask task) : base(message)
        {
            Task = task;
        }
    }
}