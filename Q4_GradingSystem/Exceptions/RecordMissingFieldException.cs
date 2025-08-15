using System;

namespace dcit318_assignment3_11121058.Q4_GradingSystem.Exceptions
{
    public class RecordMissingFieldException : Exception
    {
        public RecordMissingFieldException(string message) : base(message) { }
    }
}
