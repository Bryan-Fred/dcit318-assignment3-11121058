using System;

namespace dcit318_assignment3_11121058.Q4_GradingSystem.Exceptions
{
    public class InvalidScoreFormatException : Exception
    {
        public InvalidScoreFormatException(string message) : base(message) { }
    }
}
