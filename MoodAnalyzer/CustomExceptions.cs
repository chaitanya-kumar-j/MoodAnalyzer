using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class CustomExceptions : Exception
    {
        private readonly ExceptionType type;
        public CustomExceptions(ExceptionType Type, string message) : base(message)
        {
            this.type = Type;
        }
        public enum ExceptionType
        {
            NULL_MOOD, EMPTY_MOOD, NO_SUCH_CLASS, NO_SUCH_METHOD
        }
    }
}
